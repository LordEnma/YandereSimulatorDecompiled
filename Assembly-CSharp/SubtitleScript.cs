using System;
using UnityEngine;

// Token: 0x02000462 RID: 1122
public class SubtitleScript : MonoBehaviour
{
	// Token: 0x06001E7D RID: 7805 RVA: 0x001A15B8 File Offset: 0x0019F7B8
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
			for (int i = 1; i < 14; i++)
			{
				this.ClubGreetings[i] = "Hi! Thanks for visiting!";
				this.ClubUnwelcomes[i] = "I saw you kill someone. You can't just...pretend that nothing happened. I want you to leave. Now.";
				this.ClubKicks[i] = "Someone in the club has a big problem with you. I can't let you remain in the club. I'm very sorry about this...";
				this.ClubJoins[i] = "Oh! Would you like to join us?";
				this.ClubAccepts[i] = "That's great! Welcome to the club!";
				this.ClubRefuses[i] = "Aww, too bad. Let me know if you change your mind!";
				this.ClubRejoins[i] = "I'm sorry, I can't let you back into the club. You might leave us again, just like last time.";
				this.ClubExclusives[i] = "I'm sorry, you're already a member of another club. You'd have to leave them if you want to join us";
				this.ClubGrudges[i] = "I'm sorry...someone in our club has a big problem with you. I can't let you join.";
				this.ClubQuits[i] = "Uh-oh! Are you thinking about quitting the club?";
				this.ClubConfirms[i] = "Aww, that's too bad. I'm sad to see you go.";
				this.ClubDenies[i] = "Phew! I'm relieved to hear that!";
				this.ClubFarewells[i] = "Bye! See you around school!";
				this.ClubActivities[i] = "We're about to start our daily club activities! Would you like to join us?";
				this.ClubEarlies[i] = "I'm sorry, it's too early in the day for club activities. Please come back between 5:00 and 5:30!";
				this.ClubLates[i] = "I'm sorry, we're already done with club activities. To participate, you'd have to be here earlier than 5:30.";
				this.ClubYeses[i] = "Great! Let's get started!";
				this.ClubNoes[i] = "Okay. We can wait for you, but no longer than 5:30.";
				this.ClubGreetingClips[i] = this.LongestSilence;
				this.ClubUnwelcomeClips[i] = this.LongestSilence;
				this.ClubKickClips[i] = this.LongestSilence;
				this.ClubJoinClips[i] = this.LongestSilence;
				this.ClubAcceptClips[i] = this.LongestSilence;
				this.ClubRefuseClips[i] = this.LongestSilence;
				this.ClubRejoinClips[i] = this.LongestSilence;
				this.ClubExclusiveClips[i] = this.LongestSilence;
				this.ClubGrudgeClips[i] = this.LongestSilence;
				this.ClubQuitClips[i] = this.LongestSilence;
				this.ClubConfirmClips[i] = this.LongestSilence;
				this.ClubDenyClips[i] = this.LongestSilence;
				this.ClubFarewellClips[i] = this.LongestSilence;
				this.ClubActivityClips[i] = this.LongestSilence;
				this.ClubEarlyClips[i] = this.LongestSilence;
				this.ClubLateClips[i] = this.LongestSilence;
				this.ClubYesClips[i] = this.LongestSilence;
				this.ClubNoClips[i] = this.LongestSilence;
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
			for (int j = 1; j < 5; j++)
			{
				this.ShoveClips[j] = this.LongestSilence;
				this.ChaseClips[j] = this.LongestSilence;
				this.SprayClips[j] = this.LongestSilence;
				this.BreakUpClips[j] = this.LongestSilence;
				this.CouncilCorpseClips[j] = this.LongestSilence;
				this.CouncilCounselorClips[j] = this.LongestSilence;
				this.HmmClips[j] = this.LongestSilence;
			}
			for (int j = 1; j < 4; j++)
			{
				this.StrictReportClips[j] = this.LongestSilence;
				this.CasualReportClips[j] = this.LongestSilence;
				this.GraceReportClips[j] = this.LongestSilence;
				this.EdgyReportClips[j] = this.LongestSilence;
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
		this.SubtitleClipArrays = new SubtitleTypeAndAudioClipArrayDictionary
		{
			{
				SubtitleType.ClubAccept,
				new AudioClipArrayWrapper(this.ClubAcceptClips)
			},
			{
				SubtitleType.ClubActivity,
				new AudioClipArrayWrapper(this.ClubActivityClips)
			},
			{
				SubtitleType.ClubConfirm,
				new AudioClipArrayWrapper(this.ClubConfirmClips)
			},
			{
				SubtitleType.ClubDeny,
				new AudioClipArrayWrapper(this.ClubDenyClips)
			},
			{
				SubtitleType.ClubEarly,
				new AudioClipArrayWrapper(this.ClubEarlyClips)
			},
			{
				SubtitleType.ClubExclusive,
				new AudioClipArrayWrapper(this.ClubExclusiveClips)
			},
			{
				SubtitleType.ClubFarewell,
				new AudioClipArrayWrapper(this.ClubFarewellClips)
			},
			{
				SubtitleType.ClubGreeting,
				new AudioClipArrayWrapper(this.ClubGreetingClips)
			},
			{
				SubtitleType.ClubGrudge,
				new AudioClipArrayWrapper(this.ClubGrudgeClips)
			},
			{
				SubtitleType.ClubJoin,
				new AudioClipArrayWrapper(this.ClubJoinClips)
			},
			{
				SubtitleType.ClubKick,
				new AudioClipArrayWrapper(this.ClubKickClips)
			},
			{
				SubtitleType.ClubLate,
				new AudioClipArrayWrapper(this.ClubLateClips)
			},
			{
				SubtitleType.ClubNo,
				new AudioClipArrayWrapper(this.ClubNoClips)
			},
			{
				SubtitleType.ClubPlaceholderInfo,
				new AudioClipArrayWrapper(this.Club0Clips)
			},
			{
				SubtitleType.ClubCookingInfo,
				new AudioClipArrayWrapper(this.Club1Clips)
			},
			{
				SubtitleType.ClubDramaInfo,
				new AudioClipArrayWrapper(this.Club2Clips)
			},
			{
				SubtitleType.ClubOccultInfo,
				new AudioClipArrayWrapper(this.Club3Clips)
			},
			{
				SubtitleType.ClubArtInfo,
				new AudioClipArrayWrapper(this.Club4Clips)
			},
			{
				SubtitleType.ClubLightMusicInfo,
				new AudioClipArrayWrapper(this.Club5Clips)
			},
			{
				SubtitleType.ClubMartialArtsInfo,
				new AudioClipArrayWrapper(this.Club6Clips)
			},
			{
				SubtitleType.ClubPhotoInfoLight,
				new AudioClipArrayWrapper(this.Club7ClipsLight)
			},
			{
				SubtitleType.ClubPhotoInfoDark,
				new AudioClipArrayWrapper(this.Club7ClipsDark)
			},
			{
				SubtitleType.ClubScienceInfo,
				new AudioClipArrayWrapper(this.Club8Clips)
			},
			{
				SubtitleType.ClubSportsInfo,
				new AudioClipArrayWrapper(this.Club9Clips)
			},
			{
				SubtitleType.ClubGardenInfo,
				new AudioClipArrayWrapper(this.Club10Clips)
			},
			{
				SubtitleType.ClubGamingInfo,
				new AudioClipArrayWrapper(this.Club11Clips)
			},
			{
				SubtitleType.ClubDelinquentInfo,
				new AudioClipArrayWrapper(this.Club12Clips)
			},
			{
				SubtitleType.ClubNewspaperInfo,
				new AudioClipArrayWrapper(this.Club13Clips)
			},
			{
				SubtitleType.ClubQuit,
				new AudioClipArrayWrapper(this.ClubQuitClips)
			},
			{
				SubtitleType.ClubRefuse,
				new AudioClipArrayWrapper(this.ClubRefuseClips)
			},
			{
				SubtitleType.ClubRejoin,
				new AudioClipArrayWrapper(this.ClubRejoinClips)
			},
			{
				SubtitleType.ClubUnwelcome,
				new AudioClipArrayWrapper(this.ClubUnwelcomeClips)
			},
			{
				SubtitleType.ClubYes,
				new AudioClipArrayWrapper(this.ClubYesClips)
			},
			{
				SubtitleType.ClubPractice,
				new AudioClipArrayWrapper(this.ClubPracticeClips)
			},
			{
				SubtitleType.ClubPracticeYes,
				new AudioClipArrayWrapper(this.ClubPracticeYesClips)
			},
			{
				SubtitleType.ClubPracticeNo,
				new AudioClipArrayWrapper(this.ClubPracticeNoClips)
			},
			{
				SubtitleType.DrownReaction,
				new AudioClipArrayWrapper(this.DrownReactionClips)
			},
			{
				SubtitleType.EavesdropReaction,
				new AudioClipArrayWrapper(this.EavesdropClips)
			},
			{
				SubtitleType.RejectFood,
				new AudioClipArrayWrapper(this.FoodRejectionClips)
			},
			{
				SubtitleType.ViolenceReaction,
				new AudioClipArrayWrapper(this.ViolenceClips)
			},
			{
				SubtitleType.EventEavesdropReaction,
				new AudioClipArrayWrapper(this.EventEavesdropClips)
			},
			{
				SubtitleType.RivalEavesdropReaction,
				new AudioClipArrayWrapper(this.RivalEavesdropClips)
			},
			{
				SubtitleType.GrudgeWarning,
				new AudioClipArrayWrapper(this.GrudgeWarningClips)
			},
			{
				SubtitleType.LightSwitchReaction,
				new AudioClipArrayWrapper(this.LightSwitchClips)
			},
			{
				SubtitleType.LostPhone,
				new AudioClipArrayWrapper(this.LostPhoneClips)
			},
			{
				SubtitleType.NoteReaction,
				new AudioClipArrayWrapper(this.NoteReactionClips)
			},
			{
				SubtitleType.NoteReactionMale,
				new AudioClipArrayWrapper(this.NoteReactionMaleClips)
			},
			{
				SubtitleType.PickpocketReaction,
				new AudioClipArrayWrapper(this.PickpocketReactionClips)
			},
			{
				SubtitleType.RivalLostPhone,
				new AudioClipArrayWrapper(this.RivalLostPhoneClips)
			},
			{
				SubtitleType.RivalPickpocketReaction,
				new AudioClipArrayWrapper(this.RivalPickpocketReactionClips)
			},
			{
				SubtitleType.RivalSplashReaction,
				new AudioClipArrayWrapper(this.RivalSplashReactionClips)
			},
			{
				SubtitleType.SenpaiBloodReaction,
				new AudioClipArrayWrapper(this.SenpaiBloodReactionClips)
			},
			{
				SubtitleType.SenpaiInsanityReaction,
				new AudioClipArrayWrapper(this.SenpaiInsanityReactionClips)
			},
			{
				SubtitleType.SenpaiLewdReaction,
				new AudioClipArrayWrapper(this.SenpaiLewdReactionClips)
			},
			{
				SubtitleType.SenpaiMurderReaction,
				new AudioClipArrayWrapper(this.SenpaiMurderReactionClips)
			},
			{
				SubtitleType.SenpaiStalkingReaction,
				new AudioClipArrayWrapper(this.SenpaiStalkingReactionClips)
			},
			{
				SubtitleType.SenpaiWeaponReaction,
				new AudioClipArrayWrapper(this.SenpaiWeaponReactionClips)
			},
			{
				SubtitleType.SenpaiViolenceReaction,
				new AudioClipArrayWrapper(this.SenpaiViolenceReactionClips)
			},
			{
				SubtitleType.SenpaiRivalDeathReaction,
				new AudioClipArrayWrapper(this.SenpaiRivalDeathReactionClips)
			},
			{
				SubtitleType.RaibaruRivalDeathReaction,
				new AudioClipArrayWrapper(this.RaibaruRivalDeathReactionClips)
			},
			{
				SubtitleType.OsanaObstacleDeathReaction,
				new AudioClipArrayWrapper(this.OsanaObstacleDeathReactionClips)
			},
			{
				SubtitleType.SplashReaction,
				new AudioClipArrayWrapper(this.SplashReactionClips)
			},
			{
				SubtitleType.SplashReactionMale,
				new AudioClipArrayWrapper(this.SplashReactionMaleClips)
			},
			{
				SubtitleType.TutorialReaction,
				new AudioClipArrayWrapper(this.TutorialReactionClips)
			},
			{
				SubtitleType.Task6Line,
				new AudioClipArrayWrapper(this.Task6Clips)
			},
			{
				SubtitleType.Task7Line,
				new AudioClipArrayWrapper(this.Task7Clips)
			},
			{
				SubtitleType.Task8Line,
				new AudioClipArrayWrapper(this.Task8Clips)
			},
			{
				SubtitleType.Task11Line,
				new AudioClipArrayWrapper(this.Task11Clips)
			},
			{
				SubtitleType.Task13Line,
				new AudioClipArrayWrapper(this.Task13Clips)
			},
			{
				SubtitleType.Task14Line,
				new AudioClipArrayWrapper(this.Task14Clips)
			},
			{
				SubtitleType.Task15Line,
				new AudioClipArrayWrapper(this.Task15Clips)
			},
			{
				SubtitleType.Task25Line,
				new AudioClipArrayWrapper(this.Task25Clips)
			},
			{
				SubtitleType.Task28Line,
				new AudioClipArrayWrapper(this.Task28Clips)
			},
			{
				SubtitleType.Task30Line,
				new AudioClipArrayWrapper(this.Task30Clips)
			},
			{
				SubtitleType.Task34Line,
				new AudioClipArrayWrapper(this.Task34Clips)
			},
			{
				SubtitleType.Task36Line,
				new AudioClipArrayWrapper(this.Task36Clips)
			},
			{
				SubtitleType.Task37Line,
				new AudioClipArrayWrapper(this.Task37Clips)
			},
			{
				SubtitleType.Task38Line,
				new AudioClipArrayWrapper(this.Task38Clips)
			},
			{
				SubtitleType.Task46Line,
				new AudioClipArrayWrapper(this.Task46Clips)
			},
			{
				SubtitleType.Task47Line,
				new AudioClipArrayWrapper(this.Task47Clips)
			},
			{
				SubtitleType.Task48Line,
				new AudioClipArrayWrapper(this.Task48Clips)
			},
			{
				SubtitleType.Task49Line,
				new AudioClipArrayWrapper(this.Task49Clips)
			},
			{
				SubtitleType.Task50Line,
				new AudioClipArrayWrapper(this.Task50Clips)
			},
			{
				SubtitleType.Task52Line,
				new AudioClipArrayWrapper(this.Task52Clips)
			},
			{
				SubtitleType.Task76Line,
				new AudioClipArrayWrapper(this.Task76Clips)
			},
			{
				SubtitleType.Task77Line,
				new AudioClipArrayWrapper(this.Task77Clips)
			},
			{
				SubtitleType.Task78Line,
				new AudioClipArrayWrapper(this.Task78Clips)
			},
			{
				SubtitleType.Task79Line,
				new AudioClipArrayWrapper(this.Task79Clips)
			},
			{
				SubtitleType.Task80Line,
				new AudioClipArrayWrapper(this.Task80Clips)
			},
			{
				SubtitleType.Task81Line,
				new AudioClipArrayWrapper(this.Task81Clips)
			},
			{
				SubtitleType.TaskGenericLineMale,
				new AudioClipArrayWrapper(this.TaskGenericMaleClips)
			},
			{
				SubtitleType.TaskGenericLineFemale,
				new AudioClipArrayWrapper(this.TaskGenericFemaleClips)
			},
			{
				SubtitleType.TaskGenericEightiesLineMale,
				new AudioClipArrayWrapper(this.TaskGenericEightiesMaleClips)
			},
			{
				SubtitleType.TaskGenericEightiesLineFemale,
				new AudioClipArrayWrapper(this.TaskGenericEightiesFemaleClips)
			},
			{
				SubtitleType.TaskInquiry,
				new AudioClipArrayWrapper(this.TaskInquiryClips)
			},
			{
				SubtitleType.TheftReaction,
				new AudioClipArrayWrapper(this.TheftClips)
			},
			{
				SubtitleType.TeacherAttackReaction,
				new AudioClipArrayWrapper(this.TeacherAttackClips)
			},
			{
				SubtitleType.TeacherBloodHostile,
				new AudioClipArrayWrapper(this.TeacherBloodHostileClips)
			},
			{
				SubtitleType.TeacherBloodReaction,
				new AudioClipArrayWrapper(this.TeacherBloodClips)
			},
			{
				SubtitleType.TeacherCorpseInspection,
				new AudioClipArrayWrapper(this.TeacherInspectClips)
			},
			{
				SubtitleType.TeacherCorpseReaction,
				new AudioClipArrayWrapper(this.TeacherCorpseClips)
			},
			{
				SubtitleType.TeacherInsanityHostile,
				new AudioClipArrayWrapper(this.TeacherInsanityHostileClips)
			},
			{
				SubtitleType.TeacherInsanityReaction,
				new AudioClipArrayWrapper(this.TeacherInsanityClips)
			},
			{
				SubtitleType.TeacherLateReaction,
				new AudioClipArrayWrapper(this.TeacherLateClips)
			},
			{
				SubtitleType.TeacherLewdReaction,
				new AudioClipArrayWrapper(this.TeacherLewdClips)
			},
			{
				SubtitleType.TeacherMurderReaction,
				new AudioClipArrayWrapper(this.TeacherMurderClips)
			},
			{
				SubtitleType.TeacherPoliceReport,
				new AudioClipArrayWrapper(this.TeacherPoliceClips)
			},
			{
				SubtitleType.TeacherPrankReaction,
				new AudioClipArrayWrapper(this.TeacherPrankClips)
			},
			{
				SubtitleType.TeacherReportReaction,
				new AudioClipArrayWrapper(this.TeacherReportClips)
			},
			{
				SubtitleType.TeacherTheftReaction,
				new AudioClipArrayWrapper(this.TeacherTheftClips)
			},
			{
				SubtitleType.TeacherTrespassingReaction,
				new AudioClipArrayWrapper(this.TeacherTrespassClips)
			},
			{
				SubtitleType.TeacherWeaponHostile,
				new AudioClipArrayWrapper(this.TeacherWeaponHostileClips)
			},
			{
				SubtitleType.TeacherWeaponReaction,
				new AudioClipArrayWrapper(this.TeacherWeaponClips)
			},
			{
				SubtitleType.TeacherCoverUpHostile,
				new AudioClipArrayWrapper(this.TeacherCoverUpHostileClips)
			},
			{
				SubtitleType.YandereWhimper,
				new AudioClipArrayWrapper(this.YandereWhimperClips)
			},
			{
				SubtitleType.DelinquentAnnoy,
				new AudioClipArrayWrapper(this.DelinquentAnnoyClips)
			},
			{
				SubtitleType.DelinquentCase,
				new AudioClipArrayWrapper(this.DelinquentCaseClips)
			},
			{
				SubtitleType.DelinquentShove,
				new AudioClipArrayWrapper(this.DelinquentShoveClips)
			},
			{
				SubtitleType.DelinquentReaction,
				new AudioClipArrayWrapper(this.DelinquentReactionClips)
			},
			{
				SubtitleType.DelinquentWeaponReaction,
				new AudioClipArrayWrapper(this.DelinquentWeaponReactionClips)
			},
			{
				SubtitleType.DelinquentThreatened,
				new AudioClipArrayWrapper(this.DelinquentThreatenedClips)
			},
			{
				SubtitleType.DelinquentTaunt,
				new AudioClipArrayWrapper(this.DelinquentTauntClips)
			},
			{
				SubtitleType.DelinquentCalm,
				new AudioClipArrayWrapper(this.DelinquentCalmClips)
			},
			{
				SubtitleType.DelinquentFight,
				new AudioClipArrayWrapper(this.DelinquentFightClips)
			},
			{
				SubtitleType.DelinquentAvenge,
				new AudioClipArrayWrapper(this.DelinquentAvengeClips)
			},
			{
				SubtitleType.DelinquentWin,
				new AudioClipArrayWrapper(this.DelinquentWinClips)
			},
			{
				SubtitleType.DelinquentSurrender,
				new AudioClipArrayWrapper(this.DelinquentSurrenderClips)
			},
			{
				SubtitleType.DelinquentNoSurrender,
				new AudioClipArrayWrapper(this.DelinquentNoSurrenderClips)
			},
			{
				SubtitleType.DelinquentMurderReaction,
				new AudioClipArrayWrapper(this.DelinquentMurderReactionClips)
			},
			{
				SubtitleType.DelinquentCorpseReaction,
				new AudioClipArrayWrapper(this.DelinquentCorpseReactionClips)
			},
			{
				SubtitleType.DelinquentFriendCorpseReaction,
				new AudioClipArrayWrapper(this.DelinquentFriendCorpseReactionClips)
			},
			{
				SubtitleType.DelinquentResume,
				new AudioClipArrayWrapper(this.DelinquentResumeClips)
			},
			{
				SubtitleType.DelinquentFlee,
				new AudioClipArrayWrapper(this.DelinquentFleeClips)
			},
			{
				SubtitleType.DelinquentEnemyFlee,
				new AudioClipArrayWrapper(this.DelinquentEnemyFleeClips)
			},
			{
				SubtitleType.DelinquentFriendFlee,
				new AudioClipArrayWrapper(this.DelinquentFriendFleeClips)
			},
			{
				SubtitleType.DelinquentInjuredFlee,
				new AudioClipArrayWrapper(this.DelinquentInjuredFleeClips)
			},
			{
				SubtitleType.DelinquentCheer,
				new AudioClipArrayWrapper(this.DelinquentCheerClips)
			},
			{
				SubtitleType.DelinquentHmm,
				new AudioClipArrayWrapper(this.DelinquentHmmClips)
			},
			{
				SubtitleType.DelinquentGrudge,
				new AudioClipArrayWrapper(this.DelinquentGrudgeClips)
			},
			{
				SubtitleType.Dismissive,
				new AudioClipArrayWrapper(this.DismissiveClips)
			},
			{
				SubtitleType.EvilDelinquentCorpseReaction,
				new AudioClipArrayWrapper(this.EvilDelinquentCorpseReactionClips)
			},
			{
				SubtitleType.Eulogy,
				new AudioClipArrayWrapper(this.EulogyClips)
			},
			{
				SubtitleType.GasWarning,
				new AudioClipArrayWrapper(this.GasWarningClips)
			},
			{
				SubtitleType.StudentStay,
				new AudioClipArrayWrapper(this.StudentStayClips)
			},
			{
				SubtitleType.StrictReport,
				new AudioClipArrayWrapper(this.StrictReportClips)
			},
			{
				SubtitleType.CasualReport,
				new AudioClipArrayWrapper(this.CasualReportClips)
			},
			{
				SubtitleType.GraceReport,
				new AudioClipArrayWrapper(this.GraceReportClips)
			},
			{
				SubtitleType.EdgyReport,
				new AudioClipArrayWrapper(this.EdgyReportClips)
			},
			{
				SubtitleType.BreakingUp,
				new AudioClipArrayWrapper(this.BreakUpClips)
			},
			{
				SubtitleType.Chasing,
				new AudioClipArrayWrapper(this.ChaseClips)
			},
			{
				SubtitleType.Shoving,
				new AudioClipArrayWrapper(this.ShoveClips)
			},
			{
				SubtitleType.Spraying,
				new AudioClipArrayWrapper(this.SprayClips)
			},
			{
				SubtitleType.CouncilCorpseReaction,
				new AudioClipArrayWrapper(this.CouncilCorpseClips)
			},
			{
				SubtitleType.CouncilToCounselor,
				new AudioClipArrayWrapper(this.CouncilCounselorClips)
			},
			{
				SubtitleType.HmmReaction,
				new AudioClipArrayWrapper(this.HmmClips)
			},
			{
				SubtitleType.ObstacleMurderReaction,
				new AudioClipArrayWrapper(this.ObstacleMurderReactionClips)
			},
			{
				SubtitleType.ObstaclePoisonReaction,
				new AudioClipArrayWrapper(this.ObstaclePoisonReactionClips)
			}
		};
	}

	// Token: 0x06001E7E RID: 7806 RVA: 0x001A2DA9 File Offset: 0x001A0FA9
	private void Start()
	{
		this.Label.text = string.Empty;
	}

	// Token: 0x06001E7F RID: 7807 RVA: 0x001A2DBB File Offset: 0x001A0FBB
	private string GetRandomString(string[] strings)
	{
		return strings[UnityEngine.Random.Range(0, strings.Length)];
	}

	// Token: 0x06001E80 RID: 7808 RVA: 0x001A2DC8 File Offset: 0x001A0FC8
	public void UpdateLabel(SubtitleType subtitleType, int ID, float Duration)
	{
		if (!this.Jukebox.Yandere.Talking && subtitleType == this.PreviousSubtitle && this.Timer > 0f)
		{
			Debug.Log("A character is attempting to say a subtitle that another character is already saying: " + subtitleType.ToString());
			return;
		}
		if (subtitleType == SubtitleType.WeaponAndBloodAndInsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodInsanityReactions);
		}
		else if (subtitleType == SubtitleType.WeaponAndBloodReaction)
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodReactions);
		}
		else if (subtitleType == SubtitleType.WeaponAndInsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.WeaponInsanityReactions);
		}
		else if (subtitleType == SubtitleType.BloodAndInsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.BloodInsanityReactions);
		}
		else if (subtitleType == SubtitleType.WeaponReaction)
		{
			if (ID == 1)
			{
				this.Label.text = this.GetRandomString(this.KnifeReactions);
			}
			else if (ID == 2)
			{
				this.Label.text = this.GetRandomString(this.KatanaReactions);
			}
			else if (ID == 3)
			{
				this.Label.text = this.GetRandomString(this.SyringeReactions);
			}
			else if (ID == 7)
			{
				this.Label.text = this.GetRandomString(this.SawReactions);
			}
			else if (ID == 8)
			{
				if (this.StudentID < 31 || this.StudentID > 35)
				{
					this.Label.text = this.RitualReactions[0];
				}
				else
				{
					this.Label.text = this.RitualReactions[1];
				}
			}
			else if (ID == 9)
			{
				this.Label.text = this.GetRandomString(this.BatReactions);
			}
			else if (ID == 10)
			{
				this.Label.text = this.GetRandomString(this.ShovelReactions);
			}
			else if (ID == 11 || ID == 14 || ID == 16 || ID == 17 || ID == 22)
			{
				this.Label.text = this.GetRandomString(this.PropReactions);
			}
			else if (ID == 12)
			{
				this.Label.text = this.GetRandomString(this.DumbbellReactions);
			}
			else if (ID == 13 || ID == 15)
			{
				this.Label.text = this.GetRandomString(this.AxeReactions);
			}
			else if (ID > 17 && ID < 22)
			{
				this.Label.text = this.GetRandomString(this.DelinkWeaponReactions);
			}
			else if (ID == 23)
			{
				this.Label.text = this.GetRandomString(this.ExtinguisherReactions);
			}
			else if (ID == 24)
			{
				this.Label.text = this.GetRandomString(this.WrenchReactions);
			}
			else if (ID == 25)
			{
				this.Label.text = this.GetRandomString(this.GuitarReactions);
			}
			else if (ID == 28)
			{
				this.Label.text = this.GetRandomString(this.ScrapReactions);
			}
		}
		else if (subtitleType == SubtitleType.BloodReaction)
		{
			this.Label.text = this.GetRandomString(this.BloodReactions);
		}
		else if (subtitleType == SubtitleType.BloodPoolReaction)
		{
			this.Label.text = this.BloodPoolReactions[ID];
		}
		else if (subtitleType == SubtitleType.BloodyWeaponReaction)
		{
			this.Label.text = this.BloodyWeaponReactions[ID];
		}
		else if (subtitleType == SubtitleType.LimbReaction)
		{
			this.Label.text = this.LimbReactions[ID];
		}
		else if (subtitleType == SubtitleType.WetBloodReaction)
		{
			this.Label.text = this.GetRandomString(this.WetBloodReactions);
		}
		else if (subtitleType == SubtitleType.InsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.InsanityReactions);
		}
		else if (subtitleType == SubtitleType.LewdReaction)
		{
			this.Label.text = this.GetRandomString(this.LewdReactions);
		}
		else if (subtitleType == SubtitleType.SuspiciousReaction)
		{
			this.Label.text = this.SuspiciousReactions[ID];
		}
		else if (subtitleType == SubtitleType.PoisonReaction)
		{
			this.Label.text = this.PoisonReactions[ID];
		}
		else if (subtitleType == SubtitleType.PrankReaction)
		{
			this.Label.text = this.GetRandomString(this.PrankReactions);
		}
		else if (subtitleType == SubtitleType.InterruptionReaction)
		{
			this.Label.text = this.InterruptReactions[ID];
		}
		else if (subtitleType == SubtitleType.IntrusionReaction)
		{
			this.Label.text = this.GetRandomString(this.IntrusionReactions);
		}
		else if (subtitleType == SubtitleType.TheftReaction)
		{
			this.Label.text = this.TheftReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.KilledMood)
		{
			this.Label.text = this.GetRandomString(this.KilledMoods);
		}
		else if (subtitleType == SubtitleType.SendToLocker)
		{
			this.Label.text = this.SendToLockers[ID];
		}
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
		{
			this.Label.text = this.OfferSnacks[ID];
		}
		else if (subtitleType == SubtitleType.AcceptFood)
		{
			this.Label.text = this.GetRandomString(this.FoodAccepts);
		}
		else if (subtitleType == SubtitleType.RejectFood)
		{
			this.Label.text = this.FoodRejects[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.EavesdropReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.EavesdropReactions.Length);
			this.Label.text = this.EavesdropReactions[this.RandomID];
		}
		else if (subtitleType == SubtitleType.ViolenceReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.ViolenceReactions.Length);
			this.Label.text = this.ViolenceReactions[this.RandomID];
		}
		else if (subtitleType == SubtitleType.EventEavesdropReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.EventEavesdropReactions.Length);
			this.Label.text = this.EventEavesdropReactions[this.RandomID];
		}
		else if (subtitleType == SubtitleType.RivalEavesdropReaction)
		{
			Debug.Log("Rival eavesdrop reaction. ID is: " + ID.ToString());
			this.Label.text = this.RivalEavesdropReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.PickpocketReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.PickpocketReactions.Length);
			this.Label.text = this.PickpocketReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.PickpocketApology)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.PickpocketApologies.Length);
			this.Label.text = this.PickpocketApologies[this.RandomID];
		}
		else if (subtitleType == SubtitleType.CleaningApology)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.CleaningApologies.Length);
			this.Label.text = this.CleaningApologies[this.RandomID];
		}
		else if (subtitleType == SubtitleType.PoisonApology)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.PoisonApologies.Length);
			this.Label.text = this.PoisonApologies[this.RandomID];
		}
		else if (subtitleType == SubtitleType.HoldingBloodyClothingApology)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.HoldingBloodyClothingApologies.Length);
			this.Label.text = this.HoldingBloodyClothingApologies[this.RandomID];
		}
		else if (subtitleType == SubtitleType.RivalPickpocketReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.RivalPickpocketReactions.Length);
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
				this.RandomID = UnityEngine.Random.Range(0, this.HmmReactions.Length);
				this.Label.text = this.HmmReactions[this.RandomID];
				this.PlayVoice(subtitleType, ID);
			}
		}
		else if (subtitleType == SubtitleType.HoldingBloodyClothingReaction)
		{
			if (this.Label.text == string.Empty)
			{
				this.RandomID = UnityEngine.Random.Range(0, this.HoldingBloodyClothingReactions.Length);
				this.Label.text = this.HoldingBloodyClothingReactions[this.RandomID];
			}
		}
		else if (subtitleType == SubtitleType.ParanoidReaction)
		{
			if (this.Label.text == string.Empty)
			{
				this.RandomID = UnityEngine.Random.Range(0, this.ParanoidReactions.Length);
				this.Label.text = this.ParanoidReactions[this.RandomID];
			}
		}
		else if (subtitleType == SubtitleType.TeacherWeaponReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponReactions.Length);
			this.Label.text = this.TeacherWeaponReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherBloodReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodReactions.Length);
			this.Label.text = this.TeacherBloodReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherInsanityReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityReactions.Length);
			this.Label.text = this.TeacherInsanityReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherWeaponHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponHostiles.Length);
			this.Label.text = this.TeacherWeaponHostiles[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherBloodHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodHostiles.Length);
			this.Label.text = this.TeacherBloodHostiles[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherInsanityHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityHostiles.Length);
			this.Label.text = this.TeacherInsanityHostiles[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherCoverUpHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherCoverUpHostiles.Length);
			this.Label.text = this.TeacherCoverUpHostiles[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherLewdReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherLewdReactions.Length);
			this.Label.text = this.TeacherLewdReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherTrespassingReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherTrespassReactions.Length);
			this.Label.text = this.TeacherTrespassReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.TeacherLateReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherLateReactions.Length);
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
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherCorpseReactions.Length);
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
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherAttackReactions.Length);
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
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherPrankReactions.Length);
			this.Label.text = this.TeacherPrankReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherTheftReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherTheftReactions.Length);
			this.Label.text = this.TeacherTheftReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TutorialReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TutorialReactions.Length);
			this.Label.text = this.TutorialReactions[this.RandomID];
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
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentShoves.Length);
			this.Label.text = this.DelinquentShoves[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentReactions.Length);
			this.Label.text = this.DelinquentReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentWeaponReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentWeaponReactions.Length);
			this.Label.text = this.DelinquentWeaponReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentThreatened)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentThreateneds.Length);
			this.Label.text = this.DelinquentThreateneds[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentTaunt)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentTaunts.Length);
			this.Label.text = this.DelinquentTaunts[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentCalm)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentCalms.Length);
			this.Label.text = this.DelinquentCalms[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentFight)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentFights.Length);
			this.Label.text = this.DelinquentFights[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentAvenge)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentAvenges.Length);
			this.Label.text = this.DelinquentAvenges[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentWin)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentWins.Length);
			this.Label.text = this.DelinquentWins[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentSurrender)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentSurrenders.Length);
			this.Label.text = this.DelinquentSurrenders[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentNoSurrender)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentNoSurrenders.Length);
			this.Label.text = this.DelinquentNoSurrenders[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentMurderReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentMurderReactions.Length);
			this.Label.text = this.DelinquentMurderReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentCorpseReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentCorpseReactions.Length);
			this.Label.text = this.DelinquentCorpseReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentFriendCorpseReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentFriendCorpseReactions.Length);
			this.Label.text = this.DelinquentFriendCorpseReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentResume)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentResumes.Length);
			this.Label.text = this.DelinquentResumes[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentFlee)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentFlees.Length);
			this.Label.text = this.DelinquentFlees[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentEnemyFlee)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentEnemyFlees.Length);
			this.Label.text = this.DelinquentEnemyFlees[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentFriendFlee)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentFriendFlees.Length);
			this.Label.text = this.DelinquentFriendFlees[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentInjuredFlee)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentInjuredFlees.Length);
			this.Label.text = this.DelinquentInjuredFlees[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentCheer)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentCheers.Length);
			this.Label.text = this.DelinquentCheers[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentHmm)
		{
			if (this.Label.text == string.Empty)
			{
				this.RandomID = UnityEngine.Random.Range(0, this.DelinquentHmms.Length);
				this.Label.text = this.DelinquentHmms[this.RandomID];
				this.PlayVoice(subtitleType, this.RandomID);
			}
		}
		else if (subtitleType == SubtitleType.DelinquentGrudge)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentGrudges.Length);
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
		{
			this.Label.text = this.GetRandomString(this.MurderReactions);
		}
		else if (subtitleType == SubtitleType.CorpseReaction)
		{
			this.Label.text = this.CorpseReactions[ID];
		}
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
		{
			this.Label.text = this.GetRandomString(this.LonerMurderReactions);
		}
		else if (subtitleType == SubtitleType.LonerCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.LonerCorpseReactions);
		}
		else if (subtitleType == SubtitleType.PetBloodReport)
		{
			this.Label.text = this.PetBloodReports[ID];
		}
		else if (subtitleType == SubtitleType.PetBloodReaction)
		{
			this.Label.text = this.GetRandomString(this.PetBloodReactions);
		}
		else if (subtitleType == SubtitleType.PetCorpseReport)
		{
			this.Label.text = this.PetCorpseReports[ID];
		}
		else if (subtitleType == SubtitleType.PetCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.PetCorpseReactions);
		}
		else if (subtitleType == SubtitleType.PetLimbReport)
		{
			this.Label.text = this.PetLimbReports[ID];
		}
		else if (subtitleType == SubtitleType.PetLimbReaction)
		{
			this.Label.text = this.GetRandomString(this.PetLimbReactions);
		}
		else if (subtitleType == SubtitleType.PetMurderReport)
		{
			this.Label.text = this.PetMurderReports[ID];
		}
		else if (subtitleType == SubtitleType.PetMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.PetMurderReactions);
		}
		else if (subtitleType == SubtitleType.PetWeaponReport)
		{
			this.Label.text = this.PetWeaponReports[ID];
		}
		else if (subtitleType == SubtitleType.PetWeaponReaction)
		{
			this.Label.text = this.PetWeaponReactions[ID];
		}
		else if (subtitleType == SubtitleType.PetBloodyWeaponReport)
		{
			this.Label.text = this.PetBloodyWeaponReports[ID];
		}
		else if (subtitleType == SubtitleType.PetBloodyWeaponReaction)
		{
			this.Label.text = this.GetRandomString(this.PetBloodyWeaponReactions);
		}
		else if (subtitleType == SubtitleType.EvilCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.EvilCorpseReactions);
		}
		else if (subtitleType == SubtitleType.EvilDelinquentCorpseReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.EvilDelinquentCorpseReactions.Length);
			this.Label.text = this.EvilDelinquentCorpseReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.HeroMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.HeroMurderReactions);
		}
		else if (subtitleType == SubtitleType.CowardMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.CowardMurderReactions);
		}
		else if (subtitleType == SubtitleType.EvilMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.EvilMurderReactions);
		}
		else if (subtitleType == SubtitleType.SocialDeathReaction)
		{
			this.Label.text = this.GetRandomString(this.SocialDeathReactions);
		}
		else if (subtitleType == SubtitleType.LovestruckDeathReaction)
		{
			this.Label.text = this.LovestruckDeathReactions[ID];
		}
		else if (subtitleType == SubtitleType.LovestruckMurderReport)
		{
			this.Label.text = this.LovestruckMurderReports[ID];
		}
		else if (subtitleType == SubtitleType.LovestruckCorpseReport)
		{
			this.Label.text = this.LovestruckCorpseReports[ID];
		}
		else if (subtitleType == SubtitleType.SocialReport)
		{
			this.Label.text = this.GetRandomString(this.SocialReports);
		}
		else if (subtitleType == SubtitleType.SocialFear)
		{
			this.Label.text = this.GetRandomString(this.SocialFears);
		}
		else if (subtitleType == SubtitleType.SocialTerror)
		{
			this.Label.text = this.GetRandomString(this.SocialTerrors);
		}
		else if (subtitleType == SubtitleType.RepeatReaction)
		{
			this.Label.text = this.GetRandomString(this.RepeatReactions);
		}
		else if (subtitleType == SubtitleType.Greeting)
		{
			this.Label.text = this.GetRandomString(this.Greetings);
		}
		else if (subtitleType == SubtitleType.PlayerFarewell)
		{
			this.Label.text = this.GetRandomString(this.PlayerFarewells);
		}
		else if (subtitleType == SubtitleType.StudentFarewell)
		{
			this.Label.text = this.GetRandomString(this.StudentFarewells);
		}
		else if (subtitleType == SubtitleType.InsanityApology)
		{
			this.Label.text = this.GetRandomString(this.InsanityApologies);
		}
		else if (subtitleType == SubtitleType.WeaponAndBloodApology)
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodApologies);
		}
		else if (subtitleType == SubtitleType.WeaponApology)
		{
			this.Label.text = this.GetRandomString(this.WeaponApologies);
		}
		else if (subtitleType == SubtitleType.BloodApology)
		{
			this.Label.text = this.GetRandomString(this.BloodApologies);
		}
		else if (subtitleType == SubtitleType.LewdApology)
		{
			this.Label.text = this.GetRandomString(this.LewdApologies);
		}
		else if (subtitleType == SubtitleType.SuspiciousApology)
		{
			this.Label.text = this.GetRandomString(this.SuspiciousApologies);
		}
		else if (subtitleType == SubtitleType.EavesdropApology)
		{
			this.Label.text = this.GetRandomString(this.EavesdropApologies);
		}
		else if (subtitleType == SubtitleType.ViolenceApology)
		{
			this.Label.text = this.GetRandomString(this.ViolenceApologies);
		}
		else if (subtitleType == SubtitleType.TheftApology)
		{
			this.Label.text = this.GetRandomString(this.TheftApologies);
		}
		else if (subtitleType == SubtitleType.EventApology)
		{
			this.Label.text = this.GetRandomString(this.EventApologies);
		}
		else if (subtitleType == SubtitleType.ClassApology)
		{
			this.Label.text = this.GetRandomString(this.ClassApologies);
		}
		else if (subtitleType == SubtitleType.AccidentApology)
		{
			this.Label.text = this.GetRandomString(this.AccidentApologies);
		}
		else if (subtitleType == SubtitleType.SadApology)
		{
			this.Label.text = this.GetRandomString(this.SadApologies);
		}
		else if (subtitleType == SubtitleType.TutorialApology)
		{
			this.Label.text = this.GetRandomString(this.TutorialApologies);
			this.PlayVoice(SubtitleType.TutorialReaction, 2);
		}
		else if (subtitleType == SubtitleType.Dismissive)
		{
			this.Label.text = this.Dismissives[ID];
		}
		else if (subtitleType == SubtitleType.Forgiving)
		{
			this.Label.text = this.GetRandomString(this.Forgivings);
		}
		else if (subtitleType == SubtitleType.ForgivingAccident)
		{
			this.Label.text = this.GetRandomString(this.AccidentForgivings);
		}
		else if (subtitleType == SubtitleType.ForgivingInsanity)
		{
			this.Label.text = this.GetRandomString(this.InsanityForgivings);
		}
		else if (subtitleType == SubtitleType.Impatience)
		{
			this.Label.text = this.Impatiences[ID];
		}
		else if (subtitleType == SubtitleType.PlayerCompliment)
		{
			this.Label.text = this.GetRandomString(this.PlayerCompliments);
		}
		else if (subtitleType == SubtitleType.StudentHighCompliment)
		{
			this.Label.text = this.GetRandomString(this.StudentHighCompliments);
		}
		else if (subtitleType == SubtitleType.StudentMidCompliment)
		{
			this.Label.text = this.GetRandomString(this.StudentMidCompliments);
		}
		else if (subtitleType == SubtitleType.StudentLowCompliment)
		{
			this.Label.text = this.GetRandomString(this.StudentLowCompliments);
		}
		else if (subtitleType == SubtitleType.PlayerGossip)
		{
			this.Label.text = this.GetRandomString(this.PlayerGossip);
		}
		else if (subtitleType == SubtitleType.StudentGossip)
		{
			this.Label.text = this.GetRandomString(this.StudentGossip);
		}
		else if (subtitleType == SubtitleType.PlayerFollow)
		{
			this.Label.text = this.PlayerFollows[ID];
		}
		else if (subtitleType == SubtitleType.StudentFollow)
		{
			this.Label.text = this.StudentFollows[ID];
		}
		else if (subtitleType == SubtitleType.PlayerLeave)
		{
			this.Label.text = this.PlayerLeaves[ID];
		}
		else if (subtitleType == SubtitleType.StudentLeave)
		{
			this.Label.text = this.StudentLeaves[ID];
		}
		else if (subtitleType == SubtitleType.StudentStay)
		{
			this.Label.text = this.StudentStays[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.PlayerDistract)
		{
			this.Label.text = this.PlayerDistracts[ID];
		}
		else if (subtitleType == SubtitleType.StudentDistract)
		{
			this.Label.text = this.StudentDistracts[ID];
		}
		else if (subtitleType == SubtitleType.StudentDistractRefuse)
		{
			this.Label.text = this.GetRandomString(this.StudentDistractRefuses);
		}
		else if (subtitleType == SubtitleType.StudentDistractBullyRefuse)
		{
			this.Label.text = this.GetRandomString(this.StudentDistractBullyRefuses);
		}
		else if (subtitleType == SubtitleType.StopFollowApology)
		{
			this.Label.text = this.StopFollowApologies[ID];
		}
		else if (subtitleType == SubtitleType.GrudgeWarning)
		{
			this.Label.text = this.GetRandomString(this.GrudgeWarnings);
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.GrudgeRefusal)
		{
			this.Label.text = this.GetRandomString(this.GrudgeRefusals);
		}
		else if (subtitleType == SubtitleType.CowardGrudge)
		{
			this.Label.text = this.GetRandomString(this.CowardGrudges);
		}
		else if (subtitleType == SubtitleType.EvilGrudge)
		{
			this.Label.text = this.GetRandomString(this.EvilGrudges);
		}
		else if (subtitleType == SubtitleType.PlayerLove)
		{
			this.Label.text = this.PlayerLove[ID];
		}
		else if (subtitleType == SubtitleType.SuitorLove)
		{
			this.Label.text = this.SuitorLove[ID];
		}
		else if (subtitleType == SubtitleType.RivalLove)
		{
			this.Label.text = this.RivalLove[ID];
		}
		else if (subtitleType == SubtitleType.RequestMedicine)
		{
			this.Label.text = this.RequestMedicines[ID];
		}
		else if (subtitleType == SubtitleType.ReturningWeapon)
		{
			this.Label.text = this.ReturningWeapons[ID];
		}
		else if (subtitleType == SubtitleType.Dying)
		{
			this.Label.text = this.GetRandomString(this.Deaths);
		}
		else if (subtitleType == SubtitleType.SenpaiInsanityReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiInsanityReactions.Length);
			this.Label.text = this.SenpaiInsanityReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.SenpaiWeaponReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiWeaponReactions.Length);
			this.Label.text = this.SenpaiWeaponReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.SenpaiBloodReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiBloodReactions.Length);
			this.Label.text = this.SenpaiBloodReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.SenpaiLewdReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiLewdReactions.Length);
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
		{
			this.Label.text = this.GetRandomString(this.SenpaiCorpseReactions);
		}
		else if (subtitleType == SubtitleType.SenpaiViolenceReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiViolenceReactions.Length);
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
			this.RandomID = UnityEngine.Random.Range(0, this.YandereWhimpers.Length);
			this.Label.text = this.YandereWhimpers[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.StudentMurderReport)
		{
			this.Label.text = this.StudentMurderReports[ID];
		}
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
			{
				this.RandomID = UnityEngine.Random.Range(0, this.PhotoAnnoyances.Length);
			}
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
			{
				this.PlayVoice(SubtitleType.TaskGenericLineMale, ID);
			}
			else
			{
				this.PlayVoice(SubtitleType.TaskGenericLineFemale, ID);
			}
		}
		else if (subtitleType == SubtitleType.TaskGenericEightiesLine)
		{
			this.Label.text = "(PLACEHOLDER TASK - WILL BE REPLACED IN FUTURE)\n" + this.TaskGenericEightiesLines[ID];
			if (this.Yandere.GetComponent<YandereScript>().TargetStudent.Male)
			{
				this.PlayVoice(SubtitleType.TaskGenericEightiesLineMale, ID);
			}
			else
			{
				this.PlayVoice(SubtitleType.TaskGenericEightiesLineFemale, ID);
			}
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
		{
			this.Label.text = this.InfoNotice;
		}
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
		{
			this.Label.text = this.AskForHelps[ID];
		}
		else if (subtitleType == SubtitleType.GiveHelp)
		{
			this.Label.text = this.GiveHelps[ID];
		}
		else if (subtitleType == SubtitleType.RejectHelp)
		{
			this.Label.text = this.RejectHelps[ID];
		}
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
		{
			this.Label.text = this.CustomText;
		}
		this.PreviousSubtitle = subtitleType;
		this.PreviousStudentID = this.StudentID;
		this.Timer = Duration;
	}

	// Token: 0x06001E81 RID: 7809 RVA: 0x001A5D2C File Offset: 0x001A3F2C
	private void Update()
	{
		if (this.Timer > 0f)
		{
			this.Timer -= Time.deltaTime;
			if (this.Timer <= 0f)
			{
				this.Jukebox.Dip = 1f;
				this.Label.text = string.Empty;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x06001E82 RID: 7810 RVA: 0x001A5D90 File Offset: 0x001A3F90
	private void PlayVoice(SubtitleType subtitleType, int ID)
	{
		if (this.CurrentClip != null)
		{
			UnityEngine.Object.Destroy(this.CurrentClip);
		}
		this.Jukebox.Dip = 0.5f;
		AudioClipArrayWrapper audioClipArrayWrapper;
		this.SubtitleClipArrays.TryGetValue(subtitleType, out audioClipArrayWrapper);
		if (ID < audioClipArrayWrapper.Length)
		{
			this.PlayClip(audioClipArrayWrapper[ID], base.transform.position);
			return;
		}
		this.PlayClip(audioClipArrayWrapper[0], base.transform.position);
	}

	// Token: 0x06001E83 RID: 7811 RVA: 0x001A5E10 File Offset: 0x001A4010
	public float GetClipLength(int StudentID, int TaskPhase)
	{
		if (StudentID == 6)
		{
			return this.Task6Clips[TaskPhase].length + 0.5f;
		}
		if (StudentID == 8)
		{
			return this.Task8Clips[TaskPhase].length;
		}
		if (StudentID == 11)
		{
			return this.Task11Clips[TaskPhase].length;
		}
		if (StudentID == 25)
		{
			return this.Task25Clips[TaskPhase].length;
		}
		if (StudentID == 28)
		{
			return this.Task28Clips[TaskPhase].length;
		}
		if (StudentID == 30)
		{
			return this.Task30Clips[TaskPhase].length;
		}
		if (StudentID == 36)
		{
			return this.Task36Clips[TaskPhase].length;
		}
		if (StudentID == 37)
		{
			return this.Task37Clips[TaskPhase].length;
		}
		if (StudentID == 38)
		{
			return this.Task38Clips[TaskPhase].length;
		}
		if (StudentID == 46)
		{
			return this.Task46Clips[TaskPhase].length;
		}
		if (StudentID == 47)
		{
			return this.Task47Clips[TaskPhase].length;
		}
		if (StudentID == 48)
		{
			return this.Task48Clips[TaskPhase].length;
		}
		if (StudentID == 49)
		{
			return this.Task49Clips[TaskPhase].length;
		}
		if (StudentID == 50)
		{
			return this.Task50Clips[TaskPhase].length;
		}
		if (StudentID == 52)
		{
			return this.Task52Clips[TaskPhase].length;
		}
		if (StudentID == 76)
		{
			return this.Task76Clips[TaskPhase].length;
		}
		if (StudentID == 77)
		{
			return this.Task77Clips[TaskPhase].length;
		}
		if (StudentID == 78)
		{
			return this.Task78Clips[TaskPhase].length;
		}
		if (StudentID == 79)
		{
			return this.Task79Clips[TaskPhase].length;
		}
		if (StudentID == 80)
		{
			return this.Task80Clips[TaskPhase].length;
		}
		if (StudentID == 81)
		{
			return this.Task81Clips[TaskPhase].length;
		}
		if (!this.Yandere.GetComponent<YandereScript>().StudentManager.Eighties)
		{
			if (this.Yandere.GetComponent<YandereScript>().TargetStudent.Male)
			{
				return this.TaskGenericMaleClips[TaskPhase].length;
			}
			return this.TaskGenericFemaleClips[TaskPhase].length;
		}
		else
		{
			if (this.Yandere.GetComponent<YandereScript>().TargetStudent.Male)
			{
				return this.TaskGenericEightiesMaleClips[TaskPhase].length;
			}
			return this.TaskGenericEightiesFemaleClips[TaskPhase].length;
		}
	}

	// Token: 0x06001E84 RID: 7812 RVA: 0x001A602C File Offset: 0x001A422C
	public float GetClubClipLength(ClubType Club, int ClubPhase)
	{
		if (Club == ClubType.Cooking)
		{
			return this.Club1Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.Drama)
		{
			return this.Club2Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.Occult)
		{
			return this.Club3Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.Art)
		{
			return this.Club4Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.LightMusic)
		{
			return this.Club5Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.MartialArts)
		{
			return this.Club6Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.Photography)
		{
			if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
			{
				return this.Club7ClipsDark[ClubPhase].length + 0.5f;
			}
			return this.Club7ClipsLight[ClubPhase].length + 0.5f;
		}
		else
		{
			if (Club == ClubType.Science)
			{
				return this.Club8Clips[ClubPhase].length + 0.5f;
			}
			if (Club == ClubType.Sports)
			{
				return this.Club9Clips[ClubPhase].length + 0.5f;
			}
			if (Club == ClubType.Gardening)
			{
				return this.Club10Clips[ClubPhase].length + 0.5f;
			}
			if (Club == ClubType.Gaming)
			{
				return this.Club11Clips[ClubPhase].length + 0.5f;
			}
			if (Club == ClubType.Delinquent)
			{
				return this.Club12Clips[ClubPhase].length + 0.5f;
			}
			if (Club == ClubType.Newspaper)
			{
				return this.Club13Clips[ClubPhase].length + 0.5f;
			}
			return 0f;
		}
	}

	// Token: 0x06001E85 RID: 7813 RVA: 0x001A619C File Offset: 0x001A439C
	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		if (clip != null)
		{
			GameObject gameObject = new GameObject("TempAudio");
			if (this.Speaker != null)
			{
				gameObject.transform.position = this.Speaker.transform.position + base.transform.up;
				gameObject.transform.parent = this.Speaker.transform;
			}
			else
			{
				gameObject.transform.position = this.Yandere.transform.position + base.transform.up;
				gameObject.transform.parent = this.Yandere.transform;
			}
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.clip = clip;
			audioSource.Play();
			UnityEngine.Object.Destroy(gameObject, clip.length);
			audioSource.rolloffMode = AudioRolloffMode.Linear;
			audioSource.spatialBlend = 1f;
			audioSource.minDistance = 5f;
			audioSource.maxDistance = 15f;
			this.CurrentClip = gameObject;
			audioSource.volume = ((this.Yandere.position.y < gameObject.transform.position.y - 2f) ? 0f : 1f);
			this.Speaker = null;
			return;
		}
		Debug.Log("Could not play a voice line. The audio clip was null.");
	}

	// Token: 0x06001E86 RID: 7814 RVA: 0x001A62EC File Offset: 0x001A44EC
	public void Silence(AudioClip[] ClipArray)
	{
		for (int i = 0; i < 11; i++)
		{
			if (i < ClipArray.Length)
			{
				ClipArray[i] = this.LongestSilence;
			}
		}
	}

	// Token: 0x04003D07 RID: 15623
	public JukeboxScript Jukebox;

	// Token: 0x04003D08 RID: 15624
	public Transform Yandere;

	// Token: 0x04003D09 RID: 15625
	public UILabel Label;

	// Token: 0x04003D0A RID: 15626
	public string[] WeaponBloodInsanityReactions;

	// Token: 0x04003D0B RID: 15627
	public string[] WeaponBloodReactions;

	// Token: 0x04003D0C RID: 15628
	public string[] WeaponInsanityReactions;

	// Token: 0x04003D0D RID: 15629
	public string[] BloodInsanityReactions;

	// Token: 0x04003D0E RID: 15630
	public string[] BloodReactions;

	// Token: 0x04003D0F RID: 15631
	public string[] BloodPoolReactions;

	// Token: 0x04003D10 RID: 15632
	public string[] BloodyWeaponReactions;

	// Token: 0x04003D11 RID: 15633
	public string[] LimbReactions;

	// Token: 0x04003D12 RID: 15634
	public string[] WetBloodReactions;

	// Token: 0x04003D13 RID: 15635
	public string[] InsanityReactions;

	// Token: 0x04003D14 RID: 15636
	public string[] LewdReactions;

	// Token: 0x04003D15 RID: 15637
	public string[] SuspiciousReactions;

	// Token: 0x04003D16 RID: 15638
	public string[] MurderReactions;

	// Token: 0x04003D17 RID: 15639
	public string[] CowardMurderReactions;

	// Token: 0x04003D18 RID: 15640
	public string[] EvilMurderReactions;

	// Token: 0x04003D19 RID: 15641
	public string[] HoldingBloodyClothingReactions;

	// Token: 0x04003D1A RID: 15642
	public string[] PetBloodReports;

	// Token: 0x04003D1B RID: 15643
	public string[] PetBloodReactions;

	// Token: 0x04003D1C RID: 15644
	public string[] PetCorpseReports;

	// Token: 0x04003D1D RID: 15645
	public string[] PetCorpseReactions;

	// Token: 0x04003D1E RID: 15646
	public string[] PetLimbReports;

	// Token: 0x04003D1F RID: 15647
	public string[] PetLimbReactions;

	// Token: 0x04003D20 RID: 15648
	public string[] PetMurderReports;

	// Token: 0x04003D21 RID: 15649
	public string[] PetMurderReactions;

	// Token: 0x04003D22 RID: 15650
	public string[] PetWeaponReports;

	// Token: 0x04003D23 RID: 15651
	public string[] PetWeaponReactions;

	// Token: 0x04003D24 RID: 15652
	public string[] PetBloodyWeaponReports;

	// Token: 0x04003D25 RID: 15653
	public string[] PetBloodyWeaponReactions;

	// Token: 0x04003D26 RID: 15654
	public string[] HeroMurderReactions;

	// Token: 0x04003D27 RID: 15655
	public string[] LonerMurderReactions;

	// Token: 0x04003D28 RID: 15656
	public string[] LonerCorpseReactions;

	// Token: 0x04003D29 RID: 15657
	public string[] EvilCorpseReactions;

	// Token: 0x04003D2A RID: 15658
	public string[] EvilDelinquentCorpseReactions;

	// Token: 0x04003D2B RID: 15659
	public string[] SocialDeathReactions;

	// Token: 0x04003D2C RID: 15660
	public string[] LovestruckDeathReactions;

	// Token: 0x04003D2D RID: 15661
	public string[] LovestruckMurderReports;

	// Token: 0x04003D2E RID: 15662
	public string[] LovestruckCorpseReports;

	// Token: 0x04003D2F RID: 15663
	public string[] SocialReports;

	// Token: 0x04003D30 RID: 15664
	public string[] SocialFears;

	// Token: 0x04003D31 RID: 15665
	public string[] SocialTerrors;

	// Token: 0x04003D32 RID: 15666
	public string[] RepeatReactions;

	// Token: 0x04003D33 RID: 15667
	public string[] CorpseReactions;

	// Token: 0x04003D34 RID: 15668
	public string[] PoisonReactions;

	// Token: 0x04003D35 RID: 15669
	public string[] PrankReactions;

	// Token: 0x04003D36 RID: 15670
	public string[] InterruptReactions;

	// Token: 0x04003D37 RID: 15671
	public string[] IntrusionReactions;

	// Token: 0x04003D38 RID: 15672
	public string[] NoteReactions;

	// Token: 0x04003D39 RID: 15673
	public string[] NoteReactionsMale;

	// Token: 0x04003D3A RID: 15674
	public string[] OfferSnacks;

	// Token: 0x04003D3B RID: 15675
	public string[] FoodAccepts;

	// Token: 0x04003D3C RID: 15676
	public string[] FoodRejects;

	// Token: 0x04003D3D RID: 15677
	public string[] EavesdropReactions;

	// Token: 0x04003D3E RID: 15678
	public string[] ViolenceReactions;

	// Token: 0x04003D3F RID: 15679
	public string[] EventEavesdropReactions;

	// Token: 0x04003D40 RID: 15680
	public string[] RivalEavesdropReactions;

	// Token: 0x04003D41 RID: 15681
	public string[] PickpocketReactions;

	// Token: 0x04003D42 RID: 15682
	public string[] RivalPickpocketReactions;

	// Token: 0x04003D43 RID: 15683
	public string[] DrownReactions;

	// Token: 0x04003D44 RID: 15684
	public string[] ParanoidReactions;

	// Token: 0x04003D45 RID: 15685
	public string[] TheftReactions;

	// Token: 0x04003D46 RID: 15686
	public string[] TutorialReactions;

	// Token: 0x04003D47 RID: 15687
	public string[] KilledMoods;

	// Token: 0x04003D48 RID: 15688
	public string[] SendToLockers;

	// Token: 0x04003D49 RID: 15689
	public string[] KnifeReactions;

	// Token: 0x04003D4A RID: 15690
	public string[] SyringeReactions;

	// Token: 0x04003D4B RID: 15691
	public string[] KatanaReactions;

	// Token: 0x04003D4C RID: 15692
	public string[] SawReactions;

	// Token: 0x04003D4D RID: 15693
	public string[] RitualReactions;

	// Token: 0x04003D4E RID: 15694
	public string[] BatReactions;

	// Token: 0x04003D4F RID: 15695
	public string[] ShovelReactions;

	// Token: 0x04003D50 RID: 15696
	public string[] DumbbellReactions;

	// Token: 0x04003D51 RID: 15697
	public string[] AxeReactions;

	// Token: 0x04003D52 RID: 15698
	public string[] PropReactions;

	// Token: 0x04003D53 RID: 15699
	public string[] DelinkWeaponReactions;

	// Token: 0x04003D54 RID: 15700
	public string[] ExtinguisherReactions;

	// Token: 0x04003D55 RID: 15701
	public string[] WrenchReactions;

	// Token: 0x04003D56 RID: 15702
	public string[] GuitarReactions;

	// Token: 0x04003D57 RID: 15703
	public string[] ScrapReactions;

	// Token: 0x04003D58 RID: 15704
	public string[] WeaponBloodApologies;

	// Token: 0x04003D59 RID: 15705
	public string[] WeaponApologies;

	// Token: 0x04003D5A RID: 15706
	public string[] BloodApologies;

	// Token: 0x04003D5B RID: 15707
	public string[] InsanityApologies;

	// Token: 0x04003D5C RID: 15708
	public string[] LewdApologies;

	// Token: 0x04003D5D RID: 15709
	public string[] SuspiciousApologies;

	// Token: 0x04003D5E RID: 15710
	public string[] EventApologies;

	// Token: 0x04003D5F RID: 15711
	public string[] ClassApologies;

	// Token: 0x04003D60 RID: 15712
	public string[] AccidentApologies;

	// Token: 0x04003D61 RID: 15713
	public string[] SadApologies;

	// Token: 0x04003D62 RID: 15714
	public string[] EavesdropApologies;

	// Token: 0x04003D63 RID: 15715
	public string[] ViolenceApologies;

	// Token: 0x04003D64 RID: 15716
	public string[] PickpocketApologies;

	// Token: 0x04003D65 RID: 15717
	public string[] CleaningApologies;

	// Token: 0x04003D66 RID: 15718
	public string[] PoisonApologies;

	// Token: 0x04003D67 RID: 15719
	public string[] HoldingBloodyClothingApologies;

	// Token: 0x04003D68 RID: 15720
	public string[] TheftApologies;

	// Token: 0x04003D69 RID: 15721
	public string[] TutorialApologies;

	// Token: 0x04003D6A RID: 15722
	public string[] Greetings;

	// Token: 0x04003D6B RID: 15723
	public string[] PlayerFarewells;

	// Token: 0x04003D6C RID: 15724
	public string[] StudentFarewells;

	// Token: 0x04003D6D RID: 15725
	public string[] Forgivings;

	// Token: 0x04003D6E RID: 15726
	public string[] AccidentForgivings;

	// Token: 0x04003D6F RID: 15727
	public string[] InsanityForgivings;

	// Token: 0x04003D70 RID: 15728
	public string[] PlayerCompliments;

	// Token: 0x04003D71 RID: 15729
	public string[] StudentHighCompliments;

	// Token: 0x04003D72 RID: 15730
	public string[] StudentMidCompliments;

	// Token: 0x04003D73 RID: 15731
	public string[] StudentLowCompliments;

	// Token: 0x04003D74 RID: 15732
	public string[] PlayerGossip;

	// Token: 0x04003D75 RID: 15733
	public string[] StudentGossip;

	// Token: 0x04003D76 RID: 15734
	public string[] PlayerFollows;

	// Token: 0x04003D77 RID: 15735
	public string[] StudentFollows;

	// Token: 0x04003D78 RID: 15736
	public string[] PlayerLeaves;

	// Token: 0x04003D79 RID: 15737
	public string[] StudentLeaves;

	// Token: 0x04003D7A RID: 15738
	public string[] StudentStays;

	// Token: 0x04003D7B RID: 15739
	public string[] PlayerDistracts;

	// Token: 0x04003D7C RID: 15740
	public string[] StudentDistracts;

	// Token: 0x04003D7D RID: 15741
	public string[] StudentDistractRefuses;

	// Token: 0x04003D7E RID: 15742
	public string[] StudentDistractBullyRefuses;

	// Token: 0x04003D7F RID: 15743
	public string[] StopFollowApologies;

	// Token: 0x04003D80 RID: 15744
	public string[] GrudgeWarnings;

	// Token: 0x04003D81 RID: 15745
	public string[] GrudgeRefusals;

	// Token: 0x04003D82 RID: 15746
	public string[] CowardGrudges;

	// Token: 0x04003D83 RID: 15747
	public string[] EvilGrudges;

	// Token: 0x04003D84 RID: 15748
	public string[] PlayerLove;

	// Token: 0x04003D85 RID: 15749
	public string[] SuitorLove;

	// Token: 0x04003D86 RID: 15750
	public string[] RivalLove;

	// Token: 0x04003D87 RID: 15751
	public string[] RequestMedicines;

	// Token: 0x04003D88 RID: 15752
	public string[] ReturningWeapons;

	// Token: 0x04003D89 RID: 15753
	public string[] Impatiences;

	// Token: 0x04003D8A RID: 15754
	public string[] ImpatientFarewells;

	// Token: 0x04003D8B RID: 15755
	public string[] Deaths;

	// Token: 0x04003D8C RID: 15756
	public string[] SenpaiInsanityReactions;

	// Token: 0x04003D8D RID: 15757
	public string[] SenpaiWeaponReactions;

	// Token: 0x04003D8E RID: 15758
	public string[] SenpaiBloodReactions;

	// Token: 0x04003D8F RID: 15759
	public string[] SenpaiLewdReactions;

	// Token: 0x04003D90 RID: 15760
	public string[] SenpaiStalkingReactions;

	// Token: 0x04003D91 RID: 15761
	public string[] SenpaiMurderReactions;

	// Token: 0x04003D92 RID: 15762
	public string[] SenpaiCorpseReactions;

	// Token: 0x04003D93 RID: 15763
	public string[] SenpaiViolenceReactions;

	// Token: 0x04003D94 RID: 15764
	public string[] SenpaiRivalDeathReactions;

	// Token: 0x04003D95 RID: 15765
	public string[] RaibaruRivalDeathReactions;

	// Token: 0x04003D96 RID: 15766
	public string[] OsanaObstacleDeathReactions;

	// Token: 0x04003D97 RID: 15767
	public string[] TeacherInsanityReactions;

	// Token: 0x04003D98 RID: 15768
	public string[] TeacherWeaponReactions;

	// Token: 0x04003D99 RID: 15769
	public string[] TeacherBloodReactions;

	// Token: 0x04003D9A RID: 15770
	public string[] TeacherInsanityHostiles;

	// Token: 0x04003D9B RID: 15771
	public string[] TeacherWeaponHostiles;

	// Token: 0x04003D9C RID: 15772
	public string[] TeacherBloodHostiles;

	// Token: 0x04003D9D RID: 15773
	public string[] TeacherCoverUpHostiles;

	// Token: 0x04003D9E RID: 15774
	public string[] TeacherLewdReactions;

	// Token: 0x04003D9F RID: 15775
	public string[] TeacherTrespassReactions;

	// Token: 0x04003DA0 RID: 15776
	public string[] TeacherLateReactions;

	// Token: 0x04003DA1 RID: 15777
	public string[] TeacherReportReactions;

	// Token: 0x04003DA2 RID: 15778
	public string[] TeacherCorpseReactions;

	// Token: 0x04003DA3 RID: 15779
	public string[] TeacherCorpseInspections;

	// Token: 0x04003DA4 RID: 15780
	public string[] TeacherPoliceReports;

	// Token: 0x04003DA5 RID: 15781
	public string[] TeacherAttackReactions;

	// Token: 0x04003DA6 RID: 15782
	public string[] TeacherMurderReactions;

	// Token: 0x04003DA7 RID: 15783
	public string[] TeacherPrankReactions;

	// Token: 0x04003DA8 RID: 15784
	public string[] TeacherTheftReactions;

	// Token: 0x04003DA9 RID: 15785
	public string[] DelinquentAnnoys;

	// Token: 0x04003DAA RID: 15786
	public string[] DelinquentCases;

	// Token: 0x04003DAB RID: 15787
	public string[] DelinquentShoves;

	// Token: 0x04003DAC RID: 15788
	public string[] DelinquentReactions;

	// Token: 0x04003DAD RID: 15789
	public string[] DelinquentWeaponReactions;

	// Token: 0x04003DAE RID: 15790
	public string[] DelinquentThreateneds;

	// Token: 0x04003DAF RID: 15791
	public string[] DelinquentTaunts;

	// Token: 0x04003DB0 RID: 15792
	public string[] DelinquentCalms;

	// Token: 0x04003DB1 RID: 15793
	public string[] DelinquentFights;

	// Token: 0x04003DB2 RID: 15794
	public string[] DelinquentAvenges;

	// Token: 0x04003DB3 RID: 15795
	public string[] DelinquentWins;

	// Token: 0x04003DB4 RID: 15796
	public string[] DelinquentSurrenders;

	// Token: 0x04003DB5 RID: 15797
	public string[] DelinquentNoSurrenders;

	// Token: 0x04003DB6 RID: 15798
	public string[] DelinquentMurderReactions;

	// Token: 0x04003DB7 RID: 15799
	public string[] DelinquentCorpseReactions;

	// Token: 0x04003DB8 RID: 15800
	public string[] DelinquentFriendCorpseReactions;

	// Token: 0x04003DB9 RID: 15801
	public string[] DelinquentResumes;

	// Token: 0x04003DBA RID: 15802
	public string[] DelinquentFlees;

	// Token: 0x04003DBB RID: 15803
	public string[] DelinquentEnemyFlees;

	// Token: 0x04003DBC RID: 15804
	public string[] DelinquentFriendFlees;

	// Token: 0x04003DBD RID: 15805
	public string[] DelinquentInjuredFlees;

	// Token: 0x04003DBE RID: 15806
	public string[] DelinquentCheers;

	// Token: 0x04003DBF RID: 15807
	public string[] DelinquentHmms;

	// Token: 0x04003DC0 RID: 15808
	public string[] DelinquentGrudges;

	// Token: 0x04003DC1 RID: 15809
	public string[] Dismissives;

	// Token: 0x04003DC2 RID: 15810
	public string[] LostPhones;

	// Token: 0x04003DC3 RID: 15811
	public string[] RivalLostPhones;

	// Token: 0x04003DC4 RID: 15812
	public string[] StudentMurderReports;

	// Token: 0x04003DC5 RID: 15813
	public string[] YandereWhimpers;

	// Token: 0x04003DC6 RID: 15814
	public string[] SplashReactions;

	// Token: 0x04003DC7 RID: 15815
	public string[] SplashReactionsMale;

	// Token: 0x04003DC8 RID: 15816
	public string[] RivalSplashReactions;

	// Token: 0x04003DC9 RID: 15817
	public string[] LightSwitchReactions;

	// Token: 0x04003DCA RID: 15818
	public string[] PhotoAnnoyances;

	// Token: 0x04003DCB RID: 15819
	public string[] Task6Lines;

	// Token: 0x04003DCC RID: 15820
	public string[] Task7Lines;

	// Token: 0x04003DCD RID: 15821
	public string[] Task8Lines;

	// Token: 0x04003DCE RID: 15822
	public string[] Task11Lines;

	// Token: 0x04003DCF RID: 15823
	public string[] Task13Lines;

	// Token: 0x04003DD0 RID: 15824
	public string[] Task14Lines;

	// Token: 0x04003DD1 RID: 15825
	public string[] Task15Lines;

	// Token: 0x04003DD2 RID: 15826
	public string[] Task25Lines;

	// Token: 0x04003DD3 RID: 15827
	public string[] Task28Lines;

	// Token: 0x04003DD4 RID: 15828
	public string[] Task30Lines;

	// Token: 0x04003DD5 RID: 15829
	public string[] Task32Lines;

	// Token: 0x04003DD6 RID: 15830
	public string[] Task33Lines;

	// Token: 0x04003DD7 RID: 15831
	public string[] Task34Lines;

	// Token: 0x04003DD8 RID: 15832
	public string[] Task36Lines;

	// Token: 0x04003DD9 RID: 15833
	public string[] Task37Lines;

	// Token: 0x04003DDA RID: 15834
	public string[] Task38Lines;

	// Token: 0x04003DDB RID: 15835
	public string[] Task46Lines;

	// Token: 0x04003DDC RID: 15836
	public string[] Task47Lines;

	// Token: 0x04003DDD RID: 15837
	public string[] Task48Lines;

	// Token: 0x04003DDE RID: 15838
	public string[] Task49Lines;

	// Token: 0x04003DDF RID: 15839
	public string[] Task50Lines;

	// Token: 0x04003DE0 RID: 15840
	public string[] Task52Lines;

	// Token: 0x04003DE1 RID: 15841
	public string[] Task76Lines;

	// Token: 0x04003DE2 RID: 15842
	public string[] Task77Lines;

	// Token: 0x04003DE3 RID: 15843
	public string[] Task78Lines;

	// Token: 0x04003DE4 RID: 15844
	public string[] Task79Lines;

	// Token: 0x04003DE5 RID: 15845
	public string[] Task80Lines;

	// Token: 0x04003DE6 RID: 15846
	public string[] Task81Lines;

	// Token: 0x04003DE7 RID: 15847
	public string[] TaskGenericLines;

	// Token: 0x04003DE8 RID: 15848
	public string[] TaskGenericEightiesLines;

	// Token: 0x04003DE9 RID: 15849
	public string[] TaskGenericEightiesLinesMale;

	// Token: 0x04003DEA RID: 15850
	public string[] TaskGenericEightiesLinesFemale;

	// Token: 0x04003DEB RID: 15851
	public string[] TaskInquiries;

	// Token: 0x04003DEC RID: 15852
	public string[] Task79LinesEighties;

	// Token: 0x04003DED RID: 15853
	public string[] Club0Info;

	// Token: 0x04003DEE RID: 15854
	public string[] Club1Info;

	// Token: 0x04003DEF RID: 15855
	public string[] Club2Info;

	// Token: 0x04003DF0 RID: 15856
	public string[] Club3Info;

	// Token: 0x04003DF1 RID: 15857
	public string[] Club4Info;

	// Token: 0x04003DF2 RID: 15858
	public string[] Club5Info;

	// Token: 0x04003DF3 RID: 15859
	public string[] Club6Info;

	// Token: 0x04003DF4 RID: 15860
	public string[] Club7InfoLight;

	// Token: 0x04003DF5 RID: 15861
	public string[] Club7InfoDark;

	// Token: 0x04003DF6 RID: 15862
	public string[] Club8Info;

	// Token: 0x04003DF7 RID: 15863
	public string[] Club9Info;

	// Token: 0x04003DF8 RID: 15864
	public string[] Club10Info;

	// Token: 0x04003DF9 RID: 15865
	public string[] Club11Info;

	// Token: 0x04003DFA RID: 15866
	public string[] Club12Info;

	// Token: 0x04003DFB RID: 15867
	public string[] Club13Info;

	// Token: 0x04003DFC RID: 15868
	public string[] SubClub3Info;

	// Token: 0x04003DFD RID: 15869
	public string[] ClubGreetings;

	// Token: 0x04003DFE RID: 15870
	public string[] ClubUnwelcomes;

	// Token: 0x04003DFF RID: 15871
	public string[] ClubKicks;

	// Token: 0x04003E00 RID: 15872
	public string[] ClubJoins;

	// Token: 0x04003E01 RID: 15873
	public string[] ClubAccepts;

	// Token: 0x04003E02 RID: 15874
	public string[] ClubRefuses;

	// Token: 0x04003E03 RID: 15875
	public string[] ClubRejoins;

	// Token: 0x04003E04 RID: 15876
	public string[] ClubExclusives;

	// Token: 0x04003E05 RID: 15877
	public string[] ClubGrudges;

	// Token: 0x04003E06 RID: 15878
	public string[] ClubQuits;

	// Token: 0x04003E07 RID: 15879
	public string[] ClubConfirms;

	// Token: 0x04003E08 RID: 15880
	public string[] ClubDenies;

	// Token: 0x04003E09 RID: 15881
	public string[] ClubFarewells;

	// Token: 0x04003E0A RID: 15882
	public string[] ClubActivities;

	// Token: 0x04003E0B RID: 15883
	public string[] ClubEarlies;

	// Token: 0x04003E0C RID: 15884
	public string[] ClubLates;

	// Token: 0x04003E0D RID: 15885
	public string[] ClubYeses;

	// Token: 0x04003E0E RID: 15886
	public string[] ClubNoes;

	// Token: 0x04003E0F RID: 15887
	public string[] ClubPractices;

	// Token: 0x04003E10 RID: 15888
	public string[] ClubPracticeYeses;

	// Token: 0x04003E11 RID: 15889
	public string[] ClubPracticeNoes;

	// Token: 0x04003E12 RID: 15890
	public string[] Eulogies;

	// Token: 0x04003E13 RID: 15891
	public string[] AskForHelps;

	// Token: 0x04003E14 RID: 15892
	public string[] GiveHelps;

	// Token: 0x04003E15 RID: 15893
	public string[] RejectHelps;

	// Token: 0x04003E16 RID: 15894
	public string[] GasWarnings;

	// Token: 0x04003E17 RID: 15895
	public string[] ObstacleMurderReactions;

	// Token: 0x04003E18 RID: 15896
	public string[] ObstaclePoisonReactions;

	// Token: 0x04003E19 RID: 15897
	public string[] StrictReport;

	// Token: 0x04003E1A RID: 15898
	public string[] CasualReport;

	// Token: 0x04003E1B RID: 15899
	public string[] GraceReport;

	// Token: 0x04003E1C RID: 15900
	public string[] EdgyReport;

	// Token: 0x04003E1D RID: 15901
	public string[] BreakingUp;

	// Token: 0x04003E1E RID: 15902
	public string[] Spraying;

	// Token: 0x04003E1F RID: 15903
	public string[] Shoving;

	// Token: 0x04003E20 RID: 15904
	public string[] Chasing;

	// Token: 0x04003E21 RID: 15905
	public string[] CouncilCorpseReactions;

	// Token: 0x04003E22 RID: 15906
	public string[] CouncilToCounselors;

	// Token: 0x04003E23 RID: 15907
	public string[] HmmReactions;

	// Token: 0x04003E24 RID: 15908
	public string InfoNotice;

	// Token: 0x04003E25 RID: 15909
	public string CustomText;

	// Token: 0x04003E26 RID: 15910
	public int PreviousRandom;

	// Token: 0x04003E27 RID: 15911
	public int RandomID;

	// Token: 0x04003E28 RID: 15912
	public float Timer;

	// Token: 0x04003E29 RID: 15913
	public int StudentID;

	// Token: 0x04003E2A RID: 15914
	public PersonaSubtitleScript PersonaSubtitle;

	// Token: 0x04003E2B RID: 15915
	public AudioClip LongestSilence;

	// Token: 0x04003E2C RID: 15916
	public SubtitleType PreviousSubtitle;

	// Token: 0x04003E2D RID: 15917
	private int PreviousStudentID;

	// Token: 0x04003E2E RID: 15918
	public AudioClip[] NoteReactionClips;

	// Token: 0x04003E2F RID: 15919
	public AudioClip[] NoteReactionMaleClips;

	// Token: 0x04003E30 RID: 15920
	public AudioClip[] GrudgeWarningClips;

	// Token: 0x04003E31 RID: 15921
	public AudioClip[] SenpaiInsanityReactionClips;

	// Token: 0x04003E32 RID: 15922
	public AudioClip[] SenpaiWeaponReactionClips;

	// Token: 0x04003E33 RID: 15923
	public AudioClip[] SenpaiBloodReactionClips;

	// Token: 0x04003E34 RID: 15924
	public AudioClip[] SenpaiLewdReactionClips;

	// Token: 0x04003E35 RID: 15925
	public AudioClip[] SenpaiStalkingReactionClips;

	// Token: 0x04003E36 RID: 15926
	public AudioClip[] SenpaiMurderReactionClips;

	// Token: 0x04003E37 RID: 15927
	public AudioClip[] SenpaiViolenceReactionClips;

	// Token: 0x04003E38 RID: 15928
	public AudioClip[] SenpaiRivalDeathReactionClips;

	// Token: 0x04003E39 RID: 15929
	public AudioClip[] RaibaruRivalDeathReactionClips;

	// Token: 0x04003E3A RID: 15930
	public AudioClip[] OsanaObstacleDeathReactionClips;

	// Token: 0x04003E3B RID: 15931
	public AudioClip[] YandereWhimperClips;

	// Token: 0x04003E3C RID: 15932
	public AudioClip[] TheftClips;

	// Token: 0x04003E3D RID: 15933
	public AudioClip[] TeacherWeaponClips;

	// Token: 0x04003E3E RID: 15934
	public AudioClip[] TeacherBloodClips;

	// Token: 0x04003E3F RID: 15935
	public AudioClip[] TeacherInsanityClips;

	// Token: 0x04003E40 RID: 15936
	public AudioClip[] TeacherWeaponHostileClips;

	// Token: 0x04003E41 RID: 15937
	public AudioClip[] TeacherBloodHostileClips;

	// Token: 0x04003E42 RID: 15938
	public AudioClip[] TeacherInsanityHostileClips;

	// Token: 0x04003E43 RID: 15939
	public AudioClip[] TeacherCoverUpHostileClips;

	// Token: 0x04003E44 RID: 15940
	public AudioClip[] TeacherLewdClips;

	// Token: 0x04003E45 RID: 15941
	public AudioClip[] TeacherTrespassClips;

	// Token: 0x04003E46 RID: 15942
	public AudioClip[] TeacherLateClips;

	// Token: 0x04003E47 RID: 15943
	public AudioClip[] TeacherReportClips;

	// Token: 0x04003E48 RID: 15944
	public AudioClip[] TeacherCorpseClips;

	// Token: 0x04003E49 RID: 15945
	public AudioClip[] TeacherInspectClips;

	// Token: 0x04003E4A RID: 15946
	public AudioClip[] TeacherPoliceClips;

	// Token: 0x04003E4B RID: 15947
	public AudioClip[] TeacherAttackClips;

	// Token: 0x04003E4C RID: 15948
	public AudioClip[] TeacherMurderClips;

	// Token: 0x04003E4D RID: 15949
	public AudioClip[] TeacherPrankClips;

	// Token: 0x04003E4E RID: 15950
	public AudioClip[] TeacherTheftClips;

	// Token: 0x04003E4F RID: 15951
	public AudioClip[] LostPhoneClips;

	// Token: 0x04003E50 RID: 15952
	public AudioClip[] RivalLostPhoneClips;

	// Token: 0x04003E51 RID: 15953
	public AudioClip[] PickpocketReactionClips;

	// Token: 0x04003E52 RID: 15954
	public AudioClip[] RivalPickpocketReactionClips;

	// Token: 0x04003E53 RID: 15955
	public AudioClip[] SplashReactionClips;

	// Token: 0x04003E54 RID: 15956
	public AudioClip[] SplashReactionMaleClips;

	// Token: 0x04003E55 RID: 15957
	public AudioClip[] RivalSplashReactionClips;

	// Token: 0x04003E56 RID: 15958
	public AudioClip[] DrownReactionClips;

	// Token: 0x04003E57 RID: 15959
	public AudioClip[] LightSwitchClips;

	// Token: 0x04003E58 RID: 15960
	public AudioClip[] Task6Clips;

	// Token: 0x04003E59 RID: 15961
	public AudioClip[] Task7Clips;

	// Token: 0x04003E5A RID: 15962
	public AudioClip[] Task8Clips;

	// Token: 0x04003E5B RID: 15963
	public AudioClip[] Task11Clips;

	// Token: 0x04003E5C RID: 15964
	public AudioClip[] Task13Clips;

	// Token: 0x04003E5D RID: 15965
	public AudioClip[] Task14Clips;

	// Token: 0x04003E5E RID: 15966
	public AudioClip[] Task15Clips;

	// Token: 0x04003E5F RID: 15967
	public AudioClip[] Task25Clips;

	// Token: 0x04003E60 RID: 15968
	public AudioClip[] Task28Clips;

	// Token: 0x04003E61 RID: 15969
	public AudioClip[] Task30Clips;

	// Token: 0x04003E62 RID: 15970
	public AudioClip[] Task32Clips;

	// Token: 0x04003E63 RID: 15971
	public AudioClip[] Task33Clips;

	// Token: 0x04003E64 RID: 15972
	public AudioClip[] Task34Clips;

	// Token: 0x04003E65 RID: 15973
	public AudioClip[] Task36Clips;

	// Token: 0x04003E66 RID: 15974
	public AudioClip[] Task37Clips;

	// Token: 0x04003E67 RID: 15975
	public AudioClip[] Task38Clips;

	// Token: 0x04003E68 RID: 15976
	public AudioClip[] Task46Clips;

	// Token: 0x04003E69 RID: 15977
	public AudioClip[] Task47Clips;

	// Token: 0x04003E6A RID: 15978
	public AudioClip[] Task48Clips;

	// Token: 0x04003E6B RID: 15979
	public AudioClip[] Task49Clips;

	// Token: 0x04003E6C RID: 15980
	public AudioClip[] Task50Clips;

	// Token: 0x04003E6D RID: 15981
	public AudioClip[] Task52Clips;

	// Token: 0x04003E6E RID: 15982
	public AudioClip[] Task76Clips;

	// Token: 0x04003E6F RID: 15983
	public AudioClip[] Task77Clips;

	// Token: 0x04003E70 RID: 15984
	public AudioClip[] Task78Clips;

	// Token: 0x04003E71 RID: 15985
	public AudioClip[] Task79Clips;

	// Token: 0x04003E72 RID: 15986
	public AudioClip[] Task80Clips;

	// Token: 0x04003E73 RID: 15987
	public AudioClip[] Task81Clips;

	// Token: 0x04003E74 RID: 15988
	public AudioClip[] TaskGenericMaleClips;

	// Token: 0x04003E75 RID: 15989
	public AudioClip[] TaskGenericFemaleClips;

	// Token: 0x04003E76 RID: 15990
	public AudioClip[] TaskGenericEightiesMaleClips;

	// Token: 0x04003E77 RID: 15991
	public AudioClip[] TaskGenericEightiesFemaleClips;

	// Token: 0x04003E78 RID: 15992
	public AudioClip[] TaskInquiryClips;

	// Token: 0x04003E79 RID: 15993
	public AudioClip[] Task79ClipsEighties;

	// Token: 0x04003E7A RID: 15994
	public AudioClip[] TutorialReactionClips;

	// Token: 0x04003E7B RID: 15995
	public AudioClip[] Club0Clips;

	// Token: 0x04003E7C RID: 15996
	public AudioClip[] Club1Clips;

	// Token: 0x04003E7D RID: 15997
	public AudioClip[] Club2Clips;

	// Token: 0x04003E7E RID: 15998
	public AudioClip[] Club3Clips;

	// Token: 0x04003E7F RID: 15999
	public AudioClip[] Club4Clips;

	// Token: 0x04003E80 RID: 16000
	public AudioClip[] Club5Clips;

	// Token: 0x04003E81 RID: 16001
	public AudioClip[] Club6Clips;

	// Token: 0x04003E82 RID: 16002
	public AudioClip[] Club7ClipsLight;

	// Token: 0x04003E83 RID: 16003
	public AudioClip[] Club7ClipsDark;

	// Token: 0x04003E84 RID: 16004
	public AudioClip[] Club8Clips;

	// Token: 0x04003E85 RID: 16005
	public AudioClip[] Club9Clips;

	// Token: 0x04003E86 RID: 16006
	public AudioClip[] Club10Clips;

	// Token: 0x04003E87 RID: 16007
	public AudioClip[] Club11Clips;

	// Token: 0x04003E88 RID: 16008
	public AudioClip[] Club12Clips;

	// Token: 0x04003E89 RID: 16009
	public AudioClip[] Club13Clips;

	// Token: 0x04003E8A RID: 16010
	public AudioClip[] SubClub3Clips;

	// Token: 0x04003E8B RID: 16011
	public AudioClip[] ClubGreetingClips;

	// Token: 0x04003E8C RID: 16012
	public AudioClip[] ClubUnwelcomeClips;

	// Token: 0x04003E8D RID: 16013
	public AudioClip[] ClubKickClips;

	// Token: 0x04003E8E RID: 16014
	public AudioClip[] ClubJoinClips;

	// Token: 0x04003E8F RID: 16015
	public AudioClip[] ClubAcceptClips;

	// Token: 0x04003E90 RID: 16016
	public AudioClip[] ClubRefuseClips;

	// Token: 0x04003E91 RID: 16017
	public AudioClip[] ClubRejoinClips;

	// Token: 0x04003E92 RID: 16018
	public AudioClip[] ClubExclusiveClips;

	// Token: 0x04003E93 RID: 16019
	public AudioClip[] ClubGrudgeClips;

	// Token: 0x04003E94 RID: 16020
	public AudioClip[] ClubQuitClips;

	// Token: 0x04003E95 RID: 16021
	public AudioClip[] ClubConfirmClips;

	// Token: 0x04003E96 RID: 16022
	public AudioClip[] ClubDenyClips;

	// Token: 0x04003E97 RID: 16023
	public AudioClip[] ClubFarewellClips;

	// Token: 0x04003E98 RID: 16024
	public AudioClip[] ClubActivityClips;

	// Token: 0x04003E99 RID: 16025
	public AudioClip[] ClubEarlyClips;

	// Token: 0x04003E9A RID: 16026
	public AudioClip[] ClubLateClips;

	// Token: 0x04003E9B RID: 16027
	public AudioClip[] ClubYesClips;

	// Token: 0x04003E9C RID: 16028
	public AudioClip[] ClubNoClips;

	// Token: 0x04003E9D RID: 16029
	public AudioClip[] ClubPracticeClips;

	// Token: 0x04003E9E RID: 16030
	public AudioClip[] ClubPracticeYesClips;

	// Token: 0x04003E9F RID: 16031
	public AudioClip[] ClubPracticeNoClips;

	// Token: 0x04003EA0 RID: 16032
	public AudioClip[] EavesdropClips;

	// Token: 0x04003EA1 RID: 16033
	public AudioClip[] FoodRejectionClips;

	// Token: 0x04003EA2 RID: 16034
	public AudioClip[] ViolenceClips;

	// Token: 0x04003EA3 RID: 16035
	public AudioClip[] EventEavesdropClips;

	// Token: 0x04003EA4 RID: 16036
	public AudioClip[] RivalEavesdropClips;

	// Token: 0x04003EA5 RID: 16037
	public AudioClip[] DelinquentAnnoyClips;

	// Token: 0x04003EA6 RID: 16038
	public AudioClip[] DelinquentCaseClips;

	// Token: 0x04003EA7 RID: 16039
	public AudioClip[] DelinquentShoveClips;

	// Token: 0x04003EA8 RID: 16040
	public AudioClip[] DelinquentReactionClips;

	// Token: 0x04003EA9 RID: 16041
	public AudioClip[] DelinquentWeaponReactionClips;

	// Token: 0x04003EAA RID: 16042
	public AudioClip[] DelinquentThreatenedClips;

	// Token: 0x04003EAB RID: 16043
	public AudioClip[] DelinquentTauntClips;

	// Token: 0x04003EAC RID: 16044
	public AudioClip[] DelinquentCalmClips;

	// Token: 0x04003EAD RID: 16045
	public AudioClip[] DelinquentFightClips;

	// Token: 0x04003EAE RID: 16046
	public AudioClip[] DelinquentAvengeClips;

	// Token: 0x04003EAF RID: 16047
	public AudioClip[] DelinquentWinClips;

	// Token: 0x04003EB0 RID: 16048
	public AudioClip[] DelinquentSurrenderClips;

	// Token: 0x04003EB1 RID: 16049
	public AudioClip[] DelinquentNoSurrenderClips;

	// Token: 0x04003EB2 RID: 16050
	public AudioClip[] DelinquentMurderReactionClips;

	// Token: 0x04003EB3 RID: 16051
	public AudioClip[] DelinquentCorpseReactionClips;

	// Token: 0x04003EB4 RID: 16052
	public AudioClip[] DelinquentFriendCorpseReactionClips;

	// Token: 0x04003EB5 RID: 16053
	public AudioClip[] DelinquentResumeClips;

	// Token: 0x04003EB6 RID: 16054
	public AudioClip[] DelinquentFleeClips;

	// Token: 0x04003EB7 RID: 16055
	public AudioClip[] DelinquentEnemyFleeClips;

	// Token: 0x04003EB8 RID: 16056
	public AudioClip[] DelinquentFriendFleeClips;

	// Token: 0x04003EB9 RID: 16057
	public AudioClip[] DelinquentInjuredFleeClips;

	// Token: 0x04003EBA RID: 16058
	public AudioClip[] DelinquentCheerClips;

	// Token: 0x04003EBB RID: 16059
	public AudioClip[] DelinquentHmmClips;

	// Token: 0x04003EBC RID: 16060
	public AudioClip[] DelinquentGrudgeClips;

	// Token: 0x04003EBD RID: 16061
	public AudioClip[] DismissiveClips;

	// Token: 0x04003EBE RID: 16062
	public AudioClip[] EvilDelinquentCorpseReactionClips;

	// Token: 0x04003EBF RID: 16063
	public AudioClip[] EulogyClips;

	// Token: 0x04003EC0 RID: 16064
	public AudioClip[] ObstacleMurderReactionClips;

	// Token: 0x04003EC1 RID: 16065
	public AudioClip[] ObstaclePoisonReactionClips;

	// Token: 0x04003EC2 RID: 16066
	public AudioClip[] GasWarningClips;

	// Token: 0x04003EC3 RID: 16067
	public AudioClip[] StudentStayClips;

	// Token: 0x04003EC4 RID: 16068
	public AudioClip[] StrictReportClips;

	// Token: 0x04003EC5 RID: 16069
	public AudioClip[] CasualReportClips;

	// Token: 0x04003EC6 RID: 16070
	public AudioClip[] GraceReportClips;

	// Token: 0x04003EC7 RID: 16071
	public AudioClip[] EdgyReportClips;

	// Token: 0x04003EC8 RID: 16072
	public AudioClip[] BreakUpClips;

	// Token: 0x04003EC9 RID: 16073
	public AudioClip[] ChaseClips;

	// Token: 0x04003ECA RID: 16074
	public AudioClip[] ShoveClips;

	// Token: 0x04003ECB RID: 16075
	public AudioClip[] SprayClips;

	// Token: 0x04003ECC RID: 16076
	public AudioClip[] HmmClips;

	// Token: 0x04003ECD RID: 16077
	public AudioClip[] CouncilCorpseClips;

	// Token: 0x04003ECE RID: 16078
	public AudioClip[] CouncilCounselorClips;

	// Token: 0x04003ECF RID: 16079
	private SubtitleTypeAndAudioClipArrayDictionary SubtitleClipArrays;

	// Token: 0x04003ED0 RID: 16080
	public GameObject CurrentClip;

	// Token: 0x04003ED1 RID: 16081
	public StudentScript Speaker;

	// Token: 0x04003ED2 RID: 16082
	public UISprite Darkness;

	// Token: 0x04003ED3 RID: 16083
	public UILabel EventSubtitle;
}
