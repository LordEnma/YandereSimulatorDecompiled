// Decompiled with JetBrains decompiler
// Type: OsanaThursdayAfterClassEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaThursdayAfterClassEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public PhoneMinigameScript PhoneMinigame;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public StudentScript Friend;
  public StudentScript Rival;
  public Transform FriendLocation;
  public Transform Location;
  public AudioClip[] SpeechClip;
  public string[] SpeechText;
  public string[] EventAnim;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public float FriendWarningTimer;
  public float ReturnTimer;
  public float Distance;
  public float Scale;
  public float Timer;
  public DayOfWeek EventDay;
  public int FriendID = 10;
  public int RivalID = 11;
  public int Phase;
  public int Frame;
  public bool ReturningFromSave;
  public bool FriendWarned;
  public bool Sabotaged;
  public Vector3 OriginalPosition;
  public Vector3 OriginalRotation;

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
        if ((UnityEngine.Object) this.StudentManager.Students[this.FriendID] != (UnityEngine.Object) null && !PlayerGlobals.RaibaruLoner)
          this.Friend = this.StudentManager.Students[this.FriendID];
        if ((double) this.Clock.HourTime > 16.0100002288818 && this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless && !this.Rival.EndSearch)
          this.BeginEvent();
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
          AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.Rival.CharacterAnimation.CrossFade(this.EventAnim[1]);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.Rival.Obstacle.enabled = true;
          ++this.Phase;
          if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
          {
            ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[7];
            scheduleBlock.destination = "Sketch";
            scheduleBlock.action = "Sketch";
            this.Friend.GetDestinations();
            this.Friend.SketchPosition = this.FriendLocation;
            this.Friend.CurrentDestination = this.Friend.SketchPosition;
            this.Friend.Pathfinding.target = this.Friend.SketchPosition;
            this.Friend.Restless = true;
          }
        }
      }
      else if (this.Phase == 2)
      {
        this.Rival.transform.position = Vector3.Lerp(this.Rival.transform.position, this.Rival.CurrentDestination.position, 10f * Time.deltaTime);
        this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[1]].time >= 3.2)
        {
          this.EventSubtitle.text = this.SpeechText[1];
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 3)
      {
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[1]].time >= 6.0)
        {
          this.Rival.SmartPhoneScreen.enabled = true;
          this.Rival.SmartPhone.SetActive(true);
          ++this.Phase;
        }
      }
      else if (this.Phase == 4)
      {
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[1]].time >= 13.33333)
        {
          this.OriginalPosition = this.Rival.SmartPhone.transform.localPosition;
          this.OriginalRotation = this.Rival.SmartPhone.transform.localEulerAngles;
          this.Rival.SmartPhone.transform.parent = (Transform) null;
          this.Rival.SmartPhone.transform.position = new Vector3(0.5f, 12.5042f, -29.365f);
          this.Rival.SmartPhone.transform.eulerAngles = new Vector3(0.0f, 180f, 180f);
          ++this.Phase;
        }
      }
      else if (this.Phase == 5)
      {
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[1]].time >= (double) this.Rival.CharacterAnimation[this.EventAnim[1]].length)
        {
          this.Rival.CharacterAnimation.Play(this.EventAnim[2]);
          this.PhoneMinigame.Prompt.enabled = true;
          this.Rival.Ragdoll.Zs.SetActive(true);
          this.EventSubtitle.text = "";
          this.Rival.Distracted = true;
          ++this.Phase;
          this.StudentManager.UpdateMe(this.RivalID);
        }
      }
      else if (this.Phase == 6)
      {
        if (!this.Sabotaged && !this.PhoneMinigame.Tampering)
        {
          if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null && !this.FriendWarned)
          {
            if ((double) this.FriendWarningTimer == 0.0)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Friend.transform.position) < 5.0)
              {
                AudioClipPlayer.Play(this.SpeechClip[3], this.Friend.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
                this.EventSubtitle.text = this.SpeechText[3];
                this.FriendWarningTimer += Time.deltaTime;
              }
            }
            else
            {
              this.FriendWarningTimer += Time.deltaTime;
              if ((double) this.FriendWarningTimer > 5.0)
                this.FriendWarned = true;
            }
          }
          if ((double) this.Clock.HourTime > 17.2)
          {
            AudioClipPlayer.Play(this.SpeechClip[2], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.Rival.CharacterAnimation.CrossFade(this.EventAnim[3]);
            this.Rival.Ragdoll.Zs.SetActive(false);
            this.Rival.Hurry = true;
            ++this.Phase;
            this.PhoneMinigame.Prompt.enabled = false;
            this.PhoneMinigame.Prompt.Hide();
          }
        }
      }
      else if (this.Phase == 7)
      {
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[3]].time >= 2.5)
        {
          this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
          this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
          this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
          ++this.Phase;
        }
      }
      else if (this.Phase == 8)
      {
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[3]].time >= 3.5)
        {
          this.Rival.SmartPhone.SetActive(false);
          ++this.Phase;
        }
      }
      else if (this.Phase == 9)
      {
        if ((double) this.Rival.CharacterAnimation[this.EventAnim[3]].time >= 4.65)
        {
          this.EventSubtitle.text = this.SpeechText[2];
          ++this.Phase;
        }
      }
      else if (this.Phase == 10 && (double) this.Rival.CharacterAnimation[this.EventAnim[3]].time >= (double) this.Rival.CharacterAnimation[this.EventAnim[3]].length)
        this.EndEvent();
      if (this.Rival.Alarmed || this.Rival.Splashed || this.Rival.Dodging || this.Rival.DiscCheck || this.Rival.Dying)
        this.EndEvent();
      if (!this.Sabotaged)
      {
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
        if ((UnityEngine.Object) this.VoiceClip == (UnityEngine.Object) null)
          this.EventSubtitle.text = string.Empty;
      }
    }
    if (!this.ReturningFromSave)
      return;
    this.ReturnTimer += Time.deltaTime;
    if ((double) this.ReturnTimer <= 1.0)
      return;
    this.ReturnFromSave();
  }

  public void EndEvent()
  {
    Debug.Log((object) "Osana's Thursday after class event has ended.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if (!this.Rival.Alarmed && !this.Rival.Attacked)
    {
      this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
      this.Rival.DistanceToDestination = 100f;
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
    this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
    this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
    this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
    {
      ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[7];
      scheduleBlock.destination = "Follow";
      scheduleBlock.action = "Follow";
      this.Friend.GetDestinations();
      if (!this.Friend.ReturningMisplacedWeapon)
      {
        this.Friend.CurrentDestination = this.Friend.FollowTarget.transform;
        this.Friend.Pathfinding.target = this.Friend.FollowTarget.transform;
        this.Friend.EmptyHands();
      }
      this.Friend.Restless = false;
    }
    this.PhoneMinigame.Prompt.enabled = false;
    this.PhoneMinigame.Prompt.Hide();
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Jukebox.Dip = 1f;
    this.EventSubtitle.text = string.Empty;
    this.enabled = false;
  }

  public void ReturnFromSave()
  {
    this.ReturningFromSave = false;
    this.BeginEvent();
  }

  public void BeginEvent()
  {
    Debug.Log((object) "Osana's Thursday after class event has begun.");
    this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
    this.Rival.Pathfinding.target = this.Location;
    this.Rival.CurrentDestination = this.Location;
    this.Rival.Pathfinding.canSearch = true;
    this.Rival.Pathfinding.canMove = true;
    this.Rival.Routine = false;
    this.Rival.InEvent = true;
    this.Rival.Drownable = false;
    this.Rival.StudentManager.UpdateMe(this.Rival.StudentID);
    this.Rival.Scrubber.SetActive(false);
    this.Rival.Eraser.SetActive(false);
    this.Yandere.PauseScreen.Hint.Show = true;
    this.Yandere.PauseScreen.Hint.QuickID = 19;
    this.Phase = 1;
  }
}
