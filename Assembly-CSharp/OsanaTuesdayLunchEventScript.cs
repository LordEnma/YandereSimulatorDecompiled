// Decompiled with JetBrains decompiler
// Type: OsanaTuesdayLunchEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaTuesdayLunchEventScript : MonoBehaviour
{
  public RivalAfterClassEventManagerScript AfterClassEvent;
  public StudentManagerScript StudentManager;
  public JukeboxScript Jukebox;
  public PromptScript PushPrompt;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript Friend;
  public StudentScript Rival;
  public Transform[] Location;
  public AudioSource VoiceClipSource;
  public AudioSource MyAudio;
  public AudioClip[] SpeechClip;
  public string[] SpeechText;
  public string[] EventAnim;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public bool DoneStretching;
  public bool Sabotaging;
  public bool Sabotaged;
  public float StinkTimer;
  public float Distance;
  public float Scale;
  public float Timer;
  public DayOfWeek EventDay;
  public int StretchPhase;
  public int FriendID = 10;
  public int RivalID = 11;
  public int Phase;
  public int Frame;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    this.PushPrompt.gameObject.SetActive(false);
    if (DateGlobals.Weekday == this.EventDay && GameGlobals.RivalEliminationID <= 0 && !GameGlobals.Eighties)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.VoiceClipSource == (UnityEngine.Object) null)
        this.VoiceClipSource = this.VoiceClip.GetComponent<AudioSource>();
      else
        this.VoiceClipSource.pitch = Time.timeScale;
    }
    if (this.Phase == 0)
    {
      if (this.Frame > 0 && (UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null && this.StudentManager.Students[this.RivalID].enabled)
      {
        if (this.StudentManager.Students[this.RivalID].Bullied)
          this.enabled = false;
        else if (this.Clock.Period == 3)
        {
          Debug.Log((object) "Osana's Tuesday lunchtime event has begun.");
          this.Rival = this.StudentManager.Students[this.RivalID];
          this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
          this.Rival.Pathfinding.target = this.Location[1];
          this.Rival.CurrentDestination = this.Location[1];
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.Routine = false;
          this.Rival.InEvent = true;
          this.Rival.EmptyHands();
          Debug.Log((object) "Osana's ''StinkBombSpecialCase'' has been set to ''1''.");
          Debug.Log((object) ("PlayerGlobals.RaibaruLoner is: " + PlayerGlobals.RaibaruLoner.ToString()));
          bool flag = true;
          if (PlayerGlobals.RaibaruLoner || this.StudentManager.Police.EndOfDay.RaibaruLoner)
            flag = false;
          if ((UnityEngine.Object) this.StudentManager.Students[this.FriendID] != (UnityEngine.Object) null & flag)
          {
            this.Friend = this.StudentManager.Students[this.FriendID];
            this.StudentManager.Patrols.List[10].GetChild(0).localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
            this.StudentManager.Patrols.List[10].GetChild(1).localEulerAngles = new Vector3(0.0f, -135f, 0.0f);
            this.StudentManager.Patrols.List[10].GetChild(2).localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
            this.StudentManager.Patrols.List[10].GetChild(3).localEulerAngles = new Vector3(0.0f, 135f, 0.0f);
            ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[4];
            scheduleBlock.destination = "Patrol";
            scheduleBlock.action = "Patrol";
            this.Friend.GetDestinations();
            this.Friend.CanTalk = false;
          }
          this.Yandere.PauseScreen.Hint.Show = true;
          this.Yandere.PauseScreen.Hint.QuickID = 17;
          ++this.Phase;
        }
      }
      ++this.Frame;
    }
    else
    {
      if (this.Rival.StinkBombSpecialCase == 2)
      {
        Debug.Log((object) "Osana is holding her breath.");
        this.StinkTimer += Time.deltaTime;
        if ((double) this.StinkTimer > 1.0)
        {
          this.Rival.StinkBombSpecialCase = 1;
          this.StinkTimer = 0.0f;
          if (this.Phase < 4)
            this.Phase = 1;
          else if (this.Phase > 6)
            this.Phase = 7;
          else
            this.DoneStretching = true;
        }
      }
      else
      {
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          if (!this.Rival.GoAway)
            this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
          this.Rival.targetRotation = this.Rival.CurrentDestination.rotation;
          this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.targetRotation, 10f * Time.deltaTime);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
        }
        if (this.Phase == 1)
        {
          if ((double) this.Rival.DistanceToDestination < 0.5)
          {
            AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[1]);
            this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[1]);
            this.Rival.Pathfinding.canSearch = false;
            this.Rival.Pathfinding.canMove = false;
            this.Rival.Obstacle.enabled = true;
            ++this.Phase;
          }
        }
        else if (this.Phase == 2)
        {
          if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].time >= 0.83333301544189453)
            this.Rival.AnimatedBook.SetActive(true);
          if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].time >= 5.0)
            this.EventSubtitle.text = this.SpeechText[1];
          if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].time >= (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].length)
          {
            this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[2]);
            this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[2]);
            ++this.Phase;
          }
        }
        else if (this.Phase == 3)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 60.0)
          {
            AudioClipPlayer.Play(this.SpeechClip[2], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[3]);
            this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[3]);
            this.EventSubtitle.text = this.SpeechText[2];
            this.StretchPhase = 2;
            ++this.Phase;
          }
        }
        else if (this.Phase == 4)
        {
          if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[3]].time >= (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[3]].length)
          {
            this.Rival.AnimatedBook.transform.parent = (Transform) null;
            this.PushPrompt.gameObject.SetActive(true);
            this.PushPrompt.enabled = true;
            this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
            this.Rival.Pathfinding.target = this.Location[this.StretchPhase];
            this.Rival.CurrentDestination = this.Location[this.StretchPhase];
            this.Rival.DistanceToDestination = 100f;
            this.Rival.Pathfinding.canSearch = true;
            this.Rival.Pathfinding.canMove = true;
            this.Rival.StinkBombSpecialCase = 1;
            ++this.Phase;
          }
        }
        else if (this.Phase == 5)
        {
          if ((double) this.Rival.DistanceToDestination < 0.5 || this.DoneStretching)
          {
            if (this.StretchPhase == 2)
            {
              AudioClipPlayer.Play(this.SpeechClip[3], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
              this.EventSubtitle.text = this.SpeechText[3];
            }
            this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[4]);
            this.Rival.Pathfinding.canSearch = false;
            this.Rival.Pathfinding.canMove = false;
            this.DoneStretching = false;
            ++this.Phase;
          }
        }
        else if (this.Phase == 6)
        {
          if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[4]].time >= (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[4]].length || this.DoneStretching)
          {
            this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
            ++this.StretchPhase;
            this.DoneStretching = false;
            if (this.StretchPhase < 6)
            {
              this.Rival.Pathfinding.target = this.Location[this.StretchPhase];
              this.Rival.CurrentDestination = this.Location[this.StretchPhase];
              this.Rival.DistanceToDestination = 100f;
              this.Rival.Pathfinding.canSearch = true;
              this.Rival.Pathfinding.canMove = true;
              --this.Phase;
            }
            else
            {
              this.PushPrompt.gameObject.SetActive(false);
              this.Rival.StinkBombSpecialCase = 0;
              if (!this.Sabotaged)
              {
                this.Rival.Pathfinding.target = this.Location[1];
                this.Rival.CurrentDestination = this.Location[1];
                this.Rival.DistanceToDestination = 100f;
                this.Rival.Pathfinding.canSearch = true;
                this.Rival.Pathfinding.canMove = true;
              }
              else
              {
                this.Rival.Pathfinding.target = this.Location[7];
                this.Rival.CurrentDestination = this.Location[7];
                this.Rival.DistanceToDestination = 100f;
                this.Rival.Pathfinding.canSearch = true;
                this.Rival.Pathfinding.canMove = true;
                if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
                {
                  ScheduleBlock scheduleBlock1 = this.Friend.ScheduleBlocks[4];
                  scheduleBlock1.destination = "Follow";
                  scheduleBlock1.action = "Follow";
                  ScheduleBlock scheduleBlock2 = this.Friend.ScheduleBlocks[6];
                  scheduleBlock2.destination = "Follow";
                  scheduleBlock2.action = "Follow";
                  this.Friend.GetDestinations();
                }
              }
              ++this.Phase;
            }
          }
        }
        else if (this.Phase == 7)
        {
          if (!this.Sabotaged)
          {
            if ((double) this.Rival.DistanceToDestination < 0.5)
            {
              AudioClipPlayer.Play(this.SpeechClip[4], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
              this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[5]);
              this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[5]);
              this.EventSubtitle.text = this.SpeechText[4];
              ++this.Phase;
            }
          }
          else if ((double) this.Rival.DistanceToDestination < 0.5)
          {
            this.Rival.EventSpecialCase = true;
            this.Rival.WalkAnim = "f02_sadWalk_00";
            this.Rival.SitAnim = "f02_sadDeskSit_00";
            AudioClipPlayer.Play(this.SpeechClip[6], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[8]);
            this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[8]);
            this.EventSubtitle.text = this.SpeechText[6];
            this.Rival.Depressed = true;
            this.Phase = 11;
          }
        }
        else if (this.Phase == 8)
        {
          if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[5]].time >= (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[5]].length)
          {
            this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[2]);
            this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[2]);
            ++this.Phase;
          }
        }
        else if (this.Phase == 9)
        {
          if ((double) this.Clock.HourTime > 13.375)
          {
            AudioClipPlayer.Play(this.SpeechClip[5], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[6]);
            this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[6]);
            this.EventSubtitle.text = this.SpeechText[5];
            ++this.Phase;
          }
        }
        else if (this.Phase == 10)
        {
          if (this.Rival.AnimatedBook.activeInHierarchy && (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[6]].time > 2.0)
            this.Rival.AnimatedBook.SetActive(false);
          if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[6]].time >= (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[6]].length)
            this.EndEvent();
        }
        else if (this.Phase == 11)
        {
          if (this.Rival.AnimatedBook.activeInHierarchy && (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[8]].time > 7.0)
            this.Rival.AnimatedBook.SetActive(false);
          if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[8]].time >= (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim[8]].length)
          {
            this.Rival.Destinations[4] = this.Location[8];
            if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
            {
              this.Friend.Destinations[4] = this.Location[9];
              this.StudentManager.LunchSpots.List[this.FriendID] = this.Location[9];
            }
            this.EndEvent();
          }
        }
      }
      if ((double) this.PushPrompt.Circle[0].fillAmount == 0.0)
      {
        this.PushPrompt.Hide();
        this.PushPrompt.gameObject.SetActive(false);
        this.Sabotaging = true;
        this.Yandere.CanMove = false;
        this.Yandere.CharacterAnimation.CrossFade("f02_" + this.EventAnim[7]);
        this.Rival.AnimatedBook.GetComponent<Animation>().Play(this.EventAnim[7]);
        this.Rival.AnimatedBook.transform.eulerAngles = new Vector3(this.Rival.AnimatedBook.transform.eulerAngles.x, 0.0f, this.Rival.AnimatedBook.transform.eulerAngles.z);
        this.Rival.AnimatedBook.transform.position = new Vector3(this.Rival.AnimatedBook.transform.position.x, this.Rival.AnimatedBook.transform.position.y, -2.8f);
        this.AfterClassEvent.Sabotaged = true;
      }
      if (this.Sabotaging)
      {
        this.Yandere.MoveTowardsTarget(this.Location[6].position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.Location[6].rotation, Time.deltaTime * 10f);
        if ((double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[7]].time > 1.5 && (double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[7]].time < 2.0 && !this.MyAudio.isPlaying)
          this.MyAudio.Play();
        if ((double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[7]].time > (double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[7]].length)
        {
          this.Yandere.CanMove = true;
          this.Sabotaging = false;
          this.Sabotaged = true;
        }
      }
      if (this.Clock.Period > 3 || this.Rival.Wet || this.Rival.Alarmed || this.Rival.Attacked || !this.Rival.Alive || this.Rival.GoAway)
        this.EndEvent();
      this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Rival.transform.position);
      if ((double) this.Distance - 4.0 < 15.0)
      {
        this.Scale = Mathf.Abs((float) (1.0 - ((double) this.Distance - 4.0) / 15.0));
        if ((double) this.Scale < 0.0)
          this.Scale = 0.0f;
        if ((double) this.Scale > 1.0)
          this.Scale = 1f;
        this.Jukebox.Dip = (float) (1.0 - 0.5 * (double) this.Scale);
        this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
        if ((UnityEngine.Object) this.VoiceClipSource != (UnityEngine.Object) null)
          this.VoiceClipSource.volume = this.Scale;
      }
      else
      {
        this.EventSubtitle.transform.localScale = Vector3.zero;
        if ((UnityEngine.Object) this.VoiceClipSource != (UnityEngine.Object) null)
          this.VoiceClipSource.volume = 0.0f;
      }
      if (!((UnityEngine.Object) this.VoiceClip == (UnityEngine.Object) null))
        return;
      this.EventSubtitle.text = string.Empty;
    }
  }

  private void EndEvent()
  {
    Debug.Log((object) "Osana's Tuesday lunchtime event ended.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if (!this.Rival.Splashed && !this.Rival.Dodging)
    {
      this.Rival.Pathfinding.canSearch = true;
      this.Rival.Pathfinding.canMove = true;
    }
    else
    {
      Debug.Log((object) "Osana was told to stop moving.");
      this.Rival.Pathfinding.canSearch = false;
      this.Rival.Pathfinding.canMove = false;
    }
    if (!this.Rival.Alarmed)
    {
      this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
      this.Rival.DistanceToDestination = 100f;
    }
    this.Rival.Routine = !this.Rival.Splashed;
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
    {
      if (!this.Friend.ReturningMisplacedWeapon)
      {
        this.Friend.ResumeFollowing();
        Debug.Log((object) "Raibaru was told to resume ''Follow'' protocol.");
      }
      else
        this.Friend.ResumeFollowingAfter = true;
    }
    if ((UnityEngine.Object) this.Rival.AnimatedBook.transform.parent != (UnityEngine.Object) null)
      this.Rival.AnimatedBook.SetActive(false);
    this.PushPrompt.enabled = false;
    this.PushPrompt.Hide();
    this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.Rival.StinkBombSpecialCase = 0;
    this.Rival.EventSpecialCase = false;
    this.Rival.Obstacle.enabled = false;
    this.Rival.Prompt.enabled = true;
    this.Rival.InEvent = false;
    this.Rival.Private = false;
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Jukebox.Dip = 1f;
    this.EventSubtitle.text = string.Empty;
    this.enabled = false;
    if (!this.Rival.GoAway)
      return;
    this.Rival.Subtitle.CustomText = "Ugh, seriously?! Whatever, I'll read it later...";
    this.Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
  }
}
