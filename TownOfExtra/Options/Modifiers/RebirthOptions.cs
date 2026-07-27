using System;
using MiraAPI.GameOptions;
using TownOfExtra.Modifiers.Game.Impostor.Utility;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options.Modifiers;

public sealed class RebirthOptions : AbstractTouModifierOptionGroup<RebirthModifier>
{
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override string GroupName => "Rebirth";
    public override Color GroupColor => Palette.ImpostorRed;
    public override uint GroupPriority => 11;
}
