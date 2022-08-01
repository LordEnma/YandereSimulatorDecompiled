// Decompiled with JetBrains decompiler
// Type: ToiletEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class ToiletEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public LightSwitchScript LightSwitch;
  public BucketPourScript BucketPour;
  public ParticleSystem Splashes;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public DoorScript StallDoor;
  public PromptScript Prompt;
  public ClockScript Clock;
  public Collider Toilet;
  public StudentScript EventStudent;
  public Transform[] EventLocation;
  public AudioClip[] EventClip;
  public string[] EventSpeech;
  public string[] EventAnim;
  public GameObject VoiceClip;
  public bool EventActive;
  public bool EventCheck;
  public bool EventOver;
  public float EventTime = 7f;
  public int EventPhase = 1;
  public DayOfWeek EventDay = DayOfWeek.Thursday;
  public float ToiletCountdown;
  public float Distance;
  public float Timer;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Weekday != this.EventDay)
      return;
    this.EventCheck = true;
  }

  private void Update()
  {
    if (!this.Clock.StopTime && this.EventCheck && (double) this.Clock.HourTime > (double) this.EventTime)
    {
      this.EventStudent = this.StudentManager.Students[30];
      if ((UnityEngine.Object) this.EventStudent != (UnityEngine.Object) null && this.EventStudent.Routine && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Alarmed && !this.EventStudent.Meeting)
      {
        if (!this.EventStudent.WitnessedMurder)
        {
          this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.WalkAnim);
          this.EventStudent.CurrentDestination = this.EventLocation[1];
          this.EventStudent.Pathfinding.target = this.EventLocation[1];
          this.EventStudent.Pathfinding.canSearch = true;
          this.EventStudent.Pathfinding.canMove = true;
          this.EventStudent.LightSwitch = this.LightSwitch;
          this.EventStudent.Obstacle.checkTime = 99f;
          this.EventStudent.SpeechLines.Stop();
          this.EventStudent.ToiletEvent = this;
          this.EventStudent.InEvent = true;
          this.EventStudent.Prompt.Hide();
          this.Prompt.enabled = true;
          this.EventCheck = false;
          this.EventActive = true;
          if (this.EventStudent.Following)
          {
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
    if (this.EventActive)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Yandere.EmptyHands();
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.EventPhase = 5;
        this.Timer = 0.0f;
        AudioClipPlayer.Play(this.EventClip[1], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
        this.EventSubtitle.text = this.EventSpeech[1];
        this.EventStudent.MyController.enabled = false;
        this.EventStudent.Distracted = true;
        this.EventStudent.Routine = false;
        this.EventStudent.Drowned = true;
        this.Yandere.TargetStudent = this.EventStudent;
        this.Yandere.Attacking = true;
        this.Yandere.CanMove = false;
        this.Yandere.Drown = true;
        this.Yandere.DrownAnim = "f02_toiletDrownA_00";
        this.EventStudent.DrownAnim = "f02_toiletDrownB_00";
        this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.DrownAnim);
      }
      if ((double) this.Clock.HourTime > (double) this.EventTime + 0.5 || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Dying || this.EventStudent.Alarmed)
        this.EndEvent();
      else if (!this.EventStudent.Pathfinding.canMove)
      {
        if (this.EventPhase == 1)
        {
          if ((double) this.Timer == 0.0)
          {
            this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.IdleAnim);
            this.Prompt.HideButton[0] = false;
            this.EventStudent.Prompt.Hide();
            this.EventStudent.Prompt.enabled = false;
            this.StallDoor.Prompt.enabled = false;
            this.StallDoor.Prompt.Hide();
          }
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 3.0)
          {
            this.StallDoor.Locked = true;
            this.StallDoor.CloseDoor();
            this.Toilet.enabled = false;
            this.Prompt.Hide();
            this.Prompt.enabled = false;
            this.EventStudent.CurrentDestination = this.EventLocation[2];
            this.EventStudent.Pathfinding.target = this.EventLocation[2];
            this.EventStudent.TargetDistance = 2f;
            ++this.EventPhase;
            this.Timer = 0.0f;
          }
        }
        else if (this.EventPhase == 2)
        {
          if ((double) this.Timer == 0.0)
          {
            this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[1]);
            this.BucketPour.enabled = true;
          }
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 10.0)
          {
            AudioClipPlayer.Play(this.EventClip[2], this.Toilet.transform.position, 5f, 10f, out this.VoiceClip);
            ++this.EventPhase;
            this.Timer = 0.0f;
          }
        }
        else if (this.EventPhase == 3)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 4.0)
          {
            this.EventStudent.CurrentDestination = this.EventLocation[3];
            this.EventStudent.Pathfinding.target = this.EventLocation[3];
            this.EventStudent.TargetDistance = 2f;
            this.StallDoor.gameObject.SetActive(true);
            this.StallDoor.Prompt.enabled = true;
            this.StallDoor.Locked = false;
            ++this.EventPhase;
            this.Timer = 0.0f;
          }
        }
        else if (this.EventPhase == 4)
        {
          this.EventStudent.Character.GetComponent<Animation>().CrossFade("f02_washHands_00");
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 5.0)
            this.EndEvent();
        }
        else if (this.EventPhase == 5)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 9.0)
          {
            this.Splashes.Stop();
            this.EventOver = true;
            this.EndEvent();
          }
          else if ((double) this.Timer > 3.0)
          {
            this.EventSubtitle.text = string.Empty;
            this.Splashes.Play();
          }
        }
        this.Distance = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
        if ((double) this.Distance < 10.0)
        {
          float num = Mathf.Abs((float) (((double) this.Distance - 10.0) * 0.200000002980232));
          if ((double) num < 0.0)
            num = 0.0f;
          if ((double) num > 1.0)
            num = 1f;
          this.EventSubtitle.transform.localScale = new Vector3(num, num, num);
        }
        else
          this.EventSubtitle.transform.localScale = Vector3.zero;
      }
    }
    if ((double) this.ToiletCountdown <= 0.0)
      return;
    this.ToiletCountdown -= Time.deltaTime;
    if ((double) this.ToiletCountdown >= 0.0)
      return;
    this.Toilet.enabled = true;
  }

  public void EndEvent()
  {
    if (!this.EventOver)
    {
      if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
      this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Obstacle.checkTime = 1f;
      if (!this.EventStudent.Dying)
        this.EventStudent.Prompt.enabled = true;
      this.EventStudent.TargetDistance = 1f;
      this.EventStudent.ToiletEvent = (ToiletEventScript) null;
      this.EventStudent.InEvent = false;
      this.EventStudent.Private = false;
      this.EventSubtitle.text = string.Empty;
      this.StudentManager.UpdateStudents();
    }
    this.StallDoor.gameObject.SetActive(true);
    this.StallDoor.Prompt.enabled = true;
    this.StallDoor.Locked = false;
    this.BucketPour.enabled = false;
    this.BucketPour.Prompt.Hide();
    this.BucketPour.Prompt.enabled = false;
    this.EventActive = false;
    this.EventCheck = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.ToiletCountdown = 1f;
  }
}
