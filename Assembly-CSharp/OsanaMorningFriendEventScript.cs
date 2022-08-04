// Decompiled with JetBrains decompiler
// Type: OsanaMorningFriendEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaMorningFriendEventScript : MonoBehaviour
{
  public RivalMorningEventManagerScript OtherEvent;
  public StudentManagerScript StudentManager;
  public EndOfDayScript EndOfDay;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public SpyScript Spy;
  public StudentScript CurrentSpeaker;
  public StudentScript Friend;
  public StudentScript Rival;
  public Transform Epicenter;
  public Transform[] Location;
  public AudioClip SpeechClip;
  public string[] SpeechText;
  public float[] SpeechTime;
  public string[] EventAnim;
  public int[] Speaker;
  public AudioClip InterruptedClip;
  public string[] InterruptedSpeech;
  public float[] InterruptedTime;
  public string[] InterruptedAnim;
  public int[] InterruptedSpeaker;
  public AudioClip AltSpeechClip;
  public string[] AltSpeechText;
  public float[] AltSpeechTime;
  public string[] AltEventAnim;
  public int[] AltSpeaker;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public Quaternion targetRotation;
  public float Distance;
  public float Scale;
  public float Timer;
  public DayOfWeek EventDay;
  public int SpeechPhase = 1;
  public int FriendID = 6;
  public int RivalID = 11;
  public int Phase;
  public int Frame;
  public Vector3 OriginalPosition;
  public Vector3 OriginalRotation;
  public bool LosingFriend;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (this.LosingFriend)
    {
      if ((double) StudentGlobals.GetStudentReputation(10) <= -33.333328247070313 && StudentGlobals.StudentSlave != this.FriendID && StudentGlobals.StudentSlave != this.RivalID && !PlayerGlobals.RaibaruLoner)
        return;
      this.enabled = false;
    }
    else
    {
      if ((double) StudentGlobals.GetStudentReputation(10) > -33.333328247070313 && DateGlobals.Weekday == this.EventDay && !HomeGlobals.LateForSchool && !this.StudentManager.YandereLate && DatingGlobals.SuitorProgress != 2 && StudentGlobals.MemorialStudents <= 0 && StudentGlobals.StudentSlave != this.FriendID && StudentGlobals.StudentSlave != this.RivalID && GameGlobals.RivalEliminationID <= 0 && !PlayerGlobals.RaibaruLoner && !GameGlobals.AlphabetMode && !MissionModeGlobals.MissionMode && DateGlobals.Week <= 1 && !GameGlobals.Eighties)
        return;
      this.enabled = false;
    }
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      if (this.Frame > 0 && (UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[this.FriendID] != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.Friend == (UnityEngine.Object) null)
          this.Friend = this.StudentManager.Students[this.FriendID];
        if ((UnityEngine.Object) this.Rival == (UnityEngine.Object) null)
          this.Rival = this.StudentManager.Students[this.RivalID];
        if (this.Clock.Period == 1 && !this.StudentManager.Students[1].Alarmed && !this.Friend.DramaticReaction && !this.Friend.Alarmed && !this.Rival.Alarmed && this.Rival.enabled && !this.Rival.Talking && this.Rival.Alive && !this.Friend.Hunted && !this.OtherEvent.enabled)
        {
          Debug.Log((object) "Osana's ''talk with friend before going to the lockers'' event has begun.");
          this.Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Friend.CharacterAnimation.CrossFade(this.Friend.WalkAnim);
          this.Friend.Pathfinding.target = this.Location[1];
          this.Friend.CurrentDestination = this.Location[1];
          this.Friend.Pathfinding.canSearch = true;
          this.Friend.Pathfinding.canMove = true;
          this.Friend.Routine = false;
          this.Friend.InEvent = true;
          this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
          this.Rival.Pathfinding.target = this.Location[2];
          this.Rival.CurrentDestination = this.Location[2];
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.Routine = false;
          this.Rival.InEvent = true;
          this.Spy.Prompt.enabled = true;
          if (!this.LosingFriend)
          {
            this.Friend.Private = true;
            this.Rival.Private = true;
            if (!this.OtherEvent.NaturalEnd)
            {
              this.SpeechClip = this.InterruptedClip;
              this.SpeechText = this.InterruptedSpeech;
              this.SpeechTime = this.InterruptedTime;
              this.EventAnim = this.InterruptedAnim;
              this.Speaker = this.InterruptedSpeaker;
            }
            bool flag = false;
            if (StudentGlobals.GetStudentDead(81) || StudentGlobals.GetStudentKidnapped(81) || StudentGlobals.GetStudentArrested(81) || StudentGlobals.GetStudentExpelled(81) || StudentGlobals.GetStudentBroken(81) || StudentGlobals.StudentSlave == 81 || (double) StudentGlobals.GetStudentReputation(81) < -33.333328247070313)
            {
              Debug.Log((object) "Musume's unavailable.");
              flag = true;
            }
            if (DateGlobals.Weekday == DayOfWeek.Friday & flag && this.OtherEvent.NaturalEnd)
            {
              this.SpeechClip = this.AltSpeechClip;
              this.SpeechText = this.AltSpeechText;
              this.SpeechTime = this.AltSpeechTime;
              this.EventAnim = this.AltEventAnim;
              this.Speaker = this.AltSpeaker;
            }
          }
          this.Yandere.PauseScreen.Hint.Show = true;
          this.Yandere.PauseScreen.Hint.QuickID = 12;
          ++this.Phase;
        }
      }
      ++this.Frame;
    }
    else
    {
      if (this.Phase == 1)
      {
        this.Friend.Pathfinding.canSearch = true;
        this.Friend.Pathfinding.canMove = true;
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.SettleRival();
        }
        if ((double) this.Friend.DistanceToDestination < 0.5)
        {
          this.Friend.CharacterAnimation.CrossFade(this.Friend.IdleAnim);
          this.Friend.Pathfinding.canSearch = false;
          this.Friend.Pathfinding.canMove = false;
          this.SettleFriend();
        }
        if ((double) this.Rival.DistanceToDestination < 0.5 && (double) this.Friend.DistanceToDestination < 0.5)
        {
          AudioClipPlayer.Play(this.SpeechClip, this.Friend.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
          this.PlayRelevantAnim();
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.Rival.Obstacle.enabled = true;
          this.Friend.Pathfinding.canSearch = false;
          this.Friend.Pathfinding.canMove = false;
          this.Friend.Obstacle.enabled = true;
          ++this.Phase;
        }
      }
      else if (this.Phase == 2)
      {
        if ((UnityEngine.Object) this.CurrentSpeaker != (UnityEngine.Object) null && this.SpeechPhase > 0 && (double) this.CurrentSpeaker.CharacterAnimation[this.EventAnim[this.SpeechPhase - 1]].time >= (double) this.CurrentSpeaker.CharacterAnimation[this.EventAnim[this.SpeechPhase - 1]].length - 1.0)
          this.CurrentSpeaker.CharacterAnimation.CrossFade(this.CurrentSpeaker.IdleAnim, 1f);
        this.Timer += Time.deltaTime;
        if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
          this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
        if (this.SpeechPhase < this.SpeechTime.Length && (double) this.Timer > (double) this.SpeechTime[this.SpeechPhase])
        {
          this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
          this.PlayRelevantAnim();
          ++this.SpeechPhase;
        }
        this.SettleRival();
        this.SettleFriend();
        if ((double) this.Timer > (double) this.SpeechClip.length)
          this.EndEvent();
      }
      if (this.Rival.Alarmed || this.Friend.Alarmed || this.Friend.DramaticReaction)
      {
        Debug.Log((object) "The event ended naturally because a character was alarmed.");
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity);
        gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
        gameObject.transform.localScale = new Vector3(200f, 1f, 200f);
        this.EndEvent();
      }
      if (!this.Yandere.NoDebug && Input.GetKeyDown(KeyCode.LeftControl))
      {
        this.EndEvent();
        if ((UnityEngine.Object) this.Rival.ShoeRemoval.Locker == (UnityEngine.Object) null)
          this.Rival.ShoeRemoval.Start();
        this.Rival.ShoeRemoval.PutOnShoes();
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
        if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
          this.VoiceClip.GetComponent<AudioSource>().volume = this.Scale;
        if (this.Phase > 1)
          this.Yandere.Eavesdropping = (double) this.Distance < 3.0;
      }
      else
      {
        if ((double) this.Distance - 4.0 < 16.0)
          this.EventSubtitle.transform.localScale = Vector3.zero;
        if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
          this.VoiceClip.GetComponent<AudioSource>().volume = 0.0f;
      }
      if (!((UnityEngine.Object) this.VoiceClip == (UnityEngine.Object) null))
        return;
      this.EventSubtitle.text = string.Empty;
    }
  }

  public void EndEvent()
  {
    Debug.Log((object) "Osana's ''talk with friend before going to the lockers'' event has ended.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if ((UnityEngine.Object) this.Rival != (UnityEngine.Object) null)
    {
      if (!this.Rival.Alarmed)
      {
        this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
        this.Rival.DistanceToDestination = 100f;
        if (this.Rival.Phase == 0)
          ++this.Rival.Phase;
        this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
        this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
        this.Rival.Pathfinding.canSearch = true;
        this.Rival.Pathfinding.canMove = true;
        this.Rival.Routine = true;
      }
      if (this.Rival.Alarmed)
        this.Rival.ReturnToRoutineAfter = true;
      this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      this.Rival.Obstacle.enabled = false;
      this.Rival.Prompt.enabled = true;
      this.Rival.InEvent = false;
      this.Rival.Private = false;
    }
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
    {
      if (!this.Friend.Alarmed && !this.Friend.DramaticReaction)
      {
        this.Friend.CharacterAnimation.CrossFade(this.Friend.WalkAnim);
        this.Friend.DistanceToDestination = 100f;
        if (!this.LosingFriend)
        {
          this.Friend.CurrentDestination = this.Rival.FollowTargetDestination;
          this.Friend.Pathfinding.target = this.Rival.FollowTargetDestination;
        }
        else
        {
          this.Friend.CurrentDestination = this.Friend.Destinations[this.Friend.Phase];
          this.Friend.Pathfinding.target = this.Friend.Destinations[this.Friend.Phase];
        }
        this.Friend.Pathfinding.canSearch = true;
        this.Friend.Pathfinding.canMove = true;
        this.Friend.Routine = true;
      }
      this.Friend.VisionDistance = (PlayerGlobals.PantiesEquipped == 4 ? 5f : 10f) * this.Friend.Paranoia;
      this.Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      this.Friend.Obstacle.enabled = false;
      this.Friend.Prompt.enabled = true;
      this.Friend.InEvent = false;
      this.Friend.Private = false;
      if (this.Rival.Alarmed)
        this.Friend.FocusOnYandere = true;
    }
    this.Spy.Prompt.enabled = false;
    this.Spy.Prompt.Hide();
    if (this.Spy.Phase > 0)
      this.Spy.End();
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Yandere.Eavesdropping = false;
    this.EventSubtitle.text = string.Empty;
    this.Jukebox.Dip = 1f;
    this.enabled = false;
    if (!this.LosingFriend)
      return;
    Debug.Log((object) "Raibaru will no longer hang out with Osana.");
    this.EndOfDay.RaibaruLoner = true;
    Debug.Log((object) "Raibaru has become a loner, so Osana's schedule has changed.");
    ScheduleBlock scheduleBlock1 = this.Rival.ScheduleBlocks[2];
    scheduleBlock1.destination = "Patrol";
    scheduleBlock1.action = "Patrol";
    ScheduleBlock scheduleBlock2 = this.Rival.ScheduleBlocks[7];
    scheduleBlock2.destination = "Patrol";
    scheduleBlock2.action = "Patrol";
    this.Rival.GetDestinations();
  }

  private void SettleRival()
  {
    this.Rival.MoveTowardsTarget(this.Location[2].position);
    if ((double) Quaternion.Angle(this.Rival.transform.rotation, this.Location[2].rotation) <= 1.0)
      return;
    this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location[2].rotation, 10f * Time.deltaTime);
  }

  private void SettleFriend()
  {
    this.Friend.MoveTowardsTarget(this.Location[1].position);
    this.Friend.transform.LookAt(this.Rival.transform.position);
  }

  private void PlayRelevantAnim()
  {
    if (this.Speaker[this.SpeechPhase] == 1)
    {
      this.Rival.CharacterAnimation.CrossFade(this.EventAnim[this.SpeechPhase]);
      this.Friend.CharacterAnimation.CrossFade(this.Friend.IdleAnim);
      this.CurrentSpeaker = this.Rival;
    }
    else
    {
      this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
      this.Friend.CharacterAnimation.CrossFade(this.EventAnim[this.SpeechPhase]);
      this.CurrentSpeaker = this.Friend;
    }
  }
}
