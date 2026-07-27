using System;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfExtra.Modifiers.Game.Universal.Passive;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class ApoliticalOptions : AbstractTouModifierOptionGroup<ApoliticalModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Apolitical";
    public override Color GroupColor => TownOfExtraColours.ApoliticalModifierColour;
    public override uint GroupPriority => 13;

    public ModdedNumberOption CdIncrease { get; } =
        new("Cooldown increase per vote", 3f, 1f, 10f, 1f, MiraNumberSuffixes.None);
}
