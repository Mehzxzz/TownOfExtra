using System.Diagnostics.CodeAnalysis;
using MiraAPI.LocalSettings;
using MiraAPI.Utilities.Assets;
using TownOfUs;
using UnityEngine;

namespace TownOfExtra;

[SuppressMessage("ReSharper", "ReplaceAutoPropertyWithComputedProperty")]
public static class TownOfExtraAssets
{
    public static bool UseBasicCrew { get; set; } = LocalSettingsTabSingleton<TouLocalTabPlayers>.Instance.UseCrewmateTeamColorToggle.Value;

    // ---- Crewmate Paths ----
    public static string CrewRoleIconPath => UseBasicCrew ? "TownOfExtra.Resources.BasicCrew.RoleIcons" : "TownOfExtra.Resources.Crew.RoleIcons";
    public static string CrewButtonPath { get; } = "TownOfExtra.Resources.Crew.Buttons";
    public static string CrewMiscPath => UseBasicCrew ? "TownOfExtra.Resources.BasicCrew.Misc" : "TownOfExtra.Resources.Crew.Misc";

    // ---- Impostor Paths ----
    public static string ImpRoleIconPath { get; } = "TownOfExtra.Resources.Imp.RoleIcons";
    public static string ImpButtonPath { get; } = "TownOfExtra.Resources.Imp.Buttons";
    public static string ImpMiscPath { get; } = "TownOfExtra.Resources.Imp.Misc";

    // ---- Neutral Paths ----
    public static string NeutRoleIconPath { get; } = "TownOfExtra.Resources.Neut.RoleIcons";
    public static string NeutButtonPath { get; } = "TownOfExtra.Resources.Neut.Buttons";
    public static string NeutMiscPath { get; } = "TownOfExtra.Resources.Neut.Misc";

    // ---- Modifier Paths ----
    public static string MiscModModIconPath { get; } = "TownOfExtra.Resources.Modifiers.Misc.ModifierIcons";
    
    public static string CrewModModIconPath { get; } = "TownOfExtra.Resources.Modifiers.Crew.ModifierIcons";
    public static string CrewModButtonPath { get; } = "TownOfExtra.Resources.Modifiers.Crew.Buttons";
    public static string CrewModMiscPath { get; } = "TownOfExtra.Resources.Modifiers.Crew.Misc";
    
    public static string ImpModModIconPath { get; } = "TownOfExtra.Resources.Modifiers.Imp.ModifierIcons";
    public static string ImpModButtonPath { get; } = "TownOfExtra.Resources.Modifiers.Imp.Buttons";
    public static string ImpModMiscPath { get; } = "TownOfExtra.Resources.Modifiers.Imp.Misc";
    
    public static string NeutModModIconPath { get; } = "TownOfExtra.Resources.Modifiers.Neut.ModifierIcons";
    public static string NeutModButtonPath { get; } = "TownOfExtra.Resources.Modifiers.Neut.Buttons";
    public static string NeutModMiscPath { get; } = "TownOfExtra.Resources.Modifiers.Neut.Misc";
    
    public static string UniModModIconPath { get; } = "TownOfExtra.Resources.Modifiers.Uni.ModifierIcons";
    public static string UniModButtonPath { get; } = "TownOfExtra.Resources.Modifiers.Uni.Buttons";
    public static string UniModMiscPath { get; } = "TownOfExtra.Resources.Modifiers.Uni.Misc";
    
    public static string NonCrewModModIconPath { get; } = "TownOfExtra.Resources.Modifiers.NonCrew.ModifierIcons";
    public static string NonCrewModButtonPath { get; } = "TownOfExtra.Resources.Modifiers.NonCrew.Buttons";
    public static string NonCrewModMiscPath { get; } = "TownOfExtra.Resources.Modifiers.NonCrew.Misc";

    // ---- General Misc Path ----
    public static string MiscPath { get; } = "TownOfExtra.Resources.Misc";



    // ===============================================================
    //                        PLACEHOLDERS
    // ===============================================================

