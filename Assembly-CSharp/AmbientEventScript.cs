// Decompiled with JetBrains decompiler
// Type: AmbientEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class AmbientEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public AmbientEventScript GrudgeReaction;
  public AmbientEventScript PoliceReaction;
  public HidingSpotScript HidingSpot;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript[] EventStudent;
  public Transform[] EventLocation;
  public AudioClip[] EventClip;
  public string[] EventSpeech;
  public string[] EventAnim;
  public int[] EventSpeaker;
  public GameObject VoiceClip;
  public bool RotateSpine;
  public bool Sitting;
  public bool EventOn;
  public bool Spoken;
  public bool Private;
  public int EventPhase;
  public float StartTime = 13.001f;
  public float Delay = 0.5f;
  public float Timer;
  public float Scale;
  public int[] StudentID;
  public DayOfWeek EventDay;
  public float MouthTimer;
  public float MouthTarget;
  public float MouthExtent;
  public float TimerLimit = 0.1f;
  public float TalkSpeed;
  public float LipStrength;

  private void Start()
  {
    if (this.Sitting)
    {
      if (DateGlobals.Weekday != this.EventDay || GameGlobals.Eighties)
      {
        this.gameObject.SetActive(false);
        this.enabled = false;
      }
      else if (StudentGlobals.GetStudentGrudge(2) || StudentGlobals.GetStudentGrudge(3))
      {
        this.EventClip = this.GrudgeReaction.EventClip;
        this.EventSpeech = this.GrudgeReaction.EventSpeech;
        this.EventSpeaker = this.GrudgeReaction.EventSpeaker;
      }
      else
      {
        if (!GameGlobals.PoliceYesterday)
          return;
        this.EventClip = this.PoliceReaction.EventClip;
        this.EventSpeech = this.PoliceReaction.EventSpeech;
        this.EventSpeaker = this.PoliceReaction.EventSpeaker;
      }
    }
    else
    {
      if (DateGlobals.Weekday == this.EventDay && !GameGlobals.Eighties)
        return;
      this.gameObject.SetActive(false);
      this.enabled = false;
    }
  }

  private void Update()
  {
    if (!this.EventOn)
    {
      for (int index = 1; index < 3; ++index)
      {
        if ((UnityEngine.Object) this.EventStudent[index] == (UnityEngine.Object) null)
          this.EventStudent[index] = this.StudentManager.Students[this.StudentID[index]];
        else if (!this.EventStudent[index].Alive || this.EventStudent[index].Slave)
          this.enabled = false;
      }
      if ((double) this.Clock.HourTime <= (double) this.StartTime || !((UnityEngine.Object) this.EventStudent[1] != (UnityEngine.Object) null) || !((UnityEngine.Object) this.EventStudent[2] != (UnityEngine.Object) null) || !this.EventStudent[1].Indoors || !this.EventStudent[2].Indoors || !this.EventStudent[1].Pathfinding.canMove || !this.EventStudent[2].Pathfinding.canMove)
        return;
      if (this.Sitting && this.Yandere.Hiding && (UnityEngine.Object) this.Yandere.HidingSpot == (UnityEngine.Object) this.HidingSpot.Spot)
      {
        this.Yandere.PromptBar.ClearButtons();
        this.Yandere.PromptBar.Show = false;
        this.Yandere.Exiting = true;
        this.HidingSpot.Prompt.enabled = false;
        this.HidingSpot.Prompt.Hide();
      }
      this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
      this.EventStudent[1].CurrentDestination = this.EventLocation[1];
      this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
      this.EventStudent[1].InEvent = true;
      this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
      this.EventStudent[2].CurrentDestination = this.EventLocation[2];
      this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
      this.EventStudent[2].InEvent = true;
      if ((double) this.StartTime > 16.0)
      {
        this.Yandere.PauseScreen.Hint.QuickID = 49;
        this.Yandere.PauseScreen.Hint.Show = true;
      }
      this.EventOn = true;
    }
    else if ((double) this.Clock.HourTime > (double) this.StartTime + 0.5 || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Alarmed || this.EventStudent[2].Alarmed || this.EventStudent[1].Dying || this.EventStudent[2].Dying || this.EventStudent[1].GoAway || this.EventStudent[2].GoAway || this.Yandere.Noticed)
    {
      this.EndEvent();
    }
    else
    {
      for (int index = 1; index < 3; ++index)
      {
        if (!this.EventStudent[index].Pathfinding.canMove && !this.EventStudent[index].Private)
        {
          this.EventStudent[index].Character.GetComponent<Animation>().CrossFade(this.EventStudent[index].IdleAnim);
          this.EventStudent[index].Private = true;
          this.StudentManager.UpdateStudents();
        }
      }
      if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
      {
        if (this.Sitting)
        {
          this.EventStudent[1].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.EventStudent[1].CharacterAnimation[this.EventStudent[1].SocialSitAnim].layer = 99;
          this.EventStudent[1].CharacterAnimation.Play(this.EventStudent[1].SocialSitAnim);
          this.EventStudent[1].CharacterAnimation[this.EventStudent[1].SocialSitAnim].weight = 1f;
          this.EventStudent[2].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.EventStudent[2].CharacterAnimation[this.EventStudent[2].SocialSitAnim].layer = 99;
          this.EventStudent[2].CharacterAnimation.Play(this.EventStudent[2].SocialSitAnim);
          this.EventStudent[2].CharacterAnimation[this.EventStudent[2].SocialSitAnim].weight = 1f;
          this.EventStudent[1].MyController.radius = 0.0f;
          this.EventStudent[2].MyController.radius = 0.0f;
          this.RotateSpine = true;
        }
        float num = Vector3.Distance(this.Yandere.transform.position, this.EventLocation[1].parent.position);
        if (!this.Spoken)
        {
          if (this.Sitting)
          {
            this.EventStudent[this.EventSpeaker[1]].CharacterAnimation.CrossFade("f02_benchSit_00");
            this.EventStudent[this.EventSpeaker[2]].CharacterAnimation.CrossFade("f02_benchSit_00");
          }
          else
          {
            this.EventStudent[this.EventSpeaker[1]].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
            this.EventStudent[this.EventSpeaker[2]].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
          }
          this.EventStudent[this.EventSpeaker[this.EventPhase]].PickRandomAnim();
          this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].RandomAnim);
          if (!this.Sitting && (double) this.StartTime < 16.0 && DateGlobals.Weekday == DayOfWeek.Monday && this.EventPhase == 13)
            this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade("jojoPose_00");
          AudioClipPlayer.Play(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.Spoken = true;
        }
        else
        {
          int index = this.EventSpeaker[this.EventPhase];
          if ((double) this.EventStudent[index].CharacterAnimation[this.EventStudent[index].RandomAnim].time >= (double) this.EventStudent[index].CharacterAnimation[this.EventStudent[index].RandomAnim].length)
          {
            this.EventStudent[index].PickRandomAnim();
            this.EventStudent[index].CharacterAnimation.CrossFade(this.EventStudent[index].RandomAnim);
          }
          this.Timer += Time.deltaTime;
          if ((double) this.Yandere.transform.position.y > (double) this.EventLocation[1].parent.position.y - 1.0 && (double) this.Yandere.transform.position.y < (double) this.EventLocation[1].parent.position.y + 1.0)
          {
            if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
              this.VoiceClip.GetComponent<AudioSource>().volume = 1f;
            if ((double) num < 10.0)
            {
              this.EventSubtitle.text = (double) this.Timer <= (double) this.EventClip[this.EventPhase].length ? this.EventSpeech[this.EventPhase] : string.Empty;
              this.Scale = Mathf.Abs((float) (((double) num - 10.0) * 0.20000000298023224));
              if ((double) this.Scale < 0.0)
                this.Scale = 0.0f;
              if ((double) this.Scale > 1.0)
                this.Scale = 1f;
              this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
            }
            else if ((double) num < 11.0)
            {
              this.EventSubtitle.transform.localScale = Vector3.zero;
              this.EventSubtitle.text = string.Empty;
            }
          }
          else if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
            this.VoiceClip.GetComponent<AudioSource>().volume = 0.0f;
          if ((double) this.Timer > (double) this.EventClip[this.EventPhase].length + (double) this.Delay)
          {
            this.Spoken = false;
            ++this.EventPhase;
            this.Timer = 0.0f;
            if (this.EventPhase == this.EventSpeech.Length)
              this.EndEvent();
          }
        }
        if (!this.Private)
          return;
        if ((double) num < 5.0)
          this.Yandere.Eavesdropping = true;
        else
          this.Yandere.Eavesdropping = false;
      }
      else
      {
        double num1 = (double) Vector3.Distance(this.EventStudent[1].transform.position, this.EventLocation[1].parent.position);
        float num2 = Vector3.Distance(this.EventStudent[2].transform.position, this.EventLocation[1].parent.position);
        float num3 = Vector3.Distance(this.Yandere.transform.position, this.EventLocation[1].parent.position);
        if ((num1 >= 5.0 || (double) num3 >= 5.0) && ((double) num2 >= 5.0 || (double) num3 >= 5.0))
          return;
        this.EndEvent();
      }
    }
  }

  private void LateUpdate()
  {
    if (!this.RotateSpine)
      return;
    this.EventStudent[1].Head.transform.localEulerAngles += new Vector3(0.0f, 15f, 0.0f);
    this.EventStudent[1].Neck.transform.localEulerAngles += new Vector3(0.0f, 15f, 0.0f);
    this.EventStudent[1].Spine.transform.localEulerAngles += new Vector3(0.0f, 15f, 0.0f);
    this.EventStudent[1].LeftEye.transform.localEulerAngles += new Vector3(0.0f, 5f, 0.0f);
    this.EventStudent[1].RightEye.transform.localEulerAngles += new Vector3(0.0f, 5f, 0.0f);
    this.EventStudent[2].Head.transform.localEulerAngles += new Vector3(0.0f, -15f, 0.0f);
    this.EventStudent[2].Neck.transform.localEulerAngles += new Vector3(0.0f, -15f, 0.0f);
    this.EventStudent[2].Spine.transform.localEulerAngles += new Vector3(0.0f, -15f, 0.0f);
    this.EventStudent[2].LeftEye.transform.localEulerAngles += new Vector3(0.0f, -5f, 0.0f);
    this.EventStudent[2].RightEye.transform.localEulerAngles += new Vector3(0.0f, -5f, 0.0f);
    this.MouthTimer += Time.deltaTime;
    if ((double) this.MouthTimer > (double) this.TimerLimit)
    {
      this.MouthTarget = UnityEngine.Random.Range(40f, 40f + this.MouthExtent);
      this.MouthTimer = 0.0f;
    }
    Transform jaw = this.EventStudent[this.EventSpeaker[this.EventPhase]].Jaw;
    Transform lipL = this.EventStudent[this.EventSpeaker[this.EventPhase]].LipL;
    Transform lipR = this.EventStudent[this.EventSpeaker[this.EventPhase]].LipR;
    jaw.localEulerAngles = new Vector3(jaw.localEulerAngles.x, jaw.localEulerAngles.y, Mathf.Lerp(jaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed));
    lipL.localPosition = new Vector3(lipL.localPosition.x, Mathf.Lerp(lipL.localPosition.y, (float) (0.02632812038064003 + (double) this.MouthTarget * (double) this.LipStrength), Time.deltaTime * this.TalkSpeed), lipL.localPosition.z);
    lipR.localPosition = new Vector3(lipR.localPosition.x, Mathf.Lerp(lipR.localPosition.y, (float) (0.02632812038064003 + (double) this.MouthTarget * (double) this.LipStrength), Time.deltaTime * this.TalkSpeed), lipR.localPosition.z);
  }

  public void EndEvent()
  {
    Debug.Log((object) ("An Ambient Event named " + this.gameObject.name + " has ended."));
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    for (int index = 1; index < 3; ++index)
    {
      this.EventStudent[index].CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      this.EventStudent[index].CharacterAnimation.Stop(this.EventStudent[index].SocialSitAnim);
      this.EventStudent[1].MyController.radius = 0.1f;
      if (this.EventStudent[index].Meeting && (double) this.EventStudent[index].Clock.HourTime > (double) this.EventStudent[index].MeetTime)
      {
        this.EventStudent[index].CurrentDestination = this.EventStudent[index].MeetSpot;
        this.EventStudent[index].Pathfinding.target = this.EventStudent[index].MeetSpot;
        this.EventStudent[index].DistanceToDestination = Vector3.Distance(this.transform.position, this.EventStudent[index].CurrentDestination.position);
        this.EventStudent[index].Pathfinding.canSearch = true;
        this.EventStudent[index].Pathfinding.canMove = true;
        this.EventStudent[index].Pathfinding.speed = 4f;
        this.EventStudent[index].SpeechLines.Stop();
        this.EventStudent[index].EmptyHands();
        this.EventStudent[index].Meeting = true;
        this.EventStudent[index].MeetTime = 0.0f;
      }
      else
      {
        this.EventStudent[index].CurrentDestination = this.EventStudent[index].Destinations[this.EventStudent[index].Phase];
        this.EventStudent[index].Pathfinding.target = this.EventStudent[index].Destinations[this.EventStudent[index].Phase];
      }
      this.EventStudent[index].InEvent = false;
      this.EventStudent[index].Private = false;
    }
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    if ((UnityEngine.Object) this.HidingSpot != (UnityEngine.Object) null)
      this.HidingSpot.Prompt.enabled = true;
    this.EventSubtitle.text = string.Empty;
    this.Yandere.Eavesdropping = false;
    this.enabled = false;
  }
}
