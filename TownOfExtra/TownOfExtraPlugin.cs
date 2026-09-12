using System.Reflection;
//todo: using AchievementsAPI;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI;
using MiraAPI.PluginLoading;
using MiraAPI.Translation;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using Reactor.Utilities;
using TownOfExtra.Patches;

namespace TownOfExtra;

[BepInPlugin(TownOfExtraPluginInfo.Id, TownOfExtraPluginInfo.Name, TownOfExtraPluginInfo.Version)]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(MiraApiPlugin.Id)]
//[BepInDependency(AchievementsAPIPlugin.Id, BepInDependency.DependencyFlags.SoftDependency)]
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public class TownOfExtraPlugin : BasePlugin, IMiraPlugin
{
    private Harmony Harmony { get; } = new(TownOfExtraPluginInfo.Id);

    public string OptionsTitleText => "Town Of Extra";
    public string GetAbbreviatedModName() => $"{TownOfExtraColours.GlobalModColour.ToTextColor()}<b>TOEX</b></color>";

    public ConfigFile GetConfigFile() => Config;

    public static ManualLogSource Logger;
    
    public override void Load()
    {
        ReactorCredits.Register(TownOfExtraPluginInfo.Name, TownOfExtraPluginInfo.Version, TownOfExtraPluginInfo.IsPreRelease, ReactorCredits.AlwaysShow);
        MethodRpcAttribute.Register(Assembly.GetExecutingAssembly(), this);
        Harmony.PatchAll();
        ModNewsFetcher.CheckForNews();
        
        Logger = Log;

        ApplyTouLocaleEdits();
        TerminologyPatches.RegisterToExTerms();
        TerminologyIconRegistry.RegisterIcons();
        
        //todo: this
        /*if (ModCompat.IsLoaded(ModCompat.AApiId, out _))
        {
            Logger.LogInfo("AchievementsAPI found, achievements will be available!");
        }
        else
        {
            Logger.LogWarning("Failed to find AchievementsAPI, achievements will not be available.");
        }*/
    }

    public static void ApplyTouLocaleEdits()
    {
        // ------------------------
        // Death Messages
        // ------------------------
        
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToPoisoned", "Poisoned");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToCannibalised", "Cannibalised");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToShattered", "Shattered");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToTerminated", "Terminated");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToUnbound", "Unbound");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToCrushed", "Crushed");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToStruck", "Struck");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToMiscalculated", "Miscalculated");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToSlain", "Slain");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToPunished", "Punished");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToMurdered", "Murdered");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("DiedToPossessed", "Possessed");

        // ------------------------
        // Wiki Edits
        // ------------------------
        
        MiraLocaleManager.Locale[MiraLanguage.English]
                ["TouRoleClericCleanseWikiDescription"] =
            "Remove all negative effects on a player. (Douse, Hack, Infect, Blackmail, Blind, Flash, Hypnosis, Poisoned, Pending Shift, Doom, Pending Erase, Shockwaved)";
        
        // ------------------------
        // Doomsayer Hints
        // ------------------------
        
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("TouRoleDoomsayerRoleHint101", "You observe that %player% is not from this town");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("TouRoleDoomsayerRoleHint102", "You observe that %player% has an altered perception of reality");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("TouRoleDoomsayerRoleHint103", "You observe that %player% has an insight for private information");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("TouRoleDoomsayerRoleHint104", "You observe that %player% has an unusual obsession with dead bodies");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("TouRoleDoomsayerRoleHint105", "You observe that %player% is well-trained in hunting down prey");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("TouRoleDoomsayerRoleHint106", "You observe that %player% spreads fear amongst the group");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("TouRoleDoomsayerRoleHint107", "You observe that %player% hides to guard themselves or others");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("TouRoleDoomsayerRoleHint108", "You observe that %player% has a trick up their sleeve");
        MiraLocaleManager.Locale[MiraLanguage.English].TryAdd("TouRoleDoomsayerRoleHint109", "You observe that %player% is capable of performing relentless attacks");
    }
}