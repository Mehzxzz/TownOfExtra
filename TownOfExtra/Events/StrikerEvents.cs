using System.Collections.Generic;
using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.GameOptions;
using TownOfExtra.Options.Roles;
using TownOfExtra.Roles.Impostor.Killing;

namespace TownOfExtra.Events;

public class StrikerEvents
{
    [RegisterEvent]
    public static void OnGameStart(IntroEndEvent e)
    {
        if (PlayerControl.LocalPlayer.Data.Role is not StrikerRole) return;
        StrikerRole.UsesLeft = (int)OptionGroupSingleton<StrikerRoleOptions>.Instance.LocateUses;
        StrikerRole.UsesThisRound = 0;
    }
}