    public static LoadableAsset<Sprite> Placeholder { get; } =
        new LoadableResourceAsset($"{MiscPath}.Ph.png");
    public static LoadableAsset<Sprite> ProtectPh { get; } =
        new LoadableResourceAsset($"{MiscPath}.PhProtect.png");
    public static LoadableAsset<Sprite> InfoPh { get; } =
        new LoadableResourceAsset($"{MiscPath}.PhInfo.png");
    public static LoadableAsset<Sprite> AttackPh { get; } =
        new LoadableResourceAsset($"{MiscPath}.PhAttack.png");
    public static LoadableAsset<Sprite> MiscPh { get; } =
        new LoadableResourceAsset($"{MiscPath}.PhMisc.png");



    // ===============================================================
    //                         CREWMATE
    // ===============================================================

    // --- Role Icons ---

    // Power
    public static LoadableAsset<Sprite> ChiefRoleIcon { get; } =
        new LoadableResourceAsset($"{CrewRoleIconPath}.ChiefRoleIcon.png", 200);
    public static LoadableAsset<Sprite> JournalistRoleIcon { get; } =
        new LoadableResourceAsset($"{CrewRoleIconPath}.JournalistRoleIcon.png", 200);
    
    // Killing
    public static LoadableAsset<Sprite> CommanderRoleIcon { get; } =
        new LoadableResourceAsset($"{CrewRoleIconPath}.CommanderRoleIcon.png", 200);

    // --- Modifiers ---

    // Passive
    public static LoadableAsset<Sprite> HeavyWorkloadModifierIcon { get; } =
        new LoadableResourceAsset($"{CrewModModIconPath}.HeavyWorkloadModifierIcon.png", 200);
    public static LoadableAsset<Sprite> RoutineModifierIcon { get; } =
        new LoadableResourceAsset($"{CrewModModIconPath}.RoutineModifierIcon.png");
    public static LoadableAsset<Sprite> ObservantModifierIcon { get; } =
        new LoadableResourceAsset($"{CrewModModIconPath}.ObservantModifierIcon.png", 200);
    public static LoadableAsset<Sprite> ClumsyModifierIcon { get; } =
        new LoadableResourceAsset($"{CrewModModIconPath}.ClumsyModifierIcon.png", 200);
    
    // Passive
    public static LoadableAsset<Sprite> PanicShieldModifierIcon { get; } =
        new LoadableResourceAsset($"{CrewModModIconPath}.PanicShieldModifierIcon.png", 200);

    // --- Buttons ---
    
    // Roles

    public static LoadableAsset<Sprite> ChiefRecruitButton { get; } =
        new LoadableResourceAsset($"{CrewButtonPath}.ChiefRecruitButton.png");
    public static LoadableAsset<Sprite> ChiefShootButton { get; } =
        new LoadableResourceAsset($"{CrewButtonPath}.ChiefShootButton.png");
    public static LoadableAsset<Sprite> JournalistInterviewButton { get; } =
        new LoadableResourceAsset($"{CrewButtonPath}.JournalistInterviewButton.png");
    
    // Modifiers
    
    public static LoadableAsset<Sprite> PanicShieldPanicShieldButton { get; } =
        new LoadableResourceAsset($"{CrewModModIconPath}.PanicShieldModifierIcon.png", 225);
    
    // --- Misc ---
    
    public static LoadableAsset<Sprite> SpeedBoostModifierIcon { get; } =
        new LoadableResourceAsset($"{CrewMiscPath}.SpeedBoostModifierIcon.png");
    
    // --- Chat ---
    
    
    
    // ===============================================================
    //                         IMPOSTOR
    // ===============================================================

    // --- Role Icons ---

    // Concealing
    public static LoadableAsset<Sprite> HolographerRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.HolographerRoleIcon.png", 200);
    public static LoadableAsset<Sprite> SignalJammerRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.SignalJammerRoleIcon.png", 200);

    // Killing
    public static LoadableAsset<Sprite> KnifeThrowerRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.KnifeThrowerRoleIcon.png");
    public static LoadableAsset<Sprite> StrikerRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.StrikerRoleIcon.png");
    public static LoadableAsset<Sprite> TaggerRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.TaggerRoleIcon.png");
    public static LoadableAsset<Sprite> BloodlustRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.BloodlustRoleIcon.png");

    // Power
    public static LoadableAsset<Sprite> ConjurerRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.ConjurerRoleIcon.png", 200);
    public static LoadableAsset<Sprite> EraserRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.EraserRoleIcon.png", 200);
    public static LoadableAsset<Sprite> VinculatorRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.VinculatorRoleIcon.png", 356);

