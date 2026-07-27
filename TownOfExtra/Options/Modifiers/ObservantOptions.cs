using System;
using MiraAPI.GameOptions;
using TownOfExtra.Modifiers.Game.Crewmate.Passive;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class ObservantOptions : AbstractTouModifierOptionGroup<ObservantModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Observant";
    public override Color GroupColor => TownOfExtraColours.ObservantModifierColour;
    public override uint GroupPriority => 6;
}
