// Decompiled with JetBrains decompiler
// Type: PauseScreenScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenScript : MonoBehaviour
{
  public StudentInfoMenuScript StudentInfoMenu;
  public YouTubeChatMenuScript YouTubeChatMenu;
  public InventoryMenuScript InventoryMenu;
  public InputManagerScript InputManager;
  public PhotoGalleryScript PhotoGallery;
  public SaveLoadMenuScript SaveLoadMenu;
  public HomeYandereScript HomeYandere;
  public InputDeviceScript InputDevice;
  public MissionModeScript MissionMode;
  public NewSettingsScript NewSettings;
  public HomeCameraScript HomeCamera;
  public ServicesScript ServiceMenu;
  public FavorMenuScript FavorMenu;
  public AudioMenuScript AudioMenu;
  public IdeasMenuScript IdeasMenu;
  public PromptBarScript PromptBar;
  public TaskListScript Tutorials;
  public PassTimeScript PassTime;
  public ScheduleScript Schedule;
  public TaskListScript TaskList;
  public SchemesScript Schemes;
  public YandereScript Yandere;
  public RPG_Camera RPGCamera;
  public PoliceScript Police;
  public ClockScript Clock;
  public StatsScript Stats;
  public HintScript Hint;
  public MapScript Map;
  public UILabel SelectionLabel;
  public UILabel QuitLabel;
  public UILabel YesLabel;
  public UIPanel Panel;
  public UISprite Wifi;
  public GameObject NewMissionModeWindow;
  public GameObject MissionModeLabel;
  public GameObject MissionModeIcons;
  public GameObject LoadingScreen;
  public GameObject ControlMenu;
  public GameObject SchemesMenu;
  public GameObject StudentInfo;
  public GameObject HomeButton;
  public GameObject DropsMenu;
  public GameObject MainMenu;
  public GameObject Keyboard;
  public GameObject Gamepad;
  public GameObject Notepad;
  public GameObject Phone;
  public Transform SubtitlePanel;
  public Transform PromptParent;
  public UITexture[] EightiesPhoneIcons;
  public UISprite[] PhoneIcons;
  public string[] SelectionNames;
  public Transform[] Eggs;
  public float Speed;
  public int Selected = 1;
  public int Prompts;
  public int Secret;
  public bool ShowMissionModeDetails;
  public bool ViewingControlMenu;
  public bool CorrectingTime;
  public bool MultiMission;
  public bool ResettingDay;
  public bool BypassPhone;
  public bool EggsChecked;
  public bool AtSchool;
  public bool PressedA;
  public bool PressedB;
  public bool Quitting;
  public bool Sideways;
  public bool InEditor;
  public bool Eighties;
  public bool Home;
  public bool Show;
  public int Row = 1;
  public int Column = 2;
  public string Reason;

  private void Start()
  {
    if (SceneManager.GetActiveScene().name != "SchoolScene")
      MissionModeGlobals.MultiMission = false;
    else
      this.AtSchool = true;
    if (!MissionModeGlobals.MultiMission)
      this.MissionModeLabel.SetActive(false);
    this.MultiMission = MissionModeGlobals.MultiMission;
    StudentGlobals.SetStudentPhotographed(0, true);
    StudentGlobals.SetStudentPhotographed(1, true);
    this.transform.localPosition = new Vector3(1350f, 0.0f, 0.0f);
    this.transform.localScale = new Vector3(0.9133334f, 0.9133334f, 0.9133334f);
    this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, 0.0f);
    if (!this.Home)
      this.YouTubeChatMenu.CommandChecker.CountdownCircle.transform.parent.gameObject.SetActive(false);
    this.FavorMenu.BountyMenu.gameObject.SetActive(false);
    this.StudentInfoMenu.gameObject.SetActive(false);
    this.YouTubeChatMenu.gameObject.SetActive(false);
    this.InventoryMenu.gameObject.SetActive(false);
    this.PhotoGallery.gameObject.SetActive(false);
    this.SaveLoadMenu.gameObject.SetActive(false);
    this.ServiceMenu.gameObject.SetActive(false);
    this.NewSettings.gameObject.SetActive(false);
    this.AudioMenu.gameObject.SetActive(false);
    this.FavorMenu.gameObject.SetActive(false);
    this.IdeasMenu.gameObject.SetActive(false);
    this.Tutorials.gameObject.SetActive(false);
    this.PassTime.gameObject.SetActive(false);
    this.Schedule.gameObject.SetActive(false);
    this.TaskList.gameObject.SetActive(false);
    this.Stats.gameObject.SetActive(false);
    this.LoadingScreen.SetActive(false);
    this.ControlMenu.SetActive(false);
    this.SchemesMenu.SetActive(false);
    this.StudentInfo.SetActive(false);
    this.DropsMenu.SetActive(false);
    this.MainMenu.SetActive(true);
    this.YouTubeChatMenu.InitializeWindow.SetActive(true);
    this.YouTubeChatMenu.CommandWindow.SetActive(false);
    if (!(SceneManager.GetActiveScene().name == "SchoolScene"))
    {
      this.MissionModeIcons.SetActive(false);
      UISprite phoneIcon1 = this.PhoneIcons[5];
      phoneIcon1.color = new Color(phoneIcon1.color.r, phoneIcon1.color.g, phoneIcon1.color.b, 0.5f);
      UISprite phoneIcon2 = this.PhoneIcons[8];
      phoneIcon2.color = new Color(phoneIcon2.color.r, phoneIcon2.color.g, phoneIcon2.color.b, 0.5f);
      UISprite phoneIcon3 = this.PhoneIcons[9];
      phoneIcon3.color = new Color(phoneIcon3.color.r, phoneIcon3.color.g, phoneIcon3.color.b, 0.5f);
      UISprite phoneIcon4 = this.PhoneIcons[11];
      phoneIcon4.color = new Color(phoneIcon4.color.r, phoneIcon4.color.g, phoneIcon4.color.b, 0.5f);
      UISprite phoneIcon5 = this.PhoneIcons[13];
      phoneIcon5.color = new Color(phoneIcon5.color.r, phoneIcon5.color.g, phoneIcon5.color.b, 0.5f);
      UISprite phoneIcon6 = this.PhoneIcons[15];
      phoneIcon6.color = new Color(phoneIcon6.color.r, phoneIcon6.color.g, phoneIcon6.color.b, 0.5f);
      UISprite phoneIcon7 = this.PhoneIcons[17];
      phoneIcon7.color = new Color(phoneIcon7.color.r, phoneIcon7.color.g, phoneIcon7.color.b, 0.5f);
      UISprite phoneIcon8 = this.PhoneIcons[16];
      phoneIcon8.color = new Color(phoneIcon8.color.r, phoneIcon8.color.g, phoneIcon8.color.b, 0.5f);
      if ((Object) this.NewMissionModeWindow != (Object) null)
        this.NewMissionModeWindow.SetActive(false);
    }
    if (MissionModeGlobals.MissionMode)
    {
      UISprite phoneIcon9 = this.PhoneIcons[7];
      phoneIcon9.color = new Color(phoneIcon9.color.r, phoneIcon9.color.g, phoneIcon9.color.b, 0.5f);
      UISprite phoneIcon10 = this.PhoneIcons[9];
      phoneIcon10.color = new Color(phoneIcon10.color.r, phoneIcon10.color.g, phoneIcon10.color.b, 0.5f);
      UISprite phoneIcon11 = this.PhoneIcons[10];
      phoneIcon11.color = new Color(phoneIcon11.color.r, phoneIcon11.color.g, phoneIcon11.color.b, 1f);
    }
    this.UpdateSelection();
    this.CorrectingTime = false;
    if (GameGlobals.Eighties)
    {
      this.Eighties = true;
      for (int index = 1; index < 19; ++index)
      {
        this.EightiesPhoneIcons[index].enabled = true;
        this.PhoneIcons[index].enabled = false;
        this.EightiesPhoneIcons[index].color = this.PhoneIcons[index].color;
      }
      this.SelectionNames[5] = "Ideas";
      UISprite phoneIcon = this.PhoneIcons[17];
      phoneIcon.color = new Color(phoneIcon.color.r, phoneIcon.color.g, phoneIcon.color.b, 0.5f);
      this.Notepad.SetActive(true);
      this.Phone.SetActive(false);
      this.Wifi.gameObject.SetActive(false);
    }
    this.QuitLabel.text = "Do you wish to return to the main menu?";
    this.YesLabel.text = "Yes";
    this.HomeButton.SetActive(false);
  }

  private void Update()
  {
    this.Speed = Time.unscaledDeltaTime * 10f;
    if (this.Police.FadeOut || this.Map.Show)
      return;
    if (!this.Show)
    {
      if ((double) this.transform.localPosition.x > 1349.0)
      {
        if (this.Panel.enabled)
        {
          this.Panel.enabled = false;
          this.transform.localPosition = new Vector3(1350f, 50f, 0.0f);
          this.transform.localScale = new Vector3(0.9133334f, 0.9133334f, 0.9133334f);
          this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
      }
      else
      {
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(1350f, 50f, 0.0f), this.Speed);
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, Mathf.Lerp(this.transform.localEulerAngles.z, 0.0f, this.Speed));
      }
      if (this.CorrectingTime && (double) Time.timeScale < 0.899999976158142)
      {
        Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, this.Speed);
        if ((double) Time.timeScale > 0.899999976158142)
        {
          this.CorrectingTime = false;
          Time.timeScale = 1f;
        }
      }
      if (!Input.GetButtonDown("Start"))
        return;
      if ((Object) this.Police.StudentManager != (Object) null)
      {
        this.Police.StudentManager.Portal.GetComponent<PortalScript>().OsanaEvent.EventSubtitle.text = "";
        this.Yandere.Subtitle.Label.text = "";
      }
      if (this.Eighties)
        this.BlackenAllText();
      if (!this.Home)
      {
        if (this.Yandere.Shutter.Snapping || this.Yandere.TimeSkipping || this.Yandere.Talking || this.Yandere.Noticed || this.Yandere.InClass || this.Yandere.Struggling || this.Yandere.Won || this.Yandere.Dismembering || this.Yandere.Attacked || !this.Yandere.CanMove || this.Yandere.Chased || this.Yandere.Chasers != 0 || this.Yandere.YandereVision || (double) Time.timeScale <= 9.99999974737875E-05 || (double) this.Hint.transform.localPosition.x != 0.204300001263618 || this.Schedule.gameObject.activeInHierarchy)
          return;
        this.Yandere.StopAiming();
        this.PromptParent.localScale = Vector3.zero;
        this.Yandere.YandereVision = false;
        this.Yandere.Blur.enabled = true;
        this.Yandere.YandereTimer = 0.0f;
        this.Yandere.Mopping = false;
        this.Panel.enabled = true;
        this.Sideways = false;
        this.Show = true;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[1].text = "Exit";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.Label[5].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        UISprite phoneIcon = this.PhoneIcons[3];
        if (!this.Yandere.CanMove || this.Yandere.Dragging || this.Yandere.Carrying)
          phoneIcon.color = new Color(phoneIcon.color.r, phoneIcon.color.g, phoneIcon.color.b, 0.5f);
        else
          phoneIcon.color = new Color(phoneIcon.color.r, phoneIcon.color.g, phoneIcon.color.b, 1f);
        this.CheckIfSavePossible();
        this.UpdateSelection();
      }
      else
      {
        if (!((Object) this.HomeCamera.Destination == (Object) this.HomeCamera.Destinations[0]))
          return;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[1].text = "Exit";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.HomeYandere.CanMove = false;
        UISprite phoneIcon = this.PhoneIcons[3];
        phoneIcon.color = new Color(phoneIcon.color.r, phoneIcon.color.g, phoneIcon.color.b, 0.5f);
        this.Panel.enabled = true;
        this.Sideways = false;
        this.Show = true;
      }
    }
    else
    {
      if (!this.EggsChecked)
      {
        float num1 = 99999f;
        for (int index = 0; index < this.Eggs.Length; ++index)
        {
          if ((Object) this.Eggs[index] != (Object) null)
          {
            float num2 = Vector3.Distance(this.Yandere.transform.position, this.Eggs[index].position);
            if ((double) num2 < (double) num1)
              num1 = num2;
          }
        }
        this.Wifi.spriteName = (double) num1 >= 5.0 ? ((double) num1 >= 10.0 ? ((double) num1 >= 15.0 ? ((double) num1 >= 20.0 ? ((double) num1 >= 25.0 ? "0Bars" : "1Bars") : "2Bars") : "3Bars") : "4Bars") : "5Bars";
        this.EggsChecked = true;
      }
      if (!this.Home)
      {
        Time.timeScale = Mathf.Lerp(Time.timeScale, 0.0f, this.Speed);
        this.RPGCamera.enabled = false;
      }
      if (this.ShowMissionModeDetails)
      {
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), this.Speed);
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(0.0f, 1200f, 0.0f), this.Speed);
      }
      else if (this.Quitting)
      {
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), this.Speed);
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(0.0f, -1200f, 0.0f), this.Speed);
      }
      else if (!this.Sideways)
      {
        if (!this.NewSettings.gameObject.activeInHierarchy)
          this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(0.0f, 50f, 0.0f), this.Speed);
        else
          this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(1320f, 0.0f, 0.0f), this.Speed);
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), this.Speed);
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, Mathf.Lerp(this.transform.localEulerAngles.z, 0.0f, this.Speed));
      }
      else
      {
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1.78f, 1.78f, 1.78f), this.Speed);
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(0.0f, 35f, 0.0f), this.Speed);
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, Mathf.Lerp(this.transform.localEulerAngles.z, 90f, this.Speed));
      }
      if (this.MainMenu.activeInHierarchy && !this.Quitting)
      {
        if (this.InputManager.TappedUp)
        {
          --this.Row;
          this.UpdateSelection();
        }
        if (this.InputManager.TappedDown)
        {
          ++this.Row;
          this.UpdateSelection();
        }
        if (this.InputManager.TappedRight)
        {
          ++this.Column;
          this.UpdateSelection();
        }
        if (this.InputManager.TappedLeft)
        {
          --this.Column;
          this.UpdateSelection();
        }
        if (Input.GetKeyDown("space") && this.MultiMission)
          this.ShowMissionModeDetails = !this.ShowMissionModeDetails;
        if (this.ShowMissionModeDetails && Input.GetButtonDown("B"))
          this.ShowMissionModeDetails = false;
        for (int index = 1; index < this.PhoneIcons.Length; ++index)
        {
          if ((Object) this.PhoneIcons[index] != (Object) null)
          {
            Vector3 b = this.Selected != index ? new Vector3(1f, 1f, 1f) : new Vector3(1.5f, 1.5f, 1.5f);
            this.PhoneIcons[index].transform.localScale = Vector3.Lerp(this.PhoneIcons[index].transform.localScale, b, this.Speed);
          }
        }
        if (!this.ShowMissionModeDetails)
        {
          if (Input.GetButtonDown("A"))
          {
            this.PressedA = true;
            if (this.Eighties)
              this.BlackenAllText();
            if ((double) this.PhoneIcons[this.Selected].color.a == 1.0)
            {
              if (this.Selected == 1)
              {
                this.MainMenu.SetActive(false);
                this.LoadingScreen.SetActive(true);
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.Label[4].text = "Choose";
                this.PromptBar.Label[5].text = "Choose";
                this.PromptBar.UpdateButtons();
                this.StartCoroutine(this.PhotoGallery.GetPhotos());
              }
              else if (this.Selected == 2)
              {
                this.TaskList.gameObject.SetActive(true);
                this.MainMenu.SetActive(false);
                this.Sideways = true;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.Label[4].text = "Choose";
                this.PromptBar.UpdateButtons();
                this.TaskList.UpdateTaskList();
                this.StartCoroutine(this.TaskList.UpdateTaskInfo());
              }
              else if (this.Selected == 3)
              {
                if ((double) this.PhoneIcons[3].color.a == 1.0 && this.Yandere.CanMove && !this.Yandere.Dragging)
                {
                  for (int index = 0; index < this.Yandere.ArmedAnims.Length; ++index)
                    this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[index]].weight = 0.0f;
                  this.MainMenu.SetActive(false);
                  this.PromptBar.ClearButtons();
                  this.PromptBar.Label[0].text = "Begin";
                  this.PromptBar.Label[1].text = "Back";
                  this.PromptBar.Label[4].text = "Adjust";
                  this.PromptBar.Label[5].text = "Choose";
                  this.PromptBar.UpdateButtons();
                  this.PassTime.gameObject.SetActive(true);
                  this.PassTime.GetCurrentTime();
                }
              }
              else if (this.Selected == 4)
              {
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Exit";
                this.PromptBar.UpdateButtons();
                this.Stats.gameObject.SetActive(true);
                this.Stats.UpdateStats();
                this.MainMenu.SetActive(false);
                this.Sideways = true;
              }
              else if (this.Selected == 5)
              {
                if ((double) this.PhoneIcons[5].color.a == 1.0)
                {
                  if (!this.Eighties)
                  {
                    this.PromptBar.ClearButtons();
                    this.PromptBar.Label[0].text = "Accept";
                    this.PromptBar.Label[1].text = "Exit";
                    this.PromptBar.Label[5].text = "Choose";
                    this.PromptBar.UpdateButtons();
                    this.FavorMenu.gameObject.SetActive(true);
                    this.FavorMenu.gameObject.GetComponent<AudioSource>().Play();
                    this.MainMenu.SetActive(false);
                    this.Sideways = true;
                  }
                  else
                  {
                    this.PromptBar.ClearButtons();
                    this.PromptBar.Label[0].text = "Confirm";
                    this.PromptBar.Label[1].text = "Back";
                    this.PromptBar.Label[4].text = "Choose";
                    this.PromptBar.UpdateButtons();
                    this.PromptBar.Show = true;
                    this.IdeasMenu.gameObject.SetActive(true);
                    this.MainMenu.SetActive(false);
                  }
                }
              }
              else if (this.Selected == 6)
              {
                this.StudentInfoMenu.gameObject.SetActive(true);
                this.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
                this.MainMenu.SetActive(false);
                this.Sideways = true;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "View Info";
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
              }
              else if (this.Selected == 7)
              {
                this.SaveLoadMenu.gameObject.SetActive(true);
                this.SaveLoadMenu.Header.text = "Load Data";
                this.SaveLoadMenu.Loading = true;
                this.SaveLoadMenu.Saving = false;
                this.SaveLoadMenu.Column = 1;
                this.SaveLoadMenu.Row = 1;
                this.SaveLoadMenu.UpdateHighlight();
                this.StartCoroutine(this.SaveLoadMenu.GetThumbnails());
                this.MainMenu.SetActive(false);
                this.Sideways = true;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "Choose";
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.Label[4].text = "Change";
                this.PromptBar.Label[5].text = "Change";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
              }
              else if (this.Selected == 8)
              {
                this.NewSettings.gameObject.SetActive(true);
                if ((Object) this.Yandere.Blur != (Object) null)
                  this.Yandere.Blur.enabled = false;
                this.NewSettings.NewTitleScreen.Speed = 3f;
                this.NewSettings.enabled = true;
                this.NewSettings.Cursor.alpha = 0.0f;
                this.NewSettings.Selection = 1;
                this.NewSettings.UpdateLabels();
                this.MainMenu.SetActive(false);
              }
              else if (this.Selected == 9)
              {
                this.SaveLoadMenu.gameObject.SetActive(true);
                this.SaveLoadMenu.Header.text = "Save Data";
                this.SaveLoadMenu.Loading = false;
                this.SaveLoadMenu.Saving = true;
                this.SaveLoadMenu.Column = 1;
                this.SaveLoadMenu.Row = 1;
                this.SaveLoadMenu.UpdateHighlight();
                this.StartCoroutine(this.SaveLoadMenu.GetThumbnails());
                this.MainMenu.SetActive(false);
                this.Sideways = true;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "Choose";
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.Label[2].text = "Delete";
                this.PromptBar.Label[4].text = "Change";
                this.PromptBar.Label[5].text = "Change";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
              }
              else if (this.Selected == 10)
              {
                if (!this.Yandere.StudentManager.MissionMode)
                {
                  this.AudioMenu.gameObject.SetActive(true);
                  this.AudioMenu.UpdateText();
                  this.MainMenu.SetActive(false);
                  this.PromptBar.ClearButtons();
                  this.PromptBar.Label[0].text = "Play";
                  this.PromptBar.Label[1].text = "Back";
                  this.PromptBar.Label[4].text = "Choose";
                  this.PromptBar.UpdateButtons();
                  this.PromptBar.Show = true;
                }
                else
                {
                  this.PhoneIcons[this.Selected].transform.localScale = new Vector3(1f, 1f, 1f);
                  this.MissionMode.ChangeMusic();
                }
              }
              else if (this.Selected == 11)
              {
                this.Tutorials.gameObject.SetActive(true);
                this.MainMenu.SetActive(false);
                this.Sideways = true;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.Label[4].text = "Choose";
                this.PromptBar.UpdateButtons();
                this.Tutorials.UpdateTaskList();
                this.StartCoroutine(this.Tutorials.UpdateTaskInfo());
              }
              else if (this.Selected == 12)
              {
                if (this.InputDevice.Type == InputDeviceType.Gamepad)
                {
                  this.Keyboard.SetActive(false);
                  this.Gamepad.SetActive(true);
                }
                else
                {
                  this.Keyboard.SetActive(true);
                  this.Gamepad.SetActive(false);
                }
                this.ControlMenu.SetActive(false);
                this.ControlMenu.SetActive(true);
                this.MainMenu.SetActive(false);
                this.ViewingControlMenu = true;
                this.Sideways = true;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
              }
              else if (this.Selected == 13)
              {
                this.InventoryMenu.UpdateLabels();
                this.InventoryMenu.gameObject.SetActive(true);
                this.MainMenu.SetActive(false);
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
              }
              else if (this.Selected == 14)
              {
                this.QuitLabel.text = "Do you wish to return to the main menu?";
                this.YesLabel.text = "Yes";
                this.PromptBar.ClearButtons();
                this.PromptBar.Show = false;
                this.ResettingDay = false;
                this.Quitting = true;
                this.HomeButton.SetActive(false);
              }
              else if (this.Selected == 15)
              {
                this.QuitLabel.text = "Do you wish to restart the day?";
                if (this.Yandere.StudentManager.MissionMode)
                {
                  this.YesLabel.text = "Yes";
                  this.HomeButton.SetActive(false);
                }
                else
                {
                  this.YesLabel.text = "Yes, at school";
                  this.HomeButton.SetActive(true);
                }
                this.PromptBar.ClearButtons();
                this.PromptBar.Show = false;
                this.ResettingDay = true;
                this.Quitting = true;
              }
              else if (this.Selected == 16)
              {
                this.YouTubeChatMenu.gameObject.SetActive(true);
                this.MainMenu.SetActive(false);
                this.Sideways = true;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "Confirm";
                this.PromptBar.Label[1].text = "Back";
                if (!this.YouTubeChatMenu.InitializeWindow.activeInHierarchy)
                {
                  this.PromptBar.Label[0].text = "Toggle";
                  this.PromptBar.Label[2].text = "Connect";
                  this.PromptBar.Label[4].text = "Scroll";
                  Cursor.lockState = CursorLockMode.None;
                  Cursor.visible = true;
                }
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
              }
              else if (this.Selected == 17)
                this.ShowScheduleScreen();
            }
          }
          else if (!this.PressedB)
          {
            if (Input.GetButtonDown("Start") || Input.GetButtonDown("B"))
              this.ExitPhone();
          }
          else if (Input.GetButtonUp("B"))
            this.PressedB = false;
        }
      }
      if (!this.PressedA)
      {
        if (this.PassTime.gameObject.activeInHierarchy)
        {
          if (Input.GetButtonDown("A"))
          {
            if ((Object) this.Yandere.PickUp != (Object) null)
              this.Yandere.PickUp.Drop();
            this.Yandere.Unequip();
            this.Yandere.Blur.enabled = false;
            this.RPGCamera.enabled = true;
            this.PassTime.gameObject.SetActive(false);
            this.MainMenu.SetActive(true);
            this.Show = false;
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[1].text = "Stop";
            this.PromptBar.UpdateButtons();
            this.Clock.TargetTime = (float) this.PassTime.TargetTime;
            this.Clock.StopTime = false;
            this.Clock.TimeSkip = true;
            Time.timeScale = 1f;
            this.Yandere.ResetYandereEffects();
            this.Yandere.Phone.SetActive(true);
          }
          else if (Input.GetButtonDown("B"))
          {
            this.MainMenu.SetActive(true);
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Accept";
            this.PromptBar.Label[1].text = "Exit";
            this.PromptBar.Label[4].text = "Choose";
            this.PromptBar.Label[5].text = "Choose";
            this.PromptBar.UpdateButtons();
            this.PassTime.gameObject.SetActive(false);
          }
        }
        if (this.ViewingControlMenu)
        {
          if (this.InputDevice.Type == InputDeviceType.Gamepad)
          {
            this.Keyboard.SetActive(false);
            this.Gamepad.SetActive(true);
          }
          else
          {
            this.Keyboard.SetActive(true);
            this.Gamepad.SetActive(false);
          }
          if (Input.GetButtonDown("B"))
          {
            this.MainMenu.SetActive(true);
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Accept";
            this.PromptBar.Label[1].text = "Exit";
            this.PromptBar.Label[4].text = "Choose";
            this.PromptBar.Label[5].text = "Choose";
            this.PromptBar.UpdateButtons();
            this.ControlMenu.SetActive(false);
            this.ViewingControlMenu = false;
            this.Sideways = false;
          }
        }
        if (this.Quitting)
        {
          if (Input.GetButtonDown("A"))
          {
            if (this.ResettingDay)
            {
              SceneManager.LoadScene("LoadingScene");
            }
            else
            {
              Debug.Log((object) ("We are now returning to the title screen. Currently, GameGlobals.Profile is: " + GameGlobals.Profile.ToString()));
              GameGlobals.AlphabetMode = false;
              SceneManager.LoadScene("NewTitleScene");
            }
          }
          else if (Input.GetButtonDown("X"))
          {
            if (this.ResettingDay && !this.Yandere.StudentManager.MissionMode)
            {
              Debug.Log((object) ("Apparently, StudentGlobals.StudentSlave is: " + StudentGlobals.StudentSlave.ToString()));
              if (StudentGlobals.StudentSlave > 0)
              {
                StudentGlobals.SetStudentKidnapped(StudentGlobals.StudentSlave, true);
                StudentGlobals.PrisonerChosen = 0;
                StudentGlobals.StudentSlave = 0;
              }
              SceneManager.LoadScene("HomeScene");
            }
          }
          else if (Input.GetButtonDown("B"))
          {
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Accept";
            this.PromptBar.Label[1].text = "Exit";
            this.PromptBar.Label[4].text = "Choose";
            this.PromptBar.Label[5].text = "Choose";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.Quitting = false;
            if (this.BypassPhone)
            {
              this.transform.localPosition = new Vector3(1350f, 0.0f, 0.0f);
              this.ExitPhone();
            }
          }
        }
      }
      if (this.Eighties)
      {
        for (int index = 1; index < this.PhoneIcons.Length; ++index)
          this.EightiesPhoneIcons[index].color = this.PhoneIcons[index].color;
      }
      if (!Input.GetButtonUp("A"))
        return;
      this.PressedA = false;
    }
  }

  public void ShowScheduleScreen()
  {
    this.Schedule.gameObject.SetActive(true);
    this.Schedule.Start();
    this.MainMenu.SetActive(false);
    this.Panel.enabled = true;
    this.Sideways = true;
    this.Show = true;
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[1].text = "Back";
    this.PromptBar.Label[2].text = "View Schemes";
    this.PromptBar.Label[3].text = this.Hint.enabled ? "Disable Hints" : "Enable Hints";
    this.PromptBar.Label[6].text = "Change Day";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
  }

  public void JumpToQuit()
  {
    if (this.Police.FadeOut || this.Clock.TimeSkip || this.Yandere.Noticed)
      return;
    this.transform.localPosition = new Vector3(0.0f, -1200f, 0.0f);
    this.Yandere.YandereVision = false;
    if (!this.Yandere.Talking && !this.Yandere.Dismembering)
    {
      this.RPGCamera.enabled = false;
      this.Yandere.StopAiming();
    }
    this.QuitLabel.text = "Do you wish to return to the main menu?";
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Yandere.Blur.enabled = true;
    this.ResettingDay = false;
    this.Panel.enabled = true;
    this.BypassPhone = true;
    this.Quitting = true;
    this.Show = true;
  }

  public void ExitPhone()
  {
    if (!this.Home)
    {
      this.PromptParent.localScale = new Vector3(1f, 1f, 1f);
      this.Yandere.Blur.enabled = false;
      this.CorrectingTime = true;
      if (!this.Yandere.Talking && !this.Yandere.Dismembering)
        this.RPGCamera.enabled = true;
      if (this.Yandere.Laughing)
        this.Yandere.GetComponent<AudioSource>().volume = 1f;
    }
    else
      this.HomeYandere.CanMove = true;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.BypassPhone = false;
    this.EggsChecked = false;
    this.PressedA = false;
    this.Show = false;
  }

  private void UpdateSelection()
  {
    if (this.Row < 0)
      this.Row = 5;
    else if (this.Row > 5)
      this.Row = 0;
    if (this.Column < 1)
      this.Column = 3;
    else if (this.Column > 3)
      this.Column = 1;
    this.Selected = this.Row * 3 + this.Column;
    this.SelectionLabel.text = this.SelectionNames[this.Selected];
    if (!this.AtSchool || this.Selected != 9 || (double) this.PhoneIcons[9].color.a != 0.5)
      return;
    this.SelectionLabel.text = this.Reason;
  }

  private void CheckIfSavePossible()
  {
    this.PhoneIcons[9].color = new Color(1f, 1f, 1f, 1f);
    if (!this.AtSchool)
      return;
    for (int index = 1; index < this.Yandere.StudentManager.Students.Length; ++index)
    {
      if ((Object) this.Yandere.StudentManager.Students[index] != (Object) null && this.Yandere.StudentManager.Students[index].Alive)
      {
        if (this.Yandere.StudentManager.Students[index].Investigating || this.Yandere.StudentManager.Students[index].Alarmed || this.Yandere.StudentManager.Students[index].Fleeing || this.Yandere.StudentManager.Students[index].Ragdoll.Zs.activeInHierarchy && this.Yandere.StudentManager.Police.EndOfDay.TranqCase.VictimID != index || this.Yandere.StudentManager.Students[index].Wet)
        {
          this.PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
          this.Reason = "You cannot save the game while a student is investigating, alarmed, fleeing, wet, or asleep on the ground.";
        }
        if ((Object) this.Yandere.PickUp != (Object) null)
        {
          this.PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
          this.Reason = "You cannot save the game while you are holding that object.";
        }
        if (this.Police.BloodyClothing > 0)
        {
          this.PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
          this.Reason = "You cannot save the game while a bloody uniform is present at school.";
        }
      }
    }
  }

  public void UpdateSubtitleSize()
  {
    switch (OptionGlobals.SubtitleSize)
    {
      case 1:
        this.SubtitlePanel.localPosition = new Vector3(0.0f, 1f, 0.0f);
        this.SubtitlePanel.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        break;
      case 2:
        this.SubtitlePanel.localPosition = new Vector3(0.0f, 0.0f, 1f);
        this.SubtitlePanel.localScale = new Vector3(1f / 1000f, 1f / 1000f, 1f / 1000f);
        break;
      case 3:
        this.SubtitlePanel.localPosition = new Vector3(0.0f, 0.1133333f, 1f);
        this.SubtitlePanel.localScale = new Vector3(0.00133333f, 0.00133333f, 0.00133333f);
        break;
    }
  }

  public void BlackenAllText()
  {
    foreach (UILabel componentsInChild in this.GetComponentsInChildren<UILabel>())
    {
      componentsInChild.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      componentsInChild.effectStyle = UILabel.Effect.None;
    }
  }
}
