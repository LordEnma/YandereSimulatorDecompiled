// Decompiled with JetBrains decompiler
// Type: EventManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class EventManagerScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public NoteLockerScript NoteLocker;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public JukeboxScript Jukebox;
  public ClockScript Clock;
  public StudentScript[] EventStudent;
  public Transform[] EventLocation;
  public AudioClip[] EventClip;
  public string[] EventSpeech;
  public string[] EventAnim;
  public int[] EventSpeaker;
  public GameObject VoiceClip;
  public AudioSource VoiceClipSource;
  public bool StopWalking;
  public bool EventCheck;
  public bool CanHappen;
  public bool HintGiven;
  public bool EventOn;
  public bool Suitor;
  public bool Spoken;
  public bool Osana;
  public float StartTimer;
  public float Timer;
  public float Scale;
  public float StartTime = 13.01f;
  public float EndTime = 13.5f;
  public int EventStudent1;
  public int EventStudent2;
  public int EventPhase;
  public int OsanaID = 1;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Weekday == DayOfWeek.Monday)
      this.EventCheck = true;
    if (this.OsanaID == 3)
    {
      if (GameGlobals.Eighties || DateGlobals.Weekday != DayOfWeek.Thursday || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode)
        this.enabled = false;
      else
        this.EventCheck = true;
    }
    this.NoteLocker.Prompt.enabled = true;
    this.NoteLocker.CanLeaveNote = true;
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
    if (!this.Clock.StopTime && this.EventCheck && this.CanHappen)
    {
      if ((double) this.Clock.HourTime > (double) this.StartTime + 1.0)
        this.enabled = false;
      else if ((double) this.Clock.HourTime > (double) this.StartTime)
      {
        if ((UnityEngine.Object) this.EventStudent[1] == (UnityEngine.Object) null)
          this.EventStudent[1] = this.StudentManager.Students[this.EventStudent1];
        else if (!this.EventStudent[1].Alive)
        {
          this.EventCheck = false;
          this.enabled = false;
        }
        if ((UnityEngine.Object) this.EventStudent[2] == (UnityEngine.Object) null)
          this.EventStudent[2] = this.StudentManager.Students[this.EventStudent2];
        else if (!this.EventStudent[2].Alive)
        {
          this.EventCheck = false;
          this.enabled = false;
        }
        if ((UnityEngine.Object) this.EventStudent[1] != (UnityEngine.Object) null && (UnityEngine.Object) this.EventStudent[2] != (UnityEngine.Object) null && this.EventStudent[1].enabled && !this.EventStudent[1].Slave && !this.EventStudent[2].Slave && this.EventStudent[1].Indoors && !this.EventStudent[1].Wet && !this.EventStudent[1].Meeting && !this.EventStudent[1].Talking && (this.OsanaID < 2 || this.OsanaID > 1 && (double) Vector3.Distance(this.EventStudent[1].transform.position, this.EventLocation[1].position) < 1.0))
        {
          this.StartTimer += Time.deltaTime;
          if ((double) this.StartTimer > 1.0 && this.EventStudent[1].Routine && this.EventStudent[2].Routine && !this.EventStudent[1].InEvent && !this.EventStudent[2].InEvent)
          {
            this.EventStudent[1].CurrentDestination = this.EventLocation[1];
            this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
            this.EventStudent[1].EventManager = this;
            this.EventStudent[1].InEvent = true;
            this.EventStudent[1].EmptyHands();
            this.EventStudent[2].InEvent = true;
            if (!this.Osana)
            {
              this.EventStudent[2].CurrentDestination = this.EventLocation[2];
              this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
              this.EventStudent[2].EventManager = this;
              this.EventStudent[2].InEvent = true;
              Debug.Log((object) "Kokona's rooftop event just began?");
            }
            else
            {
              Debug.Log((object) "One of Osana's ''talk privately with Raibaru'' events is beginning.");
              this.Yandere.PauseScreen.Hint.Show = true;
              if (DateGlobals.Weekday == DayOfWeek.Monday)
                this.Yandere.PauseScreen.Hint.QuickID = (double) this.StartTime >= 7.3 ? 18 : 14;
              if (DateGlobals.Weekday == DayOfWeek.Thursday)
                this.Yandere.PauseScreen.Hint.QuickID = 13;
              double startTime = (double) this.StartTime;
            }
            this.EventStudent[2].EmptyHands();
            this.EventStudent[1].SpeechLines.Stop();
            this.EventStudent[2].SpeechLines.Stop();
            this.EventCheck = false;
            this.EventOn = true;
          }
        }
      }
    }
    if (!this.EventOn)
      return;
    float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position);
    if ((double) this.Clock.HourTime > (double) this.EndTime || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Dying || this.EventStudent[2].Dying || this.EventStudent[1].Splashed || this.EventStudent[2].Splashed || this.EventStudent[1].Alarmed || this.EventStudent[2].Alarmed)
    {
      this.EndEvent();
    }
    else
    {
      if (this.Osana)
      {
        if ((double) this.EventStudent[1].DistanceToDestination < 1.0)
        {
          this.EventStudent[2].CurrentDestination = this.EventLocation[2];
          this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
          this.EventStudent[2].EventManager = this;
        }
        else
        {
          if (this.EventStudent[1].Pathfinding.canMove)
          {
            if ((double) this.EventStudent[1].Pathfinding.speed == 1.0)
              this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
            else
              this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].SprintAnim);
          }
          this.EventStudent[2].CurrentDestination = this.EventStudent[1].FollowTargetDestination;
          this.EventStudent[2].Pathfinding.target = this.EventStudent[1].FollowTargetDestination;
        }
        if ((double) this.EventStudent[2].DistanceToDestination > 1.0 && this.EventStudent[2].Pathfinding.canMove)
        {
          if ((double) this.EventStudent[2].Pathfinding.speed == 1.0)
            this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
          else
            this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].SprintAnim);
        }
      }
      else
      {
        if ((double) this.EventStudent[1].DistanceToDestination > 1.0)
          this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
        if ((double) this.EventStudent[2].DistanceToDestination > 1.0)
          this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
      }
      if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[1].Private)
      {
        this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
        this.EventStudent[1].Private = true;
        this.StudentManager.UpdateStudents();
      }
      if ((double) Vector3.Distance(this.EventStudent[2].transform.position, this.EventLocation[2].position) < 1.0 && !this.EventStudent[2].Pathfinding.canMove && !this.StopWalking)
      {
        this.StopWalking = true;
        this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
        this.EventStudent[2].Private = true;
        this.StudentManager.UpdateStudents();
      }
      if (this.StopWalking && this.EventPhase == 1)
        this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
      if ((double) Vector3.Distance(this.EventStudent[1].transform.position, this.EventLocation[1].position) >= 1.0 || this.EventStudent[1].Pathfinding.canMove || this.EventStudent[2].Pathfinding.canMove)
        return;
      if (this.EventPhase == 1)
        this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
      if (this.Osana)
        this.SettleFriend();
      if (!this.Spoken)
      {
        this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade(this.EventAnim[this.EventPhase]);
        if ((double) num < 10.0)
          this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
        AudioClipPlayer.Play(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        this.Spoken = true;
      }
      else
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > (double) this.EventClip[this.EventPhase].length)
          this.EventSubtitle.text = string.Empty;
        if ((double) this.Yandere.transform.position.y < (double) this.EventStudent[1].transform.position.y - 1.0)
          this.EventSubtitle.transform.localScale = Vector3.zero;
        else if ((double) num < 10.0)
        {
          this.Scale = Mathf.Abs((float) (((double) num - 10.0) * 0.20000000298023224));
          if ((double) this.Scale < 0.0)
            this.Scale = 0.0f;
          if ((double) this.Scale > 1.0)
            this.Scale = 1f;
          this.Jukebox.Dip = (float) (1.0 - 0.5 * (double) this.Scale);
          this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
        }
        else
          this.EventSubtitle.transform.localScale = Vector3.zero;
        Animation characterAnimation = this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation;
        if ((double) characterAnimation[this.EventAnim[this.EventPhase]].time >= (double) characterAnimation[this.EventAnim[this.EventPhase]].length - 1.0)
          characterAnimation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].IdleAnim, 1f);
        if ((double) this.Timer > (double) this.EventClip[this.EventPhase].length + 1.0)
        {
          this.Spoken = false;
          ++this.EventPhase;
          this.Timer = 0.0f;
          if (this.EventPhase == this.EventSpeech.Length)
            this.EndEvent();
        }
        if (!this.Suitor && (double) this.Yandere.transform.position.y > (double) this.EventStudent[1].transform.position.y - 1.0 && this.EventPhase == 7 && (double) num < 5.0)
        {
          if (this.EventStudent1 == 25)
          {
            if (!EventGlobals.Event1)
            {
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
              EventGlobals.Event1 = true;
            }
          }
          else if (this.OsanaID < 2 && !this.Yandere.Police.EndOfDay.LearnedOsanaInfo2)
          {
            Debug.Log((object) "We just eavesdropped on Osana. Her profile should update.");
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
            this.Yandere.Police.EndOfDay.LearnedOsanaInfo2 = true;
            this.StudentManager.OsanaOfferHelp.Eavesdropped = true;
            if (SchemeGlobals.GetSchemeStage(6) == 2)
            {
              if (this.EventStudent[1].Friend)
                SchemeGlobals.SetSchemeStage(6, 4);
              else
                SchemeGlobals.SetSchemeStage(6, 3);
              this.Yandere.PauseScreen.Schemes.UpdateInstructions();
            }
          }
        }
      }
      if (!this.enabled)
        return;
      if ((double) num < 3.0)
        this.Yandere.Eavesdropping = true;
      else
        this.Yandere.Eavesdropping = false;
    }
  }

  private void SettleFriend()
  {
    this.EventStudent[2].MoveTowardsTarget(this.EventLocation[2].position);
    if ((double) Quaternion.Angle(this.EventStudent[2].transform.rotation, this.EventLocation[2].rotation) <= 1.0)
      return;
    this.EventStudent[2].transform.rotation = Quaternion.Slerp(this.EventStudent[2].transform.rotation, this.EventLocation[2].rotation, 10f * Time.deltaTime);
  }

  public void EndEvent()
  {
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    this.EventStudent[1].CurrentDestination = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
    this.EventStudent[1].Pathfinding.target = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
    this.EventStudent[1].EventManager = (EventManagerScript) null;
    this.EventStudent[1].InEvent = false;
    this.EventStudent[1].Private = false;
    this.EventStudent[2].CurrentDestination = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
    this.EventStudent[2].Pathfinding.target = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
    this.EventStudent[2].EventManager = (EventManagerScript) null;
    this.EventStudent[2].InEvent = false;
    this.EventStudent[2].Private = false;
    double startTime = (double) this.StartTime;
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Jukebox.Dip = 1f;
    this.Yandere.Eavesdropping = false;
    this.EventSubtitle.text = string.Empty;
    this.EventCheck = false;
    this.EventOn = false;
    this.enabled = false;
  }
}
