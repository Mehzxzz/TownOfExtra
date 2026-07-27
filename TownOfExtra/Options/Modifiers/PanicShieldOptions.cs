using System;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfExtra.Modifiers.Game.Crewmate.Utility;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class PanicShieldOptions : AbstractTouModifierOptionGroup<PanicShieldModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Panic Shield";
    public override Color GroupColor => TownOfExtraColours.PanicShieldModifierColour;
    public override uint GroupPriority => 8;

    public ModdedNumberOption Duration { get; } =
        new("Panic Shield Duration", 30f, 7.5f, 60f, 2.5f, MiraNumberSuffixes.Seconds);
}
