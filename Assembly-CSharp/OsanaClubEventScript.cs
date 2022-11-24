// Decompiled with JetBrains decompiler
// Type: OsanaClubEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaClubEventScript : MonoBehaviour
{
  public EventManagerScript RooftopConversation;
  public StudentManagerScript StudentManager;
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
  public int[] ClubIDs;
  public GameObject VoiceClip;
  public AudioSource VoiceClipSource;
  public bool ReachedTheEnd;
  public bool EventOn;
  public bool Spoken;
  public int EventPhase;
  public float Timer;
  public float Scale;
  public int[] StudentID;
  public DayOfWeek EventDay;

  private void Start()
  {
    if (DateGlobals.Weekday == this.EventDay && !GameGlobals.AlphabetMode && !MissionModeGlobals.MissionMode && !GameGlobals.Eighties)
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
    if (!this.EventOn)
    {
      for (int index = 1; index < 3; ++index)
      {
        if ((UnityEngine.Object) this.EventStudent[index] == (UnityEngine.Object) null)
          this.EventStudent[index] = this.StudentManager.Students[this.StudentID[index]];
        else if (!this.EventStudent[index].Alive || this.EventStudent[index].Slave)
          this.enabled = false;
      }
      if (!((UnityEngine.Object) this.EventStudent[1] != (UnityEngine.Object) null) || !((UnityEngine.Object) this.EventStudent[2] != (UnityEngine.Object) null) || !this.EventStudent[1].enabled || !this.EventStudent[1].Pathfinding.canMove || !this.EventStudent[2].Pathfinding.canMove || !this.EventStudent[1].Routine || this.EventStudent[1].Wet)
        return;
      Debug.Log((object) "Osana's club event has begun.");
      this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
      this.EventStudent[1].CurrentDestination = this.EventLocation[1];
      this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
      this.EventStudent[1].TargetDistance = 0.5f;
      this.EventStudent[1].Private = false;
      this.EventStudent[1].InEvent = true;
      this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
      this.EventStudent[2].CurrentDestination = this.EventLocation[2];
      this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
      this.EventStudent[2].TargetDistance = 1f;
      this.EventStudent[2].Private = false;
      this.EventStudent[2].InEvent = true;
      this.Yandere.PauseScreen.Hint.Show = true;
      this.Yandere.PauseScreen.Hint.QuickID = 16;
      this.EventOn = true;
    }
    else
    {
      float num = Vector3.Distance(this.Yandere.transform.position, (this.EventStudent[1].transform.position - this.EventStudent[2].transform.position) * 0.5f + this.EventStudent[2].transform.position);
      this.Yandere.Eavesdropping = this.EventPhase > 1 && this.EventPhase < 7 && (double) num < 3.0;
      if ((double) this.Clock.HourTime > 13.5 || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Alarmed || this.EventStudent[2].Alarmed || this.EventStudent[1].Dying || this.EventStudent[2].Dying || this.EventStudent[1].Splashed || this.EventStudent[1].Dodging || this.EventStudent[1].GoAway || this.Clock.Police.EndOfDay.gameObject.activeInHierarchy)
      {
        this.EndEvent();
      }
      else
      {
        for (int index = 1; index < 3; ++index)
        {
          if (!this.EventStudent[index].Pathfinding.canMove && !this.EventStudent[index].Private)
          {
            this.EventStudent[index].CharacterAnimation.CrossFade(this.EventStudent[index].IdleAnim);
            this.EventStudent[index].Private = true;
            this.StudentManager.UpdateStudents();
          }
        }
        if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
        {
          if (!this.Spoken)
          {
            this.EventStudent[this.EventSpeaker[1]].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
            this.EventStudent[this.EventSpeaker[2]].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
            this.EventStudent[this.EventSpeaker[this.EventPhase]].PickRandomAnim();
            this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].RandomAnim);
            AudioClipPlayer.Play(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.Spoken = true;
            if (this.EventSpeaker[this.EventPhase] != 1 || this.EventPhase <= 7 || this.EventPhase >= 33 || this.EventPhase == 24 || (double) num >= 10.0)
              return;
            if (this.EventPhase == 30)
            {
              Debug.Log((object) "Current EventPhase is: 30 and Osana is talking about the delinquents.");
              this.Yandere.NotificationManager.TopicName = "Violence";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
              this.StudentManager.SetTopicLearnedByStudent(this.ClubIDs[this.EventPhase], 11, true);
            }
            else
            {
              Debug.Log((object) ("Current EventPhase is: " + this.EventPhase.ToString() + " and ClubID is: " + this.ClubIDs[this.EventPhase].ToString()));
              this.Yandere.NotificationManager.TopicName = this.Yandere.NotificationManager.ClubNames[this.ClubIDs[this.EventPhase]];
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
              this.StudentManager.SetTopicLearnedByStudent(this.ClubIDs[this.EventPhase], 11, true);
            }
          }
          else
          {
            int index = this.EventSpeaker[this.EventPhase];
            if (index == 1)
              this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
            else
              this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
            if ((double) this.EventStudent[index].CharacterAnimation[this.EventStudent[index].RandomAnim].time >= (double) this.EventStudent[index].CharacterAnimation[this.EventStudent[index].RandomAnim].length)
            {
              this.EventStudent[index].PickRandomAnim();
              this.EventStudent[index].CharacterAnimation.CrossFade(this.EventStudent[index].RandomAnim);
            }
            this.Timer += Time.deltaTime;
            if ((double) this.Yandere.transform.position.y > (double) this.EventStudent[1].transform.position.y - 1.0 && (double) this.Yandere.transform.position.y < (double) this.EventStudent[1].transform.position.y + 1.0)
            {
              if ((UnityEngine.Object) this.VoiceClipSource != (UnityEngine.Object) null)
                this.VoiceClipSource.volume = 1f;
              if ((double) num < 11.0)
              {
                if ((double) num < 10.0)
                {
                  this.EventSubtitle.text = (double) this.Timer <= (double) this.EventClip[this.EventPhase].length ? this.EventSpeech[this.EventPhase] : string.Empty;
                  this.Scale = Mathf.Abs((float) (((double) num - 10.0) * 0.20000000298023224));
                  if ((double) this.Scale < 0.0)
                    this.Scale = 0.0f;
                  if ((double) this.Scale > 1.0)
                    this.Scale = 1f;
                  this.Jukebox.Dip = (float) (1.0 - 0.5 * (double) this.Scale);
                  this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
                }
                else
                {
                  this.EventSubtitle.transform.localScale = Vector3.zero;
                  this.EventSubtitle.text = string.Empty;
                }
              }
            }
            else if ((UnityEngine.Object) this.VoiceClipSource != (UnityEngine.Object) null)
              this.VoiceClipSource.volume = 0.0f;
            if ((double) this.Timer <= (double) this.EventClip[this.EventPhase].length + 0.5)
              return;
            this.Spoken = false;
            ++this.EventPhase;
            this.Timer = 0.0f;
            if (this.EventPhase == 4)
              this.RooftopConversation.CanHappen = true;
            if (this.EventPhase == this.EventSpeech.Length)
            {
              this.EndEvent();
            }
            else
            {
              if (this.EventPhase <= 6)
                return;
              this.EventStudent[1].CurrentDestination = this.EventLocation[this.EventPhase];
              this.EventStudent[1].Pathfinding.target = this.EventLocation[this.EventPhase];
              this.EventStudent[2].CurrentDestination = this.EventStudent[1].FollowTargetDestination;
              this.EventStudent[2].Pathfinding.target = this.EventStudent[1].FollowTargetDestination;
            }
          }
        }
        else
        {
          if (!this.EventStudent[1].Pathfinding.canMove)
            this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
          else
            this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
          if (!this.EventStudent[2].Pathfinding.canMove)
          {
            this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
            if (this.EventPhase != 1)
              return;
            this.SettleFriend();
          }
          else if ((double) this.EventStudent[2].Pathfinding.speed == 1.0)
            this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
          else
            this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].RunAnim);
        }
      }
    }
  }

  private void SettleFriend() => this.EventStudent[2].MoveTowardsTarget(this.EventStudent[2].Pathfinding.target.position);

  public void EndEvent()
  {
    Debug.Log((object) "Ending Osana's club event.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    for (int index = 1; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.EventStudent[index] != (UnityEngine.Object) null)
      {
        this.EventStudent[index].CurrentDestination = this.EventStudent[index].Destinations[this.EventStudent[index].Phase];
        this.EventStudent[index].Pathfinding.target = this.EventStudent[index].Destinations[this.EventStudent[index].Phase];
        this.EventStudent[index].InEvent = false;
        this.EventStudent[index].Private = false;
      }
    }
    this.CheckForRooftopConvo();
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Yandere.Eavesdropping = false;
    this.Jukebox.Dip = 1f;
    this.EventSubtitle.text = string.Empty;
    this.ReachedTheEnd = true;
    if (this.EventStudent[1].GoAway)
    {
      this.EventStudent[1].Subtitle.CustomText = "Ugh, seriously?! Guess we'll just talk about it later...";
      this.EventStudent[1].Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
    }
    this.enabled = false;
  }

  public void CheckForRooftopConvo()
  {
    if (!((UnityEngine.Object) this.StudentManager.Students[10] != (UnityEngine.Object) null) || !((UnityEngine.Object) this.StudentManager.Students[11] != (UnityEngine.Object) null) || !this.StudentManager.Students[11].Alive || this.StudentManager.Students[10].CurrentAction != StudentActionType.Follow)
      return;
    Debug.Log((object) "Osana's rooftop conversation with Raibaru can happen.");
    this.RooftopConversation.CanHappen = true;
  }
}
