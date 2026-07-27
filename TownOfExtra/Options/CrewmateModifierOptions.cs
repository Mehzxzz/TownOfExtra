using System;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfUs.Options;
using UnityEngine;

namespace TownOfExtra.Options;

public sealed class CrewmateModifierOptions : AbstractOptionGroup
{
    public override string GroupName => "Crewmate Modifiers";
    public override Func<bool> GroupVisible => () => OptionGroupSingleton<RoleOptions>.Instance.IsClassicRoleAssignment;
    public override Color GroupColor => Palette.CrewmateRoleHeaderBlue;
    public override MenuCategory ParentMenu => MenuCategory.Modifiers;
    public override uint GroupPriority => 1;

    /*----------------------
             ROUTINE
    ----------------------*/

    [ModdedNumberOption("Routine Amount", 0, 5)]
    public float RoutineAmount { get; set; } = 0;

    public ModdedNumberOption RoutineChance { get; } =
        new("Routine Chance", 50f, 0f, 100f, 10f, MiraNumberSuffixes.Percent)
        {
            Visible = () => OptionGroupSingleton<CrewmateModifierOptions>.Instance.RoutineAmount > 0
        };
    
    /*----------------------
           OBSERVANT
   ----------------------*/

    [ModdedNumberOption("Observant Amount", 0, 5)]
    public float ObservantAmount { get; set; } = 0;

    public ModdedNumberOption ObservantChance { get; } =
        new("Observant Chance", 50f, 0f, 100f, 10f, MiraNumberSuffixes.Percent)
        {
            Visible = () => OptionGroupSingleton<CrewmateModifierOptions>.Instance.ObservantAmount > 0
        };
    
    /*----------------------
            CLUMSY
   ----------------------*/

    [ModdedNumberOption("Clumsy Amount", 0, 5)]
    public float ClumsyAmount { get; set; } = 0;

    public ModdedNumberOption ClumsyChance { get; } =
        new("Clumsy Chance", 50f, 0f, 100f, 10f, MiraNumberSuffixes.Percent)
        {
            Visible = () => OptionGroupSingleton<CrewmateModifierOptions>.Instance.ClumsyAmount > 0
        };
    
    /*----------------------
          PANIC SHIELD
    ----------------------*/

    [ModdedNumberOption("Panic Shield Amount", 0, 5)]
    public float PanicShieldAmount { get; set; } = 0;

    public ModdedNumberOption PanicShieldChance { get; } =
        new("Panic Shield Chance", 50f, 0f, 100f, 10f, MiraNumberSuffixes.Percent)
        {
            Visible = () => OptionGroupSingleton<CrewmateModifierOptions>.Instance.PanicShieldAmount > 0
        };
}