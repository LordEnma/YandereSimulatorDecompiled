// Decompiled with JetBrains decompiler
// Type: OsanaMondayBeforeClassEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaMondayBeforeClassEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public EventManagerScript NextEvent;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript Rival;
  public Transform Destination;
  public AudioClip SpeechClip;
  public string[] SpeechText;
  public float[] SpeechTime;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public GameObject[] Bentos;
  public bool EventActive;
  public bool HintGiven;
  public float Distance;
  public float Scale;
  public float Timer;
  public int SpeechPhase = 1;
  public int RivalID = 11;
  public int Phase;
  public int Frame;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    this.Bentos[1].SetActive(false);
    this.Bentos[2].SetActive(false);
    if (DateGlobals.Weekday == DayOfWeek.Monday && StudentGlobals.StudentSlave != this.RivalID && !GameGlobals.AlphabetMode && !MissionModeGlobals.MissionMode && DateGlobals.Week <= 1 && !GameGlobals.Eighties)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      if (this.Frame > 0)
      {
        if (this.Clock.Period == 1)
        {
          if ((UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null)
          {
            if ((UnityEngine.Object) this.Rival == (UnityEngine.Object) null)
              this.Rival = this.StudentManager.Students[this.RivalID];
            else if (this.Rival.enabled && this.Rival.Indoors && !this.Rival.Alarmed && !this.Rival.WitnessedCorpse && !this.Rival.WitnessedMurder && !this.Rival.Meeting)
            {
              Debug.Log((object) "Osana's before class event has begun. Putting two bento boxes on her desk.");
              this.Rival.CharacterAnimation["f02_pondering_00"].speed = 0.65f;
              this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
              this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
              this.Rival.Pathfinding.target = this.Destination;
              this.Rival.CurrentDestination = this.Destination;
              this.Rival.Pathfinding.canSearch = true;
              this.Rival.Pathfinding.canMove = true;
              this.Rival.Routine = false;
              this.Rival.InEvent = true;
              if ((UnityEngine.Object) this.Rival.Follower != (UnityEngine.Object) null && !this.Rival.Follower.ReturningMisplacedWeapon && (double) this.Rival.Follower.DistanceToDestination < 5.0)
              {
                Debug.Log((object) "Raibaru will be joining Osana for her bento event.");
                this.Rival.Follower.TargetDistance = 1.5f;
                this.Rival.Follower.InEvent = true;
                this.Rival.Follower.CurrentDestination = this.Rival.FollowTargetDestination;
                this.Rival.Follower.Pathfinding.target = this.Rival.FollowTargetDestination;
              }
              if (!this.HintGiven)
              {
                this.Yandere.PauseScreen.Hint.Show = true;
                this.Yandere.PauseScreen.Hint.QuickID = 13;
                this.HintGiven = true;
              }
              ++this.Phase;
            }
          }
          else
            this.enabled = false;
        }
        else
          this.enabled = false;
      }
      ++this.Frame;
    }
    else if (this.Phase == 1)
    {
      if ((double) this.Rival.DistanceToDestination < 0.5)
      {
        AudioClipPlayer.Play(this.SpeechClip, this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        if ((UnityEngine.Object) this.Rival.Follower != (UnityEngine.Object) null && this.Rival.Follower.InEvent)
        {
          this.Rival.Follower.CurrentDestination = this.Rival.transform;
          this.Rival.Follower.Pathfinding.target = this.Rival.transform;
        }
        this.Rival.CharacterAnimation.CrossFade("f02_pondering_00");
        this.Rival.Pathfinding.canSearch = false;
        this.Rival.Pathfinding.canMove = false;
        this.Bentos[1].SetActive(true);
        this.Bentos[2].SetActive(true);
        ++this.Phase;
      }
      if ((UnityEngine.Object) this.Rival.Follower != (UnityEngine.Object) null && this.Rival.Follower.InEvent)
      {
        if ((double) this.Rival.Follower.DistanceToDestination >= (double) this.Rival.Follower.TargetDistance + 0.10000000149011612)
          this.Rival.Follower.CharacterAnimation.CrossFade(this.Rival.Follower.WalkAnim);
        else
          this.Rival.Follower.CharacterAnimation.CrossFade(this.Rival.Follower.IdleAnim);
      }
    }
    else
    {
      if (!this.Rival.GoAway)
      {
        this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
        this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
      }
      if ((UnityEngine.Object) this.Rival.Follower != (UnityEngine.Object) null && this.Rival.Follower.InEvent)
      {
        if ((double) this.Rival.Follower.DistanceToDestination >= (double) this.Rival.Follower.TargetDistance + 0.10000000149011612)
          this.Rival.Follower.CharacterAnimation.CrossFade(this.Rival.Follower.WalkAnim);
        else
          this.Rival.Follower.CharacterAnimation.CrossFade(this.Rival.Follower.IdleAnim);
      }
      this.Timer += Time.deltaTime;
      if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
        this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
      if (this.SpeechPhase < this.SpeechTime.Length)
      {
        if ((double) this.Timer > (double) this.SpeechTime[this.SpeechPhase])
        {
          if ((UnityEngine.Object) this.Rival.Follower == (UnityEngine.Object) null || !this.Rival.Follower.InEvent)
          {
            if ((UnityEngine.Object) this.Rival.Follower == (UnityEngine.Object) null)
              Debug.Log((object) "Ending because Raibaru wasn't there.");
            else
              Debug.Log((object) "For some reason, Raibaru's ''InEvent'' was false.");
            this.EndEvent();
          }
          else
          {
            this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
            ++this.SpeechPhase;
          }
        }
      }
      else if ((double) this.Rival.CharacterAnimation["f02_pondering_00"].time > (double) this.Rival.CharacterAnimation["f02_pondering_00"].length || (double) this.Timer > 20.0)
      {
        Debug.Log((object) "Ending naturally.");
        this.EndEvent();
      }
      if (this.Rival.Alarmed || this.Rival.Splashed || this.Rival.GoAway || (UnityEngine.Object) this.Rival.Follower != (UnityEngine.Object) null && this.Rival.Follower.DramaticReaction)
      {
        Debug.Log((object) "Ending because alarmed/slashed/stinkbombed/Raibaru saw murder.");
        UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
        this.EndEvent();
      }
      else if (this.Rival.Dying)
      {
        Debug.Log((object) "Ending because dying.");
        this.EndEvent();
      }
      this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Rival.transform.position);
      if (this.enabled)
      {
        if ((double) this.Yandere.transform.position.y > (double) this.Rival.transform.position.y - 0.10000000149011612 && (double) this.Yandere.transform.position.y < (double) this.Rival.transform.position.y + 0.10000000149011612 && (double) this.Distance - 4.0 < 15.0)
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
      }
    }
    if (this.Phase <= 0)
      return;
    if (this.Clock.Period > 1 || this.Rival.Splashed || this.Rival.Electrified)
    {
      Debug.Log((object) "Ending because of clock, splash, or electricity.");
      this.EndEvent();
    }
    if (this.Yandere.NoDebug || !Input.GetKeyDown(KeyCode.LeftControl))
      return;
    Debug.Log((object) "Ending because of debug command.");
    this.Bentos[1].SetActive(true);
    this.Bentos[2].SetActive(true);
    this.EndEvent();
  }

  public void EndEvent()
  {
    Debug.Log((object) "Osana's before class event ended.");
    this.Bentos[1].GetComponent<BentoScript>().enabled = true;
    this.Bentos[2].GetComponent<BentoScript>().enabled = true;
    this.Bentos[1].GetComponent<PromptScript>().enabled = true;
    this.Bentos[2].GetComponent<PromptScript>().enabled = true;
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if (!this.Rival.Alarmed && !this.Rival.Electrified && !this.Rival.Splashed && (UnityEngine.Object) this.Rival.Hunter == (UnityEngine.Object) null && !this.Rival.GoAway)
    {
      this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
      this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
      this.Rival.Pathfinding.canSearch = true;
      this.Rival.Pathfinding.canMove = true;
      this.Rival.Routine = true;
    }
    else
    {
      Debug.Log((object) "The event ended specifically because Osana was alarmed, splashed, stink bombed, or killed.");
      this.Rival.Pathfinding.canSearch = false;
      this.Rival.Pathfinding.canMove = false;
    }
    this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.Rival.DistanceToDestination = 999f;
    this.Rival.Prompt.enabled = true;
    this.Rival.InEvent = false;
    this.Rival.Private = false;
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Rival.CharacterAnimation["f02_pondering_00"].speed = 1f;
    this.Jukebox.Dip = 1f;
    if ((UnityEngine.Object) this.Rival.Follower != (UnityEngine.Object) null && this.Rival.Follower.InEvent)
    {
      this.Rival.Follower.TargetDistance = 1f;
      this.Rival.Follower.InEvent = false;
      this.Rival.Follower.CurrentDestination = this.Rival.FollowTargetDestination;
      this.Rival.Follower.Pathfinding.target = this.Rival.FollowTargetDestination;
    }
    this.EventSubtitle.text = string.Empty;
    this.NextEvent.enabled = true;
    this.enabled = false;
  }
}
