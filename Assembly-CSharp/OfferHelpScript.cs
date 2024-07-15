using System.IO;
using UnityEngine;

public class OfferHelpScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public StudentScript Student;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	public UILabel EventSubtitle;

	public Transform BystanderSpot;

	public Transform[] Locations;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public int[] EventSpeaker;

	public bool SimpleLookStatus;

	public bool Eavesdropped;

	public bool Eighties;

	public bool Offering;

	public bool Spoken;

	public bool Unable;

	public bool Rival;

	public int EventStudentID;

	public int EventPhase = 1;

	public float Timer;

	public AudioClip ShortSilence;

	public AudioClip AltClip;

	public string AltSpeech;

	private void Start()
	{
		Debug.Log("This ''Offer Help'' prompt is now running its Start() function.");
		MyAudio = GetComponent<AudioSource>();
		Prompt.enabled = true;
		if (EventStudentID != 5)
		{
			EventStudentID = StudentManager.RivalID;
		}
		if (Eighties)
		{
			if (DateGlobals.Week == 2)
			{
				EventSpeech[3] = "...I've got a feeling that you were just snooping around in my bag, but...yeah, to be honest, I do have a big problem.";
				EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				EventSpeech[5] = "I wanted to prove to the boys that I'm just as brave as they are, so I decided to spend a night in the asylum. Big mistake.";
				EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				EventSpeech[14] = "No! I don't want ANY one to see those photos, not even the police!";
				EventSpeech[15] = "Ugh! I just want to go back to that asylum, and burn the whole building down, so this can never happen to anyone else! But...";
				EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. I don't want them to die in a fire...";
				EventSpeech[18] = "Whoa, whoa, whoa - calm down. Maybe you're just saying that because you're getting all fired up from listening to my story...";
				EventSpeech[20] = "I'm worried that you might get hurt! But...if you could actually burn all of those photos...it would mean the world to me...";
				EventSpeech[22] = "...well...okay...but...be careful, alright?!";
			}
			else if (DateGlobals.Week == 3)
			{
				EventSpeech[3] = "...oh...gosh...um...I never really intended for anyone to find out about this...but...well...at this point...I need help...";
				EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				EventSpeech[5] = "I'm probably the least brave person in Akademi. I wanted to build up my courage, so I decided to spend a night in the asylum.";
				EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				EventSpeech[14] = "No! I don't want ANY one to see those photos, not even the police!";
				EventSpeech[15] = "I want to go back there and beg that man to please just burn all the photos he took of me, but...well...I doubt he would.";
				EventSpeech[16] = "Also, a bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				EventSpeech[18] = "Huh?! Wh...what?! No! Listen to what you're saying! You could get seriously hurt if you go into that asylum!";
				EventSpeech[20] = "...ohhhhh...I'm...really worried...but...if you could actually burn all of those photos...it would mean the world to me...";
				EventSpeech[22] = "...gosh...you're definitely a lot more brave than I am...well...be careful...and...um...g-good luck!!";
			}
			else if (DateGlobals.Week == 4)
			{
				EventSpeech[3] = "Ugh...I really, really wanted this to stay a secret...but...I've got to admit it, I can't solve this problem on my own...";
				EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				EventSpeech[5] = "I don't believe in ghosts or anything like that, so I decided to spend a night in the asylum to prove that it's no big deal...";
				EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				EventSpeech[14] = "No! I don't want ANY one to see those photos, not even the police!";
				EventSpeech[15] = "I want to go back there and kick that guy's ass! But...I worry that it would just turn out the same as it did last time...";
				EventSpeech[16] = "Also, a bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				EventSpeech[18] = "...whoa. Hey, wait a minute. Think about what you're saying...the asylum is a really, really dangerous place right now...";
				EventSpeech[20] = "...huh...well...if you could actually burn all of those photos...it would mean the world to me...";
				EventSpeech[22] = "I...really hope you can pull it off. I'll be rooting for you!";
			}
			else if (DateGlobals.Week == 5)
			{
				EventSpeech[3] = "Excuse me?! For future reference, you do NOT have permission to touch my belongings - EVER. ...but...I...do need some help...";
				EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				EventSpeech[5] = "A simple test of courage should be easy for one such as myself, so...I decided to go to the asylum. But, well...";
				EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				EventSpeech[14] = "Um?! Hello?! Excuse me?! Is there a brain in your head?! If the police catch him, they'll see those photos of me!!";
				EventSpeech[15] = "Clearly, the man wants to sell those photos. I should simply offer to buy them from him myself, but...well...";
				EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				EventSpeech[18] = "Good! There's no reason why I should be risking my life out there. That's what people like YOU are for.";
				EventSpeech[19] = "...";
				EventClip[19] = ShortSilence;
				EventSpeech[20] = "Here, I'll give you my phone number so that you can call me when you're done.";
				EventSpeech[21] = "...";
				EventClip[21] = ShortSilence;
				EventSpeech[22] = "Well, don't just stand there - get moving!";
			}
			else if (DateGlobals.Week == 6)
			{
				EventSpeech[3] = "Oh, gosh! Please, keep your voice down! Gossip can ruin an idol's career! ...but...with that said...I do need some help...";
				EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				EventSpeech[5] = "I thought it would give me inspiration for a song, so I decided to visit the asylum...but...that was a huge mistake...";
				EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				EventSpeech[14] = "I don't want to be involved in a scandal this early in my career! I want this to go away as quietly as possible!";
				EventSpeech[15] = "I want to go back there and try to strike some kind of deal with that man, but I might just make the situation worse. Also...";
				EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				EventSpeech[18] = "Whoa, whoa, whoa. Hey, hey...wait. Are you sure you want to say something like that? I mean, this is really dangerous...";
				EventSpeech[20] = "...I...I'm...really worried, but...if you could actually burn all of those photos...it would mean the world to me...";
				EventSpeech[22] = "Oh, gosh...thank you so much for this...please, burn those photos...my future career as an idol is riding on this...!";
			}
			else if (DateGlobals.Week == 7)
			{
				EventSpeech[3] = "Dear...it doesn't take a genius to tell that you were snooping around in my bag...but...nonetheless...I  require assistance...";
				EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				EventSpeech[5] = "I...got tired of being ''perfect'' and behaving properly all the time, so I decided to be reckless...and I went to the asylum.";
				EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				EventSpeech[14] = "When attorneys show evidence in court, the evidence can be seen by everyone present. I don't want anyone to see those photos!";
				EventSpeech[15] = "I've been racking my brain to come up with a solution, but nothing comes to mind. I want the photos to be destroyed, but...";
				EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				EventSpeech[18] = "Um - I appreciate you saying so, but - I must caution you against such a course of action. It would be incredibly dangerous...";
				EventSpeech[20] = "You...do you truly believe yourself to be capable of completing such a task? I...I suppose...if you really...think you can...";
				EventSpeech[22] = "Please, I'm begging you, be as careful as possible. If anything were to go wrong, I'd feel guilty for the rest of my life...";
			}
			else if (DateGlobals.Week == 8)
			{
				EventSpeech[3] = "Thank you for being so kind. To be honest, yes, there is a problem that I would like to ask for help with.";
				EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				EventSpeech[5] = "I wanted to prove to myself that courage is a trait that I do not lack...so I went to the asylum. It was a foolish mistake.";
				EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				EventSpeech[14] = "The only man who should see a woman nude is her husband! If the police saw those photos, I could never be a bride!";
				EventSpeech[15] = "Sadly, I do not think that it will be possible to reason with the man. Destruction of those photos is the only option. But...";
				EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				EventSpeech[18] = "As much as I appreciate your offer, I must turn it down. I cannot put another person's safety before my own.";
				EventSpeech[20] = "...if...you insist...then...I may have to accept your offer...for...I truly cannot solve this problem on my own...";
				EventSpeech[22] = "...here is my telephone number...please...be cautious...I will be praying for your safe return...";
			}
			else if (DateGlobals.Week == 9)
			{
				EventSpeech[3] = "Girl, I know what that means. You were snooping. But, I'll forgive you. I have a much bigger problem, and I need advice.";
				EventSpeech[4] = "There's an abandoned insane asylum just outside of town. Spending a night there is a popular ''test of courage.''";
				EventSpeech[5] = "My friends dared me to do it, so I did it. I thought it would be a piece of cake. But...well, things went horribly wrong.";
				EventSpeech[6] = "In the asylum, I was confronted by a man with a knife. I ran from him, but I got cornered in a room with only one exit.";
				EventSpeech[7] = "He blocked the doorway and told me...to strip my clothing off. I was terrified of losing my life, so...I did as I was told.";
				EventSpeech[8] = "He didn't lay a hand on me...but he took out a camera and...took a bunch of pictures of me...";
				EventSpeech[9] = "Actually, he had a big duffle bag with him. At one point, I saw what was inside...a bunch of photographs of other girls.";
				EventSpeech[10] = "Ugh, I bet that creep is the one who started the rumor about the asylum being a good place for a ''test of courage...''";
				EventSpeech[11] = "I wonder how many other girls have already been victimized in the same way that I was...";
				EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I still have nightmares about it...";
				EventSpeech[14] = "I pose for photoshoots all the time, but I'm drawing a line right here - NOBODY should see those photos, not even the cops!";
				EventSpeech[15] = "I want to burn those photos. Seriously, burn them to ashes. I would have already done it by now, but there's a problem...";
				EventSpeech[16] = "A bunch of homeless people and drug addicts are squatting in the asylum right now. It's become a real dangerous place...";
				EventSpeech[18] = "Would you...would you do that for me? If you'd do that, then I...no. I can't let you do that. It's too dangerous.";
				EventSpeech[20] = "I...well...I don't want to ask you to do this...but...if you could destroy those photos...you'd fix everything...";
				EventSpeech[22] = "...thank you...but...if there's danger, just get out of there, okay? I really, really don't want you to get hurt...";
			}
			else if (DateGlobals.Week == 10)
			{
				EventSpeech[3] = "...you don't need to make up an excuse. Just admit that you were snooping around in my bag. ...but, yes, I'm dealing with a problem that I can't handle on my own.";
				EventSpeech[4] = "There's an abandoned insane asylum just outside of town. I heard a rumor that a man is luring girls inside, threatening them at knifepoint, and forcing them to strip for him.";
				EventSpeech[5] = "I decided to purchase some pepper spray for my own protection and investigate the rumor myself.";
				EventSpeech[6] = "I arrived at the asylum and began exploring. Just a few minutes into my investigation, he appeared. I took out the pepper spray, but he knocked it out of my hands before I could use it.";
				EventSpeech[7] = "He trapped me inside a room with him, and...exactly as he had done with all of his other victims...he demanded that I strip for him.";
				EventSpeech[8] = "I was...terrified. I didn't want to die, so...I just...did what he told me to do. He didn't touch me, but...he did take some...compromising pictures of me.";
				EventSpeech[9] = "He had a big duffle bag with him. At one point, I saw what was inside...a bunch of camera equipment, along with dozens of photographs of other girls.";
				EventSpeech[10] = "Evidently, the man started a rumor about the asylum being haunted, to trick teenage girls into thinking it was a good spot for a ''test of courage''...";
				EventSpeech[11] = "He must be camping out in that asylum every night, waiting for girls to show up, so that he can corner them and take pictures of them. What a vile man.";
				EventSpeech[12] = "Eventually, I saw an opportunity to escape, so I grabbed my clothes and ran away. I got away safely, but...I haven't quite recovered from the experience.";
				EventSpeech[14] = "What?! Never! I have a reputation to maintain! I'm supposed to be a fearless, tough-as-nails, hardboiled detective! I can't let anyone know that some pervert with a camera got the better of me!";
				EventSpeech[15] = "Ugh...I just want to go back to that asylum and burn all of that man's photographs to ashes! But...there are factors that are complicating the matter.";
				EventSpeech[16] = "A bunch of homeless people and drug addicts have begun occupying the asylum. If I couldn't even defend myself against one man, I doubt I would survive if I went back in there at this point...";
				EventSpeech[18] = "...what?! Do you even realize what you're saying?! You would be putting your life in danger!";
				EventSpeech[20] = "You...ugh. If you actually succeed in burning those photos...well, I can't possibly overstate how much that would mean to me. My career is riding on this, after all.";
				EventSpeech[22] = "...I...fine. But, just...be careful.";
			}
			if (!GameGlobals.CustomMode)
			{
				return;
			}
			string path = Application.streamingAssetsPath + "/CustomMode/Events/Week" + DateGlobals.Week + "/BefriendBetray.txt";
			Debug.Log("Path is: " + Application.streamingAssetsPath + "/CustomMode/Events/Week" + DateGlobals.Week + "/BefriendBetray.txt");
			string[] array = File.ReadAllLines(path);
			for (int i = 0; i < array.Length; i++)
			{
				EventSpeech[i + 1] = array[i];
				if (EventSpeech[i + 1].Contains("Y: "))
				{
					EventSpeech[i + 1] = EventSpeech[i + 1].Replace("Y: ", "");
					EventSpeaker[i + 1] = 1;
				}
				else if (EventSpeech[i + 1].Contains("R: "))
				{
					EventSpeech[i + 1] = EventSpeech[i + 1].Replace("R: ", "");
					EventSpeaker[i + 1] = 2;
				}
			}
			for (int j = 1; j < EventClip.Length; j++)
			{
				EventClip[j] = EventClip[0];
			}
		}
		else if (Rival && DateGlobals.Week == 2)
		{
			EventSpeech[1] = "Oh! So, it was you who left that note in my locker!";
			EventSpeech[2] = "Uh...so...you wanted to talk to me about...that new bakery?";
			EventSpeech[3] = "I overheard your phone call. What do you suspect the new bakery is doing?";
			EventSpeech[4] = "...gosh...it's a long story...I wouldn't even know where to begin...";
			EventSpeech[5] = "Start at the beginning.";
			EventSpeech[6] = "...(sigh)...recently, a new bakery opened up in town. Shortly afterwards...a bunch of terrible things started happening to my family's bakery.";
			EventSpeech[7] = "Like what?";
			EventSpeech[8] = "Well, earlier today, a bunch of rats suddenly appeared in our kitchen, right before a health inspection was supposed to take place!";
			EventSpeech[9] = "There's no way I can just write that off as a coincidence. I'm certain that the new bakery is behind this...and everything else that's been happening lately, too.";
			EventSpeech[10] = "But...I don't have any proof! And, between my studies and bakery responsibilities, I don't have any time to gather evidence...";
			EventSpeech[11] = "Do you know their address?";
			EventSpeech[12] = "Yes, I...wait, why are you asking?";
			EventSpeech[13] = "I'd like to help you.";
			EventSpeech[14] = "But...but, how?";
			EventSpeech[15] = "I'll investigate the bakery and search for evidence that they're sabotaging your family's business.";
			EventSpeech[16] = "Whoa! Slow down! You don't have to do that. It could end up being a huge waste of time. It might even be dangerous!";
			EventSpeech[17] = "You don't have to worry about me. I'm tougher than I look.";
			EventSpeech[18] = "Oh, gosh...I really don't know about this!";
			EventSpeech[19] = "Please, just relax. I'll be fine.";
			EventSpeech[20] = "...well...if you say so...(sigh)...I'll text you their address later...";
			EventSpeech[21] = "Thank you.";
			EventSpeech[22] = "...but...be careful, okay?! I don't want anyone to get in trouble while trying to help me...";
			EventSpeech[23] = "Everything will turn out fine. I promise.";
			MyAudio.volume = 0f;
			for (int k = 1; k < EventClip.Length; k++)
			{
				EventClip[k] = ShortSilence;
			}
		}
	}

	private void Update()
	{
		if (!Unable)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Eighties)
				{
					EventStudentID = StudentManager.RivalID;
				}
				bool flag = true;
				Debug.Log("The player has activated an ''Offer Help'' prompt.");
				if (EventStudentID == 5)
				{
					Debug.Log("Checking to see if we have a bully photo...");
					flag = false;
					for (int i = 1; i < 26; i++)
					{
						Debug.Log("PhotoGallery.BullyPhoto[ID] is: " + Yandere.PauseScreen.PhotoGallery.BullyPhoto[i] + "!");
						if (Yandere.PauseScreen.PhotoGallery.PhotographTaken[i] && Yandere.PauseScreen.PhotoGallery.BullyPhoto[i] > 0)
						{
							flag = true;
						}
					}
				}
				if (!Yandere.Chased && Yandere.Chasers == 0 && flag)
				{
					Jukebox.Dip = 0.1f;
					Yandere.EmptyHands();
					Yandere.CanMove = false;
					Student = StudentManager.Students[EventStudentID];
					Student.Prompt.Label[0].text = "     Talk";
					Student.Pushable = false;
					Student.Meeting = false;
					Student.Routine = false;
					Student.MeetTimer = 0f;
					Student.HelpOffered = true;
					Student.InEvent = true;
					Offering = true;
					if (EventStudentID == 11 && Student.Follower != null)
					{
						Student.Follower.IdleAnim = "f02_nervousLeftRight_00";
						SimpleLookStatus = Student.Follower.SimpleLook.enabled;
						Student.Follower.SimpleLook.enabled = false;
						Student.Follower.SpeechLines.Stop();
						OriginalPosition = StudentManager.Hangouts.List[10].position;
						OriginalRotation = StudentManager.Hangouts.List[10].eulerAngles;
						ScheduleBlock obj = Student.Follower.ScheduleBlocks[Student.Follower.Phase];
						obj.destination = "Hangout";
						obj.action = "Stand";
						Student.Follower.Actions[Student.Follower.Phase] = StudentActionType.Wait;
						Student.Follower.CurrentAction = StudentActionType.Wait;
						Student.Follower.GetDestinations();
						Student.Follower.CurrentDestination = BystanderSpot;
						Student.Follower.Pathfinding.target = BystanderSpot;
					}
					if (!GameGlobals.Eighties && EventStudentID == 11 && !Eavesdropped)
					{
						EventSpeech[3] = AltSpeech;
						EventClip[3] = AltClip;
					}
				}
				else if (!flag)
				{
					Yandere.NotificationManager.CustomText = "You lack a valid photo.";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			if (Offering)
			{
				Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, base.transform.rotation, Time.deltaTime * 10f);
				Yandere.MoveTowardsTarget(base.transform.position + Vector3.down);
				Quaternion b = Quaternion.LookRotation(Yandere.transform.position - Student.transform.position);
				Student.transform.rotation = Quaternion.Slerp(Student.transform.rotation, b, Time.deltaTime * 10f);
				Student.MoveTowardsTarget(Student.CurrentDestination.position);
				Animation characterAnimation = Yandere.CharacterAnimation;
				Animation characterAnimation2 = Student.CharacterAnimation;
				if (!Spoken)
				{
					if (EventSpeaker[EventPhase] == 1)
					{
						characterAnimation.CrossFade(EventAnim[EventPhase]);
						characterAnimation2.CrossFade(Student.IdleAnim, 1f);
					}
					else
					{
						if (!Student.Male)
						{
							characterAnimation2.CrossFade(EventAnim[EventPhase]);
						}
						else
						{
							characterAnimation2.CrossFade(Student.AnimationNames[0]);
						}
						characterAnimation.CrossFade(Yandere.IdleAnim, 1f);
					}
					EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
					EventSubtitle.text = EventSpeech[EventPhase];
					MyAudio.clip = EventClip[EventPhase];
					MyAudio.Play();
					Spoken = true;
				}
				else
				{
					if (!Yandere.PauseScreen.Show && Input.GetButtonDown(InputNames.Xbox_A))
					{
						Timer += EventClip[EventPhase].length + 1f;
					}
					if (EventSpeaker[EventPhase] == 1)
					{
						if (characterAnimation[EventAnim[EventPhase]].time >= characterAnimation[EventAnim[EventPhase]].length)
						{
							characterAnimation.CrossFade(Yandere.IdleAnim);
						}
					}
					else if (!Student.Male)
					{
						if (characterAnimation2[EventAnim[EventPhase]].time >= characterAnimation2[EventAnim[EventPhase]].length)
						{
							characterAnimation2.CrossFade(Student.IdleAnim);
						}
					}
					else if (characterAnimation2[Student.AnimationNames[0]].time >= characterAnimation2[Student.AnimationNames[0]].length)
					{
						characterAnimation2.CrossFade(Student.IdleAnim);
					}
					Timer += Time.deltaTime;
					if (Timer > EventClip[EventPhase].length)
					{
						EventSubtitle.text = string.Empty;
					}
					else
					{
						EventSubtitle.text = EventSpeech[EventPhase];
					}
					if (Timer > EventClip[EventPhase].length + 1f)
					{
						if (EventStudentID == 5 && EventPhase == 2)
						{
							Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
							StartCoroutine(Yandere.PauseScreen.PhotoGallery.GetPhotos());
							Yandere.PauseScreen.PhotoGallery.gameObject.SetActive(value: true);
							Yandere.PauseScreen.PhotoGallery.NamingBully = true;
							Yandere.PauseScreen.MainMenu.SetActive(value: false);
							Yandere.PauseScreen.Panel.enabled = true;
							Yandere.PauseScreen.Sideways = true;
							Yandere.PauseScreen.Show = true;
							Time.timeScale = 0.0001f;
							Yandere.PauseScreen.PhotoGallery.UpdateButtonPrompts();
							Student.HelpOffered = false;
							Offering = false;
						}
						else
						{
							Continue();
						}
					}
				}
				if (Yandere.Attacked)
				{
					EventPhase = EventSpeech.Length - 1;
					Continue();
				}
			}
			else
			{
				if (Eighties)
				{
					EventStudentID = StudentManager.RivalID;
				}
				if (StudentManager.Students[EventStudentID] != null && (StudentManager.Students[EventStudentID].Pushed || !StudentManager.Students[EventStudentID].Alive))
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}
		else
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				int num = StudentManager.DialogueWheel.Social.StudentFriendships[EventStudentID];
				float num2 = StudentManager.DialogueWheel.Social.StudentThresholds[EventStudentID] * 100f;
				Yandere.NotificationManager.CustomText = "Friendship: " + num + "/" + num2;
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			if (StudentManager.Students[EventStudentID] != null && (StudentManager.Students[EventStudentID].Pushed || !StudentManager.Students[EventStudentID].Alive))
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	public void UpdateLocation()
	{
		Debug.Log("An ''Offer Help'' prompt has been told to update its location.");
		if (Eighties)
		{
			EventStudentID = StudentManager.RivalID;
		}
		else if (EventStudentID != 5)
		{
			EventStudentID = StudentManager.RivalID;
		}
		Student = StudentManager.Students[EventStudentID];
		Debug.Log("This ''Offer Help'' prompt's EventStudentID is: " + EventStudentID);
		if (Student.CurrentDestination == StudentManager.MeetSpots.List[7])
		{
			base.transform.position = Locations[1].position;
			base.transform.eulerAngles = Locations[1].eulerAngles;
		}
		else if (Student.CurrentDestination == StudentManager.MeetSpots.List[8])
		{
			base.transform.position = Locations[2].position;
			base.transform.eulerAngles = Locations[2].eulerAngles;
		}
		else if (Student.CurrentDestination == StudentManager.MeetSpots.List[9])
		{
			base.transform.position = Locations[3].position;
			base.transform.eulerAngles = Locations[3].eulerAngles;
		}
		else if (Student.CurrentDestination == StudentManager.MeetSpots.List[10])
		{
			base.transform.position = Locations[4].position;
			base.transform.eulerAngles = Locations[4].eulerAngles;
		}
		if (EventStudentID == 5)
		{
			Prompt.MyCollider.enabled = true;
		}
		else if ((EventStudentID > 10 && EventStudentID < 21) || EventStudentID == 30)
		{
			if (!Student.Friend)
			{
				Prompt.Label[0].text = "     Must Befriend Student First";
				Unable = true;
			}
			else
			{
				Prompt.Label[0].text = "     Offer Help";
				Unable = false;
			}
			Prompt.MyCollider.enabled = true;
		}
	}

	public void Continue()
	{
		Debug.Log("Proceeding to next line.");
		Offering = true;
		Spoken = false;
		EventPhase++;
		Timer = 0f;
		if (EventStudentID == 30 && EventPhase == 14)
		{
			if (!ConversationGlobals.GetTopicDiscovered(23))
			{
				Yandere.NotificationManager.TopicName = "Family";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(23, value: true);
			}
			if (!StudentManager.GetTopicLearnedByStudent(23, EventStudentID))
			{
				Yandere.NotificationManager.TopicName = "Family";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				StudentManager.SetTopicLearnedByStudent(23, EventStudentID, boolean: true);
			}
		}
		if (EventPhase == EventSpeech.Length - 1)
		{
			if (EventStudentID == StudentManager.RivalID || (Eighties && EventStudentID > 10 && EventStudentID < 21))
			{
				StudentManager.RaibaruKnowsAboutStalker = true;
				SchemeGlobals.SetSchemeStage(6, 8);
				Yandere.PauseScreen.Schemes.UpdateInstructions();
			}
			else if (EventStudentID == 30)
			{
				SchemeGlobals.HelpingKokona = true;
				Debug.Log("SchemeGlobals.HelpingKokona is now true.");
			}
		}
		else if (EventPhase == EventSpeech.Length)
		{
			Debug.Log("The Offer Help prompt believes that it's time to fire StopMeeting().");
			Student.CurrentDestination = Student.Destinations[Student.Phase];
			Student.Pathfinding.target = Student.Destinations[Student.Phase];
			Student.StopMeeting();
			Student.InEvent = false;
			Student.Routine = true;
			Yandere.CanMove = true;
			Jukebox.Dip = 1f;
			if (EventStudentID == 11 && Student.Follower != null)
			{
				Student.Follower.IdleAnim = Student.Follower.OriginalIdleAnim;
				Student.Follower.SimpleLook.enabled = SimpleLookStatus;
				StudentManager.Hangouts.List[10].position = OriginalPosition;
				StudentManager.Hangouts.List[10].eulerAngles = OriginalRotation;
				ScheduleBlock obj = Student.Follower.ScheduleBlocks[Student.Follower.Phase];
				obj.destination = "Follow";
				obj.action = "Follow";
				Student.Follower.Actions[Student.Follower.Phase] = StudentActionType.Follow;
				Student.Follower.CurrentAction = StudentActionType.Follow;
				Student.Follower.GetDestinations();
				Student.Follower.CurrentDestination = Student.FollowTargetDestination;
				Student.Follower.Pathfinding.target = Student.FollowTargetDestination;
			}
			if (Student.Rival)
			{
				StudentManager.UpdateInfatuatedTargetDistances();
			}
			Prompt.Yandere.PauseScreen.StudentInfoMenu.Targeting = false;
			Object.Destroy(base.gameObject);
		}
	}
}
