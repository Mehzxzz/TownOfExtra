using System;
using MiraAPI.GameOptions;
using TownOfExtra.Modifiers.Game.Non_Crew.Passive;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class ScourgeOptions : AbstractTouModifierOptionGroup<ScourgeModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Scourge";
    public override Color GroupColor => TownOfExtraColours.ScourgeModifierColour;
    public override uint GroupPriority => 9;
}
