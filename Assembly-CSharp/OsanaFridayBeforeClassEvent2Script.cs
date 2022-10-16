// Decompiled with JetBrains decompiler
// Type: OsanaFridayBeforeClassEvent2Script
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaFridayBeforeClassEvent2Script : MonoBehaviour
{
  public OsanaFridayBeforeClassEvent1Script OtherEvent;
  public StudentManagerScript StudentManager;
  public AudioSoftwareScript AudioSoftware;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public SpyScript Spy;
  public StudentScript Ganguro;
  public StudentScript Friend;
  public StudentScript Rival;
  public Transform[] Location;
  public AudioClip[] SpeechClip;
  public string[] SpeechText;
  public float[] SpeechTime;
  public string[] EventAnim;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public Quaternion targetRotation;
  public float Distance;
  public float Scale;
  public float Timer;
  public DayOfWeek EventDay;
  public int SpeechPhase = 1;
  public int GanguroID = 81;
  public int FriendID = 10;
  public int RivalID = 11;
  public int Phase;
  public int Frame;
  public bool IgnoreFriend;
  public Vector3 OriginalPosition;
  public Vector3 OriginalRotation;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Weekday == this.EventDay && !StudentGlobals.GetStudentKidnapped(this.RivalID) && StudentGlobals.StudentSlave != this.RivalID && StudentGlobals.StudentSlave != 81 && !StudentGlobals.GetStudentDead(81) && !StudentGlobals.GetStudentKidnapped(81) && !StudentGlobals.GetStudentArrested(81) && !StudentGlobals.GetStudentExpelled(81) && (double) StudentGlobals.GetStudentReputation(81) >= -33.333328247070313 && !GameGlobals.Eighties)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      if (this.Frame > 0 && (UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[this.GanguroID] != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.Ganguro == (UnityEngine.Object) null)
          this.Ganguro = this.StudentManager.Students[this.GanguroID];
        if ((UnityEngine.Object) this.Rival == (UnityEngine.Object) null)
          this.Rival = this.StudentManager.Students[this.RivalID];
        if ((UnityEngine.Object) this.Friend == (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[this.FriendID] != (UnityEngine.Object) null && !PlayerGlobals.RaibaruLoner)
          this.Friend = this.StudentManager.Students[this.FriendID];
        if ((double) this.Clock.HourTime > 7.25 && this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Meeting && this.Rival.Indoors && !this.Rival.Wet && !this.Rival.Following && !this.Rival.Meeting && (UnityEngine.Object) this.Rival.Pathfinding.target == (UnityEngine.Object) this.Rival.Destinations[2] && (double) this.Rival.DistanceToDestination < 1.0 && !this.Rival.Phoneless && !this.Rival.EndSearch)
        {
          Debug.Log((object) "Osana's ''Talk with Musume'' event has begun.");
          this.Ganguro.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
          this.Ganguro.CharacterAnimation.CrossFade(this.Ganguro.SprintAnim);
          this.Ganguro.Pathfinding.target = this.Rival.transform;
          this.Ganguro.CurrentDestination = this.Rival.transform;
          this.Ganguro.Pathfinding.canSearch = true;
          this.Ganguro.Pathfinding.canMove = true;
          this.Ganguro.Pathfinding.speed = 4f;
          this.Ganguro.SpeechLines.Stop();
          this.Ganguro.Routine = false;
          this.Ganguro.InEvent = true;
          this.Rival.InEvent = true;
          if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null && this.Friend.CurrentAction != StudentActionType.Follow)
          {
            this.IgnoreFriend = true;
            this.Friend = (StudentScript) null;
          }
          this.Yandere.PauseScreen.Hint.Show = true;
          this.Yandere.PauseScreen.Hint.QuickID = 24;
          ++this.Phase;
        }
      }
      ++this.Frame;
    }
    else
    {
      if (this.Phase == 1)
      {
        Input.GetKeyDown(KeyCode.Space);
        if ((double) this.Ganguro.DistanceToDestination < 1.0)
        {
          AudioClipPlayer.Play(this.SpeechClip[1], this.Ganguro.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.Rival.CharacterAnimation.CrossFade(this.EventAnim[1]);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.Rival.Obstacle.enabled = true;
          this.Rival.SpeechLines.Stop();
          this.Rival.Routine = false;
          this.Rival.InEvent = true;
          this.Ganguro.CharacterAnimation.CrossFade(this.EventAnim[2]);
          this.Ganguro.Pathfinding.canSearch = false;
          this.Ganguro.Pathfinding.canMove = false;
          this.Ganguro.Obstacle.enabled = true;
          this.EventSubtitle.text = this.SpeechText[1];
          ++this.Phase;
        }
      }
      else if (this.Phase == 2)
      {
        this.targetRotation = Quaternion.LookRotation(this.Ganguro.transform.position - this.Rival.transform.position);
        this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        this.targetRotation = Quaternion.LookRotation(this.Rival.transform.position - this.Ganguro.transform.position);
        this.Ganguro.transform.rotation = Quaternion.Slerp(this.Ganguro.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[1]].time >= 4.0)
        {
          this.EventSubtitle.text = this.SpeechText[2];
          this.Ganguro.Pathfinding.speed = 1f;
          ++this.Phase;
        }
        if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
          this.Friend.Distracted = true;
      }
      else if (this.Phase == 3)
      {
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[1]].time >= (double) this.Rival.CharacterAnimation[this.EventAnim[1]].length)
        {
          this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
          this.Rival.Pathfinding.target = this.Location[1];
          this.Rival.CurrentDestination = this.Location[1];
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Ganguro.CharacterAnimation.CrossFade(this.Ganguro.WalkAnim);
          this.Ganguro.Pathfinding.target = this.Location[2];
          this.Ganguro.CurrentDestination = this.Location[2];
          this.Ganguro.Pathfinding.canSearch = true;
          this.Ganguro.Pathfinding.canMove = true;
          this.Spy.Prompt.enabled = true;
          ++this.Phase;
        }
      }
      else if (this.Phase == 4)
      {
        if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null && (double) this.Rival.DistanceToDestination < 5.0)
        {
          this.Friend.CurrentDestination = this.Location[3];
          this.Friend.Pathfinding.target = this.Location[3];
          this.Friend.DistanceToDestination = 0.5f;
          this.Friend.IdleAnim = "f02_spying_00";
          this.Friend.SlideIn = true;
        }
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
          this.SettleRival();
        }
        if ((double) this.Ganguro.DistanceToDestination < 0.5)
        {
          this.Ganguro.CharacterAnimation.CrossFade(this.Ganguro.IdleAnim);
          this.SettleGanguro();
        }
        if ((double) this.Rival.DistanceToDestination < 0.5 && (double) this.Ganguro.DistanceToDestination < 0.5)
        {
          AudioClipPlayer.Play(this.SpeechClip[2], this.Ganguro.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.Rival.CharacterAnimation.CrossFade(this.EventAnim[3]);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.Rival.Obstacle.enabled = true;
          this.Ganguro.CharacterAnimation.CrossFade(this.EventAnim[4]);
          this.Ganguro.Pathfinding.canSearch = false;
          this.Ganguro.Pathfinding.canMove = false;
          this.Ganguro.Obstacle.enabled = true;
          ++this.Phase;
        }
      }
      else if (this.Phase == 5)
      {
        this.Timer += Time.deltaTime;
        if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
          this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
        if (this.SpeechPhase < this.SpeechTime.Length && (double) this.Timer > (double) this.SpeechTime[this.SpeechPhase])
        {
          this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
          ++this.SpeechPhase;
        }
        if ((double) this.Timer > 3.9 && this.Spy.CanRecord)
        {
          this.Spy.PromptBar.Label[0].text = "";
          this.Spy.PromptBar.UpdateButtons();
          this.Spy.CanRecord = false;
        }
        this.SettleRival();
        this.SettleGanguro();
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[3]].time >= (double) this.Rival.CharacterAnimation[this.EventAnim[3]].length)
          this.EndEvent();
      }
      if (this.Rival.Alarmed || (double) this.Clock.HourTime > 8.0 || this.Rival.Splashed || this.Rival.GoAway)
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
        if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
          this.VoiceClip.GetComponent<AudioSource>().volume = this.Scale;
      }
      else
      {
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
    Debug.Log((object) "Osana's second Friday before class event has ended.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if ((UnityEngine.Object) this.Rival != (UnityEngine.Object) null)
    {
      if (this.Rival.enabled && !this.Rival.Alarmed)
      {
        this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
        this.Rival.DistanceToDestination = 100f;
        this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
        this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
        this.Rival.Pathfinding.canSearch = true;
        this.Rival.Pathfinding.canMove = true;
        this.Rival.Routine = true;
      }
      this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      this.Rival.Obstacle.enabled = false;
      this.Rival.Prompt.enabled = true;
      this.Rival.InEvent = false;
      this.Rival.Private = false;
      if (!this.Ganguro.Alarmed)
      {
        this.Ganguro.CharacterAnimation.CrossFade(this.Ganguro.WalkAnim);
        this.Ganguro.DistanceToDestination = 100f;
        this.Ganguro.CurrentDestination = this.Ganguro.Destinations[this.Ganguro.Phase];
        this.Ganguro.Pathfinding.target = this.Ganguro.Destinations[this.Ganguro.Phase];
        this.Ganguro.Pathfinding.canSearch = true;
        this.Ganguro.Pathfinding.canMove = true;
        this.Ganguro.Routine = true;
      }
      this.Ganguro.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      this.Ganguro.Obstacle.enabled = false;
      this.Ganguro.Prompt.enabled = true;
      this.Ganguro.InEvent = false;
      this.Ganguro.Private = false;
      if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
      {
        this.Friend.CurrentDestination = this.Friend.FollowTarget.transform;
        this.Friend.Pathfinding.target = this.Friend.FollowTarget.transform;
        this.Friend.IdleAnim = this.Friend.OriginalIdleAnim;
        this.Friend.DistanceToDestination = 1f;
        this.Friend.SlideIn = false;
        this.Friend.Distracted = false;
      }
    }
    this.Spy.Prompt.enabled = false;
    this.Spy.Prompt.Hide();
    if (this.Spy.Phase > 0)
      this.Spy.End();
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    if (this.Spy.Recording)
      this.AudioSoftware.ConversationRecorded = true;
    this.EventSubtitle.text = string.Empty;
    this.Jukebox.Dip = 0.0f;
    this.enabled = false;
    if (!this.Rival.GoAway)
      return;
    this.Rival.Subtitle.CustomText = "Ugh, seriously?! I'm not in the mood for this...";
    this.Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
  }

  private void SettleRival()
  {
    if (!this.Rival.GoAway)
      this.Rival.MoveTowardsTarget(this.Location[1].position);
    if ((double) Quaternion.Angle(this.Rival.transform.rotation, this.Location[1].rotation) <= 1.0)
      return;
    this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location[1].rotation, 10f * Time.deltaTime);
  }

  private void SettleGanguro()
  {
    if (!this.Ganguro.GoAway)
      this.Ganguro.MoveTowardsTarget(this.Location[2].position);
    if ((double) Quaternion.Angle(this.Ganguro.transform.rotation, this.Location[2].rotation) <= 1.0)
      return;
    this.Ganguro.transform.rotation = Quaternion.Slerp(this.Ganguro.transform.rotation, this.Location[2].rotation, 10f * Time.deltaTime);
  }
}
