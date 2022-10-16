// Decompiled with JetBrains decompiler
// Type: NewTitleScreenScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using RetroAesthetics;
using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class NewTitleScreenScript : MonoBehaviour
{
  public CameraFilterPack_TV_Vignetting Vignette;
  public SelectiveGrayscale Grayscale;
  public TitleScreenOsanaScript Osana;
  public TitleDemoChecklistScript TitleDemoChecklist;
  public TitleSaveFilesScript TitleSaveFiles;
  public InputManagerScript InputManager;
  public TitleSponsorScript TitleSponsor;
  public NewSettingsScript NewSettings;
  public InputDeviceScript InputDevice;
  public PromptBarScript PromptBar;
  public PostProcessingProfile Profile;
  public Animation YandereAnimation;
  public GameObject CongratulationsWindow;
  public GameObject BloodProjector;
  public GameObject LoveLetter;
  public GameObject Knife;
  public AudioSource[] FountainSFX;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public AudioClip SpookyEightiesMusic;
  public AudioClip SpookyMusic;
  public Transform LookAtTarget;
  public UIPanel TitleScreenPanel;
  public UISprite EightiesWindow;
  public UISprite DemoWindow;
  public UISprite DemoChecklist;
  public UISprite ModeSelection;
  public UISprite CheatEntry;
  public UISprite SaveFiles;
  public UISprite Darkness;
  public UISprite Settings;
  public UISprite Sponsors;
  public UISprite Cursor;
  public UILabel[] Questions;
  public UILabel ExtrasLabel;
  public UILabel CheatLabel;
  public UILabel PressStart;
  public UILabel DebugLog;
  public AudioClip Whoosh;
  public float BloomIntensity = 40f;
  public float SpeedUpFactor = 1f;
  public float BloomRadius = 7f;
  public float DepthFocus = 2f;
  public float Speed = 1f;
  public float DebugTimer;
  public int CurrentQuestion = 1;
  public int PositionX;
  public int Selection = 1;
  public int Options = 7;
  public int Frame;
  public int Phase = 1;
  public int Log;
  public bool FadeQuestion;
  public bool QuickStart;
  public bool WeekSelect;
  public bool Eighties;
  public bool ForVideo;
  public bool FadeOut;
  public AudioClip MakeSelection;
  public AudioClip MoveCursor;
  public RetroCameraEffect EightiesEffects;
  public NormalBufferView VaporwaveVisuals;
  public AudioSource EightiesJukebox;
  public AudioSource CurrentJukebox;
  public Material VaporwaveSkybox;
  public UILabel MissionModeLabel;
  public UITexture EightiesLogo;
  public GameObject HeartPanel;
  public GameObject PalmTrees;
  public GameObject DemoText;
  public GameObject Trees;
  public GameObject AyanoHair;
  public GameObject RyobaHair;
  public SkinnedMeshRenderer YandereRenderer;
  public GameObject EightiesFilter;
  public GameObject NormalLogo;
  public Material NormalSkybox;
  public Mesh EightiesUniform;
  public Mesh ModernUniform;
  public Font Futura;
  public Font VCR;
  public string[] EightiesRivalNames;
  public string[] RivalNames;
  public GameObject PikaLoliMode;
  public string[] Letter;
  public int ID;
  public string[] VtuberNames;
  public UILabel[] ModeDescLabel;
  public GameObject[] VtuberHairs;
  public int Spaces;

  private void Start()
  {
    GameGlobals.VtuberID = 0;
    MissionModeGlobals.MissionMode = false;
    this.Eighties = GameGlobals.Eighties;
    Time.timeScale = 2f;
    this.YandereAnimation["f02_idleCouncilStrict_00"].speed = 0.5f;
    this.transform.position = new Vector3(0.0f, 0.5f, -18f);
    this.transform.eulerAngles = new Vector3(-15f, 0.0f, 0.0f);
    this.LookAtTarget.position = new Vector3(0.0f, 5.055138f, 0.0f);
    this.UpdateBloom(this.BloomIntensity, this.BloomRadius);
    this.UpdateDOF(this.DepthFocus);
    this.ResetVignette();
    this.ModeSelection.alpha = 0.0f;
    this.DemoChecklist.alpha = 0.0f;
    this.CheatEntry.alpha = 0.0f;
    this.PressStart.alpha = 0.0f;
    this.SaveFiles.alpha = 0.0f;
    this.Settings.alpha = 0.0f;
    this.Sponsors.alpha = 0.0f;
    this.Cursor.alpha = 0.0f;
    this.Profile.colorGrading.enabled = false;
    this.BloodProjector.SetActive(false);
    this.LoveLetter.SetActive(true);
    this.Knife.SetActive(false);
    if (this.Eighties)
      this.EnableEightiesEffects();
    else
      this.DisableEightiesEffects();
    if (SchoolGlobals.SchoolAtmosphereSet && (double) SchoolGlobals.SchoolAtmosphere < 0.5)
    {
      this.EightiesJukebox.clip = this.SpookyEightiesMusic;
      this.Jukebox.clip = this.SpookyMusic;
      this.EightiesJukebox.Play();
      this.Jukebox.Play();
      this.Grayscale.enabled = true;
      this.Vignette.enabled = true;
    }
    if (OptionGlobals.DrawDistance == 0 || OptionGlobals.DrawDistanceLimit == 0)
    {
      OptionGlobals.DrawDistanceLimit = 350;
      OptionGlobals.DrawDistance = 350;
    }
    this.NewSettings.UpdateGraphics();
    GameGlobals.TransitionToPostCredits = false;
    GameGlobals.DarkEnding = false;
    GameGlobals.Debug = false;
    if (DateGlobals.Week == 2 && !GameGlobals.PlayerHasBeatenDemo && !this.Eighties)
    {
      this.CongratulationsWindow.SetActive(true);
      GameGlobals.PlayerHasBeatenDemo = true;
    }
    this.EightiesLogo.alpha = 0.0f;
    this.VtuberHairs[1].SetActive(false);
  }

  private void Update()
  {
    if (this.Frame == 1)
    {
      if (this.Eighties)
        this.EnableEightiesEffects();
      else
        this.DisableEightiesEffects();
      GameGlobals.Debug = false;
    }
    ++this.Frame;
    if (Input.GetKey(KeyCode.Escape))
    {
      if (Input.GetKeyDown("-"))
        --Time.timeScale;
      if (Input.GetKeyDown("="))
        ++Time.timeScale;
      this.DebugTimer += Time.deltaTime;
      if ((double) this.DebugTimer > 100.0)
      {
        DateGlobals.Week = 2;
        GameGlobals.RivalEliminationID = 1;
        GameGlobals.NonlethalElimination = false;
        SceneManager.LoadScene("NewTitleScene");
      }
    }
    if (this.Log == 0)
    {
      if (Input.GetKeyDown("l"))
        ++this.Log;
    }
    else if (this.Log == 1)
    {
      if (Input.GetKeyDown("o"))
        ++this.Log;
    }
    else if (this.Log == 2)
    {
      if (Input.GetKeyDown("g"))
      {
        this.DebugLog.gameObject.SetActive(true);
        ++this.Log;
      }
    }
    else if (this.Log == 3)
      this.DebugLog.text = "GameGlobals.Debug is: " + GameGlobals.Debug.ToString() + " and QuickStart is: " + this.QuickStart.ToString();
    if (Input.GetKeyDown("m"))
      this.CurrentJukebox.volume = 0.0f;
    this.Cursor.transform.parent.Rotate(new Vector3(Time.deltaTime * 100f, 0.0f, 0.0f), Space.Self);
    if (this.Phase != 2)
      this.Cursor.alpha = Mathf.MoveTowards(this.Cursor.alpha, 0.0f, Time.deltaTime);
    this.Cursor.transform.parent.localPosition = Vector3.Lerp(this.Cursor.transform.parent.localPosition, new Vector3((float) this.PositionX, (float) (300.0 - 75.0 * (double) this.Selection), this.Cursor.transform.parent.localPosition.z), Time.deltaTime * 10f);
    if (!this.FadeOut)
    {
      this.PressStart.text = this.InputDevice.Type != InputDeviceType.Gamepad ? "PRESS ENTER" : "PRESS START";
      if (this.Phase < 2)
      {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.0f, 0.5f, -17f), Time.deltaTime * 0.5f * this.SpeedUpFactor);
        this.EightiesLogo.alpha = Mathf.MoveTowards(this.EightiesLogo.alpha, 1f, Time.deltaTime * 0.2f);
        this.BloomIntensity = Mathf.Lerp(this.BloomIntensity, 1f, Time.deltaTime * this.Speed);
        this.BloomRadius = Mathf.Lerp(this.BloomRadius, 4f, Time.deltaTime * this.Speed);
        this.UpdateBloom(this.BloomIntensity, this.BloomRadius);
        this.UpdateDOF(2f);
      }
      if (this.Phase == 0)
      {
        if (Input.anyKeyDown)
          ++this.Speed;
        if ((double) this.BloomIntensity < 1.1000000238418579)
        {
          if (this.CongratulationsWindow.activeInHierarchy)
          {
            if (!this.PromptBar.Show)
            {
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Cool, thanks bro!";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
            }
            if (Input.GetButtonDown("A"))
            {
              this.CongratulationsWindow.SetActive(false);
              this.PromptBar.Show = false;
            }
          }
          else
          {
            this.PressStart.alpha = Mathf.MoveTowards(this.PressStart.alpha, 1f, Time.deltaTime);
            if (Input.GetButtonDown("Start"))
            {
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Confirm";
              this.PromptBar.Label[5].text = "Change Selection";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              this.Speed = 0.0f;
              ++this.Phase;
            }
          }
        }
      }
      else if (this.Phase == 1)
      {
        this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0.0f, 5.055138f, 0.0f), Time.deltaTime);
        this.ModeSelection.alpha = Mathf.MoveTowards(this.ModeSelection.alpha, 1f, Time.deltaTime);
        this.PressStart.alpha = Mathf.MoveTowards(this.PressStart.alpha, 0.0f, Time.deltaTime);
        if (this.Eighties)
        {
          this.EightiesWindow.alpha = Mathf.MoveTowards(this.EightiesWindow.alpha, 1f, Time.deltaTime * 10f);
          this.DemoWindow.alpha = Mathf.MoveTowards(this.DemoWindow.alpha, 0.25f, Time.deltaTime * 10f);
        }
        else
        {
          this.EightiesWindow.alpha = Mathf.MoveTowards(this.EightiesWindow.alpha, 0.25f, Time.deltaTime * 10f);
          this.DemoWindow.alpha = Mathf.MoveTowards(this.DemoWindow.alpha, 1f, Time.deltaTime * 10f);
        }
        if ((double) this.ModeSelection.alpha == 1.0 && (double) this.LookAtTarget.position.y > 3.0)
        {
          if (this.InputManager.TappedLeft || this.InputManager.TappedRight)
          {
            this.Eighties = !this.Eighties;
            GameGlobals.Eighties = this.Eighties;
            if (this.Eighties)
              this.EnableEightiesEffects();
            else
              this.DisableEightiesEffects();
          }
          if (Input.GetButtonDown("A"))
          {
            this.PromptBar.Label[0].text = "Make Selection";
            this.PromptBar.Label[1].text = "Back";
            this.PromptBar.Label[4].text = "Change Selection";
            this.PromptBar.Label[5].text = "";
            this.PromptBar.UpdateButtons();
            this.MyAudio.clip = this.Whoosh;
            this.MyAudio.pitch = 0.5f;
            this.MyAudio.volume = 1f;
            this.MyAudio.Play();
            this.Speed = 0.0f;
            this.Phase = 2;
          }
        }
      }
      else if (this.Phase == 2)
      {
        this.Speed += Time.deltaTime * 2f;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-0.666666f, 1.195f, -2.9f), Time.deltaTime * this.Speed);
        this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0.0f, 1.195f, -2.263333f), Time.deltaTime * this.Speed);
        this.DepthFocus = Mathf.Lerp(this.DepthFocus, 1f, Time.deltaTime * this.Speed);
        this.UpdateDOF(this.DepthFocus);
        this.Settings.alpha = Mathf.MoveTowards(this.Settings.alpha, 0.0f, Time.deltaTime);
        this.Sponsors.alpha = Mathf.MoveTowards(this.Sponsors.alpha, 0.0f, Time.deltaTime);
        this.SaveFiles.alpha = Mathf.MoveTowards(this.SaveFiles.alpha, 0.0f, Time.deltaTime);
        this.CheatEntry.alpha = Mathf.MoveTowards(this.CheatEntry.alpha, 0.0f, Time.deltaTime);
        this.DemoChecklist.alpha = Mathf.MoveTowards(this.DemoChecklist.alpha, 0.0f, Time.deltaTime);
        if ((double) this.Speed > 3.0)
        {
          this.Cursor.alpha = Mathf.MoveTowards(this.Cursor.alpha, 1f, Time.deltaTime);
          if ((double) this.Cursor.alpha == 1.0)
          {
            if (!this.PromptBar.Show && !this.ForVideo)
            {
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Make Selection";
              this.PromptBar.Label[1].text = "Back";
              this.PromptBar.Label[4].text = "Change Selection";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
            }
            if (this.InputManager.TappedDown)
            {
              ++this.Selection;
              this.UpdateCursor();
            }
            if (this.InputManager.TappedUp)
            {
              --this.Selection;
              this.UpdateCursor();
            }
            if (Input.GetButtonDown("A"))
            {
              if (this.ForVideo)
              {
                this.Phase = 7;
              }
              else
              {
                this.PromptBar.Show = false;
                if (this.Selection == 1)
                {
                  this.TitleSaveFiles.enabled = true;
                  this.Speed = 0.0f;
                  this.Phase = 3;
                }
                else if (this.Selection == 2)
                {
                  this.TitleDemoChecklist.enabled = true;
                  this.Speed = 0.0f;
                  this.Phase = 4;
                }
                else if (this.Selection == 4)
                {
                  this.TitleSponsor.enabled = true;
                  this.Speed = 0.0f;
                  this.Phase = 5;
                }
                else if (this.Selection == 5)
                {
                  this.NewSettings.enabled = true;
                  this.NewSettings.Cursor.alpha = 0.0f;
                  this.NewSettings.Selection = 1;
                  this.Speed = 0.0f;
                  this.Phase = 6;
                }
                else if (this.Selection == 7)
                {
                  if ((double) this.ExtrasLabel.alpha == 1.0)
                  {
                    this.Speed = 0.0f;
                    this.Phase = 7;
                  }
                  else
                    this.PromptBar.Show = true;
                }
                else if (this.Selection == 3 && !this.Eighties || this.Selection == 6 || this.Selection == 8)
                  this.FadeOut = true;
                this.MyAudio.clip = this.MakeSelection;
                this.MyAudio.volume = 0.5f;
                this.MyAudio.pitch = 1f;
                this.MyAudio.Play();
              }
            }
            else if (Input.GetButtonDown("B"))
            {
              this.PromptBar.Label[1].text = "";
              this.PromptBar.Label[4].text = "";
              this.PromptBar.Label[5].text = "Change Selection";
              this.PromptBar.UpdateButtons();
              this.SpeedUpFactor = 10f;
              this.Speed = 0.0f;
              this.Phase = 1;
            }
          }
        }
      }
      else if (this.Phase == 3)
      {
        this.Speed += Time.deltaTime * 2f;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.125f, 0.875f, -2.66666f), Time.deltaTime * this.Speed);
        this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0.1f, 0.875f, 0.0f), Time.deltaTime * this.Speed);
        this.SaveFiles.alpha = Mathf.MoveTowards(this.SaveFiles.alpha, 1f, Time.deltaTime);
        this.DepthFocus = Mathf.Lerp(this.DepthFocus, 0.225f, Time.deltaTime * this.Speed);
        this.UpdateDOF(this.DepthFocus);
      }
      else if (this.Phase == 4)
      {
        this.Speed += Time.deltaTime * 2f;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.0f, 29.5f, 0.0f), Time.deltaTime * this.Speed);
        this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0.0f, 0.0f, 0.1f), Time.deltaTime * this.Speed);
        this.DemoChecklist.alpha = Mathf.MoveTowards(this.DemoChecklist.alpha, 1f, Time.deltaTime);
        this.DepthFocus = Mathf.Lerp(this.DepthFocus, 2f, Time.deltaTime * this.Speed);
        this.UpdateDOF(this.DepthFocus);
      }
      else if (this.Phase == 5)
      {
        this.Speed += Time.deltaTime * 2f;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.0f, 0.66f, -1.6f), Time.deltaTime * this.Speed);
        this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0.0f, 0.66f, 0.0f), Time.deltaTime * this.Speed);
        this.Sponsors.alpha = Mathf.MoveTowards(this.Sponsors.alpha, 1f, Time.deltaTime);
        this.DepthFocus = Mathf.Lerp(this.DepthFocus, 1f, Time.deltaTime * this.Speed);
        this.UpdateDOF(this.DepthFocus);
      }
      else if (this.Phase == 6)
      {
        this.Speed += Time.deltaTime * 2f;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.0f, 0.85f, -4f), Time.deltaTime * this.Speed);
        this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0.0f, 0.85f, 0.0f), Time.deltaTime * this.Speed);
        this.Settings.alpha = Mathf.MoveTowards(this.Settings.alpha, 1f, Time.deltaTime);
        this.DepthFocus = Mathf.Lerp(this.DepthFocus, 2f, Time.deltaTime * this.Speed);
        this.UpdateDOF(this.DepthFocus);
      }
      else if (this.Phase == 7)
      {
        this.Speed += Time.deltaTime * 2f;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.0f, 2.4f, -0.5f), Time.deltaTime * this.Speed);
        this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0.0f, 2.4f, 0.0f), Time.deltaTime * this.Speed);
        this.DepthFocus = Mathf.Lerp(this.DepthFocus, 0.5f, Time.deltaTime * this.Speed);
        this.UpdateDOF(this.DepthFocus);
        this.CheatEntry.alpha = Mathf.MoveTowards(this.CheatEntry.alpha, 1f, Time.deltaTime);
        if ((double) this.Speed > 3.0)
        {
          if (!this.PromptBar.Show)
          {
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[1].text = "Go Back";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
          }
          if (Input.GetKeyDown(KeyCode.Return))
          {
            if (this.CheatLabel.text == "debug" || this.CheatLabel.text == "Debug")
              this.CheatLabel.text = "Type 'debug' while at school!";
            else if (this.CheatLabel.text == "Nice Boat")
              this.CheatLabel.text = "Awwwww, you remembered!";
          }
          if (Input.GetButtonDown("B"))
          {
            this.PromptBar.Show = false;
            this.Speed = 0.0f;
            this.Phase = 2;
          }
        }
      }
      else if (this.Phase == 8)
      {
        if ((double) this.TitleScreenPanel.alpha > 0.0)
          this.TitleScreenPanel.alpha = Mathf.MoveTowards(this.TitleScreenPanel.alpha, 0.0f, Time.deltaTime * 2f);
        else if (!this.FadeQuestion)
        {
          this.Questions[this.CurrentQuestion].alpha = Mathf.MoveTowards(this.Questions[this.CurrentQuestion].alpha, 1f, Time.deltaTime * 2f);
          if (Input.GetButtonDown("A"))
            this.FadeQuestion = true;
        }
        else
        {
          this.Questions[this.CurrentQuestion].alpha = Mathf.MoveTowards(this.Questions[this.CurrentQuestion].alpha, 0.0f, Time.deltaTime * 2f);
          if ((double) this.Questions[this.CurrentQuestion].alpha == 0.0)
          {
            this.FadeQuestion = false;
            ++this.CurrentQuestion;
          }
        }
      }
    }
    else
    {
      this.PromptBar.Show = false;
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime * 0.5f);
      this.CurrentJukebox.volume = Mathf.MoveTowards(this.CurrentJukebox.volume, 0.0f, Time.deltaTime * 0.5f);
      this.FountainSFX[1].volume = Mathf.MoveTowards(this.FountainSFX[1].volume, 0.0f, Time.deltaTime * 0.5f);
      this.FountainSFX[2].volume = Mathf.MoveTowards(this.FountainSFX[2].volume, 0.0f, Time.deltaTime * 0.5f);
      if ((double) this.Darkness.alpha == 1.0)
      {
        Time.timeScale = 1f;
        if (this.Selection == 1)
        {
          int profile = GameGlobals.Profile;
          if (PlayerPrefs.GetInt("ProfileCreated_" + profile.ToString()) == 0)
          {
            profile = GameGlobals.Profile;
            PlayerPrefs.SetInt("ProfileCreated_" + profile.ToString(), 1);
            PlayerGlobals.Money = 10f;
            DateGlobals.Weekday = DayOfWeek.Sunday;
            DateGlobals.PassDays = 1;
            this.UpdateDOF(2f);
            if (this.WeekSelect)
            {
              this.SetEightiesVariables();
              GameGlobals.EightiesTutorial = false;
              SceneManager.LoadScene("WeekSelectScene");
            }
            else if (this.QuickStart)
            {
              GameGlobals.CameFromTitleScreen = true;
              SceneManager.LoadScene("CalendarScene");
            }
            else if (this.Eighties)
            {
              this.SetEightiesVariables();
              SceneManager.LoadScene("EightiesCutsceneScene");
            }
            else
            {
              StudentGlobals.FemaleUniform = 1;
              StudentGlobals.MaleUniform = 1;
              SceneManager.LoadScene("SenpaiScene");
            }
          }
          else if (!GameGlobals.EightiesTutorial)
          {
            if (DateGlobals.Week < 11)
            {
              GameGlobals.CameFromTitleScreen = true;
              SceneManager.LoadScene("CalendarScene");
            }
            else
              SceneManager.LoadScene("LoadingScene");
          }
          else
            SceneManager.LoadScene("EightiesCutsceneScene");
        }
        else if (this.Selection == 3)
          SceneManager.LoadScene("MissionModeScene");
        else if (this.Selection == 6)
          SceneManager.LoadScene("CreditsScene");
        else if (this.Selection == 8)
          Application.Quit();
      }
    }
    this.transform.LookAt(this.LookAtTarget);
  }

  private void UpdateBloom(float Intensity, float Radius)
  {
    BloomModel.Settings settings = this.Profile.bloom.settings;
    settings.bloom.intensity = Intensity;
    settings.bloom.radius = Radius;
    settings.bloom.softKnee = 1f;
    this.Profile.bloom.settings = settings;
    settings.bloom.softKnee = 1f;
  }

  private void UpdateDOF(float Focus)
  {
    Focus *= (float) (((double) Screen.width / 1280.0 + (double) Screen.height / 720.0) * 0.5);
    this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
    {
      focusDistance = Focus
    };
  }

  private void ResetVignette()
  {
    VignetteModel.Settings settings1 = this.Profile.vignette.settings with
    {
      color = new Color(1f, 0.75f, 1f)
    };
    ChromaticAberrationModel.Settings settings2 = this.Profile.chromaticAberration.settings with
    {
      intensity = 0.1f
    };
    this.Profile.vignette.settings = settings1;
    this.Profile.chromaticAberration.settings = settings2;
  }

  private void UpdateCursor()
  {
    if (this.Selection > this.Options)
      this.Selection = 1;
    else if (this.Selection < 1)
      this.Selection = this.Options;
    this.PositionX = this.Selection != 1 ? (this.Selection != 2 ? 40 + this.Selection * 10 : 20) : 0;
    this.MyAudio.clip = this.MoveCursor;
    this.MyAudio.volume = 0.5f;
    this.MyAudio.pitch = 1f;
    this.MyAudio.Play();
  }

  private void EnableEightiesEffects()
  {
    GameObjectUtils.SetLayerRecursively(this.EightiesLogo.transform.parent.gameObject, 5);
    RenderSettings.skybox = this.VaporwaveSkybox;
    this.VaporwaveVisuals.ApplyNormalView();
    this.EightiesEffects.enabled = true;
    this.CurrentJukebox = this.EightiesJukebox;
    this.EightiesJukebox.volume = 0.5f;
    this.Jukebox.volume = 0.0f;
    this.MissionModeLabel.alpha = 0.5f;
    this.EightiesLogo.gameObject.SetActive(true);
    this.Osana.gameObject.SetActive(false);
    this.NormalLogo.SetActive(false);
    this.HeartPanel.SetActive(true);
    this.DemoText.SetActive(false);
    this.AyanoHair.SetActive(false);
    this.RyobaHair.SetActive(true);
    this.EightiesFilter.SetActive(true);
    this.PalmTrees.SetActive(true);
    this.Trees.SetActive(false);
    this.ChangeTextOutline();
    this.ExtrasLabel.alpha = 1f;
    this.PressStart.trueTypeFont = this.VCR;
    GameGlobals.Profile = 11;
    GameGlobals.Eighties = true;
    this.TitleSaveFiles.EightiesPrefix = 10;
    this.TitleSaveFiles.SaveDatas[1].ID = 11;
    this.TitleSaveFiles.SaveDatas[2].ID = 12;
    this.TitleSaveFiles.SaveDatas[3].ID = 13;
    this.TitleSaveFiles.SaveDatas[1].Start();
    this.TitleSaveFiles.SaveDatas[2].Start();
    this.TitleSaveFiles.SaveDatas[3].Start();
    this.YandereRenderer.sharedMesh = this.ModernUniform;
    this.UpdateBloodyStatus();
  }

  private void DisableEightiesEffects()
  {
    GameObjectUtils.SetLayerRecursively(this.EightiesLogo.transform.parent.gameObject, 0);
    RenderSettings.skybox = this.NormalSkybox;
    this.VaporwaveVisuals.DisableNormalView();
    this.EightiesEffects.enabled = false;
    this.CurrentJukebox = this.Jukebox;
    this.EightiesJukebox.volume = 0.0f;
    this.Jukebox.volume = 0.5f;
    this.MissionModeLabel.alpha = 1f;
    this.EightiesLogo.gameObject.SetActive(false);
    this.Osana.gameObject.SetActive(true);
    this.HeartPanel.SetActive(false);
    this.NormalLogo.SetActive(true);
    this.DemoText.SetActive(true);
    this.AyanoHair.SetActive(true);
    this.RyobaHair.SetActive(false);
    this.EightiesFilter.SetActive(false);
    this.PalmTrees.SetActive(false);
    this.Trees.SetActive(true);
    this.ChangeTextOutline();
    this.ExtrasLabel.alpha = 1f;
    GameGlobals.Profile = 1;
    GameGlobals.Eighties = false;
    this.TitleSaveFiles.EightiesPrefix = 0;
    this.TitleSaveFiles.SaveDatas[1].ID = 1;
    this.TitleSaveFiles.SaveDatas[2].ID = 2;
    this.TitleSaveFiles.SaveDatas[3].ID = 3;
    this.TitleSaveFiles.SaveDatas[1].Start();
    this.TitleSaveFiles.SaveDatas[2].Start();
    this.TitleSaveFiles.SaveDatas[3].Start();
    this.YandereRenderer.sharedMesh = this.EightiesUniform;
    this.UpdateBloodyStatus();
  }

  private void ChangeTextOutline()
  {
    foreach (UILabel uiLabel in UnityEngine.Object.FindObjectsOfType<UILabel>())
    {
      if (this.Eighties)
      {
        uiLabel.effectColor = new Color(0.0f, 0.0f, 0.0f);
      }
      else
      {
        uiLabel.effectColor = new Color(1f, 0.5f, 1f);
        this.TitleSaveFiles.UpdateOutlines();
      }
    }
  }

  private void SetEightiesVariables()
  {
    GameGlobals.EightiesTutorial = true;
    GameGlobals.Eighties = true;
    for (int studentID = 1; studentID < 101; ++studentID)
      StudentGlobals.SetStudentPhotographed(studentID, true);
    StudentGlobals.FemaleUniform = 6;
    StudentGlobals.MaleUniform = 1;
    DateGlobals.Weekday = DayOfWeek.Saturday;
  }

  private void UpdateBloodyStatus()
  {
    if (PlayerGlobals.Kills > 0 || GameGlobals.RivalEliminationID > 0 && !GameGlobals.NonlethalElimination)
    {
      this.BloodProjector.SetActive(true);
      this.LoveLetter.SetActive(false);
      this.Knife.SetActive(true);
    }
    else
    {
      this.BloodProjector.SetActive(false);
      this.LoveLetter.SetActive(true);
      this.Knife.SetActive(false);
    }
  }

  private void LateUpdate()
  {
    if (this.ID < this.Letter.Length && Input.GetKeyDown(this.Letter[this.ID]))
    {
      ++this.ID;
      if (this.ID == this.Letter.Length)
      {
        this.PikaLoliMode.SetActive(true);
        GameGlobals.VtuberID = 1;
        this.UpdateModeDescLabels();
      }
    }
    if (!Input.GetKeyDown(KeyCode.Space))
      return;
    ++this.Spaces;
    if (this.Spaces <= 19)
      return;
    this.PikaLoliMode.SetActive(true);
    GameGlobals.VtuberID = 1;
    this.UpdateModeDescLabels();
  }

  private void UpdateModeDescLabels()
  {
    this.ModeDescLabel[1].text = "Play as " + this.VtuberNames[GameGlobals.VtuberID] + " in the year 2023.\n\nThis mode is still in development, and currently only features one rival girl.";
    this.ModeDescLabel[2].text = "Play as " + this.VtuberNames[GameGlobals.VtuberID] + " in the year 1989.\n\nThis mode is complete, and features ten rival girls.";
    this.VtuberHairs[GameGlobals.VtuberID].SetActive(true);
    this.RyobaHair.transform.position = new Vector3(0.0f, 100f, 0.0f);
    this.AyanoHair.transform.position = new Vector3(0.0f, 100f, 0.0f);
  }
}
