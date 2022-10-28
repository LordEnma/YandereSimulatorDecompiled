// Decompiled with JetBrains decompiler
// Type: OsanaMondayLunchEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaMondayLunchEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public OsanaClubEventScript ClubEvent;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public ClockScript Clock;
  public SpyScript Spy;
  public StudentScript Senpai;
  public StudentScript Friend;
  public StudentScript Rival;
  public BentoScript[] Bento;
  public string[] SabotagedSpeechText;
  public string[] SpeechText;
  public float[] SabotagedSpeechTime;
  public float[] SpeechTime;
  public AudioClip[] SpeechClip;
  public Transform[] Location;
  public Transform Epicenter;
  public GameObject AlarmDisc;
  public GameObject VoiceClip;
  public Vector3 OriginalPosition;
  public bool Sabotaged;
  public float Distance;
  public float Scale;
  public float Timer;
  public float RotationX;
  public float RotationY;
  public float RotationZ;
  public int SpeechPhase = 1;
  public int DebugPoison;
  public int FriendID = 6;
  public int RivalID = 11;
  public int Phase;
  public int Frame;

  private void Start()
  {
    this.OriginalPosition = this.Epicenter.position;
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Week <= 1 && DateGlobals.Weekday == DayOfWeek.Monday && !GameGlobals.AlphabetMode && !MissionModeGlobals.MissionMode && !GameGlobals.Eighties)
      return;
    this.gameObject.SetActive(false);
    this.enabled = false;
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      if (this.Frame > 0 && (UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null && this.StudentManager.Students[this.RivalID].enabled && this.StudentManager.Students[1].gameObject.activeInHierarchy && this.Clock.Period == 3 && !this.StudentManager.Students[this.RivalID].Meeting)
      {
        Debug.Log((object) "Osana's lunchtime event has begun.");
        if (this.ClubEvent.enabled)
          this.ClubEvent.EndEvent();
        this.DisableBentos();
        this.Bento[1].gameObject.SetActive(true);
        this.Bento[2].gameObject.SetActive(true);
        this.Senpai = this.StudentManager.Students[1];
        this.Rival = this.StudentManager.Students[this.RivalID];
        this.Friend = this.StudentManager.Students[this.FriendID];
        this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Senpai.CharacterAnimation.Play(this.Senpai.WalkAnim);
        this.Senpai.Pathfinding.target = this.Location[1];
        this.Senpai.CurrentDestination = this.Location[1];
        this.Senpai.SmartPhone.SetActive(false);
        this.Senpai.Pathfinding.canSearch = true;
        this.Senpai.Pathfinding.canMove = true;
        this.Senpai.Routine = false;
        this.Senpai.InEvent = true;
        this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
        this.Rival.Pathfinding.target = this.Location[0];
        this.Rival.CurrentDestination = this.Location[0];
        this.Rival.Pathfinding.canSearch = true;
        this.Rival.Pathfinding.canMove = true;
        this.Rival.Routine = false;
        this.Rival.InEvent = true;
        this.Rival.EmptyHands();
        this.Spy.gameObject.SetActive(true);
        if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
        {
          this.Friend.FocusOnYandere = false;
          this.Friend.Distracted = true;
          this.Friend.CanTalk = false;
          this.Friend.EmptyHands();
          this.Friend.SpeechLines.Stop();
        }
        this.Yandere.PauseScreen.Hint.Show = true;
        this.Yandere.PauseScreen.Hint.QuickID = 7;
        ++this.Phase;
      }
      ++this.Frame;
    }
    else if (this.Phase == 1)
    {
      if ((double) this.Rival.DistanceToDestination < 0.5)
      {
        this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
        ++this.SpeechPhase;
        AudioClipPlayer.Play(this.SpeechClip[0], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        this.Rival.CharacterAnimation["f02_pondering_00"].speed = 2f;
        this.Rival.CharacterAnimation.CrossFade("f02_pondering_00");
        this.Epicenter.position = this.Rival.transform.position;
        this.Rival.Pathfinding.canSearch = false;
        this.Rival.Pathfinding.canMove = false;
        ++this.Phase;
      }
    }
    else if (this.Phase == 2)
    {
      if (!this.Rival.GoAway)
        this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
      this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
      if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
      {
        this.Friend.Pathfinding.target = this.Rival.transform;
        this.Friend.CurrentDestination = this.Rival.transform;
      }
      if ((double) this.Rival.CharacterAnimation["f02_pondering_00"].time >= (double) this.Rival.CharacterAnimation["f02_pondering_00"].length)
      {
        this.Epicenter.position = this.OriginalPosition;
        this.EventSubtitle.text = string.Empty;
        this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
        this.Rival.Pathfinding.target = this.Location[2];
        this.Rival.CurrentDestination = this.Location[2];
        this.Rival.Pathfinding.canSearch = true;
        this.Rival.Pathfinding.canMove = true;
        this.Bento[1].gameObject.SetActive(false);
        this.Bento[2].gameObject.SetActive(false);
        if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
        {
          this.Rival.FollowTargetDestination.localPosition = new Vector3(0.0f, 0.0f, -0.5f);
          this.Friend.Pathfinding.target = this.Rival.FollowTargetDestination;
          this.Friend.CurrentDestination = this.Rival.FollowTargetDestination;
        }
        ++this.Phase;
      }
    }
    else if (this.Phase == 3)
    {
      if ((double) this.Senpai.DistanceToDestination < 0.5 && (double) this.Rival.DistanceToDestination < 0.5)
      {
        this.MakeRaibaruGoHide();
        AudioClipPlayer.Play(this.SpeechClip[1], this.Epicenter.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        this.Senpai.CharacterAnimation.CrossFade("Monday_2A");
        this.Rival.CharacterAnimation.CrossFade("f02_Monday_2A");
        this.Rival.Bento.transform.localEulerAngles = new Vector3(15f, this.Rival.Bento.transform.localEulerAngles.y, this.Rival.Bento.transform.localEulerAngles.z);
        this.Rival.Bento.transform.localPosition = new Vector3(-0.02f, this.Rival.Bento.transform.localPosition.y, this.Rival.Bento.transform.localPosition.z);
        this.Rival.Bento.SetActive(true);
        this.Senpai.Pathfinding.canSearch = false;
        this.Senpai.Pathfinding.canMove = false;
        this.Rival.Pathfinding.canSearch = false;
        this.Rival.Pathfinding.canMove = false;
        ++this.Phase;
      }
      else
      {
        if ((double) this.Senpai.DistanceToDestination < 0.5)
        {
          this.Senpai.CharacterAnimation.CrossFade("thinking_00");
          if (!this.Senpai.GoAway)
            this.Senpai.MoveTowardsTarget(this.Senpai.CurrentDestination.position);
          this.Senpai.transform.rotation = Quaternion.Slerp(this.Senpai.transform.rotation, this.Senpai.CurrentDestination.rotation, 10f * Time.deltaTime);
          this.Senpai.Pathfinding.canSearch = false;
          this.Senpai.Pathfinding.canMove = false;
        }
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          this.Rival.CharacterAnimation.CrossFade("f02_pondering_00");
          if (!this.Rival.GoAway)
            this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
          this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
        }
      }
    }
    else if (this.Phase == 4)
    {
      this.Timer += Time.deltaTime;
      this.MakeRaibaruGoHide();
      if (!this.Senpai.GoAway)
        this.Senpai.MoveTowardsTarget(this.Senpai.CurrentDestination.position);
      this.Senpai.transform.rotation = Quaternion.Slerp(this.Senpai.transform.rotation, this.Senpai.CurrentDestination.rotation, 10f * Time.deltaTime);
      if (!this.Rival.GoAway)
        this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
      this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
      if ((double) this.Timer > 21.5)
      {
        this.Senpai.Bento.transform.localPosition = new Vector3(-0.01652f, -0.02516f, -0.08239f);
        this.Senpai.Bento.transform.localEulerAngles = new Vector3(-35f, 116f, 165f);
        this.RotationX = -35f;
        this.RotationY = 115f;
        this.RotationZ = 165f;
        this.Senpai.Bento.SetActive(true);
        this.Rival.Bento.SetActive(false);
        ++this.Phase;
      }
    }
    else if (this.Phase == 5)
    {
      this.Timer += Time.deltaTime;
      this.RotationX = Mathf.Lerp(this.RotationX, 6f, Time.deltaTime);
      this.RotationY = Mathf.Lerp(this.RotationY, 153f, Time.deltaTime);
      this.RotationZ = Mathf.Lerp(this.RotationZ, 102.5f, Time.deltaTime);
      this.Senpai.Bento.transform.localPosition = Vector3.Lerp(this.Senpai.Bento.transform.localPosition, new Vector3(-0.045f, -0.08f, -0.025f), Time.deltaTime);
      this.Senpai.Bento.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
      if ((double) this.Timer > 29.833333969116211)
      {
        this.Senpai.Lid.transform.parent = this.Senpai.RightHand;
        this.Senpai.Lid.transform.localPosition = new Vector3(-0.025f, -0.025f, -0.015f);
        this.Senpai.Lid.transform.localEulerAngles = new Vector3(41.5f, -60f, -180f);
      }
      if ((double) this.Timer > 30.0 && (double) this.Bento[1].Poison > 0.0)
      {
        this.Senpai.CharacterAnimation.CrossFade("Monday_2B");
        this.Rival.CharacterAnimation.CrossFade("f02_Monday_2B");
        this.Sabotaged = true;
        this.SpeechPhase = 0;
      }
      if ((double) this.Timer > 30.433332443237305)
      {
        this.Senpai.Lid.transform.parent = (Transform) null;
        this.Senpai.Lid.transform.position = new Vector3(-0.31f, 12.501f, -29.335f);
        this.Senpai.Lid.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      }
      if ((double) this.Timer > 31.0)
      {
        this.Senpai.Chopsticks[0].SetActive(true);
        this.Senpai.Chopsticks[1].SetActive(true);
        ++this.Phase;
      }
    }
    else if (this.Phase == 6)
    {
      this.Timer += Time.deltaTime;
      if (!this.Sabotaged)
      {
        if ((double) this.Timer > 37.150001525878906)
        {
          AudioClipPlayer.Play(this.SpeechClip[2], this.Epicenter.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          ++this.Phase;
        }
      }
      else if ((double) this.Timer > 41.0)
      {
        AudioClipPlayer.Play(this.SpeechClip[3], this.Epicenter.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
        ++this.Phase;
      }
    }
    else if (this.Phase == 7)
    {
      this.Timer += Time.deltaTime;
      if (!this.Sabotaged)
      {
        if ((double) this.Senpai.CharacterAnimation["Monday_2A"].time > (double) this.Senpai.CharacterAnimation["Monday_2A"].length)
          this.EndEvent();
      }
      else
      {
        if ((double) this.Timer > 44.5 && (UnityEngine.Object) this.Senpai.Bento.transform.parent != (UnityEngine.Object) null)
        {
          this.Senpai.Bento.transform.parent = (Transform) null;
          this.Senpai.Bento.transform.position = new Vector3(-0.853f, 12.501f, -29.33333f);
          this.Senpai.Bento.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
          this.Senpai.Chopsticks[0].SetActive(false);
          this.Senpai.Chopsticks[1].SetActive(false);
        }
        if (this.Senpai.InEvent && (double) this.Senpai.CharacterAnimation["Monday_2B"].time > (double) this.Senpai.CharacterAnimation["Monday_2B"].length)
        {
          this.Senpai.WalkAnim = "stomachPainWalk_00";
          this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
          this.Senpai.Pathfinding.target = this.StudentManager.MaleVomitSpots[3];
          this.Senpai.CurrentDestination = this.StudentManager.MaleVomitSpots[3];
          this.Senpai.CharacterAnimation.CrossFade(this.Senpai.WalkAnim);
          this.Senpai.Pathfinding.canSearch = true;
          this.Senpai.Pathfinding.canMove = true;
          this.Senpai.Pathfinding.speed = 2f;
          this.Senpai.Distracted = true;
          this.Senpai.Vomiting = true;
          this.Senpai.InEvent = false;
          this.Senpai.Routine = false;
          this.Senpai.Private = true;
          ++this.StudentManager.SabotageProgress;
          Debug.Log((object) ("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5"));
        }
        if ((double) this.Rival.CharacterAnimation["f02_Monday_2B"].time > (double) this.Rival.CharacterAnimation["f02_Monday_2B"].length)
          this.EndEvent();
      }
    }
    if (this.Phase > 3)
    {
      if (!this.Sabotaged)
      {
        if (this.SpeechPhase < this.SpeechTime.Length && (double) this.Timer > (double) this.SpeechTime[this.SpeechPhase])
        {
          this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
          ++this.SpeechPhase;
        }
      }
      else if (this.SpeechPhase < this.SabotagedSpeechTime.Length && (double) this.Timer > 41.0 + (double) this.SabotagedSpeechTime[this.SpeechPhase])
      {
        this.EventSubtitle.text = this.SabotagedSpeechText[this.SpeechPhase];
        ++this.SpeechPhase;
      }
      if ((double) this.Friend.DistanceToDestination < 0.5)
      {
        this.Friend.CharacterAnimation.CrossFade("f02_cornerPeek_00");
        this.Friend.Pathfinding.canSearch = false;
        this.Friend.Pathfinding.canMove = false;
        if (!this.Friend.MyBento.gameObject.activeInHierarchy && !this.Friend.MyBento.Tampered)
        {
          this.Friend.MyBento.gameObject.SetActive(true);
          this.Friend.MyBento.transform.parent = (Transform) null;
          this.Friend.MyBento.transform.position = this.Bento[3].transform.position;
          this.Friend.MyBento.transform.eulerAngles = this.Bento[3].transform.eulerAngles;
          this.Friend.MyBento.Prompt.enabled = true;
        }
        this.SettleFriend();
      }
    }
    if (this.Phase <= 0)
      return;
    if (this.Clock.Period > 3 || this.Senpai.Alarmed || this.Rival.Alarmed || this.Rival.Wet || this.Rival.GoAway || this.Senpai.GoAway)
    {
      if (this.Senpai.Alarmed || this.Rival.Alarmed && !this.Rival.Wet)
        UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
      this.EndEvent();
    }
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
    this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position);
    if (!this.enabled)
      return;
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
      if (this.Phase <= 3)
        return;
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

  private void SettleFriend()
  {
    this.Friend.MoveTowardsTarget(this.Location[3].position);
    if ((double) Quaternion.Angle(this.Friend.transform.rotation, this.Location[3].rotation) <= 1.0)
      return;
    this.Friend.transform.rotation = Quaternion.Slerp(this.Friend.transform.rotation, this.Location[3].rotation, 10f * Time.deltaTime);
  }

  private void EndEvent()
  {
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    if (this.Senpai.InEvent)
    {
      this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      this.Senpai.InEvent = false;
      this.Senpai.Private = false;
      this.Senpai.Pathfinding.canSearch = true;
      this.Senpai.Pathfinding.canMove = true;
      this.Senpai.TargetDistance = 1f;
      this.Senpai.Routine = true;
    }
    this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.Rival.DistanceToDestination = 100f;
    this.Rival.Prompt.enabled = true;
    this.Rival.InEvent = false;
    this.Rival.Private = false;
    if (!this.Rival.Splashed)
    {
      this.Rival.Pathfinding.canSearch = true;
      this.Rival.Pathfinding.canMove = true;
    }
    else
    {
      this.Rival.Pathfinding.canSearch = false;
      this.Rival.Pathfinding.canMove = false;
    }
    this.Rival.TargetDistance = 1f;
    this.Rival.Routine = !this.Rival.Splashed;
    if (this.Rival.Alarmed || this.Senpai.Alarmed)
    {
      this.Senpai.Pathfinding.canSearch = false;
      this.Senpai.Pathfinding.canMove = false;
      this.Senpai.TargetDistance = 0.5f;
      this.Senpai.Routine = !this.Senpai.Alarmed;
      this.Rival.Pathfinding.canSearch = false;
      this.Rival.Pathfinding.canMove = false;
      this.Rival.TargetDistance = 0.5f;
      this.Rival.Routine = !this.Rival.Alarmed;
    }
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null && !this.Friend.Electrified)
    {
      if (!this.Friend.Alarmed)
      {
        this.Friend.Pathfinding.canSearch = true;
        this.Friend.Pathfinding.canMove = true;
        this.Friend.CanTalk = true;
        this.Friend.Routine = true;
      }
      this.Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      this.Friend.Prompt.enabled = true;
      this.Friend.InEvent = false;
      this.Friend.Private = false;
      ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[4];
      scheduleBlock.destination = "LunchSpot";
      scheduleBlock.action = "Eat";
      this.Friend.GetDestinations();
      this.Friend.CurrentDestination = this.Friend.Destinations[this.Friend.Phase];
      this.Friend.Pathfinding.target = this.Friend.Destinations[this.Friend.Phase];
      this.Friend.DistanceToDestination = 100f;
      this.Friend.MyBento.gameObject.SetActive(false);
      this.Friend.MyBento.transform.parent = this.Friend.LeftHand;
      this.Friend.MyBento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0.0f);
      this.Friend.MyBento.transform.localEulerAngles = new Vector3(0.0f, 165f, 82.5f);
      Debug.Log((object) "Osana's Monday lunch event ended, so Raibaru is being told to set her destination to her current phase's destination.");
    }
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Spy.Prompt.Hide();
    this.Spy.Prompt.enabled = false;
    if (this.Spy.Phase > 0)
      this.Spy.End();
    this.EventSubtitle.text = string.Empty;
    this.Yandere.Eavesdropping = false;
    this.enabled = false;
    this.Jukebox.Dip = 1f;
    Debug.Log((object) "Ending Osana's Monday Lunch Event.");
    if (this.Rival.GoAway)
    {
      this.Rival.Subtitle.CustomText = "Ugh, seriously?! Nevermind, Senpai...just forget it...";
      this.Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
    }
    this.DisableBentos();
  }

  private void DisableBentos()
  {
    this.Bento[1].Prompt.Hide();
    this.Bento[1].Prompt.enabled = false;
    this.Bento[2].Prompt.Hide();
    this.Bento[2].Prompt.enabled = false;
    this.Bento[1].gameObject.SetActive(false);
    this.Bento[2].gameObject.SetActive(false);
    this.Bento[1].enabled = false;
    this.Bento[2].enabled = false;
  }

  private void MakeRaibaruGoHide()
  {
    if (!((UnityEngine.Object) this.Friend != (UnityEngine.Object) null) || (double) this.Friend.DistanceToDestination <= 1.0)
      return;
    this.Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.Friend.CharacterAnimation.Play(this.Friend.WalkAnim);
    this.Friend.Pathfinding.target = this.Location[3];
    this.Friend.CurrentDestination = this.Location[3];
    this.Friend.Pathfinding.canSearch = true;
    this.Friend.Pathfinding.canMove = true;
    this.Friend.Distracted = false;
    this.Friend.Routine = false;
    this.Friend.InEvent = true;
  }
}
