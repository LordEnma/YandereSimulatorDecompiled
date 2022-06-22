// Decompiled with JetBrains decompiler
// Type: OsanaFridayBeforeClassEvent1Script
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaFridayBeforeClassEvent1Script : MonoBehaviour
{
  public OsanaFridayBeforeClassEvent2Script OtherEvent;
  public StudentManagerScript StudentManager;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript Rival;
  public Transform Location;
  public AudioClip[] SpeechClip;
  public string[] SpeechText;
  public string EventAnim;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public GameObject Yoogle;
  public float Distance;
  public float Scale;
  public float Timer;
  public DayOfWeek EventDay;
  public int RivalID = 11;
  public int Phase;
  public int Frame;
  public Vector3 OriginalPosition;
  public Vector3 OriginalRotation;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Weekday != this.EventDay || StudentGlobals.StudentSlave == this.RivalID || this.StudentManager.RivalEliminated || GameGlobals.Eighties)
      this.enabled = false;
    this.Yoogle.SetActive(false);
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      if (this.Frame > 0 && (UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.Rival == (UnityEngine.Object) null)
          this.Rival = this.StudentManager.Students[this.RivalID];
        if (this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless && this.Rival.Indoors && !this.OtherEvent.enabled)
        {
          Debug.Log((object) "Osana's ''make playlist'' event has begun.");
          this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
          this.Rival.Pathfinding.target = this.Location;
          this.Rival.CurrentDestination = this.Location;
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.Routine = false;
          this.Rival.InEvent = true;
          this.Yandere.PauseScreen.Hint.Show = true;
          this.Yandere.PauseScreen.Hint.QuickID = 15;
          ++this.Phase;
        }
      }
      ++this.Frame;
    }
    else
    {
      if (this.Phase == 1)
      {
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText[1];
          this.Rival.CharacterAnimation.CrossFade(this.EventAnim);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.Rival.Obstacle.enabled = true;
          this.Rival.Distracted = true;
          this.Yoogle.SetActive(true);
          ++this.Phase;
        }
      }
      else if (this.Phase == 2)
      {
        this.Rival.MoveTowardsTarget(this.Location.position);
        if ((double) Quaternion.Angle(this.Rival.transform.rotation, this.Location.rotation) > 1.0)
          this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location.rotation, 10f * Time.deltaTime);
        this.Timer += Time.deltaTime;
        if (Input.GetKeyDown("space"))
          this.Timer += 60f;
        if ((double) this.Timer > 60.0)
          this.EndEvent();
      }
      if (this.Rival.Alarmed || (double) this.Clock.HourTime > 8.0 || this.Rival.Splashed || this.Rival.Dodging)
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

  public void EndEvent()
  {
    Debug.Log((object) "Osana's Friday before class event has ended.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if ((UnityEngine.Object) this.Rival != (UnityEngine.Object) null)
    {
      if (this.Rival.enabled && !this.Rival.Alarmed && !this.Rival.Splashed)
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
      this.Rival.SmartPhoneScreen.enabled = false;
      this.Rival.Ragdoll.Zs.SetActive(false);
      this.Rival.Obstacle.enabled = false;
      this.Rival.Prompt.enabled = true;
      this.Rival.Distracted = false;
      this.Rival.InEvent = false;
      this.Rival.Private = false;
      this.Yoogle.SetActive(false);
      this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
      this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
      this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
    }
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Jukebox.Dip = 1f;
    this.EventSubtitle.text = string.Empty;
    this.enabled = false;
  }
}
