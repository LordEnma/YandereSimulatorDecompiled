// Decompiled with JetBrains decompiler
// Type: RivalAfterClassEventManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class RivalAfterClassEventManagerScript : MonoBehaviour
{
  public OsanaThursdayAfterClassEventScript OsanaThursdayRooftopEvent;
  public StudentManagerScript StudentManager;
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
  public AudioClip ImpatientSpeechClip;
  public string ImpatientSpeechText;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public bool LookAtSenpai;
  public bool EventActive;
  public bool NaturalEnd;
  public bool Cancelled;
  public bool HintGiven;
  public bool Impatient;
  public bool Sabotaged;
  public bool Transfer;
  public bool TakeOut;
  public bool PutAway;
  public bool Return;
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
      if (this.Frame > 1 && (double) this.Clock.HourTime > 17.25 && this.Senpai.gameObject.activeInHierarchy && (UnityEngine.Object) this.Rival != (UnityEngine.Object) null)
      {
        if ((this.Senpai.Leaving || (UnityEngine.Object) this.Senpai.CurrentDestination == (UnityEngine.Object) this.StudentManager.Exit) && !this.Senpai.InEvent)
        {
          this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Senpai.CharacterAnimation.CrossFade(this.Senpai.WalkAnim);
          this.Senpai.Pathfinding.target = this.Location[1];
          this.Senpai.CurrentDestination = this.Location[1];
          this.Senpai.Pathfinding.canSearch = true;
          this.Senpai.Pathfinding.canMove = true;
          this.Senpai.InEvent = true;
          this.Senpai.DistanceToDestination = 100f;
          this.Spy.Prompt.enabled = true;
        }
        if ((this.Rival.Leaving || (UnityEngine.Object) this.Rival.CurrentDestination == (UnityEngine.Object) this.StudentManager.Exit) && this.Rival.enabled && !this.Rival.InEvent)
        {
          Debug.Log((object) "Osana's Wednesday after school event has begun.");
          this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
          this.Rival.Pathfinding.target = this.Location[2];
          this.Rival.CurrentDestination = this.Location[2];
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.InEvent = true;
          this.Rival.DistanceToDestination = 100f;
          this.Spy.Prompt.enabled = true;
        }
        if ((UnityEngine.Object) this.Senpai.CurrentDestination == (UnityEngine.Object) this.Location[1] && (double) this.Senpai.DistanceToDestination < 0.5)
        {
          if (!this.Impatient)
          {
            this.Senpai.CharacterAnimation.CrossFade("waiting_00");
            this.Senpai.Pathfinding.canSearch = false;
            this.Senpai.Pathfinding.canMove = false;
            if ((double) this.Clock.HourTime > 17.916666030883789)
            {
              AudioClipPlayer.Play(this.ImpatientSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
              this.Senpai.CharacterAnimation.CrossFade("impatience_00");
              this.EventSubtitle.text = this.ImpatientSpeechText;
              this.Impatient = true;
            }
          }
          else if ((double) this.Senpai.CharacterAnimation["impatience_00"].time >= (double) this.Senpai.CharacterAnimation["impatience_00"].length)
          {
            ++this.StudentManager.SabotageProgress;
            Debug.Log((object) ("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5"));
            this.EndEvent();
          }
        }
        if ((UnityEngine.Object) this.Rival.CurrentDestination == (UnityEngine.Object) this.Location[2] && (double) this.Rival.DistanceToDestination < 0.5)
        {
          this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
        }
        if (!this.HintGiven)
        {
          this.Yandere.PauseScreen.Hint.QuickID = 10;
          this.Yandere.PauseScreen.Hint.Show = true;
          this.HintGiven = true;
        }
        if ((UnityEngine.Object) this.Rival.CurrentDestination == (UnityEngine.Object) this.Location[2] && (UnityEngine.Object) this.Senpai.CurrentDestination == (UnityEngine.Object) this.Location[1] && (double) this.Senpai.DistanceToDestination < 0.5 && (double) this.Rival.DistanceToDestination < 0.5 && !this.Impatient)
          ++this.Phase;
      }
      ++this.Frame;
    }
    else if (this.Phase == 1)
    {
      if ((UnityEngine.Object) this.StudentManager.Students[this.FriendID] != (UnityEngine.Object) null && (UnityEngine.Object) this.Rival.Follower != (UnityEngine.Object) null && !PlayerGlobals.RaibaruLoner)
      {
        this.Friend = this.StudentManager.Students[this.FriendID];
        this.Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Friend.Pathfinding.target = this.Location[3];
        this.Friend.CurrentDestination = this.Location[3];
        this.Friend.ManualRotation = true;
        this.Friend.Cheer.enabled = true;
        this.Friend.InEvent = true;
      }
      if (this.EventDay == DayOfWeek.Tuesday)
      {
        this.Rival.EventBook.SetActive(true);
        if (!this.Sabotaged)
        {
          AudioClipPlayer.Play(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.TransferTime = 8.5f;
          this.Suffix = "A";
        }
        else
        {
          AudioClipPlayer.Play(this.SabotagedSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.TransferTime = 11f;
          this.Suffix = "B";
        }
      }
      else if (this.EventDay == DayOfWeek.Wednesday)
      {
        this.Sabotaged = this.Rival.LewdPhotos;
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
          this.TransferTime = 4.833333f;
          this.ReturnTime = 35f;
          this.TakeOutTime = 0.75f;
          this.PutAwayTime = 36.5f;
          this.Suffix = "A";
        }
        else
        {
          AudioClipPlayer.Play(this.SabotagedSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.TransferTime = 4.833333f;
          this.ReturnTime = 26.5f;
          this.TakeOutTime = 0.75f;
          this.PutAwayTime = 50f;
          this.Suffix = "B";
        }
      }
      else if (this.EventDay == DayOfWeek.Thursday)
      {
        AudioClipPlayer.Play(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        this.Suffix = "A";
      }
      this.Rival.CharacterAnimation.CrossFade("f02_" + this.Weekday + "_3" + this.Suffix);
      if (this.EventDay == DayOfWeek.Thursday)
        this.Senpai.CharacterAnimation.CrossFade(this.Senpai.IdleAnim);
      else
        this.Senpai.CharacterAnimation.CrossFade(this.Weekday + "_3" + this.Suffix);
      this.Timer = 0.0f;
      ++this.Phase;
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
          this.Rival.StopRotating = true;
          this.LookAtSenpai = true;
          this.EndSenpai();
        }
        if (this.LookAtSenpai)
        {
          this.Rival.targetRotation = Quaternion.LookRotation(this.Senpai.transform.position - this.Rival.transform.position);
          this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.targetRotation, 10f * Time.deltaTime);
        }
      }
      if ((double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time >= (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].length)
      {
        this.NaturalEnd = true;
        this.EndEvent();
      }
      if (this.TakeOut && this.EventDay == DayOfWeek.Wednesday && (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > (double) this.TakeOutTime)
      {
        this.Rival.SmartPhone.SetActive(true);
        this.TakeOut = false;
        this.PutAway = true;
      }
      if (this.PutAway && this.EventDay == DayOfWeek.Wednesday && (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > (double) this.PutAwayTime)
      {
        this.Rival.SmartPhone.SetActive(false);
        this.PutAway = false;
      }
      if (this.Transfer)
      {
        if (this.EventDay == DayOfWeek.Tuesday)
        {
          if ((double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > (double) this.TransferTime)
          {
            this.Rival.EventBook.SetActive(false);
            this.Senpai.EventBook.SetActive(true);
            this.Transfer = false;
            this.Return = true;
          }
        }
        else if (this.EventDay == DayOfWeek.Wednesday && (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > (double) this.TransferTime)
        {
          this.Rival.SmartPhone.SetActive(false);
          this.Senpai.SmartPhone.SetActive(true);
          this.Transfer = false;
          this.Return = true;
        }
      }
      if (this.Return && this.EventDay == DayOfWeek.Wednesday && (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > (double) this.ReturnTime)
      {
        this.Rival.SmartPhone.SetActive(true);
        this.Senpai.SmartPhone.SetActive(false);
        this.Return = false;
      }
      if (this.Senpai.Alarmed || this.Rival.Alarmed || this.Rival.Splashed || this.Rival.GoAway)
      {
        UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
        this.EndEvent();
      }
    }
    if (this.Phase > 0 || this.Impatient)
    {
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
        this.Yandere.Eavesdropping = (double) this.Distance < 5.0;
      }
      else
      {
        this.EventSubtitle.transform.localScale = Vector3.zero;
        if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
          this.VoiceClip.GetComponent<AudioSource>().volume = 0.0f;
      }
    }
    if (this.Phase <= 0)
      return;
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
    {
      if ((double) this.Friend.DistanceToDestination < 1.0)
      {
        this.Friend.CharacterAnimation.CrossFade("f02_cornerPeek_00");
        this.Friend.MoveTowardsTarget(this.Friend.CurrentDestination.position);
        this.Friend.targetRotation = this.Friend.CurrentDestination.rotation;
        this.Friend.transform.rotation = Quaternion.Slerp(this.Friend.transform.rotation, this.Friend.targetRotation, 10f * Time.deltaTime);
        this.Friend.MyController.radius = 0.0f;
      }
      else
      {
        this.Friend.CharacterAnimation.CrossFade(this.Friend.SprintAnim);
        this.Friend.Pathfinding.speed = 4f;
      }
    }
    else
    {
      if (!((UnityEngine.Object) this.StudentManager.Students[this.FriendID] != (UnityEngine.Object) null) || PlayerGlobals.RaibaruLoner)
        return;
      this.Friend = this.StudentManager.Students[this.FriendID];
    }
  }

  private void EndEvent()
  {
    Debug.Log((object) "Osana's talking-with-Senpai-before-going-home event ended.");
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
      this.Rival.EventBook.SetActive(false);
      this.Rival.Prompt.enabled = true;
      this.Rival.InEvent = false;
      this.Rival.Private = false;
      this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
      this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
      this.Rival.DistanceToDestination = 100f;
      this.Rival.Pathfinding.speed = 1f;
      this.Rival.Hurry = false;
    }
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null && this.Friend.CurrentAction == StudentActionType.Follow)
    {
      if (!this.Friend.Alarmed && !this.Friend.DramaticReaction)
      {
        this.Friend.Pathfinding.canSearch = true;
        this.Friend.Pathfinding.canMove = true;
      }
      if (this.NaturalEnd || this.Rival.GoAway)
      {
        this.Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
        this.Friend.Pathfinding.target = this.Rival.transform;
        this.Friend.CurrentDestination = this.Rival.transform;
        this.Friend.Pathfinding.canSearch = true;
        this.Friend.Pathfinding.canMove = true;
        this.Friend.MyController.radius = 0.1f;
        this.Friend.ManualRotation = false;
        this.Friend.Prompt.enabled = true;
        this.Friend.InEvent = false;
        this.Friend.Private = false;
      }
      this.Friend.Cheer.enabled = false;
    }
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Spy.Prompt.Hide();
    this.Spy.Prompt.enabled = false;
    if (this.Spy.Phase > 0)
      this.Spy.End();
    if (this.Sabotaged)
    {
      this.Rival.WalkAnim = "f02_sadWalk_00";
      ++this.StudentManager.SabotageProgress;
      Debug.Log((object) ("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5"));
    }
    this.Yandere.Eavesdropping = false;
    this.EventSubtitle.text = string.Empty;
    this.enabled = false;
    this.Jukebox.Dip = 1f;
    if (!this.Rival.GoAway)
      return;
    this.Rival.Subtitle.CustomText = "Ugh, seriously?! Forget it, let's just go home...";
    this.Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
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
    this.Senpai.EventBook.SetActive(false);
    this.Senpai.InEvent = false;
    this.Senpai.Private = false;
    this.Senpai.CurrentDestination = this.Senpai.Destinations[this.Senpai.Phase];
    this.Senpai.Pathfinding.target = this.Senpai.Destinations[this.Senpai.Phase];
    this.Senpai.DistanceToDestination = 100f;
    if (this.EventDay != DayOfWeek.Thursday)
      return;
    this.OsanaThursdayRooftopEvent.enabled = false;
  }
}
