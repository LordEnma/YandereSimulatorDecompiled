// Decompiled with JetBrains decompiler
// Type: OsanaFridayLunchEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaFridayLunchEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public AudioSoftwareScript AudioSoftware;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public SpyScript Spy;
  public StudentScript Friend;
  public StudentScript Senpai;
  public StudentScript Rival;
  public Transform[] Location;
  public Transform Epicenter;
  public AudioClip CancelledSpeechClip;
  public string[] CancelledSpeechText;
  public float[] CancelledSpeechTime;
  public AudioClip SabotagedSpeechClip;
  public string[] SabotagedSpeechText;
  public float[] SabotagedSpeechTime;
  public AudioClip SpeechClip;
  public string[] SpeechText;
  public float[] SpeechTime;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public bool LookAtSenpai;
  public bool EventActive;
  public bool Cancelled;
  public bool HintGiven;
  public bool Impatient;
  public bool Sabotaged;
  public bool Transfer;
  public bool TakeOut;
  public bool PutAway;
  public bool Return;
  public Vector3 OriginalRotation;
  public Vector3 OriginalPosition;
  public float TransferTime;
  public float ReturnTime;
  public float TakeOutTime;
  public float PutAwayTime;
  public float Distance;
  public float Scale;
  public float Timer;
  public DayOfWeek EventDay;
  public int SpeechPhase = 1;
  public int FriendID = 10;
  public int RivalID = 11;
  public int Phase;
  public int Frame;
  public string Weekday = string.Empty;
  public string Suffix = string.Empty;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    this.Spy.Prompt.enabled = false;
    this.Spy.Prompt.Hide();
    if (DateGlobals.Weekday == this.EventDay && GameGlobals.RivalEliminationID <= 0 && !GameGlobals.Eighties)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      if (this.Frame > 0)
      {
        this.Senpai = this.StudentManager.Students[1];
        if ((UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null)
          this.Rival = this.StudentManager.Students[this.RivalID];
        else
          this.enabled = false;
      }
      if (this.Frame > 1 && (double) this.Clock.HourTime > 13.0 && this.Senpai.gameObject.activeInHierarchy && (UnityEngine.Object) this.Rival != (UnityEngine.Object) null)
      {
        if (this.Rival.Bullied)
        {
          this.enabled = false;
        }
        else
        {
          if (!this.Senpai.InEvent)
          {
            this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
            this.Senpai.CharacterAnimation.CrossFade(this.Senpai.WalkAnim);
            this.Senpai.Pathfinding.target = this.Location[1];
            this.Senpai.CurrentDestination = this.Location[1];
            this.Senpai.Pathfinding.canSearch = true;
            this.Senpai.Pathfinding.canMove = true;
            this.Senpai.SmartPhone.SetActive(false);
            this.Senpai.InEvent = true;
            this.Senpai.DistanceToDestination = 100f;
            this.Spy.Prompt.enabled = true;
          }
          if (this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless)
          {
            Debug.Log((object) "Osana's Friday lunch event has begun.");
            this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
            this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
            this.Rival.Pathfinding.target = this.Location[2];
            this.Rival.CurrentDestination = this.Location[2];
            this.Rival.Pathfinding.canSearch = true;
            this.Rival.Pathfinding.canMove = true;
            this.Rival.SmartPhone.SetActive(false);
            this.Rival.InEvent = true;
            this.Rival.DistanceToDestination = 100f;
            this.Spy.Prompt.enabled = true;
          }
          if ((UnityEngine.Object) this.StudentManager.Students[this.FriendID] != (UnityEngine.Object) null && !PlayerGlobals.RaibaruLoner)
            this.Friend = this.StudentManager.Students[this.FriendID];
          if ((UnityEngine.Object) this.Senpai.CurrentDestination == (UnityEngine.Object) this.Location[1] && (double) this.Senpai.DistanceToDestination < 0.5)
          {
            if (!this.Impatient)
            {
              this.Senpai.CharacterAnimation.CrossFade("waiting_00");
              this.Senpai.Pathfinding.canSearch = false;
              this.Senpai.Pathfinding.canMove = false;
            }
            else if ((double) this.Senpai.CharacterAnimation["impatience_00"].time >= (double) this.Senpai.CharacterAnimation["impatience_00"].length)
              this.EndEvent();
          }
          if ((UnityEngine.Object) this.Rival.CurrentDestination == (UnityEngine.Object) this.Location[2] && (double) this.Rival.DistanceToDestination < 0.5)
          {
            this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
            this.Rival.Pathfinding.canSearch = false;
            this.Rival.Pathfinding.canMove = false;
          }
          if (!this.HintGiven)
          {
            this.Yandere.PauseScreen.Hint.Show = true;
            this.Yandere.PauseScreen.Hint.QuickID = 7;
            this.HintGiven = true;
          }
          if ((UnityEngine.Object) this.Rival.CurrentDestination == (UnityEngine.Object) this.Location[2] && (UnityEngine.Object) this.Senpai.CurrentDestination == (UnityEngine.Object) this.Location[1] && (double) this.Senpai.DistanceToDestination < 0.5 && (double) this.Rival.DistanceToDestination < 0.5 && !this.Impatient)
            ++this.Phase;
        }
      }
      ++this.Frame;
    }
    else if (this.Phase == 1)
    {
      this.Sabotaged = this.AudioSoftware.AudioDoctored;
      if (this.Rival.Phoneless)
        this.Cancelled = true;
      if (this.Cancelled)
      {
        AudioClipPlayer.Play(this.CancelledSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        this.Transfer = false;
        this.TakeOut = false;
        this.Suffix = "C";
      }
      else if (!this.Sabotaged)
      {
        AudioClipPlayer.Play(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        this.TakeOutTime = 2.5f;
        this.TransferTime = 7f;
        this.ReturnTime = 19.33333f;
        this.PutAwayTime = 24.33333f;
        this.Suffix = "A";
      }
      else
      {
        AudioClipPlayer.Play(this.SabotagedSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        this.TakeOutTime = 2.5f;
        this.TransferTime = 7f;
        this.ReturnTime = 16.66666f;
        this.PutAwayTime = 21.5f;
        this.Suffix = "B";
      }
      this.Rival.CharacterAnimation.CrossFade("f02_" + this.Weekday + "_3" + this.Suffix);
      this.Senpai.CharacterAnimation.CrossFade(this.Weekday + "_3" + this.Suffix);
      this.Timer = 0.0f;
      ++this.Phase;
      if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
      {
        this.Friend.CurrentDestination = this.Location[3];
        this.Friend.Pathfinding.target = this.Location[3];
        this.Friend.IdleAnim = "f02_cornerPeek_00";
        this.Friend.SlideIn = true;
      }
    }
    else
    {
      this.Timer += Time.deltaTime;
      if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
        this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
      if (this.Cancelled)
      {
        if (this.SpeechPhase < this.CancelledSpeechTime.Length && (double) this.Timer > (double) this.CancelledSpeechTime[this.SpeechPhase])
        {
          this.EventSubtitle.text = this.CancelledSpeechText[this.SpeechPhase];
          ++this.SpeechPhase;
        }
      }
      else if (!this.Sabotaged)
      {
        if (this.SpeechPhase < this.SpeechTime.Length && (double) this.Timer > (double) this.SpeechTime[this.SpeechPhase])
        {
          this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
          ++this.SpeechPhase;
        }
      }
      else
      {
        if (this.SpeechPhase < this.SabotagedSpeechTime.Length && (double) this.Timer > (double) this.SabotagedSpeechTime[this.SpeechPhase])
        {
          this.EventSubtitle.text = this.SabotagedSpeechText[this.SpeechPhase];
          ++this.SpeechPhase;
        }
        if ((double) this.Senpai.CharacterAnimation[this.Weekday + "_3" + this.Suffix].time >= (double) this.Senpai.CharacterAnimation[this.Weekday + "_3" + this.Suffix].length)
        {
          ScheduleBlock scheduleBlock = this.Senpai.ScheduleBlocks[4];
          scheduleBlock.destination = "Hangout";
          scheduleBlock.action = "Eat";
          this.Senpai.GetDestinations();
          if (this.Senpai.InEvent)
          {
            this.Rival.StopRotating = true;
            this.LookAtSenpai = true;
            this.EndSenpai();
          }
        }
        if (this.LookAtSenpai)
        {
          this.Rival.targetRotation = Quaternion.LookRotation(this.Senpai.transform.position - this.Rival.transform.position);
          this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.targetRotation, 10f * Time.deltaTime);
        }
      }
      if ((double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time >= (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].length)
        this.EndEvent();
      if (this.TakeOut && (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > (double) this.TakeOutTime)
      {
        this.Rival.SmartPhone.SetActive(true);
        this.TakeOut = false;
        this.PutAway = true;
      }
      if (this.PutAway && (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > (double) this.PutAwayTime)
      {
        this.Rival.SmartPhone.SetActive(false);
        this.PutAway = false;
      }
      if (this.Transfer && (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > (double) this.TransferTime)
      {
        this.OriginalRotation = this.Rival.SmartPhone.transform.localEulerAngles;
        this.OriginalPosition = this.Rival.SmartPhone.transform.localPosition;
        this.Rival.SmartPhone.transform.parent = this.Senpai.SmartPhone.transform.parent;
        this.Rival.SmartPhone.transform.localEulerAngles = this.Senpai.SmartPhone.transform.localEulerAngles;
        this.Rival.SmartPhone.transform.localPosition = this.Senpai.SmartPhone.transform.localPosition;
        this.Transfer = false;
        this.Return = true;
      }
      if (this.Return && (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > (double) this.ReturnTime)
      {
        this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
        this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
        this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
        this.Return = false;
      }
      if (this.Senpai.Alarmed || this.Rival.Alarmed || this.Rival.Splashed || this.Rival.Dodging || this.Clock.Period == 4)
      {
        if (!this.Rival.Splashed)
          UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
        this.EndEvent();
      }
    }
    if (!this.enabled || this.Phase <= 0 && !this.Impatient)
      return;
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
      this.Yandere.Eavesdropping = (double) this.Distance < 2.5;
    }
    else
    {
      this.EventSubtitle.transform.localScale = Vector3.zero;
      if (!((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null))
        return;
      this.VoiceClip.GetComponent<AudioSource>().volume = 0.0f;
    }
  }

  public void EndEvent()
  {
    Debug.Log((object) "Osana's Friday lunchtime event has ended.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if (this.Senpai.InEvent)
      this.EndSenpai();
    if (!this.Rival.Ragdoll.Zs.activeInHierarchy)
    {
      if (!this.Rival.Alarmed)
      {
        this.Rival.Pathfinding.canSearch = true;
        this.Rival.Pathfinding.canMove = true;
        this.Rival.Routine = true;
      }
      this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      this.Rival.SmartPhone.SetActive(false);
      this.Rival.Prompt.enabled = true;
      this.Rival.InEvent = false;
      this.Rival.Private = false;
      this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
      this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
      this.Rival.DistanceToDestination = 100f;
      this.Rival.Pathfinding.speed = 1f;
      this.Rival.StopRotating = false;
      this.Rival.Hurry = false;
    }
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
    {
      ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[4];
      scheduleBlock.destination = "LunchSpot";
      scheduleBlock.action = "Eat";
      this.Friend.GetDestinations();
      this.Friend.CurrentDestination = this.Friend.Destinations[this.Friend.Phase];
      this.Friend.Pathfinding.target = this.Friend.Destinations[this.Friend.Phase];
      this.Friend.DistanceToDestination = 100f;
      this.Friend.IdleAnim = this.Friend.OriginalIdleAnim;
      this.Friend.SlideIn = false;
      Debug.Log((object) "''Friend'' is being told to set her destination to her current phase's destination.");
    }
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Spy.Prompt.Hide();
    this.Spy.Prompt.enabled = false;
    if (this.Spy.Phase > 0)
      this.Spy.End();
    if (this.Sabotaged)
      this.Rival.WalkAnim = "f02_sadWalk_00";
    if ((UnityEngine.Object) this.Rival.SmartPhone.transform.parent != (UnityEngine.Object) this.Rival.ItemParent)
    {
      this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
      this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
      this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
    }
    this.Jukebox.Dip = 1f;
    this.Yandere.Eavesdropping = false;
    this.EventSubtitle.text = string.Empty;
    this.enabled = false;
  }

  private void EndSenpai()
  {
    if (!this.Senpai.Alarmed)
    {
      this.Senpai.Pathfinding.canSearch = true;
      this.Senpai.Pathfinding.canMove = true;
      this.Senpai.Routine = true;
    }
    this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.Senpai.SmartPhone.SetActive(false);
    this.Senpai.InEvent = false;
    this.Senpai.Private = false;
    this.Senpai.CurrentDestination = this.Senpai.Destinations[this.Senpai.Phase];
    this.Senpai.Pathfinding.target = this.Senpai.Destinations[this.Senpai.Phase];
    this.Senpai.DistanceToDestination = 100f;
    if (!this.Sabotaged)
      return;
    ++this.StudentManager.SabotageProgress;
    Debug.Log((object) ("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5"));
  }
}
