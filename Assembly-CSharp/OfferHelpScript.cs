using System;
using UnityEngine;

// Token: 0x02000387 RID: 903
public class OfferHelpScript : MonoBehaviour
{
	// Token: 0x06001A46 RID: 6726 RVA: 0x001152EC File Offset: 0x001134EC
	private void Start()
	{
		this.Prompt.enabled = true;
		if (this.Eighties)
		{
			if (DateGlobals.Week == 2)
			{
				this.EventSpeech[3] = "...I've got a feeling that you were just snooping around in my bag, but...yeah, to be honest, I do have a big problem.";
				this.EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				this.EventSpeech[5] = "I wanted to prove to the boys that I'm just as brave as they are, so I decided to spend a night in the asylum. Big mistake.";
				this.EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				this.EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				this.EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				this.EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				this.EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				this.EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				this.EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				this.EventSpeech[14] = "No! I don't want ANY one to see those photos, not even the police!";
				this.EventSpeech[15] = "Ugh! I just want to go back to that asylum, and burn the whole building down, so this can never happen to anyone else! But...";
				this.EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. I don't want them to die in a fire...";
				this.EventSpeech[18] = "Whoa, whoa, whoa - calm down. Maybe you're just saying that because you're getting all fired up from listening to my story...";
				this.EventSpeech[20] = "I'm worried that you might get hurt! But...if you could actually burn all of those photos...it would mean the world to me...";
				this.EventSpeech[22] = "...well...okay...but...be careful, alright?!";
			}
			if (DateGlobals.Week == 3)
			{
				this.EventSpeech[3] = "...oh...gosh...um...I never really intended for anyone to find out about this...but...well...at this point...I need help...";
				this.EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				this.EventSpeech[5] = "I'm probably the least brave person in Akademi. I wanted to build up my courage, so I decided to spend a night in the asylum.";
				this.EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				this.EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				this.EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				this.EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				this.EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				this.EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				this.EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				this.EventSpeech[14] = "No! I don't want ANY one to see those photos, not even the police!";
				this.EventSpeech[15] = "I want to go back there and beg that man to please just burn all the photos he took of me, but...well...I doubt he would.";
				this.EventSpeech[16] = "Also, a bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				this.EventSpeech[18] = "Huh?! Wh...what?! No! Listen to what you're saying! You could get seriously hurt if you go into that asylum!";
				this.EventSpeech[20] = "...ohhhhh...I'm...really worried...but...if you could actually burn all of those photos...it would mean the world to me...";
				this.EventSpeech[22] = "...gosh...you're definitely a lot more brave than I am...well...be careful...and...um...g-good luck!!";
			}
			if (DateGlobals.Week == 4)
			{
				this.EventSpeech[3] = "Ugh...I really, really wanted this to stay a secret...but...I've got to admit it, I can't solve this problem on my own...";
				this.EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				this.EventSpeech[5] = "I don't believe in ghosts or anything like that, so I decided to spend a night in the asylum to prove that it's no big deal...";
				this.EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				this.EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				this.EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				this.EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				this.EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				this.EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				this.EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				this.EventSpeech[14] = "No! I don't want ANY one to see those photos, not even the police!";
				this.EventSpeech[15] = "I want to go back there and kick that guy's ass! But...I worry that it would just turn out the same as it did last time...";
				this.EventSpeech[16] = "Also, a bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				this.EventSpeech[18] = "...whoa. Hey, wait a minute. Think about what you're saying...the asylum is a really, really dangerous place right now...";
				this.EventSpeech[20] = "...huh...well...if you could actually burn all of those photos...it would mean the world to me...";
				this.EventSpeech[22] = "I...really hope you can pull it off. I'll be rooting for you!";
			}
			if (DateGlobals.Week == 5)
			{
				this.EventSpeech[3] = "Excuse me?! For future reference, you do NOT have permission to touch my belongings - EVER. ...but...I...do need some help...";
				this.EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				this.EventSpeech[5] = "A simple test of courage should be easy for one such as myself, so...I decided to go to the asylum. But, well...";
				this.EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				this.EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				this.EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				this.EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				this.EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				this.EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				this.EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				this.EventSpeech[14] = "Um?! Hello?! Excuse me?! Is there a brain in your head?! If the police catch him, they'll see those photos of me!!";
				this.EventSpeech[15] = "Clearly, the man wants to sell those photos. I should simply offer to buy them from him myself, but...well...";
				this.EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				this.EventSpeech[18] = "Good! There's no reason why I should be risking my life out there. That's what people like YOU are for.";
				this.EventSpeech[19] = "...";
				this.EventClip[19] = this.ShortSilence;
				this.EventSpeech[20] = "Here, I'll give you my phone number so that you can call me when you're done.";
				this.EventSpeech[21] = "...";
				this.EventClip[21] = this.ShortSilence;
				this.EventSpeech[22] = "Well, don't just stand there - get moving!";
			}
			if (DateGlobals.Week == 6)
			{
				this.EventSpeech[3] = "Oh, gosh! Please, keep your voice down! Gossip can ruin an idol's career! ...but...with that said...I do need some help...";
				this.EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				this.EventSpeech[5] = "I thought it would give me inspiration for a song, so I decided to visit the asylum...but...that was a huge mistake...";
				this.EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				this.EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				this.EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				this.EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				this.EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				this.EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				this.EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				this.EventSpeech[14] = "I don't want to be involved in a scandal this early in my career! I want this to go away as quietly as possible!";
				this.EventSpeech[15] = "I want to go back there and try to strike some kind of deal with that man, but I might just make the situation worse. Also...";
				this.EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				this.EventSpeech[18] = "Whoa, whoa, whoa. Hey, hey...wait. Are you sure you want to say something like that? I mean, this is really dangerous...";
				this.EventSpeech[20] = "...I...I'm...really worried, but...if you could actually burn all of those photos...it would mean the world to me...";
				this.EventSpeech[22] = "Oh, gosh...thank you so much for this...please, burn those photos...my future career as an idol is riding on this...!";
			}
			if (DateGlobals.Week == 7)
			{
				this.EventSpeech[3] = "Dear...it doesn't take a genius to tell that you were snooping around in my bag...but...nonetheless...I  require assistance...";
				this.EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				this.EventSpeech[5] = "I...got tired of being ''perfect'' and behaving properly all the time, so I decided to be reckless...and I went to the asylum.";
				this.EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				this.EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				this.EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				this.EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				this.EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				this.EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				this.EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				this.EventSpeech[14] = "When attorneys show evidence in court, the evidence can be seen by everyone present. I don't want anyone to see those photos!";
				this.EventSpeech[15] = "I've been racking my brain to come up with a solution, but nothing comes to mind. I want the photos to be destroyed, but...";
				this.EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				this.EventSpeech[18] = "Um - I appreciate you saying so, but - I must caution you against such a course of action. It would be incredibly dangerous...";
				this.EventSpeech[20] = "You...do you truly believe yourself to be capable of completing such a task? I...I suppose...if you really...think you can...";
				this.EventSpeech[22] = "Please, I'm begging you, be as careful as possible. If anything were to go wrong, I'd feel guilty for the rest of my life...";
			}
			if (DateGlobals.Week == 8)
			{
				this.EventSpeech[3] = "Thank you for being so kind. To be honest, yes, there is a problem that I would like to ask for help with.";
				this.EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				this.EventSpeech[5] = "I wanted to prove to myself that courage is a trait that I do not lack...so I went to the asylum. It was a foolish mistake.";
				this.EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				this.EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				this.EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				this.EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				this.EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				this.EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				this.EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				this.EventSpeech[14] = "The only man who should see a woman nude is her husband! If the police saw those photos, I could never be a bride!";
				this.EventSpeech[15] = "Sadly, I do not think that it will be possible to reason with the man. Destruction of those photos is the only option. But...";
				this.EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				this.EventSpeech[18] = "As much as I appreciate your offer, I must turn it down. I cannot put another person's safety before my own.";
				this.EventSpeech[20] = "...if...you insist...then...I may have to accept your offer...for...I truly cannot solve this problem on my own...";
				this.EventSpeech[22] = "...here is my telephone number...please...be cautious...I will be praying for your safe return...";
			}
			if (DateGlobals.Week == 9)
			{
				this.EventSpeech[3] = "Girl, I know what that means. You were snooping. But, I'll forgive you. I have a much bigger problem, and I need advice.";
				this.EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				this.EventSpeech[5] = "My friends dared me to do it, so I did it. I thought it would be a piece of cake. But...well, things went horribly wrong.";
				this.EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				this.EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				this.EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				this.EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				this.EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				this.EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				this.EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				this.EventSpeech[14] = "I pose for photoshoots all the time, but I'm drawing a line right here - NOBODY should see those photos, not even the cops!";
				this.EventSpeech[15] = "I want to burn those photos. Seriously, burn them to ashes. I would have already done it by now, but there's a problem...";
				this.EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				this.EventSpeech[18] = "Would you...would you do that for me? If you'd do that, then I...no. I can't let you do that. It's too dangerous.";
				this.EventSpeech[20] = "I...well...I don't want to ask you to do this...but...if you could destroy those photos...you'd fix everything...";
				this.EventSpeech[22] = "...thank you...but...if there's danger, just get out of there, okay? I really, really don't want you to get hurt...";
				return;
			}
			if (DateGlobals.Week == 10)
			{
				this.EventSpeech[3] = "...you don't need to make up an excuse. Just admit that you were snooping around in my bag. ...but, yes, I'm dealing with a problem that I can't handle on my own.";
				this.EventSpeech[4] = "There's an abandoned insane asylum just outside of town. I heard a rumor that a man is luring girls inside, threatening them at knifepoint, and forcing them to strip for him.";
				this.EventSpeech[5] = "I decided to purchase some pepper spray for my own protection and investigate the rumor myself.";
				this.EventSpeech[6] = "I arrived at the asylum and began exploring. Just a few minutes into my investigation, he appeared. I took out the pepper spray, but he knocked it out of my hands before I could use it.";
				this.EventSpeech[7] = "He trapped me inside a room with him, and...exactly as he had done with all of his other victims...he demanded that I strip for him.";
				this.EventSpeech[8] = "I was...terrified. I didn't want to die, so...I just...did what he told me to do. He didn't touch me, but...he did take some...compromising pictures of me.";
				this.EventSpeech[9] = "He had a big duffle bag with him. At one point, I saw what was inside...a bunch of camera equipment, along with dozens of photographs of other girls.";
				this.EventSpeech[10] = "Evidently, the man started a rumor about the asylum being haunted, to trick teenage girls into thinking it was a good spot for a ''test of courage''...";
				this.EventSpeech[11] = "He must be camping out in that asylum every night, waiting for girls to show up, so that he can corner them and take pictures of them. What a vile man.";
				this.EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I got away safely, but...I haven't quite recovered from the experience.";
				this.EventSpeech[14] = "What?! Never! I have a reputation to maintain! I'm supposed to be a fearless, tough-as-nails, hardboiled detective! I can't let anyone know that some pervert with a camera got the better of me!";
				this.EventSpeech[15] = "Ugh...I just want to go back to that asylum and burn all of that man's photographs to ashes! But...there are factors that are complicating the matter.";
				this.EventSpeech[16] = "A bunch of homeless people and drug addicts have begun occupying the asylum. If I couldn't even defend myself against one man, I doubt I would survive if I went back in there at this point...";
				this.EventSpeech[18] = "...what?! Do you even realize what you're saying?! You would be putting your life in danger!";
				this.EventSpeech[20] = "You...ugh. If you actually succeed in burning those photos...well, I can't possibly overstate how much that would mean to me. My career is riding on this, after all.";
				this.EventSpeech[22] = "...I...fine. But, just...be careful.";
			}
		}
	}

