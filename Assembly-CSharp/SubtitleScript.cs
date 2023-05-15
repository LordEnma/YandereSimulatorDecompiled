using UnityEngine;

public class SubtitleScript : MonoBehaviour
{
	public JukeboxScript Jukebox;

	public Transform Yandere;

	public UILabel EventLabel;

	public UILabel Label;

	public string[] WeaponBloodInsanityReactions;

	public string[] WeaponBloodReactions;

	public string[] WeaponInsanityReactions;

	public string[] BloodInsanityReactions;

	public string[] BloodReactions;

	public string[] BloodPoolReactions;

	public string[] BloodyWeaponReactions;

	public string[] LimbReactions;

	public string[] WetBloodReactions;

	public string[] InsanityReactions;

	public string[] LewdReactions;

	public string[] SuspiciousReactions;

	public string[] MurderReactions;

	public string[] CowardMurderReactions;

	public string[] EvilMurderReactions;

	public string[] HoldingBloodyClothingReactions;

	public string[] PetBloodReports;

	public string[] PetBloodReactions;

	public string[] PetCorpseReports;

	public string[] PetCorpseReactions;

	public string[] PetLimbReports;

	public string[] PetLimbReactions;

	public string[] PetMurderReports;

	public string[] PetMurderReactions;

	public string[] PetWeaponReports;

	public string[] PetWeaponReactions;

	public string[] PetBloodyWeaponReports;

	public string[] PetBloodyWeaponReactions;

	public string[] HeroMurderReactions;

	public string[] LonerMurderReactions;

	public string[] LonerCorpseReactions;

	public string[] EvilCorpseReactions;

	public string[] EvilDelinquentCorpseReactions;

	public string[] SocialDeathReactions;

	public string[] LovestruckDeathReactions;

	public string[] LovestruckMurderReports;

	public string[] LovestruckCorpseReports;

	public string[] SocialReports;

	public string[] SocialFears;

	public string[] SocialTerrors;

	public string[] RepeatReactions;

	public string[] CorpseReactions;

	public string[] PoisonReactions;

	public string[] PrankReactions;

	public string[] InterruptReactions;

	public string[] IntrusionReactions;

	public string[] NoteReactions;

	public string[] NoteReactionsMale;

	public string[] OfferSnacks;

	public string[] FoodAccepts;

	public string[] FoodRejects;

	public string[] EavesdropReactions;

	public string[] ViolenceReactions;

	public string[] EventEavesdropReactions;

	public string[] RivalEavesdropReactions;

	public string[] PickpocketReactions;

	public string[] RivalPickpocketReactions;

	public string[] DrownReactions;

	public string[] ParanoidReactions;

	public string[] TheftReactions;

	public string[] TutorialReactions;

	public string[] TrespassReactions;

	public string[] KilledMoods;

	public string[] SendToLockers;

	public string[] KnifeReactions;

	public string[] ScissorsReactions;

	public string[] SyringeReactions;

	public string[] KatanaReactions;

	public string[] SawReactions;

	public string[] RitualReactions;

	public string[] BatReactions;

	public string[] ShovelReactions;

	public string[] DumbbellReactions;

	public string[] AxeReactions;

	public string[] PropReactions;

	public string[] DelinkWeaponReactions;

	public string[] ExtinguisherReactions;

	public string[] WrenchReactions;

	public string[] GuitarReactions;

	public string[] ScrapReactions;

	public string[] WeaponBloodApologies;

	public string[] WeaponApologies;

	public string[] BloodApologies;

	public string[] InsanityApologies;

	public string[] LewdApologies;

	public string[] SuspiciousApologies;

	public string[] EventApologies;

	public string[] ClassApologies;

	public string[] AccidentApologies;

	public string[] SadApologies;

	public string[] EavesdropApologies;

	public string[] ViolenceApologies;

	public string[] PickpocketApologies;

	public string[] CleaningApologies;

	public string[] PoisonApologies;

	public string[] HoldingBloodyClothingApologies;

	public string[] TheftApologies;

	public string[] TrespassApologies;

	public string[] TutorialApologies;

	public string[] Greetings;

	public string[] PlayerFarewells;

	public string[] StudentFarewells;

	public string[] Forgivings;

	public string[] AccidentForgivings;

	public string[] InsanityForgivings;

	public string[] TrespassForgivings;

	public string[] PlayerCompliments;

	public string[] StudentHighCompliments;

	public string[] StudentMidCompliments;

	public string[] StudentLowCompliments;

	public string[] PlayerGossip;

	public string[] StudentGossip;

	public string[] PlayerFollows;

	public string[] StudentFollows;

	public string[] PlayerLeaves;

	public string[] StudentLeaves;

	public string[] StudentStays;

	public string[] PlayerDistracts;

	public string[] StudentDistracts;

	public string[] StudentDistractRefuses;

	public string[] StudentDistractBullyRefuses;

	public string[] StopFollowApologies;

	public string[] GrudgeWarnings;

	public string[] GrudgeRefusals;

	public string[] CowardGrudges;

	public string[] EvilGrudges;

	public string[] PlayerLove;

	public string[] SuitorLove;

	public string[] RivalLove;

	public string[] RequestMedicines;

	public string[] ReturningWeapons;

	public string[] Impatiences;

	public string[] ImpatientFarewells;

	public string[] Deaths;

	public string[] SenpaiInsanityReactions;

	public string[] SenpaiWeaponReactions;

	public string[] SenpaiBloodReactions;

	public string[] SenpaiLewdReactions;

	public string[] SenpaiStalkingReactions;

	public string[] SenpaiMurderReactions;

	public string[] SenpaiCorpseReactions;

	public string[] SenpaiViolenceReactions;

	public string[] SenpaiRivalDeathReactions;

	public string[] RaibaruRivalDeathReactions;

	public string[] OsanaObstacleDeathReactions;

	public string[] TeacherInsanityReactions;

	public string[] TeacherWeaponReactions;

	public string[] TeacherBloodReactions;

	public string[] TeacherInsanityHostiles;

	public string[] TeacherWeaponHostiles;

	public string[] TeacherBloodHostiles;

	public string[] TeacherCoverUpHostiles;

	public string[] TeacherLewdReactions;

	public string[] TeacherTrespassReactions;

	public string[] TeacherLateReactions;

	public string[] TeacherReportReactions;

	public string[] TeacherCorpseReactions;

	public string[] TeacherCorpseInspections;

	public string[] TeacherPoliceReports;

	public string[] TeacherAttackReactions;

	public string[] TeacherMurderReactions;

	public string[] TeacherPrankReactions;

	public string[] TeacherTheftReactions;

	public string[] DelinquentAnnoys;

	public string[] DelinquentCases;

	public string[] DelinquentShoves;

	public string[] DelinquentReactions;

	public string[] DelinquentWeaponReactions;

	public string[] DelinquentThreateneds;

	public string[] DelinquentTaunts;

	public string[] DelinquentCalms;

	public string[] DelinquentFights;

	public string[] DelinquentAvenges;

	public string[] DelinquentWins;

	public string[] DelinquentSurrenders;

	public string[] DelinquentNoSurrenders;

	public string[] DelinquentMurderReactions;

	public string[] DelinquentCorpseReactions;

	public string[] DelinquentFriendCorpseReactions;

	public string[] DelinquentResumes;

	public string[] DelinquentFlees;

	public string[] DelinquentEnemyFlees;

	public string[] DelinquentFriendFlees;

	public string[] DelinquentInjuredFlees;

	public string[] DelinquentCheers;

	public string[] DelinquentHmms;

	public string[] DelinquentGrudges;

	public string[] Dismissives;

	public string[] LostPhones;

	public string[] RivalLostPhones;

	public string[] StudentMurderReports;

	public string[] YandereWhimpers;

	public string[] SplashReactions;

	public string[] SplashReactionsMale;

	public string[] RivalSplashReactions;

	public string[] LightSwitchReactions;

	public string[] PhotoAnnoyances;

	public string[] Task4Lines;

	public string[] Task6Lines;

	public string[] Task7Lines;

	public string[] Task8Lines;

	public string[] Task11Lines;

	public string[] Task12Lines;

	public string[] Task13Lines;

	public string[] Task14Lines;

	public string[] Task15Lines;

	public string[] Task16Lines;

	public string[] Task17Lines;

	public string[] Task18Lines;

	public string[] Task19Lines;

	public string[] Task20Lines;

	public string[] Task25Lines;

	public string[] Task28Lines;

	public string[] Task30Lines;

	public string[] Task32Lines;

	public string[] Task33Lines;

	public string[] Task34Lines;

	public string[] Task36Lines;

	public string[] Task37Lines;

	public string[] Task38Lines;

	public string[] Task41Lines;

	public string[] Task46Lines;

	public string[] Task47Lines;

	public string[] Task48Lines;

	public string[] Task49Lines;

	public string[] Task50Lines;

	public string[] Task52Lines;

	public string[] Task76Lines;

	public string[] Task77Lines;

	public string[] Task78Lines;

	public string[] Task79Lines;

	public string[] Task80Lines;

	public string[] Task81Lines;

	public string[] TaskGenericLines;

	public string[] TaskGenericEightiesLines1;

	public string[] TaskGenericEightiesLines2;

	public string[] TaskGenericEightiesLines3;

	public string[] TaskGenericEightiesLines4;

	public string[] TaskGenericEightiesLines5;

	public string[] TaskGenericEightiesLines6;

	public string[] TaskGenericEightiesLines7;

	public string[] TaskGenericEightiesLines8;

	public string[] TaskGenericEightiesLines9;

	public string[] TaskGenericEightiesLines10;

	public string[] TaskInquiries;

	public string[] TaskRequirements;

	public string[] TaskEightiesRequirements;

	public string[] Task11LinesEighties;

	public string[] Task12LinesEighties;

	public string[] Task13LinesEighties;

	public string[] Task14LinesEighties;

	public string[] Task15LinesEighties;

	public string[] Task16LinesEighties;

	public string[] Task17LinesEighties;

	public string[] Task18LinesEighties;

	public string[] Task19LinesEighties;

	public string[] Task20LinesEighties;

	public string[] Task79LinesEighties;

	public string[] Club0Info;

	public string[] Club1Info;

	public string[] Club2Info;

	public string[] Club3Info;

	public string[] Club4Info;

	public string[] Club5Info;

	public string[] Club6Info;

	public string[] Club7InfoLight;

	public string[] Club7InfoDark;

	public string[] Club8Info;

	public string[] Club9Info;

	public string[] Club10Info;

	public string[] Club11Info;

	public string[] Club12Info;

	public string[] Club13Info;

	public string[] SubClub3Info;

	public string[] ClubGreetings;

	public string[] ClubUnwelcomes;

	public string[] ClubKicks;

	public string[] ClubJoins;

	public string[] ClubAccepts;

	public string[] ClubRefuses;

	public string[] ClubRejoins;

	public string[] ClubExclusives;

	public string[] ClubGrudges;

	public string[] ClubQuits;

	public string[] ClubConfirms;

	public string[] ClubDenies;

	public string[] ClubFarewells;

	public string[] ClubActivities;

	public string[] ClubEarlies;

	public string[] ClubLates;

	public string[] ClubYeses;

	public string[] ClubNoes;

	public string[] ClubPractices;

	public string[] ClubPracticeYeses;

	public string[] ClubPracticeNoes;

	public string[] Eulogies;

	public string[] AskForHelps;

	public string[] GiveHelps;

	public string[] RejectHelps;

	public string[] GasWarnings;

	public string[] ObstacleMurderReactions;

	public string[] ObstaclePoisonReactions;

	public string[] StrictReport;

	public string[] CasualReport;

	public string[] GraceReport;

	public string[] EdgyReport;

	public string[] BreakingUp;

	public string[] Spraying;

	public string[] Shoving;

	public string[] Chasing;

	public string[] CouncilCorpseReactions;

	public string[] CouncilToCounselors;

	public string[] HmmReactions;

	public string InfoNotice;

	public string CustomText;

	public int PreviousRandom;

	public int RandomID;

	public float Timer;

	public int StudentID;

	public PersonaSubtitleScript PersonaSubtitle;

	public AudioClip LongestSilence;

	public EightiesClubDialogueScript EightiesClubDialogue;

	public SubtitleType PreviousSubtitle;

	private int PreviousStudentID;

	public AudioClip[] NoteReactionClips;

	public AudioClip[] NoteReactionMaleClips;

	public AudioClip[] GrudgeWarningClips;

	public AudioClip[] SenpaiInsanityReactionClips;

	public AudioClip[] SenpaiWeaponReactionClips;

	public AudioClip[] SenpaiBloodReactionClips;

	public AudioClip[] SenpaiLewdReactionClips;

	public AudioClip[] SenpaiStalkingReactionClips;

	public AudioClip[] SenpaiMurderReactionClips;

	public AudioClip[] SenpaiViolenceReactionClips;

	public AudioClip[] SenpaiRivalDeathReactionClips;

	public AudioClip[] RaibaruRivalDeathReactionClips;

