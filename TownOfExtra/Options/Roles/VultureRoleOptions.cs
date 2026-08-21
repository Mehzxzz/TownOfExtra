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

    [ModdedEnumOption("Can Kill", typeof(DigestObtainment),
        ["Bodies", "Off"])]
    public DigestObtainment DigestObtainment { get; set; } = DigestObtainment.Bodies;


public enum DigestObtainment
{
    Bodies,
    Off,
}

[ModdedNumberOption("Bodies to unlock Digest", 0f, 4f, 1f, MiraNumberSuffixes.None)]
    public float BodiesTillDigest{ get; set; } = 1f;
{
            Visible = () => OptionGroupSingleton<VultureRoleOptions>.Instance.DigestObtainment is not DigestObtainment.Off
}

[ModdedEnumOption("Can Vent", typeof(VentObtainment),
        ["Bodies", "Off"])]
    public VentObtainment VentObtainment { get; set; } = VentObtainment.Bodies;


public enum VentObtainment
{
    Bodies,
    Off,
}

[ModdedNumberOption("Bodies to unlock Vent", 0f, 4f, 1f, MiraNumberSuffixes.None)]
    public float BodiesTillVent{ get; set; } = 2f;
{
            Visible = () => OptionGroupSingleton<VultureRoleOptions>.Instance.VentObtainment is not VentObtainment.Off
}

    [ModdedNumberOption("TouOptionEngineerVentCooldown", 0f, 25f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float VentCooldown { get; set; } = 15f;
  {
            Visible = () => OptionGroupSingleton<VultureRoleOptions>.Instance.VentObtainment is not VentObtainment.Off
}
 [ModdedNumberOption("TouOptionEngineerVentDuration", 0f, 25f, 5f, MiraNumberSuffixes.Seconds, zeroInfinity: true)]
    public float VentDuration { get; set; } = 10f;
{
            Visible = () => OptionGroupSingleton<VultureRoleOptions>.Instance.VentObtainment is not VentObtainment.Off
}
}
