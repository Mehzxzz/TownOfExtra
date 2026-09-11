using System;
using TownOfExtra.Modifiers.Game.Crewmate.Passive;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class ObservantOptions : AbstractTouModifierOptionGroup<ObservantModifier>
{
    public override Func<bool> GroupVisible => () => RoleOptions.IsClassicRoleAssignment;
    public override string GroupName => "Observant";
    public override Color GroupColor => TownOfExtraColours.ObservantModifierColour;
    public override uint GroupPriority => 6;
}
