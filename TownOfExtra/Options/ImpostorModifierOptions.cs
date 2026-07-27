using System;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfUs;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options;

public sealed class ImpostorModifierOptions : AbstractOptionGroup
{
    public override string GroupName => "Impostor Modifiers";
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override Color GroupColor => TownOfUsColors.Impostor;
    public override MenuCategory ParentMenu => MenuCategory.Modifiers;
    public override uint GroupPriority => 3;

    /*----------------------
            SHOCKWAVE
    ----------------------*/

    [ModdedNumberOption("Shockwave Amount", 0, 5)]
    public float ShockwaveAmount { get; set; } = 0;

    public ModdedNumberOption ShockwaveChance { get; } =
        new("Shockwave Chance", 50f, 0f, 100f, 10f, MiraNumberSuffixes.Percent)
        {
            Visible = () => OptionGroupSingleton<ImpostorModifierOptions>.Instance.ShockwaveAmount > 0
        };
    
    /*----------------------
            REBIRTH
    ----------------------*/

    [ModdedNumberOption("Rebirth Amount", 0, 5)]
    public float RebirthAmount { get; set; } = 0;

    public ModdedNumberOption RebirthChance { get; } =
        new("Rebirth Chance", 50f, 0f, 100f, 10f, MiraNumberSuffixes.Percent)
        {
            Visible = () => OptionGroupSingleton<ImpostorModifierOptions>.Instance.RebirthAmount > 0
        };
}