    // Support
    public static LoadableAsset<Sprite> FreezerRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.FreezerRoleIcon.png", 356);
    public static LoadableAsset<Sprite> GamblerRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.GamblerRoleIcon.png", 200);
    public static LoadableAsset<Sprite> ObstructorRoleIcon { get; } =
        new LoadableResourceAsset($"{ImpRoleIconPath}.ObstructorRoleIcon.png");

    // --- Modifiers ---
    
    // Utility
    public static LoadableAsset<Sprite> ShockwaveModifierIcon { get; } =
        new LoadableResourceAsset($"{ImpModModIconPath}.ShockwaveModifierIcon.png");
    
    // Passive
    public static LoadableAsset<Sprite> RebirthModifierIcon { get; } =
        new LoadableResourceAsset($"{ImpModModIconPath}.RebirthModifierIcon.png");
    
    // Buttons
    public static LoadableAsset<Sprite> ShockwaveShockwaveButton { get; } =
        new LoadableResourceAsset($"{ImpModButtonPath}.ShockwaveShockwaveButton.png");

    // --- Buttons ---

    public static LoadableAsset<Sprite> TaggerMarkButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.TaggerMarkButton.png", 200);
    public static LoadableAsset<Sprite> HolographerHolographButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.HolographerHolographButton.png");
    public static LoadableAsset<Sprite> SignalJammerJamButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.SignalJammerJamButton.png");
    public static LoadableAsset<Sprite> StrikerLocateButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.StrikerLocateButton.png", 683);
    public static LoadableAsset<Sprite> StrikerStrikeButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.StrikerStrikeButton.png");
    public static LoadableAsset<Sprite> ConjurerConjureButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.ConjurerConjureButton.png");
    public static LoadableAsset<Sprite> DreamCasterCastButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.DreamCasterCastButton.png");
    public static LoadableAsset<Sprite> EraserEraseButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.EraserEraseButton.png");
    public static LoadableAsset<Sprite> VinculatorChainButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.VinculatorChainButton.png");
    public static LoadableAsset<Sprite> VinculatorEmpowerButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.VinculatorEmpowerButton.png");
    public static LoadableAsset<Sprite> FreezerFreezeButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.FreezerFreezeButton.png");
    public static LoadableAsset<Sprite> ObstructorObstructButton { get; } =
        new LoadableResourceAsset($"{ImpButtonPath}.ObstructorObstructButton.png");

    // --- Misc ---
    
    public static LoadableAsset<Sprite> ConjurerRockSprite { get; } =
        new LoadableResourceAsset($"{ImpMiscPath}.ConjurerRockSprite.png");
    public static LoadableAsset<Sprite> ConjurerRockSpriteFallen { get; } =
        new LoadableResourceAsset($"{ImpMiscPath}.ConjurerRockSpriteFallen.png");
    public static LoadableAsset<Sprite> SquashedDeadBodySprite { get; } =
        new LoadableResourceAsset($"{ImpMiscPath}.SquashedDeadBodySprite.png");
    public static LoadableAsset<Sprite> SquashedDeadBodySpriteVisor { get; } =
        new LoadableResourceAsset($"{ImpMiscPath}.SquashedDeadBodySpriteVisor.png");
    public static LoadableAsset<Sprite> EmergencyConsoleBroken { get; } =
        new LoadableResourceAsset($"{ImpMiscPath}.EmergencyConsoleBroken.png");
    public static LoadableAsset<Sprite> ObstructedButtonOverlay { get; } =
        new LoadableResourceAsset($"{ImpMiscPath}.ObstructedButtonOverlay.png");



    // ===============================================================
    //                          NEUTRAL
    // ===============================================================

    // --- Role Icons ---

    // Evil
    public static LoadableAsset<Sprite> PoltergeistRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.PoltergeistRoleIcon.png", 200);
    public static LoadableAsset<Sprite> TricksterRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.TricksterRoleIcon.png", 200);
    public static LoadableAsset<Sprite> VultureRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.VultureRoleIcon.png", 200);

    // Outlier
    public static LoadableAsset<Sprite> ShifterRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.ShifterRoleIcon.png");
    
