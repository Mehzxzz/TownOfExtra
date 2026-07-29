using System.Linq;
using MiraAPI.GameEnd;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Roles;
using Reactor.Networking.Attributes;
using Reactor.Utilities;
using TownOfExtra.Buttons;
using TownOfExtra.Networking.Global;
using TownOfExtra.Options.Roles;
using TownOfExtra.Roles.Neutral.Evil;
using TownOfUs.Events;
using TownOfUs.GameOver;
using TownOfUs.Modifiers;
using TownOfUs.Modules.Localization;
using TownOfUs.Utilities;
using UnityEngine;

namespace TownOfExtra.Networking;

public class TricksterRpcs
{
    [MethodRpc((uint)TownOfExtraRpcs.TricksterNotifyOfReport)]
    public static void RpcNotifyTrickster(PlayerControl sender)
    {
        PlayerControl p = PlayerControl.LocalPlayer;
        if (p == null) return;

        TricksterRole.FakeBodiesReported++;
        TricksterPlaceButton.BodyPlaced = false;

        if (PlayerControl.LocalPlayer.GetTownOfUsRole() is TricksterRole)
        {
            Coroutines.Start(MiscUtils.CoFlash(TownOfExtraColours.TricksterRoleColour));

            string ttc = TownOfExtraColours.TricksterRoleColour.ToTextColor();
            int reports = TricksterRole.FakeBodiesReported;
            int reportsNeeded = (int)OptionGroupSingleton<TricksterRoleOptions>.Instance.ReportsNeeded;

            p.RpcSendNotification($"One of your {ttc}fake bodies</color> has been found! {ttc}{reports}/{reportsNeeded}</color>",
                "TricksterRoleIcon",
                "NeutRoleIcon",
                200,
                TownOfExtraColours.TricksterRoleColour
            );
            
            CustomButtonSingleton<TricksterPlaceButton>.Instance.Timer = OptionGroupSingleton<TricksterRoleOptions>.Instance.PlaceCooldown;
            
        }
        
        if (AmongUsClient.Instance.AmHost)
        {
            var winners = CustomRoleUtils.GetActiveRolesOfType<TricksterRole>()
                .Where(t => t.WinConditionMet()).ToList();

            if (winners.Count > 0)
            {
                CustomGameOver.Trigger<NeutralGameOver>(winners.Select(v => v.Player.Data).ToList());
            }
            else
            {
                var trickster = CustomRoleUtils.GetActiveRolesOfType<TricksterRole>()
                    .FirstOrDefault(v =>
                        !v.Player.HasDied() && 
                        TricksterRole.FakeBodiesReported >= OptionGroupSingleton<TricksterRoleOptions>.Instance.ReportsNeeded && 
                        OptionGroupSingleton<TricksterRoleOptions>.Instance.WinType is TricksterWinType.LeaveInVictory);
                
                if (trickster == null) return;
                
                foreach (var plr in PlayerControl.AllPlayerControls)
                {
                    if (trickster.Player == plr)
                    {
                        plr.RpcSendNotification(
                            $"You have successfully won as the {TownOfExtraColours.TricksterRoleColour.ToTextColor()}Trickster</color>, as you have tricked enough players!",
                            "TricksterRoleIcon",
                            "NeutRoleIcon",
                            200
                        );
                    }
                    else
                    {
                        plr.RpcSendNotification(
                            $"The {TownOfExtraColours.TricksterRoleColour.ToTextColor()}Trickster</color>, {trickster.Player.Data.PlayerName}, has won, as they have tricked enough players!",
                            "TricksterRoleIcon",
                            "NeutRoleIcon",
                            200
                        );
                    }
                }

                DeathHandlerModifier.UpdateDeathHandlerImmediate(trickster.Player, TouLocale.Get("DiedToWinning"),
                    DeathEventHandlers.CurrentRound, DeathHandlerOverride.SetFalse,
                    lockInfo: DeathHandlerOverride.SetTrue);
                
                trickster.Player.Exiled();
            }
        }
    }

    [MethodRpc((uint)TownOfExtraRpcs.TricksterPlaceFakeBody)]
    public static void RpcPlaceFakeBody(PlayerControl sender, byte colorId, byte parentId)
    {
        var body = TricksterPlaceButton.CreateDeadBody(sender.transform.position, colorId, parentId, sender);
        if (body != null)
        {
            TricksterRole.SpawnedBodies.Add(body);
        }
    }
    
    [MethodRpc((uint)TownOfExtraRpcs.TricksterDestroyFakeBodies)]
    public static void RpcDestroyFakeBodies(PlayerControl sender)
    {
        foreach (var body in TricksterRole.SpawnedBodies)
        {
            TricksterRole.SpawnedBodies.Remove(body);
            Object.Destroy(body.gameObject);
        }
    }
}