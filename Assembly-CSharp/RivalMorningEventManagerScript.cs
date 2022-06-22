// Decompiled with JetBrains decompiler
// Type: RivalMorningEventManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class RivalMorningEventManagerScript : MonoBehaviour
{
  public OsanaMorningFriendEventScript OsanaLoseFriendEvent;
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
  public AudioClip SpeechClip;
  public string[] SpeechText;
  public float[] SpeechTime;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public AudioSource VoiceClipSource;
  public bool NaturalEnd;
  public bool HintGiven;
  public bool Transfer;
  public bool End;
  public float TransferTime;
  public float Distance;
  public float Scale;
  public float Timer;
  public DayOfWeek EventDay;
  public int SpeechPhase = 1;
  public int FriendID = 6;
  public int RivalID = 11;
  public int Phase;
  public int Frame;
  public string Weekday = string.Empty;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    this.Spy.Prompt.enabled = true;
    if (DateGlobals.Weekday == DayOfWeek.Sunday)
      DateGlobals.Weekday = DayOfWeek.Monday;
    if (DateGlobals.Weekday != this.EventDay || HomeGlobals.LateForSchool || this.StudentManager.YandereLate || DatingGlobals.SuitorProgress == 2 || StudentGlobals.MemorialStudents > 0 || GameGlobals.RivalEliminationID > 0 || StudentGlobals.StudentSlave == this.RivalID || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || DateGlobals.Week > 1 || GameGlobals.Eighties || this.StudentManager.RecordingVideo)
    {
      this.Spy.Prompt.enabled = false;
      this.enabled = false;
    }
    if (!this.enabled || (double) StudentGlobals.GetStudentReputation(10) > -33.3333282470703)
      return;
    this.OsanaLoseFriendEvent.OtherEvent = this;
  }

  private void Update()
  {
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.VoiceClipSource == (UnityEngine.Object) null)
        this.VoiceClipSource = this.VoiceClip.GetComponent<AudioSource>();
      else
        this.VoiceClipSource.pitch = Time.timeScale;
    }
    if (this.Phase == 0)
    {
      if (this.Frame > 0 && (UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null && this.StudentManager.Students[1].gameObject.activeInHierarchy && (UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null)
      {
        Debug.Log((object) "Osana's morning Senpai interaction event is now taking place.");
        if ((UnityEngine.Object) this.StudentManager.Students[this.FriendID] != (UnityEngine.Object) null && !PlayerGlobals.RaibaruLoner && StudentGlobals.StudentSlave != this.FriendID)
        {
          this.Friend = this.StudentManager.Students[this.FriendID];
          if (this.Friend.Investigating)
            this.Friend.StopInvestigating();
          if ((double) StudentGlobals.GetStudentReputation(10) > -33.3333282470703)
          {
            this.Friend.CharacterAnimation.Play("f02_cornerPeek_00");
            this.Friend.Cheer.enabled = true;
          }
          else
            this.Friend.CharacterAnimation.Play(this.Friend.BulliedIdleAnim);
          this.Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Friend.transform.position = this.Location[3].position;
          this.Friend.transform.eulerAngles = this.Location[3].eulerAngles;
          this.Friend.Pathfinding.canSearch = false;
          this.Friend.Pathfinding.canMove = false;
          this.Friend.IgnoringPettyActions = true;
          this.Friend.ImmuneToLaughter = true;
          this.Friend.VisionDistance = 20f;
          this.Friend.Routine = false;
          this.Friend.InEvent = true;
          this.Friend.Spawned = true;
        }
        this.Senpai = this.StudentManager.Students[1];
        this.Rival = this.StudentManager.Students[this.RivalID];
        this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Senpai.CharacterAnimation.Play(this.Senpai.IdleAnim);
        this.Senpai.transform.position = this.Location[1].position;
        this.Senpai.transform.eulerAngles = this.Location[1].eulerAngles;
        this.Senpai.Pathfinding.canSearch = false;
        this.Senpai.Pathfinding.canMove = false;
        this.Senpai.Routine = false;
        this.Senpai.InEvent = true;
        this.Senpai.Spawned = true;
        this.Senpai.Prompt.Hide();
        this.Senpai.Prompt.enabled = false;
        if (this.Rival.Investigating)
          this.Rival.StopInvestigating();
        this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Rival.CharacterAnimation.Play(this.Rival.IdleAnim);
        this.Rival.transform.position = this.Location[2].position;
        this.Rival.transform.eulerAngles = this.Location[2].eulerAngles;
        this.Rival.Pathfinding.canSearch = false;
        this.Rival.Pathfinding.canMove = false;
        this.Rival.Routine = false;
        this.Rival.InEvent = true;
        this.Rival.Spawned = true;
        this.Rival.Private = true;
        this.Rival.Prompt.Hide();
        this.Rival.Prompt.enabled = false;
        this.Spy.Prompt.enabled = true;
        ++this.Phase;
        if (this.EventDay == DayOfWeek.Tuesday)
          this.StudentManager.Students[1].EventBook.SetActive(true);
      }
      ++this.Frame;
    }
    else if (this.Phase == 1)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0)
      {
        AudioClipPlayer.Play(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        this.Rival.CharacterAnimation.CrossFade("f02_" + this.Weekday + "_1");
        this.Senpai.CharacterAnimation.CrossFade(this.Weekday + "_1");
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0 && !this.HintGiven)
      {
        this.Yandere.PauseScreen.Hint.Show = true;
        this.Yandere.PauseScreen.Hint.QuickID = 1;
        this.HintGiven = true;
      }
      if ((UnityEngine.Object) this.VoiceClipSource != (UnityEngine.Object) null)
        this.VoiceClipSource.pitch = Time.timeScale;
      if (this.SpeechPhase < this.SpeechTime.Length)
      {
        if ((double) this.Timer > (double) this.SpeechTime[this.SpeechPhase])
        {
          if ((double) Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position) < 11.0)
            this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
          ++this.SpeechPhase;
        }
      }
      else
      {
        if ((UnityEngine.Object) this.Senpai == (UnityEngine.Object) null)
          this.Senpai = this.StudentManager.Students[1];
        if ((double) this.Senpai.CharacterAnimation[this.Weekday + "_1"].time >= (double) this.Senpai.CharacterAnimation[this.Weekday + "_1"].length)
        {
          Debug.Log((object) "This rival morning event ended naturally because the animation finished playing.");
          this.NaturalEnd = true;
          this.EndEvent();
        }
      }
      if (this.Transfer && (double) this.Rival.CharacterAnimation["f02_" + this.Weekday + "_1"].time > (double) this.TransferTime)
      {
        this.Senpai.EventBook.SetActive(false);
        this.Rival.EventBook.SetActive(true);
        this.Transfer = false;
      }
      if (this.Clock.Period > 1)
      {
        Debug.Log((object) "The event ended because the school period has advanced.");
        this.EndEvent();
      }
      if ((UnityEngine.Object) this.Rival != (UnityEngine.Object) null && (this.Senpai.Alarmed || this.Rival.Alarmed || (UnityEngine.Object) this.Friend != (UnityEngine.Object) null && this.Friend.DramaticReaction))
      {
        Debug.Log((object) "The event ended naturally because a character was alarmed.");
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Rival.transform.position + Vector3.up, Quaternion.identity);
        gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
        gameObject.transform.localScale = new Vector3(150f, 1f, 150f);
        gameObject.GetComponent<AlarmDiscScript>().FocusOnYandere = true;
        this.EndEvent();
      }
      if (!this.Yandere.NoDebug && Input.GetKeyDown(KeyCode.LeftControl))
        this.EndEvent();
      this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position);
      if (this.enabled)
      {
        if ((double) this.Distance - 4.0 < 15.0)
        {
          this.Scale = Mathf.Abs((float) (1.0 - ((double) this.Distance - 4.0) / 15.0));
          if ((double) this.Scale < 0.0)
            this.Scale = 0.0f;
          if ((double) this.Scale > 1.0)
            this.Scale = 1f;
          this.Jukebox.Dip = (float) (1.0 - 0.5 * (double) this.Scale);
          this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
          if ((UnityEngine.Object) this.VoiceClipSource != (UnityEngine.Object) null)
            this.VoiceClipSource.volume = this.Scale;
          this.Yandere.Eavesdropping = (double) this.Distance < 3.0;
        }
        else
        {
          if ((double) this.Distance - 4.0 < 16.0)
            this.EventSubtitle.transform.localScale = Vector3.zero;
          if ((UnityEngine.Object) this.VoiceClipSource != (UnityEngine.Object) null)
            this.VoiceClipSource.volume = 0.0f;
        }
      }
    }
    if (!this.End)
      return;
    Debug.Log((object) "The event ended naturally because the ''End'' variable was set to ''true''.");
    this.EndEvent();
  }

  public void EndEvent()
  {
    Debug.Log((object) "Osana's morning ''Talk with Senpai'' event has ended.");
    if (this.Phase <= 0 || !this.Rival.Alive)
      return;
    if (this.EventDay == DayOfWeek.Tuesday)
    {
      ScheduleBlock scheduleBlock1 = this.Senpai.ScheduleBlocks[2];
      scheduleBlock1.destination = "Patrol";
      scheduleBlock1.action = "Patrol";
      ScheduleBlock scheduleBlock2 = this.Senpai.ScheduleBlocks[7];
      scheduleBlock2.destination = "Patrol";
      scheduleBlock2.action = "Patrol";
      this.Senpai.GetDestinations();
    }
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
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
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
    {
      if (!this.Friend.Alarmed && !this.Friend.DramaticReaction)
      {
        this.Friend.Pathfinding.canSearch = true;
        this.Friend.Pathfinding.canMove = true;
        this.Friend.Routine = true;
      }
      if (this.NaturalEnd)
      {
        this.Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
        this.Friend.Prompt.enabled = true;
        this.Friend.InEvent = false;
        this.Friend.Private = false;
      }
      else
      {
        this.Friend.Pathfinding.target = this.Location[3];
        this.Friend.CurrentDestination = this.Location[3];
      }
      this.Friend.Cheer.enabled = false;
      this.Friend.ImmuneToLaughter = false;
      this.Friend.IgnoringPettyActions = false;
    }
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Spy.Prompt.Hide();
    this.Spy.Prompt.enabled = false;
    if (this.Spy.Phase > 0)
      this.Spy.End();
    this.Yandere.Eavesdropping = false;
    this.EventSubtitle.text = string.Empty;
    this.enabled = false;
    this.Jukebox.Dip = 1f;
  }
}
