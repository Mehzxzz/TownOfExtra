using System.Linq;
using TownOfExtra.Roles.Neutral.Evil;
using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.GameEnd;
using MiraAPI.GameOptions;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using TownOfExtra.Events.Custom;
using TownOfExtra.Networking;
using TownOfExtra.Networking.Global;
using TownOfExtra.Options.Roles;
using TownOfUs;
using TownOfUs.Events;
using TownOfUs.GameOver;
using TownOfUs.Modifiers;
using TownOfUs.Modules.Localization;
using TownOfUs.Utilities;
using Color = UnityEngine.Color;
using Vector3 = UnityEngine.Vector3;

namespace TownOfExtra.Events;

public class VultureEvents
{
    [RegisterEvent]
    public static void StartGameEventHandler(IntroBeginEvent e)
    {
        VultureRole.DeadBodiesEaten = 0;
    }

    [RegisterEvent]
    public static void AfterMurderEventHandler(AfterMurderEvent e)
    {
        CheckAndConvertVulture();
    }

    [RegisterEvent]
    public static void RoundStartEventHandler(RoundStartEvent e)
    {
        CheckAndConvertVulture();
    }
    
    [RegisterEvent]
    public static void OnBodyCleanEventHandler(TownOfExtraAbilityEvent e)
    {
        if (e.AbilityType != AbilityType.VultureEatBody) return;
        if (e.Player.GetTownOfUsRole() is not VultureRole) return;

        VultureRole.DeadBodiesEaten++;

        if (PlayerControl.LocalPlayer == e.Player)
        {
            var notif = Helpers.CreateAndShowNotification(
                $"You have {TownOfExtraColours.VultureRoleColour.ToTextColor()}eaten</color> a body and are now at {TownOfUsColors.Neutral.ToTextColor()}{VultureRole.DeadBodiesEaten}/{OptionGroupSingleton<VultureRoleOptions>.Instance.EatenBodiesNeeded}</color> bodies!",
                Color.white, new Vector3(0f, 1f, -20f), spr: TownOfExtraAssets.VultureEatButton.LoadAsset());
            notif.AdjustNotification();
        }

        if (AmongUsClient.Instance.AmHost)
        {
            var winners = CustomRoleUtils.GetActiveRolesOfType<VultureRole>()
                .Where(t => t.WinConditionMet()).ToList();

            if (winners.Count > 0)
            {
                CustomGameOver.Trigger<NeutralGameOver>(winners.Select(v => v.Player.Data).ToList());
            }
            else
            {
                var vulture = CustomRoleUtils.GetActiveRolesOfType<VultureRole>()
                    .FirstOrDefault(v =>
                        !v.Player.HasDied() && 
                        VultureRole.DeadBodiesEaten >= OptionGroupSingleton<VultureRoleOptions>.Instance.EatenBodiesNeeded && 
                        OptionGroupSingleton<VultureRoleOptions>.Instance.WinType is VultureWinType.LeaveInVictory);
                
                if (vulture == null) return;
                
                foreach (var plr in PlayerControl.AllPlayerControls)
                {
                    if (vulture.Player == plr)
                    {
                        plr.RpcSendNotification(
                            $"You have successfully won as the {TownOfExtraColours.VultureRoleColour.ToTextColor()}Vulture</color>, as you have eaten enough bodies!",
                            "VultureEatButton",
                            "NeutButton"
                        );
                    }
                    else
                    {
                        plr.RpcSendNotification(
                            $"The {TownOfExtraColours.VultureRoleColour.ToTextColor()}Vulture</color>, {vulture.Player.Data.PlayerName}, has won, as they have eaten enough bodies!",
                            "VultureEatButton",
                            "NeutButton"
                        );
                    }
                }

                DeathHandlerModifier.UpdateDeathHandlerImmediate(vulture.Player, TouLocale.Get("DiedToWinning"),
                    DeathEventHandlers.CurrentRound, DeathHandlerOverride.SetFalse,
                    lockInfo: DeathHandlerOverride.SetTrue);
                
                vulture.Player.Exiled();
            }
        }
    }

    private static void CheckAndConvertVulture()
    {
        if (!OptionGroupSingleton<VultureRoleOptions>.Instance.TurnIntoAmne) return;
        
        int impostors = 0;
        int others = 0;

        foreach (var p in PlayerControl.AllPlayerControls)
        {
            if (p.Data.IsDead || p.GetTownOfUsRole() is VultureRole) continue;
            if (p.IsImpostor()) impostors++;
            else others++;
        }

        foreach (var p in PlayerControl.AllPlayerControls)
        {
            VultureRpcs.RpcChangeVultureToAmne(p, others, impostors);
        }
    }
}