    // Killing
    public static LoadableAsset<Sprite> SquidRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.SquidRoleIcon.png", 200);
    public static LoadableAsset<Sprite> ShadowWalkerRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.ShadowWalkerRoleIcon.png", 200);
    public static LoadableAsset<Sprite> CannibalRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.CannibalRoleIcon.png");
    public static LoadableAsset<Sprite> BarbarianRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.BarbarianRoleIcon.png", 200);
    public static LoadableAsset<Sprite> ClownRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.ClownRoleIcon.png", 200);
    public static LoadableAsset<Sprite> PoisonerRoleIcon { get; } =
        new LoadableResourceAsset($"{NeutRoleIconPath}.PoisonerRoleIcon.png");

    // --- Buttons ---

    public static LoadableAsset<Sprite> TricksterSampleButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.TricksterSampleButton.png");
    public static LoadableAsset<Sprite> TricksterPlaceButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.TricksterPlaceButton.png");
    public static LoadableAsset<Sprite> ShifterShiftButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.ShifterShiftButton.png", 400);
    public static LoadableAsset<Sprite> VultureEatButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.VultureEatButton.png");
    public static LoadableAsset<Sprite> PoltergeistPossessButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.PoltergeistPossessButton.png");
    public static LoadableAsset<Sprite> PoltergeistScareButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.PoltergeistScareButton.png");
    public static LoadableAsset<Sprite> CannibalEatButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.CannibalEatButton.png");
    public static LoadableAsset<Sprite> ShadowWalkerKillButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.ShadowWalkerKillButton.png");
    public static LoadableAsset<Sprite> ShadowWalkerEnshroudButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.ShadowWalkerEnshroudButton.png");
    public static LoadableAsset<Sprite> SquidKillButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.SquidKillButton.png");
    public static LoadableAsset<Sprite> SquidSpillButton { get; } =
        new LoadableResourceAsset($"{NeutMiscPath}.SquidInkPuddle.png", 225);
    public static LoadableAsset<Sprite> BarbarianTargetButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.BarbarianTargetButton.png", 200);
    public static LoadableAsset<Sprite> BarbarianAttackButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.BarbarianAttackButton.png");
    public static LoadableAsset<Sprite> ClownPlaceButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.ClownPlaceButton.png");
    public static LoadableAsset<Sprite> ClownKillButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.ClownKillButton.png");
    public static LoadableAsset<Sprite> PoisonerPoisonButton { get; } =
        new LoadableResourceAsset($"{NeutButtonPath}.PoisonerPoisonButton.png");
    
    // --- Misc ---
    
    public static LoadableAsset<Sprite> SquidInkPuddle { get; } =
        new LoadableResourceAsset($"{NeutMiscPath}.SquidInkPuddle.png", 230);
    public static LoadableAsset<Sprite> ClownJackInTheBox { get; } =
        new LoadableResourceAsset($"{NeutMiscPath}.ClownJackInTheBox.png", 200);
    public static LoadableAsset<Sprite> PoisonedModifierIcon { get; } =
        new LoadableResourceAsset($"{NeutMiscPath}.PoisonedModifierIcon.png");



    // ===============================================================
    //                         UNIVERSAL
    // ===============================================================

    // --- Modifiers ---

    // Passive
    public static LoadableAsset<Sprite> SoullessModifierIcon { get; } =
        new LoadableResourceAsset($"{UniModModIconPath}.SoullessModifierIcon.png", 200);
    public static LoadableAsset<Sprite> ApoliticalModifierIcon { get; } =
        new LoadableResourceAsset($"{UniModModIconPath}.ApoliticalModifierIcon.png", 200);
    public static LoadableAsset<Sprite> MuteModifierIcon { get; } =
        new LoadableResourceAsset($"{UniModModIconPath}.MuteModifierIcon.png", 200);
    public static LoadableAsset<Sprite> YouthlingModifierIcon { get; } =
        new LoadableResourceAsset($"{UniModModIconPath}.YouthlingModifierIcon.png", 200);
    
    
    
    // ===============================================================
    //                         NON CREW
    // ===============================================================

    // --- Modifiers ---

    // Passive
    public static LoadableAsset<Sprite> ScourgeModifierIcon { get; } =
        new LoadableResourceAsset($"{NonCrewModModIconPath}.ScourgeRoleIcon.png");
    


    // ===============================================================
    //                           MISC
    // ===============================================================

    public static LoadableAsset<Sprite> TownOfExtraIcon { get; } =
        new LoadableResourceAsset($"{MiscPath}.TownOfExtraIcon.png", 250);
}