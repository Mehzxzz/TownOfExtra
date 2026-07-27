using System;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfExtra.Modifiers.Game.Universal.Passive;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class YouthlingOptions : AbstractTouModifierOptionGroup<YouthlingModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Youthling";
    public override Color GroupColor => TownOfExtraColours.YouthlingModifierColour;
    public override uint GroupPriority => 15;

    public ModdedNumberOption TimeBetweenAge { get; } =
        new("Time between age", 15f, 2.5f, 30f, 2.5f, MiraNumberSuffixes.Seconds);
}
