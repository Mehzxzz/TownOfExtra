using System;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfExtra.Modifiers.Game.Impostor.Utility;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class ShockwaveOptions : AbstractTouModifierOptionGroup<ShockwaveModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Shockwave";
    public override Color GroupColor => TownOfExtraColours.ShockwaveModifierColour;
    public override uint GroupPriority => 10;

    public ModdedNumberOption Radius { get; } =
        new("Shockwave Radius", 1f, 0.25f, 5f, 0.25f, MiraNumberSuffixes.Multiplier, "0.00");

    public ModdedNumberOption Cooldown { get; } =
        new("Shockwave Cooldown", 25f, 2.5f, 120f, 2.5f, MiraNumberSuffixes.Seconds);

    public ModdedNumberOption Uses { get; } =
        new("Shockwave Uses", 1f, 1f, 5f, 1f, MiraNumberSuffixes.None);

    public ModdedNumberOption EffectDuration { get; } =
        new("Shockwave effect durations", 10f, 5f, 15f, 1f, MiraNumberSuffixes.Seconds);

    public ModdedNumberOption VisionDebuffMultiplier { get; } =
        new("Shockwave Vision Multiplier", 0.05f, 0f, 0.25f, 0.05f, MiraNumberSuffixes.Multiplier, "0.00");

    public ModdedNumberOption SpeedDebuffMultiplier { get; } =
        new("Shockwave Speed Multiplier (1=off)", 0.35f, 0f, 1f, 0.05f, MiraNumberSuffixes.Multiplier, "0.00");
}
