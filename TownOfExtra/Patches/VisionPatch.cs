using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using TownOfExtra.Modifiers.Excluded;
using TownOfExtra.Options.Modifiers;

namespace TownOfExtra.Patches;

using HarmonyLib;

[HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.CalculateLightRadius))]
public static class VisionPatch
{
    [HarmonyPriority(Priority.Low)] 
    public static void Postfix(ShipStatus __instance, NetworkedPlayerInfo player, ref float __result)
    {
        if (player == null || player.IsDead) return;

        var p = player.Object;
        var result = __result;
        
        if (p.HasModifier<ShockwavedModifier>()) result *= OptionGroupSingleton<ShockwaveOptions>.Instance.VisionDebuffMultiplier.Value;

        __result = result;
    }
}