using System.Collections;
using System.Linq;
using MiraAPI.Events;
using MiraAPI.GameEnd;
using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using Reactor.Utilities;
using TownOfExtra.Events.Custom;
using TownOfExtra.Modifiers.Excluded;
using TownOfExtra.Networking.Global;
using TownOfExtra.Options.Roles;
using TownOfExtra.Roles.Neutral.Evil;
using TownOfUs.Events;
using TownOfUs.GameOver;
using TownOfUs.Modifiers;
using TownOfUs.Modules.Localization;
using TownOfUs.Networking;
using TownOfUs.Utilities;
using UnityEngine;

namespace TownOfExtra.Events;

public class PoltergeistEvents
{
    [RegisterEvent]
    public static void OnPoltergeistPossess(TownOfExtraAbilityEvent e)
    {
        if (e.AbilityType != AbilityType.PoltergeistPossessPlayer) return;

        Coroutines.Start(CheckPoltergeistPossess());
    }
    
    private static IEnumerator CheckPoltergeistPossess()
    {
        yield return new WaitForSeconds(0.5f);

        int possessedCount = 0;

        foreach (var p in PlayerControl.AllPlayerControls)
        {
            if (p.HasModifier<PossessedModifier>()) possessedCount++;
        }

        if (possessedCount >= OptionGroupSingleton<PoltergeistRoleOptions>.Instance.WinPossesses)
        {
            if (AmongUsClient.Instance.AmHost)
            {
                var winners = CustomRoleUtils.GetActiveRolesOfType<PoltergeistRole>()
                    .Where(t => t.WinConditionMet()).ToList();

                if (winners.Count > 0)
                {
                    CustomGameOver.Trigger<NeutralGameOver>(winners.Select(p => p.Player.Data).ToList());
                }
                else
                {
                    var poltergeist = CustomRoleUtils.GetActiveRolesOfType<PoltergeistRole>()
                        .FirstOrDefault(v =>
                            !v.Player.HasDied() &&
                            (OptionGroupSingleton<PoltergeistRoleOptions>.Instance.WinType is PoltergeistWinType.LeaveInVictory ||
                             OptionGroupSingleton<PoltergeistRoleOptions>.Instance.WinType is PoltergeistWinType.KillPossessed));

                    if (poltergeist == null) yield break;

                    foreach (var p in PlayerControl.AllPlayerControls)
                    {
                        if (poltergeist.Player == p)
                        {
                            p.RpcSendNotification(
                                $"You have successfully won as the {TownOfExtraColours.PoltergeistRoleColour.ToTextColor()}Poltergeist</color>, as you have possessed enough players!",
                                "PoltergeistPossessButton",
                                "NeutButton"
                            );
                        }
                        else
                        {
                            p.RpcSendNotification(
                                $"The {TownOfExtraColours.PoltergeistRoleColour.ToTextColor()}Poltergeist</color>, {poltergeist.Player.Data.PlayerName}, has won, as they have possessed enough players!",
                                "PoltergeistPossessButton",
                                "NeutButton"
                            );
                        }
                    }

                    DeathHandlerModifier.UpdateDeathHandlerImmediate(poltergeist.Player, TouLocale.Get("DiedToWinning"),
                        DeathEventHandlers.CurrentRound, DeathHandlerOverride.SetFalse,
                        lockInfo: DeathHandlerOverride.SetTrue);
                
                    poltergeist.Player.Exiled();

                    if (OptionGroupSingleton<PoltergeistRoleOptions>.Instance.WinType is PoltergeistWinType.KillPossessed)
                    {
                        foreach (var p in PlayerControl.AllPlayerControls)
                        {
                            if (!p.HasModifier<PossessedModifier>()) continue;
                            
                            poltergeist.Player.RpcSpecialMurder(p,
                                true,
                                true,
                                resetKillTimer: false,
                                teleportMurderer: false,
                                playKillSound: false,
                                causeOfDeath: "Possessed");
                        }
                    }
                }
            }
        }
    }
}