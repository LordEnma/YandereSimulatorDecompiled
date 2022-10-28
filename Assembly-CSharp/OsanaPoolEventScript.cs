// Decompiled with JetBrains decompiler
// Type: OsanaPoolEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class OsanaPoolEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public JukeboxScript Jukebox;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public ClockScript Clock;
  public StudentScript Friend;
  public StudentScript Rival;
  public Transform[] Location;
  public AudioClip[] SpeechClip;
  public string[] SpeechText;
  public string[] EventAnim;
  public GameObject AlarmDisc;
  public GameObject BigSplash;
  public GameObject VoiceClip;
  public GameObject Weight;
  public bool Murdering;
  public float StinkTimer;
  public float Distance;
  public float Scale;
  public float Timer;
  public DayOfWeek EventDay;
  public int MurderPhase = 1;
  public int FriendID = 10;
  public int RivalID = 11;
  public int Phase;
  public int Frame;

  private void Start()
  {
    if (!GameGlobals.Eighties && DateGlobals.Weekday == this.EventDay)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      if (this.Frame > 0)
      {
        if (this.StudentManager.VictimID == this.RivalID)
          this.enabled = false;
        else if ((UnityEngine.Object) this.StudentManager.Students[this.RivalID] != (UnityEngine.Object) null && this.StudentManager.Students[this.RivalID].enabled && this.Clock.Period == 3)
        {
          Debug.Log((object) "Osana's pool event has begun.");
          if ((UnityEngine.Object) this.StudentManager.Students[this.FriendID] != (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[this.FriendID].FollowTarget != (UnityEngine.Object) null)
          {
            this.Friend = this.StudentManager.Students[this.FriendID];
            if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
              this.Friend.CanTalk = false;
          }
          this.Rival = this.StudentManager.Students[this.RivalID];
          this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Rival.MyRenderer.updateWhenOffscreen = true;
          this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
          this.Rival.Pathfinding.target = this.StudentManager.FemaleStripSpot;
          this.Rival.CurrentDestination = this.StudentManager.FemaleStripSpot;
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.Pen.SetActive(false);
          this.Rival.Routine = false;
          this.Rival.InEvent = true;
          this.Rival.StinkBombSpecialCase = 1;
          this.Rival.SmartPhone.SetActive(false);
          this.Yandere.PauseScreen.Hint.Show = true;
          this.Yandere.PauseScreen.Hint.QuickID = 17;
          ++this.Phase;
        }
      }
      ++this.Frame;
    }
    else
    {
      if (this.Rival.StinkBombSpecialCase == 2)
      {
        Debug.Log((object) "Osana is holding her breath.");
        this.StinkTimer += Time.deltaTime;
        if ((double) this.StinkTimer > 1.0)
        {
          this.Rival.StinkBombSpecialCase = 1;
          this.StinkTimer = 0.0f;
        }
      }
      else if (this.Phase == 1)
      {
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          if ((UnityEngine.Object) this.StudentManager.CommunalLocker.Student == (UnityEngine.Object) null)
          {
            this.Rival.StudentManager.CommunalLocker.Open = true;
            this.Rival.StudentManager.CommunalLocker.Student = this.Rival;
            this.Rival.StudentManager.CommunalLocker.SpawnSteam();
            this.Rival.Schoolwear = 2;
            ++this.Phase;
          }
          else
            this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
        }
      }
      else if (this.Phase == 2)
      {
        if (!this.Rival.StudentManager.CommunalLocker.SteamCountdown)
        {
          this.StudentManager.CommunalLocker.Student = (StudentScript) null;
          if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
          {
            ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[this.Friend.Phase];
            scheduleBlock.destination = "Sunbathe";
            scheduleBlock.action = "Sunbathe";
            this.Friend.Actions[this.Friend.Phase] = StudentActionType.Sunbathe;
            this.Friend.CurrentAction = StudentActionType.Sunbathe;
            this.Friend.GetDestinations();
            this.Friend.CurrentDestination = this.StudentManager.FemaleStripSpot;
            this.Friend.Pathfinding.target = this.StudentManager.FemaleStripSpot;
            this.Friend.Pathfinding.canSearch = true;
            this.Friend.Pathfinding.canMove = true;
          }
          this.Rival.Pathfinding.target = this.Location[1];
          this.Rival.CurrentDestination = this.Location[1];
          ++this.Phase;
        }
      }
      else if (this.Phase == 3)
      {
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText[1];
          this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].time = 0.0f;
          this.Rival.CharacterAnimation.Play("f02_" + this.EventAnim[1]);
          this.Rival.OsanaHair.GetComponent<Animation>().Play("Hair_" + this.EventAnim[1]);
          this.Rival.OsanaHair.transform.parent = this.Rival.transform;
          this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
          this.Rival.OsanaHair.transform.localPosition = Vector3.zero;
          this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
          this.Rival.OsanaHairL.enabled = false;
          this.Rival.OsanaHairR.enabled = false;
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.Rival.Pathfinding.speed = 0.0f;
          this.Rival.transform.eulerAngles = this.Location[1].eulerAngles;
          ++this.Phase;
        }
        else
        {
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.Pathfinding.speed = 1f;
          this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
        }
      }
      else if (this.Phase == 4)
      {
        this.Timer += Time.deltaTime;
        if (!this.Rival.GoAway)
          this.Rival.MoveTowardsTarget(this.Location[1].position);
        if ((double) this.Timer > 5.533329963684082)
        {
          this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[2]);
          this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[2]);
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 5)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 10.0)
        {
          AudioClipPlayer.Play(this.SpeechClip[2], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText[2];
          this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[3]);
          this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[3]);
          this.Rival.Ragdoll.Zs.SetActive(true);
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 6)
      {
        if (this.MurderPhase < 2)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Clock.HourTime > 13.375)
          {
            AudioClipPlayer.Play(this.SpeechClip[3], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.EventSubtitle.text = this.SpeechText[3];
            this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[2]);
            this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[2]);
            this.Prompt.Hide();
            this.Prompt.gameObject.SetActive(false);
            this.Rival.Ragdoll.Zs.SetActive(false);
            this.Timer = 0.0f;
            ++this.Phase;
          }
        }
      }
      else if (this.Phase == 7)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.0)
        {
          AudioClipPlayer.Play(this.SpeechClip[4], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.EventSubtitle.text = this.SpeechText[4];
          this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[4]);
          this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[4]);
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 8)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 4.3333301544189453)
        {
          Debug.Log((object) "Now moving from Phase 8 to Phase 9.");
          this.AttachHair();
          this.Rival.Pathfinding.target = this.StudentManager.FemaleStripSpot;
          this.Rival.CurrentDestination = this.StudentManager.FemaleStripSpot;
          this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
          this.Rival.Pathfinding.canSearch = true;
          this.Rival.Pathfinding.canMove = true;
          this.Rival.Pathfinding.speed = 1f;
          if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
          {
            ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[this.Friend.Phase];
            scheduleBlock.destination = "Follow";
            scheduleBlock.action = "Follow";
            this.Friend.GetDestinations();
            this.Friend.CurrentDestination = this.Friend.FollowTarget.transform;
            this.Friend.Pathfinding.target = this.Friend.FollowTarget.transform;
            this.Friend.Pathfinding.canSearch = true;
            this.Friend.Pathfinding.canMove = true;
            this.Friend.Pathfinding.speed = 1f;
          }
          ++this.Phase;
        }
      }
      else if (this.Phase == 9)
      {
        this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
        this.Rival.Pathfinding.canSearch = true;
        this.Rival.Pathfinding.canMove = true;
        if ((double) this.Rival.DistanceToDestination < 0.5)
        {
          if ((UnityEngine.Object) this.StudentManager.CommunalLocker.Student == (UnityEngine.Object) null)
          {
            this.Rival.StudentManager.CommunalLocker.Open = true;
            this.Rival.StudentManager.CommunalLocker.Student = this.Rival;
            this.Rival.StudentManager.CommunalLocker.SpawnSteam();
            this.Rival.Schoolwear = 1;
            if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
              this.StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this.Friend);
            ++this.Phase;
          }
          else
            this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
        }
      }
      else if (this.Phase == 10 && !this.Rival.StudentManager.CommunalLocker.SteamCountdown)
      {
        this.Rival.StudentManager.CommunalLocker.Student = (StudentScript) null;
        this.EndEvent();
      }
      if (this.Phase == 6)
      {
        if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null)
          this.Prompt.enabled = this.Yandere.PickUp.Weight;
        else
          this.Prompt.enabled = false;
      }
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Hide();
        this.Prompt.gameObject.SetActive(false);
        this.Murdering = true;
        this.Rival.Blind = true;
        this.Yandere.CanMove = false;
        this.Rival.Distracted = true;
        this.Rival.Ragdoll.Zs.SetActive(false);
        this.Yandere.CharacterAnimation.CrossFade("f02_" + this.EventAnim[5]);
        this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[6]);
        this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[6]);
      }
      if (this.Murdering)
      {
        if (this.Yandere.Chased)
        {
          this.Murdering = false;
          this.Weight.GetComponent<Animation>().Stop();
          this.Rival.OsanaHair.GetComponent<Animation>().Stop();
          this.Rival.CharacterAnimation.GetComponent<Animation>().Stop();
        }
        this.Yandere.MoveTowardsTarget(this.Location[2].position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.Location[2].rotation, Time.deltaTime * 10f);
        if ((double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > 1.0 && (UnityEngine.Object) this.Weight.transform.parent != (UnityEngine.Object) this.Location[3])
        {
          this.Yandere.EmptyHands();
          this.Weight.transform.parent = this.Location[3];
          this.Weight.transform.localPosition = Vector3.zero;
          this.Weight.transform.localEulerAngles = Vector3.zero;
          this.Weight.GetComponent<Animation>().Play("Weight_" + this.EventAnim[5]);
          this.Weight.GetComponent<Animation>()["Weight_" + this.EventAnim[5]].time = this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time;
        }
        if (this.MurderPhase == 1)
        {
          if ((double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > 10.0)
          {
            this.Yandere.MurderousActionTimer = 999f;
            this.Rival.SpawnAlarmDisc();
            AudioClipPlayer.Play(this.SpeechClip[5], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.EventSubtitle.text = this.SpeechText[5];
            ++this.MurderPhase;
          }
        }
        else if (this.MurderPhase == 2)
        {
          if ((double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > 14.5)
          {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BigSplash, this.Location[4].position, Quaternion.identity);
            gameObject.transform.eulerAngles = new Vector3(-90f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
            ++this.MurderPhase;
          }
        }
        else if (this.MurderPhase == 3 && (double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > 14.833333015441895)
        {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BigSplash, this.Location[4].position, Quaternion.identity);
          gameObject.transform.eulerAngles = new Vector3(-90f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
          ++this.MurderPhase;
        }
        if ((double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > (double) this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].length)
        {
          this.Yandere.MurderousActionTimer = 0.0f;
          this.Yandere.CanMove = true;
          this.Murdering = false;
          this.Rival.NoRagdoll = true;
          this.Rival.BecomeRagdoll();
          this.Rival.DeathType = DeathType.Drowning;
          this.Yandere.Police.EndOfDay.PoolEvent = true;
        }
      }
      if ((double) this.Clock.HourTime > 13.5 || this.Rival.Alarmed || this.Rival.Splashed || this.Rival.Attacked || this.Rival.Stop)
        this.EndEvent();
      if (this.Phase > 2 && this.Phase < 8 && this.Rival.StinkBombSpecialCase == 2)
      {
        Debug.Log((object) "Skipping directly to Phase 8 now.");
        this.AttachHair();
        this.Phase = 8;
      }
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
    Debug.Log((object) "Osana's pool event has ended.");
    if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
    this.Rival.Pathfinding.speed = 1f;
    if (!this.Rival.Alarmed && !this.Rival.Attacked && !this.Rival.Stop)
    {
      this.Rival.Pathfinding.canSearch = true;
      this.Rival.Pathfinding.canMove = true;
      this.Rival.Routine = true;
      this.Rival.Schoolwear = 1;
      this.Rival.ChangeSchoolwear();
    }
    if (this.Rival.Schoolwear != 1)
    {
      this.Rival.CurrentDestination = this.Rival.StudentManager.StrippingPositions[this.Rival.GirlID];
      this.Rival.Pathfinding.target = this.Rival.StudentManager.StrippingPositions[this.Rival.GirlID];
      this.Rival.NotActuallyWet = true;
      this.Rival.Wet = true;
    }
    this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.Rival.MyRenderer.updateWhenOffscreen = false;
    this.Rival.Ragdoll.Zs.SetActive(false);
    this.Rival.Obstacle.enabled = false;
    this.Rival.StinkBombSpecialCase = 0;
    this.Rival.Prompt.enabled = true;
    this.Rival.InEvent = false;
    this.Rival.Private = false;
    if (!this.StudentManager.Stop)
      this.StudentManager.UpdateStudents();
    this.Rival.OsanaHair.GetComponent<Animation>().Stop();
    this.Rival.OsanaHair.transform.parent = this.Rival.Head;
    this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
    this.Rival.OsanaHair.transform.localPosition = new Vector3(0.0f, -1.442789f, 0.01900469f);
    this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
    this.Rival.OsanaHairL.enabled = true;
    this.Rival.OsanaHairR.enabled = true;
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
    {
      ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[this.Friend.Phase];
      scheduleBlock.destination = "Follow";
      scheduleBlock.action = "Follow";
      this.Friend.GetDestinations();
      if ((UnityEngine.Object) this.Friend.FollowTarget != (UnityEngine.Object) null)
      {
        this.Friend.CurrentDestination = this.Friend.FollowTarget.transform;
        this.Friend.Pathfinding.target = this.Friend.FollowTarget.transform;
      }
      this.Friend.Pathfinding.canSearch = true;
      this.Friend.Pathfinding.canMove = true;
      this.Friend.CanTalk = true;
    }
    this.EventSubtitle.text = string.Empty;
    this.enabled = false;
    this.Jukebox.Dip = 1f;
    if (!this.Rival.GoAway)
      return;
    this.Rival.Subtitle.CustomText = "Ugh, seriously?! Forget about sunbathing...";
    this.Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
  }

  public void ReturnFromSave()
  {
    this.Rival = this.StudentManager.Students[this.RivalID];
    this.Friend = this.StudentManager.Students[this.FriendID];
    if ((UnityEngine.Object) this.Friend != (UnityEngine.Object) null)
    {
      ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[this.Friend.Phase];
      scheduleBlock.destination = "Sunbathe";
      scheduleBlock.action = "Sunbathe";
      this.Friend.Actions[this.Friend.Phase] = StudentActionType.Sunbathe;
      this.Friend.CurrentAction = StudentActionType.Sunbathe;
      this.Friend.GetDestinations();
      this.Friend.CurrentDestination = this.StudentManager.FemaleStripSpot;
      this.Friend.Pathfinding.target = this.StudentManager.FemaleStripSpot;
      this.Friend.Pathfinding.canSearch = true;
      this.Friend.Pathfinding.canMove = true;
    }
    this.Rival.Pathfinding.target = this.Location[1];
    this.Rival.CurrentDestination = this.Location[1];
    this.Phase = 3;
  }

  public void AttachHair()
  {
    this.Rival.OsanaHair.GetComponent<Animation>().Stop();
    this.Rival.OsanaHair.transform.parent = this.Rival.Head;
    this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
    this.Rival.OsanaHair.transform.localPosition = new Vector3(0.0f, -1.442789f, 0.01900469f);
    this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
    this.Rival.OsanaHairL.enabled = true;
    this.Rival.OsanaHairR.enabled = true;
  }
}
