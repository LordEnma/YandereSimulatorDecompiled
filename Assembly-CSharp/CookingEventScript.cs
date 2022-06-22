// Decompiled with JetBrains decompiler
// Type: CookingEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class CookingEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public RefrigeratorScript Snacks;
  public SchemesScript Schemes;
  public YandereScript Yandere;
  public ClockScript Clock;
  public GameObject Refrigerator;
  public GameObject RivalPhone;
  public GameObject Octodog;
  public GameObject Sausage;
  public Transform CookingClub;
  public Transform JarLid;
  public Transform Knife;
  public Transform Plate;
  public Transform Jar;
  public Transform[] Octodogs;
  public StudentScript EventStudent;
  public UILabel EventSubtitle;
  public Transform[] EventLocations;
  public AudioClip[] EventClip;
  public string[] EventSpeech;
  public string[] EventAnim;
  public int[] ClubMembers;
  public GameObject VoiceClip;
  public bool EventActive;
  public bool EventCheck;
  public bool EventOver;
  public int EventStudentID;
  public float EventTime = 7f;
  public int EventPhase = 1;
  public DayOfWeek EventDay = DayOfWeek.Tuesday;
  public int Loop;
  public float CurrentClipLength;
  public float Rotation;
  public float Timer;

  private void Start()
  {
    this.Octodog.SetActive(false);
    this.Sausage.SetActive(false);
    this.Rotation = -90f;
    foreach (Component octodog in this.Octodogs)
      octodog.gameObject.SetActive(false);
    this.EventSubtitle.transform.localScale = Vector3.zero;
    this.EventCheck = true;
    if (!ClubGlobals.GetClubClosed(ClubType.Cooking))
      return;
    this.enabled = false;
  }

  private void Update()
  {
    Input.GetKeyDown(KeyCode.Space);
    if (!this.Clock.StopTime && this.EventCheck && (double) this.Clock.HourTime > (double) this.EventTime)
    {
      this.EventStudent = this.StudentManager.Students[this.EventStudentID];
      if ((UnityEngine.Object) this.EventStudent != (UnityEngine.Object) null && !this.EventStudent.Distracted && (double) this.EventStudent.MeetTime == 0.0 && !this.EventStudent.Meeting && !this.EventStudent.Wet)
      {
        if (!this.EventStudent.WitnessedMurder)
        {
          this.Snacks.Prompt.Hide();
          this.Snacks.Prompt.enabled = false;
          this.Snacks.enabled = false;
          this.EventStudent.CurrentDestination = this.EventLocations[0];
          this.EventStudent.Pathfinding.target = this.EventLocations[0];
          this.EventStudent.Scrubber.SetActive(false);
          this.EventStudent.Eraser.SetActive(false);
          this.EventStudent.Obstacle.checkTime = 99f;
          this.EventStudent.CookingEvent = this;
          this.EventStudent.InEvent = true;
          this.EventStudent.Private = true;
          this.EventStudent.Prompt.Hide();
          this.EventCheck = false;
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
    if ((double) this.Clock.HourTime > (double) this.EventTime + 0.5 || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || this.EventStudent.Yandere.Cooking)
    {
      this.EndEvent();
    }
    else
    {
      if ((double) this.EventStudent.DistanceToDestination >= 1.0)
        return;
      if (this.EventPhase == -1)
      {
        this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.0)
        {
          SchemeGlobals.SetSchemeStage(4, 5);
          this.Schemes.UpdateInstructions();
          this.RivalPhone.SetActive(false);
          this.EventSubtitle.text = string.Empty;
          ++this.EventPhase;
          this.Timer = 0.0f;
        }
      }
      else if (this.EventPhase == 0)
      {
        if (!this.RivalPhone.activeInHierarchy)
        {
          this.EventStudent.CharacterAnimation.Play("f02_prepareFood_00");
          this.EventStudent.SmartPhone.SetActive(false);
          this.Octodog.transform.parent = this.EventStudent.RightHand;
          this.Octodog.transform.localPosition = new Vector3(0.0129f, -0.02475f, 0.0316f);
          this.Octodog.transform.localEulerAngles = new Vector3(-90f, 0.0f, 0.0f);
          this.Sausage.transform.parent = this.EventStudent.RightHand;
          this.Sausage.transform.localPosition = new Vector3(0.013f, -0.038f, 0.015f);
          this.Sausage.transform.localEulerAngles = Vector3.zero;
          ++this.EventPhase;
        }
        else
        {
          AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position + Vector3.up, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
          this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
          this.EventSubtitle.text = this.EventSpeech[0];
          --this.EventPhase;
        }
      }
      else if (this.EventPhase == 1)
      {
        this.EventStudent.CharacterAnimation.Play("f02_prepareFood_00");
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 1.0)
          ++this.EventPhase;
      }
      else if (this.EventPhase == 2)
      {
        this.Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 3.0)
        {
          this.Jar.transform.parent = this.EventStudent.RightHand;
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 3)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 5.0)
        {
          this.JarLid.transform.parent = this.EventStudent.LeftHand;
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 4)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 6.0)
        {
          this.JarLid.transform.parent = this.CookingClub;
          this.JarLid.transform.localPosition = new Vector3(0.334585f, 1f, -0.2528915f);
          this.JarLid.transform.localEulerAngles = new Vector3(0.0f, 30f, 0.0f);
          this.Jar.transform.parent = this.CookingClub;
          this.Jar.transform.localPosition = new Vector3(0.29559f, 1f, 0.2029152f);
          this.Jar.transform.localEulerAngles = new Vector3(0.0f, -150f, 0.0f);
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 5)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 7.0)
        {
          this.Knife.GetComponent<WeaponScript>().FingerprintID = this.EventStudent.StudentID;
          this.Knife.parent = this.EventStudent.LeftHand;
          this.Knife.localPosition = new Vector3(0.0f, -0.01f, 0.0f);
          this.Knife.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 6)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time >= (double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length)
        {
          this.EventStudent.CharacterAnimation.CrossFade("f02_cutFood_00");
          this.Sausage.SetActive(true);
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 7)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_cutFood_00"].time > 2.66666007041931)
        {
          this.Octodog.SetActive(true);
          this.Sausage.SetActive(false);
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 8)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_cutFood_00"].time > 3.0)
        {
          this.Rotation = Mathf.MoveTowards(this.Rotation, 90f, Time.deltaTime * 360f);
          this.Octodog.transform.localEulerAngles = new Vector3(this.Rotation, this.Octodog.transform.localEulerAngles.y, this.Octodog.transform.localEulerAngles.z);
          this.Octodog.transform.localPosition = new Vector3(this.Octodog.transform.localPosition.x, this.Octodog.transform.localPosition.y, Mathf.MoveTowards(this.Octodog.transform.localPosition.z, 0.012f, Time.deltaTime));
        }
        if ((double) this.EventStudent.CharacterAnimation["f02_cutFood_00"].time > 6.0)
        {
          this.Octodog.SetActive(false);
          this.Octodogs[this.Loop].gameObject.SetActive(true);
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 9)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_cutFood_00"].time >= (double) this.EventStudent.CharacterAnimation["f02_cutFood_00"].length)
        {
          if (this.Loop < this.Octodogs.Length - 1)
          {
            this.Octodog.transform.localEulerAngles = new Vector3(-90f, this.Octodog.transform.localEulerAngles.y, this.Octodog.transform.localEulerAngles.z);
            this.Octodog.transform.localPosition = new Vector3(this.Octodog.transform.localPosition.x, this.Octodog.transform.localPosition.y, 0.0316f);
            this.EventStudent.CharacterAnimation["f02_cutFood_00"].time = 0.0f;
            this.EventStudent.CharacterAnimation.Play("f02_cutFood_00");
            this.Sausage.SetActive(true);
            this.EventPhase = 7;
            this.Rotation = -90f;
            ++this.Loop;
          }
          else
          {
            this.EventStudent.CharacterAnimation.Play("f02_prepareFood_00");
            this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time = this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length;
            this.EventStudent.CharacterAnimation["f02_prepareFood_00"].speed = -1f;
            ++this.EventPhase;
          }
        }
      }
      else if (this.EventPhase == 10)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time < (double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 1.0)
        {
          this.Knife.parent = this.CookingClub;
          this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
          this.Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 11)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time < (double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 2.0)
        {
          this.JarLid.parent = this.EventStudent.LeftHand;
          this.Jar.parent = this.EventStudent.RightHand;
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 12)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time < (double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 3.0)
        {
          this.JarLid.parent = this.Jar;
          this.JarLid.localPosition = new Vector3(0.0f, 0.175f, 0.0f);
          this.JarLid.localEulerAngles = Vector3.zero;
          this.Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
          this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].time = this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].length;
          this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].speed = -1f;
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 13)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time < (double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 5.0)
        {
          this.Jar.parent = this.CookingClub;
          this.Jar.localPosition = new Vector3(0.1f, 0.941f, 0.75f);
          this.Jar.localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 14)
      {
        if ((double) this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time <= 0.0)
        {
          this.Knife.GetComponent<Collider>().enabled = true;
          this.Plate.parent = this.EventStudent.RightHand;
          this.Plate.localPosition = new Vector3(0.0f, 11f / 1000f, -0.156765f);
          this.Plate.localEulerAngles = new Vector3(0.0f, -90f, -180f);
          this.EventStudent.CurrentDestination = this.EventLocations[1];
          this.EventStudent.Pathfinding.target = this.EventLocations[1];
          this.EventStudent.CharacterAnimation[this.EventStudent.CarryAnim].weight = 1f;
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 15)
      {
        this.Plate.parent = this.CookingClub;
        this.Plate.localPosition = new Vector3(-3.66666f, 0.9066666f, -2.379f);
        this.Plate.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
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
        this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
      }
      else
      {
        if ((double) num1 >= 11.0)
          return;
        this.EventSubtitle.transform.localScale = Vector3.zero;
      }
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
        this.EventStudent.Prompt.enabled = true;
      if ((UnityEngine.Object) this.Plate.parent == (UnityEngine.Object) this.EventStudent.RightHand)
      {
        this.Plate.parent = (Transform) null;
        this.Plate.GetComponent<Rigidbody>().useGravity = true;
        this.Plate.GetComponent<BoxCollider>().enabled = true;
      }
      this.EventStudent.CharacterAnimation[this.EventStudent.CarryAnim].weight = 0.0f;
      this.EventStudent.SmartPhone.SetActive(false);
      this.EventStudent.Pathfinding.speed = 1f;
      this.EventStudent.TargetDistance = 1f;
      this.EventStudent.PhoneEvent = (PhoneEventScript) null;
      this.EventStudent.InEvent = false;
      this.EventStudent.Private = false;
      this.EventSubtitle.text = string.Empty;
      if ((UnityEngine.Object) this.Knife.parent == (UnityEngine.Object) this.EventStudent.LeftHand)
      {
        this.Knife.parent = this.CookingClub;
        this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
        this.Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
        this.Knife.GetComponent<Collider>().enabled = true;
      }
      this.StudentManager.UpdateStudents();
    }
    this.EventActive = false;
    this.EventCheck = false;
  }
}
