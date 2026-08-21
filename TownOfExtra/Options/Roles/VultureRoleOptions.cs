using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using TownOfExtra.Roles.Neutral.Evil;

namespace TownOfExtra.Options.Roles;

public sealed class VultureRoleOptions : AbstractRoleOptionGroup<VultureRole>
{
    public override string GroupName => "Vulture";

    [ModdedNumberOption("Eat Cooldown", 0f, 240f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float EatCooldown { get; set; } = 30f;
 [ModdedNumberOption("Eat Cooldown", 2.5f, 12.5f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float KillCooldownReduction { get; set; } = 5f;
}