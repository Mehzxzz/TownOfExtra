using System;
using MiraAPI.GameOptions;
using TownOfExtra.Modifiers.Game.Universal.Passive;
using TownOfUs;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class SoullessOptions : AbstractTouModifierOptionGroup<SoullessModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Soulless";
    public override Color GroupColor => TownOfUsColors.SoulCollector;
    public override uint GroupPriority => 12;
}
