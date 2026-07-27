using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using TownOfExtra.Roles.Neutral.Killing;

namespace TownOfExtra.Options.Roles;

public sealed class MurdererRoleOptions : AbstractRoleOptionGroup<MurdererRole>
{
    public override string GroupName => "Murderer";

    [ModdedNumberOption("Murder Cooldown", 2.5f, 240f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float MurderCooldown { get; set; } = 20f;

    [ModdedToggleOption("Can Vent")]
    public bool CanVent  { get; set; } = true;
}