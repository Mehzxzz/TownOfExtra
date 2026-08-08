using System.Diagnostics.CodeAnalysis;
using MiraAPI.GameOptions;
using MiraAPI.Keybinds;
using MiraAPI.Networking;
using MiraAPI.Utilities.Assets;
using TownOfExtra.Options.Roles;
using TownOfExtra.Roles.Impostor.Killing;
using TownOfUs.Assets;
using TownOfUs.Buttons;
using TownOfUs.Networking;
using TownOfUs.Options;
using TownOfUs.Options.Maps;
using TownOfUs.Options.Modifiers.Alliance;
using TownOfUs.Utilities;
using TownOfUs.Utilities.Appearances;
using UnityEngine;

namespace TownOfExtra.Buttons;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class TaggerMarkButton : TownOfUsKillRoleButton<TaggerRole, PlayerControl>, IKillButton
{
    public override string Name => "Mark";
    public override BaseKeybind Keybind => Keybinds.SecondaryAction;
    public override Color TextOutlineColor => Palette.ImpostorRed;
    public override float Cooldown => OptionGroupSingleton<TaggerRoleOptions>.Instance.MarkCooldown;
    public override LoadableAsset<Sprite> Sprite => TownOfExtraAssets.TaggerMarkButton;

    private static Sprite _markSprite => TownOfExtraAssets.TaggerMarkButton.LoadAsset();
    private static Sprite _killSprite => TouAssets.KillSprite.LoadAsset();

    public override PlayerControl GetTarget()
    {
        PlayerControl target;
        
        var genOpt = OptionGroupSingleton<GeneralOptions>.Instance;
        var saboOpt = OptionGroupSingleton<AdvancedSabotageOptions>.Instance;
        var closePlayer = PlayerControl.LocalPlayer.GetClosestLivingPlayer(true, Distance);

        var includePostors = genOpt.FFAImpostorMode ||
                             (PlayerControl.LocalPlayer.IsLover() &&
                              OptionGroupSingleton<LoversOptions>.Instance.LoverKillTeammates) ||
                             (saboOpt.KillDuringCamoComms &&
                              closePlayer?.GetAppearanceType() == TownOfUsAppearances.Camouflage);
        if (!OptionGroupSingleton<LoversOptions>.Instance.LoversKillEachOther && PlayerControl.LocalPlayer.IsLover())
        {
            target = PlayerControl.LocalPlayer.GetClosestLivingPlayer(includePostors, Distance, false,
                x => !x.IsLover());
        }
        else
        {
            target = PlayerControl.LocalPlayer.GetClosestLivingPlayer(includePostors, Distance);
        }

        if (target == null || !TaggerRole.MarkedPlayers.Contains(target))
        {
            OverrideName("Mark");
            OverrideSprite(_markSprite);
        }
        else
        {
            OverrideName("Eliminate");
            OverrideSprite(_killSprite);
        }

        return target;
    }

    protected override void OnClick()
    {
        if (Target == null) return;

        if (TaggerRole.MarkedPlayers.Contains(Target))
        {
            PlayerControl.LocalPlayer.RpcSpecialMurder(
                Target, MeetingCheck.OutsideMeeting, resetKillTimer: false
            );
            TaggerRole.MarkedPlayers.Remove(Target);
        }
        else
        {
            TaggerRole.MarkedPlayers.Add(Target);
        }
    }
}