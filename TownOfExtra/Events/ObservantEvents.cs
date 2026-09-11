using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.Modifiers;
using TownOfExtra.Modifiers.Game.Crewmate.Passive;
using TownOfExtra.Networking.Global;
using TownOfUs;
using TownOfUs.Modules;
using TownOfUs.Roles.Crewmate;
using TownOfUs.Utilities;

namespace TownOfExtra.Events;

public class ObservantEvents
{
    [RegisterEvent]
    public static void OnMeetingDeath(AfterMurderEvent e)
    {
        if (!MeetingHud.Instance) return;
        if (!PlayerControl.LocalPlayer.HasModifier<ObservantModifier>()) return;
        if (!GameHistory.PlayerStats.TryGetValue(e.Target.PlayerId, out _)) return;

        var isMisguess = e.Source.PlayerId == e.Target.PlayerId;
        var cod = isMisguess ? "Misguessed" : "Guessed";

        var title = $"{TownOfExtraColours.ObservantModifierColour.ToTextColor()}Observations</color>";
        var startTxt = isMisguess
            ? $"{e.Target.Data.PlayerName} has"
            : $"{e.Target.Data.PlayerName} has been";
        
        var endTxt =
            e.Source.Data.Role is VigilanteRole
                ? $"{TownOfUsColors.Vigilante.ToTextColor()}<b>{cod}</b></color>"
                : $"<b>{cod}</b>";
        var msg = $"{startTxt} {endTxt}!";

        MiscUtils.AddFakeChat(PlayerControl.LocalPlayer.Data, title, msg, false, true);
        PlayerControl.LocalPlayer.RpcSendNotification(
            msg,
            "ObservantModifierIcon",
            "CrewModIcon",
            200
        );

        if (!HudManager.Instance.Chat.IsOpenOrOpening) HudManager.Instance.Chat.Toggle();
    }
}