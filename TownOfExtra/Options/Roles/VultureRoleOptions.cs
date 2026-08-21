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
    [ModdedNumberOption("Digest Cooldown", 0f, 240f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float DigestCooldown { get; set; } = 35f;
   [ModdedNumberOption("Kill Cooldown reduction", 2.5f, 12.5f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float KillCooldownReduction { get; set; } = 5f;

    [ModdedEnumOption("Kill is", typeof(Obtainment),
        ["Amount", "Off"])]
    public Obtainment Obtainment { get; set; } = Obtainment.Amount;


public enum Obtainment
{
    Amount,
    Off,
}

[ModdedNumberOption("Bodies to unlock Digest", 1f, 4f, 1f, MiraNumberSuffixes.None)]
    public float BodiesTillDigest{ get; set; } = 1f;
{
            Visible = () => OptionGroupSingleton<VultureRoleOptions>.Instance.Obtainment is not Obtainment.Off
}
}