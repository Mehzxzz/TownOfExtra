using System;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfExtra.Modifiers.Game.Crewmate.Passive;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class RoutineOptions : AbstractTouModifierOptionGroup<RoutineModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Routine";
    public override Color GroupColor => Palette.CrewmateBlue;
    public override uint GroupPriority => 5;

    public ModdedNumberOption SpeedBoost { get; } =
        new("Speed Boost", 1.5f, 1.25f, 2f, 0.25f, MiraNumberSuffixes.Multiplier);

    public ModdedNumberOption SpeedBoostDuration { get; } =
        new("Speed Boost Duration", 5f, 5f, 20f, 2.5f, MiraNumberSuffixes.Seconds);
}
