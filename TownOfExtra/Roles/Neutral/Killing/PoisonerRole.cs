using System;
using System.Collections.Generic;
using System.Linq;
using AmongUs.GameOptions;
using Il2CppInterop.Runtime.Attributes;
using MiraAPI.GameOptions;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using TownOfExtra.Modules;
using TownOfExtra.Options.Roles;
using TownOfUs.Extensions;
using TownOfUs.Modules.Wiki;
using TownOfUs.Roles;
using TownOfUs.Roles.Crewmate;
using TownOfUs.Roles.Neutral;
using TownOfUs.Utilities;
using UnityEngine;

namespace TownOfExtra.Roles.Neutral.Killing;

public sealed class PoisonerRole(IntPtr cppPtr) : NeutralRole(cppPtr), ITownOfUsRole, IWikiDiscoverable, IDoomable, ICrewVariant
{
    public string RoleName => "Poisoner";
    public string RoleDescription => "Infect the ship with a deadly poison!";
    public string RoleLongDescription => RoleDescription;
    public Color RoleColor => TownOfExtraColours.PoisonerRoleColour;
    public ModdedRoleTeams Team => ModdedRoleTeams.Custom;
    public RoleAlignment RoleAlignment => RoleAlignment.NeutralKilling;
    public DoomableType DoomHintType => (DoomableType)ToExDoomHints.ToExRelentless;
    public RoleBehaviour CrewVariant =>
        RoleManager.Instance.GetRole((RoleTypes)RoleId.Get<ClericRole>());

    public override void SpawnTaskHeader(PlayerControl playerControl)
    {
        if (playerControl != PlayerControl.LocalPlayer)
        {
            return;
        }
        ImportantTextTask orCreateTask = PlayerTask.GetOrCreateTask<ImportantTextTask>(playerControl);
        orCreateTask.Text = $"{TownOfExtraColours.PoisonerRoleColour.ToTextColor()}Be the last killer alive, at all costs.</color>\n{TownOfExtraColours.PoisonerRoleColour.ToTextColor()}Fake Tasks:</color>";
        orCreateTask.name = "NeutralRoleText";
    }
    
    public string GetAdvancedDescription()
    {
        return
            "The Poisoner is a Neutral Killing role that can poison players, making their screen become green, and making them die in a few seconds." +
            MiscUtils.AppendOptionsText(GetType());
    }
    
    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        IconTmp = MiraAPI.Utilities.Assets.TmpSpriteUtils.CreateSpriteAsset(TownOfExtraAssets.PoisonerRoleIcon.LoadAsset(), "ToEx.Role.Neutral.Poisoner", 1.45f),
        Icon = TownOfExtraAssets.PoisonerRoleIcon,
        CanUseVent = OptionGroupSingleton<PoisonerRoleOptions>.Instance.CanVent,
        GhostRole = (RoleTypes)RoleId.Get<NeutralGhostRole>()
    };
    
    [HideFromIl2Cpp]
    public List<CustomButtonWikiDescription> Abilities
    {
        get
        {
            return new List<CustomButtonWikiDescription>
            {
                new("Poison", "Poison a player causing them to die later in the game.", TownOfExtraAssets.PoisonerPoisonButton)
            };
        }
    }
    
    public bool WinConditionMet()
    {
        var poisonerAmount = CustomRoleUtils.GetActiveRolesOfType<PoisonerRole>().Count(x => !x.Player.HasDied());

        if (MiscUtils.KillersAliveCount > poisonerAmount)
        {
            return false;
        }

        return poisonerAmount >= Helpers.GetAlivePlayers().Count - poisonerAmount;
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