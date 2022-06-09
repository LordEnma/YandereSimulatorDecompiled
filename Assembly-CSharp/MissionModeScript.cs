// Decompiled with JetBrains decompiler
// Type: MissionModeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;

public class MissionModeScript : MonoBehaviour
{
  public SecurityCameraManagerScript SecurityCameraManager;
  public NotificationManagerScript NotificationManager;
  public CameraFilterPack_Gradients_FireGradient Fire;
  public NewMissionWindowScript NewMissionWindow;
  public MissionModeMenuScript MissionModeMenu;
  public StudentManagerScript StudentManager;
  public WeaponManagerScript WeaponManager;
  public PromptScript ExitPortalPrompt;
  public IncineratorScript Incinerator;
  public WoodChipperScript WoodChipper;
  public AlphabetScript AlphabetArrow;
  public ReputationScript Reputation;
  public GrayscaleEffect Grayscale;
  public PromptBarScript PromptBar;
  public BoundaryScript Boundary;
  public JukeboxScript Jukebox;
  public YandereScript Yandere;
  public PoliceScript Police;
  public ClockScript Clock;
  public UILabel EventSubtitleLabel;
  public UILabel ReputationLabel;
  public UILabel GameOverHeader;
  public UILabel GameOverReason;
  public UILabel SubtitleLabel;
  public UILabel LoadingLabel;
  public UILabel SpottedLabel;
  public UILabel SanityLabel;
  public UILabel MoneyLabel;
  public UILabel TimeLabel;
  public Graphic NewFPSLabel;
  public Graphic NewFPSValueLabel;
  public UISprite ReputationFace1;
  public UISprite ReputationFace2;
  public UISprite ReputationBG;
  public UISprite CautionSign;
  public UISprite MusicIcon;
  public UISprite Darkness;
  public UISprite PhoneBar;
  public UISprite PhoneBG;
  public UILabel FPS;
  public GardenHoleScript[] GardenHoles;
  public GameObject[] ReputationIcons;
  public string[] GameOverReasons;
  public AudioClip[] StealthMusic;
  public Transform[] SpawnPoints;
  public UISprite[] PoliceIcon;
  public UILabel[] PoliceLabel;
  public int[] Conditions;
  public GameObject SecurityCameraGroup;
  public GameObject MetalDetectorGroup;
  public GameObject HeartbrokenCamera;
  public GameObject DetectionCamera;
  public GameObject HeartbeatCamera;
  public GameObject MissionModeHUD;
  public GameObject SpottedWindow;
  public GameObject TranqDetector;
  public GameObject WitnessCamera;
  public GameObject GameOverText;
  public GameObject VoidGoddess;
  public GameObject Headmaster;
  public GameObject ExitPortal;
  public GameObject MurderKit;
  public GameObject Subtitle;
  public GameObject Nemesis;
  public GameObject Safe;
  public Transform LastKnownPosition;
  public int RequiredClothingID;
  public int RequiredDisposalID;
  public int RequiredWeaponID;
  public int NemesisDifficulty;
  public int DisposalMethod;
  public int MurderWeaponID;
  public int GameOverPhase;
  public int Destination;
  public int Difficulty;
  public int GameOverID;
  public int TargetID;
  public int MusicID = 1;
  public int Phase = 1;
  public int ID;
  public int[] Target;
  public int[] Method;
  public bool SecurityCameras;
  public bool MetalDetectors;
  public bool StealDocuments;
  public bool NoCollateral;
  public bool NoSuspicion;
  public bool NoWitnesses;
  public bool NoCorpses;
  public bool NoSpeech;
  public bool NoWeapon;
  public bool NoBlood;
  public bool TimeLimit;
  public bool CorrectClothingConfirmed;
  public bool DocumentsStolen;
  public bool CorpseDisposed;
  public bool WeaponDisposed;
  public bool CheckForBlood;
  public bool BloodCleaned;
  public bool MultiMission;
  public bool InfoRemark;
  public bool TargetDead;
  public bool Chastise;
  public bool FadeOut;
  public bool Enabled;
  public bool[] Checking;
  public string CauseOfFailure = string.Empty;
  public float TimeRemaining = 300f;
  public float TargetHeight;
  public float BloodTimer;
  public float Speed;
  public float Timer;
  public AudioClip InfoAccomplished;
  public AudioClip InfoExfiltrate;
  public AudioClip InfoObjective;
  public AudioClip InfoFailure;
  public AudioClip GameOverSound;
  public AudioSource MyAudio;
  public Camera MainCamera;
  public UILabel Watermark;
  public Font Arial;
  public int Frame;
  public UILabel DiscordCodeLabel;
  public float RandomNumber;
  public bool Valid;

