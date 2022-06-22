// Decompiled with JetBrains decompiler
// Type: PhoneEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class PhoneEventScript : MonoBehaviour
{
  public OsanaClubEventScript OsanaClubEvent;
  public StudentManagerScript StudentManager;
  public BucketPourScript DumpPoint;
  public YandereScript Yandere;
  public JukeboxScript Jukebox;
  public ClockScript Clock;
  public StudentScript EventStudent;
  public StudentScript EventFriend;
  public UILabel EventSubtitle;
  public Transform EventLocation;
  public Transform SpyLocation;
  public AudioClip[] EventClip;
  public string[] EventSpeech;
  public float[] SpeechTimes;
  public string[] EventAnim;
  public GameObject VoiceClip;
  public bool EndedPrematurely;
  public bool EventActive;
  public bool EventCheck;
  public bool EventOver;
  public bool HintGiven;
  public int EventStudentID = 7;
  public int EventFriendID = 34;
  public float EventTime = 7.5f;
  public int EventPhase = 1;
  public DayOfWeek EventDay = DayOfWeek.Monday;
  public float CurrentClipLength;
  public float FailSafe;
  public float Timer;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Weekday == this.EventDay)
      this.EventCheck = true;
    if (!HomeGlobals.LateForSchool && !this.StudentManager.YandereLate && !GameGlobals.AlphabetMode && !MissionModeGlobals.MissionMode)
      return;
    this.enabled = false;
  }

  private void OnAwake()
  {
  }

  private void Update()
  {
    if (!this.Clock.StopTime && this.EventCheck)
    {
      if ((double) this.Clock.HourTime > (double) this.EventTime + 0.5)
        this.enabled = false;
      else if ((double) this.Clock.HourTime > (double) this.EventTime)
      {
        if ((UnityEngine.Object) this.EventStudent == (UnityEngine.Object) null)
          this.EventStudent = this.StudentManager.Students[this.EventStudentID];
        if ((UnityEngine.Object) this.EventStudent != (UnityEngine.Object) null && !this.EventStudent.InEvent && !this.EventStudent.Meeting && (double) this.EventStudent.DistanceToDestination < 1.0 && !this.EventStudent.Phoneless)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 1.0)
          {
            if ((UnityEngine.Object) this.OsanaClubEvent != (UnityEngine.Object) null && this.EventStudent.Alive)
              Debug.Log((object) "Osana's Monday morning phone event has begun.");
            this.EventStudent.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
            if (this.EventStudentID == 11)
            {
              this.EventFriend = this.StudentManager.Students[this.EventFriendID];
              if ((UnityEngine.Object) this.EventFriend != (UnityEngine.Object) null && this.EventFriend.CurrentAction == StudentActionType.Follow && !this.EventFriend.InvestigatingBloodPool && !this.EventFriend.ReturningMisplacedWeapon)
              {
                Debug.Log((object) "Raibaru is available, so she's getting involved in the event.");
                this.EventFriend.CharacterAnimation.CrossFade(this.EventFriend.IdleAnim);
                this.EventFriend.Pathfinding.canSearch = false;
                this.EventFriend.Pathfinding.canMove = false;
                this.EventFriend.TargetDistance = 0.5f;
                this.EventFriend.SpeechLines.Stop();
                this.EventFriend.PhoneEvent = this;
                this.EventFriend.CanTalk = false;
                this.EventFriend.Routine = false;
                this.EventFriend.InEvent = true;
                this.EventFriend.Prompt.Hide();
              }
            }
            if (this.EventStudent.enabled && this.EventStudent.Routine && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting && !this.EventStudent.Investigating && this.EventStudent.Indoors)
            {
              if (!this.EventStudent.WitnessedMurder)
              {
                this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
                this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
                this.EventStudent.Obstacle.checkTime = 99f;
                this.EventStudent.SpeechLines.Stop();
                this.EventStudent.PhoneEvent = this;
                this.EventStudent.CanTalk = false;
                this.EventStudent.InEvent = true;
                this.EventStudent.Prompt.Hide();
                this.EventCheck = false;
                this.EventActive = true;
                this.Timer = 0.0f;
                this.Yandere.PauseScreen.Hint.Show = true;
                this.Yandere.PauseScreen.Hint.QuickID = 15;
                if (this.EventStudent.Following)
                {
                  this.EventStudent.Pathfinding.canMove = true;
                  this.EventStudent.Pathfinding.speed = 1f;
                  this.EventStudent.Following = false;
                  this.EventStudent.Routine = true;
                  this.Yandere.Follower = (StudentScript) null;
                  --this.Yandere.Followers;
                  this.EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
                  this.EventStudent.Prompt.Label[0].text = "     Talk";
                }
              }
              else
                this.enabled = false;
            }
          }
        }
      }
    }
    if (!this.EventActive)
      return;
    if ((double) this.EventStudent.DistanceToDestination < 0.5)
    {
      this.EventStudent.Pathfinding.canSearch = false;
      this.EventStudent.Pathfinding.canMove = false;
    }
    if ((double) this.Clock.HourTime > (double) this.EventTime + 0.5 || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dodging || this.EventStudent.Dying || !this.EventStudent.Alive)
    {
      this.EndedPrematurely = true;
      this.EndEvent();
    }
    else
    {
      if (!this.EventStudent.Pathfinding.canMove)
      {
        if (this.EventPhase == 1)
        {
          this.Timer += Time.deltaTime;
          this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
          AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
          ++this.EventPhase;
        }
        else if (this.EventPhase == 2)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 1.5)
          {
            this.EventStudent.SmartPhone.SetActive(true);
            this.EventStudent.SmartPhone.transform.localPosition = new Vector3(0.01f, -0.005f, -0.025f);
            this.EventStudent.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -150f, 165f);
          }
          if ((double) this.Timer > 2.0)
          {
            AudioClipPlayer.Play(this.EventClip[1], this.EventStudent.transform.position, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
            this.EventSubtitle.text = this.EventSpeech[1];
            this.Timer = 0.0f;
            ++this.EventPhase;
          }
        }
        else if (this.EventPhase == 3)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > (double) this.CurrentClipLength)
          {
            this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.RunAnim);
            this.EventStudent.CurrentDestination = this.EventLocation;
            this.EventStudent.Pathfinding.target = this.EventLocation;
            this.EventStudent.Pathfinding.canSearch = true;
            this.EventStudent.Pathfinding.canMove = true;
            this.EventStudent.Pathfinding.speed = 4f;
            this.EventSubtitle.text = string.Empty;
            this.EventStudent.Hurry = true;
            Debug.Log((object) (this.EventStudent.Name + " has been given a pathfinding speed of 4."));
            this.Timer = 0.0f;
            ++this.EventPhase;
          }
        }
        else if (this.EventPhase == 4)
        {
          if (this.EventStudentID != 11)
            this.DumpPoint.enabled = true;
          this.EventStudent.Private = true;
          this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[2]);
          AudioClipPlayer.Play(this.EventClip[2], this.EventStudent.transform.position, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
          ++this.EventPhase;
        }
        else if (this.EventPhase < 13)
        {
          if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
          {
            this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
            this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time = this.VoiceClip.GetComponent<AudioSource>().time;
            if ((double) this.VoiceClip.GetComponent<AudioSource>().time > (double) this.SpeechTimes[this.EventPhase - 3])
            {
              this.EventSubtitle.text = this.EventSpeech[this.EventPhase - 3];
              ++this.EventPhase;
            }
          }
        }
        else
        {
          if ((double) this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time >= (double) this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].length * 90.3333282470703)
            this.EventStudent.SmartPhone.SetActive(true);
          if ((double) this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time >= (double) this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].length)
            this.EndEvent();
        }
        float num1 = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
        if ((double) num1 < 10.0)
        {
          float num2 = Mathf.Abs((float) (((double) num1 - 10.0) * 0.200000002980232));
          if ((double) num2 < 0.0)
            num2 = 0.0f;
          if ((double) num2 > 1.0)
            num2 = 1f;
          this.Jukebox.Dip = (float) (1.0 - 0.5 * (double) num2);
          this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
        }
        else
          this.EventSubtitle.transform.localScale = Vector3.zero;
        if (this.enabled && this.EventPhase > 4)
          this.Yandere.Eavesdropping = (double) num1 < 5.0;
        if (this.EventPhase == 11 && (double) num1 < 5.0)
        {
          if (this.EventStudentID == 30)
          {
            if (!EventGlobals.Event2)
            {
              EventGlobals.Event2 = true;
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
              ConversationGlobals.SetTopicDiscovered(25, true);
              this.Yandere.NotificationManager.TopicName = "Money";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
              this.Yandere.NotificationManager.TopicName = "Money";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
              ConversationGlobals.SetTopicLearnedByStudent(25, this.EventStudentID, true);
            }
          }
          else if (!this.Yandere.Police.EndOfDay.LearnedOsanaInfo1)
          {
            this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 = true;
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
            if (SchemeGlobals.GetSchemeStage(6) == 1)
            {
              SchemeGlobals.SetSchemeStage(6, 2);
              this.Yandere.PauseScreen.Schemes.UpdateInstructions();
            }
          }
        }
      }
      else
      {
        this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.RunAnim);
        this.EventStudent.Pathfinding.speed = 4f;
      }
      if (!this.EventStudent.Pathfinding.canMove && this.EventPhase <= 3 || !((UnityEngine.Object) this.EventFriend != (UnityEngine.Object) null) || this.EventFriend.CurrentAction != StudentActionType.Follow || !this.EventFriend.InEvent || this.EventPhase <= 3)
        return;
      if ((UnityEngine.Object) this.EventFriend.CurrentDestination != (UnityEngine.Object) this.SpyLocation)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 3.0)
        {
          this.EventFriend.CharacterAnimation.CrossFade(this.EventStudent.RunAnim);
          this.EventFriend.CurrentDestination = this.SpyLocation;
          this.EventFriend.Pathfinding.target = this.SpyLocation;
          this.EventFriend.Pathfinding.canSearch = true;
          this.EventFriend.Pathfinding.canMove = true;
          this.EventFriend.Pathfinding.speed = 4f;
          this.EventFriend.Routine = true;
          this.Timer = 0.0f;
        }
        else
        {
          this.EventFriend.targetRotation = Quaternion.LookRotation(this.StudentManager.Students[this.EventStudentID].transform.position - this.EventFriend.transform.position);
          this.EventFriend.transform.rotation = Quaternion.Slerp(this.EventFriend.transform.rotation, this.EventFriend.targetRotation, 10f * Time.deltaTime);
        }
      }
      else
      {
        if ((double) this.EventFriend.DistanceToDestination >= 1.0)
          return;
        this.EventFriend.CharacterAnimation.CrossFade("f02_cornerPeek_00");
        this.EventFriend.Pathfinding.canSearch = false;
        this.EventFriend.Pathfinding.canMove = false;
        this.SettleFriend();
      }
    }
  }

  private void SettleFriend()
  {
    this.EventFriend.MoveTowardsTarget(this.SpyLocation.position);
    if ((double) Quaternion.Angle(this.EventFriend.transform.rotation, this.SpyLocation.rotation) <= 1.0)
      return;
    this.EventFriend.transform.rotation = Quaternion.Slerp(this.EventFriend.transform.rotation, this.SpyLocation.rotation, 10f * Time.deltaTime);
  }

  private void EndEvent()
  {
    Debug.Log((object) "A phone event ended.");
    if (!this.EventOver)
    {
      this.EventStudent.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
      if ((UnityEngine.Object) this.EventFriend != (UnityEngine.Object) null && this.EventFriend.Alive && !this.EventFriend.Electrified && !this.EventFriend.Electrocuted && this.EventFriend.CurrentAction == StudentActionType.Follow && this.EventFriend.InEvent)
      {
        Debug.Log((object) "Raibaru is exiting the phone event.");
        this.EventFriend.CurrentDestination = this.EventFriend.Destinations[this.EventFriend.Phase];
        this.EventFriend.Pathfinding.target = this.EventFriend.Destinations[this.EventFriend.Phase];
        this.EventFriend.Obstacle.checkTime = 1f;
        this.EventFriend.Pathfinding.speed = 1f;
        this.EventFriend.TargetDistance = 1f;
        this.EventFriend.InEvent = false;
        this.EventFriend.Private = false;
        this.EventFriend.Routine = true;
        this.EventFriend.CanTalk = true;
        if (!this.EndedPrematurely)
          this.OsanaClubEvent.enabled = true;
      }
      this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Obstacle.checkTime = 1f;
      if (!this.EventStudent.Dying)
        this.EventStudent.Prompt.enabled = true;
      if (!this.EventStudent.WitnessedMurder)
        this.EventStudent.SmartPhone.SetActive(false);
      this.EventStudent.Pathfinding.speed = 1f;
      this.EventStudent.TargetDistance = 1f;
      this.EventStudent.PhoneEvent = (PhoneEventScript) null;
      this.EventStudent.InEvent = false;
      this.EventStudent.Private = false;
      this.EventStudent.CanTalk = true;
      this.EventSubtitle.text = string.Empty;
      this.StudentManager.UpdateStudents();
    }
    this.EventStudent.Hurry = false;
    this.Yandere.Eavesdropping = false;
    this.Jukebox.Dip = 1f;
    this.EventActive = false;
    this.EventCheck = false;
    this.enabled = false;
  }
}