	// Token: 0x06001A47 RID: 6727 RVA: 0x00115B5C File Offset: 0x00113D5C
	private void Update()
	{
		if (!this.Unable)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.Eighties)
				{
					this.EventStudentID = this.StudentManager.RivalID;
				}
				bool flag = true;
				Debug.Log("The player has activated an ''Offer Help'' prompt.");
				if (this.EventStudentID == 5)
				{
					Debug.Log("Checking to see if we have a bully photo...");
					flag = false;
					for (int i = 1; i < 26; i++)
					{
						Debug.Log("PlayerGlobals.GetBullyPhoto(ID) is: " + PlayerGlobals.GetBullyPhoto(i).ToString() + "!");
						if (PlayerGlobals.GetBullyPhoto(i) > 0)
						{
							flag = true;
						}
					}
				}
				if (!this.Yandere.Chased && this.Yandere.Chasers == 0 && flag)
				{
					this.Jukebox.Dip = 0.1f;
					this.Yandere.EmptyHands();
					this.Yandere.CanMove = false;
					this.Student = this.StudentManager.Students[this.EventStudentID];
					this.Student.Prompt.Label[0].text = "     Talk";
					this.Student.Pushable = false;
					this.Student.Meeting = false;
					this.Student.Routine = false;
					this.Student.MeetTimer = 0f;
					this.Student.HelpOffered = true;
					this.Student.InEvent = true;
					this.Offering = true;
					if (this.EventStudentID == 11 && this.Student.Follower != null)
					{
						this.Student.Follower.IdleAnim = "f02_nervousLeftRight_00";
						this.Student.Follower.SpeechLines.Stop();
						this.OriginalPosition = this.StudentManager.Hangouts.List[10].position;
						this.OriginalRotation = this.StudentManager.Hangouts.List[10].eulerAngles;
						ScheduleBlock scheduleBlock = this.Student.Follower.ScheduleBlocks[this.Student.Follower.Phase];
						scheduleBlock.destination = "Hangout";
						scheduleBlock.action = "Stand";
						this.Student.Follower.Actions[this.Student.Follower.Phase] = StudentActionType.Wait;
						this.Student.Follower.CurrentAction = StudentActionType.Wait;
						this.Student.Follower.GetDestinations();
						this.Student.Follower.CurrentDestination = this.BystanderSpot;
						this.Student.Follower.Pathfinding.target = this.BystanderSpot;
					}
					if (!GameGlobals.Eighties && this.EventStudentID == 11 && !this.Eavesdropped)
					{
						this.EventSpeech[3] = this.AltSpeech;
						this.EventClip[3] = this.AltClip;
					}
				}
				else if (!flag)
				{
					this.Yandere.NotificationManager.CustomText = "You lack a valid photo";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			if (this.Offering)
			{
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, base.transform.rotation, Time.deltaTime * 10f);
				this.Yandere.MoveTowardsTarget(base.transform.position + Vector3.down);
				Quaternion b = Quaternion.LookRotation(this.Yandere.transform.position - this.Student.transform.position);
				this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, b, Time.deltaTime * 10f);
				this.Student.MoveTowardsTarget(this.Student.CurrentDestination.position);
				Animation characterAnimation = this.Yandere.CharacterAnimation;
				Animation characterAnimation2 = this.Student.CharacterAnimation;
				if (!this.Spoken)
				{
					if (this.EventSpeaker[this.EventPhase] == 1)
					{
						characterAnimation.CrossFade(this.EventAnim[this.EventPhase]);
						characterAnimation2.CrossFade(this.Student.IdleAnim, 1f);
					}
					else
					{
						characterAnimation2.CrossFade(this.EventAnim[this.EventPhase]);
						characterAnimation.CrossFade(this.Yandere.IdleAnim, 1f);
					}
					this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
					this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
					AudioSource component = base.GetComponent<AudioSource>();
					component.clip = this.EventClip[this.EventPhase];
					component.Play();
					this.Spoken = true;
					return;
				}
				if (!this.Yandere.PauseScreen.Show && Input.GetButtonDown("A"))
				{
					this.Timer += this.EventClip[this.EventPhase].length + 1f;
				}
				if (this.EventSpeaker[this.EventPhase] == 1)
				{
					if (characterAnimation[this.EventAnim[this.EventPhase]].time >= characterAnimation[this.EventAnim[this.EventPhase]].length)
					{
						characterAnimation.CrossFade(this.Yandere.IdleAnim);
					}
				}
				else if (characterAnimation2[this.EventAnim[this.EventPhase]].time >= characterAnimation2[this.EventAnim[this.EventPhase]].length)
				{
					characterAnimation2.CrossFade(this.Student.IdleAnim);
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > this.EventClip[this.EventPhase].length)
				{
					this.EventSubtitle.text = string.Empty;
				}
				else
				{
					this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
				}
				if (this.Timer > this.EventClip[this.EventPhase].length + 1f)
				{
					if (this.EventStudentID == 5 && this.EventPhase == 2)
					{
						this.Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
						base.StartCoroutine(this.Yandere.PauseScreen.PhotoGallery.GetPhotos());
						this.Yandere.PauseScreen.PhotoGallery.gameObject.SetActive(true);
						this.Yandere.PauseScreen.PhotoGallery.NamingBully = true;
						this.Yandere.PauseScreen.MainMenu.SetActive(false);
						this.Yandere.PauseScreen.Panel.enabled = true;
						this.Yandere.PauseScreen.Sideways = true;
						this.Yandere.PauseScreen.Show = true;
						Time.timeScale = 0.0001f;
						this.Yandere.PauseScreen.PhotoGallery.UpdateButtonPrompts();
						this.Student.HelpOffered = false;
						this.Offering = false;
						return;
					}
					this.Continue();
					return;
				}
			}
			else
			{
				if (this.Eighties)
				{
					this.EventStudentID = this.StudentManager.RivalID;
				}
				if (this.StudentManager.Students[this.EventStudentID] != null && (this.StudentManager.Students[this.EventStudentID].Pushed || !this.StudentManager.Students[this.EventStudentID].Alive))
				{
					base.gameObject.SetActive(false);
					return;
				}
			}
		}
		else
		{
			this.Prompt.Circle[0].fillAmount = 1f;
		}
	}

	// Token: 0x06001A48 RID: 6728 RVA: 0x00116338 File Offset: 0x00114538
	public void UpdateLocation()
	{
		if (this.Eighties)
		{
			this.EventStudentID = this.StudentManager.RivalID;
		}
		this.Student = this.StudentManager.Students[this.EventStudentID];
		Debug.Log("An ''Offer Help'' prompt has been told to update its location.");
		if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[7])
		{
			base.transform.position = this.Locations[1].position;
			base.transform.eulerAngles = this.Locations[1].eulerAngles;
		}
		else if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[8])
		{
			base.transform.position = this.Locations[2].position;
			base.transform.eulerAngles = this.Locations[2].eulerAngles;
		}
		else if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[9])
		{
			base.transform.position = this.Locations[3].position;
			base.transform.eulerAngles = this.Locations[3].eulerAngles;
		}
		else if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[10])
		{
			base.transform.position = this.Locations[4].position;
			base.transform.eulerAngles = this.Locations[4].eulerAngles;
		}
		if (this.EventStudentID == 5)
		{
			this.Prompt.MyCollider.enabled = true;
			return;
		}
		if ((this.EventStudentID > 10 && this.EventStudentID < 21) || this.EventStudentID == 30)
		{
			if (!this.Student.Friend)
			{
				this.Prompt.Label[0].text = "     Must Befriend Student First";
				this.Unable = true;
			}
			else
			{
				this.Unable = false;
			}
			this.Prompt.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001A49 RID: 6729 RVA: 0x0011655C File Offset: 0x0011475C
	public void Continue()
	{
		Debug.Log("Proceeding to next line.");
		this.Offering = true;
		this.Spoken = false;
		this.EventPhase++;
		this.Timer = 0f;
		if (this.EventStudentID == 30 && this.EventPhase == 14)
		{
			if (!ConversationGlobals.GetTopicDiscovered(23))
			{
				this.Yandere.NotificationManager.TopicName = "Family";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(23, true);
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(23, this.EventStudentID))
			{
				this.Yandere.NotificationManager.TopicName = "Family";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(23, this.EventStudentID, true);
			}
		}
		if (this.EventPhase == this.EventSpeech.Length - 1)
		{
			if (this.EventStudentID == 11 || (this.Eighties && this.EventStudentID > 10 && this.EventStudentID < 21))
			{
				SchemeGlobals.SetSchemeStage(6, 8);
				this.Yandere.PauseScreen.Schemes.UpdateInstructions();
				return;
			}
			if (this.EventStudentID == 30)
			{
				SchemeGlobals.HelpingKokona = true;
				Debug.Log("SchemeGlobals.HelpingKokona is now true.");
				return;
			}
		}
		else if (this.EventPhase == this.EventSpeech.Length)
		{
			this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
			this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
			this.Student.StopMeeting();
			this.Student.InEvent = false;
			this.Student.Routine = true;
			this.Yandere.CanMove = true;
			this.Jukebox.Dip = 1f;
			if (this.EventStudentID == 11 && this.Student.Follower != null)
			{
				this.Student.Follower.IdleAnim = this.Student.Follower.OriginalIdleAnim;
				this.StudentManager.Hangouts.List[10].position = this.OriginalPosition;
				this.StudentManager.Hangouts.List[10].eulerAngles = this.OriginalRotation;
				ScheduleBlock scheduleBlock = this.Student.Follower.ScheduleBlocks[this.Student.Follower.Phase];
				scheduleBlock.destination = "Follow";
				scheduleBlock.action = "Follow";
				this.Student.Follower.Actions[this.Student.Follower.Phase] = StudentActionType.Follow;
				this.Student.Follower.CurrentAction = StudentActionType.Follow;
				this.Student.Follower.GetDestinations();
				this.Student.Follower.CurrentDestination = this.Student.FollowTargetDestination;
				this.Student.Follower.Pathfinding.target = this.Student.FollowTargetDestination;
			}
			if (this.Student.Rival)
			{
				this.StudentManager.UpdateInfatuatedTargetDistances();
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002AF7 RID: 10999
	public StudentManagerScript StudentManager;

	// Token: 0x04002AF8 RID: 11000
	public JukeboxScript Jukebox;

	// Token: 0x04002AF9 RID: 11001
	public StudentScript Student;

	// Token: 0x04002AFA RID: 11002
	public YandereScript Yandere;

	// Token: 0x04002AFB RID: 11003
	public PromptScript Prompt;

	// Token: 0x04002AFC RID: 11004
	public Vector3 OriginalPosition;

	// Token: 0x04002AFD RID: 11005
	public Vector3 OriginalRotation;

	// Token: 0x04002AFE RID: 11006
	public UILabel EventSubtitle;

	// Token: 0x04002AFF RID: 11007
	public Transform BystanderSpot;

	// Token: 0x04002B00 RID: 11008
	public Transform[] Locations;

	// Token: 0x04002B01 RID: 11009
	public AudioClip[] EventClip;

	// Token: 0x04002B02 RID: 11010
	public string[] EventSpeech;

	// Token: 0x04002B03 RID: 11011
	public string[] EventAnim;

	// Token: 0x04002B04 RID: 11012
	public int[] EventSpeaker;

	// Token: 0x04002B05 RID: 11013
	public bool Eavesdropped;

	// Token: 0x04002B06 RID: 11014
	public bool Eighties;

	// Token: 0x04002B07 RID: 11015
	public bool Offering;

	// Token: 0x04002B08 RID: 11016
	public bool Spoken;

	// Token: 0x04002B09 RID: 11017
	public bool Unable;

	// Token: 0x04002B0A RID: 11018
	public int EventStudentID;

	// Token: 0x04002B0B RID: 11019
	public int EventPhase = 1;

	// Token: 0x04002B0C RID: 11020
	public float Timer;

	// Token: 0x04002B0D RID: 11021
	public AudioClip ShortSilence;

	// Token: 0x04002B0E RID: 11022
	public AudioClip AltClip;

	// Token: 0x04002B0F RID: 11023
	public string AltSpeech;
}
