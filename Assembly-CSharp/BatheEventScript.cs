// Decompiled with JetBrains decompiler
// Type: BatheEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class BatheEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript EventStudent;
  public UILabel EventSubtitle;
  public AudioClip[] EventClip;
  public string[] EventSpeech;
  public string[] EventAnim;
  public GameObject RivalPhone;
  public GameObject VoiceClip;
  public bool EventActive;
  public bool EventOver;
  public float EventTime = 15.1f;
  public int EventPhase = 1;
  public DayOfWeek EventDay = DayOfWeek.Thursday;
  public Vector3 OriginalPosition;
  public float CurrentClipLength;
  public float Timer;

  private void Start()
  {
    this.RivalPhone.SetActive(false);
    if (DateGlobals.Weekday == this.EventDay)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (!this.Clock.StopTime && !this.EventActive && (double) this.Clock.HourTime > (double) this.EventTime)
    {
      this.EventStudent = this.StudentManager.Students[30];
      if ((UnityEngine.Object) this.EventStudent != (UnityEngine.Object) null && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting && this.EventStudent.Indoors)
      {
        if (!this.EventStudent.WitnessedMurder)
        {
          this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition;
          this.EventStudent.CurrentDestination = this.StudentManager.FemaleStripSpot;
          this.EventStudent.Pathfinding.target = this.StudentManager.FemaleStripSpot;
          this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.WalkAnim);
          this.EventStudent.Pathfinding.canSearch = true;
          this.EventStudent.Pathfinding.canMove = true;
          this.EventStudent.Pathfinding.speed = 1f;
          this.EventStudent.SpeechLines.Stop();
          this.EventStudent.DistanceToDestination = 100f;
          this.EventStudent.SmartPhone.SetActive(false);
          this.EventStudent.Obstacle.checkTime = 99f;
          this.EventStudent.InEvent = true;
          this.EventStudent.Private = true;
          this.EventStudent.Prompt.Hide();
          this.EventStudent.Hearts.Stop();
          this.EventActive = true;
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
    if (!this.EventActive)
      return;
    if ((double) this.Clock.HourTime > (double) this.EventTime + 1.0 || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Dodging || this.EventStudent.Alarmed || this.EventStudent.Dying || !this.EventStudent.Alive)
    {
      this.EndEvent();
    }
    else
    {
      if ((double) this.EventStudent.DistanceToDestination < 0.5)
      {
        if (this.EventPhase == 1)
        {
          this.EventStudent.Routine = false;
          this.EventStudent.BathePhase = 1;
          this.EventStudent.Wet = true;
          ++this.EventPhase;
        }
        else if (this.EventPhase == 2)
        {
          if (this.EventStudent.BathePhase == 4)
          {
            this.RivalPhone.SetActive(true);
            ++this.EventPhase;
          }
        }
        else if (this.EventPhase == 3 && !this.EventStudent.Wet)
          this.EndEvent();
      }
      if (this.EventPhase == 4)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > (double) this.CurrentClipLength + 1.0)
        {
          this.EventStudent.Routine = true;
          this.EndEvent();
        }
      }
      float num1 = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
      if ((double) num1 >= 11.0)
        return;
      if ((double) num1 < 10.0)
      {
        float num2 = Mathf.Abs((float) (((double) num1 - 10.0) * 0.20000000298023224));
        if ((double) num2 < 0.0)
          num2 = 0.0f;
        if ((double) num2 > 1.0)
          num2 = 1f;
        this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
      }
      else
        this.EventSubtitle.transform.localScale = Vector3.zero;
    }
  }

  private void EndEvent()
  {
    if (!this.EventOver)
    {
      if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
      this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Obstacle.checkTime = 1f;
      if (!this.EventStudent.Dying)
      {
        this.EventStudent.Prompt.enabled = true;
        this.EventStudent.Pathfinding.canSearch = true;
        this.EventStudent.Pathfinding.canMove = true;
        this.EventStudent.Pathfinding.speed = 1f;
        this.EventStudent.TargetDistance = 1f;
        this.EventStudent.Private = false;
      }
      this.EventStudent.InEvent = false;
      this.EventSubtitle.text = string.Empty;
      this.StudentManager.UpdateStudents();
    }
    this.EventActive = false;
    this.enabled = false;
  }
}