	public AudioClip[] OsanaObstacleDeathReactionClips;

	public AudioClip[] YandereWhimperClips;

	public AudioClip[] TheftClips;

	public AudioClip[] TeacherWeaponClips;

	public AudioClip[] TeacherBloodClips;

	public AudioClip[] TeacherInsanityClips;

	public AudioClip[] TeacherWeaponHostileClips;

	public AudioClip[] TeacherBloodHostileClips;

	public AudioClip[] TeacherInsanityHostileClips;

	public AudioClip[] TeacherCoverUpHostileClips;

	public AudioClip[] TeacherLewdClips;

	public AudioClip[] TeacherTrespassClips;

	public AudioClip[] TeacherLateClips;

	public AudioClip[] TeacherReportClips;

	public AudioClip[] TeacherCorpseClips;

	public AudioClip[] TeacherInspectClips;

	public AudioClip[] TeacherPoliceClips;

	public AudioClip[] TeacherAttackClips;

	public AudioClip[] TeacherMurderClips;

	public AudioClip[] TeacherPrankClips;

	public AudioClip[] TeacherTheftClips;

	public AudioClip[] LostPhoneClips;

	public AudioClip[] RivalLostPhoneClips;

	public AudioClip[] PickpocketReactionClips;

	public AudioClip[] RivalPickpocketReactionClips;

	public AudioClip[] SplashReactionClips;

	public AudioClip[] SplashReactionMaleClips;

	public AudioClip[] RivalSplashReactionClips;

	public AudioClip[] DrownReactionClips;

	public AudioClip[] LightSwitchClips;

	public AudioClip[] Task4Clips;

	public AudioClip[] Task6Clips;

	public AudioClip[] Task7Clips;

	public AudioClip[] Task8Clips;

	public AudioClip[] Task11Clips;

	public AudioClip[] Task12Clips;

	public AudioClip[] Task13Clips;

	public AudioClip[] Task14Clips;

	public AudioClip[] Task15Clips;

	public AudioClip[] Task16Clips;

	public AudioClip[] Task17Clips;

	public AudioClip[] Task18Clips;

	public AudioClip[] Task19Clips;

	public AudioClip[] Task20Clips;

	public AudioClip[] Task25Clips;

	public AudioClip[] Task28Clips;

	public AudioClip[] Task30Clips;

	public AudioClip[] Task32Clips;

	public AudioClip[] Task33Clips;

	public AudioClip[] Task34Clips;

	public AudioClip[] Task36Clips;

	public AudioClip[] Task37Clips;

	public AudioClip[] Task38Clips;

	public AudioClip[] Task41Clips;

	public AudioClip[] Task46Clips;

	public AudioClip[] Task47Clips;

	public AudioClip[] Task48Clips;

	public AudioClip[] Task49Clips;

	public AudioClip[] Task50Clips;

	public AudioClip[] Task52Clips;

	public AudioClip[] Task76Clips;

	public AudioClip[] Task77Clips;

	public AudioClip[] Task78Clips;

	public AudioClip[] Task79Clips;

	public AudioClip[] Task80Clips;

	public AudioClip[] Task81Clips;

	public AudioClip[] TaskGenericMaleClips;

	public AudioClip[] TaskGenericFemaleClips;

	public AudioClip[] TaskGenericEightiesMaleClips1;

	public AudioClip[] TaskGenericEightiesMaleClips2;

	public AudioClip[] TaskGenericEightiesMaleClips3;

	public AudioClip[] TaskGenericEightiesMaleClips4;

	public AudioClip[] TaskGenericEightiesMaleClips5;

	public AudioClip[] TaskGenericEightiesMaleClips6;

	public AudioClip[] TaskGenericEightiesMaleClips7;

	public AudioClip[] TaskGenericEightiesMaleClips8;

	public AudioClip[] TaskGenericEightiesMaleClips9;

	public AudioClip[] TaskGenericEightiesMaleClips10;

	public AudioClip[] TaskGenericEightiesFemaleClips1;

	public AudioClip[] TaskGenericEightiesFemaleClips2;

	public AudioClip[] TaskGenericEightiesFemaleClips3;

	public AudioClip[] TaskGenericEightiesFemaleClips4;

	public AudioClip[] TaskGenericEightiesFemaleClips5;

	public AudioClip[] TaskGenericEightiesFemaleClips6;

	public AudioClip[] TaskGenericEightiesFemaleClips7;

	public AudioClip[] TaskGenericEightiesFemaleClips8;

	public AudioClip[] TaskGenericEightiesFemaleClips9;

	public AudioClip[] TaskGenericEightiesFemaleClips10;

	public AudioClip[] TaskInquiryClips;

	public AudioClip[] TaskRequirementClips;

	public AudioClip[] TaskEightiesRequirementClips;

	public AudioClip[] Task11ClipsEighties;

	public AudioClip[] Task12ClipsEighties;

	public AudioClip[] Task13ClipsEighties;

	public AudioClip[] Task14ClipsEighties;

	public AudioClip[] Task15ClipsEighties;

	public AudioClip[] Task16ClipsEighties;

	public AudioClip[] Task17ClipsEighties;

	public AudioClip[] Task18ClipsEighties;

	public AudioClip[] Task19ClipsEighties;

	public AudioClip[] Task20ClipsEighties;

	public AudioClip[] Task79ClipsEighties;

	public AudioClip[] TutorialReactionClips;

	public AudioClip[] TrespassReactionClips;

	public AudioClip[] Club0Clips;

	public AudioClip[] Club1Clips;

	public AudioClip[] Club2Clips;

	public AudioClip[] Club3Clips;

	public AudioClip[] Club4Clips;

	public AudioClip[] Club5Clips;

	public AudioClip[] Club6Clips;

	public AudioClip[] Club7ClipsLight;

	public AudioClip[] Club7ClipsDark;

	public AudioClip[] Club8Clips;

	public AudioClip[] Club9Clips;

	public AudioClip[] Club10Clips;

	public AudioClip[] Club11Clips;

	public AudioClip[] Club12Clips;

	public AudioClip[] Club13Clips;

	public AudioClip[] SubClub3Clips;

	public AudioClip[] ClubGreetingClips;

	public AudioClip[] ClubUnwelcomeClips;

	public AudioClip[] ClubKickClips;

	public AudioClip[] ClubJoinClips;

	public AudioClip[] ClubAcceptClips;

	public AudioClip[] ClubRefuseClips;

	public AudioClip[] ClubRejoinClips;

	public AudioClip[] ClubExclusiveClips;

	public AudioClip[] ClubGrudgeClips;

	public AudioClip[] ClubQuitClips;

	public AudioClip[] ClubConfirmClips;

	public AudioClip[] ClubDenyClips;

	public AudioClip[] ClubFarewellClips;

	public AudioClip[] ClubActivityClips;

	public AudioClip[] ClubEarlyClips;

	public AudioClip[] ClubLateClips;

	public AudioClip[] ClubYesClips;

	public AudioClip[] ClubNoClips;

	public AudioClip[] ClubPracticeClips;

	public AudioClip[] ClubPracticeYesClips;

	public AudioClip[] ClubPracticeNoClips;

	public AudioClip[] EavesdropClips;

	public AudioClip[] FoodRejectionClips;

	public AudioClip[] ViolenceClips;

	public AudioClip[] EventEavesdropClips;

	public AudioClip[] RivalEavesdropClips;

	public AudioClip[] DelinquentAnnoyClips;

	public AudioClip[] DelinquentCaseClips;

	public AudioClip[] DelinquentShoveClips;

	public AudioClip[] DelinquentReactionClips;

	public AudioClip[] DelinquentWeaponReactionClips;

	public AudioClip[] DelinquentThreatenedClips;

	public AudioClip[] DelinquentTauntClips;

	public AudioClip[] DelinquentCalmClips;

	public AudioClip[] DelinquentFightClips;

	public AudioClip[] DelinquentAvengeClips;

	public AudioClip[] DelinquentWinClips;

	public AudioClip[] DelinquentSurrenderClips;

	public AudioClip[] DelinquentNoSurrenderClips;

	public AudioClip[] DelinquentMurderReactionClips;

	public AudioClip[] DelinquentCorpseReactionClips;

	public AudioClip[] DelinquentFriendCorpseReactionClips;

	public AudioClip[] DelinquentResumeClips;

	public AudioClip[] DelinquentFleeClips;

	public AudioClip[] DelinquentEnemyFleeClips;

	public AudioClip[] DelinquentFriendFleeClips;

	public AudioClip[] DelinquentInjuredFleeClips;

	public AudioClip[] DelinquentCheerClips;

	public AudioClip[] DelinquentHmmClips;

	public AudioClip[] DelinquentGrudgeClips;

	public AudioClip[] DismissiveClips;

	public AudioClip[] EvilDelinquentCorpseReactionClips;

	public AudioClip[] AltDelinquentAnnoyClips;

	public AudioClip[] AltDelinquentCaseClips;

	public AudioClip[] AltDelinquentShoveClips;

	public AudioClip[] AltDelinquentReactionClips;

	public AudioClip[] AltDelinquentWeaponReactionClips;

	public AudioClip[] AltDelinquentThreatenedClips;

	public AudioClip[] AltDelinquentTauntClips;

	public AudioClip[] AltDelinquentCalmClips;

	public AudioClip[] AltDelinquentFightClips;

	public AudioClip[] AltDelinquentAvengeClips;

	public AudioClip[] AltDelinquentWinClips;

	public AudioClip[] AltDelinquentSurrenderClips;

	public AudioClip[] AltDelinquentNoSurrenderClips;

	public AudioClip[] AltDelinquentMurderReactionClips;

	public AudioClip[] AltDelinquentCorpseReactionClips;

	public AudioClip[] AltDelinquentFriendCorpseReactionClips;

	public AudioClip[] AltDelinquentResumeClips;

	public AudioClip[] AltDelinquentFleeClips;

	public AudioClip[] AltDelinquentEnemyFleeClips;

	public AudioClip[] AltDelinquentFriendFleeClips;

	public AudioClip[] AltDelinquentInjuredFleeClips;

	public AudioClip[] AltDelinquentCheerClips;

	public AudioClip[] AltDelinquentHmmClips;

	public AudioClip[] AltDelinquentGrudgeClips;

	public AudioClip[] AltDismissiveClips;

	public AudioClip[] AltEvilDelinquentCorpseReactionClips;

	public AudioClip[] EulogyClips;

	public AudioClip[] ObstacleMurderReactionClips;

	public AudioClip[] ObstaclePoisonReactionClips;

	public AudioClip[] GasWarningClips;

	public AudioClip[] StudentStayClips;

	public AudioClip[] StrictReportClips;

	public AudioClip[] CasualReportClips;

	public AudioClip[] GraceReportClips;

	public AudioClip[] EdgyReportClips;

	public AudioClip[] BreakUpClips;

	public AudioClip[] ChaseClips;

	public AudioClip[] ShoveClips;

	public AudioClip[] SprayClips;

	public AudioClip[] HmmClips;

	public AudioClip[] CouncilCorpseClips;

	public AudioClip[] CouncilCounselorClips;

	private SubtitleTypeAndAudioClipArrayDictionary SubtitleClipArrays;

	public GameObject CurrentClip;

	public StudentScript Speaker;

	public UISprite Darkness;

	public UILabel EventSubtitle;

