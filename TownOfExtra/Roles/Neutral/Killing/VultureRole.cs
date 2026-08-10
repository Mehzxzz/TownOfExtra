using System;
using System.Collections.Generic;
using System.Text;
using AmongUs.GameOptions;
using TownOfExtra.Options.Roles;
using Il2CppInterop.Runtime.Attributes;
using MiraAPI.GameOptions;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using TownOfExtra.Modules;
using TownOfUs;
using TownOfUs.Extensions;
using TownOfUs.Modules.Wiki;
using TownOfUs.Roles;
using TownOfUs.Roles.Crewmate;
using TownOfUs.Roles.Neutral;
using TownOfUs.Utilities;
using UnityEngine;

namespace TownOfExtra.Roles.Neutral.Evil;

public sealed class VultureRole(IntPtr cppPtr) : NeutralRole(cppPtr), ITownOfUsRole, IWikiDiscoverable, IDoomable, ICrewVariant
{
    public string RoleName => "Vulture";
    public string RoleDescription => "Eat the bodies of dead crewmates!";
    public string RoleLongDescription => RoleDescription;
    public Color RoleColor => TownOfExtraColours.VultureRoleColour;
    public ModdedRoleTeams Team => ModdedRoleTeams.Custom;
    public RoleAlignment RoleAlignment => RoleAlignment.NeutralKilling;
    public DoomableType DoomHintType => (DoomableType)ToExDoomHints.ToExRelentless;
    public RoleBehaviour CrewVariant =>
        RoleManager.Instance.GetRole((RoleTypes)RoleId.Get<AltruistRole>());

    public static int DeadBodiesEaten;

    public override void SpawnTaskHeader(PlayerControl playerControl)
    {
        if (playerControl != PlayerControl.LocalPlayer)
        {
            return;
        }
        ImportantTextTask orCreateTask = PlayerTask.GetOrCreateTask<ImportantTextTask>(playerControl);
        orCreateTask.Text = $"{TownOfExtraColours.VultureRoleColour.ToTextColor()}Eat {OptionGroupSingleton<VultureRoleOptions>.Instance.EatenBodiesNeeded} dead bod{((int)OptionGroupSingleton<VultureRoleOptions>.Instance.EatenBodiesMax != 1 ? "ies" : "y")} till all buffs have been received!</color>\n{TownOfExtraColours.VultureRoleColour.ToTextColor()}Fake Tasks:</color>";
        orCreateTask.name = "NeutralRoleText";
    }

    [HideFromIl2Cpp]
    public StringBuilder SetTabText()
    {
        var stringB = ITownOfUsRole.SetNewTabText(this);

        stringB.Append(TownOfUsPlugin.Culture, $"\n<b>Bodies Eaten: {DeadBodiesEaten}/{OptionGroupSingleton<VultureRoleOptions>.Instance.EatenBodiesMax}</color>");

        return stringB;
    }

    public string GetAdvancedDescription()
    {
        return
            "The Vulture is a Neutral killing role that gets a buff for every body they digest." +
            MiscUtils.AppendOptionsText(GetType());
    }

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        IconTmp = MiraAPI.Utilities.Assets.TmpSpriteUtils.CreateSpriteAsset(TownOfExtraAssets.VultureRoleIcon.LoadAsset(), "ToEx.Role.Neutral.Vulture", 1.45f),
        MaxRoleCount = 1,
        Icon = TownOfExtraAssets.VultureRoleIcon,
        GhostRole = (RoleTypes)RoleId.Get<NeutralGhostRole>()
    };

    [HideFromIl2Cpp]
    public List<CustomButtonWikiDescription> Abilities
    {
        get
        {
            return new List<CustomButtonWikiDescription>
            {
                new("Eat", "Eat a dead body.", TownOfExtraAssets.VultureEatButton)
            };
        }
    }

    public bool WinConditionMet()
    {
        var vultCount = CustomRoleUtils.GetActiveRolesOfType<VultureRole>().Count(x => !x.Player.HasDied());

        if (MiscUtils.KillersAliveCount > vultCount)
        {
            return false;
        }

        return vultCount >= Helpers.GetAlivePlayers().Count - murdererCount;
    }

    public override bool DidWin(GameOverReason gameOverReason)
    {
        return WinConditionMet();
    }

    public override bool CanUse(IUsable usable)
    {
        if (!GameManager.Instance.LogicUsables.CanUse(usable, Player))
        {
            return false;
        }

        var console = usable.TryCast<Console>()!;
        return console == null || console.AllowImpostor;
    }
}