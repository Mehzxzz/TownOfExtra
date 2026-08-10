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
                $"You have {TownOfExtraColours.VultureRoleColour.ToTextColor()}eaten</color> a body and are now at {TownOfUsColors.Neutral.ToTextColor()}{VultureRole.DeadBodiesEaten}/{OptionGroupSingleton<VultureRoleOptions>.Instance.EatenBodiesNeeded}</color> bodies digested!",
                Color.white, new Vector3(0f, 1f, -20f), spr: TownOfExtraAssets.VultureEatButton.LoadAsset());
            notif.AdjustNotification();
        }