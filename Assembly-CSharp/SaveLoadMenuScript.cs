// Decompiled with JetBrains decompiler
// Type: SaveLoadMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadMenuScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public GameObject ConfirmWindow;
  public GameObject WarningWindow;
  public ClockScript Clock;
  public Texture DefaultThumbnail;
  public UILabel AreYouSureLabel;
  public UILabel Header;
  public UITexture[] Thumbnails;
  public UILabel[] DataLabels;
  public Transform Highlight;
  public Camera UICamera;
  public bool GrabScreenshot;
  public bool Loading;
  public bool Saving;
  public int Profile;
  public int Row = 1;
  public int Column = 1;
  public int Selected = 1;

  public void Start()
  {
    if (GameGlobals.Profile == 0)
      GameGlobals.Profile = 1;
    this.Profile = GameGlobals.Profile;
    this.WarningWindow.SetActive(true);
    this.ConfirmWindow.SetActive(false);
    this.StartCoroutine(this.GetThumbnails());
  }

  public void Update()
  {
    if (!this.ConfirmWindow.activeInHierarchy)
    {
      if (this.InputManager.TappedUp)
      {
        --this.Row;
        this.UpdateHighlight();
      }
      else if (this.InputManager.TappedDown)
      {
        ++this.Row;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedLeft)
      {
        --this.Column;
        this.UpdateHighlight();
      }
      else if (this.InputManager.TappedRight)
      {
        ++this.Column;
        this.UpdateHighlight();
      }
    }
    if (this.GrabScreenshot)
    {
      if (GameGlobals.Profile == 0)
      {
        Debug.Log((object) "Grabbin' a screenshot!");
        GameGlobals.Profile = 1;
        this.Profile = 1;
      }
      this.PauseScreen.Yandere.Blur.enabled = true;
      this.UICamera.enabled = true;
      this.StudentManager.Save();
      this.StartCoroutine(this.GetThumbnails());
      switch (DateGlobals.Weekday)
      {
        case DayOfWeek.Monday:
          PlayerPrefs.SetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday", 1);
          break;
        case DayOfWeek.Tuesday:
          PlayerPrefs.SetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday", 2);
          break;
        case DayOfWeek.Wednesday:
          PlayerPrefs.SetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday", 3);
          break;
        case DayOfWeek.Thursday:
          PlayerPrefs.SetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday", 4);
          break;
        case DayOfWeek.Friday:
          PlayerPrefs.SetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday", 5);
          break;
      }
      this.GrabScreenshot = false;
    }
    if (this.WarningWindow.activeInHierarchy)
    {
      if (Input.GetButtonDown("A"))
      {
        this.WarningWindow.SetActive(false);
      }
      else
      {
        if (!Input.GetButtonDown("B"))
          return;
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.PressedB = true;
        this.gameObject.SetActive(false);
        this.PauseScreen.PromptBar.ClearButtons();
        this.PauseScreen.PromptBar.Label[0].text = "Accept";
        this.PauseScreen.PromptBar.Label[1].text = "Exit";
        this.PauseScreen.PromptBar.Label[4].text = "Choose";
        this.PauseScreen.PromptBar.UpdateButtons();
        this.PauseScreen.PromptBar.Show = true;
      }
    }
    else
    {
      if (Input.GetButtonDown("A"))
      {
        if (this.Loading)
        {
          if (this.DataLabels[this.Selected].text != "No Data")
          {
            if (!this.ConfirmWindow.activeInHierarchy)
            {
              this.AreYouSureLabel.text = "Are you sure you'd like to load?";
              this.ConfirmWindow.SetActive(true);
            }
            else if (this.DataLabels[this.Selected].text != "No Data")
            {
              PlayerPrefs.SetInt("LoadingSave", 1);
              PlayerPrefs.SetInt("SaveSlot", this.Selected);
              YanSave.LoadPrefs("Profile_" + GameGlobals.Profile.ToString() + "_Slot_" + this.Selected.ToString());
              SceneManager.LoadScene("LoadingScene");
            }
          }
        }
        else if (this.Saving)
        {
          if (!this.ConfirmWindow.activeInHierarchy)
          {
            this.AreYouSureLabel.text = "Are you sure you'd like to save?";
            this.ConfirmWindow.SetActive(true);
          }
          else
          {
            this.ConfirmWindow.SetActive(false);
            PlayerPrefs.SetInt("SaveSlot", this.Selected);
            GameGlobals.MostRecentSlot = this.Selected;
            PlayerPrefs.SetString("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_DateTime", DateTime.Now.ToString());
            ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/SaveData/Profile_" + this.Profile.ToString() + "/Slot_" + this.Selected.ToString() + "_Thumbnail.png");
            this.PauseScreen.Yandere.Blur.enabled = false;
            this.UICamera.enabled = false;
            this.GrabScreenshot = true;
          }
        }
      }
      if (Input.GetButtonDown("X"))
      {
        if (this.Loading)
        {
          if (this.DataLabels[this.Selected].text != "No Data")
          {
            PlayerPrefs.SetInt("SaveSlot", this.Selected);
            this.StudentManager.Load();
            Physics.SyncTransforms();
            if (PlayerPrefs.GetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday") == 1)
              DateGlobals.Weekday = DayOfWeek.Monday;
            else if (PlayerPrefs.GetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday") == 2)
              DateGlobals.Weekday = DayOfWeek.Tuesday;
            else if (PlayerPrefs.GetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday") == 3)
              DateGlobals.Weekday = DayOfWeek.Wednesday;
            else if (PlayerPrefs.GetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday") == 4)
              DateGlobals.Weekday = DayOfWeek.Tuesday;
            else if (PlayerPrefs.GetInt("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_Weekday") == 5)
              DateGlobals.Weekday = DayOfWeek.Wednesday;
            this.Clock.DayLabel.text = this.Clock.GetWeekdayText(DateGlobals.Weekday);
            this.PauseScreen.MainMenu.SetActive(true);
            this.PauseScreen.Sideways = false;
            this.PauseScreen.PressedB = true;
            this.gameObject.SetActive(false);
            this.PauseScreen.ExitPhone();
          }
        }
        else if (this.Saving)
        {
          if (PlayerPrefs.GetString("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_DateTime") != "")
          {
            File.Delete(Application.streamingAssetsPath + "/SaveData/Profile_" + this.Profile.ToString() + "/Slot_" + this.Selected.ToString() + "_Thumbnail.png");
            PlayerPrefs.SetString("Profile_" + this.Profile.ToString() + "_Slot_" + this.Selected.ToString() + "_DateTime", "");
            this.Thumbnails[this.Selected].mainTexture = this.DefaultThumbnail;
            this.DataLabels[this.Selected].text = "No Data";
          }
        }
      }
      if (!Input.GetButtonDown("B"))
        return;
      if (this.ConfirmWindow.activeInHierarchy)
      {
        this.ConfirmWindow.SetActive(false);
      }
      else
      {
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.PressedB = true;
        this.gameObject.SetActive(false);
        this.PauseScreen.PromptBar.ClearButtons();
        this.PauseScreen.PromptBar.Label[0].text = "Accept";
        this.PauseScreen.PromptBar.Label[1].text = "Exit";
        this.PauseScreen.PromptBar.Label[4].text = "Choose";
        this.PauseScreen.PromptBar.UpdateButtons();
        this.PauseScreen.PromptBar.Show = true;
      }
    }
  }

  public IEnumerator GetThumbnails()
  {
    for (int ID = 1; ID < 11; ++ID)
    {
      if (PlayerPrefs.GetString("Profile_" + this.Profile.ToString() + "_Slot_" + ID.ToString() + "_DateTime") != "")
      {
        this.DataLabels[ID].text = PlayerPrefs.GetString("Profile_" + this.Profile.ToString() + "_Slot_" + ID.ToString() + "_DateTime");
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/SaveData/Profile_" + this.Profile.ToString() + "/Slot_" + ID.ToString() + "_Thumbnail.png");
        yield return (object) www;
        if (www.error == null)
          this.Thumbnails[ID].mainTexture = (Texture) www.texture;
        else
          Debug.Log((object) "Could not retrieve the thumbnail. Maybe it was deleted from Streaming Assets?");
        www = (WWW) null;
      }
      else
        this.DataLabels[ID].text = "No Data";
    }
  }

  public void UpdateHighlight()
  {
    if (this.Row < 1)
      this.Row = 2;
    else if (this.Row > 2)
      this.Row = 1;
    if (this.Column < 1)
      this.Column = 5;
    else if (this.Column > 5)
      this.Column = 1;
    this.Highlight.localPosition = new Vector3((float) (170 * this.Column - 510), (float) (313 - 226 * this.Row), this.Highlight.localPosition.z);
    this.Selected = this.Column + (this.Row - 1) * 5;
  }
}