  private void Start()
  {
    if (!SchoolGlobals.HighSecurity)
      this.MetalDetectorGroup.SetActive(false);
    this.NewMissionWindow.gameObject.SetActive(false);
    this.MissionModeHUD.SetActive(false);
    this.SpottedWindow.SetActive(false);
    this.ExitPortal.SetActive(false);
    this.Safe.SetActive(false);
    if (GameGlobals.Eighties)
    {
      this.StudentManager.EightiesifyLabel(this.Watermark);
      this.Watermark.transform.localPosition = new Vector3(0.0f, -546f, 0.0f);
      if (GameGlobals.EightiesTutorial)
        this.Watermark.gameObject.SetActive(false);
    }
    if (GameGlobals.LoveSick)
    {
      this.MurderKit.SetActive(false);
      this.Yandere.HeartRate.MediumColour = new Color(1f, 1f, 1f, 1f);
      this.Yandere.HeartRate.NormalColour = new Color(1f, 1f, 1f, 1f);
      this.Clock.PeriodLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.Clock.TimeLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.Clock.DayLabel.enabled = false;
      this.MoneyLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.MoneyLabel.applyGradient = false;
      this.Reputation.PendingRepMarker.GetComponent<UISprite>().color = new Color(1f, 0.0f, 0.0f, 1f);
      this.Reputation.CurrentRepMarker.gameObject.SetActive(false);
      this.Reputation.PendingRepLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.Reputation.PendingRepLabel.applyGradient = false;
      this.ReputationFace1.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.ReputationFace2.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.ReputationBG.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.ReputationLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.ReputationLabel.applyGradient = false;
      this.Watermark.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.Watermark.applyGradient = false;
      this.EventSubtitleLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.EventSubtitleLabel.applyGradient = false;
      this.SubtitleLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.SubtitleLabel.applyGradient = false;
      this.CautionSign.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.CautionSign.applyGradient = false;
      this.FPS.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.FPS.applyGradient = false;
      this.SanityLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.SanityLabel.applyGradient = false;
      for (this.ID = 1; this.ID < this.PoliceLabel.Length; ++this.ID)
      {
        this.PoliceLabel[this.ID].color = new Color(1f, 0.0f, 0.0f, 1f);
        this.PoliceLabel[this.ID].applyGradient = false;
      }
      for (this.ID = 1; this.ID < this.PoliceIcon.Length; ++this.ID)
      {
        this.PoliceIcon[this.ID].color = new Color(1f, 0.0f, 0.0f, 1f);
        this.PoliceIcon[this.ID].applyGradient = false;
      }
      this.PhoneBar.color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.PhoneBG.color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.PhoneBG.gradientTop = new Color(1f, 1f, 1f, 1f);
      this.PhoneBG.gradientBottom = new Color(0.0f, 0.0f, 0.0f, 1f);
    }
    this.NewFPSLabel.transform.parent.parent.gameObject.SetActive(true);
    if (MissionModeGlobals.MissionMode)
    {
      this.NewFPSLabel.color = new Color(1f, 1f, 1f, 1f);
      this.NewFPSValueLabel.color = new Color(1f, 1f, 1f, 1f);
      this.AlphabetArrow.gameObject.SetActive(true);
      this.AlphabetArrow.gameObject.GetComponent<Renderer>().material.shader = this.StudentManager.QualityManager.ToonOutline;
      this.AlphabetArrow.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.0f);
      this.Headmaster.SetActive(false);
      this.Yandere.HeartRate.MediumColour = new Color(1f, 0.5f, 0.5f, 1f);
      this.Yandere.HeartRate.NormalColour = new Color(1f, 1f, 1f, 1f);
      this.Clock.PeriodLabel.color = new Color(1f, 1f, 1f, 1f);
      this.Clock.TimeLabel.color = new Color(1f, 1f, 1f, 1f);
      this.Clock.DayLabel.enabled = false;
      this.MoneyLabel.color = new Color(1f, 1f, 1f, 1f);
      this.MoneyLabel.fontStyle = FontStyle.Bold;
      this.MoneyLabel.trueTypeFont = this.Arial;
      this.MoneyLabel.applyGradient = false;
      this.Reputation.PendingRepMarker.GetComponent<UISprite>().color = new Color(1f, 1f, 1f, 1f);
      this.Reputation.CurrentRepMarker.gameObject.SetActive(false);
      this.Reputation.PendingRepLabel.color = new Color(1f, 1f, 1f, 1f);
      this.Reputation.PendingRepLabel.applyGradient = false;
      this.ReputationLabel.fontStyle = FontStyle.Bold;
      this.ReputationLabel.trueTypeFont = this.Arial;
      this.ReputationLabel.color = new Color(1f, 1f, 1f, 1f);
      this.ReputationLabel.applyGradient = false;
      this.ReputationLabel.text = "AWARENESS";
      this.ReputationIcons[0].SetActive(true);
      this.ReputationIcons[1].SetActive(false);
      this.ReputationIcons[2].SetActive(false);
      this.ReputationIcons[3].SetActive(false);
      this.ReputationIcons[4].SetActive(false);
      this.ReputationIcons[5].SetActive(false);
      this.Clock.TimeLabel.fontStyle = FontStyle.Bold;
      this.Clock.TimeLabel.trueTypeFont = this.Arial;
      this.Clock.TimeLabel.applyGradient = false;
      this.Clock.PeriodLabel.fontStyle = FontStyle.Bold;
      this.Clock.PeriodLabel.trueTypeFont = this.Arial;
      this.Clock.PeriodLabel.applyGradient = false;
      this.Watermark.fontStyle = FontStyle.Bold;
      this.Watermark.color = new Color(1f, 1f, 1f, 1f);
      this.Watermark.trueTypeFont = this.Arial;
      this.Watermark.applyGradient = false;
      this.SubtitleLabel.color = new Color(1f, 1f, 1f, 1f);
      this.SubtitleLabel.applyGradient = false;
      this.CautionSign.color = new Color(1f, 1f, 1f, 1f);
      this.CautionSign.applyGradient = false;
      this.FPS.color = new Color(1f, 1f, 1f, 1f);
      this.FPS.applyGradient = false;
      this.SanityLabel.color = new Color(1f, 1f, 1f, 1f);
      this.SanityLabel.applyGradient = false;
      this.StudentManager.MissionMode = true;
      this.NemesisDifficulty = MissionModeGlobals.NemesisDifficulty;
      this.Difficulty = MissionModeGlobals.MissionDifficulty;
      this.TargetID = MissionModeGlobals.MissionTarget;
      ClassGlobals.BiologyGrade = 1;
      ClassGlobals.ChemistryGrade = 1;
      ClassGlobals.LanguageGrade = 1;
      ClassGlobals.PhysicalGrade = 1;
      ClassGlobals.PsychologyGrade = 1;
      OptionGlobals.TutorialsOff = true;
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.SchoolAtmosphere = (float) (1.0 - (double) this.Difficulty * 0.100000001490116);
      PlayerGlobals.Money = 20f;
      this.StudentManager.Atmosphere = (float) (1.0 - (double) this.Difficulty * 0.100000001490116);
      this.StudentManager.SetAtmosphere();
      for (this.ID = 1; this.ID < this.PoliceLabel.Length; ++this.ID)
      {
        this.PoliceLabel[this.ID].fontStyle = FontStyle.Bold;
        this.PoliceLabel[this.ID].color = new Color(1f, 1f, 1f, 1f);
        this.PoliceLabel[this.ID].trueTypeFont = this.Arial;
        this.PoliceLabel[this.ID].applyGradient = false;
      }
      for (this.ID = 1; this.ID < this.PoliceIcon.Length; ++this.ID)
      {
        this.PoliceIcon[this.ID].color = new Color(1f, 1f, 1f, 1f);
        this.PoliceIcon[this.ID].applyGradient = false;
      }
      if (this.Difficulty > 1)
      {
        for (this.ID = 2; this.ID < this.Difficulty + 1; ++this.ID)
        {
          int missionCondition = MissionModeGlobals.GetMissionCondition(this.ID);
          switch (missionCondition)
          {
            case 1:
              this.RequiredWeaponID = MissionModeGlobals.MissionRequiredWeapon;
              break;
            case 2:
              this.RequiredClothingID = MissionModeGlobals.MissionRequiredClothing;
              break;
            case 3:
              this.RequiredDisposalID = MissionModeGlobals.MissionRequiredDisposal;
              break;
            case 4:
              this.NoCollateral = true;
              break;
            case 5:
              this.NoWitnesses = true;
              break;
            case 6:
              this.NoCorpses = true;
              break;
            case 7:
              this.NoWeapon = true;
              break;
            case 8:
              this.NoBlood = true;
              break;
            case 9:
              this.TimeLimit = true;
              break;
            case 10:
              this.NoSuspicion = true;
              break;
            case 11:
              this.SecurityCameras = true;
              break;
            case 12:
              this.MetalDetectors = true;
              break;
            case 13:
              this.NoSpeech = true;
              break;
            case 14:
              this.StealDocuments = true;
              break;
          }
          this.Conditions[this.ID] = missionCondition;
        }
      }
      if (!this.StealDocuments)
        this.DocumentsStolen = true;
      else
        this.Safe.SetActive(true);
      if (this.SecurityCameras)
        this.SecurityCameraManager.ActivateAllCameras();
      if (this.MetalDetectors)
        this.MetalDetectorGroup.SetActive(true);
      if (this.TimeLimit)
        this.TimeLabel.gameObject.SetActive(true);
      if (this.NoSpeech)
        this.StudentManager.NoSpeech = true;
      if (this.RequiredDisposalID == 0)
        this.CorpseDisposed = true;
      if (this.NemesisDifficulty > 0)
        this.Nemesis.SetActive(true);
      if (!this.NoWeapon)
        this.WeaponDisposed = true;
      if (!this.NoBlood)
        this.BloodCleaned = true;
      this.Jukebox.Egg = true;
      this.Jukebox.KillVolume();
      this.Jukebox.MissionMode.enabled = true;
      this.Jukebox.MissionMode.volume = 0.0f;
      this.Yandere.FixCamera();
      this.MainCamera.transform.position = new Vector3(this.MainCamera.transform.position.x, 6.51505f, -76.9222f);
      this.MainCamera.transform.eulerAngles = new Vector3(15f, this.MainCamera.transform.eulerAngles.y, this.MainCamera.transform.eulerAngles.z);
      this.Yandere.RPGCamera.enabled = false;
      this.Yandere.SanityBased = true;
      this.Yandere.CanMove = false;
      this.VoidGoddess.GetComponent<VoidGoddessScript>().Window.gameObject.SetActive(false);
      this.TranqDetector.GetComponent<TranqDetectorScript>().Checklist.alpha = 0.0f;
      this.HeartbeatCamera.SetActive(false);
      this.TranqDetector.SetActive(false);
      this.VoidGoddess.SetActive(false);
      this.MurderKit.SetActive(false);
      this.TargetHeight = 1.51505f;
      this.Yandere.HUD.alpha = 0.0f;
      this.MusicIcon.color = new Color(this.MusicIcon.color.r, this.MusicIcon.color.g, this.MusicIcon.color.b, 1f);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
      this.MissionModeMenu.UpdateGraphics();
      this.MissionModeMenu.gameObject.SetActive(true);
      if (MissionModeGlobals.MultiMission)
      {
        this.NewMissionWindow.gameObject.SetActive(true);
        this.MissionModeMenu.gameObject.SetActive(false);
        this.NewMissionWindow.FillOutInfo();
        this.NewMissionWindow.HideButtons();
        this.MultiMission = true;
        for (int index = 1; index < 11; ++index)
        {
          this.Target[index] = PlayerPrefs.GetInt("MissionModeTarget" + index.ToString());
          this.Method[index] = PlayerPrefs.GetInt("MissionModeMethod" + index.ToString());
        }
      }
      this.PhoneBar.color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.PhoneBG.color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.PhoneBG.gradientTop = new Color(1f, 1f, 1f, 1f);
      this.PhoneBG.gradientBottom = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.Enabled = true;
    }
    else
    {
      this.MissionModeMenu.gameObject.SetActive(false);
      this.TimeLabel.gameObject.SetActive(false);
      this.enabled = false;
    }
  }

  private void Update()
  {
    if (this.Phase == 1)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime / 3f));
      if ((double) this.Darkness.color.a == 0.0)
      {
        this.Speed += Time.deltaTime / 3f;
        this.MainCamera.transform.position = new Vector3(this.MainCamera.transform.position.x, Mathf.Lerp(this.MainCamera.transform.position.y, this.TargetHeight, Time.deltaTime * this.Speed), this.MainCamera.transform.position.z);
        if ((double) this.MainCamera.transform.position.y < (double) this.TargetHeight + 0.100000001490116)
        {
          this.Yandere.HUD.alpha = Mathf.MoveTowards(this.Yandere.HUD.alpha, 1f, Time.deltaTime / 3f);
          if ((double) this.Yandere.HUD.alpha == 1.0)
          {
            Debug.Log((object) "Incrementing phase.");
            this.Yandere.RPGCamera.enabled = true;
            this.HeartbeatCamera.SetActive(true);
            this.Yandere.CanMove = true;
            ++this.Phase;
          }
        }
      }
      if (!Input.GetButtonDown("A"))
        return;
      this.MainCamera.transform.position = new Vector3(this.MainCamera.transform.position.x, this.TargetHeight, this.MainCamera.transform.position.z);
      this.Yandere.RPGCamera.enabled = true;
      this.HeartbeatCamera.SetActive(true);
      this.Yandere.CanMove = true;
      this.Yandere.HUD.alpha = 1f;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0.0f);
      ++this.Phase;
    }
    else if (this.Phase == 2)
    {
      if (this.MultiMission)
      {
        for (int index = 1; index < this.Target.Length; ++index)
        {
          if (this.Target[index] == 0)
            this.Checking[index] = false;
          else if (this.Checking[index])
          {
            if ((double) this.StudentManager.Students[this.Target[index]].transform.position.y < -11.0)
            {
              this.GameOverID = 1;
              this.GameOver();
              this.Phase = 4;
            }
            else if (!this.StudentManager.Students[this.Target[index]].Alive)
            {
              if (this.Method[index] == 0)
              {
                if (this.StudentManager.Students[this.Target[index]].DeathType == DeathType.Weapon)
                {
                  this.NewMissionWindow.DeathSkulls[index].SetActive(true);
                  this.Checking[index] = false;
                  this.CheckForCompletion();
                }
                else
                {
                  this.GameOverID = 18;
                  this.GameOver();
                  this.Phase = 4;
                }
              }
              else if (this.Method[index] == 1)
              {
                if (this.StudentManager.Students[this.Target[index]].DeathType == DeathType.Drowning)
                {
                  this.NewMissionWindow.DeathSkulls[index].SetActive(true);
                  this.Checking[index] = false;
                  this.CheckForCompletion();
                }
                else
                {
                  this.GameOverID = 18;
                  this.GameOver();
                  this.Phase = 4;
                }
              }
              else if (this.Method[index] == 2)
              {
                if (this.StudentManager.Students[this.Target[index]].DeathType == DeathType.Poison)
                {
                  this.NewMissionWindow.DeathSkulls[index].SetActive(true);
                  this.Checking[index] = false;
                  this.CheckForCompletion();
                }
                else
                {
                  this.GameOverID = 18;
                  this.GameOver();
                  this.Phase = 4;
                }
              }
              else if (this.Method[index] == 3)
              {
                if (this.StudentManager.Students[this.Target[index]].DeathType == DeathType.Electrocution)
                {
                  this.NewMissionWindow.DeathSkulls[index].SetActive(true);
                  this.Checking[index] = false;
                  this.CheckForCompletion();
                }
                else
                {
                  this.GameOverID = 18;
                  this.GameOver();
                  this.Phase = 4;
                }
              }
              else if (this.Method[index] == 4)
              {
                if (this.StudentManager.Students[this.Target[index]].DeathType == DeathType.Burning)
                {
                  this.NewMissionWindow.DeathSkulls[index].SetActive(true);
                  this.Checking[index] = false;
                  this.CheckForCompletion();
                }
                else
                {
                  this.GameOverID = 18;
                  this.GameOver();
                  this.Phase = 4;
                }
              }
              else if (this.Method[index] == 5)
              {
                if (this.StudentManager.Students[this.Target[index]].DeathType == DeathType.Falling)
                {
                  this.NewMissionWindow.DeathSkulls[index].SetActive(true);
                  this.Checking[index] = false;
                  this.CheckForCompletion();
                }
                else
                {
                  this.GameOverID = 18;
                  this.GameOver();
                  this.Phase = 4;
                }
              }
              else if (this.Method[index] == 6)
              {
                if (this.StudentManager.Students[this.Target[index]].DeathType == DeathType.Weight)
                {
                  this.NewMissionWindow.DeathSkulls[index].SetActive(true);
                  this.Checking[index] = false;
                  this.CheckForCompletion();
                }
                else
                {
                  this.GameOverID = 18;
                  this.GameOver();
                  this.Phase = 4;
                }
              }
            }
          }
        }
      }
      if (!this.TargetDead && (Object) this.StudentManager.Students[this.TargetID] != (Object) null)
      {
        this.AlphabetArrow.LocalArrow.LookAt(this.StudentManager.Students[this.TargetID].transform.position);
        this.AlphabetArrow.transform.eulerAngles = this.AlphabetArrow.LocalArrow.eulerAngles - new Vector3(0.0f, this.StudentManager.MainCamera.transform.eulerAngles.y, 0.0f);
        this.AlphabetArrow.gameObject.SetActive(true);
        if (!this.StudentManager.Students[this.TargetID].Alive)
        {
          if (this.Yandere.Equipped > 0)
          {
            if (this.StudentManager.Students[this.TargetID].DeathType == DeathType.Weapon)
              this.MurderWeaponID = this.Yandere.EquippedWeapon.WeaponID;
            else
              this.WeaponDisposed = true;
          }
          else
            this.WeaponDisposed = true;
          this.AlphabetArrow.gameObject.SetActive(false);
          this.TargetDead = true;
        }
        if ((double) this.StudentManager.Students[this.TargetID].transform.position.y < -11.0)
        {
          this.GameOverID = 1;
          this.GameOver();
          this.Phase = 4;
        }
      }
      if (this.RequiredWeaponID > 0 && (Object) this.StudentManager.Students[this.TargetID] != (Object) null && !this.StudentManager.Students[this.TargetID].Alive && this.StudentManager.Students[this.TargetID].DeathCause != this.RequiredWeaponID)
      {
        this.Chastise = true;
        this.GameOverID = 2;
        this.GameOver();
        this.Phase = 4;
      }
      if (!this.CorrectClothingConfirmed && this.RequiredClothingID > 0 && (Object) this.StudentManager.Students[this.TargetID] != (Object) null && !this.StudentManager.Students[this.TargetID].Alive)
      {
        if (this.Yandere.Schoolwear != this.RequiredClothingID)
        {
          this.Chastise = true;
          this.GameOverID = 3;
          this.GameOver();
          this.Phase = 4;
        }
        else
          this.CorrectClothingConfirmed = true;
      }
      if (this.RequiredDisposalID > 0 && this.DisposalMethod == 0 && this.TargetDead)
      {
        for (this.ID = 1; this.ID < this.Incinerator.Victims + 1; ++this.ID)
        {
          if (this.Incinerator.VictimList[this.ID] == this.TargetID && this.Incinerator.Smoke.isPlaying)
            this.DisposalMethod = 1;
        }
        int num = 0;
        for (this.ID = 1; this.ID < this.Incinerator.Limbs + 1; ++this.ID)
        {
          if (this.Incinerator.LimbList[this.ID] == this.TargetID)
            ++num;
          if (num == 6 && this.Incinerator.Smoke.isPlaying)
            this.DisposalMethod = 1;
        }
        for (this.ID = 1; this.ID < this.WoodChipper.Victims + 1; ++this.ID)
        {
          if (this.WoodChipper.VictimList[this.ID] == this.TargetID && this.WoodChipper.Shredding)
            this.DisposalMethod = 2;
        }
        for (this.ID = 1; this.ID < this.GardenHoles.Length; ++this.ID)
        {
          if (this.GardenHoles[this.ID].VictimID == this.TargetID && !this.GardenHoles[this.ID].enabled)
            this.DisposalMethod = 3;
        }
        if (this.DisposalMethod > 0)
        {
          if (this.DisposalMethod != this.RequiredDisposalID)
          {
            this.Chastise = true;
            this.GameOverID = 4;
            this.GameOver();
            this.Phase = 4;
          }
          else
            this.CorpseDisposed = true;
        }
      }
      if (this.NoCollateral)
      {
        if (this.Police.Corpses == 1)
        {
          if (this.Police.CorpseList[0].StudentID != this.TargetID)
          {
            this.Chastise = true;
            this.GameOverID = 5;
            this.GameOver();
            this.Phase = 4;
          }
        }
        else if (this.Police.Corpses > 1)
        {
          this.GameOverID = 5;
          this.GameOver();
          this.Phase = 4;
        }
      }
      if (this.NoWitnesses)
      {
        for (this.ID = 1; this.ID < this.StudentManager.Students.Length; ++this.ID)
        {
          if ((Object) this.StudentManager.Students[this.ID] != (Object) null && this.StudentManager.Students[this.ID].WitnessedMurder && !this.Yandere.DelinquentFighting)
          {
            this.SpottedLabel.text = this.StudentManager.Students[this.ID].Name;
            this.SpottedWindow.SetActive(true);
            this.Chastise = true;
            this.GameOverID = 6;
            if (this.Yandere.Mopping)
              this.GameOverID = 20;
            this.GameOver();
            this.Phase = 4;
          }
        }
      }
      if (this.NoCorpses)
      {
        for (this.ID = 1; this.ID < this.StudentManager.Students.Length; ++this.ID)
        {
          if ((Object) this.StudentManager.Students[this.ID] != (Object) null && (this.StudentManager.Students[this.ID].WitnessedCorpse || this.StudentManager.Students[this.ID].WitnessedMurder))
          {
            this.SpottedLabel.text = this.StudentManager.Students[this.ID].Name;
            this.SpottedWindow.SetActive(true);
            this.Chastise = true;
            this.GameOverID = !this.Yandere.DelinquentFighting ? 7 : 19;
            this.GameOver();
            this.Phase = 4;
          }
        }
      }
      if (this.NoBlood)
      {
        if (this.Police.Deaths > 0)
          this.CheckForBlood = true;
        if (this.CheckForBlood)
        {
          if (this.Police.BloodParent.childCount == 0)
          {
            this.BloodTimer += Time.deltaTime;
            if ((double) this.BloodTimer > 2.0)
              this.BloodCleaned = true;
          }
          else
            this.BloodTimer = 0.0f;
        }
      }
      if (this.NoWeapon && !this.WeaponDisposed && (double) this.Incinerator.Timer > 0.0)
      {
        for (this.ID = 1; this.ID < this.Incinerator.DestroyedEvidence + 1; ++this.ID)
        {
          if (this.Incinerator.EvidenceList[this.ID] == this.MurderWeaponID)
            this.WeaponDisposed = true;
        }
      }
      if (this.TimeLimit)
      {
        if (!this.Yandere.PauseScreen.Show)
          this.TimeRemaining = Mathf.MoveTowards(this.TimeRemaining, 0.0f, Time.deltaTime);
        int num = Mathf.CeilToInt(this.TimeRemaining);
        this.TimeLabel.text = string.Format("{0:00}:{1:00}", (object) (num / 60), (object) (num % 60));
        if ((double) this.TimeRemaining == 0.0)
        {
          this.Chastise = true;
          this.GameOverID = 10;
          this.GameOver();
          this.Phase = 4;
        }
      }
      if ((double) this.Reputation.Reputation + (double) this.Reputation.PendingRep <= -100.0)
      {
        this.GameOverID = 14;
        this.GameOver();
        this.Phase = 4;
      }
      if (this.NoSuspicion && (double) this.Reputation.Reputation + (double) this.Reputation.PendingRep < 0.0)
      {
        this.GameOverID = 14;
        this.GameOver();
        this.Phase = 4;
      }
      if (this.HeartbrokenCamera.activeInHierarchy)
      {
        this.HeartbrokenCamera.SetActive(false);
        this.GameOverID = 0;
        this.GameOver();
        this.Phase = 4;
      }
      if ((double) this.Clock.PresentTime > 1080.0)
      {
        this.GameOverID = 11;
        this.GameOver();
        this.Phase = 4;
      }
      else if (this.Police.FadeOut)
      {
        this.GameOverID = 12;
        this.GameOver();
        this.Phase = 4;
      }
      if (this.Yandere.ShoulderCamera.Noticed)
      {
        this.GameOverID = this.Yandere.Senpai.GetComponent<StudentScript>().Club != ClubType.Council ? 17 : 21;
        this.GameOver();
        this.Phase = 4;
      }
      if (this.ExitPortal.activeInHierarchy)
      {
        if (this.Yandere.Chased || this.Yandere.Chasers > 0)
        {
          this.ExitPortalPrompt.Label[0].text = "     Cannot Exfiltrate!";
          this.ExitPortalPrompt.Circle[0].fillAmount = 1f;
        }
        else
        {
          this.ExitPortalPrompt.Label[0].text = "     Exfiltrate";
          if ((double) this.ExitPortalPrompt.Circle[0].fillAmount == 0.0)
          {
            this.StudentManager.DisableChaseCameras();
            this.MainCamera.transform.position = new Vector3(0.5f, 2.25f, -100.5f);
            this.MainCamera.transform.eulerAngles = Vector3.zero;
            this.Yandere.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
            this.Yandere.transform.position = new Vector3(0.0f, 0.0f, -94.5f);
            this.Yandere.Character.GetComponent<Animation>().Play(this.Yandere.WalkAnim);
            this.Yandere.RPGCamera.enabled = false;
            this.Yandere.HUD.gameObject.SetActive(false);
            this.Yandere.ResetYandereEffects();
            this.Yandere.YandereVision = false;
            this.Yandere.CanMove = false;
            this.Jukebox.MissionMode.clip = this.StealthMusic[10];
            this.Jukebox.MissionMode.loop = false;
            this.Jukebox.MissionMode.Play();
            this.MyAudio.PlayOneShot(this.InfoAccomplished);
            this.HeartbeatCamera.SetActive(false);
            this.Boundary.enabled = false;
            ++this.Phase;
          }
        }
      }
      if (this.TargetDead && this.CorpseDisposed && this.BloodCleaned && this.WeaponDisposed && this.DocumentsStolen && this.GameOverID == 0 && !this.ExitPortal.activeInHierarchy)
      {
        this.NotificationManager.DisplayNotification(NotificationType.Complete);
        this.NotificationManager.DisplayNotification(NotificationType.Exfiltrate);
        this.MyAudio.PlayOneShot(this.InfoExfiltrate);
        this.AlphabetArrow.gameObject.SetActive(true);
        this.ExitPortal.SetActive(true);
      }
      if (this.NoBlood && this.BloodCleaned && this.Police.BloodParent.childCount > 0)
      {
        this.ExitPortal.SetActive(false);
        this.BloodCleaned = false;
        this.BloodTimer = 0.0f;
      }
      if (!this.InfoRemark && this.GameOverID == 0 && this.TargetDead && (!this.CorpseDisposed || !this.BloodCleaned || !this.WeaponDisposed))
      {
        this.MyAudio.PlayOneShot(this.InfoObjective);
        this.InfoRemark = true;
      }
      if (!this.ExitPortal.activeInHierarchy)
        return;
      this.AlphabetArrow.LocalArrow.LookAt(new Vector3(0.0f, 0.0f, this.ExitPortal.transform.position.z));
      this.AlphabetArrow.transform.eulerAngles = this.AlphabetArrow.LocalArrow.transform.eulerAngles - new Vector3(0.0f, this.StudentManager.MainCamera.transform.eulerAngles.y, 0.0f);
    }
    else if (this.Phase == 3)
    {
      this.Timer += Time.deltaTime;
      this.MainCamera.transform.position = new Vector3(this.MainCamera.transform.position.x, this.MainCamera.transform.position.y - Time.deltaTime * 0.2f, this.MainCamera.transform.position.z);
      this.Yandere.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y, this.Yandere.transform.position.z - Time.deltaTime);
      if ((double) this.Timer <= 5.0)
        return;
      this.Success();
      this.Timer = 0.0f;
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 4)
        return;
      this.Timer += 0.01666667f;
      if ((double) this.Timer > 1.0)
      {
        if (!this.FadeOut)
        {
          if (!this.PromptBar.Show)
          {
            this.PromptBar.Show = true;
          }
          else
          {
            GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
            if (Input.GetButtonDown("A"))
            {
              this.PromptBar.Show = false;
              this.Destination = 1;
              this.FadeOut = true;
            }
            else if (Input.GetButtonDown("B"))
            {
              this.PromptBar.Show = false;
              this.Destination = 2;
              this.FadeOut = true;
            }
            else if (Input.GetButtonDown("X"))
            {
              this.PromptBar.Show = false;
              this.Destination = 3;
              this.FadeOut = true;
            }
          }
        }
        else
        {
          this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, 0.01666667f));
          this.Jukebox.Dip = Mathf.MoveTowards(this.Jukebox.Dip, 0.0f, 0.01666667f);
          if ((double) this.Darkness.color.a > (double) sbyte.MaxValue / 128.0)
          {
            if (this.Destination == 1)
            {
              this.LoadingLabel.enabled = true;
              this.ResetGlobals();
              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (this.Destination == 2)
            {
              Globals.DeleteAll();
              SceneManager.LoadScene("MissionModeScene");
            }
            else if (this.Destination == 3)
            {
              Globals.DeleteAll();
              SceneManager.LoadScene("NewTitleScene");
            }
            else if (this.Destination == 4)
            {
              Globals.DeleteAll();
              SceneManager.LoadScene("DiscordScene");
            }
          }
        }
      }
      if (this.GameOverPhase == 1)
      {
        if ((double) this.Timer <= 2.5)
          return;
        if (this.Chastise)
        {
          this.MyAudio.PlayOneShot(this.InfoFailure);
          ++this.GameOverPhase;
        }
        else
        {
          ++this.GameOverPhase;
          this.Timer += 5f;
        }
      }
      else
      {
        if (this.GameOverPhase != 2 || (double) this.Timer <= 7.5)
          return;
        this.Jukebox.MissionMode.clip = this.StealthMusic[0];
        this.Jukebox.MissionMode.Play();
        this.Jukebox.Volume = 0.5f;
        ++this.GameOverPhase;
      }
    }
  }

  public void GameOver()
  {
    if (this.Yandere.Aiming)
      this.Yandere.StopAiming();
    if (this.Yandere.YandereVision)
    {
      this.Yandere.YandereVision = false;
      this.Yandere.ResetYandereEffects();
    }
    this.Yandere.enabled = false;
    this.GameOverReason.text = this.GameOverReasons[this.GameOverID];
    this.Fire.enabled = true;
    this.MyAudio.PlayOneShot(this.GameOverSound);
    this.DetectionCamera.SetActive(false);
    this.HeartbeatCamera.SetActive(false);
    this.WitnessCamera.SetActive(false);
    this.GameOverText.SetActive(true);
    this.Yandere.HUD.gameObject.SetActive(false);
    this.Subtitle.SetActive(false);
    Time.timeScale = 0.0001f;
    this.GameOverPhase = 1;
    this.Jukebox.MissionMode.Stop();
  }

  private void Success()
  {
    while (!this.Valid)
    {
      this.RandomNumber = (float) Random.Range(1000000, 10000000);
      if ((double) this.RandomNumber / 9.0 % 5.0 == 0.0)
        this.Valid = true;
    }
    this.DiscordCodeLabel.text = this.RandomNumber.ToString() ?? "";
    this.DiscordCodeLabel.transform.parent.gameObject.SetActive(true);
    this.GameOverHeader.transform.localPosition = new Vector3(this.GameOverHeader.transform.localPosition.x, 0.0f, this.GameOverHeader.transform.localPosition.z);
    this.GameOverHeader.text = "MISSION ACCOMPLISHED";
    this.GameOverReason.gameObject.SetActive(false);
    this.DetectionCamera.SetActive(false);
    this.WitnessCamera.SetActive(false);
    this.GameOverText.SetActive(true);
    this.GameOverReason.text = string.Empty;
    this.Subtitle.SetActive(false);
    this.Jukebox.Volume = 1f;
    Time.timeScale = 0.0001f;
    this.Fire.enabled = true;
  }

  public void ChangeMusic()
  {
    ++this.MusicID;
    if (this.MusicID > 9)
      this.MusicID = 1;
    this.Jukebox.MissionMode.clip = this.StealthMusic[this.MusicID];
    this.Jukebox.MissionMode.Play();
  }

  private void ResetGlobals()
  {
    Debug.Log((object) ("Mission Difficulty was: " + MissionModeGlobals.MissionDifficulty.ToString()));
    int disableFarAnimations = OptionGlobals.DisableFarAnimations;
    bool disablePostAliasing = OptionGlobals.DisablePostAliasing;
    bool disableOutlines = OptionGlobals.DisableOutlines;
    int lowDetailStudents = OptionGlobals.LowDetailStudents;
    int particleCount = OptionGlobals.ParticleCount;
    bool enableShadows = OptionGlobals.EnableShadows;
    int drawDistance = OptionGlobals.DrawDistance;
    int drawDistanceLimit = OptionGlobals.DrawDistanceLimit;
    bool disableBloom = OptionGlobals.DisableBloom;
    bool fog = OptionGlobals.Fog;
    bool nemesisAggression = MissionModeGlobals.NemesisAggression;
    string missionTargetName = MissionModeGlobals.MissionTargetName;
    bool highPopulation = OptionGlobals.HighPopulation;
    Globals.DeleteAll();
    OptionGlobals.TutorialsOff = true;
    for (int index = 1; index < 11; ++index)
    {
      PlayerPrefs.SetInt("MissionModeTarget" + index.ToString(), this.Target[index]);
      PlayerPrefs.SetInt("MissionModeMethod" + index.ToString(), this.Method[index]);
    }
    SchoolGlobals.SchoolAtmosphere = (float) (1.0 - (double) this.Difficulty * 0.100000001490116);
    MissionModeGlobals.MissionTargetName = missionTargetName;
    MissionModeGlobals.MissionDifficulty = this.Difficulty;
    OptionGlobals.HighPopulation = highPopulation;
    MissionModeGlobals.MissionTarget = this.TargetID;
    SchoolGlobals.SchoolAtmosphereSet = true;
    MissionModeGlobals.MissionMode = true;
    MissionModeGlobals.MultiMission = this.MultiMission;
    MissionModeGlobals.MissionRequiredWeapon = this.RequiredWeaponID;
    MissionModeGlobals.MissionRequiredClothing = this.RequiredClothingID;
    MissionModeGlobals.MissionRequiredDisposal = this.RequiredDisposalID;
    ClassGlobals.BiologyGrade = 1;
    ClassGlobals.ChemistryGrade = 1;
    ClassGlobals.LanguageGrade = 1;
    ClassGlobals.PhysicalGrade = 1;
    ClassGlobals.PsychologyGrade = 1;
    for (this.ID = 2; this.ID < 11; ++this.ID)
      MissionModeGlobals.SetMissionCondition(this.ID, this.Conditions[this.ID]);
    MissionModeGlobals.NemesisDifficulty = this.NemesisDifficulty;
    MissionModeGlobals.NemesisAggression = nemesisAggression;
    OptionGlobals.DisableFarAnimations = disableFarAnimations;
    OptionGlobals.DisablePostAliasing = disablePostAliasing;
    OptionGlobals.DisableOutlines = disableOutlines;
    OptionGlobals.LowDetailStudents = lowDetailStudents;
    OptionGlobals.ParticleCount = particleCount;
    OptionGlobals.EnableShadows = enableShadows;
    OptionGlobals.DrawDistance = drawDistance;
    OptionGlobals.DrawDistanceLimit = drawDistanceLimit;
    OptionGlobals.DisableBloom = disableBloom;
    OptionGlobals.Fog = fog;
    Debug.Log((object) ("Mission Difficulty is now: " + MissionModeGlobals.MissionDifficulty.ToString()));
  }

  private void ChangeAllText()
  {
    foreach (UILabel uiLabel in Object.FindObjectsOfType<UILabel>())
    {
      uiLabel.color = new Color(1f, 1f, 1f, uiLabel.color.a);
      uiLabel.trueTypeFont = this.Arial;
    }
    foreach (UISprite uiSprite in Object.FindObjectsOfType<UISprite>())
    {
      float a = uiSprite.color.a;
      if (uiSprite.color != new Color(0.0f, 0.0f, 0.0f, a))
        uiSprite.color = new Color(1f, 1f, 1f, a);
    }
  }

  private void CheckForCompletion()
  {
    if (this.Checking[1] || this.Checking[2] || this.Checking[3] || this.Checking[4] || this.Checking[5] || this.Checking[6] || this.Checking[7] || this.Checking[8] || this.Checking[9] || this.Checking[10])
      return;
    this.TargetDead = true;
  }
}
