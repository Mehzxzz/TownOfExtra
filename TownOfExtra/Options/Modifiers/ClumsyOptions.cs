using System;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfExtra.Modifiers.Game.Crewmate.Passive;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class ClumsyOptions : AbstractTouModifierOptionGroup<ClumsyModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Clumsy";
    public override Color GroupColor => TownOfExtraColours.ClumsyModifierColour;
    public override uint GroupPriority => 7;

    public ModdedNumberOption SabotageChance { get; } =
        new("Sabotage Chance", 70f, 10f, 100f, 10f, MiraNumberSuffixes.Percent);
}
