// Decompiled with JetBrains decompiler
// Type: GenericRivalEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class GenericRivalEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public JournalistScript Journalist;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public SpyScript Spy;
  public StudentScript[] Speaker;
  public StudentScript Senpai;
  public StudentScript Rival;
  public DayOfWeek EventDay;
  public Transform[] Location;
  public Transform Epicenter;
  public GameObject AlarmDisc;
  public string[] SabobtagedSpeechText;
  public float[] SabobtagedSpeechTime;
  public int[] SabotagedSpeakerID;
  public string[] SpeechText;
  public float[] SpeechTime;
  public int[] SpeakerID;
  public bool ForcedEnding;
  public bool NaturalEnd;
  public bool LunchTime;
  public bool Impatient;
  public bool Sabotaged;
  public bool Teleport;
  public bool Transfer;
  public bool End;
  public int SpeechPhase = 1;
  public int StartPeriod;
  public int EndPhase;
  public int Frame;
  public int Phase;
  public float TransferTime;
  public float StartTime;
  public float Distance;
  public float Scale;
  public float Timer;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    this.Spy.Prompt.enabled = true;
    this.EndPhase = this.SpeechTime.Length;
    if (DateGlobals.Weekday == DayOfWeek.Sunday)
      DateGlobals.Weekday = DayOfWeek.Monday;
    if (!GameGlobals.Eighties || DateGlobals.Weekday != this.EventDay || StudentGlobals.StudentSlave == this.StudentManager.RivalID || StudentGlobals.MemorialStudents > 0 || GameGlobals.RivalEliminationID > 0 || DatingGlobals.SuitorProgress == 2 || MissionModeGlobals.MissionMode || this.StudentManager.YandereLate || HomeGlobals.LateForSchool || GameGlobals.AlphabetMode)
    {
      this.Spy.Prompt.enabled = false;
      this.enabled = false;
    }
    else
    {
      if ((UnityEngine.Object) this.Journalist != (UnityEngine.Object) null)
        this.Journalist.RivalEvent = this;
      int week = DateGlobals.Week;
      if (DateGlobals.Week <= 1)
        return;
      if (this.EventDay == DayOfWeek.Monday)
      {
        switch (week)
        {
          case 2:
            this.SpeechText[1] = "Hey, Senpai! I want to ask you something!";
            this.SpeechText[2] = "Sure, what is it?";
            this.SpeechText[3] = "My scatterbrained sister accidentally made an extra bento this morning...";
            this.SpeechText[4] = "I didn't want it to go to waste, so I thought I might offer it to you.";
            this.SpeechText[5] = "Oh! That's thoughtful of you! I'd take it!";
            this.SpeechText[6] = "Great! Here it is! I hope you enjoy it!";
            this.SpeechText[7] = "Thanks! I'll keep it on my desk for now, and eat it at lunchtime.";
            this.SpeechText[8] = "Okay! At 5:15 PM, let's meet up back here, so you can tell me how it tasted!";
            this.SpeechText[9] = "Alright, sounds like a plan!";
            this.SpeechText[10] = "Great! I'm looking forward to it!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Sup, Senpai! So, how was that bento?";
            this.SpeechText[2] = "Oh, it was great!";
            this.SpeechText[3] = "Really? My cooking is actually...good?";
            this.SpeechText[4] = "Huh? I thought you said that your sister made it.";
            this.SpeechText[5] = "...huh? OH! Yeah! You're right! My sister!";
            this.SpeechText[6] = "Yes, that's correct, it was my sister's cooking, not mine...";
            this.SpeechText[7] = "...but, either way...I'm really glad that you enjoyed it!";
            this.SpeechText[8] = "...hey, uh...would you want to, uh...walk...home together?";
            this.SpeechText[9] = "Sure! I'd be happy to!";
            this.SpeechText[10] = "Awesome! Let's go!";
            this.SabobtagedSpeechText[1] = "Sup, Senpai! So, how was that bento?";
            this.SabobtagedSpeechText[2] = "...um...well...";
            this.SabobtagedSpeechText[3] = "...hmm? Something wrong?";
            this.SabobtagedSpeechText[4] = "Hey, that bento...was that a prank, or something?";
            this.SabobtagedSpeechText[5] = "Huh? why do you say that?";
            this.SabobtagedSpeechText[6] = "Well...it made me throw up. Like, immediately.";
            this.SabobtagedSpeechText[7] = "Whoa, WHAT?! No way...you're not serious, are you?!";
            this.SabobtagedSpeechText[8] = "...as long as you didn't do it on purpose, it's no big deal...";
            this.SabobtagedSpeechText[9] = "...well, I'm going to go home now...";
            this.SabobtagedSpeechText[10] = "Ah - wait - no - hold on - I'm sorry...ah...bye...";
            break;
          case 3:
            this.SpeechText[1] = "...h...hey...um...s...senpai...?...";
            this.SpeechText[2] = "Hmm? Yes?";
            this.SpeechText[3] = "...well...I...uh...I thought...um...maybe...b...bento...";
            this.SpeechText[4] = "...I...made a...bento this morning and...um...";
            this.SpeechText[5] = "...you made an extra one and want me to have it?";
            this.SpeechText[6] = "...um...well...that's not...I mean...yeah...do you...want it?";
            this.SpeechText[7] = "Sure! I'll keep it on my desk for now, and eat it at lunchtime.";
            this.SpeechText[8] = "...o-okay...um...I...want to know if you liked it...so...um...at 5:15 PM...";
            this.SpeechText[9] = "...You want to meet up back here so I can tell you how it tasted?";
            this.SpeechText[10] = "...y...yes! ...um...I...I'll be...going now...";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "...um...uh...Senpai...um...the bento...";
            this.SpeechText[2] = "Yeah, I ate it at lunchtime! It was great!";
            this.SpeechText[3] = "...r...really...?...it was...good...?...";
            this.SpeechText[4] = "Yeah! I loved it! It was delicious!";
            this.SpeechText[5] = "...d...delicious...?...you'd really...";
            this.SpeechText[6] = "...someone like me...my cooking...delicious...?...";
            this.SpeechText[7] = "...I'm...so happy...";
            this.SpeechText[8] = "...uh...um...would you, uh...want to...walk...walk...walk...";
            this.SpeechText[9] = "...walk home with you? Sure!";
            this.SpeechText[10] = "...oh...oh gosh...um...let's...let's go...";
            this.SabobtagedSpeechText[1] = "...um...uh...Senpai...um...the bento...";
            this.SabobtagedSpeechText[2] = "...um...well...";
            this.SabobtagedSpeechText[3] = "...what...what is it?";
            this.SabobtagedSpeechText[4] = "Hey, that bento...was that a prank, or something?";
            this.SabobtagedSpeechText[5] = "...p-prank?! I would never prank anyone...";
            this.SabobtagedSpeechText[6] = "Well...it made me throw up. Like, immediately.";
            this.SabobtagedSpeechText[7] = "...n...no...no...that can't be...no...";
            this.SabobtagedSpeechText[8] = "...as long as you didn't do it on purpose, it's no big deal...";
            this.SabobtagedSpeechText[9] = "...well, I'm going to go home now...";
            this.SabobtagedSpeechText[10] = "...s...senpai...I...oh, no...how could I...no...";
            break;
          case 4:
            this.SpeechText[1] = "Senpai! Good to see you!";
            this.SpeechText[2] = "Oh, hey! It's good to see you, too!";
            this.SpeechText[3] = "I'm still determined to convince you that healthy food can taste great!";
            this.SpeechText[4] = "Look, I prepared this meal for you. I promise it's delicious!";
            this.SpeechText[5] = "Oh! Well, um...";
            this.SpeechText[6] = "Hey, don't be that way! Take it! I swear, you're going to love it!";
            this.SpeechText[7] = "Okay! I'll keep it on my desk for now, and eat it at lunchtime.";
            this.SpeechText[8] = "Great! At 5:15 PM, let's meet up back here, so you can tell me how it tasted!";
            this.SpeechText[9] = "Alright, sounds like a plan!";
            this.SpeechText[10] = "Great! I'm looking forward to it!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Yo, Senpai! How was that bento?";
            this.SpeechText[2] = "Actually, it was way better than I expected!";
            this.SpeechText[3] = "Ha! Told ya that healthy food can still taste great!";
            this.SpeechText[4] = "Yeah! I actually wouldn't mind eating more meals like that!";
            this.SpeechText[5] = "Good! That's the way things should always be!";
            this.SpeechText[6] = "Mark my words! I'll get you to completely abandon junk food!";
            this.SpeechText[7] = "Just think of me as your personal nutritionist! Haha!";
            this.SpeechText[8] = "Man, I feel like going for a run! Jog home with me?";
            this.SpeechText[9] = "Sure! I'd be happy to!";
            this.SpeechText[10] = "That's what I like to hear! Let's go!";
            this.SabobtagedSpeechText[1] = "Yo, Senpai! How was that bento?";
            this.SabobtagedSpeechText[2] = "...um...well...";
            this.SabobtagedSpeechText[3] = "...hmm? What's the matter?";
            this.SabobtagedSpeechText[4] = "Hey, that bento...was that a prank, or something?";
            this.SabobtagedSpeechText[5] = "Huh? No, not in the slightest. Why?";
            this.SabobtagedSpeechText[6] = "Well...it made me throw up. Like, immediately.";
            this.SabobtagedSpeechText[7] = "Whoa, WHAT?! No way...you're not serious, are you?!";
            this.SabobtagedSpeechText[8] = "...as long as you didn't do it on purpose, it's no big deal...";
            this.SabobtagedSpeechText[9] = "...well, I'm going to go home now...";
            this.SabobtagedSpeechText[10] = "No way...must be...an allergy or something? Damn...";
            break;
          case 5:
            this.SpeechText[1] = "Senpai! There is a matter I must discuss with you!";
            this.SpeechText[2] = "Hmm? What's up?";
            this.SpeechText[3] = "My foolish chef made an extra meal this morning. What a blunder!";
            this.SpeechText[4] = "I brought it to school so that you may have it. Here, take it now.";
            this.SpeechText[5] = "Huh? Well, I already brought my own lunch, so -";
            this.SpeechText[6] = "Silence! This is world-class cuisine! You will take it! I insist!";
            this.SpeechText[7] = "Uh...okay then! I'll keep it on my desk for now, and eat it at lunchtime.";
            this.SpeechText[8] = "Ugh...fine. At 5:15 PM, meet me here, so you can praise the way it tasted.";
            this.SpeechText[9] = "Alright, sounds like a plan!";
            this.SpeechText[10] = "Would it kill you to sound a little more grateful? Hmph!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai! I anticipate that the bento was to your liking?";
            this.SpeechText[2] = "Yeah! It was great!";
            this.SpeechText[3] = "As expected. Now, you may begin saying words of praise.";
            this.SpeechText[4] = "Well, I guess my favorite part of the meal was -";
            this.SpeechText[5] = "No, you dolt! I'm not talking about the meal!";
            this.SpeechText[6] = "I'm waiting for you to start praising ME!";
            this.SpeechText[7] = "Honestly...you should be overflowing with gratitude right now!";
            this.SpeechText[8] = "Accompany me as I walk home, and praise my generosity along the way.";
            this.SpeechText[9] = "Uh...well, I mean...sure, I could...walk home with you...";
            this.SpeechText[10] = "Excellent. Then, let us be off! Posthaste!";
            this.SabobtagedSpeechText[1] = "Senpai! I anticipate that the bento was to your liking?";
            this.SabobtagedSpeechText[2] = "...um...well...";
            this.SabobtagedSpeechText[3] = "Hmm? Speak up! Express yourself clearly!";
            this.SabobtagedSpeechText[4] = "Hey, that bento...was that a prank, or something?";
            this.SabobtagedSpeechText[5] = "What? No! Childish pranks are far beneath me!";
            this.SabobtagedSpeechText[6] = "Well...it made me throw up. Like, immediately.";
            this.SabobtagedSpeechText[7] = "...WHAT? Ew! That's disgusting! Ew, ew, ew!";
            this.SabobtagedSpeechText[8] = "...as long as you didn't do it on purpose, it's no big deal...";
            this.SabobtagedSpeechText[9] = "...well, I'm going to go home now...";
            this.SabobtagedSpeechText[10] = "Perhaps...common folk simply have inferior stomachs...?...";
            break;
          case 6:
            this.SpeechText[1] = "Senpai! Hey, Senpai! I need your help!";
            this.SpeechText[2] = "Oh? What can I do for you?";
            this.SpeechText[3] = "I want to have firsthand experience in everything I sing about...";
            this.SpeechText[4] = "...and I want my next song to be about lovey-dovey stuff! Soooo...";
            this.SpeechText[5] = "...um...(gulp)...yes...?...";
            this.SpeechText[6] = "...so, I made this bento for you! Please take it, Senpai!";
            this.SpeechText[7] = "OH! I see. I'll keep it on my desk for now, and eat it at lunchtime.";
            this.SpeechText[8] = "At 5:15 PM, meet me here, so you can tell me how it tasted!";
            this.SpeechText[9] = "Alright, sounds like a plan!";
            this.SpeechText[10] = "Ohhhhh! This is such valuable experience to have for my lyrics!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai, Senpai!! Tell me how the bento tasted!!";
            this.SpeechText[2] = "Oh, it was great!";
            this.SpeechText[3] = "Really? Did you taste the love in it? Did you taste the love?!";
            this.SpeechText[4] = "Love? Well, I guess it tasted better than a normal bento...";
            this.SpeechText[5] = "Yes! That's exactly the kind of information I'm looking for!";
            this.SpeechText[6] = "What does a bento taste like when it's been prepared with love?";
            this.SpeechText[7] = "I need to know every detail! Every! Last! Detail!";
            this.SpeechText[8] = "I'm in a rush, though! Please tell me while we walk home, okay?";
            this.SpeechText[9] = "Um, sure, okay!";
            this.SpeechText[10] = "Okay! Let's go go go!";
            this.SabobtagedSpeechText[1] = "Senpai, Senpai!! Tell me how the bento tasted!!";
            this.SabobtagedSpeechText[2] = "...um...well...";
            this.SabobtagedSpeechText[3] = "...huh? What's wrong, what's wrong?";
            this.SabobtagedSpeechText[4] = "Hey, that bento...was that a prank, or something?";
            this.SabobtagedSpeechText[5] = "Huh?! No!! I wouldn't prank you, Senpai!!";
            this.SabobtagedSpeechText[6] = "Well...it made me throw up. Like, immediately.";
            this.SabobtagedSpeechText[7] = "...n...no way...you're kidding right?! Did you really?!";
            this.SabobtagedSpeechText[8] = "...as long as you didn't do it on purpose, it's no big deal...";
            this.SabobtagedSpeechText[9] = "...well, I'm going to go home now...";
            this.SabobtagedSpeechText[10] = "Oh my gosh...I'm sorry...I'm so so so sorry...I'm sorry...";
            break;
          case 7:
            this.SpeechText[1] = "Senpai...may I please have a moment of your time?";
            this.SpeechText[2] = "Sure, what's up?";
            this.SpeechText[3] = "It's embarrassing...but I accidentally made an extra bento this morning.";
            this.SpeechText[4] = "It pains me to see food go to waste...so, I'd like to offer it to you.";
            this.SpeechText[5] = "Oh, that'd be an honor! I'd love to have it?";
            this.SpeechText[6] = "Would you? That would make me so happy! Please take it, Senpai!";
            this.SpeechText[7] = "Okay! I'll keep it on my desk for now, and eat it at lunchtime.";
            this.SpeechText[8] = "Wonderful! At 5:15 PM, would you meet me here, so you can tell me how it tasted?";
            this.SpeechText[9] = "Yeah, I'd be glad to!";
            this.SpeechText[10] = "I'm so happy that everything worked out okay!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hello, Senpai! I'm anxious to hear how the bento tasted...";
            this.SpeechText[2] = "Oh, it was great!";
            this.SpeechText[3] = "Really? It was? Oh, I'm so happy to hear that!";
            this.SpeechText[4] = "Yeah! You're a great cook!";
            this.SpeechText[5] = "Oh...honestly, you're too kind! You'll make me blush!";
            this.SpeechText[6] = "It's a relief to know that I didn't mess it up somehow...";
            this.SpeechText[7] = "...maybe I'll make you another bento one day! Hehe!";
            this.SpeechText[8] = "...well...shall we...um...walk home together...?";
            this.SpeechText[9] = "Sure! I'd be happy to!";
            this.SpeechText[10] = "Oh, delightful! Let's go!";
            this.SabobtagedSpeechText[1] = "Hello, Senpai! I'm anxious to hear how the bento tasted...";
            this.SabobtagedSpeechText[2] = "...um...well...";
            this.SabobtagedSpeechText[3] = "...oh, dear. I anticipate a problem...";
            this.SabobtagedSpeechText[4] = "Hey, that bento...was that a prank, or something?";
            this.SabobtagedSpeechText[5] = "What? No! I swear, I'd never prank you!";
            this.SabobtagedSpeechText[6] = "Well...it made me throw up. Like, immediately.";
            this.SabobtagedSpeechText[7] = "...no. You're not serious. You don't mean that, do you?";
            this.SabobtagedSpeechText[8] = "...as long as you didn't do it on purpose, it's no big deal...";
            this.SabobtagedSpeechText[9] = "...well, I'm going to go home now...";
            this.SabobtagedSpeechText[10] = "Wait...that bento should have been fine...why...why did...";
            break;
          case 8:
            this.SpeechText[1] = "Senpai, may I please speak with you?";
            this.SpeechText[2] = "Yeah, anytime! What's up?";
            this.SpeechText[3] = "I was thinking of you this morning. I wanted to do something nice for you.";
            this.SpeechText[4] = "I have prepared a meal for you. Would you be willing to accept it?";
            this.SpeechText[5] = "Whoa, really? You made a meal, just for me?";
            this.SpeechText[6] = "Oh...I'm sorry...I shouldn't have made you a meal without your permission...";
            this.SpeechText[7] = "No, I'd love to have it! I'll put it on my desk, and eat it at lunchtime!";
            this.SpeechText[8] = "Splendid! At 5:15 PM, would you meet me here, so you can tell me how it tasted?";
            this.SpeechText[9] = "Yes, I'd love to!";
            this.SpeechText[10] = "Oh, I sincerely hope that you will enjoy it!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Greetings, Senpai. Please, tell me how the bento tasted.";
            this.SpeechText[2] = "Oh, it was great!";
            this.SpeechText[3] = "It was? Oh, I am ever so glad to hear that!";
            this.SpeechText[4] = "Yeah! You did a really good job with it!";
            this.SpeechText[5] = "Oh, Senpai...it truly makes my heart soar to hear such words...";
            this.SpeechText[6] = "I can't tell you how much of a relief it is that you enjoyed it...";
            this.SpeechText[7] = "Senpai...I always feel nervous and scared when walking alone...";
            this.SpeechText[8] = "Would you please...accompany me as I walk home today?";
            this.SpeechText[9] = "Sure! I'd be happy to!";
            this.SpeechText[10] = "Oh, thank you, Senpai! You're such a gentleman!";
            this.SabobtagedSpeechText[1] = "Greetings, Senpai. Please, tell me how the bento tasted.";
            this.SabobtagedSpeechText[2] = "...um...well...";
            this.SabobtagedSpeechText[3] = "...there wasn't...anything wrong with it...was there...?...";
            this.SabobtagedSpeechText[4] = "Hey, that bento...was that a prank, or something?";
            this.SabobtagedSpeechText[5] = "Oh...oh, no...don't tell me that there was a problem...";
            this.SabobtagedSpeechText[6] = "Well...it made me throw up. Like, immediately.";
            this.SabobtagedSpeechText[7] = "...! I...I'm speechless...did that...did that really happen?";
            this.SabobtagedSpeechText[8] = "...as long as you didn't do it on purpose, it's no big deal...";
            this.SabobtagedSpeechText[9] = "...well, I'm going to go home now...";
            this.SabobtagedSpeechText[10] = "Senpai...I can't apologize enough for this...forgive me...";
            break;
          case 9:
            this.SpeechText[1] = "Hehe...hey, Senpaaaaai~";
            this.SpeechText[2] = "O-oh! Um! Hi! Hello!";
            this.SpeechText[3] = "Hey~ How would you feeeeel~ If I told you...";
            this.SpeechText[4] = "...I made a bento for you this morning?";
            this.SpeechText[5] = "...r...really?! D-did you?! A bento?! All for me?!";
            this.SpeechText[6] = "Hehehe...yes~ Here it is~ Please, take it~";
            this.SpeechText[7] = "I'll cherish it forever! I mean, I'll put it on my desk, and eat it at lunchtime!";
            this.SpeechText[8] = "At 5:15 PM, would you meet me here, so you can tell me how it tasted?";
            this.SpeechText[9] = "Oh!! Yes!! Yes, I'd love to!!";
            this.SpeechText[10] = "Hehe...so cute~ Enjoy your meal, Senpaaaaai~";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hehe~ Hey, Senpai~ So~ How was that bento, hmmmmm~?";
            this.SpeechText[2] = "Oh, it was great!";
            this.SpeechText[3] = "Oh, yeahhhhh~? What was the best part~?";
            this.SpeechText[4] = "The fact that you made it, of course!";
            this.SpeechText[5] = "Hehe~ Good boy~ That's the right answer~";
            this.SpeechText[6] = "Oh, it's just so cute how excited you get around me~";
            this.SpeechText[7] = "Say, would you like to spend some time together~?";
            this.SpeechText[8] = "How about...walking home with me today? Hmmmmm~?";
            this.SpeechText[9] = "Oh!! Yes!! I'd love to!!";
            this.SpeechText[10] = "Hehe~ You cutie~ Let's go, then~";
            this.SabobtagedSpeechText[1] = "Hehe~ Hey, Senpai~ So~ How was that bento, hmmmmm~?";
            this.SabobtagedSpeechText[2] = "...um...well...";
            this.SabobtagedSpeechText[3] = "Hehe~ Left speechless, are you~?";
            this.SabobtagedSpeechText[4] = "Hey, that bento...was that a prank, or something?";
            this.SabobtagedSpeechText[5] = "...huh? What do you mean?";
            this.SabobtagedSpeechText[6] = "Well...it made me throw up. Like, immediately.";
            this.SabobtagedSpeechText[7] = "What the...what the hell?! Hey, are you serious?!";
            this.SabobtagedSpeechText[8] = "...as long as you didn't do it on purpose, it's no big deal...";
            this.SabobtagedSpeechText[9] = "...well, I'm going to go home now...";
            this.SabobtagedSpeechText[10] = "Whoa! Wait! Tell me exactly what happened! I'm confused!";
            break;
          case 10:
            this.SpeechText[1] = "Senpai. I need to speak to you.";
            this.SpeechText[2] = "...oh? What can I do for you?";
            this.SpeechText[3] = "Take this meal. Put it on your desk.";
            this.SpeechText[4] = "At lunchtime, eat it.";
            this.SpeechText[5] = "...uh...sure...but...why...?...";
            this.SpeechText[6] = "I'm testing a theory.";
            this.SpeechText[7] = "Uh...okay. I'll...do it, I guess.";
            this.SpeechText[8] = "Meet me here at 5:15 PM and tell me how the bento tasted.";
            this.SpeechText[9] = "...uh...sure...";
            this.SpeechText[10] = "Thank you for your cooperation.";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai. Please, tell me how the bento tasted.";
            this.SpeechText[2] = "Uh...it was good. Great, actually.";
            this.SpeechText[3] = "...hmm. So, she didn't tamper with it.";
            this.SpeechText[4] = "Huh? What?! What exactly did you try to feed me?!";
            this.SpeechText[5] = "I theorized that someone might try to sabotage my attempt to feed you.";
            this.SpeechText[6] = "However, the bento was left alone. This rules out one theory.";
            this.SpeechText[7] = "I am sure that you must have many questions for me. However...";
            this.SpeechText[8] = "...I cannot say anything that may interfere with the investigation.";
            this.SpeechText[9] = "...I...don't really...appreciate being left in the dark like this...";
            this.SpeechText[10] = "I apologize. To make up for it, I will guard you on your walk home.";
            this.SabobtagedSpeechText[1] = "Senpai. Please, tell me how the bento tasted.";
            this.SabobtagedSpeechText[2] = "...um...well...";
            this.SabobtagedSpeechText[3] = "Please, Senpai. I need to know";
            this.SabobtagedSpeechText[4] = "Hey, that bento...was that a prank, or something?";
            this.SabobtagedSpeechText[5] = "...just as I expected. How bad was it?";
            this.SabobtagedSpeechText[6] = "Well...it made me throw up. Like, immediately.";
            this.SabobtagedSpeechText[7] = "Damn it. I didn't think she'd go that far...";
            this.SabobtagedSpeechText[8] = "I don't know what this has to do with your investigation...";
            this.SabobtagedSpeechText[9] = "...but I do NOT appreciate being left in the dark like this.";
            this.SabobtagedSpeechText[10] = "I'm not at liberty to explain the details...I'm sorry...";
            break;
        }
      }
      else if (this.EventDay == DayOfWeek.Tuesday)
      {
        switch (week)
        {
          case 2:
            this.SpeechText[1] = "Hey, Senpai! Did you bring that book I asked for?";
            this.SpeechText[2] = "Yeah! I've got it right here!";
            this.SpeechText[3] = "Sweet! I've been looking forward to this!";
            this.SpeechText[4] = "Here, take it! Hope you enjoy it!";
            this.SpeechText[5] = "Awesome! I can't wait to check it out!";
            this.SpeechText[6] = "I'll keep it safe in my bookbag for now, and I'll read it at lunchtime.";
            this.SpeechText[7] = "Hey, when do you want it back?";
            this.SpeechText[8] = "Hmm...how about 5:15 PM? We can meet right here.";
            this.SpeechText[9] = "Cool, that works for me!";
            this.SpeechText[10] = "I'll look forward to hearing your thoughts on the book!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hi again! What did you think of the book?";
            this.SpeechText[2] = "I tried to enjoy it, but I think my attention span is just too short!";
            this.SpeechText[3] = "Oh...sorry to hear you didn't enjoy it!";
            this.SpeechText[4] = "I'm sure it's a good book, I just don't have the patience for it...";
            this.SpeechText[5] = "Yeah, I understand...it's not for everyone, I guess.";
            this.SpeechText[6] = "Phew, I'm glad my opinion didn't offend you, haha!";
            this.SpeechText[7] = "So, uh, hey, I couldn't help but notice something...";
            this.SpeechText[8] = "Your house and my house are in the same direction, so...";
            this.SpeechText[9] = "Let's walk home together!";
            this.SpeechText[10] = "Yeah! Sure! I'd love to!";
            this.SabobtagedSpeechText[1] = "...uh...Senpai...hey, uh...";
            this.SabobtagedSpeechText[2] = "...there's no easy way to say this, so I'm just gonna be direct...";
            this.SabobtagedSpeechText[3] = "I...I lost the book. I lost the book you lent me.";
            this.SabobtagedSpeechText[4] = "...so, it's just...gone now?";
            this.SabobtagedSpeechText[5] = "Don't worry! It's okay! I'll buy you a new one! I promise!";
            this.SabobtagedSpeechText[6] = "...you don't have to bother doing that.";
            this.SabobtagedSpeechText[7] = "It was special to me because it was a gift from my sister.";
            this.SabobtagedSpeechText[8] = "There's no point in replacing it. It wouldn't really be the same book.";
            this.SabobtagedSpeechText[9] = "...I'm just...going to go now...";
            this.SabobtagedSpeechText[10] = "Uh - uhhhhh - oh, shoot - shoot, I really messed up - uhhhhh...";
            break;
          case 3:
            this.SpeechText[1] = "...um...s...senpai...d...did you...";
            this.SpeechText[2] = "...bring the book you asked for? Yeah, I've got it right here!";
            this.SpeechText[3] = "...oh...I...um...thank you...";
            this.SpeechText[4] = "Here, take it! Hope you enjoy it!";
            this.SpeechText[5] = "...th...um, th-thank...thank you...";
            this.SpeechText[6] = "...um...I'll read it at...lunchtime...";
            this.SpeechText[7] = "...uh...when...should I...";
            this.SpeechText[8] = "...return it? How about 5:15 PM? We can meet right here.";
            this.SpeechText[9] = "...that...o-okay...";
            this.SpeechText[10] = "I'll look forward to hearing your thoughts on the book!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hi again! What did you think of the book?";
            this.SpeechText[2] = "Um...! Uh...! Really good...! Really, really good...!";
            this.SpeechText[3] = "I'm glad to hear that you like it!";
            this.SpeechText[4] = "...I'll return it, but...I'll definitely buy my own copy...";
            this.SpeechText[5] = "Once you finish it, let me know what you think of the ending!";
            this.SpeechText[6] = "...heh...hehe...yeah...I will...";
            this.SpeechText[7] = "...um...uh...well...I...um...uh...well...I...um...I...";
            this.SpeechText[8] = "...uh...w...w...walk...um...";
            this.SpeechText[9] = "...want to walk home together?";
            this.SpeechText[10] = "...y-yes...!";
            this.SabobtagedSpeechText[1] = "...s...senpai...I...";
            this.SabobtagedSpeechText[2] = "...I'm so...I'm so, so sorry...";
            this.SabobtagedSpeechText[3] = "...the book...I lost it...I'm so, so, so so so sorry...";
            this.SabobtagedSpeechText[4] = "...so, it's just...gone now?";
            this.SabobtagedSpeechText[5] = "...ahhhhh...I'll...I'll buy you a new one...!";
            this.SabobtagedSpeechText[6] = "...you don't have to bother doing that.";
            this.SabobtagedSpeechText[7] = "It was special to me because it was a gift from my sister.";
            this.SabobtagedSpeechText[8] = "There's no point in replacing it. It wouldn't really be the same book.";
            this.SabobtagedSpeechText[9] = "...I'm just...going to go now...";
            this.SabobtagedSpeechText[10] = "...n...no...oh, god....oh, god, no...no...";
            break;
          case 4:
            this.SpeechText[1] = "Hey, Senpai! Good to see you!";
            this.SpeechText[2] = "Good to see you, too! Hey, I've got that book you wanted!";
            this.SpeechText[3] = "Oh, great! It's been impossible for me to find this one!";
            this.SpeechText[4] = "Here, take it! Hope you enjoy it!";
            this.SpeechText[5] = "I'm really looking forward to reading this one!";
            this.SpeechText[6] = "I'll keep it safe in my bookbag for now, and I'll read it at lunchtime.";
            this.SpeechText[7] = "When should I return it to you?";
            this.SpeechText[8] = "Hmm...how about 5:15 PM? We can meet right here.";
            this.SpeechText[9] = "That's fine by me!";
            this.SpeechText[10] = "I'll look forward to hearing your thoughts on the book!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hi again! What did you think of the book?";
            this.SpeechText[2] = "It seemed pretty good, but I was too restless to really enjoy it.";
            this.SpeechText[3] = "Restless? Why?";
            this.SpeechText[4] = "I mean, it's a good book, but I just gotta stand up and move, you know?";
            this.SpeechText[5] = "Oh, I see. Yeah, not everyone likes to sit still for long periods.";
            this.SpeechText[6] = "Phew, I'm glad you understand. Didn't want you to think I was a weirdo...";
            this.SpeechText[7] = "Speaking of getting up and moving around, Senpai...";
            this.SpeechText[8] = "Jog with me! Right now! Let's go!";
            this.SpeechText[9] = "Oh! Uh...um, okay! I guess!";
            this.SpeechText[10] = "That's the spirit! Let's gooooo!";
            this.SabobtagedSpeechText[1] = "Hey, uh...Senpai...";
            this.SabobtagedSpeechText[2] = "Look...I'm sorry...I'm really, really sorry...";
            this.SabobtagedSpeechText[3] = "I...lost the book you lent me. I'm really sorry about this...";
            this.SabobtagedSpeechText[4] = "...so, it's just...gone now?";
            this.SabobtagedSpeechText[5] = "Yeah...it's gone. But...hey! I'll buy you a new one! Okay?";
            this.SabobtagedSpeechText[6] = "...you don't have to bother doing that.";
            this.SabobtagedSpeechText[7] = "It was special to me because it was a gift from my sister.";
            this.SabobtagedSpeechText[8] = "There's no point in replacing it. It wouldn't really be the same book.";
            this.SabobtagedSpeechText[9] = "...I'm just...going to go now...";
            this.SabobtagedSpeechText[10] = "Uh - oh, shoot. Ohhhhh, shoot. I...really screwed up this time...";
            break;
          case 5:
            this.SpeechText[1] = "Senpai! I trust that you have procured the book I requested?";
            this.SpeechText[2] = "Yeah! I've got it right here!";
            this.SpeechText[3] = "Excellent! It is good to know that you can be reliable. Sometimes.";
            this.SpeechText[4] = "Here, take it! Hope you enjoy it!";
            this.SpeechText[5] = "Most pleasing. I shall read it at lunchtime!";
            this.SpeechText[6] = "I understand that this is a temporary rental and not a gift.";
            this.SpeechText[7] = "I am unaccustomed to such things. When exactly should I return it?";
            this.SpeechText[8] = "Hmm...how about 5:15 PM? We can meet right here.";
            this.SpeechText[9] = "Understood. I will have to read it hastily, then...";
            this.SpeechText[10] = "I'll look forward to hearing your thoughts on the book!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hi again! What did you think of the book?";
            this.SpeechText[2] = "It was quite intriguing! I rather enjoyed reading it!";
            this.SpeechText[3] = "I'm glad to hear that you like it!";
            this.SpeechText[4] = "I will buy the nearest bookstore that carries it!";
            this.SpeechText[5] = "Uh...you mean, you'll buy the book from the nearest bookstore?";
            this.SpeechText[6] = "No. I mean I'll just buy the nearest bookstore.";
            this.SpeechText[7] = "Ugh, sometimes I forget how the less fortunate live their lives...";
            this.SpeechText[8] = "Enough of that subject. Senpai! Walk me home. Now.";
            this.SpeechText[9] = "Um...well, actually, I had plans to...";
            this.SpeechText[10] = "Silence! I'll have none of that. We shall depart now.";
            this.SabobtagedSpeechText[1] = "Senpai! I have good news!";
            this.SabobtagedSpeechText[2] = "That book you lent me? It's gone now! I lost it!";
            this.SabobtagedSpeechText[3] = "This means that I shall be buying you a new one! Rejoice!";
            this.SabobtagedSpeechText[4] = "...wait. You lost my book? It's just...gone now?";
            this.SabobtagedSpeechText[5] = "Did you not hear me? I said: I will buy you a new one!";
            this.SabobtagedSpeechText[6] = "...you don't have to bother doing that.";
            this.SabobtagedSpeechText[7] = "It was special to me because it was a gift from my sister.";
            this.SabobtagedSpeechText[8] = "There's no point in replacing it. It wouldn't really be the same book.";
            this.SabobtagedSpeechText[9] = "There are some things...money can't buy.";
            this.SabobtagedSpeechText[10] = "Huh...huh? Things that money...can't buy? But...but...Senpai! Wait!";
            break;
          case 6:
            this.SpeechText[1] = "Oh, oh! Senpai, hey Senpai! Didja bring that book?!";
            this.SpeechText[2] = "Yeah! I've got it right here!";
            this.SpeechText[3] = "Oh, yaaaaay! I'm so glad you brought it!";
            this.SpeechText[4] = "Here, take it! Hope you enjoy it!";
            this.SpeechText[5] = "Yippie! I'm really going to enjoy reading this!";
            this.SpeechText[6] = "I only want to read one chapter so I can decide if I want to buy it.";
            this.SpeechText[7] = "I'll read it at lunchtime. When should I return it to you?";
            this.SpeechText[8] = "Hmm...how about 5:15 PM? We can meet right here.";
            this.SpeechText[9] = "Okay, that works for me!";
            this.SpeechText[10] = "I'll look forward to hearing your thoughts on the book!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hi again! What did you think of the book?";
            this.SpeechText[2] = "Senpai! I love the book! It's sooooo goooood!";
            this.SpeechText[3] = "I'm glad to hear that you like it!";
            this.SpeechText[4] = "It gives me so much inspiration for new song ideas!";
            this.SpeechText[5] = "Once you finish it, let me know what you think of the ending!";
            this.SpeechText[6] = "Oh, for sure! Totally! I will!";
            this.SpeechText[7] = "Oh, um, hey! I was actually wondering, um...";
            this.SpeechText[8] = "Would you, ah...me willing to...walk home with me?";
            this.SpeechText[9] = "Of course! I'd love to!";
            this.SpeechText[10] = "Oh, yaaaaay! Let's get going!";
            this.SabobtagedSpeechText[1] = "Uuuuu...Senpai...Senpai...!";
            this.SabobtagedSpeechText[2] = "...I'm sorry! I'm sorry! Imsorryimsorryimsorry!";
            this.SabobtagedSpeechText[3] = "I...I lost the book! I'm sorry! I'M SO SORRY!";
            this.SabobtagedSpeechText[4] = "...so, it's just...gone now?";
            this.SabobtagedSpeechText[5] = "Oh!! But I'll buy you a new one!! I promise!! Okay?!";
            this.SabobtagedSpeechText[6] = "...you don't have to bother doing that.";
            this.SabobtagedSpeechText[7] = "It was special to me because it was a gift from my sister.";
            this.SabobtagedSpeechText[8] = "There's no point in replacing it. It wouldn't really be the same book.";
            this.SabobtagedSpeechText[9] = "...I'm just...going to go now...";
            this.SabobtagedSpeechText[10] = "Uh - oh - oh no! No no no! Wait! Senpai! Please! I'm sorry!";
            break;
          case 7:
            this.SpeechText[1] = "Hello, Senpai. How are you today?";
            this.SpeechText[2] = "Good! Hey, I brought that book you wanted.";
            this.SpeechText[3] = "That's wonderful! I was hoping that you'd bring it!";
            this.SpeechText[4] = "Here, take it! Hope you enjoy it!";
            this.SpeechText[5] = "I'm really looking forward to reading this!";
            this.SpeechText[6] = "I only want to read one chapter so I can decide if I want to buy it.";
            this.SpeechText[7] = "I'll read it at lunchtime. When should I return it to you?";
            this.SpeechText[8] = "Hmm...how about 5:15 PM? We can meet right here.";
            this.SpeechText[9] = "That fits into my schedule nicely!";
            this.SpeechText[10] = "I'll look forward to hearing your thoughts on the book!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hi again! What did you think of the book?";
            this.SpeechText[2] = "Oh, I loved it! It was wonderful from beginning to end!";
            this.SpeechText[3] = "I'm glad you liked...wait. Beginning to end?";
            this.SpeechText[4] = "Yes! I read the entire thing!";
            this.SpeechText[5] = "The...whole book. From start to finish. Everything?";
            this.SpeechText[6] = "Yes! It was so engrossing, I couldn't put it down.";
            this.SpeechText[7] = "I've been told that I read a bit faster than most people...";
            this.SpeechText[8] = "I'd love to discuss the ending with you! Shall we walk together?";
            this.SpeechText[9] = "Uh...oh! Yeah! Sure! Let's!";
            this.SpeechText[10] = "Excellent! Okay, so, in Chapter 5...";
            this.SabobtagedSpeechText[1] = "Senpai...I'm sorry, I have bad news.";
            this.SabobtagedSpeechText[2] = "I...lost the book that you lent me. I'm so sorry.";
            this.SabobtagedSpeechText[3] = "I searched for it everywhere, but...I just couldn't find it...";
            this.SabobtagedSpeechText[4] = "...so, it's just...gone now?";
            this.SabobtagedSpeechText[5] = "To make up for this, I'll buy you a replacement right away!";
            this.SabobtagedSpeechText[6] = "...you don't have to bother doing that.";
            this.SabobtagedSpeechText[7] = "It was special to me because it was a gift from my sister.";
            this.SabobtagedSpeechText[8] = "There's no point in replacing it. It wouldn't really be the same book.";
            this.SabobtagedSpeechText[9] = "...I'm just...going to go now...";
            this.SabobtagedSpeechText[10] = "...uh...oh...I've...I've really...blundered this time, haven't I...";
            break;
          case 8:
            this.SpeechText[1] = "Greetings, Senpai. I hope that you have been well since we last spoke.";
            this.SpeechText[2] = "Good! Hey, I brought that book you wanted.";
            this.SpeechText[3] = "Oh, how kind of you! I really appreciate that!";
            this.SpeechText[4] = "Here, take it! Hope you enjoy it!";
            this.SpeechText[5] = "I've been interested in this book for quite a long time now.";
            this.SpeechText[6] = "I only want to read one chapter so I can decide if I want to buy it.";
            this.SpeechText[7] = "I'll read it at lunchtime. When should I return it to you?";
            this.SpeechText[8] = "Hmm...how about 5:15 PM? We can meet right here.";
            this.SpeechText[9] = "I promise to be here at that time, then!";
            this.SpeechText[10] = "I'll look forward to hearing your thoughts on the book!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hi again! What did you think of the book?";
            this.SpeechText[2] = "Hello, Senpai! This book is quite marvelous so far!";
            this.SpeechText[3] = "I'm glad to hear that you like it!";
            this.SpeechText[4] = "I most certainly will be purchasing my own copy very soon!";
            this.SpeechText[5] = "Once you finish it, let me know what you think of the ending!";
            this.SpeechText[6] = "Oh, I shall! I can only wonder at what twists must await.";
            this.SpeechText[7] = "Senpai, as I said yesterday, I feel quite frightened when I walk alone...";
            this.SpeechText[8] = "Would you please accompany as I walk home?";
            this.SpeechText[9] = "Of course! I'd love to!";
            this.SpeechText[10] = "Oh, ever the gentleman! Well, then. Let us depart!";
            this.SabobtagedSpeechText[1] = "Senpai...I must beg for your forgiveness...";
            this.SabobtagedSpeechText[2] = "I lost the book that you lent me. There is no excuse for this.";
            this.SabobtagedSpeechText[3] = "I am never careless with the belongings of others...but, today...";
            this.SabobtagedSpeechText[4] = "...so, it's just...gone now?";
            this.SabobtagedSpeechText[5] = "Senpai, allow me to buy you a new one. It is the least I can do.";
            this.SabobtagedSpeechText[6] = "...you don't have to bother doing that.";
            this.SabobtagedSpeechText[7] = "It was special to me because it was a gift from my sister.";
            this.SabobtagedSpeechText[8] = "There's no point in replacing it. It wouldn't really be the same book.";
            this.SabobtagedSpeechText[9] = "...I'm just...going to go now...";
            this.SabobtagedSpeechText[10] = "...I...no...no, I haven't really let this happen...have I...?...";
            break;
          case 9:
            this.SpeechText[1] = "Hehe...hey, Senpai~";
            this.SpeechText[2] = "Oh, um, hi!! Hey, I, uh, brought that book you wanted!!";
            this.SpeechText[3] = "Hehe~ You remembered~ That makes me happy~";
            this.SpeechText[4] = "Here, take it! Hope you enjoy it!";
            this.SpeechText[5] = "Hehe~ I sure will~";
            this.SpeechText[6] = "I only want to read one chapter so I can decide if I want to buy it.";
            this.SpeechText[7] = "I'll read it at lunchtime. When should I return it to you?";
            this.SpeechText[8] = "Hmm...how about 5:15 PM? We can meet right here.";
            this.SpeechText[9] = "Okay then~ It's a daaaaate~";
            this.SpeechText[10] = "A d...d...d-d-d-d-d-date...?...";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Oh! Um! Hi! So, uh...what did you think of the book?";
            this.SpeechText[2] = "Hehe~ Hey, Senpai~ This book's great so far~";
            this.SpeechText[3] = "Oh,I'm glad to hear that you like it!";
            this.SpeechText[4] = "Mm-hmm~ I'm already planning to buy a copy for myself~";
            this.SpeechText[5] = "Um, I'd be willing to buy one for you...";
            this.SpeechText[6] = "Hehe~ Ohhhhh~ Such a gentleman~ Teehee~";
            this.SpeechText[7] = "Shall we walk to the nearest bookstore, then?";
            this.SpeechText[8] = "And then, perhaps you can walk me home~";
            this.SpeechText[9] = "Oh!! Of course!! I'd love to!!";
            this.SpeechText[10] = "Hehe~ Oh my~ So eager~ Hehehe~ Let's go, then~";
            this.SabobtagedSpeechText[1] = "Uhhhhh...hey, look, Senpai...";
            this.SabobtagedSpeechText[2] = "Shoot...man, I feel bad about this...ah, this is hard...";
            this.SabobtagedSpeechText[3] = "Look, I...I lost the book. I lost the book you lent me...";
            this.SabobtagedSpeechText[4] = "...so, it's just...gone now?";
            this.SabobtagedSpeechText[5] = "Hey - I'm really sorry about this. I'll buy you a new one, okay?";
            this.SabobtagedSpeechText[6] = "...you don't have to bother doing that.";
            this.SabobtagedSpeechText[7] = "It was special to me because it was a gift from my sister.";
            this.SabobtagedSpeechText[8] = "There's no point in replacing it. It wouldn't really be the same book.";
            this.SabobtagedSpeechText[9] = "...I'm just...going to go now...";
            this.SabobtagedSpeechText[10] = "I...oh, shoot. Ohhhhh, shoot. This is...this is bad, huh...";
            break;
          case 10:
            this.SpeechText[1] = "Senpai. Did you bring it?";
            this.SpeechText[2] = "...the book? Yeah...";
            this.SpeechText[3] = "Excellent. Hand it over.";
            this.SpeechText[4] = "Uh, yeah...here it is.";
            this.SpeechText[5] = "I must apologize in advance if anything happens to this book.";
            this.SpeechText[6] = "If all goes well, the book will be returned to you unscathed.";
            this.SpeechText[7] = "But, if not...at least a theory of mine will be proven.";
            this.SpeechText[8] = "Uh...okay...but, could you return it to me around 5:15 PM?";
            this.SpeechText[9] = "That would be acceptable.";
            this.SpeechText[10] = "Uh...alright...";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Uh...hey. So, uh...about the book...";
            this.SpeechText[2] = "Here it is, in perfect condition.";
            this.SpeechText[3] = "Phew. You made me worry that something was going to happen to it.";
            this.SpeechText[4] = "I, too, had my suspicions that something bad would happen.";
            this.SpeechText[5] = "I'm still not certain what you hoped to achieve...";
            this.SpeechText[6] = "I suspected that, if I borrowed something of value from you...";
            this.SpeechText[7] = "...a mysterious aggressor would appear and steal the object.";
            this.SpeechText[8] = "I cannot tell you more than that without jeopardizing the investigation.";
            this.SpeechText[9] = "So, you're just...using my belongings as bait? Um...that's...kinda...";
            this.SpeechText[10] = "I swear to you that one day, I will explain everything. Just not today.";
            this.SabobtagedSpeechText[1] = "Senpai! Great news! My suspicions were correct!";
            this.SabobtagedSpeechText[2] = "As expected, the book was stolen! The book you lent me!";
            this.SabobtagedSpeechText[3] = "This proves my theory! I was right all along!";
            this.SabobtagedSpeechText[4] = "Wait a minute. My book is gone? It was stolen?";
            this.SabobtagedSpeechText[5] = "Ultimately, a trivial matter. I can just buy you a new one.";
            this.SabobtagedSpeechText[6] = "...you don't have to bother doing that.";
            this.SabobtagedSpeechText[7] = "It was special to me because it was a gift from my sister.";
            this.SabobtagedSpeechText[8] = "There's no point in replacing it. It wouldn't really be the same book.";
            this.SabobtagedSpeechText[9] = "...I don't appreciate you using my belongings as bait. I'm leaving.";
            this.SabobtagedSpeechText[10] = "Uh - wait - if I had known - I never would have...ohhhhh...";
            break;
        }
      }
      else if (this.EventDay == DayOfWeek.Wednesday)
      {
        switch (week)
        {
          case 2:
            this.SpeechText[1] = "Yo! Senpai! Will you be free around lunchtime?";
            this.SpeechText[2] = "Hmm? Why do you ask?";
            this.SpeechText[3] = "I brought something to school that I want to share with you!";
            this.SpeechText[4] = "But...it's a surprise! I won't tell you what it is yet!";
            this.SpeechText[5] = "Oh? Sounds fun! Sure, I'll be free at lunchtime.";
            this.SpeechText[6] = "Awesome! Meet me on the school rooftop for lunch, then.";
            this.SpeechText[7] = "Man, what could it be? Now you've got me all curious...";
            this.SpeechText[8] = "Hehe...I'm glad I've got your interest!";
            this.SpeechText[9] = "Hey, I gotta go - see you at lunchtime, Senpai!";
            this.SpeechText[10] = "Okay! See you later, then!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hey, Senpai! I've got your present right here! Open it up!";
            this.SpeechText[2] = "Okay...here goes! I'm opening the box now, aaaaand...";
            this.SpeechText[3] = "...oh! This is a book by my favorite author? But, what's this...";
            this.SpeechText[4] = "...oh?! This is his autograph! Oh my gosh! How did you get this?!";
            this.SpeechText[5] = "I remember that you mentioned that you were a fan of this author...";
            this.SpeechText[6] = "...and he held a book signing in Tokyo yesterday, so I got this for you!";
            this.SpeechText[7] = "Aww, that's so sweet of you, thanks!";
            this.SpeechText[8] = "(Senpai admires the autograph for a moment.)";
            this.SpeechText[9] = "...wait. Does this mean you went to Tokyo just for me?";
            this.SpeechText[10] = "Huh? Um...no! I was...in Tokyo...for my own reasons! Haha...";
            this.SabobtagedSpeechText[1] = "Hey, Senpai! I've got your present right here! Open it up!";
            this.SabobtagedSpeechText[2] = "Okay...here goes! I'm opening the box now, aaaaand...";
            this.SabobtagedSpeechText[3] = "...oh...wow...I...definitely didn't expect to see something like this...";
            this.SabobtagedSpeechText[4] = "...huh? What's the matter, Senpai?";
            this.SabobtagedSpeechText[5] = "Um...I have to be honest with you...I'm not really interested in this sort of thing...";
            this.SabobtagedSpeechText[6] = "...wait, what? But...";
            this.SabobtagedSpeechText[7] = "Please don't try to share this type of stuff with me again, okay?";
            this.SabobtagedSpeechText[8] = "...whoa...yikes...geez...no reason to be mean about it...";
            this.SabobtagedSpeechText[9] = "...yeah, well...anyway...enjoy your lunch, I guess...";
            this.SabobtagedSpeechText[10] = "...um?? Okay?? Whatever...";
            break;
          case 3:
            this.SpeechText[1] = "...um...s...senpai...um...";
            this.SpeechText[2] = "Hmm? What's up?";
            this.SpeechText[3] = "...I, uh...I, um...b...brought something...for you...";
            this.SpeechText[4] = "...um...will you be...free at...lunchtime...?...";
            this.SpeechText[5] = "...you want to show me something at lunchtime? Sure, I guess.";
            this.SpeechText[6] = "...o...oh...!...o-okay, then...um...at lunchtime...";
            this.SpeechText[7] = "You alright? You seem kinda nervous...";
            this.SpeechText[8] = "...I...I'm fine...";
            this.SpeechText[9] = "...I'll...just...uh...be going...now...";
            this.SpeechText[10] = "Well, uh, okay! See you at lunch, then!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "...um...so...it's...uh...I...um...here.";
            this.SpeechText[2] = "...a box? You want me to open it? Okay! I'm opening the box now, aaaaand...";
            this.SpeechText[3] = "...whoooooa, what's this? Is this a book on...the occult?";
            this.SpeechText[4] = "Whoa, there are all kinds of crazy illustrations in here...";
            this.SpeechText[5] = "...you mentioned...you thought...it was an...interesting subject...";
            this.SpeechText[6] = "...so I just...thought I'd...let you have this book...";
            this.SpeechText[7] = "Aww, that's so sweet of you, thanks!";
            this.SpeechText[8] = "(Senpai thumbs through the book for a moment.)";
            this.SpeechText[9] = "Hey, thanks, this was really nice of you. I appreciate it a lot!";
            this.SpeechText[10] = "...oh...ohh!!...I...um...it was...nothing...hehe...";
            this.SabobtagedSpeechText[1] = "...um...so...it's...uh...I...um...here.";
            this.SabobtagedSpeechText[2] = "...a box? You want me to open it? Okay! I'm opening the box now, aaaaand...";
            this.SabobtagedSpeechText[3] = "...oh...wow...I...definitely didn't expect to see something like this...";
            this.SabobtagedSpeechText[4] = "...huh...?...";
            this.SabobtagedSpeechText[5] = "Um...I have to be honest with you...I'm not really interested in this sort of thing...";
            this.SabobtagedSpeechText[6] = "...o-oh...I was...worried...you'd think it was creepy...";
            this.SabobtagedSpeechText[7] = "Please don't try to share this type of stuff with me again, okay?";
            this.SabobtagedSpeechText[8] = "...imsorryimsorryimsorry...";
            this.SabobtagedSpeechText[9] = "...yeah, well...anyway...enjoy your lunch, I guess...";
            this.SabobtagedSpeechText[10] = "...imsorryimsorryimsorryimsorryimsorry...";
            break;
          case 4:
            this.SpeechText[1] = "Hey there! Senpai! Got a sec?";
            this.SpeechText[2] = "Hmm? Yeah, what's up?";
            this.SpeechText[3] = "I brought something to school for you, but I'm a bit busy right now...";
            this.SpeechText[4] = "I'll be free around lunchtime. Can I show you then?";
            this.SpeechText[5] = "Oh? Sounds fun! Sure, I'll be free at lunchtime.";
            this.SpeechText[6] = "Cool! Let's meet up on the school rooftop for lunch, then.";
            this.SpeechText[7] = "Man, what could it be? Now you've got me all curious...";
            this.SpeechText[8] = "Heh heh...I guarantee you won't be able to guess what it is!";
            this.SpeechText[9] = "Well, I gotta go do my daily routine - see you at lunchtime, Senpai!";
            this.SpeechText[10] = "Okay! See you later, then!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hey! Senpai! Check this out! Open it, open it!";
            this.SpeechText[2] = "Okay...here goes! I'm opening the box now, aaaaand...";
            this.SpeechText[3] = "...oh! This is a book about...eating...healthy?";
            this.SpeechText[4] = "...heh...heh heh...just what I...always wanted...";
            this.SpeechText[5] = "C'mon, Senpai! You're getting tubby! You need to slim down!";
            this.SpeechText[6] = "I just want you to be the best you that you can be!";
            this.SpeechText[7] = "Well...I suppose I should be thankful that you care so much.";
            this.SpeechText[8] = "(Senpai thumbs through the book for a few moments.)";
            this.SpeechText[9] = "Well, alright...I'll look through it and see if I can learn something.";
            this.SpeechText[10] = "That's the right attitude, Senpai! Never stop striving to be better!";
            this.SabobtagedSpeechText[1] = "Hey! Senpai! Check this out! Open it, open it!";
            this.SabobtagedSpeechText[2] = "Okay...here goes! I'm opening the box now, aaaaand...";
            this.SabobtagedSpeechText[3] = "...oh...wow...I...definitely didn't expect to see something like this...";
            this.SabobtagedSpeechText[4] = "...huh? What do you mean? You had to see this coming!";
            this.SabobtagedSpeechText[5] = "Um...I have to be honest with you...I'm not really interested in this sort of thing...";
            this.SabobtagedSpeechText[6] = "...hey, come on, I'm only trying to help you!";
            this.SabobtagedSpeechText[7] = "Please don't try to share this type of stuff with me again, okay?";
            this.SabobtagedSpeechText[8] = "...yeeeeesh. You could afford to chill out a bit.";
            this.SabobtagedSpeechText[9] = "...yeah, well...anyway...enjoy your lunch, I guess...";
            this.SabobtagedSpeechText[10] = "...alright, alright, I can take a hint...";
            break;
          case 5:
            this.SpeechText[1] = "Senpai! I require your attention immediately!";
            this.SpeechText[2] = "Huh? What's so urgent?";
            this.SpeechText[3] = "I have brought something to school that I wish to show you...";
            this.SpeechText[4] = "...however, there are too many eyes here. I would prefer to show you in private.";
            this.SpeechText[5] = "Huh? Sounds...kinda...sketchy...";
            this.SpeechText[6] = "There is nothing sketchy about it! Now, listen closely to my instructions.";
            this.SpeechText[7] = "Umm...well, okay...I'm listening...I guess...";
            this.SpeechText[8] = "You will meet me on the school rooftop at lunchtime. Do not be late.";
            this.SpeechText[9] = "Surely, you can keep a simple appointment, yes?";
            this.SpeechText[10] = "Well, I...uh...sure, alright...";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai! Open this box! Open it now. I want to see your reaction!";
            this.SpeechText[2] = "Okay...here goes! I'm opening the box now, aaaaand...";
            this.SpeechText[3] = "...money? ...oh my god. There's...so much money in here.";
            this.SpeechText[4] = "This has got to be at least...ten million yen. What's all this money for?";
            this.SpeechText[5] = "Haha! Oh, the look on your face! It's absolutely priceless!";
            this.SpeechText[6] = "Honestly, I just wanted to see how you would react to seeing all that cash!";
            this.SpeechText[7] = "...seriously? Man, that's a weird reason to carry millions around...";
            this.SpeechText[8] = "(Senpai stares at the money for a moment.)";
            this.SpeechText[9] = "...wait. Is this...a gift? Are you giving this to me?!";
            this.SpeechText[10] = "What?! No! Of course not! Give it back! You've stared at it long enough!";
            this.SabobtagedSpeechText[1] = "Senpai! Open this box! Open it now. I want to see your reaction!";
            this.SabobtagedSpeechText[2] = "Okay...here goes! I'm opening the box now, aaaaand...";
            this.SabobtagedSpeechText[3] = "...oh...wow...I...definitely didn't expect to see something like this...";
            this.SabobtagedSpeechText[4] = "...hmm? Drat! I was hoping for a stronger reaction.";
            this.SabobtagedSpeechText[5] = "Um...I have to be honest with you...I'm not really interested in this sort of thing...";
            this.SabobtagedSpeechText[6] = "...not...interested?! But...how can that possibly be?!";
            this.SabobtagedSpeechText[7] = "Please don't try to share this type of stuff with me again, okay?";
            this.SabobtagedSpeechText[8] = "...wh...what?! But...but, this stuff is what makes the world go around!";
            this.SabobtagedSpeechText[9] = "...yeah, well...anyway...enjoy your lunch, I guess...";
            this.SabobtagedSpeechText[10] = "...well, I...hmph! HMPH, I say!";
            break;
          case 6:
            this.SpeechText[1] = "Senpai! Heyyyyy, Senpaiiiii~!";
            this.SpeechText[2] = "Oh! Hi there! Good morning!";
            this.SpeechText[3] = "Hey Senpai hey Senpai hey Senpai! I have a present for you!";
            this.SpeechText[4] = "But...it's a secret! An absolute secret! A super secret!";
            this.SpeechText[5] = "Oh? Um...okay...so...what does that mean, exactly?";
            this.SpeechText[6] = "It means I want to show you in private! On the rooftop! At lunchtime!";
            this.SpeechText[7] = "Oh! Okay. Sure, I could do lunch on the roof today.";
            this.SpeechText[8] = "Yaaaaay! Hehe! I'm looking forward to showing you, then!";
            this.SpeechText[9] = "I gotta go now, but I'll see you at lunch, Senpaaaaai!";
            this.SpeechText[10] = "Heh, okay! See you later, then!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai Senpai Senpai! Take this! Open it open it open it!";
            this.SpeechText[2] = "Whoa, okay! I'm opening the box now, aaaaand...";
            this.SpeechText[3] = "...hmm? What is this? A tape player and a cassette tape?";
            this.SpeechText[4] = "It's not a gift, right? I mean, I already own one...";
            this.SpeechText[5] = "No, silly! That's my new song! I want you to be the first to hear it!";
            this.SpeechText[6] = "I wrote all the lyrics myself! Please, tell me what you think of it!";
            this.SpeechText[7] = "Oh! Okay! I'll listen right now!";
            this.SpeechText[8] = "(Senpai listens to the cassette tape.)";
            this.SpeechText[9] = "...wow! This is actually REALLY good! You're definitely going to be a star!";
            this.SpeechText[10] = "...really?! Yay!! It means so much to hear that from you, Senpai!!";
            this.SabobtagedSpeechText[1] = "Senpai Senpai Senpai! Take this! Open it open it open it!";
            this.SabobtagedSpeechText[2] = "Whoa, okay! I'm opening the box now, aaaaand...";
            this.SabobtagedSpeechText[3] = "...oh...wow...I...definitely didn't expect to see something like this...";
            this.SabobtagedSpeechText[4] = "...huh? Um...what's the issue, Senpai...?";
            this.SabobtagedSpeechText[5] = "Um...I have to be honest with you...I'm not really interested in this sort of thing...";
            this.SabobtagedSpeechText[6] = "...wh...whoa! Hey, I was just trying to share something nice with you...";
            this.SabobtagedSpeechText[7] = "Please don't try to share this type of stuff with me again, okay?";
            this.SabobtagedSpeechText[8] = "...oh...so...that's how you feel about my passion, huh...?";
            this.SabobtagedSpeechText[9] = "...yeah, well...anyway...enjoy your lunch, I guess...";
            this.SabobtagedSpeechText[10] = "...yeah...you...you enjoy your lunch, too...hmph...";
            break;
          case 7:
            this.SpeechText[1] = "Hello, Senpai! I have a question for you?";
            this.SpeechText[2] = "Oh? Hi! What do you want to ask?";
            this.SpeechText[3] = "I'd like to know if you'll be free around lunchtime!";
            this.SpeechText[4] = "You see, there's something I'd like to give you...";
            this.SpeechText[5] = "Oh? Sounds fun! Sure, I'll be free at lunchtime.";
            this.SpeechText[6] = "Oh...good! Please meet me on the school rooftop for lunch, then.";
            this.SpeechText[7] = "Man, what could it be? Now you've got me all curious...";
            this.SpeechText[8] = "Heh...I'm not trying to tease you, if that's what you think...";
            this.SpeechText[9] = "Oh, I'm sorry, I have to go now - I'll see you at lunchtime!";
            this.SpeechText[10] = "Okay! See you later, then!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai! I'm glad you're here. Please...take this box, and open it.";
            this.SpeechText[2] = "Okay...here goes! I'm opening the box now, aaaaand...";
            this.SpeechText[3] = "...Hmm? A book? Hey...I think I recognize this author.";
            this.SpeechText[4] = "This book is by that mysterious author whose true identity is unknown, right?";
            this.SpeechText[5] = "Senpai...you're very important to me. I don't want to keep secrets from you.";
            this.SpeechText[6] = "So...I'm going to confess the truth to you.";
            this.SpeechText[7] = "...huh? The truth? ...wait. Hold on...are you saying that you're actually...?!";
            this.SpeechText[8] = "(Senpai looks back and forth between the book and the girl.)";
            this.SpeechText[9] = "...wow! It's an honor to be trusted with this secret. I won't tell a soul!";
            this.SpeechText[10] = "Thank you, Senpai. I just couldn't bear the thought of hiding anything from you.";
            this.SabobtagedSpeechText[1] = "Senpai! I'm glad you're here. Please...take this box, and open it.";
            this.SabobtagedSpeechText[2] = "Okay...here goes! I'm opening the box now, aaaaand...";
            this.SabobtagedSpeechText[3] = "...oh...wow...I...definitely didn't expect to see something like this...";
            this.SabobtagedSpeechText[4] = "...huh? What's so surprising?";
            this.SabobtagedSpeechText[5] = "Um...I have to be honest with you...I'm not really interested in this sort of thing...";
            this.SabobtagedSpeechText[6] = "...I...uh...oh...so, not a fan, then...?";
            this.SabobtagedSpeechText[7] = "Please don't try to share this type of stuff with me again, okay?";
            this.SabobtagedSpeechText[8] = "...oh...wow...you really...dislike it, then, huh...";
            this.SabobtagedSpeechText[9] = "...yeah, well...anyway...enjoy your lunch, I guess...";
            this.SabobtagedSpeechText[10] = "...I...I was just trying to...yeah...okay...";
            break;
          case 8:
            this.SpeechText[1] = "Good morning. Senpai. May I please ask you a question?";
            this.SpeechText[2] = "Haha, you don't have to be so formal! But, sure, what's up?";
            this.SpeechText[3] = "I have brought a gift that I would like to give to you. But...";
            this.SpeechText[4] = "...it would be so embarrassing to give it to you here...";
            this.SpeechText[5] = "Oh? Um, how about on the rooftop at lunchtime, then?";
            this.SpeechText[6] = "Oh! That's such a clever idea! Good thinking, Senpai!";
            this.SpeechText[7] = "Man, what could it be? Now you've got me all curious...";
            this.SpeechText[8] = "Oh, I promise you, it is nothing too special...just a small gift.";
            this.SpeechText[9] = "I will look forward to our meeting at lunchtime then, Senpai!";
            this.SpeechText[10] = "Okay! See you later, then!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai! Thank you so much for coming. Please...accept this gift.";
            this.SpeechText[2] = "Okay! I accept! I'm opening the box now, aaaaand...";
            this.SpeechText[3] = "...a flower? Huh, that's interesting. It's, uh...a pretty flower!";
            this.SpeechText[4] = "Huh! Nobody has ever given me a flower before. It's, uah...it's nice!";
            this.SpeechText[5] = "Senpai...do you recognize this flower? This is a red camellia.";
            this.SpeechText[6] = "Do you...understand the meaning...of a red camellia?";
            this.SpeechText[7] = "...huh? Oh, yeah, that's right, flowers have meanings and stuff, right?";
            this.SpeechText[8] = "(Senpai stares at the flower for a little while.)";
            this.SpeechText[9] = "...ummmmm, nope! I don't actually know what this one means! I'm sorry!";
            this.SpeechText[10] = "...oh...I see...I suppose my message was...unclear...sorry to trouble you.";
            this.SabobtagedSpeechText[1] = "Senpai! I'm glad you're here. Please...take this box, and open it.";
            this.SabobtagedSpeechText[2] = "Okay...here goes! I'm opening the box now, aaaaand...";
            this.SabobtagedSpeechText[3] = "...oh...wow...I...definitely didn't expect to see something like this...";
            this.SabobtagedSpeechText[4] = "...huh? What's so surprising?";
            this.SabobtagedSpeechText[5] = "Um...I have to be honest with you...I'm not really interested in this sort of thing...";
            this.SabobtagedSpeechText[6] = "...I...uh...oh...so, not a fan, then...?";
            this.SabobtagedSpeechText[7] = "Please don't try to share this type of stuff with me again, okay?";
            this.SabobtagedSpeechText[8] = "...oh...wow...you really...dislike it, then, huh...";
            this.SabobtagedSpeechText[9] = "...yeah, well...anyway...enjoy your lunch, I guess...";
            this.SabobtagedSpeechText[10] = "...I...I was just trying to...yeah...okay...";
            break;
          case 9:
            this.SpeechText[1] = "Hehe~ Senpai~ Hey, Senpaaaaai~";
            this.SpeechText[2] = "Oh!! Umm, hi!! Hi, hello...hi!";
            this.SpeechText[3] = "Hehe~ Aww, you're so cute when you're flustered~";
            this.SpeechText[4] = "Hey~ I want to show you something~ In...private~";
            this.SpeechText[5] = "...oh...oh?! Oh?! Something...in...p...private?!";
            this.SpeechText[6] = "Hehe~ Hey...meet me on the school rooftop at lunchtime...okaaaaay?";
            this.SpeechText[7] = "Oh!! Yes!! Sure!! Yes!! I promise!! I'll be there!!";
            this.SpeechText[8] = "Hehe~ You're so cute when you're eager~";
            this.SpeechText[9] = "I'll be looking forward to lunchtime, then...Senpaaaaai~";
            this.SpeechText[10] = "Oh...ohhhhh...! M-me, too...!";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hehe~ Senpai~ You're here~ Hehehe~ Here, take this box...open it!";
            this.SpeechText[2] = "...o-oh?! A gift?! For me?! You're too kind!! Let's see what's inside...";
            this.SpeechText[3] = "...oh?! It's a magazine...with you on the cover! I don't recognize it...";
            this.SpeechText[4] = "But, I could have sworn I already collected every magazine with you in it...";
            this.SpeechText[5] = "Heh...Senpai...this one had to be pulled off the shelves...";
            this.SpeechText[6] = "Because...it was just~ too~ raunchy~";
            this.SpeechText[7] = "...o-oh?! Ohhhhh?!";
            this.SpeechText[8] = "(Senpai opens up the magazine and gazes at the photographs within.)";
            this.SpeechText[9] = "...oh...ohhhhh!! Oh my gosh!! U-um, th-thank you for...sharing this with me!!";
            this.SpeechText[10] = "Hehehe...you always get so excited~ It's sooooo cute, Senpai~";
            this.SabobtagedSpeechText[1] = "Hehe~ Senpai~ You're here~ Hehehe~ Here, take this box...open it!";
            this.SabobtagedSpeechText[2] = "...o-oh?! A gift?! For me?! You're too kind!! Let's see what's inside...";
            this.SabobtagedSpeechText[3] = "...oh...wow...I...definitely didn't expect to see something like this...";
            this.SabobtagedSpeechText[4] = "...hmm? What's wrong, Senpai? I thought you'd like it~";
            this.SabobtagedSpeechText[5] = "Um...I have to be honest with you...I'm not really interested in this sort of thing...";
            this.SabobtagedSpeechText[6] = "...what? Huh? Okay...now I know you're just playing hard-to-get.";
            this.SabobtagedSpeechText[7] = "Please don't try to share this type of stuff with me again, okay?";
            this.SabobtagedSpeechText[8] = "...whoa. Relax. No need to get all offended.";
            this.SabobtagedSpeechText[9] = "...yeah, well...anyway...enjoy your lunch, I guess...";
            this.SabobtagedSpeechText[10] = "...what the hell? Whatever. See you later.";
            break;
          case 10:
            this.SpeechText[1] = "Senpai. I need to tell you something.";
            this.SpeechText[2] = "...huh? Well, okay...";
            this.SpeechText[3] = "I bought a present for you. It's in this box. See this box?";
            this.SpeechText[4] = "I'm going to go put this box on my desk now. Got that?";
            this.SpeechText[5] = "Uh...um...okay...?";
            this.SpeechText[6] = "Meet me on the school rooftop at lunchtime. I'll give you the present.";
            this.SpeechText[7] = "Uh...well, if you say so, I suppose.";
            this.SpeechText[8] = "Good. I'm going to go put this PRESENT FOR YOU on MY DESK now.";
            this.SpeechText[9] = "Remember: Meet me on the rooftop at lunchtime.";
            this.SpeechText[10] = "Um...okay?? Sure?? I...guess??";
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai. Please open this box and tell me what's inside.";
            this.SpeechText[2] = "...well, okay. I'll open it now...";
            this.SpeechText[3] = "...huh? ...what? ...it's...just empty?";
            this.SpeechText[4] = "...okay. I've played along up until now, but I need an explanation this time.";
            this.SpeechText[5] = "I anticipated that, if someone knew I was trying to give you a gift...";
            this.SpeechText[6] = "...they would make some sort of attempt to sabotage it.";
            this.SpeechText[7] = "So, the box...was always empty? You left it on your desk as...bait, I guess?";
            this.SpeechText[8] = "(Senpai stares at the empty box for a moment.)";
            this.SpeechText[9] = "Okay, but why? Why do you suspect that someone would sabotage the gift?";
            this.SpeechText[10] = "I'm sorry, Senpai...for the sake of the investigation, I can't tell you yet.";
            this.SabobtagedSpeechText[1] = "Senpai. Please open this box and tell me what's inside.";
            this.SabobtagedSpeechText[2] = "...well, okay. I'll open it now...";
            this.SabobtagedSpeechText[3] = "...oh...wow...I...definitely didn't expect to see something like this...";
            this.SabobtagedSpeechText[4] = "The box was empty this morning. Someone put contraband inside of it.";
            this.SabobtagedSpeechText[5] = "Huh? What? Why would someone do that?";
            this.SabobtagedSpeechText[6] = "Someone is attempting to sabotage my interactions with you.";
            this.SabobtagedSpeechText[7] = "But...but, why? What motive does anyone have to do that?";
            this.SabobtagedSpeechText[8] = "Senpai...I know the answer to that question, but...";
            this.SabobtagedSpeechText[9] = "...you can't tell me because it would jeopardize the investigation.";
            this.SabobtagedSpeechText[10] = "Yes...you understand. I'm sorry for the secrecy, Senpai.";
            break;
        }
      }
      else if (this.EventDay == DayOfWeek.Thursday)
      {
        switch (week)
        {
          case 2:
            this.SpeechText[1] = "Hey, Senpai! We still on for that movie later tonight?";
            this.SpeechText[2] = "Yeah! I can't wait to go see it with you!";
            this.SpeechText[3] = "So, just to make sure, we're going to meet up here at 5:15 PM, right?";
            this.SpeechText[4] = "Yep, that's right!";
            if ((double) this.StartTime == 0.0)
            {
              this.SpeechText[5] = "Phew, I'm glad I remembered the time correctly - (Yawn)";
              this.SpeechText[6] = "Oh, sorry about that...I guess I didn't get much sleep last night, haha...";
              this.SpeechText[7] = "Maybe you should take a nap after cleaning time is over.";
              this.SpeechText[8] = "Hmm...that might be a good idea. Yeah, I should do that!";
              this.SpeechText[9] = "Sometimes a big meal puts me right to sleep...";
              this.SpeechText[10] = "I guess I should be careful what I eat at lunchtime!";
            }
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Yo! Senpai! Ready to get goin'?";
            this.SpeechText[2] = "Yeah!";
            this.SpeechText[3] = "Awesome! Then let's get movin'!";
            break;
          case 3:
            this.SpeechText[1] = "...s...senpai...the...the movie...um...are we...still...";
            this.SpeechText[2] = "...yep! I haven't forgotten! We're seeing a movie tonight!";
            this.SpeechText[3] = "...um...the time...uh...5:15...PM..?";
            this.SpeechText[4] = "Yep, that's right! We're meeting here at 5:15!";
            if ((double) this.StartTime == 0.0)
            {
              this.SpeechText[5] = "...great...I'm...(yawn)...oh...oops...uh...";
              this.SpeechText[6] = "...sorry...just...sleepy...(yawn)...sorry again...";
              this.SpeechText[7] = "Maybe you should take a nap after cleaning time is over.";
              this.SpeechText[8] = "...oh...!...that might be smart...!";
              this.SpeechText[9] = "...just gotta make sure not to oversleep...";
              this.SpeechText[10] = "...better watch what I eat...at lunchtime...";
            }
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "...um...I...I, uh...do you...still want to...";
            this.SpeechText[2] = "...see the movie? Yeah! Let's go!";
            this.SpeechText[3] = "...o-oh...!...yeah...let's...g-go...!...";
            break;
          case 4:
            this.SpeechText[1] = "Hey, Senpai! You haven't forgotten our plans, right?";
            this.SpeechText[2] = "I didn't forget! We're going to see a movie later tonight!";
            this.SpeechText[3] = "And when are we going to meet up back here?";
            this.SpeechText[4] = "At 5:15 PM!";
            if ((double) this.StartTime == 0.0)
            {
              this.SpeechText[5] = "Nice! I'm glad that you're a dependable guy, Senpai. Some guys are just...(yawn)";
              this.SpeechText[6] = "Whoa, sorry, that yawn was rude of me. I guess I'm tired after jogging to school...";
              this.SpeechText[7] = "Maybe you should take a nap after cleaning time is over.";
              this.SpeechText[8] = "Hey, smart idea, Senpai! Good thinking!";
              this.SpeechText[9] = "Depending on the ingredients I put into my food, I can get really sleepy...";
              this.SpeechText[10] = "...so I'll just be extra careful what I eat today!";
            }
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai! We gotta hurry if we're gonna catch that movie!";
            this.SpeechText[2] = "...are you telling me we're going to jog the whole way there?";
            this.SpeechText[3] = "Of course! That was always the plan! Now let's get going";
            break;
          case 5:
            this.SpeechText[1] = "Senpai! Clear your schedule. You are going to accompany me to see a film tonight.";
            this.SpeechText[2] = "...uh...what? I mean, sure, I guess, but...shouldn't you, like...ask if...";
            this.SpeechText[3] = "Silence! I won't tolerate any back-talk. Meet me here at 5:15 PM. Understood?";
            this.SpeechText[4] = "Well, I...yeah. I can do that.";
            if ((double) this.StartTime == 0.0)
            {
              this.SpeechText[5] = "Good. I will take my leave now. Be sure not to...(Yawn)";
              this.SpeechText[6] = "...ugh...how...uncouth of me...you did NOT see that, understood?";
              this.SpeechText[7] = "Sleepy? Maybe you should take a nap after cleaning time is over.";
              this.SpeechText[8] = "Nap?! Like a lazy servant who is slacking on the job?! Are you serious?!";
              this.SpeechText[9] = "Although...a nap at cleaning time may be beneficial...";
              this.SpeechText[10] = "Perhaps I shall. After all, it's not like I'll oversleep or anything like that!";
            }
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai! I'm glad you're capable of keeping an appointment.";
            this.SpeechText[2] = "...so, uh...is this the part where we go see a movie...?";
            this.SpeechText[3] = "Yes! Now put one foot in front of the other and start walking!";
            break;
          case 6:
            this.SpeechText[1] = "Senpaaaaai! Senpai Senpai Senpai! Hey, watch a movie with me tonight!";
            this.SpeechText[2] = "Oh? You'd like to go see a film with me?";
            this.SpeechText[3] = "Yeah! Yeah yeah yeah! There's a good one we can catch if we leave here at 5:15 PM!";
            this.SpeechText[4] = "Well, sure, sounds like it'd be fun!";
            if ((double) this.StartTime == 0.0)
            {
              this.SpeechText[5] = "Whoohoo! I'm gonna look forward to it alllll day! Now I just...(Yawn)";
              this.SpeechText[6] = "Whoop, sorry! Kinda sleepy, hehe...kinda difficult to stay energetic right now...";
              this.SpeechText[7] = "Maybe you should take a nap after cleaning time is over.";
              this.SpeechText[8] = "Ohh!! You're smart as always, Senpai!! I'll do that!!";
              this.SpeechText[9] = "Sometimes if I eat too much, I sleep for hours and hours...";
              this.SpeechText[10] = "I'll just be extra careful what I eat at lunchtime!";
            }
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Seeeeenpaaaaai! Are youready to go see the movie?!";
            this.SpeechText[2] = "Yep, I sure am!";
            this.SpeechText[3] = "Whoo hoo! Then let's get going right away!";
            break;
          case 7:
            this.SpeechText[1] = "Hey, Senpai! We still on for that movie later tonight?";
            this.SpeechText[2] = "Yeah! I can't wait to go see it with you!";
            this.SpeechText[3] = "So, just to make sure, we're going to meet up here at 5:15 PM, right?";
            this.SpeechText[4] = "Yep, that's right!";
            if ((double) this.StartTime == 0.0)
            {
              this.SpeechText[5] = "Phew, I'm glad I remembered the time correctly - (Yawn)";
              this.SpeechText[6] = "Oh, sorry about that...I guess I didn't get much sleep last night, haha...";
              this.SpeechText[7] = "Maybe you should take a nap after cleaning time is over.";
              this.SpeechText[8] = "Hmm...that might be a good idea. Yeah, I should do that!";
              this.SpeechText[9] = "Sometimes a big meal puts me right to sleep...";
              this.SpeechText[10] = "I guess I should be careful what I eat at lunchtime!";
            }
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai! It's good to see you. Ready to go see that movie?";
            this.SpeechText[2] = "Yeah!";
            this.SpeechText[3] = "That's good to hear! Let's go!";
            break;
          case 8:
            this.SpeechText[1] = "Good morning, Senpai. Are we still going to watch a motion picture later tonight?";
            this.SpeechText[2] = "Yeah! Nothing has come up that would change my schedule for today!";
            this.SpeechText[3] = "I'm so glad to hear that. We'll meet each other here at 5:15 PM, right?";
            this.SpeechText[4] = "Yep, that's right!";
            if ((double) this.StartTime == 0.0)
            {
              this.SpeechText[5] = "I'm very glad that I...I...";
              this.SpeechText[6] = "...oh, my. I'm very sorry. I nearly yawned a moment ago...";
              this.SpeechText[7] = "Sleepy? Maybe you should take a nap after cleaning time is over.";
              this.SpeechText[8] = "That is a good suggestion, Senpai! I believe that I'll do so!";
              this.SpeechText[9] = "I admit that I am sometimes guilty of oversleeping, but...";
              this.SpeechText[10] = "...it won't be a problem if I'm careful what I eat at lunchtime!";
            }
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Good afternoon, Senpai. Are you ready to see the motion picture?";
            this.SpeechText[2] = "Haha, you don't have to be so formal! But, yeah, I'm ready!";
            this.SpeechText[3] = "Splendid! Let's be on our way, then.";
            break;
          case 9:
            this.SpeechText[1] = "Hey, Senpai~ Go out with me tonight~";
            this.SpeechText[2] = "...h...huh?! Wait...r...r...really?!";
            this.SpeechText[3] = "Hehe, yes really~ There's a film we can catch if we leave here at 5:15 PM~";
            this.SpeechText[4] = "Oh...oh!! Yes!! I'd love to go!!";
            if ((double) this.StartTime == 0.0)
            {
              this.SpeechText[5] = "Hehehe...mmmmm, you're so cute, Senpai...";
              this.SpeechText[6] = "...ah...I'm so sleepy...hope I don't doze off in class today...";
              this.SpeechText[7] = "Maybe you should take a nap after cleaning time is over.";
              this.SpeechText[8] = "Hehe~ Hey~ Goood idea, Senpai~ I think I'll do that~";
              this.SpeechText[9] = "Gotta watch what I eat today. Oh, not just to keep my figure, though~";
              this.SpeechText[10] = "Sometimes I oversleep depending on what I eat, haha~";
            }
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Hehe~ Senpai~ You're on time~ I love a punctual man~";
            this.SpeechText[2] = "...o-oh...so, it really wasn't a prank after all...?!";
            this.SpeechText[3] = "Haha, of course not! I really DO want to see a movie with you! Let's go~";
            break;
          case 10:
            this.SpeechText[1] = "Senpai. This is dangerous, but it may be the fastest way to expose a criminal.";
            this.SpeechText[2] = "Huh? Um...I'm a bit worried, but...alright. Tell me what you need me to do.";
            this.SpeechText[3] = "I need you to go out on a date with me.";
            this.SpeechText[4] = "Wh...what?! S...seriously?! A...date?!";
            if ((double) this.StartTime == 0.0)
            {
              this.SpeechText[5] = "That is correct. Meet me here at 5:15 PM so that we can leave school together.";
              this.SpeechText[6] = "...ugh...I couldn't sleep last night...it'll be hard to concentrate today...";
              this.SpeechText[7] = "Maybe you should take a nap after cleaning time is over.";
              this.SpeechText[8] = "Sleep? Here? Never. It would make me too vulnerable. I'd be defenseless.";
              this.SpeechText[9] = "...but...if I don't get some rest soon...the whole operation could fail...";
              this.SpeechText[10] = "...as long as I'm careful what I eat at lunchtime, I shouldn't oversleep...";
            }
            if ((double) this.StartTime <= 0.0)
              break;
            this.SpeechText[1] = "Senpai. The date is cancelled.";
            this.SpeechText[2] = "(Sigh) Pretending to arrange a date with me was part of the investigation, huh?";
            this.SpeechText[3] = "You understand. I'm sorry. When the investigation is over, I'll explain everything.";
            break;
        }
      }
      else
      {
        if (this.EventDay != DayOfWeek.Friday)
          return;
        switch (week)
        {
          case 2:
            this.SpeechText[1] = "Yo, Senpai...you seem kinda down today. What's the matter?";
            this.SpeechText[2] = "Oh...I'm worried about the test we're going to have before lunch today...";
            this.SpeechText[3] = "I took a lot of notes in class in preparation for this test, but...";
            this.SpeechText[4] = "Somehow, I lost all of the notes I took, and now I can't study before the test...";
            this.SpeechText[5] = "Oh! Let me help, Senpai! I'll share my notes with you!";
            this.SpeechText[6] = "I'll just dash over to my desk and copy the notes I took.";
            this.SpeechText[7] = "Once I finish copying everything down, I'll put my notes on your desk, okay?";
            this.SpeechText[8] = "Wow, would you really do that for me? I would appreciate that a lot!";
            this.SpeechText[9] = "Hell yeah, Senpai! It'll be no problem at all!";
            this.SpeechText[10] = "Hey, meet me on the roof at lunchtime so that you can tell me if my notes helped you!";
            if ((double) this.StartTime > 0.0)
            {
              this.SpeechText[1] = "Yo, Senpai! I've been curious all day! Did my notes help?";
              this.SpeechText[2] = "Yeah! Thanks to your notes, I aced that test!";
              this.SpeechText[3] = "Oh, kick-ass! I'm really glad to hear that!";
              this.SpeechText[4] = "I probably would have flunked that test if it wasn't for your help! I owe you big time!";
              this.SpeechText[5] = "Haha, aww, shucks...I'm just glad that I was actually able to help for once!";
              this.SabobtagedSpeechText[1] = "Yo, Senpai! I've been curious all day! Did my notes help?";
              this.SabobtagedSpeechText[2] = "...uh...well...I'll just...be honest...";
              this.SabobtagedSpeechText[3] = "I'm sorry, but...your notes didn't help me at all...";
              this.SabobtagedSpeechText[4] = "...huh?! What?! Oh, no!! I'm so sorry, Senpai!!";
              this.SabobtagedSpeechText[5] = "Nothing that you wrote down was correct...everything was wrong.";
              this.SabobtagedSpeechText[6] = "Honestly, I thought it was a prank or something...";
              this.SabobtagedSpeechText[7] = "Ahhhhh! I'm so sorry, I'm so sorry, I'm so sorry!";
              this.SabobtagedSpeechText[8] = "Dang it...I shouldn't have offered to help...I'm a screw up...";
              this.SabobtagedSpeechText[9] = "I only just barely passed the entrance exams...I don't really belong at this school...";
              this.SabobtagedSpeechText[10] = "I'm so sorry, Senpai...I'm just...not the right person to rely on, when it counts...";
              break;
            }
            break;
          case 3:
            this.SpeechText[1] = "...senpai?...are you...sad...?...what's the matter...?...";
            this.SpeechText[2] = "Oh...I'm worried about the test we're going to have before lunch today...";
            this.SpeechText[3] = "I took a lot of notes in class in preparation for this test, but...";
            this.SpeechText[4] = "Somehow, I lost all of the notes I took, and now I can't study before the test...";
            this.SpeechText[5] = "...oh...!...Senpai, I can help...!...I'll...share my notes with you...!";
            this.SpeechText[6] = "...I'll...go to my desk...and copy my notes...";
            this.SpeechText[7] = "...I'll...put my notes...on your desk...okay...?...";
            this.SpeechText[8] = "Wow, would you really do that for me? I would appreciate that a lot!";
            this.SpeechText[9] = "Senpai...it would make me happy...if I could help you...!...";
            this.SpeechText[10] = "Um...at lunchtime...on the rooftop...tell me if my notes helped...okay...?...";
            if ((double) this.StartTime > 0.0)
            {
              this.SpeechText[1] = "...s...senpai...did...did I help...?...";
              this.SpeechText[2] = "Yeah! Thanks to your notes, I aced that test!";
              this.SpeechText[3] = "...o-oh...!...I'm...so glad I was able to...help...";
              this.SpeechText[4] = "I probably would have flunked that test if it wasn't for your help! I owe you big time!";
              this.SpeechText[5] = "...r...really...?...I helped...that much...?...hehe...I'm glad...";
              this.SabobtagedSpeechText[1] = "...s...senpai...did...did I help...?...";
              this.SabobtagedSpeechText[2] = "...uh...well...I'll just...be honest...";
              this.SabobtagedSpeechText[3] = "I'm sorry, but...your notes didn't help me at all...";
              this.SabobtagedSpeechText[4] = "...oh...oh, no...!...";
              this.SabobtagedSpeechText[5] = "Nothing that you wrote down was correct...everything was wrong.";
              this.SabobtagedSpeechText[6] = "Honestly, I thought it was a prank or something...";
              this.SabobtagedSpeechText[7] = "...I...I...I'm sorry, I'm sorry...";
              this.SabobtagedSpeechText[8] = "...I tried...I tried to help, but I...";
              this.SabobtagedSpeechText[9] = "...I'm just...I'm just a screw-up, after all...";
              this.SabobtagedSpeechText[10] = "...ugh...just kill me now...I want to die...I'm so sorry, Senpai...";
              break;
            }
            break;
          case 4:
            this.SpeechText[1] = "Sup, Senpai! ...oh, wait. You seem kinda...sad. Is something wrong?";
            this.SpeechText[2] = "Oh...I'm worried about the test we're going to have before lunch today...";
            this.SpeechText[3] = "I took a lot of notes in class in preparation for this test, but...";
            this.SpeechText[4] = "Somehow, I lost all of the notes I took, and now I can't study before the test...";
            this.SpeechText[5] = "Oh! Hey, I can help you with that! I'll share my notes with you!";
            this.SpeechText[6] = "I'll only need a second to copy down the notes I took....";
            this.SpeechText[7] = "I'll put my notes on your desk in just a few minutes, okay?";
            this.SpeechText[8] = "Wow, would you really do that for me? I would appreciate that a lot!";
            this.SpeechText[9] = "Haha! It's no problem! I'm happy to help!";
            this.SpeechText[10] = "Just promise to meet me on the roof at lunchtime and tell me if my notes helped you!";
            if ((double) this.StartTime > 0.0)
            {
              this.SpeechText[1] = "Hey! Senpai! I gotta know! Did my notes help you out?";
              this.SpeechText[2] = "Yeah! Thanks to your notes, I aced that test!";
              this.SpeechText[3] = "Oh, really?! Whoohoo, that's great news!";
              this.SpeechText[4] = "I probably would have flunked that test if it wasn't for your help! I owe you big time!";
              this.SpeechText[5] = "Whoa, haha, it made that much of a difference? Well, I'm really glad I helped you out!";
              this.SabobtagedSpeechText[1] = "Hey! Senpai! I gotta know! Did my notes help you out?";
              this.SabobtagedSpeechText[2] = "...uh...well...I'll just...be honest...";
              this.SabobtagedSpeechText[3] = "I'm sorry, but...your notes didn't help me at all...";
              this.SabobtagedSpeechText[4] = "...huh, what? Oh, shoot...what happened?";
              this.SabobtagedSpeechText[5] = "Nothing that you wrote down was correct...everything was wrong.";
              this.SabobtagedSpeechText[6] = "Honestly, I thought it was a prank or something...";
              this.SabobtagedSpeechText[7] = "Whoa! I mean, I might be better at sports than book stuff, but still!";
              this.SabobtagedSpeechText[8] = "I'd like to think that I can at least take notes and pass them along...";
              this.SabobtagedSpeechText[9] = "Shoot, Senpai...I don't know what to tell you. I don't know what went wrong...";
              this.SabobtagedSpeechText[10] = "I don't know what to say...but...let me try to make it up to you somehow, okay?";
              break;
            }
            break;
          case 5:
            this.SpeechText[1] = "Senpai! I demand your attention immediately! I need...wait. ...is something wrong?";
            this.SpeechText[2] = "Oh...I'm worried about the test we're going to have before lunch today...";
            this.SpeechText[3] = "I took a lot of notes in class in preparation for this test, but...";
            this.SpeechText[4] = "Somehow, I lost all of the notes I took, and now I can't study before the test...";
            this.SpeechText[5] = "Ugh...the problems of poor people...";
            this.SpeechText[6] = "I already have the answer sh - I mean...I have already taken extensive notes.";
            this.SpeechText[7] = "I'll go...copy my notes...and put them on your desk.";
            this.SpeechText[8] = "Wow, would you really do that for me? I would appreciate that a lot!";
            this.SpeechText[9] = "Ugh...you'd better be grateful to me, after you've inconvenienced me like this...";
            this.SpeechText[10] = "I insist that you must meet me on the roof at lunchtime and that tell me if my notes helped you!";
            if ((double) this.StartTime > 0.0)
            {
              this.SpeechText[1] = "Senpai! The notes I left for you were flawless. I assume you passed with flying colors?";
              this.SpeechText[2] = "Yeah! Thanks to your notes, I aced that test!";
              this.SpeechText[3] = "Hmph! As expected, since you were using MY notes, after all.";
              this.SpeechText[4] = "I probably would have flunked that test if it wasn't for your help! I owe you big time!";
              this.SpeechText[5] = "Don't get used to it! I won't always be there to bail you out! ...but...you're welcome.";
              this.SabobtagedSpeechText[1] = "Senpai! The notes I left for you were flawless. I assume you passed with flying colors?";
              this.SabobtagedSpeechText[2] = "...uh...well...I'll just...be honest...";
              this.SabobtagedSpeechText[3] = "I'm sorry, but...your notes didn't help me at all...";
              this.SabobtagedSpeechText[4] = "...what?! But, I literally gave the answer sh - uh, I mean...what?!";
              this.SabobtagedSpeechText[5] = "Nothing that you wrote down was correct...everything was wrong.";
              this.SabobtagedSpeechText[6] = "Honestly, I thought it was a prank or something...";
              this.SabobtagedSpeechText[7] = "That can't be! Unless I...grabbed the wrong sheet by accident...";
              this.SabobtagedSpeechText[8] = "...w-well, Senpai, clearly, this must be some sort of mistake on YOUR end.";
              this.SabobtagedSpeechText[9] = "I most certainly did not make ANY mistakes when copying my notes, so...uh...";
              this.SabobtagedSpeechText[10] = "...if you expect an apology, you are sorely mistaken! I have done no wrong!";
              break;
            }
            break;
          case 6:
            this.SpeechText[1] = "...Senpai?! Are you sad?! Why?! Tell me all about it!! I want you to smile, Senpai!!";
            this.SpeechText[2] = "Oh...I'm worried about the test we're going to have before lunch today...";
            this.SpeechText[3] = "I took a lot of notes in class in preparation for this test, but...";
            this.SpeechText[4] = "Somehow, I lost all of the notes I took, and now I can't study before the test...";
            this.SpeechText[5] = "Oh! Oh oh oh oh oh! I can help with this one! I can actually help!";
            this.SpeechText[6] = "I'm gonna run over to my desk and copy my notes for you!";
            this.SpeechText[7] = "And then, when I'm done, I'll put my notes on your desk, okay?";
            this.SpeechText[8] = "Wow, would you really do that for me? I would appreciate that a lot!";
            this.SpeechText[9] = "Of course! I want to bring smiles to the whole world, Senpai! And I'll start with you!";
            this.SpeechText[10] = "In exchange...meet me on the roof at lunchtime and tell me if my notes helped! Hehe!";
            if ((double) this.StartTime > 0.0)
            {
              this.SpeechText[1] = "Senpaaaaai, Senpaaaaai! Tell me, tell me, tell me! Did my notes help you?!";
              this.SpeechText[2] = "Yeah! Thanks to your notes, I aced that test!";
              this.SpeechText[3] = "Oh, yippieeeee! I'm so happy to hear that, Senpai!";
              this.SpeechText[4] = "I probably would have flunked that test if it wasn't for your help! I owe you big time!";
              this.SpeechText[5] = "Hehe! Yep, that's me! Your hero, Senpai! Now and forever!";
              this.SabobtagedSpeechText[1] = "Senpaaaaai, Senpaaaaai! Tell me, tell me, tell me! Did my notes help you?!";
              this.SabobtagedSpeechText[2] = "...uh...well...I'll just...be honest...";
              this.SabobtagedSpeechText[3] = "I'm sorry, but...your notes didn't help me at all...";
              this.SabobtagedSpeechText[4] = "...h-huh?! What?! Oh, nooooo! Please, tell me it's not true, Senpai!";
              this.SabobtagedSpeechText[5] = "Nothing that you wrote down was correct...everything was wrong.";
              this.SabobtagedSpeechText[6] = "Honestly, I thought it was a prank or something...";
              this.SabobtagedSpeechText[7] = "...oh...oh gosh...oh gosh...";
              this.SabobtagedSpeechText[8] = "...I'm so sorry...I just wanted to help...I didn't think I would...";
              this.SabobtagedSpeechText[9] = "...aw, darn...aw, shoot...I really...screwed everything up...";
              this.SabobtagedSpeechText[10] = "...I'm sorry...I'm sorry, Senpai, I'm so sorry...";
              break;
            }
            break;
          case 7:
            this.SpeechText[1] = "Oh, dear...Senpai, you seem rather sad today. What's the matter...?";
            this.SpeechText[2] = "Oh...I'm worried about the test we're going to have before lunch today...";
            this.SpeechText[3] = "I took a lot of notes in class in preparation for this test, but...";
            this.SpeechText[4] = "Somehow, I lost all of the notes I took, and now I can't study before the test...";
            this.SpeechText[5] = "You're in luck, Senpai! I don't mean to boast, but I happen to take very thorough notes!";
            this.SpeechText[6] = "I'll simply head over to my desk and create a copy of my notes...";
            this.SpeechText[7] = "...then, I'll go over to your classroom and put my notes on your desk, okay?";
            this.SpeechText[8] = "Wow, would you really do that for me? I would appreciate that a lot!";
            this.SpeechText[9] = "It would be my pleasure, Senpai! It's not any inconvenience at all!";
            this.SpeechText[10] = "I will want to know if my notes were helpful, so please meet me on the roof at lunchtime!";
            if ((double) this.StartTime > 0.0)
            {
              this.SpeechText[1] = "Senpai! I wrote the best notes for you that I possibly could. Did they help?";
              this.SpeechText[2] = "Yeah! Thanks to your notes, I aced that test!";
              this.SpeechText[3] = "I'm glad to hear that! I'm very confident in my ability to take good notes!";
              this.SpeechText[4] = "I probably would have flunked that test if it wasn't for your help! I owe you big time!";
              this.SpeechText[5] = "Oh, it was nothing! I'd be willing to help you out with academic pursuits anytime!";
              this.SabobtagedSpeechText[1] = "Senpai! I wrote the best notes for you that I possibly could. Did they help?";
              this.SabobtagedSpeechText[2] = "...uh...well...I'll just...be honest...";
              this.SabobtagedSpeechText[3] = "I'm sorry, but...your notes didn't help me at all...";
              this.SabobtagedSpeechText[4] = "...what? That's...not possible. My notes should have been perfect.";
              this.SabobtagedSpeechText[5] = "Nothing that you wrote down was correct...everything was wrong.";
              this.SabobtagedSpeechText[6] = "Honestly, I thought it was a prank or something...";
              this.SabobtagedSpeechText[7] = "What?! Something is seriously wrong here. My notes were flawless...";
              this.SabobtagedSpeechText[8] = "I try to never boast, but...I DO have the best grades in school, so...";
              this.SabobtagedSpeechText[9] = "...oh...no, no...there's only one explanation...I think I understand...";
              this.SabobtagedSpeechText[10] = "...I copied the wrong notes by mistake...I'm sorry, Senpai...it's my fault...";
              break;
            }
            break;
          case 8:
            this.SpeechText[1] = "Good morning, Senpai. Oh dear, oh dear...you seem sad today. What is wrong?";
            this.SpeechText[2] = "Oh...I'm worried about the test we're going to have before lunch today...";
            this.SpeechText[3] = "I took a lot of notes in class in preparation for this test, but...";
            this.SpeechText[4] = "Somehow, I lost all of the notes I took, and now I can't study before the test...";
            this.SpeechText[5] = "Ah! Senpai, I want to help you! I'll make a copy of my notes and give them to you!";
            this.SpeechText[6] = "I'll go to my desk to create the copy, and then I'll put the copy on your desk.";
            this.SpeechText[7] = "I won't take no for an answer! I want to help you however I can, Senpai!";
            this.SpeechText[8] = "Wow, would you really do that for me? I would appreciate that a lot!";
            this.SpeechText[9] = "I'm so happy to have an opportunity to help you out, Senpai!";
            this.SpeechText[10] = "Please, meet me on the rooftop at lunchtime to let me know if my notes were useful!";
            if ((double) this.StartTime > 0.0)
            {
              this.SpeechText[1] = "Good afternoon, Senpai. I'm very interested in learning if my notes were of use to you.";
              this.SpeechText[2] = "Yeah! Thanks to your notes, I aced that test!";
              this.SpeechText[3] = "Oh, wonderful! I'm absolutely delighted to hear that, Senpai!";
              this.SpeechText[4] = "I probably would have flunked that test if it wasn't for your help! I owe you big time!";
              this.SpeechText[5] = "Oh, Senpai...you don't know how happy it makes me to know that I was able to help you!";
              this.SabobtagedSpeechText[1] = "Good afternoon, Senpai. I'm very interested in learning if my notes were of use to you.";
              this.SabobtagedSpeechText[2] = "...uh...well...I'll just...be honest...";
              this.SabobtagedSpeechText[3] = "I'm sorry, but...your notes didn't help me at all...";
              this.SabobtagedSpeechText[4] = "...what?! Oh, no!! What happened, Senpai?!";
              this.SabobtagedSpeechText[5] = "Nothing that you wrote down was correct...everything was wrong.";
              this.SabobtagedSpeechText[6] = "Honestly, I thought it was a prank or something...";
              this.SabobtagedSpeechText[7] = "No! No, Senpai, I would never pull a prank on you - or anyone!";
              this.SabobtagedSpeechText[8] = "How could this be possible...I thought that my notes were flawless...";
              this.SabobtagedSpeechText[9] = "I'm so sorry, Senpai...there truly is no excuse for this mistake...";
              this.SabobtagedSpeechText[10] = "...all I can do is give you my word that I'll never let it happen again...";
              break;
            }
            break;
          case 9:
            this.SpeechText[1] = "Senpai~ Hey, Senpaaaaai~ ...oh, no! What's got you looking so down~?";
            this.SpeechText[2] = "Oh...I'm worried about the test we're going to have before lunch today...";
            this.SpeechText[3] = "I took a lot of notes in class in preparation for this test, but...";
            this.SpeechText[4] = "Somehow, I lost all of the notes I took, and now I can't study before the test...";
            this.SpeechText[5] = "...heh. I might actually be able to help you with this one.";
            this.SpeechText[6] = "You may not believe me, but I actually did come to this school to study.";
            this.SpeechText[7] = "I've taken a lot of notes. I'll go copy them and put them on your desk.";
            this.SpeechText[8] = "Wow, would you really do that for me? I would appreciate that a lot!";
            this.SpeechText[9] = "Hehe~ No problem~ Anything for my Senpai~ Hehehehe~";
            this.SpeechText[10] = "Hey...at lunchtime, meet me on the rooftop and let me know if my notes were useful~";
            if ((double) this.StartTime > 0.0)
            {
              this.SpeechText[1] = "Hey~ Senpai~ C'mon, tell me...did my notes help you~?";
              this.SpeechText[2] = "Yeah! Thanks to your notes, I aced that test!";
              this.SpeechText[3] = "Oh, I'm so happy to hear that, Senpaaaaai~!";
              this.SpeechText[4] = "I probably would have flunked that test if it wasn't for your help! I owe you big time!";
              this.SpeechText[5] = "Hehehe...oh, whatever would you do without me~? Looks like you need me, Senpai~";
              this.SabobtagedSpeechText[1] = "Hey~ Senpai~ C'mon, tell me...did my notes help you~?";
              this.SabobtagedSpeechText[2] = "...uh...well...I'll just...be honest...";
              this.SabobtagedSpeechText[3] = "I'm sorry, but...your notes didn't help me at all...";
              this.SabobtagedSpeechText[4] = "...huh? Whoa. That's not what I expected. I tried to take good notes.";
              this.SabobtagedSpeechText[5] = "Nothing that you wrote down was correct...everything was wrong.";
              this.SabobtagedSpeechText[6] = "Honestly, I thought it was a prank or something...";
              this.SabobtagedSpeechText[7] = "Owch, that's kind of a rude thing to say, don't you think? Yeesh.";
              this.SabobtagedSpeechText[8] = "Look, I don't know what to tell you. I actually put effort into those notes.";
              this.SabobtagedSpeechText[9] = "Hmph...guess you think I'm just some dumb bimbo with no brains now, huh?";
              this.SabobtagedSpeechText[10] = "Well, whatever...sorry it didn't work out. Later, Senpai...";
              break;
            }
            break;
          case 10:
            this.SpeechText[1] = "Senpai. I will need your full cooperation today. I need...wait, what's wrong?";
            this.SpeechText[2] = "Oh...I'm worried about the test we're going to have before lunch today...";
            this.SpeechText[3] = "I took a lot of notes in class in preparation for this test, but...";
            this.SpeechText[4] = "Somehow, I lost all of the notes I took, and now I can't study before the test...";
            this.SpeechText[5] = "...(sigh)...today is a critical turning point. I really need your help today...";
            this.SpeechText[6] = "...but, if you're distracted by this matter, I won't be able to count on you...";
            this.SpeechText[7] = "...look. I'll go prepare a bunch of notes and leave them on your desk.";
            this.SpeechText[8] = "Wow, would you really do that for me? I would appreciate that a lot!";
            this.SpeechText[9] = "But, in exchange...you must help me with my investigation one last time.";
            this.SpeechText[10] = "At lunchtime, meet me on the rooftop. I'll give you the details then.";
            if ((double) this.StartTime > 0.0)
            {
              this.SpeechText[1] = "Senpai. I need to speak with you. But, first: did my notes help you?";
              this.SpeechText[2] = "Yeah! Thanks to your notes, I aced that test!";
              this.SpeechText[3] = "Glad to hear it. But, more importantly...I will need your assistance later today.";
              this.SpeechText[4] = "Sure! I owe you one, after all. What do you need help with?";
              this.SpeechText[5] = "I can't tell you here. Later, I will leave a note in your locker with instructions.";
              this.SabobtagedSpeechText[1] = "Senpai. I need to speak with you. But, first: did my notes help you?";
              this.SabobtagedSpeechText[2] = "...uh...well...I'll just...be honest...";
              this.SabobtagedSpeechText[3] = "I'm sorry, but...your notes didn't help me at all...";
              this.SabobtagedSpeechText[4] = "...what? That's a surprise to hear. My notes should have been flawless.";
              this.SabobtagedSpeechText[5] = "Nothing that you wrote down was correct...everything was wrong.";
              this.SabobtagedSpeechText[6] = "Honestly, I thought it was a prank or something...";
              this.SabobtagedSpeechText[7] = "...wait. I think I know what's going on. Someone sabotaged the notes I gave you.";
              this.SabobtagedSpeechText[8] = "Fascinating! This actually proves my hypothesis! This is a breakthrough, Senpai!";
              this.SabobtagedSpeechText[9] = "You want revenge on the person who did this? I know how to bring them to justice.";
              this.SabobtagedSpeechText[10] = "I can't tell you here. Later, I will leave a note in your locker with instructions.";
              break;
            }
            break;
        }
        if ((double) this.StartTime <= 0.0)
          return;
        this.SpeechText[6] = "";
        this.SpeechText[7] = "";
        this.SpeechText[8] = "";
        this.SpeechText[9] = "";
        this.SpeechText[10] = "";
      }
    }
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      if ((UnityEngine.Object) this.Senpai == (UnityEngine.Object) null && (UnityEngine.Object) this.Rival == (UnityEngine.Object) null)
      {
        this.Senpai = this.StudentManager.Students[1];
        if ((UnityEngine.Object) this.StudentManager.Students[this.StudentManager.RivalID] != (UnityEngine.Object) null)
          this.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
        else
          this.enabled = false;
      }
      else
      {
        if ((double) this.Clock.HourTime <= (double) this.StartTime)
          return;
        ++this.Frame;
        if (this.Frame <= 4)
          return;
        if (this.Senpai.gameObject.activeInHierarchy && (UnityEngine.Object) this.Rival != (UnityEngine.Object) null && this.Rival.enabled)
        {
          bool flag1 = false;
          if (this.Teleport || this.LunchTime || this.Senpai.Leaving || (UnityEngine.Object) this.Senpai.CurrentDestination == (UnityEngine.Object) this.StudentManager.Exit)
            flag1 = true;
          if (flag1 && !this.Senpai.InEvent)
          {
            this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
            this.Senpai.CharacterAnimation.CrossFade(this.Senpai.WalkAnim);
            this.Senpai.Pathfinding.target = this.Location[1];
            this.Senpai.CurrentDestination = this.Location[1];
            this.Senpai.Pathfinding.canSearch = true;
            this.Senpai.Pathfinding.canMove = true;
            this.Senpai.InEvent = true;
            this.Senpai.DistanceToDestination = 100f;
            this.Spy.gameObject.SetActive(true);
            this.Spy.Prompt.enabled = true;
            if (this.Teleport)
            {
              this.Senpai.transform.eulerAngles = this.Location[1].eulerAngles;
              this.Senpai.transform.position = this.Location[1].position;
              this.Senpai.CharacterAnimation.Play(this.Senpai.IdleAnim);
              this.Senpai.Pathfinding.canSearch = false;
              this.Senpai.Pathfinding.canMove = false;
              this.Senpai.Routine = false;
              this.Senpai.Spawned = true;
            }
            this.Speaker[1] = this.Senpai;
          }
          bool flag2 = false;
          if ((this.Teleport || this.LunchTime || this.Rival.Leaving || (UnityEngine.Object) this.Rival.CurrentDestination == (UnityEngine.Object) this.StudentManager.Exit) && !this.Rival.Ragdoll.Zs.activeInHierarchy)
            flag2 = true;
          if (flag2 && !this.Rival.InEvent)
          {
            this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
            this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
            this.Rival.Pathfinding.target = this.Location[2];
            this.Rival.CurrentDestination = this.Location[2];
            this.Rival.Pathfinding.canSearch = true;
            this.Rival.Pathfinding.canMove = true;
            this.Rival.InEvent = true;
            this.Rival.DistanceToDestination = 100f;
            this.Spy.gameObject.SetActive(true);
            this.Spy.Prompt.enabled = true;
            if (this.Teleport)
            {
              this.Rival.transform.eulerAngles = this.Location[2].eulerAngles;
              this.Rival.transform.position = this.Location[2].position;
              this.Rival.CharacterAnimation.Play(this.Rival.IdleAnim);
              this.Rival.Pathfinding.canSearch = false;
              this.Rival.Pathfinding.canMove = false;
              this.Rival.Routine = false;
              this.Rival.Spawned = true;
              this.Rival.Private = true;
              this.Rival.Prompt.Hide();
              this.Rival.Prompt.enabled = false;
              if (this.Rival.Investigating)
                this.Rival.StopInvestigating();
            }
            this.Speaker[2] = this.Rival;
          }
          if ((UnityEngine.Object) this.Senpai.CurrentDestination == (UnityEngine.Object) this.Location[1] && (double) this.Senpai.DistanceToDestination < 0.5)
          {
            if (!this.Impatient)
            {
              this.Senpai.CharacterAnimation.CrossFade("waiting_00");
              this.Senpai.Pathfinding.canSearch = false;
              this.Senpai.Pathfinding.canMove = false;
              if ((double) this.Clock.HourTime > 17.9166660308838)
              {
                this.Senpai.CharacterAnimation.CrossFade("impatience_00");
                this.EventSubtitle.text = "I understand being a few minutes late, but this is just too much...";
                this.Impatient = true;
              }
            }
            else if ((double) this.Senpai.CharacterAnimation["impatience_00"].time >= (double) this.Senpai.CharacterAnimation["impatience_00"].length)
            {
              ++this.StudentManager.SabotageProgress;
              Debug.Log((object) ("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5"));
              ++this.Phase;
              this.EndEvent();
            }
          }
          if ((UnityEngine.Object) this.Rival.CurrentDestination == (UnityEngine.Object) this.Location[2] && (double) this.Rival.DistanceToDestination < 0.5)
          {
            this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
            this.Rival.Pathfinding.canSearch = false;
            this.Rival.Pathfinding.canMove = false;
          }
          if (!((UnityEngine.Object) this.Senpai.CurrentDestination == (UnityEngine.Object) this.Location[1]) || !((UnityEngine.Object) this.Rival.CurrentDestination == (UnityEngine.Object) this.Location[2]) || (double) this.Senpai.DistanceToDestination >= 0.5 || (double) this.Rival.DistanceToDestination >= 0.5 || this.Impatient)
            return;
          Debug.Log((object) (this.gameObject.name + " has begun."));
          this.StartPeriod = this.Clock.Period;
          ++this.Phase;
        }
        else
          this.enabled = false;
      }
    }
    else if (this.Phase == 1)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      this.Timer = 0.0f;
      ++this.Phase;
    }
    else
    {
      this.Timer += Time.deltaTime;
      if (this.SpeechPhase < this.EndPhase)
      {
        if ((double) this.Timer > (double) this.SpeechTime[this.SpeechPhase])
        {
          if ((UnityEngine.Object) this.Senpai == (UnityEngine.Object) null)
          {
            this.Senpai = this.StudentManager.Students[1];
            if ((UnityEngine.Object) this.StudentManager.Students[this.StudentManager.RivalID] != (UnityEngine.Object) null)
              this.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
            else
              this.enabled = false;
          }
          this.Senpai.CharacterAnimation.CrossFade(this.Senpai.IdleAnim);
          this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
          if ((double) Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position) < 11.0)
            this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
          if ((UnityEngine.Object) this.Speaker[1] == (UnityEngine.Object) null)
          {
            this.Senpai = this.StudentManager.Students[1];
            this.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
            this.Senpai.InEvent = false;
            this.Rival.InEvent = false;
            this.Phase = 0;
          }
          else
          {
            this.Speaker[this.SpeakerID[this.SpeechPhase]].CharacterAnimation.CrossFade(this.Speaker[this.SpeakerID[this.SpeechPhase]].AnimationNames[2]);
            ++this.SpeechPhase;
          }
        }
      }
      else
      {
        if (this.Sabotaged)
        {
          ++this.StudentManager.SabotageProgress;
          Debug.Log((object) ("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5"));
        }
        this.NaturalEnd = true;
        this.EndEvent();
        Debug.Log((object) "The event ended naturally.");
      }
      if (this.Clock.Period > this.StartPeriod || !this.Rival.Alive)
      {
        if (!this.Rival.Alive)
          this.ForcedEnding = true;
        this.EndEvent();
      }
      if (this.Senpai.Alarmed || this.Rival.Alarmed)
      {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Rival.transform.position + Vector3.up, Quaternion.identity);
        gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
        gameObject.transform.localScale = new Vector3(150f, 1f, 150f);
        gameObject.GetComponent<AlarmDiscScript>().FocusOnYandere = true;
        this.EndEvent();
        Debug.Log((object) "The event ended due to one of the characters becoming alarmed.");
      }
      if (!this.Yandere.NoDebug && Input.GetKeyDown(KeyCode.LeftControl))
      {
        this.NaturalEnd = true;
        this.EndEvent();
        Debug.Log((object) "The event ended due to a debug command.");
      }
      this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position);
      if ((double) this.Distance - 4.0 < 15.0)
      {
        this.Scale = Mathf.Abs((float) (1.0 - ((double) this.Distance - 4.0) / 15.0));
        if ((double) this.Scale < 0.0)
          this.Scale = 0.0f;
        if ((double) this.Scale > 1.0)
          this.Scale = 1f;
        this.Jukebox.Dip = (float) (1.0 - 0.5 * (double) this.Scale);
        this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
        this.Yandere.Eavesdropping = (double) this.Distance < 3.0;
      }
      else
      {
        if ((double) this.Distance - 4.0 >= 16.0)
          return;
        this.EventSubtitle.transform.localScale = Vector3.zero;
      }
    }
  }

  public void EndEvent()
  {
    Debug.Log((object) (this.gameObject.name + " has ended."));
    if ((UnityEngine.Object) this.Journalist != (UnityEngine.Object) null)
      this.Journalist.RivalEvent = (GenericRivalEventScript) null;
    if (this.Phase > 0 && this.Rival.Alive || this.StudentManager.Reputation.Portal.Transition || this.ForcedEnding)
    {
      if (!this.Senpai.Alarmed)
      {
        this.Senpai.Pathfinding.canSearch = true;
        this.Senpai.Pathfinding.canMove = true;
        this.Senpai.Routine = true;
      }
      if (this.Senpai.Phase == 0)
        ++this.Senpai.Phase;
      this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      this.Senpai.CurrentDestination = this.Senpai.Destinations[this.Senpai.Phase];
      this.Senpai.Pathfinding.target = this.Senpai.Destinations[this.Senpai.Phase];
      this.Senpai.DistanceToDestination = 100f;
      this.Senpai.Pathfinding.speed = 1f;
      this.Senpai.InEvent = false;
      this.Senpai.Private = false;
      this.Senpai.Hurry = false;
      if (!this.Rival.Sedated && this.Rival.Alive)
      {
        if (!this.Rival.Alarmed)
        {
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.Routine = true;
        }
        if (this.Rival.Phase == 0)
          ++this.Rival.Phase;
        this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
        this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
        this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
        this.Rival.DistanceToDestination = 100f;
        this.Rival.Pathfinding.speed = 1f;
        this.Rival.Prompt.enabled = true;
        this.Rival.InEvent = false;
        this.Rival.Private = false;
        this.Rival.Hurry = false;
      }
      if (!this.StudentManager.Stop)
        this.StudentManager.UpdateStudents();
      this.Spy.Prompt.Hide();
      this.Spy.Prompt.enabled = false;
      if (this.Spy.Phase > 0)
        this.Spy.End();
      this.EventSubtitle.text = string.Empty;
      this.Yandere.Eavesdropping = false;
      this.Jukebox.Dip = 1f;
      this.enabled = false;
      if (this.Sabotaged)
        this.Rival.WalkAnim = this.Rival.BulliedWalkAnim;
    }
    if (!this.Teleport || !this.NaturalEnd)
      return;
    switch (DateGlobals.Weekday)
    {
      case DayOfWeek.Monday:
        this.Senpai.ExtraBento = true;
        break;
      case DayOfWeek.Tuesday:
        this.StudentManager.RivalBookBag.BorrowedBook = true;
        ScheduleBlock scheduleBlock1 = this.Rival.ScheduleBlocks[4];
        scheduleBlock1.destination = "LunchSpot";
        scheduleBlock1.action = "Read";
        this.Rival.GetDestinations();
        break;
      case DayOfWeek.Wednesday:
        this.Rival.GiftBox = true;
        break;
      case DayOfWeek.Thursday:
        Debug.Log((object) "Thursday-specific ''Rival going to sleep'' code just fired.");
        ScheduleBlock scheduleBlock2 = this.Rival.ScheduleBlocks[6];
        scheduleBlock2.destination = "SleepSpot";
        scheduleBlock2.action = "Sleep";
        if (this.Rival.Sedated && this.Rival.StudentID != 15 && this.Rival.ScheduleBlocks.Length == 10)
        {
          ScheduleBlock scheduleBlock3 = this.Rival.ScheduleBlocks[7];
          scheduleBlock3.destination = "SleepSpot";
          scheduleBlock3.action = "Sleep";
          ScheduleBlock scheduleBlock4 = this.Rival.ScheduleBlocks[8];
          scheduleBlock4.destination = "SleepSpot";
          scheduleBlock4.action = "Sleep";
          ScheduleBlock scheduleBlock5 = this.Rival.ScheduleBlocks[9];
          scheduleBlock5.destination = "SleepSpot";
          scheduleBlock5.action = "Sleep";
        }
        this.Rival.GetDestinations();
        break;
      case DayOfWeek.Friday:
        this.Rival.VisitSenpaiDesk = true;
        break;
    }
  }

  public void Sabotage()
  {
    Debug.Log((object) "A Senpai-Rival interaction event has just been sabotaged.");
    this.SpeechText = this.SabobtagedSpeechText;
    this.SpeechTime = this.SabobtagedSpeechTime;
    this.SpeakerID = this.SabotagedSpeakerID;
    this.Sabotaged = true;
    this.EndPhase = 12;
    if (this.EventDay != DayOfWeek.Friday)
      return;
    this.SabotagedSpeakerID[10] = 2;
  }
}
