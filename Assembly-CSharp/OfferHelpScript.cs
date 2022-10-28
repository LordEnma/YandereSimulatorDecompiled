// Decompiled with JetBrains decompiler
// Type: OfferHelpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class OfferHelpScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public JukeboxScript Jukebox;
  public StudentScript Student;
  public YandereScript Yandere;
  public PromptScript Prompt;
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
  public int EventStudentID;
  public int EventPhase = 1;
  public float Timer;
  public AudioClip ShortSilence;
  public AudioClip AltClip;
  public string AltSpeech;

  private void Start()
  {
    this.Prompt.enabled = true;
    if (!this.Eighties)
      return;
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
    }
    else
    {
      if (DateGlobals.Week != 10)
        return;
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

  private void Update()
  {
    if (!this.Unable)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        if (this.Eighties)
          this.EventStudentID = this.StudentManager.RivalID;
        bool flag = true;
        Debug.Log((object) "The player has activated an ''Offer Help'' prompt.");
        if (this.EventStudentID == 5)
        {
          Debug.Log((object) "Checking to see if we have a bully photo...");
          flag = false;
          for (int photoID = 1; photoID < 26; ++photoID)
          {
            Debug.Log((object) ("PlayerGlobals.GetBullyPhoto(ID) is: " + PlayerGlobals.GetBullyPhoto(photoID).ToString() + "!"));
            if (PlayerGlobals.GetBullyPhoto(photoID) > 0)
              flag = true;
          }
        }
        if (((this.Yandere.Chased ? 0 : (this.Yandere.Chasers == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
        {
          this.Jukebox.Dip = 0.1f;
          this.Yandere.EmptyHands();
          this.Yandere.CanMove = false;
          this.Student = this.StudentManager.Students[this.EventStudentID];
          this.Student.Prompt.Label[0].text = "     Talk";
          this.Student.Pushable = false;
          this.Student.Meeting = false;
          this.Student.Routine = false;
          this.Student.MeetTimer = 0.0f;
          this.Student.HelpOffered = true;
          this.Student.InEvent = true;
          this.Offering = true;
          if (this.EventStudentID == 11 && (Object) this.Student.Follower != (Object) null)
          {
            this.Student.Follower.IdleAnim = "f02_nervousLeftRight_00";
            this.SimpleLookStatus = this.Student.Follower.SimpleLook.enabled;
            this.Student.Follower.SimpleLook.enabled = false;
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
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.transform.rotation, Time.deltaTime * 10f);
        this.Yandere.MoveTowardsTarget(this.transform.position + Vector3.down);
        this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, Quaternion.LookRotation(this.Yandere.transform.position - this.Student.transform.position), Time.deltaTime * 10f);
        this.Student.MoveTowardsTarget(this.Student.CurrentDestination.position);
        Animation characterAnimation1 = this.Yandere.CharacterAnimation;
        Animation characterAnimation2 = this.Student.CharacterAnimation;
        if (!this.Spoken)
        {
          if (this.EventSpeaker[this.EventPhase] == 1)
          {
            characterAnimation1.CrossFade(this.EventAnim[this.EventPhase]);
            characterAnimation2.CrossFade(this.Student.IdleAnim, 1f);
          }
          else
          {
            characterAnimation2.CrossFade(this.EventAnim[this.EventPhase]);
            characterAnimation1.CrossFade(this.Yandere.IdleAnim, 1f);
          }
          this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
          this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
          AudioSource component = this.GetComponent<AudioSource>();
          component.clip = this.EventClip[this.EventPhase];
          component.Play();
          this.Spoken = true;
        }
        else
        {
          if (!this.Yandere.PauseScreen.Show && Input.GetButtonDown("A"))
            this.Timer += this.EventClip[this.EventPhase].length + 1f;
          if (this.EventSpeaker[this.EventPhase] == 1)
          {
            if ((double) characterAnimation1[this.EventAnim[this.EventPhase]].time >= (double) characterAnimation1[this.EventAnim[this.EventPhase]].length)
              characterAnimation1.CrossFade(this.Yandere.IdleAnim);
          }
          else if ((double) characterAnimation2[this.EventAnim[this.EventPhase]].time >= (double) characterAnimation2[this.EventAnim[this.EventPhase]].length)
            characterAnimation2.CrossFade(this.Student.IdleAnim);
          this.Timer += Time.deltaTime;
          this.EventSubtitle.text = (double) this.Timer <= (double) this.EventClip[this.EventPhase].length ? this.EventSpeech[this.EventPhase] : string.Empty;
          if ((double) this.Timer <= (double) this.EventClip[this.EventPhase].length + 1.0)
            return;
          if (this.EventStudentID == 5 && this.EventPhase == 2)
          {
            this.Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
            this.StartCoroutine(this.Yandere.PauseScreen.PhotoGallery.GetPhotos());
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
          }
          else
            this.Continue();
        }
      }
      else
      {
        if (this.Eighties)
          this.EventStudentID = this.StudentManager.RivalID;
        if (!((Object) this.StudentManager.Students[this.EventStudentID] != (Object) null) || !this.StudentManager.Students[this.EventStudentID].Pushed && this.StudentManager.Students[this.EventStudentID].Alive)
          return;
        this.gameObject.SetActive(false);
      }
    }
    else
      this.Prompt.Circle[0].fillAmount = 1f;
  }

  public void UpdateLocation()
  {
    if (this.Eighties)
      this.EventStudentID = this.StudentManager.RivalID;
    this.Student = this.StudentManager.Students[this.EventStudentID];
    Debug.Log((object) "An ''Offer Help'' prompt has been told to update its location.");
    if ((Object) this.Student.CurrentDestination == (Object) this.StudentManager.MeetSpots.List[7])
    {
      this.transform.position = this.Locations[1].position;
      this.transform.eulerAngles = this.Locations[1].eulerAngles;
    }
    else if ((Object) this.Student.CurrentDestination == (Object) this.StudentManager.MeetSpots.List[8])
    {
      this.transform.position = this.Locations[2].position;
      this.transform.eulerAngles = this.Locations[2].eulerAngles;
    }
    else if ((Object) this.Student.CurrentDestination == (Object) this.StudentManager.MeetSpots.List[9])
    {
      this.transform.position = this.Locations[3].position;
      this.transform.eulerAngles = this.Locations[3].eulerAngles;
    }
    else if ((Object) this.Student.CurrentDestination == (Object) this.StudentManager.MeetSpots.List[10])
    {
      this.transform.position = this.Locations[4].position;
      this.transform.eulerAngles = this.Locations[4].eulerAngles;
    }
    if (this.EventStudentID == 5)
    {
      this.Prompt.MyCollider.enabled = true;
    }
    else
    {
      if ((this.EventStudentID <= 10 || this.EventStudentID >= 21) && this.EventStudentID != 30)
        return;
      if (!this.Student.Friend)
      {
        this.Prompt.Label[0].text = "     Must Befriend Student First";
        this.Unable = true;
      }
      else
        this.Unable = false;
      this.Prompt.MyCollider.enabled = true;
    }
  }

  public void Continue()
  {
    Debug.Log((object) "Proceeding to next line.");
    this.Offering = true;
    this.Spoken = false;
    ++this.EventPhase;
    this.Timer = 0.0f;
    if (this.EventStudentID == 30 && this.EventPhase == 14)
    {
      if (!ConversationGlobals.GetTopicDiscovered(23))
      {
        this.Yandere.NotificationManager.TopicName = "Family";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        ConversationGlobals.SetTopicDiscovered(23, true);
      }
      if (!this.StudentManager.GetTopicLearnedByStudent(23, this.EventStudentID))
      {
        this.Yandere.NotificationManager.TopicName = "Family";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
        this.StudentManager.SetTopicLearnedByStudent(23, this.EventStudentID, true);
      }
    }
    if (this.EventPhase == this.EventSpeech.Length - 1)
    {
      if (this.EventStudentID == 11 || this.Eighties && this.EventStudentID > 10 && this.EventStudentID < 21)
      {
        this.StudentManager.RaibaruKnowsAboutStalker = true;
        SchemeGlobals.SetSchemeStage(6, 8);
        this.Yandere.PauseScreen.Schemes.UpdateInstructions();
      }
      else
      {
        if (this.EventStudentID != 30)
          return;
        SchemeGlobals.HelpingKokona = true;
        Debug.Log((object) "SchemeGlobals.HelpingKokona is now true.");
      }
    }
    else
    {
      if (this.EventPhase != this.EventSpeech.Length)
        return;
      Debug.Log((object) "The Offer Help prompt believes that it's time to fire StopMeeting().");
      this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
      this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
      this.Student.StopMeeting();
      this.Student.InEvent = false;
      this.Student.Routine = true;
      this.Yandere.CanMove = true;
      this.Jukebox.Dip = 1f;
      if (this.EventStudentID == 11 && (Object) this.Student.Follower != (Object) null)
      {
        this.Student.Follower.IdleAnim = this.Student.Follower.OriginalIdleAnim;
        this.Student.Follower.SimpleLook.enabled = this.SimpleLookStatus;
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
        this.StudentManager.UpdateInfatuatedTargetDistances();
      Object.Destroy((Object) this.gameObject);
    }
  }
}
