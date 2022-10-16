// Decompiled with JetBrains decompiler
// Type: TalkingScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TalkingScript : MonoBehaviour
{
  private const float LongestTime = 100f;
  private const float LongTime = 5f;
  private const float MediumTime = 3f;
  private const float ShortTime = 2f;
  public StudentScript S;
  public WeaponScript StuckBoxCutter;
  public bool NegativeResponse;
  public bool FadeIn;
  public bool Follow;
  public bool Grudge;
  public bool Refuse;
  public bool Fake;
  public string IdleAnim = "";
  public float Timer;
  public int ClubBonus;

  private void Update()
  {
    if (!this.S.Talking)
      return;
    this.S.BoobsResized = false;
    this.ClubBonus = !this.S.Sleuthing || this.S.Club != ClubType.Photography ? 0 : 5;
    if (this.S.StudentManager.EmptyDemon)
      this.ClubBonus = (int) this.S.Club * -1;
    if (this.S.Interaction == StudentInteractionType.Idle)
    {
      if (!this.Fake)
      {
        if ((Object) this.S.Yandere.TargetStudent != (Object) null && this.S.StudentID == 10 && (Object) this.S.FollowTarget != (Object) null && this.S.FollowTarget.Routine && !this.S.FollowTarget.Distracted)
        {
          this.S.FollowTarget.Pathfinding.canSearch = false;
          this.S.FollowTarget.Pathfinding.canMove = false;
          this.S.FollowTarget.FocusOnYandere = true;
          this.S.FollowTarget.Routine = false;
        }
        this.IdleAnim = !this.S.Sleuthing ? (this.S.Club != ClubType.Art || !this.S.DialogueWheel.ClubLeader || !this.S.Paintbrush.activeInHierarchy || this.S.StudentManager.Eighties ? (this.S.Club == ClubType.Bully ? ((double) this.S.StudentManager.Reputation.Reputation < 33.333328247070313 || this.S.Persona == PersonaType.Coward ? (this.S.CurrentAction != StudentActionType.Sunbathe || this.S.SunbathePhase <= 2 ? this.S.IdleAnim : this.S.OriginalIdleAnim) : this.S.CuteAnim) : this.S.IdleAnim) : "paintingIdle_00") : this.S.SleuthCalmAnim;
        this.S.CharacterAnimation.CrossFade(this.IdleAnim);
      }
      else if (this.IdleAnim != "")
        this.S.CharacterAnimation.CrossFade(this.IdleAnim);
      if ((double) this.S.TalkTimer == 0.0)
      {
        if (!this.S.DialogueWheel.AppearanceWindow.Show && !this.S.StudentManager.TutorialActive)
          this.S.DialogueWheel.Impatience.fillAmount += Time.deltaTime * 0.1f;
        if ((double) this.S.DialogueWheel.Impatience.fillAmount > 0.5 && !this.S.StudentManager.Police.FadeOut && !this.S.StudentManager.Police.Show && (double) this.S.Subtitle.Timer == 0.0)
        {
          if (this.S.StudentID == 41 && !this.S.StudentManager.Eighties)
            this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 4, 5f);
          else if (this.S.Pestered == 0)
            this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 0, 5f);
          else
            this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 2, 5f);
        }
        if ((double) this.S.DialogueWheel.Impatience.fillAmount == 1.0 && this.S.DialogueWheel.Show)
        {
          if (this.S.StudentID == 41 && !this.S.StudentManager.Eighties)
            this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 4, 5f);
          else if (this.S.Club == ClubType.Delinquent)
            this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 3, 5f);
          else if (this.S.Pestered == 0)
            this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 1, 5f);
          else
            this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 3, 5f);
          this.S.WaitTimer = 0.0f;
          this.S.Pestered += 5;
          this.S.DialogueWheel.Pestered = true;
          this.S.DialogueWheel.End();
        }
      }
    }
    else if (this.S.Interaction == StudentInteractionType.Forgiving)
    {
      if ((double) this.S.TalkTimer == 3.0)
      {
        if (this.S.Club != ClubType.Delinquent)
        {
          this.S.CharacterAnimation.CrossFade(this.S.Nod2Anim);
          this.S.RepRecovery = 5f;
          if (PlayerGlobals.PantiesEquipped == 6)
            this.S.RepRecovery += 2.5f;
          if (this.S.Yandere.Class.SocialBonus > 0)
            this.S.RepRecovery += 2.5f;
          this.S.PendingRep += this.S.RepRecovery;
          this.S.Reputation.PendingRep += this.S.RepRecovery;
          Debug.Log((object) "Time to change this student's outlines!");
          for (int index = 0; index < this.S.Outlines.Length; ++index)
          {
            if ((Object) this.S.Outlines[index] != (Object) null)
            {
              if (!this.S.Rival)
              {
                Debug.Log((object) "They're not a rival, so they should be green!");
                this.S.Outlines[index].color = new Color(0.0f, 1f, 0.0f);
              }
              else
              {
                Debug.Log((object) "She's a rival! She's going back to being red!");
                this.S.Outlines[index].color = new Color(1f, 0.0f, 0.0f);
              }
              this.S.Outlines[index].enabled = true;
            }
          }
          this.S.Forgave = true;
          if (this.S.Witnessed == StudentWitnessType.Insanity || this.S.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity || this.S.Witnessed == StudentWitnessType.WeaponAndInsanity || this.S.Witnessed == StudentWitnessType.BloodAndInsanity)
            this.S.Subtitle.UpdateLabel(SubtitleType.ForgivingInsanity, 0, 3f);
          else if (this.S.Witnessed == StudentWitnessType.Accident)
            this.S.Subtitle.UpdateLabel(SubtitleType.ForgivingAccident, 0, 5f);
          else
            this.S.Subtitle.UpdateLabel(SubtitleType.Forgiving, 0, 3f);
        }
        else
          this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 0, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.CharacterAnimation[this.S.Nod2Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod2Anim].length)
          this.S.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.S.TalkTimer <= 0.0)
        {
          this.S.IgnoreTimer = 5f;
          this.S.DialogueWheel.End();
        }
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.ReceivingCompliment)
    {
      if ((double) this.S.TalkTimer == 3.0)
      {
        if (!ConversationGlobals.GetTopicDiscovered(20))
        {
          this.S.Yandere.NotificationManager.TopicName = "Socializing";
          this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
          ConversationGlobals.SetTopicDiscovered(20, true);
        }
        if (!this.S.StudentManager.GetTopicLearnedByStudent(20, this.S.StudentID))
        {
          this.S.Yandere.NotificationManager.TopicName = "Socializing";
          this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
          this.S.StudentManager.SetTopicLearnedByStudent(20, this.S.StudentID, true);
        }
        if (this.S.Club != ClubType.Delinquent)
        {
          this.S.CharacterAnimation.CrossFade(this.S.LookDownAnim);
          this.CalculateRepBonus();
          int topicSelected = this.S.StudentManager.DialogueWheel.TopicInterface.TopicSelected;
          if (!this.S.StudentManager.GetTopicLearnedByStudent(topicSelected, this.S.StudentID))
          {
            this.S.Yandere.NotificationManager.TopicName = this.S.StudentManager.InterestManager.TopicNames[topicSelected];
            this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
            this.S.StudentManager.SetTopicLearnedByStudent(topicSelected, this.S.StudentID, true);
          }
          if (this.S.DialogueWheel.TopicInterface.Success)
          {
            this.S.Subtitle.PersonaSubtitle.UpdateLabel(PersonaType.Nemesis, this.S.Reputation.Reputation, 5f);
            this.S.Reputation.PendingRep += 1f + (float) this.S.RepBonus;
            this.S.PendingRep += 1f + (float) this.S.RepBonus;
          }
          else
          {
            this.S.Subtitle.PersonaSubtitle.UpdateLabel(PersonaType.None, this.S.Reputation.Reputation, 5f);
            --this.S.Reputation.PendingRep;
            --this.S.PendingRep;
          }
        }
        else
          this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 1, 3f);
        this.S.Complimented = true;
      }
      else if (Input.GetButtonDown("A"))
        this.S.TalkTimer = 0.0f;
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
        this.S.DialogueWheel.End();
    }
    else if (this.S.Interaction == StudentInteractionType.Gossiping)
    {
      if ((double) this.S.TalkTimer == 3.0)
      {
        if (this.S.Club != ClubType.Delinquent)
        {
          this.S.Gossiped = true;
          if (this.S.DialogueWheel.TopicInterface.Success)
          {
            this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
            this.S.Subtitle.CustomText = "Ugh, I can't get along with people like that...";
            this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
            this.S.GossipBonus = 0;
            if (PlayerGlobals.PantiesEquipped == 9)
              ++this.S.GossipBonus;
            if (this.S.Yandere.Class.SocialBonus > 0)
              ++this.S.GossipBonus;
            if (this.S.Friend)
              ++this.S.GossipBonus;
            if (this.S.StudentManager.EmbarassingSecret && this.S.DialogueWheel.Victim == this.S.StudentManager.RivalID)
              ++this.S.GossipBonus;
            if (this.S.Male && this.S.Yandere.Class.Seduction + this.S.Yandere.Class.SeductionBonus > 0 || this.S.Yandere.Class.Seduction == 5)
              ++this.S.GossipBonus;
            if ((double) this.S.Reputation.Reputation > 33.333328247070313)
              ++this.S.GossipBonus;
            if (this.S.Club == ClubType.Bully)
              ++this.S.GossipBonus;
            this.S.GossipBonus += this.S.Yandere.Class.PsychologyGrade + this.S.Yandere.Class.PsychologyBonus;
            this.S.StudentManager.StudentReps[this.S.DialogueWheel.Victim] -= (float) (1 + this.S.GossipBonus);
            if (this.S.Club != ClubType.Bully)
            {
              this.S.Reputation.PendingRep -= 2f;
              this.S.PendingRep -= 2f;
            }
            this.S.Gossiped = true;
            this.S.Yandere.NotificationManager.TopicName = "Gossip";
            if ((Object) this.S.StudentManager.Students[this.S.DialogueWheel.Victim] != (Object) null)
            {
              this.S.Yandere.NotificationManager.CustomText = this.S.StudentManager.Students[this.S.DialogueWheel.Victim].Name + "'s rep is now " + this.S.StudentManager.StudentReps[this.S.DialogueWheel.Victim].ToString();
              this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
          }
          else
          {
            this.S.Subtitle.PersonaSubtitle.UpdateLabel(PersonaType.None, this.S.Reputation.Reputation, 5f);
            --this.S.Reputation.PendingRep;
            --this.S.PendingRep;
          }
          int topicSelected = this.S.StudentManager.DialogueWheel.TopicInterface.TopicSelected;
          if (!this.S.StudentManager.GetTopicLearnedByStudent(topicSelected, this.S.StudentID))
          {
            this.S.Yandere.NotificationManager.TopicName = this.S.StudentManager.InterestManager.TopicNames[topicSelected];
            this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
            this.S.StudentManager.SetTopicLearnedByStudent(topicSelected, this.S.StudentID, true);
          }
          if (!this.S.StudentManager.GetTopicLearnedByStudent(19, this.S.StudentID))
          {
            this.S.Yandere.NotificationManager.TopicName = "Gossip";
            this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
            this.S.StudentManager.SetTopicLearnedByStudent(19, this.S.StudentID, true);
          }
        }
        else
          this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 2, 3f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.CharacterAnimation[this.S.GossipAnim].time >= (double) this.S.CharacterAnimation[this.S.GossipAnim].length)
          this.S.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.S.TalkTimer <= 0.0)
          this.S.DialogueWheel.End();
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.Bye)
    {
      if ((double) this.S.TalkTimer == 2.0)
      {
        if (this.S.Club != ClubType.Delinquent)
          this.S.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 2f);
        else
          this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 3, 3f);
      }
      else if (Input.GetButtonDown("A"))
        this.S.TalkTimer = 0.0f;
      this.S.CharacterAnimation.CrossFade(this.IdleAnim);
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        this.S.Pestered += 2;
        this.S.DialogueWheel.End();
      }
    }
    else if (this.S.Interaction == StudentInteractionType.GivingTask)
    {
      if ((double) this.S.TalkTimer == 100.0)
      {
        bool flag1 = true;
        if (this.S.StudentID == 46)
        {
          int num = !((Object) this.S.StudentManager.Students[47] != (Object) null) ? 0 : (this.S.StudentManager.Students[47].Friend ? 1 : 0);
          bool flag2 = (Object) this.S.StudentManager.Students[48] != (Object) null && this.S.StudentManager.Students[48].Friend;
          bool flag3 = (Object) this.S.StudentManager.Students[49] != (Object) null && this.S.StudentManager.Students[49].Friend;
          bool flag4 = (Object) this.S.StudentManager.Students[50] != (Object) null && this.S.StudentManager.Students[50].Friend;
          if (num == 0 || !flag2 || !flag3 || !flag4)
            flag1 = false;
        }
        if (flag1)
        {
          this.S.Subtitle.UpdateLabel(this.S.TaskLineResponseType, this.S.TaskPhase, this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase));
          this.S.CharacterAnimation.CrossFade(this.S.TaskAnims[this.S.TaskPhase]);
          this.S.CurrentAnim = this.S.TaskAnims[this.S.TaskPhase];
          this.S.TalkTimer = this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase);
        }
        else
        {
          this.S.TaskPhase = 999;
          this.S.Subtitle.CustomText = "I'm sorry, it's a little difficult for me to confide in a complete stranger. If you befriend all of my clubmembers, I'd be able to trust you.";
          this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 10f);
          this.S.Subtitle.Timer = 0.0f;
          this.S.CharacterAnimation.CrossFade(this.S.TaskAnims[1]);
          this.S.CurrentAnim = this.S.TaskAnims[1];
          this.S.TalkTimer = 10f;
        }
      }
      else if (Input.GetButtonDown("A"))
      {
        this.S.Subtitle.Label.text = string.Empty;
        Object.Destroy((Object) this.S.Subtitle.CurrentClip);
        this.S.TalkTimer = 0.0f;
      }
      if (this.S.CurrentAnim != "" && (double) this.S.CharacterAnimation[this.S.CurrentAnim].time >= (double) this.S.CharacterAnimation[this.S.CurrentAnim].length)
        this.S.CharacterAnimation.CrossFade(this.IdleAnim);
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        if (this.S.TaskPhase == 5)
        {
          if (!ConversationGlobals.GetTopicDiscovered(21))
          {
            this.S.Yandere.NotificationManager.TopicName = "Solitude";
            this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
            ConversationGlobals.SetTopicDiscovered(21, true);
          }
          if (!this.S.StudentManager.GetTopicLearnedByStudent(21, this.S.StudentID))
          {
            this.S.Yandere.NotificationManager.TopicName = "Solitude";
            this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
            this.S.StudentManager.SetTopicLearnedByStudent(21, this.S.StudentID, true);
          }
          this.S.DialogueWheel.TaskWindow.TaskComplete = true;
          this.S.StudentManager.TaskManager.TaskStatus[this.S.StudentID] = 3;
          ++this.S.Police.EndOfDay.NewFriends;
          this.S.Interaction = StudentInteractionType.Idle;
          this.S.Friend = true;
          if (this.S.Club != ClubType.Delinquent)
          {
            this.CalculateRepBonus();
            this.S.Reputation.PendingRep += 1f + (float) this.S.RepBonus;
            this.S.PendingRep += 1f + (float) this.S.RepBonus;
          }
          else
            this.S.StudentManager.DelinquentVoices.SetActive(false);
          if (SchemeGlobals.GetSchemeStage(6) == 3)
          {
            SchemeGlobals.SetSchemeStage(6, 4);
            this.S.Yandere.PauseScreen.Schemes.UpdateInstructions();
          }
        }
        else if (this.S.TaskPhase == 4 || this.S.TaskPhase == 0)
        {
          this.S.StudentManager.TaskManager.UpdateTaskStatus();
          this.S.DialogueWheel.End();
        }
        else if (this.S.TaskPhase == 3)
        {
          this.S.DialogueWheel.TaskWindow.UpdateWindow(this.S.StudentID);
          this.S.Subtitle.Label.text = "";
          this.S.Interaction = StudentInteractionType.Idle;
        }
        else if (this.S.TaskPhase == 999)
        {
          this.S.TaskPhase = 0;
          this.S.Interaction = StudentInteractionType.Idle;
          this.S.DialogueWheel.End();
        }
        else
        {
          ++this.S.TaskPhase;
          this.S.Subtitle.UpdateLabel(this.S.TaskLineResponseType, this.S.TaskPhase, this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase));
          this.S.Subtitle.Timer = 0.0f;
          this.S.CharacterAnimation.CrossFade(this.S.TaskAnims[this.S.TaskPhase]);
          this.S.CurrentAnim = this.S.TaskAnims[this.S.TaskPhase];
          this.S.TalkTimer = this.S.Subtitle.GetClipLength(this.S.StudentID, this.S.TaskPhase);
        }
      }
    }
    else if (this.S.Interaction == StudentInteractionType.FollowingPlayer)
    {
      if ((double) this.S.TalkTimer == 2.0)
      {
        if (this.S.Club != ClubType.Delinquent)
        {
          bool flag5 = false;
          bool flag6 = false;
          bool flag7 = false;
          if (this.S.StudentID == this.S.StudentManager.RivalID)
          {
            if ((Object) this.S.Follower != (Object) null && this.S.Follower.CurrentAction == StudentActionType.Follow && !this.S.Follower.Distracting && !this.S.Follower.GoAway && !this.S.Follower.EatingSnack)
              flag5 = true;
            else if ((double) this.S.Reputation.Reputation < (double) (DateGlobals.Week * 10))
            {
              this.S.Yandere.NotificationManager.CustomText = "You need at least " + (DateGlobals.Week * 10).ToString() + " Reputation Points";
              this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
              flag7 = true;
            }
            else if (this.S.CurrentAction == StudentActionType.SitAndEatBento)
              flag6 = true;
          }
          if ((double) this.S.Clock.HourTime > 8.0 && (double) this.S.Clock.HourTime < 13.0 || (double) this.S.Clock.HourTime > 13.375 && (double) this.S.Clock.HourTime < 15.5 || this.S.StudentID == this.S.StudentManager.RivalID & flag5 || this.S.StudentID == this.S.StudentManager.RivalID & flag7 || this.S.StudentID == this.S.StudentManager.RivalID & flag6 || (double) SchoolGlobals.SchoolAtmosphere <= 0.5 || this.S.Schoolwear == 2)
          {
            this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
            this.NegativeResponse = true;
            if (this.S.StudentID == this.S.StudentManager.RivalID)
            {
              if (this.S.Yandere.Club == ClubType.Delinquent)
              {
                this.S.Subtitle.CustomText = "Are you trying to intimidate me? Well, it won't work! Go away!";
                this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                this.S.TalkTimer = 5f;
              }
              else if (flag5)
              {
                this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 2, 5f);
                this.S.TalkTimer = 5f;
              }
              else if (flag7)
              {
                this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 3, 13f);
                this.S.TalkTimer = 13f;
              }
              else if (flag6)
              {
                this.S.Subtitle.CustomText = "Now? I'm busy eating...can you show me later, instead?";
                this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                this.S.TalkTimer = 5f;
              }
              else if ((double) SchoolGlobals.SchoolAtmosphere <= 0.5)
              {
                this.S.Subtitle.CustomText = "I wouldn't be comfortable with that...the school doesn't feel safe right now.";
                this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                this.S.TalkTimer = 5f;
              }
            }
            else if (this.S.Schoolwear == 2)
            {
              this.S.Subtitle.CustomText = "Uh...I'm wearing a swimsuit right now. I can't really do that for you. Maybe later...?";
              this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 7.5f);
              this.S.TalkTimer = 7.5f;
              this.Refuse = true;
            }
            else if ((double) SchoolGlobals.SchoolAtmosphere <= 0.5)
            {
              this.S.Subtitle.CustomText = "I wouldn't be comfortable with that...the school doesn't feel safe right now.";
              this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 7.5f);
              this.S.TalkTimer = 5f;
            }
            else
              this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 0, 5f);
          }
          else if (this.S.StudentManager.LockerRoomArea.bounds.Contains(this.S.Yandere.transform.position) || this.S.StudentManager.WestBathroomArea.bounds.Contains(this.S.Yandere.transform.position) || this.S.StudentManager.EastBathroomArea.bounds.Contains(this.S.Yandere.transform.position) || this.S.StudentManager.HeadmasterArea.bounds.Contains(this.S.Yandere.transform.position) || (Object) this.S.MyRenderer.sharedMesh == (Object) this.S.SchoolSwimsuit || (Object) this.S.MyRenderer.sharedMesh == (Object) this.S.SwimmingTrunks || this.S.Traumatized)
          {
            this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
            this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 1, 5f);
            this.NegativeResponse = true;
          }
          else
          {
            int ID = 0;
            if (this.S.Yandere.Club == ClubType.Delinquent)
            {
              this.S.Reputation.PendingRep -= 10f;
              this.S.PendingRep -= 10f;
              ++ID;
            }
            this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
            this.S.Subtitle.UpdateLabel(SubtitleType.StudentFollow, ID, 2f);
            this.Follow = true;
          }
        }
        else
          this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 4, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.CharacterAnimation[this.S.Nod1Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod1Anim].length)
          this.S.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.S.TalkTimer <= 0.0)
        {
          this.S.DialogueWheel.End();
          if (this.Follow)
          {
            this.S.Pathfinding.target = this.S.Yandere.transform;
            this.S.Prompt.Label[0].text = "     Stop";
            if (this.S.StudentID == 30)
            {
              this.S.StudentManager.FollowerLookAtTarget.position = this.S.DefaultTarget.position;
              this.S.StudentManager.LoveManager.Follower = this.S;
            }
            this.S.FollowCountdown.Sprite.fillAmount = 1f;
            this.S.FollowCountdown.Speed = this.S.Yandere.Club == ClubType.Delinquent ? (float) (1.0 / (35.0 + (double) this.S.Reputation.Reputation * -0.25)) : (float) (1.0 / (35.0 + (double) this.S.Reputation.Reputation * 0.25));
            this.S.FollowCountdown.gameObject.SetActive(true);
            this.S.Yandere.Follower = this.S;
            ++this.S.Yandere.Followers;
            this.S.Following = true;
            this.S.Hurry = false;
            this.S.StudentManager.InterestManager.FollowerID = this.S.StudentID;
            this.S.StudentManager.InterestManager.UpdateIgnore();
          }
          this.Follow = false;
        }
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.GoingAway)
    {
      if ((double) this.S.TalkTimer == 3.0)
      {
        if (this.S.Club != ClubType.Delinquent)
        {
          if ((double) this.S.Clock.HourTime > 8.0 && (double) this.S.Clock.HourTime < 13.0 || (double) this.S.Clock.HourTime > 13.375 && (double) this.S.Clock.HourTime < 15.5 || (double) SchoolGlobals.SchoolAtmosphere <= 0.5 || this.S.Schoolwear == 2)
          {
            if (this.S.Schoolwear == 2)
            {
              this.S.Subtitle.CustomText = "Uh...I'm wearing a swimsuit right now. I can't really do that for you. Maybe later...?";
              this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 7.5f);
              this.S.TalkTimer = 7.5f;
              this.Refuse = true;
            }
            else if ((double) SchoolGlobals.SchoolAtmosphere <= 0.5)
            {
              this.S.Subtitle.CustomText = "I'm sorry, I wouldn't be comfortable with that...I'm not even sure if we're safe right now.";
              this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 7.5f);
              this.S.TalkTimer = 7.5f;
            }
            else
            {
              this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
              this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 0, 5f);
            }
          }
          else
          {
            int ID = 0;
            if (this.S.Yandere.Club == ClubType.Delinquent)
            {
              this.S.Reputation.PendingRep -= 10f;
              this.S.PendingRep -= 10f;
              ++ID;
            }
            this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
            this.S.Subtitle.UpdateLabel(SubtitleType.StudentLeave, ID, 3f);
            this.S.GoAway = true;
          }
        }
        else
          this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 5, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.CharacterAnimation[this.S.Nod1Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod1Anim].length)
          this.S.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.S.TalkTimer <= 0.0)
          this.S.DialogueWheel.End();
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.DistractingTarget)
    {
      if ((double) this.S.TalkTimer == 3.0)
      {
        if (this.S.Club != ClubType.Delinquent)
        {
          if ((double) this.S.Clock.HourTime > 8.0 && (double) this.S.Clock.HourTime < 13.0 || (double) this.S.Clock.HourTime > 13.375 && (double) this.S.Clock.HourTime < 15.5 || (double) SchoolGlobals.SchoolAtmosphere <= 0.5 || this.S.Schoolwear == 2)
          {
            if (this.S.Schoolwear == 2)
            {
              this.S.Subtitle.CustomText = "Uh...I'm wearing a swimsuit right now. I can't really do that for you. Maybe later...?";
              this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 7.5f);
              this.S.TalkTimer = 7.5f;
              this.Refuse = true;
            }
            else if ((double) SchoolGlobals.SchoolAtmosphere <= 0.5)
            {
              this.S.Subtitle.CustomText = "I'm sorry, I wouldn't be comfortable with that...I'm not even sure if we're safe right now.";
              this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 7.5f);
              this.S.TalkTimer = 7.5f;
              this.Refuse = true;
            }
            else
            {
              this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
              this.S.Subtitle.UpdateLabel(SubtitleType.StudentStay, 0, 5f);
            }
          }
          else
          {
            StudentScript student = this.S.StudentManager.Students[this.S.DialogueWheel.Victim];
            this.Grudge = false;
            if (student.Club == ClubType.Delinquent || this.S.Bullied && student.Club == ClubType.Bully || student.StudentID == 36 && this.S.StudentManager.TaskManager.TaskStatus[36] < 3)
              this.Grudge = true;
            if (student.Routine && !student.TargetedForDistraction && !student.InEvent && !this.Grudge && student.Indoors && student.gameObject.activeInHierarchy && student.ClubActivityPhase < 16 && student.CurrentAction != StudentActionType.Sunbathe)
            {
              int ID = 0;
              if (this.S.Yandere.Club == ClubType.Delinquent)
              {
                this.S.Reputation.PendingRep -= 10f;
                this.S.PendingRep -= 10f;
                ++ID;
              }
              this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
              this.S.Subtitle.UpdateLabel(SubtitleType.StudentDistract, ID, 3f);
              this.Refuse = false;
            }
            else
            {
              this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
              if (this.Grudge)
                this.S.Subtitle.UpdateLabel(SubtitleType.StudentDistractBullyRefuse, 0, 3f);
              else
                this.S.Subtitle.UpdateLabel(SubtitleType.StudentDistractRefuse, 0, 3f);
              this.Refuse = true;
            }
          }
        }
        else
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 6, 5f);
          this.Refuse = true;
        }
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.CharacterAnimation[this.S.Nod1Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod1Anim].length)
          this.S.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.S.TalkTimer <= 0.0)
        {
          this.S.DialogueWheel.End();
          if (!this.Refuse && ((double) this.S.Clock.HourTime < 8.0 || (double) this.S.Clock.HourTime > 13.0 && (double) this.S.Clock.HourTime < 13.375 || (double) this.S.Clock.HourTime > 15.5) && !this.S.Distracting)
          {
            this.S.DistractionTarget = this.S.StudentManager.Students[this.S.DialogueWheel.Victim];
            this.S.DistractionTarget.TargetedForDistraction = true;
            this.S.CurrentDestination = this.S.DistractionTarget.transform;
            this.S.Pathfinding.target = this.S.DistractionTarget.transform;
            this.S.Pathfinding.speed = 4f;
            this.S.TargetDistance = 1f;
            this.S.DistractTimer = 10f;
            this.S.Distracting = true;
            this.S.Routine = false;
            this.S.CanTalk = false;
          }
        }
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.PersonalGrudge)
    {
      if ((double) this.S.TalkTimer == 5.0)
      {
        if (this.S.Persona == PersonaType.Coward || this.S.Persona == PersonaType.Fragile)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.CowardGrudge, 0, 5f);
          this.S.CharacterAnimation.CrossFade(this.S.CowardAnim);
          this.S.TalkTimer = 5f;
        }
        else
        {
          if (!this.S.Male)
            this.S.Subtitle.UpdateLabel(SubtitleType.GrudgeWarning, 0, 99f);
          else if (this.S.Club == ClubType.Delinquent)
            this.S.Subtitle.UpdateLabel(SubtitleType.DelinquentGrudge, 1, 99f);
          else
            this.S.Subtitle.UpdateLabel(SubtitleType.GrudgeWarning, 1, 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
          this.S.CharacterAnimation.CrossFade(this.S.GrudgeAnim);
        }
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.TalkTimer <= 0.0)
          this.S.DialogueWheel.End();
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.ClubInfo)
    {
      if ((double) this.S.TalkTimer == 100.0)
      {
        this.S.Subtitle.UpdateLabel(this.S.ClubInfoResponseType, this.S.ClubPhase, 99f);
        this.S.TalkTimer = this.S.Subtitle.GetClubClipLength(this.S.Club, this.S.ClubPhase);
      }
      else if (Input.GetButtonDown("A"))
      {
        this.S.Subtitle.Label.text = string.Empty;
        Object.Destroy((Object) this.S.Subtitle.CurrentClip);
        this.S.TalkTimer = 0.0f;
      }
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        if (this.S.ClubPhase == 3)
        {
          this.S.DialogueWheel.Panel.enabled = true;
          this.S.DialogueWheel.Show = true;
          this.S.Subtitle.Label.text = string.Empty;
          this.S.Interaction = StudentInteractionType.Idle;
          this.S.TalkTimer = 0.0f;
        }
        else
        {
          ++this.S.ClubPhase;
          this.S.Subtitle.UpdateLabel(this.S.ClubInfoResponseType, this.S.ClubPhase, 99f);
          this.S.TalkTimer = this.S.Subtitle.GetClubClipLength(this.S.Club, this.S.ClubPhase);
        }
      }
    }
    else if (this.S.Interaction == StudentInteractionType.ClubJoin)
    {
      if ((double) this.S.TalkTimer == 100.0)
      {
        if (this.S.ClubPhase == 1)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubJoin, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 2)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubAccept, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 3)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubRefuse, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 4)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubRejoin, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 5)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubExclusive, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 6)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubGrudge, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
      }
      else if (Input.GetButtonDown("A"))
      {
        this.S.Subtitle.Label.text = string.Empty;
        Object.Destroy((Object) this.S.Subtitle.CurrentClip);
        this.S.TalkTimer = 0.0f;
      }
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        if (this.S.ClubPhase == 1)
        {
          this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
          this.S.DialogueWheel.ClubWindow.UpdateWindow();
          this.S.Subtitle.Label.text = string.Empty;
          this.S.Interaction = StudentInteractionType.Idle;
        }
        else
        {
          this.S.DialogueWheel.End();
          if (this.S.Club == ClubType.MartialArts)
            this.S.ChangingBooth.CheckYandereClub();
        }
      }
    }
    else if (this.S.Interaction == StudentInteractionType.ClubQuit)
    {
      if ((double) this.S.TalkTimer == 100.0)
      {
        if (this.S.ClubPhase == 1)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubQuit, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 2)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubConfirm, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 3)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubDeny, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
      }
      else if (Input.GetButtonDown("A"))
      {
        this.S.Subtitle.Label.text = string.Empty;
        Object.Destroy((Object) this.S.Subtitle.CurrentClip);
        this.S.TalkTimer = 0.0f;
      }
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        if (this.S.ClubPhase == 1)
        {
          this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
          this.S.DialogueWheel.ClubWindow.Quitting = true;
          this.S.DialogueWheel.ClubWindow.UpdateWindow();
          this.S.Subtitle.Label.text = string.Empty;
          this.S.Interaction = StudentInteractionType.Idle;
        }
        else
        {
          this.S.DialogueWheel.End();
          if (this.S.Club == ClubType.MartialArts)
            this.S.ChangingBooth.CheckYandereClub();
          if (this.S.ClubPhase != 2)
            ;
        }
      }
    }
    else if (this.S.Interaction == StudentInteractionType.ClubBye)
    {
      if ((double) this.S.TalkTimer == (double) this.S.Subtitle.ClubFarewellClips[(int) (this.S.Club + this.ClubBonus)].length)
        this.S.Subtitle.UpdateLabel(SubtitleType.ClubFarewell, (int) (this.S.Club + this.ClubBonus), this.S.Subtitle.ClubFarewellClips[(int) (this.S.Club + this.ClubBonus)].length);
      else if (Input.GetButtonDown("A"))
        this.S.TalkTimer = 0.0f;
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
        this.S.DialogueWheel.End();
    }
    else if (this.S.Interaction == StudentInteractionType.ClubActivity)
    {
      if ((double) this.S.TalkTimer == 100.0)
      {
        if (this.S.ClubPhase == 1)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubActivity, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 2)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubYes, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 3)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubNo, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 4)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubEarly, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 5)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubLate, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
      }
      else if (Input.GetButtonDown("A"))
      {
        this.S.Subtitle.Label.text = string.Empty;
        Object.Destroy((Object) this.S.Subtitle.CurrentClip);
        this.S.TalkTimer = 0.0f;
      }
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        if (this.S.ClubPhase == 1)
        {
          this.S.DialogueWheel.ClubWindow.Club = this.S.Club;
          this.S.DialogueWheel.ClubWindow.Activity = true;
          this.S.DialogueWheel.ClubWindow.UpdateWindow();
          this.S.Subtitle.Label.text = string.Empty;
          this.S.Interaction = StudentInteractionType.Idle;
        }
        else if (this.S.ClubPhase == 2)
        {
          this.S.Police.Darkness.enabled = true;
          this.S.Police.ClubActivity = true;
          this.S.Police.FadeOut = true;
          this.S.Subtitle.Label.text = string.Empty;
          this.S.Interaction = StudentInteractionType.Idle;
        }
        else
          this.S.DialogueWheel.End();
      }
    }
    else if (this.S.Interaction == StudentInteractionType.ClubUnwelcome)
    {
      this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
      if ((double) this.S.TalkTimer == 5.0)
      {
        this.S.Subtitle.UpdateLabel(SubtitleType.ClubUnwelcome, (int) (this.S.Club + this.ClubBonus), 99f);
        this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.TalkTimer <= 0.0)
          this.S.DialogueWheel.End();
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.ClubKick)
    {
      this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
      if ((double) this.S.TalkTimer == 5.0)
      {
        this.S.Subtitle.UpdateLabel(SubtitleType.ClubKick, (int) (this.S.Club + this.ClubBonus), 99f);
        this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.TalkTimer <= 0.0)
        {
          this.S.ClubManager.DeactivateClubBenefit();
          this.S.Yandere.Club = ClubType.None;
          this.S.DialogueWheel.End();
          this.S.Yandere.ClubAccessory();
        }
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.ClubGrudge)
    {
      this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
      if ((double) this.S.TalkTimer == 5.0)
      {
        if (this.S.ClubManager.ClubGrudge)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubGrudge, (int) (this.S.Club + this.ClubBonus), 99f);
        }
        else
        {
          this.S.Subtitle.CustomText = "You joined our club, and then you just...never showed up. I don't see a reason to let you join the club again...";
          this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 99f);
        }
        this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.TalkTimer <= 0.0)
          this.S.DialogueWheel.End();
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.ClubPractice)
    {
      if ((double) this.S.TalkTimer == 100.0)
      {
        if (this.S.ClubPhase == 1)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubPractice, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 2)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubPracticeYes, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
        else if (this.S.ClubPhase == 3)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.ClubPracticeNo, (int) (this.S.Club + this.ClubBonus), 99f);
          this.S.TalkTimer = this.S.Subtitle.CurrentClip.GetComponent<AudioSource>().clip.length;
        }
      }
      else if (Input.GetButtonDown("A"))
      {
        this.S.Subtitle.Label.text = string.Empty;
        Object.Destroy((Object) this.S.Subtitle.CurrentClip);
        this.S.TalkTimer = 0.0f;
      }
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        if (this.S.ClubPhase == 1)
        {
          this.S.DialogueWheel.PracticeWindow.Club = this.S.Club;
          this.S.DialogueWheel.PracticeWindow.UpdateWindow();
          this.S.DialogueWheel.PracticeWindow.Selected = 1;
          this.S.DialogueWheel.PracticeWindow.ID = 1;
          this.S.Subtitle.Label.text = string.Empty;
          this.S.Interaction = StudentInteractionType.Idle;
        }
        else if (this.S.ClubPhase == 2)
        {
          this.S.DialogueWheel.PracticeWindow.Club = this.S.Club;
          this.S.DialogueWheel.PracticeWindow.FadeOut = true;
          this.S.DialogueWheel.PracticeWindow.FadeIn = false;
          this.S.Subtitle.Label.text = string.Empty;
          this.S.Interaction = StudentInteractionType.Idle;
        }
        else if (this.S.ClubPhase == 3)
          this.S.DialogueWheel.End();
      }
    }
    else if (this.S.Interaction == StudentInteractionType.NamingCrush)
    {
      if ((double) this.S.TalkTimer == 3.0)
      {
        if (this.S.DialogueWheel.Victim != this.S.Crush)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 0, 3f);
          this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
          this.S.CurrentAnim = this.S.GossipAnim;
        }
        else
        {
          DatingGlobals.SuitorProgress = 1;
          ++this.S.Yandere.LoveManager.SuitorProgress;
          this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 1, 3f);
          this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
          this.S.CurrentAnim = this.S.Nod1Anim;
        }
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.CharacterAnimation[this.S.CurrentAnim].time >= (double) this.S.CharacterAnimation[this.S.CurrentAnim].length)
          this.S.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.S.TalkTimer <= 0.0)
          this.S.DialogueWheel.End();
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.ChangingAppearance)
    {
      if (!this.S.StudentManager.DialogueWheel.AppearanceWindow.Show)
      {
        if ((double) this.S.TalkTimer == 3.0)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 2, 3f);
          this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
        }
        else
        {
          if (Input.GetButtonDown("A"))
            this.S.TalkTimer = 0.0f;
          if ((double) this.S.CharacterAnimation[this.S.Nod1Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod1Anim].length)
            this.S.CharacterAnimation.CrossFade(this.IdleAnim);
          if ((double) this.S.TalkTimer <= 0.0)
          {
            Debug.Log((object) ("Apparently, " + this.name + "'s TalkTimer just reached 0."));
            this.S.DialogueWheel.End();
          }
        }
        this.S.TalkTimer -= Time.deltaTime;
      }
    }
    else if (this.S.Interaction == StudentInteractionType.Court)
    {
      if ((double) this.S.TalkTimer == 3.0)
      {
        if (this.S.Male)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 3, 5f);
          this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
        }
        else if (this.S.BikiniAttacher.enabled && !this.S.MyRenderer.enabled)
        {
          this.S.Subtitle.CustomText = "Bad timing. As you can see, I'm in a swimsuit right now. Maybe later.";
          this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 10f);
          this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
          this.Refuse = true;
        }
        else if (this.S.HelpOffered)
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 6, 5f);
          this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
          this.Refuse = true;
        }
        else
        {
          this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 4, 5f);
          this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
        }
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.CharacterAnimation[this.S.Nod1Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod1Anim].length)
          this.S.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.S.TalkTimer <= 0.0)
        {
          if (!this.Refuse)
          {
            this.S.MeetTime = this.S.Clock.HourTime - 1f;
            if (this.S.Male)
            {
              this.S.MeetSpot = this.S.StudentManager.SuitorSpot;
            }
            else
            {
              this.S.MeetSpot = this.S.StudentManager.RomanceSpot;
              this.S.StudentManager.LoveManager.RivalWaiting = true;
            }
            this.S.Hurry = true;
            this.S.Pathfinding.speed = 4f;
            this.S.MeetTime = this.S.Clock.HourTime;
          }
          this.S.DialogueWheel.End();
          this.Refuse = false;
        }
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.Advice)
    {
      if ((double) this.S.TalkTimer == 5.0)
      {
        this.S.Subtitle.UpdateLabel(SubtitleType.SuitorLove, 5, 99f);
        this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.CharacterAnimation[this.S.Nod1Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod1Anim].length)
          this.S.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.S.TalkTimer <= 0.0)
        {
          this.S.Rose = true;
          this.S.DialogueWheel.End();
        }
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.Feeding)
    {
      Debug.Log((object) "Feeding.");
      if ((double) this.S.TalkTimer == 10.0)
      {
        if (this.S.Club == ClubType.Delinquent)
        {
          this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
          this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 1, 3f);
        }
        else if (this.S.Fed || this.S.Club == ClubType.Council || this.S.StudentID == 22)
        {
          this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
          this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 0, 3f);
          this.S.Fed = true;
        }
        else
        {
          this.S.CharacterAnimation.CrossFade(this.S.Nod2Anim);
          this.S.Subtitle.UpdateLabel(SubtitleType.AcceptFood, 0, 3f);
          this.CalculateRepBonus();
          this.S.Reputation.PendingRep += 1f + (float) this.S.RepBonus;
          this.S.PendingRep += 1f + (float) this.S.RepBonus;
        }
      }
      else if (Input.GetButtonDown("A"))
        this.S.TalkTimer = 0.0f;
      if ((double) this.S.CharacterAnimation[this.S.Nod2Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod2Anim].length)
        this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
      if ((double) this.S.CharacterAnimation[this.S.GossipAnim].time >= (double) this.S.CharacterAnimation[this.S.GossipAnim].length)
        this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        if (!this.S.Fed && this.S.Club != ClubType.Delinquent)
        {
          this.S.Yandere.PickUp.FoodPieces[this.S.Yandere.PickUp.Food].SetActive(false);
          --this.S.Yandere.PickUp.Food;
          this.S.Fed = true;
        }
        this.S.DialogueWheel.End();
        this.S.StudentManager.UpdateStudents();
      }
    }
    else if (this.S.Interaction == StudentInteractionType.TaskInquiry)
    {
      Debug.Log((object) (this.S.Name + " is currently being told to respond to a Task Inquiry."));
      if ((double) this.S.TalkTimer == 10.0)
      {
        if (this.S.Club == ClubType.Bully)
        {
          this.S.CharacterAnimation.CrossFade("f02_embar_00");
          this.S.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, this.S.StudentID - 80, 10f);
        }
        else if (this.S.StudentID == 10)
        {
          this.S.CharacterAnimation.CrossFade("f02_nod_00");
          if ((Object) this.S.FollowTarget != (Object) null)
            this.S.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 7, 10f);
          else
            this.S.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 8, 8f);
        }
      }
      else if (Input.GetButtonDown("A"))
        this.S.TalkTimer = 0.0f;
      if ((double) this.S.CharacterAnimation["f02_embar_00"].time >= (double) this.S.CharacterAnimation["f02_embar_00"].length)
        this.S.CharacterAnimation.CrossFade(this.IdleAnim);
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        if (this.S.Club == ClubType.Bully)
          this.S.StudentManager.TaskManager.GirlsQuestioned[this.S.StudentID - 80] = true;
        else if (this.S.StudentID == 10)
        {
          this.S.Destinations[this.S.Phase] = this.S.StudentManager.RaibaruMentorSpot;
          this.S.Pathfinding.target = this.S.StudentManager.RaibaruMentorSpot;
          this.S.CurrentDestination = this.S.StudentManager.RaibaruMentorSpot;
          this.S.Actions[this.S.Phase] = StudentActionType.Socializing;
          this.S.CurrentAction = StudentActionType.Socializing;
          if ((Object) this.S.FollowTarget != (Object) null)
            this.S.FollowTarget.Follower = (StudentScript) null;
          this.S.StudentManager.TaskManager.Mentored = true;
          this.S.Pathfinding.speed = 4f;
          this.S.Mentoring = true;
          this.S.InEvent = true;
          this.S.Hurry = true;
        }
        this.S.DialogueWheel.End();
      }
    }
    else if (this.S.Interaction == StudentInteractionType.TakingSnack)
    {
      Debug.Log((object) (this.S.Name + " is reacting to being offered a snack."));
      if ((double) this.S.TalkTimer == 5.0)
      {
        bool flag = false;
        if (this.S.StudentID == this.S.StudentManager.RivalID)
        {
          if (this.S.StudentManager.Eighties)
          {
            if (this.S.Clock.Period > 2 && this.S.StudentManager.RivalBookBag.BentoStolen)
            {
              this.S.Hungry = true;
              this.S.Fed = false;
            }
            else
              flag = true;
          }
          else if (!this.S.Hungry)
          {
            Debug.Log((object) "The rival is not hungry, so she is going to refuse the snack.");
            flag = true;
          }
          else
            Debug.Log((object) "Osana is hungry, and should accept the snack.");
        }
        if (this.S.Club == ClubType.Delinquent && !this.S.StudentManager.MissionMode)
        {
          this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
          this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 1, 3f);
          this.S.IgnoreFoodTimer = 10f;
        }
        else if (((this.S.Fed ? 1 : (this.S.Club == ClubType.Council ? 1 : 0)) | (flag ? 1 : 0)) != 0 || this.S.StudentID == 22)
        {
          this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
          this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 0, 3f);
          this.S.IgnoreFoodTimer = 10f;
          this.S.Fed = true;
          if (this.S.StudentID == this.S.StudentManager.RivalID)
          {
            if (this.S.StudentManager.Eighties)
            {
              this.S.Subtitle.CustomText = "No thanks, I brought my own lunch to school today!";
              this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
            }
            else
              this.S.Subtitle.UpdateLabel(SubtitleType.RejectFood, 2, 5f);
          }
          Debug.Log((object) (this.S.Name + " has refused the snack."));
        }
        else
        {
          this.S.CharacterAnimation.CrossFade(this.S.Nod2Anim);
          this.S.Subtitle.UpdateLabel(SubtitleType.AcceptFood, 0, 10f);
          this.CalculateRepBonus();
          this.S.Reputation.PendingRep += 1f + (float) this.S.RepBonus;
          this.S.PendingRep += 1f + (float) this.S.RepBonus;
        }
      }
      else if (Input.GetButtonDown("A"))
        this.S.TalkTimer = 0.0f;
      if ((double) this.S.CharacterAnimation[this.S.Nod2Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod2Anim].length)
        this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
      if ((double) this.S.CharacterAnimation[this.S.GossipAnim].time >= (double) this.S.CharacterAnimation[this.S.GossipAnim].length)
        this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
      this.S.TalkTimer -= Time.deltaTime;
      if ((double) this.S.TalkTimer <= 0.0)
      {
        bool flag = false;
        if (this.S.Club == ClubType.Delinquent && !this.S.StudentManager.MissionMode)
          flag = true;
        if (!this.S.Fed && !flag)
        {
          if (this.S.StudentID == this.S.StudentManager.RivalID && SchemeGlobals.GetSchemeStage(4) == 5)
          {
            SchemeGlobals.SetSchemeStage(4, 6);
            this.S.Yandere.PauseScreen.Schemes.UpdateInstructions();
          }
          PickUpScript pickUp = this.S.Yandere.PickUp;
          this.S.Yandere.EmptyHands();
          this.S.EmptyHands();
          pickUp.GetComponent<MeshFilter>().mesh = this.S.StudentManager.OpenChipBag;
          pickUp.transform.parent = this.S.LeftItemParent;
          pickUp.transform.localPosition = new Vector3(-0.02f, -0.075f, 0.0f);
          pickUp.transform.localEulerAngles = new Vector3(-15f, -15f, 30f);
          pickUp.MyRigidbody.useGravity = false;
          pickUp.MyRigidbody.isKinematic = true;
          pickUp.Prompt.Hide();
          pickUp.Prompt.enabled = false;
          pickUp.enabled = false;
          this.S.BagOfChips = pickUp.gameObject;
          this.S.EatingSnack = true;
          this.S.Private = true;
          this.S.Hungry = false;
          this.S.Fed = true;
        }
        this.S.DialogueWheel.End();
        this.S.StudentManager.UpdateStudents();
      }
    }
    else if (this.S.Interaction == StudentInteractionType.GivingHelp)
    {
      if ((double) this.S.TalkTimer == 4.0)
      {
        if (this.S.Club == ClubType.Council || this.S.Club == ClubType.Delinquent)
        {
          this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
          this.S.Subtitle.UpdateLabel(SubtitleType.RejectHelp, 0, 4f);
        }
        else if ((double) this.S.Yandere.Bloodiness > 0.0)
        {
          this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
          this.S.Subtitle.UpdateLabel(SubtitleType.RejectHelp, 1, 4f);
        }
        else
        {
          this.S.CharacterAnimation.CrossFade(this.S.PullBoxCutterAnim);
          this.S.SmartPhone.SetActive(false);
          this.S.Subtitle.UpdateLabel(SubtitleType.GiveHelp, 0, 4f);
        }
      }
      else
        Input.GetButtonDown("A");
      if ((double) this.S.CharacterAnimation[this.S.GossipAnim].time >= (double) this.S.CharacterAnimation[this.S.GossipAnim].length)
        this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
      if ((double) this.S.CharacterAnimation[this.S.PullBoxCutterAnim].time >= (double) this.S.CharacterAnimation[this.S.PullBoxCutterAnim].length)
        this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
      this.S.TalkTimer -= Time.deltaTime;
      if (this.S.Club != ClubType.Council && this.S.Club != ClubType.Delinquent)
      {
        this.S.MoveTowardsTarget(this.S.Yandere.transform.position + this.S.Yandere.transform.forward * 0.75f);
        if ((double) this.S.CharacterAnimation[this.S.PullBoxCutterAnim].time >= (double) this.S.CharacterAnimation[this.S.PullBoxCutterAnim].length)
        {
          this.S.CharacterAnimation.CrossFade(this.S.IdleAnim);
          this.StuckBoxCutter = (WeaponScript) null;
        }
        else if ((double) this.S.CharacterAnimation[this.S.PullBoxCutterAnim].time >= 2.0)
        {
          if ((Object) this.StuckBoxCutter.transform.parent != (Object) this.S.RightEye)
          {
            this.StuckBoxCutter.Prompt.enabled = true;
            this.StuckBoxCutter.enabled = true;
            this.StuckBoxCutter.transform.parent = this.S.Yandere.PickUp.transform;
            this.StuckBoxCutter.transform.localPosition = new Vector3(0.0f, 0.19f, 0.0f);
            this.StuckBoxCutter.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
          }
        }
        else if ((double) this.S.CharacterAnimation[this.S.PullBoxCutterAnim].time >= 1.1666660308837891 && (Object) this.StuckBoxCutter == (Object) null)
        {
          this.StuckBoxCutter = this.S.Yandere.PickUp.StuckBoxCutter;
          this.S.Yandere.PickUp.StuckBoxCutter = (WeaponScript) null;
          this.StuckBoxCutter.FingerprintID = this.S.StudentID;
          this.StuckBoxCutter.transform.parent = this.S.RightHand;
          this.StuckBoxCutter.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
          this.StuckBoxCutter.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
        }
      }
      if ((double) this.S.TalkTimer <= 0.0)
      {
        this.S.DialogueWheel.End();
        this.S.StudentManager.UpdateStudents();
      }
    }
    else if (this.S.Interaction == StudentInteractionType.SentToLocker)
    {
      bool flag = false;
      if (this.S.Club == ClubType.Delinquent)
        flag = true;
      if (this.S.Friend)
        flag = false;
      if ((double) this.S.TalkTimer == 5.0)
      {
        if (!flag)
        {
          this.Refuse = false;
          if ((double) this.S.Clock.HourTime > 8.0 && (double) this.S.Clock.HourTime < 13.0 || (double) this.S.Clock.HourTime > 13.375 && (double) this.S.Clock.HourTime < 15.5 || this.S.Schoolwear == 2)
          {
            if (this.S.Schoolwear == 2)
            {
              this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
              this.S.Subtitle.CustomText = "Thanks for letting me know, but...I'm in a swimsuit right now. It'll just have to wait.";
              this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
              this.Refuse = true;
            }
            else
            {
              this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
              this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 1, 5f);
              this.Refuse = true;
            }
          }
          else if (this.S.Club == ClubType.Council)
          {
            this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
            this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 3, 5f);
            this.Refuse = true;
          }
          else if (!this.S.StudentManager.MissionMode && this.S.Rival)
          {
            if (!this.S.Friend || (double) this.S.Reputation.Reputation < (double) (DateGlobals.Week * 10))
            {
              if (!this.S.Friend)
              {
                this.S.Yandere.NotificationManager.CustomText = "You must befriend her first";
                this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
              }
              if ((double) this.S.Reputation.Reputation < (double) (DateGlobals.Week * 10))
              {
                this.S.Yandere.NotificationManager.CustomText = "You need at least " + (DateGlobals.Week * 10).ToString() + " Reputation Points";
                this.S.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
              }
              this.S.CharacterAnimation.CrossFade(this.S.GossipAnim);
              this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 4, 5f);
              this.Refuse = true;
            }
            else
            {
              this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
              this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 2, 5f);
            }
          }
          else
          {
            this.S.CharacterAnimation.CrossFade(this.S.Nod1Anim);
            this.S.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 2, 5f);
          }
        }
        else
          this.S.Subtitle.UpdateLabel(SubtitleType.Dismissive, 5, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.S.TalkTimer = 0.0f;
        if ((double) this.S.CharacterAnimation[this.S.Nod1Anim].time >= (double) this.S.CharacterAnimation[this.S.Nod1Anim].length)
          this.S.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.S.TalkTimer <= 0.0)
        {
          if (!this.Refuse)
          {
            if (!flag)
            {
              this.S.Pathfinding.speed = 4f;
              this.S.TargetDistance = 1f;
              this.S.SentToLocker = true;
              this.S.Routine = false;
              this.S.CanTalk = false;
            }
            else
            {
              this.S.Pathfinding.speed = 1f;
              this.S.TargetDistance = 0.5f;
              this.S.Routine = true;
              this.S.CanTalk = true;
            }
          }
          this.S.DialogueWheel.End();
        }
      }
      this.S.TalkTimer -= Time.deltaTime;
    }
    else if (this.S.Interaction == StudentInteractionType.WaitingForBeatEmUpResult)
    {
      Debug.Log((object) "We are currently ''waiting for beat em up result''");
      if (!this.FadeIn)
      {
        this.S.Subtitle.Darkness.alpha = Mathf.MoveTowards(this.S.Subtitle.Darkness.alpha, 1f, Time.deltaTime);
        if ((double) this.S.Subtitle.Darkness.alpha == 1.0)
        {
          this.S.TriggerBeatEmUpMinigame();
          this.FadeIn = true;
        }
      }
      else
      {
        Debug.Log((object) "''FadeIn'' is false.");
        this.S.Subtitle.Darkness.alpha = Mathf.MoveTowards(this.S.Subtitle.Darkness.alpha, 0.0f, Time.deltaTime);
        if ((double) this.S.Subtitle.Darkness.alpha == 0.0)
        {
          Debug.Log((object) "''Darkness'' is 0.");
          if (!GameGlobals.BeatEmUpSuccess)
          {
            this.S.DialogueWheel.End();
            this.Timer = 0.0f;
          }
          else
          {
            Debug.Log((object) "''BeatEmUpSuccess'' is true.");
            this.S.StudentManager.UpdateAllAnimLayers();
            this.S.Yandere.SetAnimationLayers();
            AstarPath.active.Scan();
            this.S.TaskPhase = 5;
            this.S.Interaction = StudentInteractionType.GivingTask;
            this.Timer = 0.0f;
            Debug.Log((object) ("Now telling " + this.S.Name + " to go home."));
            this.S.CurrentDestination.transform.position = this.S.StudentManager.Exit.position;
            ScheduleBlock scheduleBlock = this.S.ScheduleBlocks[6];
            scheduleBlock.destination = "Exit";
            scheduleBlock.action = "Stand";
            this.S.GetDestinations();
          }
          this.FadeIn = false;
        }
      }
    }
    if (this.S.StudentID == 41 && !this.S.DialogueWheel.ClubLeader && this.S.Interaction != StudentInteractionType.ClubUnwelcome && this.S.Interaction != StudentInteractionType.GivingTask && !this.S.StudentManager.Eighties && (double) this.S.TalkTimer > 0.0)
    {
      Debug.Log((object) "Geiju response.");
      if (this.S.Grudge)
      {
        this.S.Subtitle.CustomText = "Murderer. Begone.";
        this.S.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
      }
      else if (this.NegativeResponse)
      {
        Debug.Log((object) "Negative response.");
        this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
      }
      else
        this.S.Subtitle.UpdateLabel(SubtitleType.Impatience, 5, 5f);
    }
    if (this.S.Waiting)
    {
      this.S.WaitTimer -= Time.deltaTime;
      if ((double) this.S.WaitTimer > 0.0)
        return;
      this.S.DialogueWheel.TaskManager.UpdateTaskStatus();
      this.S.Talking = false;
      this.S.Waiting = false;
      this.enabled = false;
      if (!this.Fake && !this.S.StudentManager.CombatMinigame.Practice)
      {
        this.S.Pathfinding.canSearch = true;
        this.S.Pathfinding.canMove = true;
        this.S.Obstacle.enabled = false;
        this.S.Alarmed = false;
        if (!this.S.Following && !this.S.Distracting && !this.S.Wet && !this.S.EatingSnack && !this.S.SentToLocker)
          this.S.Routine = true;
        if (!this.S.Following)
          this.S.Hearts.emission.enabled = false;
      }
      this.S.StudentManager.EnablePrompts();
      if (!this.S.GoAway)
        return;
      Debug.Log((object) "This student was just told to go away.");
      this.S.CurrentDestination = this.S.StudentManager.GoAwaySpots.List[this.S.StudentID];
      this.S.Pathfinding.target = this.S.StudentManager.GoAwaySpots.List[this.S.StudentID];
      this.S.Pathfinding.canSearch = true;
      this.S.Pathfinding.canMove = true;
      this.S.DistanceToDestination = 100f;
    }
    else
    {
      this.S.targetRotation = Quaternion.LookRotation(new Vector3(this.S.Yandere.transform.position.x, this.transform.position.y, this.S.Yandere.transform.position.z) - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.S.targetRotation, 10f * Time.deltaTime);
    }
  }

  private void CalculateRepBonus()
  {
    this.S.RepBonus = 0;
    if (PlayerGlobals.PantiesEquipped == 3)
      ++this.S.RepBonus;
    if (this.S.Male && this.S.Yandere.Class.Seduction + this.S.Yandere.Class.SeductionBonus > 0 || this.S.Yandere.Class.Seduction == 5)
      ++this.S.RepBonus;
    if (this.S.Yandere.Class.SocialBonus > 0)
      ++this.S.RepBonus;
    this.S.ChameleonCheck();
    if (this.S.Chameleon)
      ++this.S.RepBonus;
    this.S.RepBonus += this.S.Yandere.Class.PsychologyGrade + this.S.Yandere.Class.PsychologyBonus;
  }
}
