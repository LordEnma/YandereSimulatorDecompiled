// Decompiled with JetBrains decompiler
// Type: SubtitleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SubtitleScript : MonoBehaviour
{
  public JukeboxScript Jukebox;
  public Transform Yandere;
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
  public string[] Task6Lines;
  public string[] Task7Lines;
  public string[] Task8Lines;
  public string[] Task11Lines;
  public string[] Task13Lines;
  public string[] Task14Lines;
  public string[] Task15Lines;
  public string[] Task25Lines;
  public string[] Task28Lines;
  public string[] Task30Lines;
  public string[] Task32Lines;
  public string[] Task33Lines;
  public string[] Task34Lines;
  public string[] Task36Lines;
  public string[] Task37Lines;
  public string[] Task38Lines;
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
  public string[] TaskGenericEightiesLines;
  public string[] TaskGenericEightiesLinesMale;
  public string[] TaskGenericEightiesLinesFemale;
  public string[] TaskInquiries;
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
  public AudioClip[] Task6Clips;
  public AudioClip[] Task7Clips;
  public AudioClip[] Task8Clips;
  public AudioClip[] Task11Clips;
  public AudioClip[] Task13Clips;
  public AudioClip[] Task14Clips;
  public AudioClip[] Task15Clips;
  public AudioClip[] Task25Clips;
  public AudioClip[] Task28Clips;
  public AudioClip[] Task30Clips;
  public AudioClip[] Task32Clips;
  public AudioClip[] Task33Clips;
  public AudioClip[] Task34Clips;
  public AudioClip[] Task36Clips;
  public AudioClip[] Task37Clips;
  public AudioClip[] Task38Clips;
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
  public AudioClip[] TaskGenericEightiesMaleClips;
  public AudioClip[] TaskGenericEightiesFemaleClips;
  public AudioClip[] TaskInquiryClips;
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
      this.PlayerLove[4] = "She's at the east fountain. Go there and use the advice I gave you.";
      this.Task79Lines = this.Task79LinesEighties;
      this.Task79Clips = this.Task79ClipsEighties;
      this.Club1Info[1] = "This is the cooking club! Everyone here enjoys preparing food! We also like to hang out our food to people around school!";
      this.Club1Info[2] = "If you join our club, you'll get access to our ingredients, and you'll be able to prepare snacks to hand out to people.";
      this.Club1Info[3] = "Giving people food is a very effective way to get people to like you!";
      this.Club2Info[1] = "This is the drama club! Everyone here is very passionate about acting, especially stage plays!";
      this.Club2Info[2] = "If you join our club, you'll get access to our costumes.";
      this.Club2Info[3] = "Don't worry, I trust you! I'm sure you wouldn't do anything illegal while wearing our masks and gloves.";
      this.Club3Info[1] = "This is the occult club! Everyone here is dedicated to the study of the supernatural.";
      this.Club3Info[2] = "In this world, there are horrific sights that might cause certain people to...lose some of their sanity.";
      this.Club3Info[3] = "If you join our club, you'll develop a tolerance for horrific things, and you won't lose your sanity. ...well, most of it.";
      this.Club4Info[1] = "Well, we do all sorts of things here! We make paintings, we make clay sculptures, and we sometimes just do fun arts and crafts!";
      this.Club4Info[2] = "If you're an artist, or if you'd just like to give it a try, you're welcome to join us!";
      this.Club4Info[3] = "The best part? If you're wearing a painter's smock, nobody will notice if you've spilled anything on your clothing! Like...you know, ketchup, or something!";
      this.Club5Info[1] = "This is the light music club! Everyone here loves to make music!";
      this.Club5Info[2] = "If you join our club, you'll gain access to our musical instrument cases.";
      this.Club5Info[3] = "Our giant cello case is a great way to transport certain things in secrecy. ...you know, like yummy cakes and stuff like that!";
      this.Club6Info[1] = "This is the martial arts club! Everyone here is serious about self-improvement!";
      this.Club6Info[2] = "We train our bodies, but we also train our minds, as well!";
      this.Club6Info[3] = "If you join our club, I'll teach you how to instantly win any physical confrontation!";
      this.Club7InfoLight[1] = "We study photography here! Every day, we take pictures and share them with one another so we can grow as photographers!";
      this.Club7InfoLight[2] = "If you're a diehard fan of photography, or if you just have a passing interest and want to learn more about it, please join us!";
      this.Club7InfoLight[3] = "If you join, we'll let you have one of our spare polaroid cameras. It's so cool how they can print a photo immediately!";
      this.Club8Info[1] = "This is the science club! Everyone here takes science very seriously!";
      this.Club8Info[2] = "We primarily focus on chemistry here. I'm sorry if you expected something sci-fi.";
      this.Club8Info[3] = "If you join our club, you'll get access to our emergency shower. If you spill dangerous chemicals, it can be a life-saver.";
      this.Club9Info[1] = "This is the sports club! You don't need me to explain what this club is about, right? Running and swimming!";
      this.Club9Info[2] = "We exercise during almost all of our free time! When we're not jogging, we're swimming! Gotta stay fit!";
      this.Club9Info[3] = "If you join our club, I guarantee you'll become a faster runner!";
      this.Club10Info[1] = "This is the gardening club! Everyone here loves planting flowers!";
      this.Club10Info[2] = "You'll usually see us tending to our garden here or watering the plants around school.";
      this.Club10Info[3] = "If you join our club, you'll get access to our supply shed! Oh, but there's some dangerous stuff in there, so be careful.";
      for (int index = 1; index < 14; ++index)
      {
        this.ClubGreetings[index] = "Hi! Thanks for visiting!";
        this.ClubUnwelcomes[index] = "I saw you kill someone. You can't just...pretend that nothing happened. I want you to leave. Now.";
        this.ClubKicks[index] = "Someone in the club has a big problem with you. I can't let you remain in the club. I'm very sorry about this...";
        this.ClubJoins[index] = "Oh! Would you like to join us?";
        this.ClubAccepts[index] = "That's great! Welcome to the club!";
        this.ClubRefuses[index] = "Aww, too bad. Let me know if you change your mind!";
        this.ClubRejoins[index] = "I'm sorry, I can't let you back into the club. You might leave us again, just like last time.";
        this.ClubExclusives[index] = "I'm sorry, you're already a member of another club. You'd have to leave them if you want to join us";
        this.ClubGrudges[index] = "I'm sorry...someone in our club has a big problem with you. I can't let you join.";
        this.ClubQuits[index] = "Uh-oh! Are you thinking about quitting the club?";
        this.ClubConfirms[index] = "Aww, that's too bad. I'm sad to see you go.";
        this.ClubDenies[index] = "Phew! I'm relieved to hear that!";
        this.ClubFarewells[index] = "Bye! See you around school!";
        this.ClubActivities[index] = "We're about to start our daily club activities! Would you like to join us?";
        this.ClubEarlies[index] = "I'm sorry, it's too early in the day for club activities. Please come back between 5:00 and 5:30!";
        this.ClubLates[index] = "I'm sorry, we're already done with club activities. To participate, you'd have to be here earlier than 5:30.";
        this.ClubYeses[index] = "Great! Let's get started!";
        this.ClubNoes[index] = "Okay. We can wait for you, but no longer than 5:30.";
        this.ClubGreetingClips[index] = this.LongestSilence;
        this.ClubUnwelcomeClips[index] = this.LongestSilence;
        this.ClubKickClips[index] = this.LongestSilence;
        this.ClubJoinClips[index] = this.LongestSilence;
        this.ClubAcceptClips[index] = this.LongestSilence;
        this.ClubRefuseClips[index] = this.LongestSilence;
        this.ClubRejoinClips[index] = this.LongestSilence;
        this.ClubExclusiveClips[index] = this.LongestSilence;
        this.ClubGrudgeClips[index] = this.LongestSilence;
        this.ClubQuitClips[index] = this.LongestSilence;
        this.ClubConfirmClips[index] = this.LongestSilence;
        this.ClubDenyClips[index] = this.LongestSilence;
        this.ClubFarewellClips[index] = this.LongestSilence;
        this.ClubActivityClips[index] = this.LongestSilence;
        this.ClubEarlyClips[index] = this.LongestSilence;
        this.ClubLateClips[index] = this.LongestSilence;
        this.ClubYesClips[index] = this.LongestSilence;
        this.ClubNoClips[index] = this.LongestSilence;
      }
      this.Shoving[1] = "Back off.";
      this.Shoving[2] = "Desculpe!";
      this.Shoving[3] = "Oops, sorry!";
      this.Shoving[4] = "Too close, girlie.";
      this.Chasing[1] = "How dare you!";
      this.Chasing[2] = "Oh meu Deus!";
      this.Chasing[3] = "How could you do that?!";
      this.Chasing[4] = "I'm taking you down!";
      this.Spraying[1] = "Take this!";
      this.Spraying[2] = "Spray de pimenta!";
      this.Spraying[3] = "You brought this on yourself!";
      this.Spraying[4] = "Get on the ground now!";
      this.BreakingUp[1] = "Cease this nonsesne immediately.";
      this.BreakingUp[2] = "No! Do not fight!";
      this.BreakingUp[3] = "Um, please, don't do this!";
      this.BreakingUp[4] = "Knock it off, or I'll kick BOTH your asses.";
      this.CouncilToCounselors[1] = "This conduct is unacceptable. Come with me to the counselor's office.";
      this.CouncilToCounselors[2] = "I'm sorry! You must go to the conselheira.";
      this.CouncilToCounselors[3] = "Um, I'm really sorry, but the counselor will need to hear about this...";
      this.CouncilToCounselors[4] = "What the hell do you think you're doing? Get your ass to the counelsor's office.";
      this.CouncilCorpseReactions[1] = "A dead body?!";
      this.CouncilCorpseReactions[2] = "Você está morto?!";
      this.CouncilCorpseReactions[3] = "Oh, no! This is horrible!";
      this.CouncilCorpseReactions[4] = "Damn! This is serious!";
      this.StrictReport[1] = "The faculty must be informed!";
      this.StrictReport[2] = "I've discovered a dead body! Come with me!";
      this.StrictReport[3] = "...no...impossible...";
      this.CasualReport[1] = "Devo contar a um professor!";
      this.CasualReport[2] = "Emergency! Dead body! Follow me!";
      this.CasualReport[3] = "Que diabos está acontecendo aqui...";
      this.GraceReport[1] = "The teachers need to hear about this!";
      this.GraceReport[2] = "Help! Help! Somebody's dead!";
      this.GraceReport[3] = "No! Wait! I'm telling the truth! I swear!";
      this.EdgyReport[1] = "Gotta act fast!";
      this.EdgyReport[2] = "Listen up! I found a dead body!";
      this.EdgyReport[3] = "What the hell?! What's going on here?!";
      this.LovestruckMurderReports[0] = "Senpai! Ryoba from class 2-1 just killed someone!";
      this.WeaponBloodApologies[0] = "It's not what it looks like! It's a costume and prop for an upcoming play.";
      for (int index = 1; index < 5; ++index)
      {
        this.ShoveClips[index] = this.LongestSilence;
        this.ChaseClips[index] = this.LongestSilence;
        this.SprayClips[index] = this.LongestSilence;
        this.BreakUpClips[index] = this.LongestSilence;
        this.CouncilCorpseClips[index] = this.LongestSilence;
        this.CouncilCounselorClips[index] = this.LongestSilence;
        this.HmmClips[index] = this.LongestSilence;
      }
      for (int index = 1; index < 4; ++index)
      {
        this.StrictReportClips[index] = this.LongestSilence;
        this.CasualReportClips[index] = this.LongestSilence;
        this.GraceReportClips[index] = this.LongestSilence;
        this.EdgyReportClips[index] = this.LongestSilence;
      }
      this.SenpaiRivalDeathReactions[0] = "...huh? ...are you okay?! What's wrong?! Hey!! Do you need any help?!";
      this.SenpaiRivalDeathReactions[1] = "Huh?! What happened?!";
      this.SenpaiRivalDeathReactions[2] = "Oh my god!! No!! Please, say something!! Answer me!! Wake up, please, wake up!! Don't do this!! Oh, god!! This can't be happening!! NO!! ...no...";
      this.SenpaiRivalDeathReactions[4] = "No...no...(Sobbing)...no, no, no...no...no...";
      this.SenpaiRivalDeathReactionClips[0] = this.LongestSilence;
      this.SenpaiRivalDeathReactionClips[1] = this.LongestSilence;
      this.SenpaiRivalDeathReactionClips[2] = this.LongestSilence;
      this.SenpaiRivalDeathReactionClips[4] = this.LongestSilence;
      this.Silence(this.DelinquentAnnoyClips);
      this.Silence(this.DelinquentCaseClips);
      this.Silence(this.DelinquentShoveClips);
      this.Silence(this.DelinquentReactionClips);
      this.Silence(this.DelinquentWeaponReactionClips);
      this.Silence(this.DelinquentThreatenedClips);
      this.Silence(this.DelinquentTauntClips);
      this.Silence(this.DelinquentCalmClips);
      this.Silence(this.DelinquentFightClips);
      this.Silence(this.DelinquentAvengeClips);
      this.Silence(this.DelinquentWinClips);
      this.Silence(this.DelinquentSurrenderClips);
      this.Silence(this.DelinquentNoSurrenderClips);
      this.Silence(this.DelinquentMurderReactionClips);
      this.Silence(this.DelinquentCorpseReactionClips);
      this.Silence(this.DelinquentFriendCorpseReactionClips);
      this.Silence(this.DelinquentResumeClips);
      this.Silence(this.DelinquentFleeClips);
      this.Silence(this.DelinquentEnemyFleeClips);
      this.Silence(this.DelinquentFriendFleeClips);
      this.Silence(this.DelinquentInjuredFleeClips);
      this.Silence(this.DelinquentCheerClips);
      this.Silence(this.DelinquentHmmClips);
      this.Silence(this.DelinquentGrudgeClips);
      this.Silence(this.DismissiveClips);
      this.Silence(this.EvilDelinquentCorpseReactionClips);
      this.Silence(this.SenpaiRivalDeathReactionClips);
      this.Silence(this.RaibaruRivalDeathReactionClips);
      this.Silence(this.OsanaObstacleDeathReactionClips);
      this.Silence(this.Club1Clips);
      this.Silence(this.Club2Clips);
      this.Silence(this.Club3Clips);
      this.Silence(this.Club4Clips);
      this.Silence(this.Club5Clips);
      this.Silence(this.Club6Clips);
      this.Silence(this.Club8Clips);
      this.Silence(this.Club9Clips);
      this.Silence(this.Club10Clips);
      this.Silence(this.Club11Clips);
      this.Silence(this.Club12Clips);
      this.Silence(this.Club13Clips);
      this.Silence(this.Club7ClipsLight);
      this.Silence(this.Club7ClipsDark);
    }
    else
    {
      this.Club3Info = this.SubClub3Info;
      this.ClubGreetings[3] = this.ClubGreetings[13];
      this.ClubUnwelcomes[3] = this.ClubUnwelcomes[13];
      this.ClubKicks[3] = this.ClubKicks[13];
      this.ClubJoins[3] = this.ClubJoins[13];
      this.ClubAccepts[3] = this.ClubAccepts[13];
      this.ClubRefuses[3] = this.ClubRefuses[13];
      this.ClubRejoins[3] = this.ClubRejoins[13];
      this.ClubExclusives[3] = this.ClubExclusives[13];
      this.ClubGrudges[3] = this.ClubGrudges[13];
      this.ClubQuits[3] = this.ClubQuits[13];
      this.ClubConfirms[3] = this.ClubConfirms[13];
      this.ClubDenies[3] = this.ClubDenies[13];
      this.ClubFarewells[3] = this.ClubFarewells[13];
      this.ClubActivities[3] = this.ClubActivities[13];
      this.ClubEarlies[3] = this.ClubEarlies[13];
      this.ClubLates[3] = this.ClubLates[13];
      this.ClubYeses[3] = this.ClubYeses[13];
      this.ClubNoes[3] = this.ClubNoes[13];
      this.Club3Clips = this.SubClub3Clips;
      this.ClubGreetingClips[3] = this.ClubGreetingClips[13];
      this.ClubUnwelcomeClips[3] = this.ClubUnwelcomeClips[13];
      this.ClubKickClips[3] = this.ClubKickClips[13];
      this.ClubJoinClips[3] = this.ClubJoinClips[13];
      this.ClubAcceptClips[3] = this.ClubAcceptClips[13];
      this.ClubRefuseClips[3] = this.ClubRefuseClips[13];
      this.ClubRejoinClips[3] = this.ClubRejoinClips[13];
      this.ClubExclusiveClips[3] = this.ClubExclusiveClips[13];
      this.ClubGrudgeClips[3] = this.ClubGrudgeClips[13];
      this.ClubQuitClips[3] = this.ClubQuitClips[13];
      this.ClubConfirmClips[3] = this.ClubConfirmClips[13];
      this.ClubDenyClips[3] = this.ClubDenyClips[13];
      this.ClubFarewellClips[3] = this.ClubFarewellClips[13];
      this.ClubActivityClips[3] = this.ClubActivityClips[13];
      this.ClubEarlyClips[3] = this.ClubEarlyClips[13];
      this.ClubLateClips[3] = this.ClubLateClips[13];
      this.ClubYesClips[3] = this.ClubYesClips[13];
      this.ClubNoClips[3] = this.ClubNoClips[13];
    }
    SubtitleTypeAndAudioClipArrayDictionary clipArrayDictionary = new SubtitleTypeAndAudioClipArrayDictionary();
    clipArrayDictionary.Add(SubtitleType.ClubAccept, new AudioClipArrayWrapper(this.ClubAcceptClips));
    clipArrayDictionary.Add(SubtitleType.ClubActivity, new AudioClipArrayWrapper(this.ClubActivityClips));
    clipArrayDictionary.Add(SubtitleType.ClubConfirm, new AudioClipArrayWrapper(this.ClubConfirmClips));
    clipArrayDictionary.Add(SubtitleType.ClubDeny, new AudioClipArrayWrapper(this.ClubDenyClips));
    clipArrayDictionary.Add(SubtitleType.ClubEarly, new AudioClipArrayWrapper(this.ClubEarlyClips));
    clipArrayDictionary.Add(SubtitleType.ClubExclusive, new AudioClipArrayWrapper(this.ClubExclusiveClips));
    clipArrayDictionary.Add(SubtitleType.ClubFarewell, new AudioClipArrayWrapper(this.ClubFarewellClips));
    clipArrayDictionary.Add(SubtitleType.ClubGreeting, new AudioClipArrayWrapper(this.ClubGreetingClips));
    clipArrayDictionary.Add(SubtitleType.ClubGrudge, new AudioClipArrayWrapper(this.ClubGrudgeClips));
    clipArrayDictionary.Add(SubtitleType.ClubJoin, new AudioClipArrayWrapper(this.ClubJoinClips));
    clipArrayDictionary.Add(SubtitleType.ClubKick, new AudioClipArrayWrapper(this.ClubKickClips));
    clipArrayDictionary.Add(SubtitleType.ClubLate, new AudioClipArrayWrapper(this.ClubLateClips));
    clipArrayDictionary.Add(SubtitleType.ClubNo, new AudioClipArrayWrapper(this.ClubNoClips));
    clipArrayDictionary.Add(SubtitleType.ClubPlaceholderInfo, new AudioClipArrayWrapper(this.Club0Clips));
    clipArrayDictionary.Add(SubtitleType.ClubCookingInfo, new AudioClipArrayWrapper(this.Club1Clips));
    clipArrayDictionary.Add(SubtitleType.ClubDramaInfo, new AudioClipArrayWrapper(this.Club2Clips));
    clipArrayDictionary.Add(SubtitleType.ClubOccultInfo, new AudioClipArrayWrapper(this.Club3Clips));
    clipArrayDictionary.Add(SubtitleType.ClubArtInfo, new AudioClipArrayWrapper(this.Club4Clips));
    clipArrayDictionary.Add(SubtitleType.ClubLightMusicInfo, new AudioClipArrayWrapper(this.Club5Clips));
    clipArrayDictionary.Add(SubtitleType.ClubMartialArtsInfo, new AudioClipArrayWrapper(this.Club6Clips));
    clipArrayDictionary.Add(SubtitleType.ClubPhotoInfoLight, new AudioClipArrayWrapper(this.Club7ClipsLight));
    clipArrayDictionary.Add(SubtitleType.ClubPhotoInfoDark, new AudioClipArrayWrapper(this.Club7ClipsDark));
    clipArrayDictionary.Add(SubtitleType.ClubScienceInfo, new AudioClipArrayWrapper(this.Club8Clips));
    clipArrayDictionary.Add(SubtitleType.ClubSportsInfo, new AudioClipArrayWrapper(this.Club9Clips));
    clipArrayDictionary.Add(SubtitleType.ClubGardenInfo, new AudioClipArrayWrapper(this.Club10Clips));
    clipArrayDictionary.Add(SubtitleType.ClubGamingInfo, new AudioClipArrayWrapper(this.Club11Clips));
    clipArrayDictionary.Add(SubtitleType.ClubDelinquentInfo, new AudioClipArrayWrapper(this.Club12Clips));
    clipArrayDictionary.Add(SubtitleType.ClubNewspaperInfo, new AudioClipArrayWrapper(this.Club13Clips));
    clipArrayDictionary.Add(SubtitleType.ClubQuit, new AudioClipArrayWrapper(this.ClubQuitClips));
    clipArrayDictionary.Add(SubtitleType.ClubRefuse, new AudioClipArrayWrapper(this.ClubRefuseClips));
    clipArrayDictionary.Add(SubtitleType.ClubRejoin, new AudioClipArrayWrapper(this.ClubRejoinClips));
    clipArrayDictionary.Add(SubtitleType.ClubUnwelcome, new AudioClipArrayWrapper(this.ClubUnwelcomeClips));
    clipArrayDictionary.Add(SubtitleType.ClubYes, new AudioClipArrayWrapper(this.ClubYesClips));
    clipArrayDictionary.Add(SubtitleType.ClubPractice, new AudioClipArrayWrapper(this.ClubPracticeClips));
    clipArrayDictionary.Add(SubtitleType.ClubPracticeYes, new AudioClipArrayWrapper(this.ClubPracticeYesClips));
    clipArrayDictionary.Add(SubtitleType.ClubPracticeNo, new AudioClipArrayWrapper(this.ClubPracticeNoClips));
    clipArrayDictionary.Add(SubtitleType.DrownReaction, new AudioClipArrayWrapper(this.DrownReactionClips));
    clipArrayDictionary.Add(SubtitleType.EavesdropReaction, new AudioClipArrayWrapper(this.EavesdropClips));
    clipArrayDictionary.Add(SubtitleType.RejectFood, new AudioClipArrayWrapper(this.FoodRejectionClips));
    clipArrayDictionary.Add(SubtitleType.ViolenceReaction, new AudioClipArrayWrapper(this.ViolenceClips));
    clipArrayDictionary.Add(SubtitleType.EventEavesdropReaction, new AudioClipArrayWrapper(this.EventEavesdropClips));
    clipArrayDictionary.Add(SubtitleType.RivalEavesdropReaction, new AudioClipArrayWrapper(this.RivalEavesdropClips));
    clipArrayDictionary.Add(SubtitleType.GrudgeWarning, new AudioClipArrayWrapper(this.GrudgeWarningClips));
    clipArrayDictionary.Add(SubtitleType.LightSwitchReaction, new AudioClipArrayWrapper(this.LightSwitchClips));
    clipArrayDictionary.Add(SubtitleType.LostPhone, new AudioClipArrayWrapper(this.LostPhoneClips));
    clipArrayDictionary.Add(SubtitleType.NoteReaction, new AudioClipArrayWrapper(this.NoteReactionClips));
    clipArrayDictionary.Add(SubtitleType.NoteReactionMale, new AudioClipArrayWrapper(this.NoteReactionMaleClips));
    clipArrayDictionary.Add(SubtitleType.PickpocketReaction, new AudioClipArrayWrapper(this.PickpocketReactionClips));
    clipArrayDictionary.Add(SubtitleType.RivalLostPhone, new AudioClipArrayWrapper(this.RivalLostPhoneClips));
    clipArrayDictionary.Add(SubtitleType.RivalPickpocketReaction, new AudioClipArrayWrapper(this.RivalPickpocketReactionClips));
    clipArrayDictionary.Add(SubtitleType.RivalSplashReaction, new AudioClipArrayWrapper(this.RivalSplashReactionClips));
    clipArrayDictionary.Add(SubtitleType.SenpaiBloodReaction, new AudioClipArrayWrapper(this.SenpaiBloodReactionClips));
    clipArrayDictionary.Add(SubtitleType.SenpaiInsanityReaction, new AudioClipArrayWrapper(this.SenpaiInsanityReactionClips));
    clipArrayDictionary.Add(SubtitleType.SenpaiLewdReaction, new AudioClipArrayWrapper(this.SenpaiLewdReactionClips));
    clipArrayDictionary.Add(SubtitleType.SenpaiMurderReaction, new AudioClipArrayWrapper(this.SenpaiMurderReactionClips));
    clipArrayDictionary.Add(SubtitleType.SenpaiStalkingReaction, new AudioClipArrayWrapper(this.SenpaiStalkingReactionClips));
    clipArrayDictionary.Add(SubtitleType.SenpaiWeaponReaction, new AudioClipArrayWrapper(this.SenpaiWeaponReactionClips));
    clipArrayDictionary.Add(SubtitleType.SenpaiViolenceReaction, new AudioClipArrayWrapper(this.SenpaiViolenceReactionClips));
    clipArrayDictionary.Add(SubtitleType.SenpaiRivalDeathReaction, new AudioClipArrayWrapper(this.SenpaiRivalDeathReactionClips));
    clipArrayDictionary.Add(SubtitleType.RaibaruRivalDeathReaction, new AudioClipArrayWrapper(this.RaibaruRivalDeathReactionClips));
    clipArrayDictionary.Add(SubtitleType.OsanaObstacleDeathReaction, new AudioClipArrayWrapper(this.OsanaObstacleDeathReactionClips));
    clipArrayDictionary.Add(SubtitleType.SplashReaction, new AudioClipArrayWrapper(this.SplashReactionClips));
    clipArrayDictionary.Add(SubtitleType.SplashReactionMale, new AudioClipArrayWrapper(this.SplashReactionMaleClips));
    clipArrayDictionary.Add(SubtitleType.TutorialReaction, new AudioClipArrayWrapper(this.TutorialReactionClips));
    clipArrayDictionary.Add(SubtitleType.TrespassReaction, new AudioClipArrayWrapper(this.TrespassReactionClips));
    clipArrayDictionary.Add(SubtitleType.Task6Line, new AudioClipArrayWrapper(this.Task6Clips));
    clipArrayDictionary.Add(SubtitleType.Task7Line, new AudioClipArrayWrapper(this.Task7Clips));
    clipArrayDictionary.Add(SubtitleType.Task8Line, new AudioClipArrayWrapper(this.Task8Clips));
    clipArrayDictionary.Add(SubtitleType.Task11Line, new AudioClipArrayWrapper(this.Task11Clips));
    clipArrayDictionary.Add(SubtitleType.Task13Line, new AudioClipArrayWrapper(this.Task13Clips));
    clipArrayDictionary.Add(SubtitleType.Task14Line, new AudioClipArrayWrapper(this.Task14Clips));
    clipArrayDictionary.Add(SubtitleType.Task15Line, new AudioClipArrayWrapper(this.Task15Clips));
    clipArrayDictionary.Add(SubtitleType.Task25Line, new AudioClipArrayWrapper(this.Task25Clips));
    clipArrayDictionary.Add(SubtitleType.Task28Line, new AudioClipArrayWrapper(this.Task28Clips));
    clipArrayDictionary.Add(SubtitleType.Task30Line, new AudioClipArrayWrapper(this.Task30Clips));
    clipArrayDictionary.Add(SubtitleType.Task34Line, new AudioClipArrayWrapper(this.Task34Clips));
    clipArrayDictionary.Add(SubtitleType.Task36Line, new AudioClipArrayWrapper(this.Task36Clips));
    clipArrayDictionary.Add(SubtitleType.Task37Line, new AudioClipArrayWrapper(this.Task37Clips));
    clipArrayDictionary.Add(SubtitleType.Task38Line, new AudioClipArrayWrapper(this.Task38Clips));
    clipArrayDictionary.Add(SubtitleType.Task46Line, new AudioClipArrayWrapper(this.Task46Clips));
    clipArrayDictionary.Add(SubtitleType.Task47Line, new AudioClipArrayWrapper(this.Task47Clips));
    clipArrayDictionary.Add(SubtitleType.Task48Line, new AudioClipArrayWrapper(this.Task48Clips));
    clipArrayDictionary.Add(SubtitleType.Task49Line, new AudioClipArrayWrapper(this.Task49Clips));
    clipArrayDictionary.Add(SubtitleType.Task50Line, new AudioClipArrayWrapper(this.Task50Clips));
    clipArrayDictionary.Add(SubtitleType.Task52Line, new AudioClipArrayWrapper(this.Task52Clips));
    clipArrayDictionary.Add(SubtitleType.Task76Line, new AudioClipArrayWrapper(this.Task76Clips));
    clipArrayDictionary.Add(SubtitleType.Task77Line, new AudioClipArrayWrapper(this.Task77Clips));
    clipArrayDictionary.Add(SubtitleType.Task78Line, new AudioClipArrayWrapper(this.Task78Clips));
    clipArrayDictionary.Add(SubtitleType.Task79Line, new AudioClipArrayWrapper(this.Task79Clips));
    clipArrayDictionary.Add(SubtitleType.Task80Line, new AudioClipArrayWrapper(this.Task80Clips));
    clipArrayDictionary.Add(SubtitleType.Task81Line, new AudioClipArrayWrapper(this.Task81Clips));
    clipArrayDictionary.Add(SubtitleType.TaskGenericLineMale, new AudioClipArrayWrapper(this.TaskGenericMaleClips));
    clipArrayDictionary.Add(SubtitleType.TaskGenericLineFemale, new AudioClipArrayWrapper(this.TaskGenericFemaleClips));
    clipArrayDictionary.Add(SubtitleType.TaskGenericEightiesLineMale, new AudioClipArrayWrapper(this.TaskGenericEightiesMaleClips));
    clipArrayDictionary.Add(SubtitleType.TaskGenericEightiesLineFemale, new AudioClipArrayWrapper(this.TaskGenericEightiesFemaleClips));
    clipArrayDictionary.Add(SubtitleType.TaskInquiry, new AudioClipArrayWrapper(this.TaskInquiryClips));
    clipArrayDictionary.Add(SubtitleType.TheftReaction, new AudioClipArrayWrapper(this.TheftClips));
    clipArrayDictionary.Add(SubtitleType.TeacherAttackReaction, new AudioClipArrayWrapper(this.TeacherAttackClips));
    clipArrayDictionary.Add(SubtitleType.TeacherBloodHostile, new AudioClipArrayWrapper(this.TeacherBloodHostileClips));
    clipArrayDictionary.Add(SubtitleType.TeacherBloodReaction, new AudioClipArrayWrapper(this.TeacherBloodClips));
    clipArrayDictionary.Add(SubtitleType.TeacherCorpseInspection, new AudioClipArrayWrapper(this.TeacherInspectClips));
    clipArrayDictionary.Add(SubtitleType.TeacherCorpseReaction, new AudioClipArrayWrapper(this.TeacherCorpseClips));
    clipArrayDictionary.Add(SubtitleType.TeacherInsanityHostile, new AudioClipArrayWrapper(this.TeacherInsanityHostileClips));
    clipArrayDictionary.Add(SubtitleType.TeacherInsanityReaction, new AudioClipArrayWrapper(this.TeacherInsanityClips));
    clipArrayDictionary.Add(SubtitleType.TeacherLateReaction, new AudioClipArrayWrapper(this.TeacherLateClips));
    clipArrayDictionary.Add(SubtitleType.TeacherLewdReaction, new AudioClipArrayWrapper(this.TeacherLewdClips));
    clipArrayDictionary.Add(SubtitleType.TeacherMurderReaction, new AudioClipArrayWrapper(this.TeacherMurderClips));
    clipArrayDictionary.Add(SubtitleType.TeacherPoliceReport, new AudioClipArrayWrapper(this.TeacherPoliceClips));
    clipArrayDictionary.Add(SubtitleType.TeacherPrankReaction, new AudioClipArrayWrapper(this.TeacherPrankClips));
    clipArrayDictionary.Add(SubtitleType.TeacherReportReaction, new AudioClipArrayWrapper(this.TeacherReportClips));
    clipArrayDictionary.Add(SubtitleType.TeacherTheftReaction, new AudioClipArrayWrapper(this.TeacherTheftClips));
    clipArrayDictionary.Add(SubtitleType.TeacherTrespassingReaction, new AudioClipArrayWrapper(this.TeacherTrespassClips));
    clipArrayDictionary.Add(SubtitleType.TeacherWeaponHostile, new AudioClipArrayWrapper(this.TeacherWeaponHostileClips));
    clipArrayDictionary.Add(SubtitleType.TeacherWeaponReaction, new AudioClipArrayWrapper(this.TeacherWeaponClips));
    clipArrayDictionary.Add(SubtitleType.TeacherCoverUpHostile, new AudioClipArrayWrapper(this.TeacherCoverUpHostileClips));
    clipArrayDictionary.Add(SubtitleType.YandereWhimper, new AudioClipArrayWrapper(this.YandereWhimperClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentAnnoy, new AudioClipArrayWrapper(this.DelinquentAnnoyClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentCase, new AudioClipArrayWrapper(this.DelinquentCaseClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentShove, new AudioClipArrayWrapper(this.DelinquentShoveClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentReaction, new AudioClipArrayWrapper(this.DelinquentReactionClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentWeaponReaction, new AudioClipArrayWrapper(this.DelinquentWeaponReactionClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentThreatened, new AudioClipArrayWrapper(this.DelinquentThreatenedClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentTaunt, new AudioClipArrayWrapper(this.DelinquentTauntClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentCalm, new AudioClipArrayWrapper(this.DelinquentCalmClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentFight, new AudioClipArrayWrapper(this.DelinquentFightClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentAvenge, new AudioClipArrayWrapper(this.DelinquentAvengeClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentWin, new AudioClipArrayWrapper(this.DelinquentWinClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentSurrender, new AudioClipArrayWrapper(this.DelinquentSurrenderClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentNoSurrender, new AudioClipArrayWrapper(this.DelinquentNoSurrenderClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentMurderReaction, new AudioClipArrayWrapper(this.DelinquentMurderReactionClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentCorpseReaction, new AudioClipArrayWrapper(this.DelinquentCorpseReactionClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentFriendCorpseReaction, new AudioClipArrayWrapper(this.DelinquentFriendCorpseReactionClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentResume, new AudioClipArrayWrapper(this.DelinquentResumeClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentFlee, new AudioClipArrayWrapper(this.DelinquentFleeClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentEnemyFlee, new AudioClipArrayWrapper(this.DelinquentEnemyFleeClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentFriendFlee, new AudioClipArrayWrapper(this.DelinquentFriendFleeClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentInjuredFlee, new AudioClipArrayWrapper(this.DelinquentInjuredFleeClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentCheer, new AudioClipArrayWrapper(this.DelinquentCheerClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentHmm, new AudioClipArrayWrapper(this.DelinquentHmmClips));
    clipArrayDictionary.Add(SubtitleType.DelinquentGrudge, new AudioClipArrayWrapper(this.DelinquentGrudgeClips));
    clipArrayDictionary.Add(SubtitleType.Dismissive, new AudioClipArrayWrapper(this.DismissiveClips));
    clipArrayDictionary.Add(SubtitleType.EvilDelinquentCorpseReaction, new AudioClipArrayWrapper(this.EvilDelinquentCorpseReactionClips));
    clipArrayDictionary.Add(SubtitleType.Eulogy, new AudioClipArrayWrapper(this.EulogyClips));
    clipArrayDictionary.Add(SubtitleType.GasWarning, new AudioClipArrayWrapper(this.GasWarningClips));
    clipArrayDictionary.Add(SubtitleType.StudentStay, new AudioClipArrayWrapper(this.StudentStayClips));
    clipArrayDictionary.Add(SubtitleType.StrictReport, new AudioClipArrayWrapper(this.StrictReportClips));
    clipArrayDictionary.Add(SubtitleType.CasualReport, new AudioClipArrayWrapper(this.CasualReportClips));
    clipArrayDictionary.Add(SubtitleType.GraceReport, new AudioClipArrayWrapper(this.GraceReportClips));
    clipArrayDictionary.Add(SubtitleType.EdgyReport, new AudioClipArrayWrapper(this.EdgyReportClips));
    clipArrayDictionary.Add(SubtitleType.BreakingUp, new AudioClipArrayWrapper(this.BreakUpClips));
    clipArrayDictionary.Add(SubtitleType.Chasing, new AudioClipArrayWrapper(this.ChaseClips));
    clipArrayDictionary.Add(SubtitleType.Shoving, new AudioClipArrayWrapper(this.ShoveClips));
    clipArrayDictionary.Add(SubtitleType.Spraying, new AudioClipArrayWrapper(this.SprayClips));
    clipArrayDictionary.Add(SubtitleType.CouncilCorpseReaction, new AudioClipArrayWrapper(this.CouncilCorpseClips));
    clipArrayDictionary.Add(SubtitleType.CouncilToCounselor, new AudioClipArrayWrapper(this.CouncilCounselorClips));
    clipArrayDictionary.Add(SubtitleType.HmmReaction, new AudioClipArrayWrapper(this.HmmClips));
    clipArrayDictionary.Add(SubtitleType.ObstacleMurderReaction, new AudioClipArrayWrapper(this.ObstacleMurderReactionClips));
    clipArrayDictionary.Add(SubtitleType.ObstaclePoisonReaction, new AudioClipArrayWrapper(this.ObstaclePoisonReactionClips));
    this.SubtitleClipArrays = clipArrayDictionary;
  }

  private void Start() => this.Label.text = string.Empty;

  private string GetRandomString(string[] strings) => strings[Random.Range(0, strings.Length)];

  public void UpdateLabel(SubtitleType subtitleType, int ID, float Duration)
  {
    if (!this.Jukebox.Yandere.Talking && subtitleType == this.PreviousSubtitle && (double) this.Timer > 0.0)
    {
      Debug.Log((object) ("A character is attempting to say a subtitle that another character is already saying: " + subtitleType.ToString()));
    }
    else
    {
      if (subtitleType == SubtitleType.WeaponAndBloodAndInsanityReaction)
        this.Label.text = this.GetRandomString(this.WeaponBloodInsanityReactions);
      else if (subtitleType == SubtitleType.WeaponAndBloodReaction)
        this.Label.text = this.GetRandomString(this.WeaponBloodReactions);
      else if (subtitleType == SubtitleType.WeaponAndInsanityReaction)
        this.Label.text = this.GetRandomString(this.WeaponInsanityReactions);
      else if (subtitleType == SubtitleType.BloodAndInsanityReaction)
        this.Label.text = this.GetRandomString(this.BloodInsanityReactions);
      else if (subtitleType == SubtitleType.WeaponReaction)
      {
        switch (ID)
        {
          case 1:
            this.Label.text = this.GetRandomString(this.KnifeReactions);
            break;
          case 2:
            this.Label.text = this.GetRandomString(this.KatanaReactions);
            break;
          case 3:
            this.Label.text = this.GetRandomString(this.SyringeReactions);
            break;
          case 4:
            this.Label.text = this.GetRandomString(this.ScissorsReactions);
            break;
          case 7:
            this.Label.text = this.GetRandomString(this.SawReactions);
            break;
          case 8:
            this.Label.text = this.StudentID < 31 || this.StudentID > 35 ? this.RitualReactions[0] : this.RitualReactions[1];
            break;
          case 9:
            this.Label.text = this.GetRandomString(this.BatReactions);
            break;
          case 10:
            this.Label.text = this.GetRandomString(this.ShovelReactions);
            break;
          case 11:
          case 14:
          case 16:
          case 17:
          case 22:
            this.Label.text = this.GetRandomString(this.PropReactions);
            break;
          case 12:
            this.Label.text = this.GetRandomString(this.DumbbellReactions);
            break;
          case 13:
          case 15:
            this.Label.text = this.GetRandomString(this.AxeReactions);
            break;
          default:
            if (ID > 17 && ID < 22)
            {
              this.Label.text = this.GetRandomString(this.DelinkWeaponReactions);
              break;
            }
            switch (ID)
            {
              case 23:
                this.Label.text = this.GetRandomString(this.ExtinguisherReactions);
                break;
              case 24:
                this.Label.text = this.GetRandomString(this.WrenchReactions);
                break;
              case 25:
                this.Label.text = this.GetRandomString(this.GuitarReactions);
                break;
              case 28:
                this.Label.text = this.GetRandomString(this.ScrapReactions);
                break;
            }
            break;
        }
      }
      else if (subtitleType == SubtitleType.BloodReaction)
        this.Label.text = this.GetRandomString(this.BloodReactions);
      else if (subtitleType == SubtitleType.BloodPoolReaction)
        this.Label.text = this.BloodPoolReactions[ID];
      else if (subtitleType == SubtitleType.BloodyWeaponReaction)
        this.Label.text = this.BloodyWeaponReactions[ID];
      else if (subtitleType == SubtitleType.LimbReaction)
        this.Label.text = this.LimbReactions[ID];
      else if (subtitleType == SubtitleType.WetBloodReaction)
        this.Label.text = this.GetRandomString(this.WetBloodReactions);
      else if (subtitleType == SubtitleType.InsanityReaction)
        this.Label.text = this.GetRandomString(this.InsanityReactions);
      else if (subtitleType == SubtitleType.LewdReaction)
        this.Label.text = this.GetRandomString(this.LewdReactions);
      else if (subtitleType == SubtitleType.SuspiciousReaction)
        this.Label.text = this.SuspiciousReactions[ID];
      else if (subtitleType == SubtitleType.PoisonReaction)
        this.Label.text = this.PoisonReactions[ID];
      else if (subtitleType == SubtitleType.PrankReaction)
        this.Label.text = this.GetRandomString(this.PrankReactions);
      else if (subtitleType == SubtitleType.InterruptionReaction)
        this.Label.text = this.InterruptReactions[ID];
      else if (subtitleType == SubtitleType.IntrusionReaction)
        this.Label.text = this.GetRandomString(this.IntrusionReactions);
      else if (subtitleType == SubtitleType.TheftReaction)
      {
        this.Label.text = this.TheftReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.KilledMood)
        this.Label.text = this.GetRandomString(this.KilledMoods);
      else if (subtitleType == SubtitleType.SendToLocker)
        this.Label.text = this.SendToLockers[ID];
      else if (subtitleType == SubtitleType.NoteReaction)
      {
        this.Label.text = this.NoteReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.NoteReactionMale)
      {
        this.Label.text = this.NoteReactionsMale[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.OfferSnack)
        this.Label.text = this.OfferSnacks[ID];
      else if (subtitleType == SubtitleType.AcceptFood)
        this.Label.text = this.GetRandomString(this.FoodAccepts);
      else if (subtitleType == SubtitleType.RejectFood)
      {
        this.Label.text = this.FoodRejects[ID];
        if (this.Jukebox.Yandere.TargetStudent.Male)
          this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.EavesdropReaction)
      {
        this.RandomID = Random.Range(0, this.EavesdropReactions.Length);
        this.Label.text = this.EavesdropReactions[this.RandomID];
      }
      else if (subtitleType == SubtitleType.ViolenceReaction)
      {
        this.RandomID = Random.Range(0, this.ViolenceReactions.Length);
        this.Label.text = this.ViolenceReactions[this.RandomID];
      }
      else if (subtitleType == SubtitleType.EventEavesdropReaction)
      {
        this.RandomID = Random.Range(0, this.EventEavesdropReactions.Length);
        this.Label.text = this.EventEavesdropReactions[this.RandomID];
      }
      else if (subtitleType == SubtitleType.RivalEavesdropReaction)
      {
        Debug.Log((object) ("Rival eavesdrop reaction. ID is: " + ID.ToString()));
        this.Label.text = this.RivalEavesdropReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.PickpocketReaction)
      {
        this.RandomID = Random.Range(0, this.PickpocketReactions.Length);
        this.Label.text = this.PickpocketReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.PickpocketApology)
      {
        this.RandomID = Random.Range(0, this.PickpocketApologies.Length);
        this.Label.text = this.PickpocketApologies[this.RandomID];
      }
      else if (subtitleType == SubtitleType.CleaningApology)
      {
        this.RandomID = Random.Range(0, this.CleaningApologies.Length);
        this.Label.text = this.CleaningApologies[this.RandomID];
      }
      else if (subtitleType == SubtitleType.PoisonApology)
      {
        this.RandomID = Random.Range(0, this.PoisonApologies.Length);
        this.Label.text = this.PoisonApologies[this.RandomID];
      }
      else if (subtitleType == SubtitleType.HoldingBloodyClothingApology)
      {
        this.RandomID = Random.Range(0, this.HoldingBloodyClothingApologies.Length);
        this.Label.text = this.HoldingBloodyClothingApologies[this.RandomID];
      }
      else if (subtitleType == SubtitleType.TrespassApology)
      {
        this.RandomID = Random.Range(0, this.TrespassApologies.Length);
        this.Label.text = this.TrespassApologies[this.RandomID];
      }
      else if (subtitleType == SubtitleType.RivalPickpocketReaction)
      {
        this.RandomID = Random.Range(0, this.RivalPickpocketReactions.Length);
        this.Label.text = this.RivalPickpocketReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DrownReaction)
      {
        this.Label.text = this.DrownReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.HmmReaction)
      {
        if (this.Label.text == string.Empty)
        {
          this.RandomID = Random.Range(0, this.HmmReactions.Length);
          this.Label.text = this.HmmReactions[this.RandomID];
          this.PlayVoice(subtitleType, ID);
        }
      }
      else if (subtitleType == SubtitleType.HoldingBloodyClothingReaction)
      {
        if (this.Label.text == string.Empty)
        {
          this.RandomID = Random.Range(0, this.HoldingBloodyClothingReactions.Length);
          this.Label.text = this.HoldingBloodyClothingReactions[this.RandomID];
        }
      }
      else if (subtitleType == SubtitleType.ParanoidReaction)
      {
        if (this.Label.text == string.Empty)
        {
          this.RandomID = Random.Range(0, this.ParanoidReactions.Length);
          this.Label.text = this.ParanoidReactions[this.RandomID];
        }
      }
      else if (subtitleType == SubtitleType.TeacherWeaponReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherWeaponReactions.Length);
        this.Label.text = this.TeacherWeaponReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherBloodReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherBloodReactions.Length);
        this.Label.text = this.TeacherBloodReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherInsanityReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherInsanityReactions.Length);
        this.Label.text = this.TeacherInsanityReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherWeaponHostile)
      {
        this.RandomID = Random.Range(0, this.TeacherWeaponHostiles.Length);
        this.Label.text = this.TeacherWeaponHostiles[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherBloodHostile)
      {
        this.RandomID = Random.Range(0, this.TeacherBloodHostiles.Length);
        this.Label.text = this.TeacherBloodHostiles[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherInsanityHostile)
      {
        this.RandomID = Random.Range(0, this.TeacherInsanityHostiles.Length);
        this.Label.text = this.TeacherInsanityHostiles[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherCoverUpHostile)
      {
        this.RandomID = Random.Range(0, this.TeacherCoverUpHostiles.Length);
        this.Label.text = this.TeacherCoverUpHostiles[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherLewdReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherLewdReactions.Length);
        this.Label.text = this.TeacherLewdReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherTrespassingReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherTrespassReactions.Length);
        this.Label.text = this.TeacherTrespassReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.TeacherLateReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherLateReactions.Length);
        this.Label.text = this.TeacherLateReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.TeacherReportReaction)
      {
        this.Label.text = this.TeacherReportReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.TeacherCorpseReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherCorpseReactions.Length);
        this.Label.text = this.TeacherCorpseReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherCorpseInspection)
      {
        this.Label.text = this.TeacherCorpseInspections[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.TeacherPoliceReport)
      {
        this.Label.text = this.TeacherPoliceReports[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.TeacherAttackReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherAttackReactions.Length);
        this.Label.text = this.TeacherAttackReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherMurderReaction)
      {
        this.Label.text = this.TeacherMurderReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.TeacherPrankReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherPrankReactions.Length);
        this.Label.text = this.TeacherPrankReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TeacherTheftReaction)
      {
        this.RandomID = Random.Range(0, this.TeacherTheftReactions.Length);
        this.Label.text = this.TeacherTheftReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.TutorialReaction)
      {
        this.RandomID = Random.Range(0, this.TutorialReactions.Length);
        this.Label.text = this.TutorialReactions[this.RandomID];
        this.PlayVoice(subtitleType, 1);
      }
      else if (subtitleType == SubtitleType.TrespassReaction)
      {
        this.RandomID = Random.Range(0, this.TrespassReactions.Length);
        this.Label.text = this.TrespassReactions[this.RandomID];
        this.PlayVoice(subtitleType, 1);
      }
      else if (subtitleType == SubtitleType.DelinquentAnnoy)
      {
        this.Label.text = this.DelinquentAnnoys[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.DelinquentCase)
      {
        this.Label.text = this.DelinquentCases[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.DelinquentShove)
      {
        this.RandomID = Random.Range(0, this.DelinquentShoves.Length);
        this.Label.text = this.DelinquentShoves[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentReaction)
      {
        this.RandomID = Random.Range(0, this.DelinquentReactions.Length);
        this.Label.text = this.DelinquentReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentWeaponReaction)
      {
        this.RandomID = Random.Range(0, this.DelinquentWeaponReactions.Length);
        this.Label.text = this.DelinquentWeaponReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentThreatened)
      {
        this.RandomID = Random.Range(0, this.DelinquentThreateneds.Length);
        this.Label.text = this.DelinquentThreateneds[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentTaunt)
      {
        this.RandomID = Random.Range(0, this.DelinquentTaunts.Length);
        this.Label.text = this.DelinquentTaunts[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentCalm)
      {
        this.RandomID = Random.Range(0, this.DelinquentCalms.Length);
        this.Label.text = this.DelinquentCalms[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentFight)
      {
        this.RandomID = Random.Range(0, this.DelinquentFights.Length);
        this.Label.text = this.DelinquentFights[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentAvenge)
      {
        this.RandomID = Random.Range(0, this.DelinquentAvenges.Length);
        this.Label.text = this.DelinquentAvenges[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentWin)
      {
        this.RandomID = Random.Range(0, this.DelinquentWins.Length);
        this.Label.text = this.DelinquentWins[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentSurrender)
      {
        this.RandomID = Random.Range(0, this.DelinquentSurrenders.Length);
        this.Label.text = this.DelinquentSurrenders[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentNoSurrender)
      {
        this.RandomID = Random.Range(0, this.DelinquentNoSurrenders.Length);
        this.Label.text = this.DelinquentNoSurrenders[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentMurderReaction)
      {
        this.RandomID = Random.Range(0, this.DelinquentMurderReactions.Length);
        this.Label.text = this.DelinquentMurderReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentCorpseReaction)
      {
        this.RandomID = Random.Range(0, this.DelinquentCorpseReactions.Length);
        this.Label.text = this.DelinquentCorpseReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentFriendCorpseReaction)
      {
        this.RandomID = Random.Range(0, this.DelinquentFriendCorpseReactions.Length);
        this.Label.text = this.DelinquentFriendCorpseReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentResume)
      {
        this.RandomID = Random.Range(0, this.DelinquentResumes.Length);
        this.Label.text = this.DelinquentResumes[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentFlee)
      {
        this.RandomID = Random.Range(0, this.DelinquentFlees.Length);
        this.Label.text = this.DelinquentFlees[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentEnemyFlee)
      {
        this.RandomID = Random.Range(0, this.DelinquentEnemyFlees.Length);
        this.Label.text = this.DelinquentEnemyFlees[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentFriendFlee)
      {
        this.RandomID = Random.Range(0, this.DelinquentFriendFlees.Length);
        this.Label.text = this.DelinquentFriendFlees[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentInjuredFlee)
      {
        this.RandomID = Random.Range(0, this.DelinquentInjuredFlees.Length);
        this.Label.text = this.DelinquentInjuredFlees[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentCheer)
      {
        this.RandomID = Random.Range(0, this.DelinquentCheers.Length);
        this.Label.text = this.DelinquentCheers[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.DelinquentHmm)
      {
        if (this.Label.text == string.Empty)
        {
          this.RandomID = Random.Range(0, this.DelinquentHmms.Length);
          this.Label.text = this.DelinquentHmms[this.RandomID];
          this.PlayVoice(subtitleType, this.RandomID);
        }
      }
      else if (subtitleType == SubtitleType.DelinquentGrudge)
      {
        this.RandomID = Random.Range(0, this.DelinquentGrudges.Length);
        this.Label.text = this.DelinquentGrudges[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.Dismissive)
      {
        this.Label.text = this.Dismissives[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.LostPhone)
      {
        this.Label.text = this.LostPhones[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.RivalLostPhone)
      {
        this.Label.text = this.RivalLostPhones[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.MurderReaction)
        this.Label.text = this.GetRandomString(this.MurderReactions);
      else if (subtitleType == SubtitleType.CorpseReaction)
        this.Label.text = this.CorpseReactions[ID];
      else if (subtitleType == SubtitleType.CouncilCorpseReaction)
      {
        this.Label.text = this.CouncilCorpseReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.CouncilToCounselor)
      {
        this.Label.text = this.CouncilToCounselors[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.LonerMurderReaction)
        this.Label.text = this.GetRandomString(this.LonerMurderReactions);
      else if (subtitleType == SubtitleType.LonerCorpseReaction)
        this.Label.text = this.GetRandomString(this.LonerCorpseReactions);
      else if (subtitleType == SubtitleType.PetBloodReport)
        this.Label.text = this.PetBloodReports[ID];
      else if (subtitleType == SubtitleType.PetBloodReaction)
        this.Label.text = this.GetRandomString(this.PetBloodReactions);
      else if (subtitleType == SubtitleType.PetCorpseReport)
        this.Label.text = this.PetCorpseReports[ID];
      else if (subtitleType == SubtitleType.PetCorpseReaction)
        this.Label.text = this.GetRandomString(this.PetCorpseReactions);
      else if (subtitleType == SubtitleType.PetLimbReport)
        this.Label.text = this.PetLimbReports[ID];
      else if (subtitleType == SubtitleType.PetLimbReaction)
        this.Label.text = this.GetRandomString(this.PetLimbReactions);
      else if (subtitleType == SubtitleType.PetMurderReport)
        this.Label.text = this.PetMurderReports[ID];
      else if (subtitleType == SubtitleType.PetMurderReaction)
        this.Label.text = this.GetRandomString(this.PetMurderReactions);
      else if (subtitleType == SubtitleType.PetWeaponReport)
        this.Label.text = this.PetWeaponReports[ID];
      else if (subtitleType == SubtitleType.PetWeaponReaction)
        this.Label.text = this.PetWeaponReactions[ID];
      else if (subtitleType == SubtitleType.PetBloodyWeaponReport)
        this.Label.text = this.PetBloodyWeaponReports[ID];
      else if (subtitleType == SubtitleType.PetBloodyWeaponReaction)
        this.Label.text = this.GetRandomString(this.PetBloodyWeaponReactions);
      else if (subtitleType == SubtitleType.EvilCorpseReaction)
        this.Label.text = this.GetRandomString(this.EvilCorpseReactions);
      else if (subtitleType == SubtitleType.EvilDelinquentCorpseReaction)
      {
        this.RandomID = Random.Range(0, this.EvilDelinquentCorpseReactions.Length);
        this.Label.text = this.EvilDelinquentCorpseReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.HeroMurderReaction)
        this.Label.text = this.GetRandomString(this.HeroMurderReactions);
      else if (subtitleType == SubtitleType.CowardMurderReaction)
        this.Label.text = this.GetRandomString(this.CowardMurderReactions);
      else if (subtitleType == SubtitleType.EvilMurderReaction)
        this.Label.text = this.GetRandomString(this.EvilMurderReactions);
      else if (subtitleType == SubtitleType.SocialDeathReaction)
        this.Label.text = this.GetRandomString(this.SocialDeathReactions);
      else if (subtitleType == SubtitleType.LovestruckDeathReaction)
        this.Label.text = this.LovestruckDeathReactions[ID];
      else if (subtitleType == SubtitleType.LovestruckMurderReport)
        this.Label.text = this.LovestruckMurderReports[ID];
      else if (subtitleType == SubtitleType.LovestruckCorpseReport)
        this.Label.text = this.LovestruckCorpseReports[ID];
      else if (subtitleType == SubtitleType.SocialReport)
        this.Label.text = this.GetRandomString(this.SocialReports);
      else if (subtitleType == SubtitleType.SocialFear)
        this.Label.text = this.GetRandomString(this.SocialFears);
      else if (subtitleType == SubtitleType.SocialTerror)
        this.Label.text = this.GetRandomString(this.SocialTerrors);
      else if (subtitleType == SubtitleType.RepeatReaction)
        this.Label.text = this.GetRandomString(this.RepeatReactions);
      else if (subtitleType == SubtitleType.Greeting)
        this.Label.text = this.GetRandomString(this.Greetings);
      else if (subtitleType == SubtitleType.PlayerFarewell)
        this.Label.text = this.GetRandomString(this.PlayerFarewells);
      else if (subtitleType == SubtitleType.StudentFarewell)
        this.Label.text = this.GetRandomString(this.StudentFarewells);
      else if (subtitleType == SubtitleType.InsanityApology)
        this.Label.text = this.GetRandomString(this.InsanityApologies);
      else if (subtitleType == SubtitleType.WeaponAndBloodApology)
        this.Label.text = this.GetRandomString(this.WeaponBloodApologies);
      else if (subtitleType == SubtitleType.WeaponApology)
        this.Label.text = this.GetRandomString(this.WeaponApologies);
      else if (subtitleType == SubtitleType.BloodApology)
        this.Label.text = this.GetRandomString(this.BloodApologies);
      else if (subtitleType == SubtitleType.LewdApology)
        this.Label.text = this.GetRandomString(this.LewdApologies);
      else if (subtitleType == SubtitleType.SuspiciousApology)
        this.Label.text = this.GetRandomString(this.SuspiciousApologies);
      else if (subtitleType == SubtitleType.EavesdropApology)
        this.Label.text = this.GetRandomString(this.EavesdropApologies);
      else if (subtitleType == SubtitleType.ViolenceApology)
        this.Label.text = this.GetRandomString(this.ViolenceApologies);
      else if (subtitleType == SubtitleType.TheftApology)
        this.Label.text = this.GetRandomString(this.TheftApologies);
      else if (subtitleType == SubtitleType.EventApology)
        this.Label.text = this.GetRandomString(this.EventApologies);
      else if (subtitleType == SubtitleType.ClassApology)
        this.Label.text = this.GetRandomString(this.ClassApologies);
      else if (subtitleType == SubtitleType.AccidentApology)
        this.Label.text = this.GetRandomString(this.AccidentApologies);
      else if (subtitleType == SubtitleType.SadApology)
        this.Label.text = this.GetRandomString(this.SadApologies);
      else if (subtitleType == SubtitleType.TutorialApology)
      {
        this.Label.text = this.GetRandomString(this.TutorialApologies);
        this.PlayVoice(SubtitleType.TutorialReaction, 2);
      }
      else if (subtitleType == SubtitleType.TrespassApology)
        this.Label.text = this.GetRandomString(this.TrespassApologies);
      else if (subtitleType == SubtitleType.Dismissive)
        this.Label.text = this.Dismissives[ID];
      else if (subtitleType == SubtitleType.Forgiving)
        this.Label.text = this.GetRandomString(this.Forgivings);
      else if (subtitleType == SubtitleType.ForgivingAccident)
        this.Label.text = this.GetRandomString(this.AccidentForgivings);
      else if (subtitleType == SubtitleType.ForgivingInsanity)
        this.Label.text = this.GetRandomString(this.InsanityForgivings);
      else if (subtitleType == SubtitleType.ForgivingTrespass)
        this.Label.text = this.GetRandomString(this.TrespassForgivings);
      else if (subtitleType == SubtitleType.Impatience)
        this.Label.text = this.Impatiences[ID];
      else if (subtitleType == SubtitleType.PlayerCompliment)
        this.Label.text = this.GetRandomString(this.PlayerCompliments);
      else if (subtitleType == SubtitleType.StudentHighCompliment)
        this.Label.text = this.GetRandomString(this.StudentHighCompliments);
      else if (subtitleType == SubtitleType.StudentMidCompliment)
        this.Label.text = this.GetRandomString(this.StudentMidCompliments);
      else if (subtitleType == SubtitleType.StudentLowCompliment)
        this.Label.text = this.GetRandomString(this.StudentLowCompliments);
      else if (subtitleType == SubtitleType.PlayerGossip)
        this.Label.text = this.GetRandomString(this.PlayerGossip);
      else if (subtitleType == SubtitleType.StudentGossip)
        this.Label.text = this.GetRandomString(this.StudentGossip);
      else if (subtitleType == SubtitleType.PlayerFollow)
        this.Label.text = this.PlayerFollows[ID];
      else if (subtitleType == SubtitleType.StudentFollow)
        this.Label.text = this.StudentFollows[ID];
      else if (subtitleType == SubtitleType.PlayerLeave)
        this.Label.text = this.PlayerLeaves[ID];
      else if (subtitleType == SubtitleType.StudentLeave)
        this.Label.text = this.StudentLeaves[ID];
      else if (subtitleType == SubtitleType.StudentStay)
      {
        this.Label.text = this.StudentStays[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.PlayerDistract)
        this.Label.text = this.PlayerDistracts[ID];
      else if (subtitleType == SubtitleType.StudentDistract)
        this.Label.text = this.StudentDistracts[ID];
      else if (subtitleType == SubtitleType.StudentDistractRefuse)
        this.Label.text = this.GetRandomString(this.StudentDistractRefuses);
      else if (subtitleType == SubtitleType.StudentDistractBullyRefuse)
        this.Label.text = this.GetRandomString(this.StudentDistractBullyRefuses);
      else if (subtitleType == SubtitleType.StopFollowApology)
        this.Label.text = this.StopFollowApologies[ID];
      else if (subtitleType == SubtitleType.GrudgeWarning)
      {
        this.Label.text = this.GetRandomString(this.GrudgeWarnings);
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.GrudgeRefusal)
        this.Label.text = this.GetRandomString(this.GrudgeRefusals);
      else if (subtitleType == SubtitleType.CowardGrudge)
        this.Label.text = this.GetRandomString(this.CowardGrudges);
      else if (subtitleType == SubtitleType.EvilGrudge)
        this.Label.text = this.GetRandomString(this.EvilGrudges);
      else if (subtitleType == SubtitleType.PlayerLove)
        this.Label.text = this.PlayerLove[ID];
      else if (subtitleType == SubtitleType.SuitorLove)
        this.Label.text = this.SuitorLove[ID];
      else if (subtitleType == SubtitleType.RivalLove)
        this.Label.text = this.RivalLove[ID];
      else if (subtitleType == SubtitleType.RequestMedicine)
        this.Label.text = this.RequestMedicines[ID];
      else if (subtitleType == SubtitleType.ReturningWeapon)
        this.Label.text = this.ReturningWeapons[ID];
      else if (subtitleType == SubtitleType.Dying)
        this.Label.text = this.GetRandomString(this.Deaths);
      else if (subtitleType == SubtitleType.SenpaiInsanityReaction)
      {
        this.RandomID = Random.Range(0, this.SenpaiInsanityReactions.Length);
        this.Label.text = this.SenpaiInsanityReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.SenpaiWeaponReaction)
      {
        this.RandomID = Random.Range(0, this.SenpaiWeaponReactions.Length);
        this.Label.text = this.SenpaiWeaponReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.SenpaiBloodReaction)
      {
        this.RandomID = Random.Range(0, this.SenpaiBloodReactions.Length);
        this.Label.text = this.SenpaiBloodReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.SenpaiLewdReaction)
      {
        this.RandomID = Random.Range(0, this.SenpaiLewdReactions.Length);
        this.Label.text = this.SenpaiLewdReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.SenpaiStalkingReaction)
      {
        this.Label.text = this.SenpaiStalkingReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.SenpaiMurderReaction)
      {
        this.Label.text = this.SenpaiMurderReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.SenpaiCorpseReaction)
        this.Label.text = this.GetRandomString(this.SenpaiCorpseReactions);
      else if (subtitleType == SubtitleType.SenpaiViolenceReaction)
      {
        this.RandomID = Random.Range(0, this.SenpaiViolenceReactions.Length);
        this.Label.text = this.SenpaiViolenceReactions[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.SenpaiRivalDeathReaction)
      {
        this.Label.text = this.SenpaiRivalDeathReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.RaibaruRivalDeathReaction)
      {
        this.Label.text = this.RaibaruRivalDeathReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.OsanaObstacleDeathReaction)
      {
        this.Label.text = this.OsanaObstacleDeathReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.YandereWhimper)
      {
        this.RandomID = Random.Range(0, this.YandereWhimpers.Length);
        this.Label.text = this.YandereWhimpers[this.RandomID];
        this.PlayVoice(subtitleType, this.RandomID);
      }
      else if (subtitleType == SubtitleType.StudentMurderReport)
        this.Label.text = this.StudentMurderReports[ID];
      else if (subtitleType == SubtitleType.SplashReaction)
      {
        this.Label.text = this.SplashReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.SplashReactionMale)
      {
        this.Label.text = this.SplashReactionsMale[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.RivalSplashReaction)
      {
        this.Label.text = this.RivalSplashReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.LightSwitchReaction)
      {
        this.Label.text = this.LightSwitchReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.PhotoAnnoyance)
      {
        while (this.RandomID == this.PreviousRandom)
          this.RandomID = Random.Range(0, this.PhotoAnnoyances.Length);
        this.PreviousRandom = this.RandomID;
        this.Label.text = this.PhotoAnnoyances[this.RandomID];
      }
      else if (subtitleType == SubtitleType.Task6Line)
      {
        this.Label.text = this.Task6Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task7Line)
      {
        this.Label.text = this.Task7Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task8Line)
      {
        this.Label.text = this.Task8Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task11Line)
      {
        this.Label.text = this.Task11Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task13Line)
      {
        this.Label.text = this.Task13Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task14Line)
      {
        this.Label.text = this.Task14Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task15Line)
      {
        this.Label.text = this.Task15Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task25Line)
      {
        this.Label.text = this.Task25Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task28Line)
      {
        this.Label.text = this.Task28Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task30Line)
      {
        this.Label.text = this.Task30Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task32Line)
      {
        this.Label.text = this.Task32Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task33Line)
      {
        this.Label.text = this.Task33Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task34Line)
      {
        this.Label.text = this.Task34Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task36Line)
      {
        this.Label.text = this.Task36Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task37Line)
      {
        this.Label.text = this.Task37Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task38Line)
      {
        this.Label.text = this.Task38Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task46Line)
      {
        this.Label.text = this.Task46Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task47Line)
      {
        this.Label.text = this.Task47Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task48Line)
      {
        this.Label.text = this.Task48Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task49Line)
      {
        this.Label.text = this.Task49Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task50Line)
      {
        this.Label.text = this.Task50Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task52Line)
      {
        this.Label.text = this.Task52Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task76Line)
      {
        this.Label.text = this.Task76Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task77Line)
      {
        this.Label.text = this.Task77Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task78Line)
      {
        this.Label.text = this.Task78Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task79Line)
      {
        this.Label.text = this.Task79Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task80Line)
      {
        this.Label.text = this.Task80Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Task81Line)
      {
        this.Label.text = this.Task81Lines[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.TaskGenericLine)
      {
        this.Label.text = "(PLACEHOLDER TASK - WILL BE REPLACED IN FUTURE)\n" + this.TaskGenericLines[ID];
        if (this.Yandere.GetComponent<YandereScript>().TargetStudent.Male)
          this.PlayVoice(SubtitleType.TaskGenericLineMale, ID);
        else
          this.PlayVoice(SubtitleType.TaskGenericLineFemale, ID);
      }
      else if (subtitleType == SubtitleType.TaskGenericEightiesLine)
      {
        this.Label.text = "(PLACEHOLDER TASK - WILL BE REPLACED IN FUTURE)\n" + this.TaskGenericEightiesLines[ID];
        if (this.Yandere.GetComponent<YandereScript>().TargetStudent.Male)
          this.PlayVoice(SubtitleType.TaskGenericEightiesLineMale, ID);
        else
          this.PlayVoice(SubtitleType.TaskGenericEightiesLineFemale, ID);
      }
      else if (subtitleType == SubtitleType.TaskInquiry)
      {
        this.Label.text = this.TaskInquiries[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubGreeting)
      {
        this.Label.text = this.ClubGreetings[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubUnwelcome)
      {
        this.Label.text = this.ClubUnwelcomes[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubKick)
      {
        this.Label.text = this.ClubKicks[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubPractice)
      {
        this.Label.text = this.ClubPractices[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubPracticeYes)
      {
        this.Label.text = this.ClubPracticeYeses[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubPracticeNo)
      {
        this.Label.text = this.ClubPracticeNoes[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubPlaceholderInfo)
      {
        this.Label.text = this.Club0Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubCookingInfo)
      {
        this.Label.text = this.Club1Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubDramaInfo)
      {
        this.Label.text = this.Club2Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubOccultInfo)
      {
        this.Label.text = this.Club3Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubArtInfo)
      {
        this.Label.text = this.Club4Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubLightMusicInfo)
      {
        this.Label.text = this.Club5Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubMartialArtsInfo)
      {
        this.Label.text = this.Club6Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubPhotoInfoLight)
      {
        this.Label.text = this.Club7InfoLight[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubPhotoInfoDark)
      {
        this.Label.text = this.Club7InfoDark[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubScienceInfo)
      {
        this.Label.text = this.Club8Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubSportsInfo)
      {
        this.Label.text = this.Club9Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubGardenInfo)
      {
        this.Label.text = this.Club10Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubGamingInfo)
      {
        this.Label.text = this.Club11Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubDelinquentInfo)
      {
        this.Label.text = this.Club12Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubNewspaperInfo)
      {
        this.Label.text = this.Club13Info[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubJoin)
      {
        this.Label.text = this.ClubJoins[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubAccept)
      {
        this.Label.text = this.ClubAccepts[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubRefuse)
      {
        this.Label.text = this.ClubRefuses[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubRejoin)
      {
        this.Label.text = this.ClubRejoins[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubExclusive)
      {
        this.Label.text = this.ClubExclusives[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubGrudge)
      {
        this.Label.text = this.ClubGrudges[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubQuit)
      {
        this.Label.text = this.ClubQuits[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubConfirm)
      {
        this.Label.text = this.ClubConfirms[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubDeny)
      {
        this.Label.text = this.ClubDenies[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubFarewell)
      {
        this.Label.text = this.ClubFarewells[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubActivity)
      {
        this.Label.text = this.ClubActivities[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubEarly)
      {
        this.Label.text = this.ClubEarlies[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubLate)
      {
        this.Label.text = this.ClubLates[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubYes)
      {
        this.Label.text = this.ClubYeses[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ClubNo)
      {
        this.Label.text = this.ClubNoes[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.InfoNotice)
        this.Label.text = this.InfoNotice;
      else if (subtitleType == SubtitleType.StrictReport)
      {
        this.Label.text = this.StrictReport[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.CasualReport)
      {
        this.Label.text = this.CasualReport[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.GraceReport)
      {
        this.Label.text = this.GraceReport[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.EdgyReport)
      {
        this.Label.text = this.EdgyReport[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.BreakingUp)
      {
        this.Label.text = this.BreakingUp[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Shoving)
      {
        this.Label.text = this.Shoving[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Spraying)
      {
        this.Label.text = this.Spraying[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Chasing)
      {
        this.Label.text = this.Chasing[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Eulogy)
      {
        this.Label.text = this.Eulogies[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.AskForHelp)
        this.Label.text = this.AskForHelps[ID];
      else if (subtitleType == SubtitleType.GiveHelp)
        this.Label.text = this.GiveHelps[ID];
      else if (subtitleType == SubtitleType.RejectHelp)
        this.Label.text = this.RejectHelps[ID];
      else if (subtitleType == SubtitleType.ObstacleMurderReaction)
      {
        this.Label.text = this.ObstacleMurderReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.ObstaclePoisonReaction)
      {
        this.Label.text = this.ObstaclePoisonReactions[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.GasWarning)
      {
        this.Label.text = this.GasWarnings[ID];
        this.PlayVoice(subtitleType, ID);
      }
      else if (subtitleType == SubtitleType.Custom)
        this.Label.text = this.CustomText;
      this.PreviousSubtitle = subtitleType;
      this.PreviousStudentID = this.StudentID;
      this.Timer = Duration;
    }
  }

  private void Update()
  {
    if ((double) this.Timer <= 0.0)
      return;
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer > 0.0)
      return;
    this.Jukebox.Dip = 1f;
    this.Label.text = string.Empty;
    this.Timer = 0.0f;
  }

  private void PlayVoice(SubtitleType subtitleType, int ID)
  {
    if ((Object) this.CurrentClip != (Object) null)
      Object.Destroy((Object) this.CurrentClip);
    this.Jukebox.Dip = 0.5f;
    AudioClipArrayWrapper clipArrayWrapper;
    this.SubtitleClipArrays.TryGetValue(subtitleType, out clipArrayWrapper);
    if (ID < clipArrayWrapper.Length)
      this.PlayClip(clipArrayWrapper[ID], this.transform.position);
    else
      this.PlayClip(clipArrayWrapper[0], this.transform.position);
  }

  public float GetClipLength(int StudentID, int TaskPhase)
  {
    switch (StudentID)
    {
      case 6:
        return this.Task6Clips[TaskPhase].length + 0.5f;
      case 8:
        return this.Task8Clips[TaskPhase].length;
      case 11:
        return this.Task11Clips[TaskPhase].length;
      case 25:
        return this.Task25Clips[TaskPhase].length;
      case 28:
        return this.Task28Clips[TaskPhase].length;
      case 30:
        return this.Task30Clips[TaskPhase].length;
      case 36:
        return this.Task36Clips[TaskPhase].length;
      case 37:
        return this.Task37Clips[TaskPhase].length;
      case 38:
        return this.Task38Clips[TaskPhase].length;
      case 46:
        return this.Task46Clips[TaskPhase].length;
      case 47:
        return this.Task47Clips[TaskPhase].length;
      case 48:
        return this.Task48Clips[TaskPhase].length;
      case 49:
        return this.Task49Clips[TaskPhase].length;
      case 50:
        return this.Task50Clips[TaskPhase].length;
      case 52:
        return this.Task52Clips[TaskPhase].length;
      case 76:
        return this.Task76Clips[TaskPhase].length;
      case 77:
        return this.Task77Clips[TaskPhase].length;
      case 78:
        return this.Task78Clips[TaskPhase].length;
      case 79:
        return this.Task79Clips[TaskPhase].length;
      case 80:
        return this.Task80Clips[TaskPhase].length;
      case 81:
        return this.Task81Clips[TaskPhase].length;
      default:
        return !this.Yandere.GetComponent<YandereScript>().StudentManager.Eighties ? (this.Yandere.GetComponent<YandereScript>().TargetStudent.Male ? this.TaskGenericMaleClips[TaskPhase].length : this.TaskGenericFemaleClips[TaskPhase].length) : (this.Yandere.GetComponent<YandereScript>().TargetStudent.Male ? this.TaskGenericEightiesMaleClips[TaskPhase].length : this.TaskGenericEightiesFemaleClips[TaskPhase].length);
    }
  }

  public float GetClubClipLength(ClubType Club, int ClubPhase)
  {
    switch (Club)
    {
      case ClubType.Cooking:
        return this.Club1Clips[ClubPhase].length + 0.5f;
      case ClubType.Drama:
        return this.Club2Clips[ClubPhase].length + 0.5f;
      case ClubType.Occult:
        return this.Club3Clips[ClubPhase].length + 0.5f;
      case ClubType.Art:
        return this.Club4Clips[ClubPhase].length + 0.5f;
      case ClubType.LightMusic:
        return this.Club5Clips[ClubPhase].length + 0.5f;
      case ClubType.MartialArts:
        return this.Club6Clips[ClubPhase].length + 0.5f;
      case ClubType.Photography:
        return (double) SchoolGlobals.SchoolAtmosphere <= 0.800000011920929 ? this.Club7ClipsDark[ClubPhase].length + 0.5f : this.Club7ClipsLight[ClubPhase].length + 0.5f;
      case ClubType.Science:
        return this.Club8Clips[ClubPhase].length + 0.5f;
      case ClubType.Sports:
        return this.Club9Clips[ClubPhase].length + 0.5f;
      case ClubType.Gardening:
        return this.Club10Clips[ClubPhase].length + 0.5f;
      case ClubType.Gaming:
        return this.Club11Clips[ClubPhase].length + 0.5f;
      case ClubType.Delinquent:
        return this.Club12Clips[ClubPhase].length + 0.5f;
      case ClubType.Newspaper:
        return this.Club13Clips[ClubPhase].length + 0.5f;
      default:
        return 0.0f;
    }
  }

  private void PlayClip(AudioClip clip, Vector3 pos)
  {
    if ((Object) clip != (Object) null)
    {
      GameObject gameObject = new GameObject("TempAudio");
      if ((Object) this.Speaker != (Object) null)
      {
        gameObject.transform.position = this.Speaker.transform.position + this.transform.up;
        gameObject.transform.parent = this.Speaker.transform;
      }
      else
      {
        gameObject.transform.position = this.Yandere.transform.position + this.transform.up;
        gameObject.transform.parent = this.Yandere.transform;
      }
      AudioSource audioSource = gameObject.AddComponent<AudioSource>();
      audioSource.clip = clip;
      audioSource.Play();
      Object.Destroy((Object) gameObject, clip.length);
      audioSource.rolloffMode = AudioRolloffMode.Linear;
      audioSource.spatialBlend = 1f;
      audioSource.minDistance = 5f;
      audioSource.maxDistance = 15f;
      this.CurrentClip = gameObject;
      audioSource.volume = (double) this.Yandere.position.y < (double) gameObject.transform.position.y - 2.0 ? 0.0f : 1f;
      this.Speaker = (StudentScript) null;
    }
    else
      Debug.Log((object) "Could not play a voice line. The audio clip was null.");
  }

  public void Silence(AudioClip[] ClipArray)
  {
    for (int index = 0; index < 11; ++index)
    {
      if (index < ClipArray.Length)
        ClipArray[index] = this.LongestSilence;
    }
  }
}
