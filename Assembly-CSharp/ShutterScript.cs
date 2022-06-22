// Decompiled with JetBrains decompiler
// Type: ShutterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class ShutterScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public TaskManagerScript TaskManager;
  public PauseScreenScript PauseScreen;
  public StudentInfoScript StudentInfo;
  public PromptBarScript PromptBar;
  public SubtitleScript Subtitle;
  public SchemesScript Schemes;
  public StudentScript Student;
  public YandereScript Yandere;
  public StudentScript FaceStudent;
  public RenderTexture SmartphoneScreen;
  public Camera SmartphoneCamera;
  public Camera MainCamera;
  public Transform SelfieRayParent;
  public Transform TextMessages;
  public Transform ErrorWindow;
  public Transform Palm;
  public UILabel PhotoDescLabel;
  public UISprite Sprite;
  public GameObject NotificationManager;
  public GameObject BullyPhotoCollider;
  public GameObject PhotoDescription;
  public GameObject HeartbeatCamera;
  public GameObject EightiesCamera;
  public GameObject CameraButtons;
  public GameObject NewMessage;
  public GameObject PhotoIcons;
  public GameObject MainMenu;
  public GameObject SubPanel;
  public GameObject Message;
  public GameObject Panel;
  public GameObject ViolenceX;
  public GameObject PantiesX;
  public GameObject SenpaiX;
  public GameObject BullyX;
  public GameObject InfoX;
  public bool BountyComplete;
  public bool AirGuitarShot;
  public bool DisplayError;
  public bool MissionMode;
  public bool PlushieShot;
  public bool BountyShot;
  public bool HorudaShot;
  public bool KittenShot;
  public bool OsanaShot;
  public bool FreeSpace;
  public bool TakePhoto;
  public bool TookPhoto;
  public bool Snapping;
  public bool Close;
  public bool Disguise;
  public bool Nemesis;
  public bool NotFace;
  public bool Skirt;
  public RaycastHit hit;
  public float ReactionDistance;
  public float PenaltyTimer;
  public float Timer;
  private float currentPercent;
  public int TargetStudent;
  public int NemesisShots;
  public int Frame;
  public int Slot;
  public int ID;
  public string PlushieName = "";
  public AudioSource MyAudio;
  public Vector3 OriginalPosition;

  public int OnlyPhotography => 65537;

  public int OnlyCharacters => 513;

  public int OnlyRagdolls => 2049;

  public int OnlyBlood => 16385;

  private void Start()
  {
    if (MissionModeGlobals.MissionMode)
      this.MissionMode = true;
    this.ErrorWindow.transform.localScale = Vector3.zero;
    this.CameraButtons.SetActive(false);
    this.PhotoIcons.SetActive(false);
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0.0f);
    this.OriginalPosition = this.PhotoIcons.transform.localPosition;
  }

  private void Update()
  {
    int num = this.Yandere.Selfie ? 1 : 0;
    if (this.Snapping)
    {
      if (this.Yandere.Noticed)
      {
        this.ResumeGameplay();
        this.Yandere.StopAiming();
      }
      else if (this.Close)
      {
        for (this.currentPercent += 60f * Time.unscaledDeltaTime; (double) this.currentPercent >= 1.0; --this.currentPercent)
          this.Frame = Mathf.Min(this.Frame + 1, 8);
        this.Sprite.spriteName = "Shutter" + this.Frame.ToString();
        if (this.Frame == 8)
        {
          this.StudentManager.GhostChan.gameObject.SetActive(true);
          this.PhotoDescription.SetActive(false);
          this.PhotoDescLabel.text = "";
          this.StudentManager.GhostChan.Look();
          this.CheckPhoto();
          if (this.PhotoDescLabel.text == "")
            this.PhotoDescLabel.text = "Cannot determine subject of photo. Try again.";
          this.PhotoDescription.SetActive(true);
          this.SmartphoneCamera.targetTexture = (RenderTexture) null;
          this.Yandere.PhonePromptBar.Show = false;
          this.NotificationManager.SetActive(false);
          this.HeartbeatCamera.SetActive(false);
          this.PhotoIcons.transform.localPosition = this.OriginalPosition;
          this.Yandere.SelfieGuide.SetActive(false);
          this.MainCamera.enabled = false;
          this.PhotoIcons.SetActive(true);
          this.SubPanel.SetActive(false);
          this.Panel.SetActive(false);
          this.Close = false;
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Save";
          this.PromptBar.Label[1].text = "Delete";
          if (!this.Yandere.RivalPhone)
            this.PromptBar.Label[2].text = "Send";
          else if (this.PantiesX.activeInHierarchy)
            this.PromptBar.Label[0].text = "";
          if (this.StudentManager.Eighties)
            this.PromptBar.Label[2].text = "";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
          Time.timeScale = 0.0001f;
        }
      }
      else
      {
        for (this.currentPercent += 60f * Time.unscaledDeltaTime; (double) this.currentPercent >= 1.0; --this.currentPercent)
          this.Frame = Mathf.Max(this.Frame - 1, 1);
        this.Sprite.spriteName = "Shutter" + this.Frame.ToString();
        if (this.Frame == 1)
        {
          this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0.0f);
          this.Snapping = false;
        }
      }
    }
    else if (this.Yandere.Aiming)
    {
      this.TargetStudent = 0;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5)
      {
        Vector3 direction = this.Yandere.Selfie ? this.SelfieRayParent.TransformDirection(Vector3.forward) : this.SmartphoneCamera.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyPhotography))
        {
          if (this.hit.collider.gameObject.name == "Face")
          {
            GameObject gameObject = this.hit.collider.gameObject.transform.root.gameObject;
            this.FaceStudent = gameObject.GetComponent<StudentScript>();
            if ((UnityEngine.Object) this.FaceStudent != (UnityEngine.Object) null)
            {
              this.TargetStudent = this.FaceStudent.StudentID;
              this.ReactionDistance = this.TargetStudent <= 1 ? this.FaceStudent.VisionDistance : 1.66666f;
              bool enabled = this.FaceStudent.ShoeRemoval.enabled;
              if (!this.FaceStudent.Alarmed && !this.FaceStudent.Dying && !this.FaceStudent.Distracted && !this.FaceStudent.InEvent && !this.FaceStudent.Wet && this.FaceStudent.Schoolwear > 0 && !this.FaceStudent.Fleeing && !this.FaceStudent.Following && !enabled && !this.FaceStudent.HoldingHands && this.FaceStudent.Actions[this.FaceStudent.Phase] != StudentActionType.Mourn && !this.FaceStudent.Guarding && !this.FaceStudent.Confessing && !this.FaceStudent.DiscCheck && !this.FaceStudent.TurnOffRadio && !this.FaceStudent.Investigating && !this.FaceStudent.Distracting && !this.FaceStudent.WitnessedLimb && !this.FaceStudent.WitnessedWeapon && !this.FaceStudent.WitnessedBloodPool && !this.FaceStudent.WitnessedBloodyWeapon && !this.FaceStudent.SentHome && !this.FaceStudent.EatingSnack && !this.FaceStudent.Slave && !this.FaceStudent.FragileSlave && !this.FaceStudent.TakingOutTrash && (double) Vector3.Distance(this.Yandere.transform.position, gameObject.transform.position) < (double) this.ReactionDistance && this.FaceStudent.CanSeeObject(this.Yandere.gameObject, this.Yandere.transform.position + Vector3.up))
              {
                if (this.MissionMode)
                {
                  this.PenaltyTimer += Time.deltaTime;
                  if ((double) this.PenaltyTimer > 1.0)
                  {
                    this.FaceStudent.Reputation.PendingRep -= -10f;
                    this.PenaltyTimer = 0.0f;
                  }
                }
                if (!this.FaceStudent.CameraReacting)
                {
                  if (this.FaceStudent.enabled && !this.FaceStudent.Stop)
                  {
                    if ((double) this.FaceStudent.DistanceToDestination < 5.0 && this.FaceStudent.Actions[this.FaceStudent.Phase] == StudentActionType.Graffiti || (double) this.FaceStudent.DistanceToDestination < 5.0 && this.FaceStudent.Actions[this.FaceStudent.Phase] == StudentActionType.Bully)
                    {
                      this.FaceStudent.PhotoPatience = 0.0f;
                      this.FaceStudent.KilledMood = true;
                      this.FaceStudent.Ignoring = true;
                      this.PenaltyTimer = 1f;
                      this.Penalize();
                    }
                    else if ((double) this.FaceStudent.PhotoPatience > 0.0)
                    {
                      if (this.FaceStudent.StudentID > 1)
                      {
                        if ((double) this.Yandere.Bloodiness > 0.0 && !this.Yandere.Paint || (double) this.Yandere.Sanity < 33.33333)
                          this.FaceStudent.Alarm += 200f;
                        else
                          this.FaceStudent.CameraReact();
                      }
                      else
                      {
                        this.FaceStudent.Alarm += (float) ((double) Time.deltaTime * (100.0 / (double) this.FaceStudent.DistanceToPlayer) * (double) this.FaceStudent.Paranoia * (double) this.FaceStudent.Perception * (double) this.FaceStudent.DistanceToPlayer * 2.0);
                        this.FaceStudent.YandereVisible = true;
                      }
                    }
                    else
                      this.Penalize();
                  }
                }
                else
                {
                  this.FaceStudent.PhotoPatience = Mathf.MoveTowards(this.FaceStudent.PhotoPatience, 0.0f, Time.deltaTime);
                  if ((double) this.FaceStudent.PhotoPatience > 0.0)
                  {
                    this.FaceStudent.CameraPoseTimer = 1f;
                    if (this.MissionMode)
                      this.FaceStudent.PhotoPatience = 0.0f;
                  }
                }
              }
            }
          }
          else if (this.hit.collider.gameObject.name == "Panties" || this.hit.collider.gameObject.name == "Skirt")
          {
            GameObject gameObject = this.hit.collider.gameObject.transform.root.gameObject;
            if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyCharacters))
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, gameObject.transform.position) < 5.0)
              {
                if ((UnityEngine.Object) this.hit.collider.gameObject == (UnityEngine.Object) gameObject)
                {
                  if (!this.Yandere.Lewd)
                    this.Yandere.NotificationManager.DisplayNotification(NotificationType.Lewd);
                  this.Yandere.Lewd = true;
                }
                else
                  this.Yandere.Lewd = false;
              }
              else
                this.Yandere.Lewd = false;
            }
          }
          else
            this.Yandere.Lewd = false;
        }
        else
          this.Yandere.Lewd = false;
      }
    }
    else
      this.Timer = 0.0f;
    if (this.TookPhoto)
      this.ResumeGameplay();
    if (!this.DisplayError)
    {
      if (this.PhotoIcons.activeInHierarchy && !this.Snapping && !this.TextMessages.gameObject.activeInHierarchy)
      {
        Time.timeScale = 0.0001f;
        if (Input.GetButtonDown("A"))
        {
          if (!this.Yandere.RivalPhone)
          {
            bool flag1 = !this.BullyX.activeInHierarchy;
            bool flag2 = !this.SenpaiX.activeInHierarchy;
            this.PromptBar.transform.localPosition = new Vector3(this.PromptBar.transform.localPosition.x, -627f, this.PromptBar.transform.localPosition.z);
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
            this.PhotoIcons.SetActive(false);
            this.ID = 0;
            this.FreeSpace = false;
            while (this.ID < 26)
            {
              ++this.ID;
              if (!PlayerGlobals.GetPhoto(this.ID))
              {
                this.FreeSpace = true;
                this.Slot = this.ID;
                this.ID = 26;
              }
            }
            if (this.FreeSpace)
            {
              if (this.StudentManager.Eighties)
                this.Yandere.HandCamera.gameObject.SetActive(true);
              ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Photographs/Photo_" + this.Slot.ToString() + ".png");
              this.TookPhoto = true;
              Debug.Log((object) ("Setting Photo " + this.Slot.ToString() + " to ''true''."));
              PlayerGlobals.SetPhoto(this.Slot, true);
              if (flag1)
              {
                Debug.Log((object) "Saving a bully photo!");
                int studentId = this.BullyPhotoCollider.transform.parent.gameObject.GetComponent<StudentScript>().StudentID;
                if (this.StudentManager.Students[studentId].Club != ClubType.Bully)
                  PlayerGlobals.SetBullyPhoto(this.Slot, studentId);
                else
                  PlayerGlobals.SetBullyPhoto(this.Slot, this.StudentManager.Students[studentId].DistractionTarget.StudentID);
              }
              if (flag2)
              {
                PlayerGlobals.SetSenpaiPhoto(this.Slot, true);
                ++PlayerGlobals.SenpaiShots;
                ++this.Yandere.Inventory.SenpaiShots;
              }
              if (this.AirGuitarShot)
              {
                TaskGlobals.SetGuitarPhoto(this.Slot, true);
                this.TaskManager.UpdateTaskStatus();
              }
              if (this.KittenShot)
              {
                TaskGlobals.SetKittenPhoto(this.Slot, true);
                this.TaskManager.UpdateTaskStatus();
              }
              if (this.HorudaShot)
              {
                TaskGlobals.SetHorudaPhoto(this.Slot, true);
                this.TaskManager.UpdateTaskStatus();
              }
              if (this.OsanaShot && DateGlobals.Weekday == DayOfWeek.Thursday)
              {
                SchemeGlobals.SetSchemeStage(4, 7);
                this.Yandere.PauseScreen.Schemes.UpdateInstructions();
              }
            }
            else
              this.DisplayError = true;
          }
          else if (!this.PantiesX.activeInHierarchy)
          {
            if (SchemeGlobals.GetSchemeStage(1) == 5)
            {
              SchemeGlobals.SetSchemeStage(1, 6);
              this.Schemes.UpdateInstructions();
            }
            this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos = true;
            this.ResumeGameplay();
          }
        }
        if (!this.Yandere.RivalPhone && Input.GetButtonDown("X"))
        {
          bool flag = false;
          if (this.StudentManager.Eighties && this.InfoX.activeInHierarchy)
            flag = true;
          if (!flag)
          {
            this.Panel.SetActive(true);
            this.MainMenu.SetActive(false);
            this.PauseScreen.Show = true;
            this.PauseScreen.Panel.enabled = true;
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[1].text = "Exit";
            this.PromptBar.Label[3].text = this.InfoX.activeInHierarchy ? "" : "Interests";
            this.PromptBar.UpdateButtons();
            if (!this.InfoX.activeInHierarchy)
            {
              this.PauseScreen.Sideways = true;
              if (!StudentGlobals.GetStudentPhotographed(this.Student.StudentID))
                ++this.Yandere.Inventory.PantyShots;
              StudentGlobals.SetStudentPhotographed(this.Student.StudentID, true);
              for (this.ID = 0; this.ID < this.Student.Outlines.Length; ++this.ID)
              {
                if ((UnityEngine.Object) this.Student.Outlines[this.ID] != (UnityEngine.Object) null)
                  this.Student.Outlines[this.ID].enabled = true;
              }
              this.StudentInfo.UpdateInfo(this.Student.StudentID);
              this.StudentInfo.gameObject.SetActive(true);
              this.PhotoIcons.transform.localPosition = new Vector3(0.0f, 1000f, 0.0f);
            }
            else if (!this.TextMessages.gameObject.activeInHierarchy)
            {
              this.PauseScreen.Sideways = false;
              this.TextMessages.gameObject.SetActive(true);
              this.SpawnMessage();
            }
          }
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.ResumeGameplay();
      }
      else
      {
        if (!this.PhotoIcons.activeInHierarchy || !Input.GetButtonDown("B"))
          return;
        this.ResumeGameplay();
        if (this.Yandere.Aiming)
          return;
        this.Yandere.StopAiming();
        this.Yandere.CanMove = false;
      }
    }
    else
    {
      this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, new Vector3(1f, 1f, 1f), Time.unscaledDeltaTime * 10f);
      if (!Input.GetButtonDown("A"))
        return;
      this.ResumeGameplay();
    }
  }

  public void Snap()
  {
    this.ErrorWindow.transform.localScale = Vector3.zero;
    if (!this.StudentManager.Eighties)
    {
      this.Yandere.HandCamera.gameObject.SetActive(false);
    }
    else
    {
      this.SmartphoneCamera.transform.parent = this.Yandere.HandCamera.transform;
      this.SmartphoneCamera.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.SmartphoneCamera.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.StudentManager.ClubManager.Viewfinder.SetActive(false);
    }
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
    this.MyAudio.Play();
    this.Snapping = true;
    this.Close = true;
    this.Frame = 0;
  }

  public void CheckPhoto()
  {
    Debug.Log((object) "We are now checking what Yandere-chan took a picture of.");
    this.InfoX.SetActive(true);
    this.BullyX.SetActive(true);
    this.SenpaiX.SetActive(true);
    this.PantiesX.SetActive(true);
    this.ViolenceX.SetActive(true);
    this.AirGuitarShot = false;
    this.PlushieShot = false;
    this.BountyShot = false;
    this.HorudaShot = false;
    this.KittenShot = false;
    this.OsanaShot = false;
    this.Nemesis = false;
    this.NotFace = false;
    this.Skirt = false;
    Transform transform = !this.Yandere.Aiming ? this.Palm : this.SmartphoneCamera.transform;
    Vector3 direction = this.Yandere.Selfie ? this.SelfieRayParent.TransformDirection(Vector3.forward) : transform.TransformDirection(Vector3.forward);
    this.StudentManager.UpdatePanties(true);
    this.StudentManager.UpdateSkirts(true);
    if (Physics.Raycast(transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyPhotography))
    {
      Debug.Log((object) ("The camera's raycast collided with something named ''" + this.hit.collider.gameObject.name + "''"));
      if (this.hit.collider.gameObject.name == "Panties")
      {
        this.Student = this.hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
        this.PhotoDescLabel.text = "Photo of: " + this.Student.Name + "'s Panties";
        this.PantiesX.SetActive(false);
        if (!this.Yandere.Aiming)
        {
          this.Yandere.ResetYandereEffects();
          this.PhotoIcons.SetActive(true);
          this.InfoX.SetActive(true);
          Time.timeScale = 0.0f;
          this.Panel.SetActive(true);
          this.MainMenu.SetActive(false);
          this.PauseScreen.Show = true;
          this.PauseScreen.Panel.enabled = true;
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[1].text = "Exit";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
          this.PauseScreen.Sideways = false;
          this.TextMessages.gameObject.SetActive(true);
          this.SpawnMessage();
        }
      }
      else if (this.hit.collider.gameObject.name == "Face")
      {
        if (this.hit.collider.gameObject.tag == "Nemesis")
        {
          this.PhotoDescLabel.text = "Photo of: Nemesis";
          this.Nemesis = true;
          ++this.NemesisShots;
        }
        else if (this.hit.collider.gameObject.tag == "Disguise")
        {
          this.PhotoDescLabel.text = "Photo of: ?????";
          this.Disguise = true;
        }
        else
        {
          this.Student = this.hit.collider.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
          if (this.Student.StudentID == 1)
          {
            this.PhotoDescLabel.text = "Photo of: Senpai";
            this.SenpaiX.SetActive(false);
          }
          else
          {
            this.PhotoDescLabel.text = "Photo of: " + this.Student.Name;
            this.InfoX.SetActive(false);
          }
        }
      }
      else if (this.hit.collider.gameObject.name == "NotFace")
      {
        this.PhotoDescLabel.text = "Photo of: Blocked Face";
        this.NotFace = true;
      }
      else if (this.hit.collider.gameObject.name == "Skirt")
      {
        this.PhotoDescLabel.text = "Photo of: Skirt";
        this.Skirt = true;
      }
      if (this.hit.collider.transform.root.gameObject.name == "Student_51 (Miyuji Shan)" && this.StudentManager.Students[51].AirGuitar.isPlaying)
      {
        this.AirGuitarShot = true;
        this.PhotoDescription.SetActive(true);
        this.PhotoDescLabel.text = "Photo of: Miyuji's True Nature?";
      }
      if (this.hit.collider.gameObject.name == "Kitten")
      {
        this.KittenShot = true;
        this.PhotoDescription.SetActive(true);
        this.PhotoDescLabel.text = "Photo of: Kitten";
        if (!ConversationGlobals.GetTopicDiscovered(15))
        {
          ConversationGlobals.SetTopicDiscovered(15, true);
          this.Yandere.NotificationManager.TopicName = "Cats";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
      }
      if (this.hit.collider.gameObject.tag == "Horuda")
      {
        this.HorudaShot = true;
        this.PhotoDescription.SetActive(true);
        this.PhotoDescLabel.text = "Photo of: Horuda's Hiding Spot";
      }
      if (this.hit.collider.gameObject.name == "Bounty")
      {
        this.BountyShot = true;
        this.PhotoDescription.SetActive(true);
        if (this.StudentManager.Clock.Day == 1)
          this.PhotoDescLabel.text = "Photo of: Ryuto Gaming At School";
        else if (this.StudentManager.Clock.Day == 2)
          this.PhotoDescLabel.text = "Photo of: Otohiko Falling Down";
        else if (this.StudentManager.Clock.Day == 3)
          this.PhotoDescLabel.text = "Photo of: Fureddo Goofing Off";
        else if (this.StudentManager.Clock.Day == 4)
          this.PhotoDescLabel.text = "Photo of: Umeji Sulking In Defeat";
        else if (this.StudentManager.Clock.Day == 5)
          this.PhotoDescLabel.text = "Photo of: Kashiko Ignoring Duties";
      }
      if (this.hit.collider.gameObject.tag == "Bully")
      {
        this.PhotoDescLabel.text = "Photo of: Student Speaking With Bully";
        this.BullyPhotoCollider = this.hit.collider.gameObject;
        this.BullyX.SetActive(false);
      }
      if (this.hit.collider.gameObject.tag == "RivalEvidence")
      {
        this.OsanaShot = true;
        this.PhotoDescription.SetActive(true);
        this.PhotoDescLabel.text = "Photo of: Osana Vandalizing School Property";
      }
      if ((UnityEngine.Object) this.hit.collider.gameObject.transform.parent != (UnityEngine.Object) null && this.hit.collider.gameObject.transform.parent.name == "PlushieShelf")
      {
        this.PlushieShot = true;
        this.PlushieName = this.hit.collider.gameObject.name;
        this.PhotoDescription.SetActive(true);
        this.PhotoDescLabel.text = "Photo of: A cute plushie doll";
      }
    }
    if (Physics.Raycast(this.SmartphoneCamera.transform.position, direction, out this.hit, float.PositiveInfinity, this.OnlyRagdolls) && this.hit.collider.gameObject.layer == 11)
    {
      this.PhotoDescLabel.text = "Photo of: Corpse";
      this.ViolenceX.SetActive(false);
    }
    if (Physics.Raycast(this.SmartphoneCamera.transform.position, this.SmartphoneCamera.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.OnlyBlood) && this.hit.collider.gameObject.layer == 14)
    {
      this.PhotoDescLabel.text = "Photo of: Blood";
      this.ViolenceX.SetActive(false);
    }
    this.StudentManager.UpdateSkirts(false);
    if (this.Yandere.Aiming)
      return;
    if ((UnityEngine.Object) this.NewMessage == (UnityEngine.Object) null)
    {
      this.Yandere.NotificationManager.CustomText = "You missed.";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
    this.StudentManager.UpdatePanties(false);
  }

  public void SpawnMessage()
  {
    Debug.Log((object) "Spawning a message.");
    if ((UnityEngine.Object) this.NewMessage != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.NewMessage);
    this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.Message);
    this.NewMessage.transform.parent = this.TextMessages;
    this.NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0.0f);
    this.NewMessage.transform.localEulerAngles = Vector3.zero;
    this.NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
    bool flag = false;
    if (this.Yandere.Aiming && (UnityEngine.Object) this.hit.collider != (UnityEngine.Object) null && this.hit.collider.gameObject.name == "Kitten")
      flag = true;
    string empty = string.Empty;
    string str;
    int num;
    if (this.BountyShot)
    {
      if (!this.BountyComplete)
      {
        str = "Bounty complete. You've earned 25 Info Points.";
        num = 2;
        this.Yandere.Inventory.PantyShots += 25;
        this.BountyComplete = true;
      }
      else
      {
        str = "You've already completed this bounty.";
        num = 2;
      }
    }
    else if (flag)
    {
      str = "Why are you showing me this? I don't care.";
      num = 2;
    }
    else if (!this.InfoX.activeInHierarchy)
    {
      str = "I recognize this person. Here's some information about them.";
      num = 3;
    }
    else if (!this.PantiesX.activeInHierarchy)
    {
      Debug.Log((object) "Detected panties.");
      if ((UnityEngine.Object) this.Student != (UnityEngine.Object) null)
      {
        if (!this.StudentManager.PantyShotTaken[this.Student.StudentID])
        {
          this.StudentManager.PantyShotTaken[this.Student.StudentID] = true;
          if (this.Student.Nemesis)
            str = "Hey, wait a minute...I recognize those panties! This person is extremely dangerous! Avoid her at all costs!";
          else if (this.Student.Club == ClubType.Bully || this.Student.Club == ClubType.Council || this.Student.Club == ClubType.Nurse || this.Student.StudentID == 20)
          {
            str = "A high value target! " + this.Student.Name + "'s panties were in high demand. You've earned 10 Info Points.";
            this.Yandere.Inventory.PantyShots += 10;
          }
          else
          {
            str = "Excellent! Now I have a picture of " + this.Student.Name + "'s panties. You've earned 5 Info Points.";
            this.Yandere.Inventory.PantyShots += 5;
          }
          num = 5;
        }
        else if (!this.Student.Nemesis)
        {
          str = "I already have a picture of " + this.Student.Name + "'s panties. I don't need this shot.";
          num = 4;
        }
        else
        {
          str = "You are in danger. Avoid her.";
          num = 2;
        }
      }
      else
      {
        str = "How peculiar. I don't recognize these panties.";
        num = 2;
      }
    }
    else if (!this.ViolenceX.activeInHierarchy)
    {
      str = "Good work, but don't send me this stuff. I have no use for it.";
      num = 3;
    }
    else if (!this.SenpaiX.activeInHierarchy)
    {
      switch (PlayerGlobals.SenpaiShotsTexted)
      {
        case 0:
          str = "I don't need any pictures of your Senpai.";
          num = 2;
          break;
        case 1:
          str = "I know how you feel about this person, but I have no use for these pictures.";
          num = 4;
          break;
        case 2:
          str = "Okay, I get it, you love your Senpai, and you love taking pictures of your Senpai. I still don't need these shots.";
          num = 5;
          break;
        case 3:
          str = "You're spamming my inbox. Cut it out.";
          num = 2;
          break;
        default:
          str = "...";
          num = 1;
          break;
      }
      ++PlayerGlobals.SenpaiShotsTexted;
    }
    else if (!this.BullyX.activeInHierarchy)
    {
      str = "I have no interest in this.";
      num = 2;
    }
    else if (this.NotFace)
    {
      str = "Do you want me to identify this person? Please get me a clear shot of their face.";
      num = 4;
    }
    else if (this.Skirt)
    {
      str = "Is this supposed to be a panty shot? My clients are picky. The panties need to be in the EXACT center of the shot.";
      num = 5;
    }
    else if (this.Nemesis)
    {
      if (this.NemesisShots == 1)
      {
        str = "Strange. I have no profile for this student.";
        num = 2;
      }
      else if (this.NemesisShots == 2)
      {
        str = "...wait. I think I know who she is.";
        num = 2;
      }
      else if (this.NemesisShots == 3)
      {
        str = "You are in danger. Avoid her.";
        num = 2;
      }
      else if (this.NemesisShots == 4)
      {
        str = "Do not engage.";
        num = 1;
      }
      else
      {
        str = "I repeat: Do. Not. Engage.";
        num = 2;
      }
    }
    else if (this.Disguise)
    {
      str = "Something about that student seems...wrong.";
      num = 2;
    }
    else if (this.PlushieShot)
    {
      str = "Hey, that's " + this.PlushieName + "!";
      num = 4;
    }
    else
    {
      str = "I don't get it. What are you trying to show me? Make sure the subject is in the EXACT center of the photo.";
      num = 5;
    }
    this.NewMessage.GetComponent<UISprite>().height = 36 + 36 * num;
    this.NewMessage.GetComponent<TextMessageScript>().Label.text = str;
  }

  public void ResumeGameplay()
  {
    this.ErrorWindow.transform.localScale = Vector3.zero;
    this.SmartphoneCamera.targetTexture = this.SmartphoneScreen;
    this.StudentManager.GhostChan.gameObject.SetActive(false);
    this.Yandere.HandCamera.gameObject.SetActive(true);
    this.NotificationManager.SetActive(true);
    this.PauseScreen.CorrectingTime = true;
    this.HeartbeatCamera.SetActive(true);
    this.TextMessages.gameObject.SetActive(false);
    this.StudentInfo.gameObject.SetActive(false);
    this.MainCamera.enabled = true;
    this.PhotoIcons.SetActive(false);
    this.PauseScreen.Show = false;
    this.SubPanel.SetActive(true);
    this.MainMenu.SetActive(true);
    this.Yandere.CanMove = true;
    this.DisplayError = false;
    this.Panel.SetActive(true);
    Time.timeScale = 1f;
    this.TakePhoto = false;
    this.TookPhoto = false;
    this.AirGuitarShot = false;
    this.PlushieShot = false;
    this.BountyShot = false;
    this.HorudaShot = false;
    this.KittenShot = false;
    this.OsanaShot = false;
    this.Nemesis = false;
    this.NotFace = false;
    this.Skirt = false;
    if (!this.StudentManager.Eighties)
    {
      this.Yandere.PhonePromptBar.Panel.enabled = true;
      this.Yandere.PhonePromptBar.Show = true;
    }
    else if (this.Yandere.Club == ClubType.Photography)
      this.StudentManager.ClubManager.Viewfinder.SetActive(true);
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    if ((UnityEngine.Object) this.NewMessage != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.NewMessage);
    if (!this.Yandere.CameraEffects.OneCamera)
    {
      this.Yandere.MainCamera.clearFlags = OptionGlobals.Fog ? CameraClearFlags.Color : CameraClearFlags.Skybox;
      this.Yandere.MainCamera.farClipPlane = (float) OptionGlobals.DrawDistance;
    }
    this.Yandere.UpdateSelfieStatus();
    this.Yandere.RPGCamera.enabled = true;
    this.Yandere.RPGCamera.mouseX = this.Yandere.RPGCamera.mouseXSmooth;
    this.Yandere.RPGCamera.mouseY = this.Yandere.RPGCamera.mouseYSmooth;
    this.Yandere.RPGCamera.mouseSmoothingFactor = 0.08f;
  }

  public void Penalize()
  {
    this.PenaltyTimer += Time.deltaTime;
    if ((double) this.PenaltyTimer < 1.0)
      return;
    this.Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
    if ((UnityEngine.Object) this.Yandere.Mask == (UnityEngine.Object) null)
    {
      if (this.MissionMode)
      {
        if (this.FaceStudent.TimesAnnoyed < 5)
        {
          ++this.FaceStudent.TimesAnnoyed;
        }
        else
        {
          this.FaceStudent.RepDeduction = 0.0f;
          this.FaceStudent.RepLoss = 20f;
          this.FaceStudent.Reputation.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
          this.FaceStudent.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
        }
      }
      else
      {
        this.FaceStudent.RepDeduction = 0.0f;
        this.FaceStudent.RepLoss = 1f;
        this.FaceStudent.CalculateReputationPenalty();
        if ((double) this.FaceStudent.RepDeduction >= 0.0)
          this.FaceStudent.RepLoss -= this.FaceStudent.RepDeduction;
        this.FaceStudent.Reputation.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
        this.FaceStudent.PendingRep -= this.FaceStudent.RepLoss * this.FaceStudent.Paranoia;
        this.FaceStudent.PersonalSpaceTimer = 0.0f;
      }
    }
    this.PenaltyTimer = 0.0f;
  }
}
