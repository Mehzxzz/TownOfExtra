using System;
using MiraAPI.GameOptions;
using TownOfExtra.Modifiers.Game.Universal.Passive;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class MuteOptions : AbstractTouModifierOptionGroup<MuteModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Mute";
    public override Color GroupColor => TownOfExtraColours.MuteModifierColour;
    public override uint GroupPriority => 14;
}