	private void Awake()
	{
		if (GameGlobals.Eighties)
		{
			PlayerLove[4] = "She's at the east fountain. Go there and use the advice I gave you.";
			Task11Lines = Task11LinesEighties;
			Task11Clips = Task11ClipsEighties;
			Task12Lines = Task12LinesEighties;
			Task12Clips = Task12ClipsEighties;
			Task13Lines = Task13LinesEighties;
			Task13Clips = Task13ClipsEighties;
			Task14Lines = Task14LinesEighties;
			Task14Clips = Task14ClipsEighties;
			Task15Lines = Task15LinesEighties;
			Task15Clips = Task15ClipsEighties;
			Task16Lines = Task16LinesEighties;
			Task16Clips = Task16ClipsEighties;
			Task17Lines = Task17LinesEighties;
			Task17Clips = Task17ClipsEighties;
			Task18Lines = Task18LinesEighties;
			Task18Clips = Task18ClipsEighties;
			Task19Lines = Task19LinesEighties;
			Task19Clips = Task19ClipsEighties;
			Task20Lines = Task20LinesEighties;
			Task20Clips = Task20ClipsEighties;
			Task79Lines = Task79LinesEighties;
			Task79Clips = Task79ClipsEighties;
			Club1Info[1] = "This is the cooking club! Everyone here enjoys preparing food! We also like to hand out our food to people around school!";
			Club1Info[2] = "If you join our club, you'll get access to our ingredients, and you'll be able to prepare snacks to hand out to people.";
			Club1Info[3] = "Giving people food is a very effective way to get people to like you!";
			Club2Info[1] = "This is the drama club! Everyone here is very passionate about acting, especially stage plays!";
			Club2Info[2] = "If you join our club, you'll get access to our costumes.";
			Club2Info[3] = "Don't worry, I trust you! I'm sure you wouldn't do anything illegal while wearing our masks and gloves.";
			Club3Info[1] = "This is the occult club! Everyone here is dedicated to the study of the supernatural.";
			Club3Info[2] = "In this world, there are horrific sights that might cause certain people to...lose some of their sanity.";
			Club3Info[3] = "If you join our club, you'll develop a tolerance for horrific things, and you won't lose your sanity. ...well, most of it.";
			Club4Info[1] = "Well, we do all sorts of things here! We make paintings, we make clay sculptures, and we sometimes just do fun arts and crafts!";
			Club4Info[2] = "If you're an artist, or if you'd just like to give it a try, you're welcome to join us!";
			Club4Info[3] = "The best part? If you're wearing a painter's smock, nobody will notice if you've spilled anything on your clothing! Like...you know, ketchup, or something!";
			Club5Info[1] = "This is the light music club! Everyone here loves to make music!";
			Club5Info[2] = "If you join our club, you'll gain access to our musical instrument cases.";
			Club5Info[3] = "Our giant cello case is a great way to transport certain things in secrecy. ...you know, like yummy cakes and stuff like that!";
			Club6Info[1] = "This is the martial arts club! Everyone here is serious about self-improvement!";
			Club6Info[2] = "We train our bodies, but we also train our minds, as well!";
			Club6Info[3] = "If you join our club, I'll teach you how to instantly win any physical confrontation!";
			Club7InfoLight[1] = "We study photography here! Every day, we take pictures and share them with one another so we can grow as photographers!";
			Club7InfoLight[2] = "If you're a diehard fan of photography, or if you just have a passing interest and want to learn more about it, please join us!";
			Club7InfoLight[3] = "If you join, we'll let you have one of our spare polaroid cameras. It's so cool how they can print a photo immediately!";
			Club8Info[1] = "This is the science club! Everyone here takes science very seriously!";
			Club8Info[2] = "We primarily focus on chemistry here. I'm sorry if you expected something sci-fi.";
			Club8Info[3] = "If you join our club, you'll get access to our emergency shower. If you spill dangerous chemicals, it can be a life-saver.";
			Club9Info[1] = "This is the sports club! You don't need me to explain what this club is about, right? Running and swimming!";
			Club9Info[2] = "We exercise during almost all of our free time! When we're not jogging, we're swimming! Gotta stay fit!";
			Club9Info[3] = "If you join our club, I guarantee you'll become a faster runner!";
			Club10Info[1] = "This is the gardening club! Everyone here loves planting flowers!";
			Club10Info[2] = "You'll usually see us tending to our garden here or watering the plants around school.";
			Club10Info[3] = "If you join our club, you'll get access to our supply shed! Oh, but there's some dangerous stuff in there, so be careful.";
			for (int i = 1; i < 14; i++)
			{
				ClubGreetings[i] = "Hi! Thanks for visiting!";
				ClubUnwelcomes[i] = "I saw you kill someone. You can't just...pretend that nothing happened. I want you to leave. Now.";
				ClubKicks[i] = "Someone in the club has a big problem with you. I can't let you remain in the club. I'm very sorry about this...";
				ClubJoins[i] = "Oh! Would you like to join us?";
				ClubAccepts[i] = "That's great! Welcome to the club!";
				ClubRefuses[i] = "Aww, too bad. Let me know if you change your mind!";
				ClubRejoins[i] = "I'm sorry, I can't let you back into the club. You might leave us again, just like last time.";
				ClubExclusives[i] = "I'm sorry, you're already a member of another club. You'd have to leave them if you want to join us.";
				ClubGrudges[i] = "I'm sorry...someone in our club has a big problem with you. I can't let you join.";
				ClubQuits[i] = "Uh-oh! Are you thinking about quitting the club?";
				ClubConfirms[i] = "Aww, that's too bad. I'm sad to see you go.";
				ClubDenies[i] = "Phew! I'm relieved to hear that!";
				ClubFarewells[i] = "Bye! See you around school!";
				ClubActivities[i] = "We're about to start our daily club activities! Would you like to join us?";
				ClubEarlies[i] = "I'm sorry, it's too early in the day for club activities. Please come back between 5:00 and 5:30!";
				ClubLates[i] = "I'm sorry, we're already done with club activities. To participate, you'd have to be here earlier than 5:30.";
				ClubYeses[i] = "Great! Let's get started!";
				ClubNoes[i] = "Okay. We can wait for you, but no longer than 5:30.";
				ClubGreetingClips[i] = LongestSilence;
				ClubUnwelcomeClips[i] = LongestSilence;
				ClubKickClips[i] = LongestSilence;
				ClubJoinClips[i] = LongestSilence;
				ClubAcceptClips[i] = LongestSilence;
				ClubRefuseClips[i] = LongestSilence;
				ClubRejoinClips[i] = LongestSilence;
				ClubExclusiveClips[i] = LongestSilence;
				ClubGrudgeClips[i] = LongestSilence;
				ClubQuitClips[i] = LongestSilence;
				ClubConfirmClips[i] = LongestSilence;
				ClubDenyClips[i] = LongestSilence;
				ClubFarewellClips[i] = LongestSilence;
				ClubActivityClips[i] = LongestSilence;
				ClubEarlyClips[i] = LongestSilence;
				ClubLateClips[i] = LongestSilence;
				ClubYesClips[i] = LongestSilence;
				ClubNoClips[i] = LongestSilence;
			}
			EightiesClubDialogue.UpdateDialogue(2);
			EightiesClubDialogue.UpdateDialogue(3);
			EightiesClubDialogue.UpdateDialogue(4);
			TaskRequirements = TaskEightiesRequirements;
			Shoving[1] = "Back off.";
			Shoving[2] = "Desculpa!";
			Shoving[3] = "Oops, sorry!";
			Shoving[4] = "Too close, girlie.";
			Chasing[1] = "How dare you!";
			Chasing[2] = "Ai meu Deus!";
			Chasing[3] = "How could you do that?!";
			Chasing[4] = "I'm taking you down!";
			Spraying[1] = "Take this!";
			Spraying[2] = "Spray de pimenta!";
			Spraying[3] = "You brought this on yourself!";
			Spraying[4] = "Get on the ground now!";
			BreakingUp[1] = "Cease this nonsense immediately.";
			BreakingUp[2] = "No! Do not fight!";
			BreakingUp[3] = "Um, please, don't do this!";
			BreakingUp[4] = "Knock it off, or I'll kick BOTH your asses.";
			CouncilToCounselors[1] = "This conduct is unacceptable. Come with me to the counselor's office.";
			CouncilToCounselors[2] = "I'm sorry! You must go to the conselheira.";
			CouncilToCounselors[3] = "Um, I'm really sorry, but the counselor will need to hear about this...";
			CouncilToCounselors[4] = "What the hell do you think you're doing? Get your ass to the counselor's office.";
			CouncilCorpseReactions[1] = "A dead body?!";
			CouncilCorpseReactions[2] = "Você morreu?!";
			CouncilCorpseReactions[3] = "Oh, no! This is horrible!";
			CouncilCorpseReactions[4] = "Damn! This is serious!";
			StrictReport[1] = "The faculty must be informed!";
			StrictReport[2] = "I've discovered a dead body! Come with me!";
			StrictReport[3] = "...no...impossible...";
			CasualReport[1] = "Devo contar a uma professora!";
			CasualReport[2] = "Emergency! Dead body! Follow me!";
			CasualReport[3] = "O que está acontecendo aqui...";
			GraceReport[1] = "The teachers need to hear about this!";
			GraceReport[2] = "Help! Help! Somebody's dead!";
			GraceReport[3] = "No! Wait! I'm telling the truth! I swear!";
			EdgyReport[1] = "Gotta act fast!";
			EdgyReport[2] = "Listen up! I found a dead body!";
			EdgyReport[3] = "What the hell?! What's going on here?!";
			LovestruckMurderReports[0] = "Senpai! Ryoba from class 2-1 just killed someone!";
			WeaponBloodApologies[0] = "It's not what it looks like! It's a costume and prop for an upcoming play.";
			for (int j = 1; j < 5; j++)
			{
				ShoveClips[j] = LongestSilence;
				ChaseClips[j] = LongestSilence;
				SprayClips[j] = LongestSilence;
				BreakUpClips[j] = LongestSilence;
				CouncilCorpseClips[j] = LongestSilence;
				CouncilCounselorClips[j] = LongestSilence;
				HmmClips[j] = LongestSilence;
			}
			for (int j = 1; j < 4; j++)
			{
				StrictReportClips[j] = LongestSilence;
				CasualReportClips[j] = LongestSilence;
				GraceReportClips[j] = LongestSilence;
				EdgyReportClips[j] = LongestSilence;
			}
			SenpaiRivalDeathReactions[0] = "...huh? ...are you okay?! What's wrong?! Hey!! Do you need any help?!";
			SenpaiRivalDeathReactions[1] = "Huh?! What happened?!";
			SenpaiRivalDeathReactions[2] = "Oh my god!! No!! Please, say something!! Answer me!! Wake up, please, wake up!! Don't do this!! Oh, god!! This can't be happening!! NO!! ...no...";
			SenpaiRivalDeathReactions[4] = "No...no...(Sobbing)...no, no, no...no...no...";
			SenpaiRivalDeathReactionClips[0] = LongestSilence;
			SenpaiRivalDeathReactionClips[1] = LongestSilence;
			SenpaiRivalDeathReactionClips[2] = LongestSilence;
			SenpaiRivalDeathReactionClips[4] = LongestSilence;
			Silence(DelinquentAnnoyClips);
			Silence(DelinquentCaseClips);
			Silence(DelinquentShoveClips);
			Silence(DelinquentReactionClips);
			Silence(DelinquentWeaponReactionClips);
			Silence(DelinquentThreatenedClips);
			Silence(DelinquentTauntClips);
			Silence(DelinquentCalmClips);
			Silence(DelinquentFightClips);
			Silence(DelinquentAvengeClips);
			Silence(DelinquentWinClips);
			Silence(DelinquentSurrenderClips);
			Silence(DelinquentNoSurrenderClips);
			Silence(DelinquentMurderReactionClips);
			Silence(DelinquentCorpseReactionClips);
			Silence(DelinquentFriendCorpseReactionClips);
			Silence(DelinquentResumeClips);
			Silence(DelinquentFleeClips);
			Silence(DelinquentEnemyFleeClips);
			Silence(DelinquentFriendFleeClips);
			Silence(DelinquentInjuredFleeClips);
			Silence(DelinquentCheerClips);
			Silence(DelinquentHmmClips);
			Silence(DelinquentGrudgeClips);
			Silence(DismissiveClips);
			Silence(EvilDelinquentCorpseReactionClips);
			Silence(SenpaiRivalDeathReactionClips);
			Silence(RaibaruRivalDeathReactionClips);
			Silence(OsanaObstacleDeathReactionClips);
			Silence(Club1Clips);
			Silence(Club2Clips);
			Silence(Club3Clips);
			Silence(Club4Clips);
			Silence(Club5Clips);
			Silence(Club6Clips);
			Silence(Club8Clips);
			Silence(Club9Clips);
			Silence(Club10Clips);
			Silence(Club11Clips);
			Silence(Club12Clips);
			Silence(Club13Clips);
			Silence(Club7ClipsLight);
			Silence(Club7ClipsDark);
		}
		else
		{
			Club3Info = SubClub3Info;
			ClubGreetings[3] = ClubGreetings[13];
			ClubUnwelcomes[3] = ClubUnwelcomes[13];
			ClubKicks[3] = ClubKicks[13];
			ClubJoins[3] = ClubJoins[13];
			ClubAccepts[3] = ClubAccepts[13];
			ClubRefuses[3] = ClubRefuses[13];
			ClubRejoins[3] = ClubRejoins[13];
			ClubExclusives[3] = ClubExclusives[13];
			ClubGrudges[3] = ClubGrudges[13];
			ClubQuits[3] = ClubQuits[13];
			ClubConfirms[3] = ClubConfirms[13];
			ClubDenies[3] = ClubDenies[13];
			ClubFarewells[3] = ClubFarewells[13];
			ClubActivities[3] = ClubActivities[13];
			ClubEarlies[3] = ClubEarlies[13];
			ClubLates[3] = ClubLates[13];
			ClubYeses[3] = ClubYeses[13];
			ClubNoes[3] = ClubNoes[13];
			Club3Clips = SubClub3Clips;
			ClubGreetingClips[3] = ClubGreetingClips[13];
			ClubUnwelcomeClips[3] = ClubUnwelcomeClips[13];
			ClubKickClips[3] = ClubKickClips[13];
			ClubJoinClips[3] = ClubJoinClips[13];
			ClubAcceptClips[3] = ClubAcceptClips[13];
			ClubRefuseClips[3] = ClubRefuseClips[13];
			ClubRejoinClips[3] = ClubRejoinClips[13];
			ClubExclusiveClips[3] = ClubExclusiveClips[13];
			ClubGrudgeClips[3] = ClubGrudgeClips[13];
			ClubQuitClips[3] = ClubQuitClips[13];
			ClubConfirmClips[3] = ClubConfirmClips[13];
			ClubDenyClips[3] = ClubDenyClips[13];
			ClubFarewellClips[3] = ClubFarewellClips[13];
			ClubActivityClips[3] = ClubActivityClips[13];
			ClubEarlyClips[3] = ClubEarlyClips[13];
			ClubLateClips[3] = ClubLateClips[13];
			ClubYesClips[3] = ClubYesClips[13];
			ClubNoClips[3] = ClubNoClips[13];
		}
		SubtitleClipArrays = new SubtitleTypeAndAudioClipArrayDictionary
		{
			{
				SubtitleType.ClubAccept,
				new AudioClipArrayWrapper(ClubAcceptClips)
			},
			{
				SubtitleType.ClubActivity,
				new AudioClipArrayWrapper(ClubActivityClips)
			},
			{
				SubtitleType.ClubConfirm,
				new AudioClipArrayWrapper(ClubConfirmClips)
			},
			{
				SubtitleType.ClubDeny,
				new AudioClipArrayWrapper(ClubDenyClips)
			},
			{
				SubtitleType.ClubEarly,
				new AudioClipArrayWrapper(ClubEarlyClips)
			},
			{
				SubtitleType.ClubExclusive,
				new AudioClipArrayWrapper(ClubExclusiveClips)
			},
			{
				SubtitleType.ClubFarewell,
				new AudioClipArrayWrapper(ClubFarewellClips)
			},
			{
				SubtitleType.ClubGreeting,
				new AudioClipArrayWrapper(ClubGreetingClips)
			},
			{
				SubtitleType.ClubGrudge,
				new AudioClipArrayWrapper(ClubGrudgeClips)
			},
			{
				SubtitleType.ClubJoin,
				new AudioClipArrayWrapper(ClubJoinClips)
			},
			{
				SubtitleType.ClubKick,
				new AudioClipArrayWrapper(ClubKickClips)
			},
			{
				SubtitleType.ClubLate,
				new AudioClipArrayWrapper(ClubLateClips)
			},
			{
				SubtitleType.ClubNo,
				new AudioClipArrayWrapper(ClubNoClips)
			},
			{
				SubtitleType.ClubPlaceholderInfo,
				new AudioClipArrayWrapper(Club0Clips)
			},
			{
				SubtitleType.ClubCookingInfo,
				new AudioClipArrayWrapper(Club1Clips)
			},
			{
				SubtitleType.ClubDramaInfo,
				new AudioClipArrayWrapper(Club2Clips)
			},
			{
				SubtitleType.ClubOccultInfo,
				new AudioClipArrayWrapper(Club3Clips)
			},
			{
				SubtitleType.ClubArtInfo,
				new AudioClipArrayWrapper(Club4Clips)
			},
			{
				SubtitleType.ClubLightMusicInfo,
				new AudioClipArrayWrapper(Club5Clips)
			},
			{
				SubtitleType.ClubMartialArtsInfo,
				new AudioClipArrayWrapper(Club6Clips)
			},
			{
				SubtitleType.ClubPhotoInfoLight,
				new AudioClipArrayWrapper(Club7ClipsLight)
			},
			{
				SubtitleType.ClubPhotoInfoDark,
				new AudioClipArrayWrapper(Club7ClipsDark)
			},
			{
				SubtitleType.ClubScienceInfo,
				new AudioClipArrayWrapper(Club8Clips)
			},
			{
				SubtitleType.ClubSportsInfo,
				new AudioClipArrayWrapper(Club9Clips)
			},
			{
				SubtitleType.ClubGardenInfo,
				new AudioClipArrayWrapper(Club10Clips)
			},
			{
				SubtitleType.ClubGamingInfo,
				new AudioClipArrayWrapper(Club11Clips)
			},
			{
				SubtitleType.ClubDelinquentInfo,
				new AudioClipArrayWrapper(Club12Clips)
			},
			{
				SubtitleType.ClubNewspaperInfo,
				new AudioClipArrayWrapper(Club13Clips)
			},
			{
				SubtitleType.ClubQuit,
				new AudioClipArrayWrapper(ClubQuitClips)
			},
			{
				SubtitleType.ClubRefuse,
				new AudioClipArrayWrapper(ClubRefuseClips)
			},
			{
				SubtitleType.ClubRejoin,
				new AudioClipArrayWrapper(ClubRejoinClips)
			},
			{
				SubtitleType.ClubUnwelcome,
				new AudioClipArrayWrapper(ClubUnwelcomeClips)
			},
			{
				SubtitleType.ClubYes,
				new AudioClipArrayWrapper(ClubYesClips)
			},
			{
				SubtitleType.ClubPractice,
				new AudioClipArrayWrapper(ClubPracticeClips)
			},
			{
				SubtitleType.ClubPracticeYes,
				new AudioClipArrayWrapper(ClubPracticeYesClips)
			},
			{
				SubtitleType.ClubPracticeNo,
				new AudioClipArrayWrapper(ClubPracticeNoClips)
			},
			{
				SubtitleType.DrownReaction,
				new AudioClipArrayWrapper(DrownReactionClips)
			},
			{
				SubtitleType.EavesdropReaction,
				new AudioClipArrayWrapper(EavesdropClips)
			},
			{
				SubtitleType.RejectFood,
				new AudioClipArrayWrapper(FoodRejectionClips)
			},
			{
				SubtitleType.ViolenceReaction,
				new AudioClipArrayWrapper(ViolenceClips)
			},
			{
				SubtitleType.EventEavesdropReaction,
				new AudioClipArrayWrapper(EventEavesdropClips)
			},
			{
				SubtitleType.RivalEavesdropReaction,
				new AudioClipArrayWrapper(RivalEavesdropClips)
			},
			{
				SubtitleType.GrudgeWarning,
				new AudioClipArrayWrapper(GrudgeWarningClips)
			},
			{
				SubtitleType.LightSwitchReaction,
				new AudioClipArrayWrapper(LightSwitchClips)
			},
			{
				SubtitleType.LostPhone,
				new AudioClipArrayWrapper(LostPhoneClips)
			},
			{
				SubtitleType.NoteReaction,
				new AudioClipArrayWrapper(NoteReactionClips)
			},
			{
				SubtitleType.NoteReactionMale,
				new AudioClipArrayWrapper(NoteReactionMaleClips)
			},
			{
				SubtitleType.PickpocketReaction,
				new AudioClipArrayWrapper(PickpocketReactionClips)
			},
			{
				SubtitleType.RivalLostPhone,
				new AudioClipArrayWrapper(RivalLostPhoneClips)
			},
			{
				SubtitleType.RivalPickpocketReaction,
				new AudioClipArrayWrapper(RivalPickpocketReactionClips)
			},
			{
				SubtitleType.RivalSplashReaction,
				new AudioClipArrayWrapper(RivalSplashReactionClips)
			},
			{
				SubtitleType.SenpaiBloodReaction,
				new AudioClipArrayWrapper(SenpaiBloodReactionClips)
			},
			{
				SubtitleType.SenpaiInsanityReaction,
				new AudioClipArrayWrapper(SenpaiInsanityReactionClips)
			},
			{
				SubtitleType.SenpaiLewdReaction,
				new AudioClipArrayWrapper(SenpaiLewdReactionClips)
			},
			{
				SubtitleType.SenpaiMurderReaction,
				new AudioClipArrayWrapper(SenpaiMurderReactionClips)
			},
			{
				SubtitleType.SenpaiStalkingReaction,
				new AudioClipArrayWrapper(SenpaiStalkingReactionClips)
			},
			{
				SubtitleType.SenpaiWeaponReaction,
				new AudioClipArrayWrapper(SenpaiWeaponReactionClips)
			},
			{
				SubtitleType.SenpaiViolenceReaction,
				new AudioClipArrayWrapper(SenpaiViolenceReactionClips)
			},
			{
				SubtitleType.SenpaiRivalDeathReaction,
				new AudioClipArrayWrapper(SenpaiRivalDeathReactionClips)
			},
			{
				SubtitleType.RaibaruRivalDeathReaction,
				new AudioClipArrayWrapper(RaibaruRivalDeathReactionClips)
			},
			{
				SubtitleType.OsanaObstacleDeathReaction,
				new AudioClipArrayWrapper(OsanaObstacleDeathReactionClips)
			},
			{
				SubtitleType.SplashReaction,
				new AudioClipArrayWrapper(SplashReactionClips)
			},
			{
				SubtitleType.SplashReactionMale,
				new AudioClipArrayWrapper(SplashReactionMaleClips)
			},
			{
				SubtitleType.TutorialReaction,
				new AudioClipArrayWrapper(TutorialReactionClips)
			},
			{
				SubtitleType.TrespassReaction,
				new AudioClipArrayWrapper(TrespassReactionClips)
			},
			{
				SubtitleType.Task4Line,
				new AudioClipArrayWrapper(Task4Clips)
			},
			{
				SubtitleType.Task6Line,
				new AudioClipArrayWrapper(Task6Clips)
			},
			{
				SubtitleType.Task7Line,
				new AudioClipArrayWrapper(Task7Clips)
			},
			{
				SubtitleType.Task8Line,
				new AudioClipArrayWrapper(Task8Clips)
			},
			{
				SubtitleType.Task11Line,
				new AudioClipArrayWrapper(Task11Clips)
			},
			{
				SubtitleType.Task12Line,
				new AudioClipArrayWrapper(Task12Clips)
			},
			{
				SubtitleType.Task13Line,
				new AudioClipArrayWrapper(Task13Clips)
			},
			{
				SubtitleType.Task14Line,
				new AudioClipArrayWrapper(Task14Clips)
			},
			{
				SubtitleType.Task15Line,
				new AudioClipArrayWrapper(Task15Clips)
			},
			{
				SubtitleType.Task16Line,
				new AudioClipArrayWrapper(Task16Clips)
			},
			{
				SubtitleType.Task17Line,
				new AudioClipArrayWrapper(Task17Clips)
			},
			{
				SubtitleType.Task18Line,
				new AudioClipArrayWrapper(Task18Clips)
			},
			{
				SubtitleType.Task19Line,
				new AudioClipArrayWrapper(Task19Clips)
			},
			{
				SubtitleType.Task20Line,
				new AudioClipArrayWrapper(Task20Clips)
			},
			{
				SubtitleType.Task25Line,
				new AudioClipArrayWrapper(Task25Clips)
			},
			{
				SubtitleType.Task28Line,
				new AudioClipArrayWrapper(Task28Clips)
			},
			{
				SubtitleType.Task30Line,
				new AudioClipArrayWrapper(Task30Clips)
			},
			{
				SubtitleType.Task34Line,
				new AudioClipArrayWrapper(Task34Clips)
			},
			{
				SubtitleType.Task36Line,
				new AudioClipArrayWrapper(Task36Clips)
			},
			{
				SubtitleType.Task37Line,
				new AudioClipArrayWrapper(Task37Clips)
			},
			{
				SubtitleType.Task38Line,
				new AudioClipArrayWrapper(Task38Clips)
			},
			{
				SubtitleType.Task41Line,
				new AudioClipArrayWrapper(Task41Clips)
			},
			{
				SubtitleType.Task46Line,
				new AudioClipArrayWrapper(Task46Clips)
			},
			{
				SubtitleType.Task47Line,
				new AudioClipArrayWrapper(Task47Clips)
			},
			{
				SubtitleType.Task48Line,
				new AudioClipArrayWrapper(Task48Clips)
			},
			{
				SubtitleType.Task49Line,
				new AudioClipArrayWrapper(Task49Clips)
			},
			{
				SubtitleType.Task50Line,
				new AudioClipArrayWrapper(Task50Clips)
			},
			{
				SubtitleType.Task52Line,
				new AudioClipArrayWrapper(Task52Clips)
			},
			{
				SubtitleType.Task76Line,
				new AudioClipArrayWrapper(Task76Clips)
			},
			{
				SubtitleType.Task77Line,
				new AudioClipArrayWrapper(Task77Clips)
			},
			{
				SubtitleType.Task78Line,
				new AudioClipArrayWrapper(Task78Clips)
			},
			{
				SubtitleType.Task79Line,
				new AudioClipArrayWrapper(Task79Clips)
			},
			{
				SubtitleType.Task80Line,
				new AudioClipArrayWrapper(Task80Clips)
			},
			{
				SubtitleType.Task81Line,
				new AudioClipArrayWrapper(Task81Clips)
			},
			{
				SubtitleType.TaskGenericLineMale,
				new AudioClipArrayWrapper(TaskGenericMaleClips)
			},
			{
				SubtitleType.TaskGenericLineFemale,
				new AudioClipArrayWrapper(TaskGenericFemaleClips)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale1,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips1)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale2,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips2)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale3,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips3)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale4,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips4)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale5,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips5)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale6,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips6)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale7,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips7)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale8,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips8)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale9,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips9)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale10,
				new AudioClipArrayWrapper(TaskGenericEightiesMaleClips10)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale1,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips1)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale2,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips2)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale3,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips3)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale4,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips4)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale5,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips5)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale6,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips6)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale7,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips7)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale8,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips8)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale9,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips9)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale10,
				new AudioClipArrayWrapper(TaskGenericEightiesFemaleClips10)
			},
			{
				SubtitleType.TaskInquiry,
				new AudioClipArrayWrapper(TaskInquiryClips)
			},
			{
				SubtitleType.TaskRequirement,
				new AudioClipArrayWrapper(TaskRequirementClips)
			},
			{
				SubtitleType.TaskEightiesRequirement,
				new AudioClipArrayWrapper(TaskEightiesRequirementClips)
			},
			{
				SubtitleType.TheftReaction,
				new AudioClipArrayWrapper(TheftClips)
			},
			{
				SubtitleType.TeacherAttackReaction,
				new AudioClipArrayWrapper(TeacherAttackClips)
			},
			{
				SubtitleType.TeacherBloodHostile,
				new AudioClipArrayWrapper(TeacherBloodHostileClips)
			},
			{
				SubtitleType.TeacherBloodReaction,
				new AudioClipArrayWrapper(TeacherBloodClips)
			},
			{
				SubtitleType.TeacherCorpseInspection,
				new AudioClipArrayWrapper(TeacherInspectClips)
			},
			{
				SubtitleType.TeacherCorpseReaction,
				new AudioClipArrayWrapper(TeacherCorpseClips)
			},
			{
				SubtitleType.TeacherInsanityHostile,
				new AudioClipArrayWrapper(TeacherInsanityHostileClips)
			},
			{
				SubtitleType.TeacherInsanityReaction,
				new AudioClipArrayWrapper(TeacherInsanityClips)
			},
			{
				SubtitleType.TeacherLateReaction,
				new AudioClipArrayWrapper(TeacherLateClips)
			},
			{
				SubtitleType.TeacherLewdReaction,
				new AudioClipArrayWrapper(TeacherLewdClips)
			},
			{
				SubtitleType.TeacherMurderReaction,
				new AudioClipArrayWrapper(TeacherMurderClips)
			},
			{
				SubtitleType.TeacherPoliceReport,
				new AudioClipArrayWrapper(TeacherPoliceClips)
			},
			{
				SubtitleType.TeacherPrankReaction,
				new AudioClipArrayWrapper(TeacherPrankClips)
			},
			{
				SubtitleType.TeacherReportReaction,
				new AudioClipArrayWrapper(TeacherReportClips)
			},
			{
				SubtitleType.TeacherTheftReaction,
				new AudioClipArrayWrapper(TeacherTheftClips)
			},
			{
				SubtitleType.TeacherTrespassingReaction,
				new AudioClipArrayWrapper(TeacherTrespassClips)
			},
			{
				SubtitleType.TeacherWeaponHostile,
				new AudioClipArrayWrapper(TeacherWeaponHostileClips)
			},
			{
				SubtitleType.TeacherWeaponReaction,
				new AudioClipArrayWrapper(TeacherWeaponClips)
			},
			{
				SubtitleType.TeacherCoverUpHostile,
				new AudioClipArrayWrapper(TeacherCoverUpHostileClips)
			},
			{
				SubtitleType.YandereWhimper,
				new AudioClipArrayWrapper(YandereWhimperClips)
			},
			{
				SubtitleType.DelinquentAnnoy,
				new AudioClipArrayWrapper(DelinquentAnnoyClips)
			},
			{
				SubtitleType.DelinquentCase,
				new AudioClipArrayWrapper(DelinquentCaseClips)
			},
			{
				SubtitleType.DelinquentShove,
				new AudioClipArrayWrapper(DelinquentShoveClips)
			},
			{
				SubtitleType.DelinquentReaction,
				new AudioClipArrayWrapper(DelinquentReactionClips)
			},
			{
				SubtitleType.DelinquentWeaponReaction,
				new AudioClipArrayWrapper(DelinquentWeaponReactionClips)
			},
			{
				SubtitleType.DelinquentThreatened,
				new AudioClipArrayWrapper(DelinquentThreatenedClips)
			},
			{
				SubtitleType.DelinquentTaunt,
				new AudioClipArrayWrapper(DelinquentTauntClips)
			},
			{
				SubtitleType.DelinquentCalm,
				new AudioClipArrayWrapper(DelinquentCalmClips)
			},
			{
				SubtitleType.DelinquentFight,
				new AudioClipArrayWrapper(DelinquentFightClips)
			},
			{
				SubtitleType.DelinquentAvenge,
				new AudioClipArrayWrapper(DelinquentAvengeClips)
			},
			{
				SubtitleType.DelinquentWin,
				new AudioClipArrayWrapper(DelinquentWinClips)
			},
			{
				SubtitleType.DelinquentSurrender,
				new AudioClipArrayWrapper(DelinquentSurrenderClips)
			},
			{
				SubtitleType.DelinquentNoSurrender,
				new AudioClipArrayWrapper(DelinquentNoSurrenderClips)
			},
			{
				SubtitleType.DelinquentMurderReaction,
				new AudioClipArrayWrapper(DelinquentMurderReactionClips)
			},
			{
				SubtitleType.DelinquentCorpseReaction,
				new AudioClipArrayWrapper(DelinquentCorpseReactionClips)
			},
			{
				SubtitleType.DelinquentFriendCorpseReaction,
				new AudioClipArrayWrapper(DelinquentFriendCorpseReactionClips)
			},
			{
				SubtitleType.DelinquentResume,
				new AudioClipArrayWrapper(DelinquentResumeClips)
			},
			{
				SubtitleType.DelinquentFlee,
				new AudioClipArrayWrapper(DelinquentFleeClips)
			},
			{
				SubtitleType.DelinquentEnemyFlee,
				new AudioClipArrayWrapper(DelinquentEnemyFleeClips)
			},
			{
				SubtitleType.DelinquentFriendFlee,
				new AudioClipArrayWrapper(DelinquentFriendFleeClips)
			},
			{
				SubtitleType.DelinquentInjuredFlee,
				new AudioClipArrayWrapper(DelinquentInjuredFleeClips)
			},
			{
				SubtitleType.DelinquentCheer,
				new AudioClipArrayWrapper(DelinquentCheerClips)
			},
			{
				SubtitleType.DelinquentHmm,
				new AudioClipArrayWrapper(DelinquentHmmClips)
			},
			{
				SubtitleType.DelinquentGrudge,
				new AudioClipArrayWrapper(DelinquentGrudgeClips)
			},
			{
				SubtitleType.Dismissive,
				new AudioClipArrayWrapper(DismissiveClips)
			},
			{
				SubtitleType.EvilDelinquentCorpseReaction,
				new AudioClipArrayWrapper(EvilDelinquentCorpseReactionClips)
			},
			{
				SubtitleType.Eulogy,
				new AudioClipArrayWrapper(EulogyClips)
			},
			{
				SubtitleType.GasWarning,
				new AudioClipArrayWrapper(GasWarningClips)
			},
			{
				SubtitleType.StudentStay,
				new AudioClipArrayWrapper(StudentStayClips)
			},
			{
				SubtitleType.StrictReport,
				new AudioClipArrayWrapper(StrictReportClips)
			},
			{
				SubtitleType.CasualReport,
				new AudioClipArrayWrapper(CasualReportClips)
			},
			{
				SubtitleType.GraceReport,
				new AudioClipArrayWrapper(GraceReportClips)
			},
			{
				SubtitleType.EdgyReport,
				new AudioClipArrayWrapper(EdgyReportClips)
			},
			{
				SubtitleType.BreakingUp,
				new AudioClipArrayWrapper(BreakUpClips)
			},
			{
				SubtitleType.Chasing,
				new AudioClipArrayWrapper(ChaseClips)
			},
			{
				SubtitleType.Shoving,
				new AudioClipArrayWrapper(ShoveClips)
			},
			{
				SubtitleType.Spraying,
				new AudioClipArrayWrapper(SprayClips)
			},
			{
				SubtitleType.CouncilCorpseReaction,
				new AudioClipArrayWrapper(CouncilCorpseClips)
			},
			{
				SubtitleType.CouncilToCounselor,
				new AudioClipArrayWrapper(CouncilCounselorClips)
			},
			{
				SubtitleType.HmmReaction,
				new AudioClipArrayWrapper(HmmClips)
			},
			{
				SubtitleType.ObstacleMurderReaction,
				new AudioClipArrayWrapper(ObstacleMurderReactionClips)
			},
			{
				SubtitleType.ObstaclePoisonReaction,
				new AudioClipArrayWrapper(ObstaclePoisonReactionClips)
			}
		};
	}

	private void Start()
	{
		Label.text = string.Empty;
	}

	private string GetRandomString(string[] strings)
	{
		return strings[Random.Range(0, strings.Length)];
	}

	public void UpdateLabel(SubtitleType subtitleType, int ID, float Duration)
	{
		if (!Jukebox.Yandere.Talking && subtitleType == PreviousSubtitle && Timer > 0f)
		{
			return;
		}
		switch (subtitleType)
		{
		case SubtitleType.WeaponAndBloodAndInsanityReaction:
			Label.text = GetRandomString(WeaponBloodInsanityReactions);
			break;
		case SubtitleType.WeaponAndBloodReaction:
			Label.text = GetRandomString(WeaponBloodReactions);
			break;
		case SubtitleType.WeaponAndInsanityReaction:
			Label.text = GetRandomString(WeaponInsanityReactions);
			break;
		case SubtitleType.BloodAndInsanityReaction:
			Label.text = GetRandomString(BloodInsanityReactions);
			break;
		case SubtitleType.WeaponReaction:
			switch (ID)
			{
			case 1:
				Label.text = GetRandomString(KnifeReactions);
				break;
			case 2:
				Label.text = GetRandomString(KatanaReactions);
				break;
			case 3:
				Label.text = GetRandomString(SyringeReactions);
				break;
			case 4:
				Label.text = GetRandomString(ScissorsReactions);
				break;
			case 7:
				Label.text = GetRandomString(SawReactions);
				break;
			case 8:
				if (StudentID < 31 || StudentID > 35)
				{
					Label.text = RitualReactions[0];
				}
				else
				{
					Label.text = RitualReactions[1];
				}
				break;
			case 9:
				Label.text = GetRandomString(BatReactions);
				break;
			case 10:
				Label.text = GetRandomString(ShovelReactions);
				break;
			case 11:
			case 14:
			case 16:
			case 17:
			case 22:
				Label.text = GetRandomString(PropReactions);
				break;
			case 12:
				Label.text = GetRandomString(DumbbellReactions);
				break;
			case 13:
			case 15:
				Label.text = GetRandomString(AxeReactions);
				break;
			case 18:
			case 19:
			case 20:
			case 21:
				Label.text = GetRandomString(DelinkWeaponReactions);
				break;
			default:
				switch (ID)
				{
				case 23:
					Label.text = GetRandomString(ExtinguisherReactions);
					break;
				case 24:
					Label.text = GetRandomString(WrenchReactions);
					break;
				case 25:
					Label.text = GetRandomString(GuitarReactions);
					break;
				case 28:
					Label.text = GetRandomString(ScrapReactions);
					break;
				}
				break;
			}
			break;
		case SubtitleType.BloodReaction:
			Label.text = GetRandomString(BloodReactions);
			break;
		case SubtitleType.BloodPoolReaction:
			Label.text = BloodPoolReactions[ID];
			break;
		case SubtitleType.BloodyWeaponReaction:
			Label.text = BloodyWeaponReactions[ID];
			break;
		case SubtitleType.LimbReaction:
			Label.text = LimbReactions[ID];
			break;
		case SubtitleType.WetBloodReaction:
			Label.text = GetRandomString(WetBloodReactions);
			break;
		case SubtitleType.InsanityReaction:
			Label.text = GetRandomString(InsanityReactions);
			break;
		case SubtitleType.LewdReaction:
			Label.text = GetRandomString(LewdReactions);
			break;
		case SubtitleType.SuspiciousReaction:
			Label.text = SuspiciousReactions[ID];
			break;
		case SubtitleType.PoisonReaction:
			Label.text = PoisonReactions[ID];
			break;
		case SubtitleType.PrankReaction:
			Label.text = GetRandomString(PrankReactions);
			break;
		case SubtitleType.InterruptionReaction:
			Label.text = InterruptReactions[ID];
			break;
		case SubtitleType.IntrusionReaction:
			Label.text = GetRandomString(IntrusionReactions);
			break;
		case SubtitleType.TheftReaction:
			Label.text = TheftReactions[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.KilledMood:
			Label.text = GetRandomString(KilledMoods);
			break;
		case SubtitleType.SendToLocker:
			Label.text = SendToLockers[ID];
			break;
		case SubtitleType.NoteReaction:
			Label.text = NoteReactions[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.NoteReactionMale:
			Label.text = NoteReactionsMale[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.OfferSnack:
			Label.text = OfferSnacks[ID];
			break;
		case SubtitleType.AcceptFood:
			Label.text = GetRandomString(FoodAccepts);
			break;
		case SubtitleType.RejectFood:
			Label.text = FoodRejects[ID];
			if (Jukebox.Yandere.TargetStudent.Male)
			{
				PlayVoice(subtitleType, ID);
			}
			break;
		case SubtitleType.EavesdropReaction:
			RandomID = Random.Range(0, EavesdropReactions.Length);
			Label.text = EavesdropReactions[RandomID];
			break;
		case SubtitleType.ViolenceReaction:
			RandomID = Random.Range(0, ViolenceReactions.Length);
			Label.text = ViolenceReactions[RandomID];
			break;
		case SubtitleType.EventEavesdropReaction:
			RandomID = Random.Range(0, EventEavesdropReactions.Length);
			Label.text = EventEavesdropReactions[RandomID];
			break;
		case SubtitleType.RivalEavesdropReaction:
			Debug.Log("Rival eavesdrop reaction. ID is: " + ID);
			Label.text = RivalEavesdropReactions[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.PickpocketReaction:
			RandomID = Random.Range(0, PickpocketReactions.Length);
			Label.text = PickpocketReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.PickpocketApology:
			RandomID = Random.Range(0, PickpocketApologies.Length);
			Label.text = PickpocketApologies[RandomID];
			break;
		case SubtitleType.CleaningApology:
			RandomID = Random.Range(0, CleaningApologies.Length);
			Label.text = CleaningApologies[RandomID];
			break;
		case SubtitleType.PoisonApology:
			RandomID = Random.Range(0, PoisonApologies.Length);
			Label.text = PoisonApologies[RandomID];
			break;
		case SubtitleType.HoldingBloodyClothingApology:
			RandomID = Random.Range(0, HoldingBloodyClothingApologies.Length);
			Label.text = HoldingBloodyClothingApologies[RandomID];
			break;
		case SubtitleType.TrespassApology:
			RandomID = Random.Range(0, TrespassApologies.Length);
			Label.text = TrespassApologies[RandomID];
			break;
		case SubtitleType.RivalPickpocketReaction:
			RandomID = Random.Range(0, RivalPickpocketReactions.Length);
			Label.text = RivalPickpocketReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DrownReaction:
			Label.text = DrownReactions[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.HmmReaction:
			if (Label.text == string.Empty)
			{
				RandomID = Random.Range(0, HmmReactions.Length);
				Label.text = HmmReactions[RandomID];
				PlayVoice(subtitleType, ID);
			}
			break;
		case SubtitleType.HoldingBloodyClothingReaction:
			if (Label.text == string.Empty)
			{
				RandomID = Random.Range(0, HoldingBloodyClothingReactions.Length);
				Label.text = HoldingBloodyClothingReactions[RandomID];
			}
			break;
		case SubtitleType.ParanoidReaction:
			if (Label.text == string.Empty)
			{
				RandomID = Random.Range(0, ParanoidReactions.Length);
				Label.text = ParanoidReactions[RandomID];
			}
			break;
		case SubtitleType.TeacherWeaponReaction:
			RandomID = Random.Range(0, TeacherWeaponReactions.Length);
			Label.text = TeacherWeaponReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherBloodReaction:
			RandomID = Random.Range(0, TeacherBloodReactions.Length);
			Label.text = TeacherBloodReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherInsanityReaction:
			RandomID = Random.Range(0, TeacherInsanityReactions.Length);
			Label.text = TeacherInsanityReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherWeaponHostile:
			RandomID = Random.Range(0, TeacherWeaponHostiles.Length);
			Label.text = TeacherWeaponHostiles[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherBloodHostile:
			RandomID = Random.Range(0, TeacherBloodHostiles.Length);
			Label.text = TeacherBloodHostiles[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherInsanityHostile:
			RandomID = Random.Range(0, TeacherInsanityHostiles.Length);
			Label.text = TeacherInsanityHostiles[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherCoverUpHostile:
			RandomID = Random.Range(0, TeacherCoverUpHostiles.Length);
			Label.text = TeacherCoverUpHostiles[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherLewdReaction:
			RandomID = Random.Range(0, TeacherLewdReactions.Length);
			Label.text = TeacherLewdReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherTrespassingReaction:
			RandomID = Random.Range(0, TeacherTrespassReactions.Length);
			Label.text = TeacherTrespassReactions[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.TeacherLateReaction:
			RandomID = Random.Range(0, TeacherLateReactions.Length);
			Label.text = TeacherLateReactions[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.TeacherReportReaction:
			Label.text = TeacherReportReactions[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.TeacherCorpseReaction:
			RandomID = Random.Range(0, TeacherCorpseReactions.Length);
			Label.text = TeacherCorpseReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherCorpseInspection:
			Label.text = TeacherCorpseInspections[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.TeacherPoliceReport:
			Label.text = TeacherPoliceReports[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.TeacherAttackReaction:
			RandomID = Random.Range(0, TeacherAttackReactions.Length);
			Label.text = TeacherAttackReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherMurderReaction:
			Label.text = TeacherMurderReactions[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.TeacherPrankReaction:
			RandomID = Random.Range(0, TeacherPrankReactions.Length);
			Label.text = TeacherPrankReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TeacherTheftReaction:
			RandomID = Random.Range(0, TeacherTheftReactions.Length);
			Label.text = TeacherTheftReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.TutorialReaction:
			RandomID = Random.Range(0, TutorialReactions.Length);
			Label.text = TutorialReactions[RandomID];
			PlayVoice(subtitleType, 1);
			break;
		case SubtitleType.TrespassReaction:
			RandomID = Random.Range(0, TrespassReactions.Length);
			Label.text = TrespassReactions[RandomID];
			PlayVoice(subtitleType, 1);
			break;
		case SubtitleType.DelinquentAnnoy:
			Label.text = DelinquentAnnoys[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.DelinquentCase:
			Label.text = DelinquentCases[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.DelinquentShove:
			RandomID = Random.Range(0, DelinquentShoves.Length);
			Label.text = DelinquentShoves[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentReaction:
			RandomID = Random.Range(0, DelinquentReactions.Length);
			Label.text = DelinquentReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentWeaponReaction:
			RandomID = Random.Range(0, DelinquentWeaponReactions.Length);
			Label.text = DelinquentWeaponReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentThreatened:
			RandomID = Random.Range(0, DelinquentThreateneds.Length);
			Label.text = DelinquentThreateneds[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentTaunt:
			RandomID = Random.Range(0, DelinquentTaunts.Length);
			Label.text = DelinquentTaunts[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentCalm:
			RandomID = Random.Range(0, DelinquentCalms.Length);
			Label.text = DelinquentCalms[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentFight:
			RandomID = Random.Range(0, DelinquentFights.Length);
			Label.text = DelinquentFights[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentAvenge:
			RandomID = Random.Range(0, DelinquentAvenges.Length);
			Label.text = DelinquentAvenges[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentWin:
			RandomID = Random.Range(0, DelinquentWins.Length);
			Label.text = DelinquentWins[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentSurrender:
			RandomID = Random.Range(0, DelinquentSurrenders.Length);
			Label.text = DelinquentSurrenders[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentNoSurrender:
			RandomID = Random.Range(0, DelinquentNoSurrenders.Length);
			Label.text = DelinquentNoSurrenders[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentMurderReaction:
			RandomID = Random.Range(0, DelinquentMurderReactions.Length);
			Label.text = DelinquentMurderReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentCorpseReaction:
			RandomID = Random.Range(0, DelinquentCorpseReactions.Length);
			Label.text = DelinquentCorpseReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentFriendCorpseReaction:
			RandomID = Random.Range(0, DelinquentFriendCorpseReactions.Length);
			Label.text = DelinquentFriendCorpseReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentResume:
			RandomID = Random.Range(0, DelinquentResumes.Length);
			Label.text = DelinquentResumes[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentFlee:
			RandomID = Random.Range(0, DelinquentFlees.Length);
			Label.text = DelinquentFlees[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentEnemyFlee:
			RandomID = Random.Range(0, DelinquentEnemyFlees.Length);
			Label.text = DelinquentEnemyFlees[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentFriendFlee:
			RandomID = Random.Range(0, DelinquentFriendFlees.Length);
			Label.text = DelinquentFriendFlees[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentInjuredFlee:
			RandomID = Random.Range(0, DelinquentInjuredFlees.Length);
			Label.text = DelinquentInjuredFlees[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentCheer:
			RandomID = Random.Range(0, DelinquentCheers.Length);
			Label.text = DelinquentCheers[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.DelinquentHmm:
			if (Label.text == string.Empty)
			{
				RandomID = Random.Range(0, DelinquentHmms.Length);
				Label.text = DelinquentHmms[RandomID];
				PlayVoice(subtitleType, RandomID);
			}
			break;
		case SubtitleType.DelinquentGrudge:
			RandomID = Random.Range(0, DelinquentGrudges.Length);
			Label.text = DelinquentGrudges[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.Dismissive:
			Label.text = Dismissives[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.LostPhone:
			Label.text = LostPhones[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.RivalLostPhone:
			Label.text = RivalLostPhones[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.MurderReaction:
			Label.text = GetRandomString(MurderReactions);
			break;
		case SubtitleType.CorpseReaction:
			Label.text = CorpseReactions[ID];
			break;
		case SubtitleType.CouncilCorpseReaction:
			Label.text = CouncilCorpseReactions[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.CouncilToCounselor:
			Label.text = CouncilToCounselors[ID];
			PlayVoice(subtitleType, ID);
			break;
		case SubtitleType.LonerMurderReaction:
			Label.text = GetRandomString(LonerMurderReactions);
			break;
		case SubtitleType.LonerCorpseReaction:
			Label.text = GetRandomString(LonerCorpseReactions);
			break;
		case SubtitleType.PetBloodReport:
			Label.text = PetBloodReports[ID];
			break;
		case SubtitleType.PetBloodReaction:
			Label.text = GetRandomString(PetBloodReactions);
			break;
		case SubtitleType.PetCorpseReport:
			Label.text = PetCorpseReports[ID];
			break;
		case SubtitleType.PetCorpseReaction:
			Label.text = GetRandomString(PetCorpseReactions);
			break;
		case SubtitleType.PetLimbReport:
			Label.text = PetLimbReports[ID];
			break;
		case SubtitleType.PetLimbReaction:
			Label.text = GetRandomString(PetLimbReactions);
			break;
		case SubtitleType.PetMurderReport:
			Label.text = PetMurderReports[ID];
			break;
		case SubtitleType.PetMurderReaction:
			Label.text = GetRandomString(PetMurderReactions);
			break;
		case SubtitleType.PetWeaponReport:
			Label.text = PetWeaponReports[ID];
			break;
		case SubtitleType.PetWeaponReaction:
			Label.text = PetWeaponReactions[ID];
			break;
		case SubtitleType.PetBloodyWeaponReport:
			Label.text = PetBloodyWeaponReports[ID];
			break;
		case SubtitleType.PetBloodyWeaponReaction:
			Label.text = GetRandomString(PetBloodyWeaponReactions);
			break;
		case SubtitleType.EvilCorpseReaction:
			Label.text = GetRandomString(EvilCorpseReactions);
			break;
		case SubtitleType.EvilDelinquentCorpseReaction:
			RandomID = Random.Range(0, EvilDelinquentCorpseReactions.Length);
			Label.text = EvilDelinquentCorpseReactions[RandomID];
			PlayVoice(subtitleType, RandomID);
			break;
		case SubtitleType.HeroMurderReaction:
			Label.text = GetRandomString(HeroMurderReactions);
			break;
		case SubtitleType.CowardMurderReaction:
			Label.text = GetRandomString(CowardMurderReactions);
			break;
		case SubtitleType.EvilMurderReaction:
			Label.text = GetRandomString(EvilMurderReactions);
			break;
		case SubtitleType.SocialDeathReaction:
			Label.text = GetRandomString(SocialDeathReactions);
			break;
		case SubtitleType.LovestruckDeathReaction:
			Label.text = LovestruckDeathReactions[ID];
			break;
		case SubtitleType.LovestruckMurderReport:
			Label.text = LovestruckMurderReports[ID];
			break;
		case SubtitleType.LovestruckCorpseReport:
			Label.text = LovestruckCorpseReports[ID];
			break;
		case SubtitleType.SocialReport:
			Label.text = GetRandomString(SocialReports);
			break;
		case SubtitleType.SocialFear:
			Label.text = GetRandomString(SocialFears);
			break;
		case SubtitleType.SocialTerror:
			Label.text = GetRandomString(SocialTerrors);
			break;
		case SubtitleType.RepeatReaction:
			Label.text = GetRandomString(RepeatReactions);
			break;
		case SubtitleType.Greeting:
			Label.text = GetRandomString(Greetings);
			break;
		case SubtitleType.PlayerFarewell:
			Label.text = GetRandomString(PlayerFarewells);
			break;
		case SubtitleType.StudentFarewell:
			Label.text = GetRandomString(StudentFarewells);
			break;
		case SubtitleType.InsanityApology:
			Label.text = GetRandomString(InsanityApologies);
			break;
		case SubtitleType.WeaponAndBloodApology:
			Label.text = GetRandomString(WeaponBloodApologies);
			break;
		case SubtitleType.WeaponApology:
			Label.text = GetRandomString(WeaponApologies);
			break;
		case SubtitleType.BloodApology:
			Label.text = GetRandomString(BloodApologies);
			break;
		case SubtitleType.LewdApology:
			Label.text = GetRandomString(LewdApologies);
			break;
		case SubtitleType.SuspiciousApology:
			Label.text = GetRandomString(SuspiciousApologies);
			break;
		case SubtitleType.EavesdropApology:
			Label.text = GetRandomString(EavesdropApologies);
			break;
		case SubtitleType.ViolenceApology:
			Label.text = GetRandomString(ViolenceApologies);
			break;
		case SubtitleType.TheftApology:
			Label.text = GetRandomString(TheftApologies);
			break;
		case SubtitleType.EventApology:
			Label.text = GetRandomString(EventApologies);
			break;
		case SubtitleType.ClassApology:
			Label.text = GetRandomString(ClassApologies);
			break;
		case SubtitleType.AccidentApology:
			Label.text = GetRandomString(AccidentApologies);
			break;
		case SubtitleType.SadApology:
			Label.text = GetRandomString(SadApologies);
			break;
		case SubtitleType.TutorialApology:
			Label.text = GetRandomString(TutorialApologies);
			PlayVoice(SubtitleType.TutorialReaction, 2);
			break;
		default:
			if (subtitleType == SubtitleType.TrespassApology)
			{
				Label.text = GetRandomString(TrespassApologies);
				break;
			}
			if (subtitleType == SubtitleType.Dismissive)
			{
				Label.text = Dismissives[ID];
				break;
			}
			if (subtitleType == SubtitleType.Forgiving)
			{
				Label.text = GetRandomString(Forgivings);
				break;
			}
			if (subtitleType == SubtitleType.ForgivingAccident)
			{
				Label.text = GetRandomString(AccidentForgivings);
				break;
			}
			if (subtitleType == SubtitleType.ForgivingInsanity)
			{
				Label.text = GetRandomString(InsanityForgivings);
				break;
			}
			if (subtitleType == SubtitleType.ForgivingTrespass)
			{
				Label.text = GetRandomString(TrespassForgivings);
				break;
			}
			if (subtitleType == SubtitleType.Impatience)
			{
				Label.text = Impatiences[ID];
				break;
			}
			if (subtitleType == SubtitleType.PlayerCompliment)
			{
				Label.text = GetRandomString(PlayerCompliments);
				break;
			}
			if (subtitleType == SubtitleType.StudentHighCompliment)
			{
				Label.text = GetRandomString(StudentHighCompliments);
				break;
			}
			if (subtitleType == SubtitleType.StudentMidCompliment)
			{
				Label.text = GetRandomString(StudentMidCompliments);
				break;
			}
			if (subtitleType == SubtitleType.StudentLowCompliment)
			{
				Label.text = GetRandomString(StudentLowCompliments);
				break;
			}
			if (subtitleType == SubtitleType.PlayerGossip)
			{
				Label.text = GetRandomString(PlayerGossip);
				break;
			}
			if (subtitleType == SubtitleType.StudentGossip)
			{
				Label.text = GetRandomString(StudentGossip);
				break;
			}
			if (subtitleType == SubtitleType.PlayerFollow)
			{
				Label.text = PlayerFollows[ID];
				break;
			}
			if (subtitleType == SubtitleType.StudentFollow)
			{
				Label.text = StudentFollows[ID];
				break;
			}
			if (subtitleType == SubtitleType.PlayerLeave)
			{
				Label.text = PlayerLeaves[ID];
				break;
			}
			if (subtitleType == SubtitleType.StudentLeave)
			{
				Label.text = StudentLeaves[ID];
				break;
			}
			if (subtitleType == SubtitleType.StudentStay)
			{
				Label.text = StudentStays[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.PlayerDistract)
			{
				Label.text = PlayerDistracts[ID];
				break;
			}
			if (subtitleType == SubtitleType.StudentDistract)
			{
				Label.text = StudentDistracts[ID];
				break;
			}
			if (subtitleType == SubtitleType.StudentDistractRefuse)
			{
				Label.text = GetRandomString(StudentDistractRefuses);
				break;
			}
			if (subtitleType == SubtitleType.StudentDistractBullyRefuse)
			{
				Label.text = GetRandomString(StudentDistractBullyRefuses);
				break;
			}
			if (subtitleType == SubtitleType.StopFollowApology)
			{
				Label.text = StopFollowApologies[ID];
				break;
			}
			if (subtitleType == SubtitleType.GrudgeWarning)
			{
				Label.text = GetRandomString(GrudgeWarnings);
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.GrudgeRefusal)
			{
				Label.text = GetRandomString(GrudgeRefusals);
				break;
			}
			if (subtitleType == SubtitleType.CowardGrudge)
			{
				Label.text = GetRandomString(CowardGrudges);
				break;
			}
			if (subtitleType == SubtitleType.EvilGrudge)
			{
				Label.text = GetRandomString(EvilGrudges);
				break;
			}
			if (subtitleType == SubtitleType.PlayerLove)
			{
				Label.text = PlayerLove[ID];
				break;
			}
			if (subtitleType == SubtitleType.SuitorLove)
			{
				Label.text = SuitorLove[ID];
				break;
			}
			if (subtitleType == SubtitleType.RivalLove)
			{
				Label.text = RivalLove[ID];
				break;
			}
			if (subtitleType == SubtitleType.RequestMedicine)
			{
				Label.text = RequestMedicines[ID];
				break;
			}
			if (subtitleType == SubtitleType.ReturningWeapon)
			{
				Label.text = ReturningWeapons[ID];
				break;
			}
			if (subtitleType == SubtitleType.Dying)
			{
				Label.text = GetRandomString(Deaths);
				break;
			}
			if (subtitleType == SubtitleType.SenpaiInsanityReaction)
			{
				RandomID = Random.Range(0, SenpaiInsanityReactions.Length);
				Label.text = SenpaiInsanityReactions[RandomID];
				PlayVoice(subtitleType, RandomID);
				break;
			}
			if (subtitleType == SubtitleType.SenpaiWeaponReaction)
			{
				RandomID = Random.Range(0, SenpaiWeaponReactions.Length);
				Label.text = SenpaiWeaponReactions[RandomID];
				PlayVoice(subtitleType, RandomID);
				break;
			}
			if (subtitleType == SubtitleType.SenpaiBloodReaction)
			{
				RandomID = Random.Range(0, SenpaiBloodReactions.Length);
				Label.text = SenpaiBloodReactions[RandomID];
				PlayVoice(subtitleType, RandomID);
				break;
			}
			if (subtitleType == SubtitleType.SenpaiLewdReaction)
			{
				RandomID = Random.Range(0, SenpaiLewdReactions.Length);
				Label.text = SenpaiLewdReactions[RandomID];
				PlayVoice(subtitleType, RandomID);
				break;
			}
			if (subtitleType == SubtitleType.SenpaiStalkingReaction)
			{
				Label.text = SenpaiStalkingReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.SenpaiMurderReaction)
			{
				Label.text = SenpaiMurderReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.SenpaiCorpseReaction)
			{
				Label.text = GetRandomString(SenpaiCorpseReactions);
				break;
			}
			if (subtitleType == SubtitleType.SenpaiViolenceReaction)
			{
				RandomID = Random.Range(0, SenpaiViolenceReactions.Length);
				Label.text = SenpaiViolenceReactions[RandomID];
				PlayVoice(subtitleType, RandomID);
				break;
			}
			if (subtitleType == SubtitleType.SenpaiRivalDeathReaction)
			{
				Label.text = SenpaiRivalDeathReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.RaibaruRivalDeathReaction)
			{
				Label.text = RaibaruRivalDeathReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.OsanaObstacleDeathReaction)
			{
				Label.text = OsanaObstacleDeathReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.YandereWhimper)
			{
				RandomID = Random.Range(0, YandereWhimpers.Length);
				Label.text = YandereWhimpers[RandomID];
				PlayVoice(subtitleType, RandomID);
				break;
			}
			if (subtitleType == SubtitleType.StudentMurderReport)
			{
				Label.text = StudentMurderReports[ID];
				break;
			}
			if (subtitleType == SubtitleType.SplashReaction)
			{
				Label.text = SplashReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.SplashReactionMale)
			{
				Label.text = SplashReactionsMale[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.RivalSplashReaction)
			{
				Label.text = RivalSplashReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.LightSwitchReaction)
			{
				Label.text = LightSwitchReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			}
			if (subtitleType == SubtitleType.PhotoAnnoyance)
			{
				while (RandomID == PreviousRandom)
				{
					RandomID = Random.Range(0, PhotoAnnoyances.Length);
				}
				PreviousRandom = RandomID;
				Label.text = PhotoAnnoyances[RandomID];
				break;
			}
			switch (subtitleType)
			{
			case SubtitleType.Task4Line:
				Label.text = Task4Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task6Line:
				Label.text = Task6Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task7Line:
				Label.text = Task7Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task8Line:
				Label.text = Task8Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task11Line:
				Label.text = Task11Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task12Line:
				Label.text = Task12Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task13Line:
				Label.text = Task13Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task14Line:
				Label.text = Task14Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task15Line:
				Label.text = Task15Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task16Line:
				Label.text = Task16Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task17Line:
				Label.text = Task17Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task18Line:
				Label.text = Task18Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task19Line:
				Label.text = Task19Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task20Line:
				Label.text = Task20Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task25Line:
				Label.text = Task25Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task28Line:
				Label.text = Task28Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task30Line:
				Label.text = Task30Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task32Line:
				Label.text = Task32Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task33Line:
				Label.text = Task33Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task34Line:
				Label.text = Task34Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task36Line:
				Label.text = Task36Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task37Line:
				Label.text = Task37Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task38Line:
				Label.text = Task38Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task41Line:
				Label.text = Task41Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task46Line:
				Label.text = Task46Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task47Line:
				Label.text = Task47Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task48Line:
				Label.text = Task48Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task49Line:
				Label.text = Task49Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task50Line:
				Label.text = Task50Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task52Line:
				Label.text = Task52Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task76Line:
				Label.text = Task76Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task77Line:
				Label.text = Task77Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task78Line:
				Label.text = Task78Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task79Line:
				Label.text = Task79Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task80Line:
				Label.text = Task80Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Task81Line:
				Label.text = Task81Lines[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.TaskGenericLine:
				Label.text = "(PLACEHOLDER TASK - WILL BE REPLACED IN FUTURE)\n" + TaskGenericLines[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericLineMale, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericLineFemale, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine1:
				Label.text = TaskGenericEightiesLines1[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale1, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale1, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine2:
				Label.text = TaskGenericEightiesLines2[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale2, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale2, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine3:
				Label.text = TaskGenericEightiesLines3[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale3, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale3, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine4:
				Label.text = TaskGenericEightiesLines4[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale4, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale4, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine5:
				Label.text = TaskGenericEightiesLines5[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale5, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale5, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine6:
				Label.text = TaskGenericEightiesLines6[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale6, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale6, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine7:
				Label.text = TaskGenericEightiesLines7[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale7, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale7, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine8:
				Label.text = TaskGenericEightiesLines8[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale8, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale8, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine9:
				Label.text = TaskGenericEightiesLines9[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale9, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale9, ID);
				}
				break;
			case SubtitleType.TaskGenericEightiesLine10:
				Label.text = TaskGenericEightiesLines10[ID];
				if (Yandere.GetComponent<YandereScript>().TargetStudent.Male)
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineMale10, ID);
				}
				else
				{
					PlayVoice(SubtitleType.TaskGenericEightiesLineFemale10, ID);
				}
				break;
			case SubtitleType.TaskInquiry:
				Label.text = TaskInquiries[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.TaskRequirement:
				Label.text = TaskRequirements[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.TaskEightiesRequirement:
				Label.text = TaskEightiesRequirements[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubGreeting:
				Label.text = ClubGreetings[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubUnwelcome:
				Label.text = ClubUnwelcomes[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubKick:
				Label.text = ClubKicks[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubPractice:
				Label.text = ClubPractices[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubPracticeYes:
				Label.text = ClubPracticeYeses[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubPracticeNo:
				Label.text = ClubPracticeNoes[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubPlaceholderInfo:
				Label.text = Club0Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubCookingInfo:
				Label.text = Club1Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubDramaInfo:
				Label.text = Club2Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubOccultInfo:
				Label.text = Club3Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubArtInfo:
				Label.text = Club4Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubLightMusicInfo:
				Label.text = Club5Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubMartialArtsInfo:
				Label.text = Club6Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubPhotoInfoLight:
				Label.text = Club7InfoLight[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubPhotoInfoDark:
				Label.text = Club7InfoDark[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubScienceInfo:
				Label.text = Club8Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubSportsInfo:
				Label.text = Club9Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubGardenInfo:
				Label.text = Club10Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubGamingInfo:
				Label.text = Club11Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubDelinquentInfo:
				Label.text = Club12Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubNewspaperInfo:
				Label.text = Club13Info[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubJoin:
				Label.text = ClubJoins[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubAccept:
				Label.text = ClubAccepts[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubRefuse:
				Label.text = ClubRefuses[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubRejoin:
				Label.text = ClubRejoins[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubExclusive:
				Label.text = ClubExclusives[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubGrudge:
				Label.text = ClubGrudges[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubQuit:
				Label.text = ClubQuits[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubConfirm:
				Label.text = ClubConfirms[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubDeny:
				Label.text = ClubDenies[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubFarewell:
				Label.text = ClubFarewells[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubActivity:
				Label.text = ClubActivities[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubEarly:
				Label.text = ClubEarlies[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubLate:
				Label.text = ClubLates[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubYes:
				Label.text = ClubYeses[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ClubNo:
				Label.text = ClubNoes[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.InfoNotice:
				Label.text = InfoNotice;
				break;
			case SubtitleType.StrictReport:
				Label.text = StrictReport[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.CasualReport:
				Label.text = CasualReport[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.GraceReport:
				Label.text = GraceReport[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.EdgyReport:
				Label.text = EdgyReport[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.BreakingUp:
				Label.text = BreakingUp[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Shoving:
				Label.text = Shoving[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Spraying:
				Label.text = Spraying[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Chasing:
				Label.text = Chasing[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Eulogy:
				Label.text = Eulogies[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.AskForHelp:
				Label.text = AskForHelps[ID];
				break;
			case SubtitleType.GiveHelp:
				Label.text = GiveHelps[ID];
				break;
			case SubtitleType.RejectHelp:
				Label.text = RejectHelps[ID];
				break;
			case SubtitleType.ObstacleMurderReaction:
				Label.text = ObstacleMurderReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.ObstaclePoisonReaction:
				Label.text = ObstaclePoisonReactions[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.GasWarning:
				Label.text = GasWarnings[ID];
				PlayVoice(subtitleType, ID);
				break;
			case SubtitleType.Custom:
				Label.text = CustomText;
				break;
			}
			break;
		}
		PreviousSubtitle = subtitleType;
		PreviousStudentID = StudentID;
		Timer = Duration;
	}

	private void Update()
	{
		if (Timer > 0f)
		{
			Timer -= Time.deltaTime;
			if (Timer <= 0f)
			{
				Jukebox.Dip = 1f;
				Label.text = string.Empty;
				Timer = 0f;
			}
		}
		if (Label.text != "" && EventLabel.text != "")
		{
			EventLabel.transform.localPosition = Vector3.Lerp(EventLabel.transform.localPosition, new Vector3(0f, -485f, 0f), Time.deltaTime * 10f);
		}
		else if (EventLabel.transform.localPosition.y < -334f)
		{
			EventLabel.transform.localPosition = Vector3.Lerp(EventLabel.transform.localPosition, new Vector3(0f, -335f, 0f), Time.deltaTime * 10f);
			if (EventLabel.transform.localPosition.y > -334f)
			{
				EventLabel.transform.localPosition = new Vector3(0f, -335f, 0f);
			}
		}
	}

	private void PlayVoice(SubtitleType subtitleType, int ID)
	{
		Jukebox.Dip = 0.5f;
		SubtitleClipArrays.TryGetValue(subtitleType, out var value);
		if (CurrentClip != null && value[ID] != HmmClips[0])
		{
			Object.Destroy(CurrentClip);
		}
		if (ID < value.Length)
		{
			PlayClip(value[ID], base.transform.position);
		}
		else
		{
			PlayClip(value[0], base.transform.position);
		}
	}

	public float GetClipLength(int StudentID, int TaskPhase)
	{
		YandereScript component = Yandere.GetComponent<YandereScript>();
		if (!component.StudentManager.Eighties)
		{
			switch (StudentID)
			{
			case 4:
				return Task4Clips[TaskPhase].length + 0.5f;
			case 6:
				return Task6Clips[TaskPhase].length + 0.5f;
			case 8:
				return Task8Clips[TaskPhase].length;
			case 11:
				return Task11Clips[TaskPhase].length;
			case 12:
				return Task12Clips[TaskPhase].length;
			case 13:
				return Task13Clips[TaskPhase].length;
			case 14:
				return Task14Clips[TaskPhase].length;
			case 15:
				return Task15Clips[TaskPhase].length;
			case 16:
				return Task16Clips[TaskPhase].length;
			case 17:
				return Task17Clips[TaskPhase].length;
			case 18:
				return Task18Clips[TaskPhase].length;
			case 19:
				return Task19Clips[TaskPhase].length;
			case 20:
				return Task20Clips[TaskPhase].length;
			case 25:
				return Task25Clips[TaskPhase].length;
			case 28:
				return Task28Clips[TaskPhase].length;
			case 30:
				return Task30Clips[TaskPhase].length;
			case 36:
				return Task36Clips[TaskPhase].length;
			case 37:
				return Task37Clips[TaskPhase].length;
			case 38:
				return Task38Clips[TaskPhase].length;
			case 41:
				return Task41Clips[TaskPhase].length;
			case 46:
				return Task46Clips[TaskPhase].length;
			case 47:
				return Task47Clips[TaskPhase].length;
			case 48:
				return Task48Clips[TaskPhase].length;
			case 49:
				return Task49Clips[TaskPhase].length;
			case 50:
				return Task50Clips[TaskPhase].length;
			case 52:
				return Task52Clips[TaskPhase].length;
			case 76:
				return Task76Clips[TaskPhase].length;
			case 77:
				return Task77Clips[TaskPhase].length;
			case 78:
				return Task78Clips[TaskPhase].length;
			case 79:
				return Task79Clips[TaskPhase].length;
			case 80:
				return Task80Clips[TaskPhase].length;
			case 81:
				return Task81Clips[TaskPhase].length;
			default:
				if (component.TargetStudent.Male)
				{
					return TaskGenericMaleClips[TaskPhase].length;
				}
				return TaskGenericFemaleClips[TaskPhase].length;
			}
		}
		switch (StudentID)
		{
		case 11:
			return Task11Clips[TaskPhase].length;
		case 12:
			return Task12Clips[TaskPhase].length;
		case 13:
			return Task13Clips[TaskPhase].length;
		case 14:
			return Task14Clips[TaskPhase].length;
		case 15:
			return Task15Clips[TaskPhase].length;
		case 16:
			return Task16Clips[TaskPhase].length;
		case 17:
			return Task17Clips[TaskPhase].length;
		case 18:
			return Task18Clips[TaskPhase].length;
		case 19:
			return Task19Clips[TaskPhase].length;
		case 20:
			if (StudentID == 20)
			{
				return Task20Clips[TaskPhase].length;
			}
			Debug.Log("This code is returning null, which is bad.");
			return 1f;
		default:
			if (StudentID == 79)
			{
				return Task79Clips[TaskPhase].length;
			}
			if (component.TargetStudent.Male)
			{
				if (component.TargetStudent.GenericTaskID == 1)
				{
					return TaskGenericEightiesMaleClips1[TaskPhase].length;
				}
				if (component.TargetStudent.GenericTaskID == 2)
				{
					return TaskGenericEightiesMaleClips2[TaskPhase].length;
				}
				if (component.TargetStudent.GenericTaskID == 3)
				{
					return TaskGenericEightiesMaleClips3[TaskPhase].length;
				}
				if (component.TargetStudent.GenericTaskID == 4)
				{
					return TaskGenericEightiesMaleClips4[TaskPhase].length;
				}
				if (component.TargetStudent.GenericTaskID == 5)
				{
					return TaskGenericEightiesMaleClips5[TaskPhase].length;
				}
				if (component.TargetStudent.GenericTaskID == 6)
				{
					return TaskGenericEightiesMaleClips6[TaskPhase].length;
				}
				if (component.TargetStudent.GenericTaskID == 7)
				{
					return TaskGenericEightiesMaleClips7[TaskPhase].length;
				}
				if (component.TargetStudent.GenericTaskID == 8)
				{
					return TaskGenericEightiesMaleClips8[TaskPhase].length;
				}
				if (component.TargetStudent.GenericTaskID == 9)
				{
					return TaskGenericEightiesMaleClips9[TaskPhase].length;
				}
				if (component.TargetStudent.GenericTaskID == 10)
				{
					return TaskGenericEightiesMaleClips10[TaskPhase].length;
				}
				Debug.Log("This code is returning null, which is bad.");
				return 1f;
			}
			if (component.TargetStudent.GenericTaskID == 1)
			{
				return TaskGenericEightiesFemaleClips1[TaskPhase].length;
			}
			if (component.TargetStudent.GenericTaskID == 2)
			{
				return TaskGenericEightiesFemaleClips2[TaskPhase].length;
			}
			if (component.TargetStudent.GenericTaskID == 3)
			{
				return TaskGenericEightiesFemaleClips3[TaskPhase].length;
			}
			if (component.TargetStudent.GenericTaskID == 4)
			{
				return TaskGenericEightiesFemaleClips4[TaskPhase].length;
			}
			if (component.TargetStudent.GenericTaskID == 5)
			{
				return TaskGenericEightiesFemaleClips5[TaskPhase].length;
			}
			if (component.TargetStudent.GenericTaskID == 6)
			{
				return TaskGenericEightiesFemaleClips6[TaskPhase].length;
			}
			if (component.TargetStudent.GenericTaskID == 7)
			{
				return TaskGenericEightiesFemaleClips7[TaskPhase].length;
			}
			if (component.TargetStudent.GenericTaskID == 8)
			{
				return TaskGenericEightiesFemaleClips8[TaskPhase].length;
			}
			if (component.TargetStudent.GenericTaskID == 9)
			{
				return TaskGenericEightiesFemaleClips9[TaskPhase].length;
			}
			if (component.TargetStudent.GenericTaskID == 10)
			{
				return TaskGenericEightiesFemaleClips10[TaskPhase].length;
			}
			Debug.Log("This code is returning null, which is bad.");
			return 1f;
		}
	}

	public float GetClubClipLength(ClubType Club, int ClubPhase)
	{
		switch (Club)
		{
		case ClubType.Cooking:
			return Club1Clips[ClubPhase].length + 0.5f;
		case ClubType.Drama:
			return Club2Clips[ClubPhase].length + 0.5f;
		case ClubType.Occult:
			return Club3Clips[ClubPhase].length + 0.5f;
		case ClubType.Art:
			return Club4Clips[ClubPhase].length + 0.5f;
		case ClubType.LightMusic:
			return Club5Clips[ClubPhase].length + 0.5f;
		case ClubType.MartialArts:
			return Club6Clips[ClubPhase].length + 0.5f;
		case ClubType.Photography:
			if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
			{
				return Club7ClipsDark[ClubPhase].length + 0.5f;
			}
			return Club7ClipsLight[ClubPhase].length + 0.5f;
		case ClubType.Science:
			return Club8Clips[ClubPhase].length + 0.5f;
		case ClubType.Sports:
			return Club9Clips[ClubPhase].length + 0.5f;
		case ClubType.Gardening:
			return Club10Clips[ClubPhase].length + 0.5f;
		case ClubType.Gaming:
			return Club11Clips[ClubPhase].length + 0.5f;
		case ClubType.Delinquent:
			return Club12Clips[ClubPhase].length + 0.5f;
		case ClubType.Newspaper:
			return Club13Clips[ClubPhase].length + 0.5f;
		default:
			return 0f;
		}
	}

	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		if (clip != null)
		{
			GameObject gameObject = new GameObject("TempAudio");
			if (Speaker != null)
			{
				gameObject.transform.position = Speaker.transform.position + base.transform.up;
				gameObject.transform.parent = Speaker.transform;
			}
			else
			{
				gameObject.transform.position = Yandere.transform.position + base.transform.up;
				gameObject.transform.parent = Yandere.transform;
			}
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.clip = clip;
			audioSource.Play();
			Object.Destroy(gameObject, clip.length);
			audioSource.rolloffMode = AudioRolloffMode.Linear;
			audioSource.spatialBlend = 1f;
			audioSource.minDistance = 5f;
			audioSource.maxDistance = 15f;
			CurrentClip = gameObject;
			audioSource.volume = ((Yandere.position.y < gameObject.transform.position.y - 2f) ? 0f : 1f);
			Speaker = null;
		}
		else
		{
			Debug.Log("Could not play a voice line. The audio clip was null.");
		}
	}

	public void Silence(AudioClip[] ClipArray)
	{
		for (int i = 0; i < 11; i++)
		{
			if (i < ClipArray.Length)
			{
				ClipArray[i] = LongestSilence;
			}
		}
	}
}
