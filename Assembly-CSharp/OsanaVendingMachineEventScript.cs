// Decompiled with JetBrains decompiler
// Type: OsanaVendingMachineEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaVendingMachineEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript Rival;
  public Transform Location;
  public AudioSource VoiceSource;
  public AudioSource MyAudio;
  public AudioClip[] SpeechClip;
  public AudioClip Bang;
  public string[] SpeechText;
  public string[] EventAnim;
  public GameObject OsanaVandalismCollider;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public float MinimumDistance = 0.5f;
  public float Distance;
  public float Scale;
  public float Timer;
  public DayOfWeek EventDay;
  public int StartPeriod;
  public int RivalID = 11;
  public int Phase;
  public int Frame;
  public bool PlaySound;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (!GameGlobals.Eighties)
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
        if (this.Rival.enabled && this.Rival.SnackPhase == 1)
        {
          Debug.Log((object) "Osana's vending machine event has begun.");
          AudioClipPlayer.Play(this.SpeechClip[0], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText[0];
          this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
          this.Rival.Pathfinding.target = this.Location;
          this.Rival.CurrentDestination = this.Location;
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.EatingSnack = false;
          this.Rival.Routine = false;
          this.Rival.InEvent = true;
          this.Rival.EmptyHands();
          ++this.Phase;
        }
      }
      ++this.Frame;
    }
    else
    {
      if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.VoiceSource == (UnityEngine.Object) null)
          this.VoiceSource = this.VoiceClip.GetComponent<AudioSource>();
        else
          this.VoiceSource.pitch = Time.timeScale;
      }
      if ((double) this.Rival.DistanceToDestination < (double) this.MinimumDistance)
      {
        this.Rival.MoveTowardsTarget(this.Location.position);
        if ((double) Quaternion.Angle(this.Rival.transform.rotation, this.Location.rotation) > 1.0)
          this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location.rotation, 10f * Time.deltaTime);
      }
      if (this.Phase == 1)
      {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          this.Yandere.transform.position = this.Location.position + new Vector3(2f, 0.0f, 2f);
          this.Rival.transform.position = this.Location.position + new Vector3(1f, 0.0f, 1f);
        }
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText[1];
          this.Rival.CharacterAnimation.CrossFade(this.EventAnim[1]);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.Rival.Obstacle.enabled = true;
          ++this.Phase;
        }
      }
      else if (this.Phase == 2)
      {
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[1]].time >= (double) this.Rival.CharacterAnimation[this.EventAnim[1]].length)
        {
          this.Rival.CharacterAnimation[this.EventAnim[2]].time = 7f;
          this.Rival.CharacterAnimation.CrossFade(this.EventAnim[2]);
          ++this.Phase;
        }
      }
      else if (this.Phase == 3)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.0)
        {
          AudioClipPlayer.Play(this.SpeechClip[3], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText[3];
          this.Rival.CharacterAnimation[this.EventAnim[3]].time = 7f;
          this.Rival.CharacterAnimation.CrossFade(this.EventAnim[3]);
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 4)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.0)
        {
          AudioClipPlayer.Play(this.SpeechClip[4], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.Rival.CharacterAnimation[this.EventAnim[4]].speed = 0.0f;
          this.Rival.CharacterAnimation.CrossFade(this.EventAnim[4]);
          this.MinimumDistance = 1f;
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 5)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 0.5)
        {
          this.Rival.CharacterAnimation[this.EventAnim[4]].speed = 1f;
          this.OsanaVandalismCollider.SetActive(true);
        }
        else
          this.Location.position = Vector3.MoveTowards(this.Location.position, new Vector3(-2f, 4f, -31.7f), Time.deltaTime * 5f);
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[4]].time > (double) this.Rival.CharacterAnimation[this.EventAnim[4]].length)
          this.Rival.CharacterAnimation[this.EventAnim[4]].time = 0.0f;
        if ((double) this.Timer > 5.5)
        {
          this.Rival.CharacterAnimation[this.EventAnim[4]].speed = 0.0f;
          this.OsanaVandalismCollider.SetActive(false);
        }
        if ((double) this.Timer > 6.0)
        {
          AudioClipPlayer.Play(this.SpeechClip[5], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText[5];
          this.Rival.CharacterAnimation[this.EventAnim[5]].time = 0.0f;
          this.Rival.CharacterAnimation.CrossFade(this.EventAnim[5]);
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 6)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.0)
          this.EndEvent();
      }
      if (this.Clock.Period > this.StartPeriod || this.Rival.Alarmed || this.Rival.Splashed || this.Rival.Dodging)
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
        if ((UnityEngine.Object) this.VoiceSource != (UnityEngine.Object) null)
          this.VoiceSource.volume = this.Scale;
      }
      else
      {
        this.EventSubtitle.transform.localScale = Vector3.zero;
        if ((UnityEngine.Object) this.VoiceSource != (UnityEngine.Object) null)
          this.VoiceSource.volume = 0.0f;
      }
      if (!((UnityEngine.Object) this.VoiceClip == (UnityEngine.Object) null))
        return;
      this.EventSubtitle.text = string.Empty;
    }
  }

  private void EndEvent()
  {
    Debug.Log((object) "Osana's vending machine event has ended.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if (!this.Rival.Alarmed)
    {
      this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
      this.Rival.DistanceToDestination = 100f;
      this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
      this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
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
    this.OsanaVandalismCollider.SetActive(false);
    this.Jukebox.Dip = 1f;
    this.EventSubtitle.text = string.Empty;
    this.enabled = false;
  }
}
