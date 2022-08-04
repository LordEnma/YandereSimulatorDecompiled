// Decompiled with JetBrains decompiler
// Type: OsanaWednesdayLunchEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaWednesdayLunchEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript Rival;
  public Transform Location;
  public AudioClip SpeechClip;
  public string SpeechText;
  public string EventAnim;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public float Distance;
  public float Scale;
  public DayOfWeek EventDay;
  public int StartPeriod;
  public int RivalID = 11;
  public int Phase;
  public int Frame;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Weekday == this.EventDay && GameGlobals.RivalEliminationID <= 0)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      if (this.Frame > 0 && (UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.Rival == (UnityEngine.Object) null)
          this.Rival = this.StudentManager.Students[this.RivalID];
        if (this.Rival.Bullied)
          this.enabled = false;
        else if ((this.Clock.Period == 3 || this.Clock.Period == 6) && this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless)
        {
          Debug.Log((object) "Osana's Wednesday lunchtime event has begun.");
          this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
          this.Rival.Pathfinding.target = this.Location;
          this.Rival.CurrentDestination = this.Location;
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.Routine = false;
          this.Rival.InEvent = true;
          this.Rival.EmptyHands();
          this.StartPeriod = this.Clock.Period;
          this.Yandere.PauseScreen.Hint.Show = true;
          this.Yandere.PauseScreen.Hint.QuickID = 17;
          ++this.Phase;
        }
      }
      ++this.Frame;
    }
    else
    {
      if (this.Phase == 1)
      {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          this.Yandere.transform.position = this.Location.position + new Vector3(2f, 0.0f, 2f);
          this.Rival.transform.position = this.Location.position + new Vector3(1f, 0.0f, 1f);
        }
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          AudioClipPlayer.Play(this.SpeechClip, this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText;
          this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.Rival.Obstacle.enabled = true;
          ++this.Phase;
        }
      }
      else if (this.Phase == 2)
      {
        if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim].time >= 1.33333)
        {
          this.Rival.SmartPhone.SetActive(true);
          ++this.Phase;
        }
      }
      else if (this.Phase == 3)
      {
        if ((double) this.Rival.CharacterAnimation["f02_" + this.EventAnim].time >= 6.833333)
        {
          this.Rival.SmartPhone.SetActive(false);
          ++this.Phase;
        }
      }
      else if (this.Phase == 4 && (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim].time >= (double) this.Rival.CharacterAnimation["f02_" + this.EventAnim].length)
        this.EndEvent();
      if (this.Clock.Period > this.StartPeriod || this.Rival.Alarmed || this.Rival.Splashed)
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

  private void EndEvent()
  {
    Debug.Log((object) "Osana's Wednesday lunchtime event has ended.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if (!this.Rival.Alarmed)
    {
      this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
      this.Rival.DistanceToDestination = 100f;
      this.Rival.Pathfinding.canSearch = true;
      this.Rival.Pathfinding.canMove = true;
      this.Rival.Routine = true;
    }
    this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.Rival.Obstacle.enabled = false;
    this.Rival.Prompt.enabled = true;
    this.Rival.InEvent = false;
    this.Rival.Private = false;
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Jukebox.Dip = 1f;
    this.EventSubtitle.text = string.Empty;
    this.enabled = false;
  }
}
