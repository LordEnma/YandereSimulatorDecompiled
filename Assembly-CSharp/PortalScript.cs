// Decompiled with JetBrains decompiler
// Type: PortalScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PortalScript : MonoBehaviour
{
  public RivalMorningEventManagerScript[] MorningEvents;
  public OsanaMorningFriendEventScript[] FriendEvents;
  public OsanaMondayBeforeClassEventScript OsanaEvent;
  public RivalAfterClassEventManagerScript OsanaWednesdayAfterClassEvent;
  public RivalAfterClassEventManagerScript OsanaTuesdayAfterClassEvent;
  public OsanaThursdayAfterClassEventScript OsanaThursdayEvent;
  public OsanaFridayBeforeClassEvent1Script OsanaFridayEvent1;
  public OsanaFridayBeforeClassEvent2Script OsanaFridayEvent2;
  public OsanaTuesdayLunchEventScript OsanaTuesdayLunchEvent;
  public OsanaMondayLunchEventScript OsanaMondayLunchEvent;
  public OsanaFridayLunchEventScript OsanaFridayLunchEvent;
  public OsanaClubEventScript OsanaClubEvent;
  public OsanaPoolEventScript OsanaPoolEvent;
  public WashingMachineScript WashingMachine;
  public DelinquentManagerScript DelinquentManager;
  public StudentManagerScript StudentManager;
  public WeaponManagerScript WeaponManager;
  public LoveManagerScript LoveManager;
  public ReputationScript Reputation;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public PoliceScript Police;
  public PromptScript Prompt;
  public ClassScript Class;
  public ClockScript Clock;
  public GameObject EvidenceWarning;
  public GameObject HeartbeatCamera;
  public GameObject Headmaster;
  public GameObject Paper;
  public UISprite ClassDarkness;
  public Texture HomeMapMarker;
  public Renderer MapMarker;
  public Transform Teacher;
  public bool ReturningFromLecture;
  public bool CanAttendClass;
  public bool BypassWarning;
  public bool LateReport1;
  public bool LateReport2;
  public bool Transition;
  public bool FadeOut;
  public bool Proceed;
  public float OriginalDOF;
  public float Timer;
  public int Late;
  public UILabel BottomLabel;
  public UILabel AttendClassLabel;
  public UILabel CorpsesLabel;
  public UILabel BodyPartsLabel;
  public UILabel BloodStainsLabel;
  public UILabel BloodyClothingLabel;
  public UILabel BloodyWeaponsLabel;
  public GenericRivalEventScript[] MorningGenericEvents;
  public GenericRivalEventScript[] LunchGenericEvents;
  public GenericRivalEventScript[] FinalGenericEvents;
  public bool EndedFinalEvents;

  private void Start()
  {
    this.EvidenceWarning.SetActive(false);
    this.ClassDarkness.enabled = false;
    if (!GameGlobals.EightiesTutorial)
      return;
    this.gameObject.SetActive(false);
  }

  private void Update()
  {
    if ((double) this.Clock.HourTime > 8.52000045776367 && (double) this.Clock.HourTime < 8.52999973297119 && !this.Yandere.InClass && !this.LateReport1)
    {
      this.LateReport1 = true;
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Late);
    }
    if ((double) this.Clock.HourTime > 13.5200004577637 && (double) this.Clock.HourTime < 13.5299997329712 && !this.Yandere.InClass && !this.LateReport2)
    {
      this.LateReport2 = true;
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Late);
    }
    bool flag1 = false;
    if (this.EvidenceWarning.activeInHierarchy)
    {
      if (Input.GetButtonDown("A"))
      {
        this.EvidenceWarning.SetActive(false);
        this.BypassWarning = true;
        flag1 = true;
      }
      if (Input.GetButtonDown("B"))
      {
        this.EvidenceWarning.SetActive(false);
        this.Yandere.CanMove = true;
      }
    }
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0 | flag1)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.BypassWarning && this.Police.Corpses - this.Police.HiddenCorpses > 0 || !this.BypassWarning && this.Police.LimbParent.childCount > 0 || !this.BypassWarning && this.Police.BloodParent.childCount > 0 || !this.BypassWarning && this.Police.BloodyClothing > 0 || !this.BypassWarning && this.Police.BloodyWeapons > 0)
      {
        string str = "";
        if (this.WashingMachine.Washing)
          str = "     (The washing machine is still running.)";
        this.CorpsesLabel.text = "Corpses: " + (this.Police.Corpses - this.Police.HiddenCorpses).ToString();
        this.BodyPartsLabel.text = "Body Parts: " + this.Police.LimbParent.childCount.ToString();
        this.BloodStainsLabel.text = "Blood Stains: " + this.Police.BloodParent.childCount.ToString();
        this.BloodyClothingLabel.text = "Bloody Clothing: " + this.Police.BloodyClothing.ToString() + str;
        this.BloodyWeaponsLabel.text = "Bloody Weapons: " + this.Police.BloodyWeapons.ToString();
        if ((double) this.Clock.HourTime > 13.5)
        {
          this.BottomLabel.text = "If you try to leave school right now, the police will be called.";
          this.AttendClassLabel.text = "Leave School";
        }
        this.EvidenceWarning.SetActive(true);
        this.Yandere.CanMove = false;
      }
      else
      {
        this.CheckForLateness();
        this.Reputation.UpdateRep();
        bool flag2 = false;
        if ((double) this.Clock.HourTime > 13.0)
          this.CheckForPoison();
        if (this.Police.PoisonScene || this.Police.SuicideScene && this.Police.Corpses - this.Police.HiddenCorpses > 0 || this.Police.Corpses - this.Police.HiddenCorpses > 0 || this.Police.BloodParent.childCount > 0 || (double) this.Reputation.Reputation <= -100.0)
          this.EndDay();
        else if ((double) this.Clock.HourTime < 15.5)
        {
          if (!this.Police.Show)
          {
            bool flag3 = false;
            if ((Object) this.StudentManager.Teachers[21] != (Object) null && (double) this.StudentManager.Teachers[21].DistanceToDestination < 1.0)
              flag3 = true;
            if (this.StudentManager.Eighties && (Object) this.StudentManager.Students[this.StudentManager.RivalID] != (Object) null)
              this.StudentManager.Students[this.StudentManager.RivalID].PlaceBag();
            if (this.Late > 0 & flag3)
            {
              this.Yandere.Subtitle.UpdateLabel(SubtitleType.TeacherLateReaction, this.Late, 5.5f);
              this.Yandere.RPGCamera.enabled = false;
              this.Yandere.ShoulderCamera.Scolding = true;
              this.Yandere.ShoulderCamera.Teacher = this.Teacher;
            }
            else
            {
              this.ClassDarkness.enabled = true;
              this.Transition = true;
              this.FadeOut = true;
            }
            this.Clock.StopTime = true;
          }
          else
            this.EndDay();
        }
        else if (this.Yandere.Inventory.RivalPhone && !this.StudentManager.RivalEliminated)
        {
          this.Yandere.NotificationManager.CustomText = "Put the stolen phone on the owner's desk!";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          this.Yandere.NotificationManager.CustomText = "You are carrying a stolen phone!";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          flag2 = true;
        }
        else
        {
          this.EndFinalEvents();
          this.EndDay();
        }
        if (!flag2)
        {
          if ((double) this.Clock.HourTime < 15.5)
          {
            this.Yandere.CharacterAnimation.CrossFade("f02_takingNotes_00");
            this.Yandere.LifeNotePen.SetActive(true);
            this.Yandere.LifeNotePen.GetComponent<Renderer>().material.color = new Color(1f, 0.0f, 0.0f, 1f);
            this.Yandere.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
            this.Paper.SetActive(true);
          }
          else
            this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
          this.Yandere.YandereVision = false;
          this.Yandere.CanMove = false;
          if ((double) this.Clock.HourTime < 15.5)
          {
            this.Yandere.InClass = true;
            if ((double) this.Clock.HourTime < 8.5)
            {
              this.EndEvents();
            }
            else
            {
              this.StudentManager.CheckBentos();
              if ((Object) this.StudentManager.Students[11] != (Object) null && this.StudentManager.Students[11].Alive && this.OsanaMondayLunchEvent.Bento[2].Poison == 2)
              {
                Debug.Log((object) "The player poisoned Osana, so we're killing her automatically.");
                this.StudentManager.Students[11].DeathType = DeathType.Poison;
                this.StudentManager.Students[11].BecomeRagdoll();
                this.ClassDarkness.enabled = false;
                this.Yandere.InClass = false;
                this.Transition = false;
                this.FadeOut = false;
                this.EndDay();
              }
              else if ((Object) this.StudentManager.Students[10] != (Object) null && this.StudentManager.Students[10].Alive && this.OsanaMondayLunchEvent.Bento[3].Poison == 2)
              {
                Debug.Log((object) "The player poisoned Raibaru, so we're killing her automatically.");
                this.StudentManager.Students[10].DeathType = DeathType.Poison;
                this.StudentManager.Students[10].BecomeRagdoll();
                this.ClassDarkness.enabled = false;
                this.Yandere.InClass = false;
                this.Transition = false;
                this.FadeOut = false;
                this.EndDay();
              }
              else
                this.EndLaterEvents();
            }
          }
        }
      }
    }
    if (this.Transition)
    {
      if (this.FadeOut)
      {
        this.Yandere.CharacterAnimation.CrossFade("f02_takingNotes_00");
        this.Yandere.MoveTowardsTarget(new Vector3(-9.62f, 4f, -26f));
        if (this.LoveManager.HoldingHands)
          this.LoveManager.Rival.transform.position = new Vector3(0.0f, 0.0f, -50f);
        this.ClassDarkness.alpha = Mathf.MoveTowards(this.ClassDarkness.alpha, 1f, Time.deltaTime);
        if ((double) this.ClassDarkness.alpha == 1.0)
        {
          if (this.Yandere.Resting)
          {
            this.StudentManager.Mirror.UpdatePersona();
            this.Yandere.OriginalIdleAnim = this.Yandere.IdleAnim;
            this.Yandere.OriginalWalkAnim = this.Yandere.WalkAnim;
            this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
            this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0.0f);
            this.Yandere.Resting = false;
            this.Yandere.Health = 10;
            this.FadeOut = false;
            this.Proceed = true;
            this.ClassDarkness.alpha = 1f;
            this.Yandere.CameraEffects.UpdateDOF(this.OriginalDOF);
          }
          else
          {
            if (this.Yandere.Armed)
              this.Yandere.Unequip();
            this.HeartbeatCamera.SetActive(false);
            this.FadeOut = false;
            this.Proceed = false;
            this.Yandere.RPGCamera.enabled = false;
            this.Yandere.MainCamera.transform.position = new Vector3(-10.25f, 5f, -26.5f);
            this.Yandere.MainCamera.transform.eulerAngles = new Vector3(0.0f, 45f, 0.0f);
            this.OriginalDOF = this.Yandere.CameraEffects.Profile.depthOfField.settings.focusDistance;
            this.Yandere.CameraEffects.UpdateDOF(0.6f);
            this.Clock.gameObject.SetActive(false);
            this.StudentManager.Reputation.gameObject.SetActive(false);
            this.Yandere.SanityLabel.transform.parent.gameObject.SetActive(false);
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[4].text = "Choose";
            this.PromptBar.Label[5].text = "Allocate";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.Class.StudyPoints += PlayerGlobals.PantiesEquipped == 7 ? 10 : 5;
            this.Class.StudyPoints += this.Class.BonusPoints;
            this.Class.BonusPoints = 0;
            this.Class.StudyPoints -= this.Late;
            this.Class.UpdateLabel();
            this.Class.gameObject.SetActive(true);
            this.Class.Show = true;
            if (this.Police.Show)
              this.Police.Timer = 1E-06f;
          }
        }
      }
      else if (this.Proceed)
      {
        if (this.ReturningFromLecture)
        {
          this.ClassDarkness.alpha = 1f;
          this.ReturningFromLecture = false;
          this.Yandere.CameraEffects.UpdateDOF(this.OriginalDOF);
        }
        if ((double) this.ClassDarkness.color.a == 1.0)
        {
          Debug.Log((object) "The PortalScript is now changing the time of day.");
          this.HeartbeatCamera.SetActive(true);
          this.Clock.enabled = true;
          this.Yandere.FixCamera();
          this.Yandere.RPGCamera.enabled = false;
          if ((double) this.Clock.HourTime < 13.0)
          {
            if (this.StudentManager.Bully && this.StudentManager.Bullies > 0)
              this.StudentManager.UpdateGraffiti();
            this.Yandere.Incinerator.Timer -= 780f - this.Clock.PresentTime;
            this.DelinquentManager.CheckTime();
            this.Clock.PresentTime = 780f;
          }
          else
          {
            this.Yandere.Incinerator.Timer -= 930f - this.Clock.PresentTime;
            this.DelinquentManager.CheckTime();
            this.Clock.PresentTime = 930f;
          }
          this.Clock.HourTime = this.Clock.PresentTime / 60f;
          this.StudentManager.AttendClass();
        }
        this.ClassDarkness.alpha = Mathf.MoveTowards(this.ClassDarkness.alpha, 0.0f, Time.deltaTime);
        if ((double) this.ClassDarkness.color.a == 0.0)
        {
          this.ClassDarkness.enabled = false;
          this.Clock.StopTime = false;
          this.Transition = false;
          this.Proceed = false;
          this.Yandere.RPGCamera.enabled = true;
          this.Yandere.InClass = false;
          this.Yandere.CanMove = true;
          this.Yandere.LifeNotePen.SetActive(false);
          this.Yandere.LifeNotePen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
          this.Paper.SetActive(false);
          this.Clock.gameObject.SetActive(true);
          this.StudentManager.Reputation.gameObject.SetActive(true);
          this.Yandere.SanityLabel.transform.parent.gameObject.SetActive(true);
          this.StudentManager.ResumeMovement();
          if ((double) this.Clock.HourTime > 15.0)
            this.StudentManager.TakeOutTheTrash();
          if (!MissionModeGlobals.MissionMode)
          {
            if (this.Headmaster.activeInHierarchy)
              this.Headmaster.SetActive(false);
            else
              this.Headmaster.SetActive(true);
          }
        }
      }
      else
      {
        this.Yandere.CharacterAnimation.CrossFade("f02_takingNotes_00");
        this.ClassDarkness.alpha = Mathf.MoveTowards(this.ClassDarkness.alpha, 0.0f, Time.deltaTime);
      }
    }
    if ((double) this.Clock.HourTime > 15.5)
    {
      if ((double) this.transform.position.z >= 0.0)
        return;
      this.StudentManager.RemovePapersFromDesks();
      if (!MissionModeGlobals.MissionMode)
      {
        this.MapMarker.material.mainTexture = this.HomeMapMarker;
        this.transform.position = new Vector3(0.0f, 1f, -75f);
        this.Prompt.Label[0].text = "     Go Home";
        this.Prompt.enabled = true;
      }
      else
      {
        this.transform.position = new Vector3(0.0f, -10f, 0.0f);
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else
    {
      if (this.Yandere.Police.FadeOut || (double) Vector3.Distance(this.Yandere.transform.position, this.transform.position) >= 1.39999997615814)
        return;
      this.CanAttendClass = true;
      this.CheckForProblems();
      if (!this.CanAttendClass)
      {
        if ((double) this.Timer == 0.0)
        {
          if (this.Yandere.Armed)
            this.Yandere.NotificationManager.CustomText = "Carrying Weapon";
          else if ((double) this.Yandere.Bloodiness > 0.0)
            this.Yandere.NotificationManager.CustomText = "Bloody";
          else if ((double) this.Yandere.Sanity < 33.3330001831055)
            this.Yandere.NotificationManager.CustomText = "Visibly Insane";
          else if (this.Yandere.Attacking)
            this.Yandere.NotificationManager.CustomText = "In Combat";
          else if (this.Yandere.Dragging || this.Yandere.Carrying)
            this.Yandere.NotificationManager.CustomText = "Holding Corpse";
          else if ((Object) this.Yandere.PickUp != (Object) null)
            this.Yandere.NotificationManager.CustomText = "Carrying Item";
          else if (this.Yandere.Chased || this.Yandere.Chasers > 0)
            this.Yandere.NotificationManager.CustomText = "Chased";
          else if ((bool) (Object) this.StudentManager.Reporter && !this.Police.Show)
            this.Yandere.NotificationManager.CustomText = "Murder being reported";
          else if (this.StudentManager.MurderTakingPlace)
            this.Yandere.NotificationManager.CustomText = "Murder taking place";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          this.Yandere.NotificationManager.CustomText = "Cannot attend class. Reason:";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.Timer += Time.deltaTime;
        if ((double) this.Timer <= 5.0)
          return;
        this.Timer = 0.0f;
      }
      else
        this.Prompt.enabled = true;
    }
  }

  public void CheckForProblems()
  {
    if (!this.Yandere.Armed && (double) this.Yandere.Bloodiness <= 0.0 && (double) this.Yandere.Sanity >= 33.3330001831055 && !this.Yandere.Attacking && !this.Yandere.Dragging && !this.Yandere.Carrying && !((Object) this.Yandere.PickUp != (Object) null) && !this.Yandere.Chased && this.Yandere.Chasers <= 0 && (!((Object) this.StudentManager.Reporter != (Object) null) || this.Police.Show) && !this.StudentManager.MurderTakingPlace)
      return;
    this.CanAttendClass = false;
  }

  public void EndDay()
  {
    Debug.Log((object) "Ending the day through the Portal script.");
    this.StudentManager.StopMoving();
    this.Yandere.StopLaughing();
    this.Yandere.EmptyHands();
    this.Clock.StopTime = true;
    if ((double) this.Clock.HourTime < 15.5)
    {
      Debug.Log((object) "It's before 3:30 PM.");
      if (!this.Police.SelfReported)
        this.Yandere.transform.position = new Vector3(-9.62f, 4f, -26f);
    }
    this.Police.Darkness.enabled = true;
    this.Police.FadeOut = true;
    this.Police.DayOver = true;
    if (SchemeGlobals.GetSchemeStage(6) == 8)
    {
      SchemeGlobals.SetSchemeStage(6, 9);
      this.Yandere.PauseScreen.Schemes.UpdateInstructions();
    }
    if (!this.Police.SelfReported)
      return;
    this.ReturningFromLecture = false;
    this.CanAttendClass = false;
    this.BypassWarning = false;
    this.LateReport1 = false;
    this.LateReport2 = false;
    this.Transition = false;
    this.FadeOut = false;
    this.Proceed = false;
  }

  private void CheckForLateness()
  {
    this.Late = 0;
    if ((double) this.Clock.HourTime < 13.0)
    {
      if ((double) this.Clock.HourTime < 8.52000045776367)
        this.Late = 0;
      else if ((double) this.Clock.HourTime < 10.0)
        this.Late = 1;
      else if ((double) this.Clock.HourTime < 11.0)
        this.Late = 2;
      else if ((double) this.Clock.HourTime < 12.0)
        this.Late = 3;
      else if ((double) this.Clock.HourTime < 13.0)
        this.Late = 4;
    }
    else if ((double) this.Clock.HourTime < 13.5200004577637)
      this.Late = 0;
    else if ((double) this.Clock.HourTime < 14.0)
      this.Late = 1;
    else if ((double) this.Clock.HourTime < 14.5)
      this.Late = 2;
    else if ((double) this.Clock.HourTime < 15.0)
      this.Late = 3;
    else if ((double) this.Clock.HourTime < 15.5)
      this.Late = 4;
    this.Reputation.PendingRep -= (float) (5 * this.Late);
    int late = this.Late;
  }

  public void EndEvents()
  {
    for (int index = 0; index < this.MorningEvents.Length; ++index)
    {
      if (this.MorningEvents[index].enabled)
        this.MorningEvents[index].EndEvent();
    }
    for (int index = 0; index < this.FriendEvents.Length; ++index)
    {
      if (this.FriendEvents[index].enabled)
        this.FriendEvents[index].EndEvent();
    }
    if (this.OsanaEvent.enabled)
      this.OsanaEvent.EndEvent();
    if (this.OsanaClubEvent.enabled)
      this.OsanaClubEvent.EndEvent();
    if (!this.OsanaClubEvent.enabled && !this.OsanaClubEvent.ReachedTheEnd && !this.StudentManager.Eighties)
    {
      Debug.Log((object) "The Portal is checking the Osana Club Event.");
      this.OsanaClubEvent.CheckForRooftopConvo();
    }
    if (this.OsanaFridayEvent1.enabled)
      this.OsanaFridayEvent1.EndEvent();
    if (this.OsanaFridayEvent2.enabled)
      this.OsanaFridayEvent2.EndEvent();
    for (int index = 1; index < this.MorningGenericEvents.Length; ++index)
    {
      if (this.MorningGenericEvents[index].enabled)
      {
        this.MorningGenericEvents[index].NaturalEnd = true;
        this.MorningGenericEvents[index].EndEvent();
      }
    }
  }

  public void EndLaterEvents()
  {
    if (this.OsanaMondayLunchEvent.enabled && this.OsanaMondayLunchEvent.Phase > 0 && this.OsanaMondayLunchEvent.Bento[1].Poison > 0)
    {
      Debug.Log((object) "We're skipping past Osana's Monday lunchtime event, but it was was sabotaged, so we're incrementing the Sabotage count.");
      ++this.StudentManager.SabotageProgress;
    }
    if (this.OsanaFridayLunchEvent.enabled && (Object) this.OsanaFridayLunchEvent.Rival != (Object) null && this.OsanaFridayLunchEvent.Rival.InEvent && this.OsanaFridayLunchEvent.AudioSoftware.AudioDoctored)
    {
      Debug.Log((object) "We're skipping past Osana's Friday lunchtime event, but it was was sabotaged, so we're incrementing the Sabotage count.");
      ++this.StudentManager.SabotageProgress;
    }
    if (this.OsanaPoolEvent.Phase > 0)
      this.OsanaPoolEvent.EndEvent();
    if (this.OsanaFridayLunchEvent.enabled)
      this.OsanaFridayLunchEvent.EndEvent();
    for (int index = 1; index < this.LunchGenericEvents.Length; ++index)
    {
      if (this.LunchGenericEvents[index].enabled)
      {
        if (this.LunchGenericEvents[index].Sabotaged)
        {
          Debug.Log((object) "We're skipping past a generic rival lunchtime event, but it was was sabotaged, so we're incrementing the Sabotage count.");
          ++this.StudentManager.SabotageProgress;
        }
        this.LunchGenericEvents[index].EndEvent();
      }
    }
    Debug.Log((object) ("Sabotage Progress is currently: " + this.StudentManager.SabotageProgress.ToString()));
  }

  public void EndFinalEvents()
  {
    this.EndedFinalEvents = true;
    if (this.OsanaTuesdayAfterClassEvent.enabled && this.OsanaTuesdayAfterClassEvent.Sabotaged)
    {
      Debug.Log((object) "We're skipping past Osana's Tuesday talk-to-Senpai-outside-of-school event, but it was was sabotaged, so we're incrementing the Sabotage count.");
      ++this.StudentManager.SabotageProgress;
    }
    if (this.OsanaWednesdayAfterClassEvent.enabled && (Object) this.OsanaWednesdayAfterClassEvent.Rival != (Object) null && this.OsanaWednesdayAfterClassEvent.Rival.LewdPhotos)
    {
      Debug.Log((object) "We're skipping past Osana's Wednesday talk-to-Senpai-outside-of-school event, but it was was sabotaged, so we're incrementing the Sabotage count.");
      ++this.StudentManager.SabotageProgress;
    }
    if (this.OsanaThursdayEvent.enabled && this.OsanaThursdayEvent.Phase > 0 && this.OsanaThursdayEvent.Sabotaged)
    {
      Debug.Log((object) "We're skipping past Osana's Thursday rooftop event, but it was was sabotaged, so we're incrementing the Sabotage count.");
      ++this.StudentManager.SabotageProgress;
    }
    for (int index = 1; index < this.FinalGenericEvents.Length; ++index)
    {
      if (this.FinalGenericEvents[index].enabled)
      {
        if (this.FinalGenericEvents[index].Sabotaged || index == 3 && this.StudentManager.Students[this.StudentManager.RivalID].Sleepy)
        {
          Debug.Log((object) "We're skipping past a generic rival after-class event, but it was was sabotaged, so we're incrementing the Sabotage count.");
          ++this.StudentManager.SabotageProgress;
        }
        this.FinalGenericEvents[index].EndEvent();
      }
    }
    Debug.Log((object) ("End of day. Sabotage Progress is " + this.StudentManager.SabotageProgress.ToString() + " out of 5."));
  }

  public void CheckForPoison()
  {
    for (int index = 0; index < this.StudentManager.Students.Length; ++index)
    {
      if ((Object) this.StudentManager.Students[index] != (Object) null && this.StudentManager.Students[index].Alive && this.StudentManager.Students[index].MyBento.Lethal)
      {
        this.Police.SkippingPastPoison = true;
        this.StudentManager.Students[index].Ragdoll.Poisoned = true;
        this.StudentManager.Students[index].BecomeRagdoll();
        this.StudentManager.Students[index].DeathType = DeathType.Poison;
      }
    }
  }
}
