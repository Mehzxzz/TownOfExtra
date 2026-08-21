using MiraAPI.GameOptions;
using MiraAPI.Keybinds;
using MiraAPI.Networking;
using MiraAPI.Utilities.Assets;
using TownOfExtra.Options.Roles;
using TownOfExtra.Roles.Neutral.Killing;
using TownOfUs;
using TownOfUs.Buttons;
using TownOfUs.Networking;
using TownOfUs.Options.Modifiers.Alliance;
using TownOfUs.Utilities;
using UnityEngine;

namespace TownOfExtra.Buttons;

public sealed class VultureDigestButton : TownOfUsKillRoleButton<VultureRole, PlayerControl>, IDiseaseableButton, IKillButton
{
    public override string Name => "Digest";
    public override BaseKeybind Keybind => Keybinds.PrimaryAction;
    public override Color TextOutlineColor => TownOfUsColors.Neutral;
    public override float Cooldown => GetCooldown()
    public override LoadableAsset<Sprite> Sprite => TownOfExtraAssets.AttackPh;

    public void SetDiseasedTimer(float multiplier)
    {
        SetTimer(Cooldown * multiplier);
    }
        public static float BaseCooldown => Math.Clamp(OptionGroupSingleton<VultureOptions>.Instance.DigestCooldown + MapCooldown, 5f, 120f);

    public override bool CanUse()
    {
      if (OptionsGroupSingleton<VultureOptions>.Instance.DigestObtainment == Off)
   {
      continue;
   }
   else
     {
   return base.CanUse() && VultureRole.DeadBodiesEaten => OptionsGroupSingleton<VultureOptions>.Instance.BodiesTillDigest;
    }
    }

    protected override void OnClick()
    {
        if (Target == null) return;

        PlayerControl.LocalPlayer.RpcSpecialMurder(Target, MeetingCheck.OutsideMeeting, causeOfDeath: "Digested");
    }

    public override PlayerControl GetTarget()
    {
        if (!OptionGroupSingleton<LoversOptions>.Instance.LoversKillEachOther && PlayerControl.LocalPlayer.IsLover())
        {
            return PlayerControl.LocalPlayer.GetClosestLivingPlayer(true, Distance, false, x => !x.IsLover());
        }

        return PlayerControl.LocalPlayer.GetClosestLivingPlayer(true, Distance);
    public static float GetCooldown()
    {
        var vulture = PlayerControl.LocalPlayer.Data.Role as VultureRole;

        if (vulture == null)
        {
            return BaseCooldown;
        }

        var options = OptionGroupSingleton<VultureOptions>.Instance;
  if (VultureRole.DeadBodiesEaten => 1)
   {
   return Math.Max(BaseCooldown - options.KillCooldownReduction.Value * VultureRole.DeadBodiesEaten, 0);
    }
    }
}