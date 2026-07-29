using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using TownOfExtra.Roles.Neutral.Evil;

namespace TownOfExtra.Options.Roles;

public sealed class PoltergeistRoleOptions : AbstractRoleOptionGroup<PoltergeistRole>
{
    public override string GroupName => "Poltergeist";
    
    [ModdedNumberOption("Scare Cooldown", 0f, 120f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float ScareCooldown { get; set; } = 25f;
    
    [ModdedNumberOption("Possess Cooldown", 0f, 120f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float PossessCooldown { get; set; } = 30f;
    
    [ModdedNumberOption("# of Possesses to win", 1f, 15f)]
    public float WinPossesses { get; set; } = 5f;
    
    [ModdedNumberOption("Scared Vision Multiplier (1=off)", 0f, 1f, 0.05f, MiraNumberSuffixes.Multiplier, "0.00")]
    public float ScaredVisDebuffMulti { get; set; } = 0.80f;

    [ModdedNumberOption("Possessed Vision Multiplier (1=off)", 0f, 1f, 0.05f, MiraNumberSuffixes.Multiplier, "0.00")]
    public float PossessedVisDebuffMulti { get; set; } = 0.65f;
    
    [ModdedEnumOption("When Victorious", typeof(PoltergeistWinType), ["Win Alone", "Kill possessed players (victorious)", "Leave In Victory"])]
    public PoltergeistWinType WinType { get; set; } = PoltergeistWinType.WinAlone;
}

public enum PoltergeistWinType
{
    WinAlone,
    KillPossessed,
    LeaveInVictory,
}