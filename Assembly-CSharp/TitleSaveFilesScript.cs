// Decompiled with JetBrains decompiler
// Type: TitleSaveFilesScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TitleSaveFilesScript : MonoBehaviour
{
  public NewTitleScreenScript NewTitleScreen;
  public InputManagerScript InputManager;
  public TitleSaveDataScript[] SaveDatas;
  public UILabel CorruptSaveLabel;
  public UILabel NewSaveLabel;
  public GameObject ConfirmationWindow;
  public GameObject ErrorWindow;
  public PromptBarScript PromptBar;
  public TitleMenuScript Menu;
  public Transform Highlight;
  public bool Started;
  public bool Show;
  public int EightiesPrefix;
  public int ID = 1;

  private void Update()
  {
    if ((double) this.NewTitleScreen.Speed <= 3.0 || this.NewTitleScreen.FadeOut)
      return;
    if (this.Started)
    {
      this.ErrorWindow.SetActive(true);
      if (!this.Started)
      {
        this.CorruptSaveLabel.gameObject.SetActive(true);
        this.NewSaveLabel.gameObject.SetActive(false);
      }
      this.Started = false;
    }
    if (!this.ConfirmationWindow.activeInHierarchy)
    {
      if (this.InputManager.TappedDown)
      {
        ++this.ID;
        if (this.ID > 3)
          this.ID = 1;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedUp)
      {
        --this.ID;
        if (this.ID < 1)
          this.ID = 3;
        this.UpdateHighlight();
      }
    }
    if (!this.ErrorWindow.activeInHierarchy)
    {
      if (!this.ConfirmationWindow.activeInHierarchy)
      {
        if (!this.PromptBar.Show)
        {
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Make Selection";
          this.PromptBar.Label[1].text = "Go Back";
          this.PromptBar.Label[4].text = "Change Selection";
          this.UpdateHighlight();
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
        }
        if (Input.GetButtonDown("A") || this.PromptBar.Label[3].text != "" && Input.GetButtonDown("Y"))
        {
          if (PlayerPrefs.GetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString()) == 0)
          {
            this.Started = true;
            bool debug = GameGlobals.Debug;
            GameGlobals.Profile = this.EightiesPrefix + this.ID;
            Globals.DeleteAll();
            if (GameGlobals.Eighties)
            {
              for (int studentID = 1; studentID < 101; ++studentID)
                StudentGlobals.SetStudentPhotographed(studentID, true);
            }
            GameGlobals.Profile = this.EightiesPrefix + this.ID;
            GameGlobals.Debug = debug;
            this.NewTitleScreen.Darkness.color = new Color(1f, 1f, 1f, 0.0f);
            this.Started = false;
          }
          else
          {
            Debug.Log((object) ("The game believed that Profile " + (this.EightiesPrefix + this.ID).ToString() + " already existed, so that profile is now being loaded."));
            GameGlobals.Profile = this.EightiesPrefix + this.ID;
            GameGlobals.Eighties = this.NewTitleScreen.Eighties;
          }
          this.NewTitleScreen.FadeOut = true;
          if (!Input.GetButtonDown("Y"))
            return;
          if (!this.NewTitleScreen.Eighties)
            this.NewTitleScreen.QuickStart = true;
          else
            this.NewTitleScreen.WeekSelect = true;
        }
        else if (Input.GetButtonDown("X"))
        {
          if (PlayerPrefs.GetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString()) <= 0)
            return;
          this.ConfirmationWindow.SetActive(true);
        }
        else
        {
          if (!Input.GetButtonDown("B"))
            return;
          this.NewTitleScreen.Speed = 0.0f;
          this.NewTitleScreen.Phase = 2;
          this.PromptBar.Show = false;
          this.enabled = false;
        }
      }
      else
      {
        this.PromptBar.Show = false;
        if (Input.GetButtonDown("A"))
        {
          PlayerPrefs.SetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString(), 0);
          this.ConfirmationWindow.SetActive(false);
          this.SaveDatas[this.ID].Start();
        }
        else
        {
          if (!Input.GetButtonDown("B"))
            return;
          this.ConfirmationWindow.SetActive(false);
        }
      }
    }
    else
    {
      if (!Input.anyKeyDown)
        return;
      PlayerPrefs.DeleteAll();
      Debug.Log((object) "All player prefs deleted...");
      Application.Quit();
    }
  }

  private void UpdateHighlight()
  {
    this.Highlight.localPosition = new Vector3(0.0f, (float) (700.0 - 350.0 * (double) this.ID), 0.0f);
    this.PromptBar.Label[2].text = "";
    this.PromptBar.Label[3].text = "";
    if (PlayerPrefs.GetInt("ProfileCreated_" + (this.EightiesPrefix + this.ID).ToString()) > 0)
    {
      this.PromptBar.Label[2].text = "Delete";
      this.PromptBar.UpdateButtons();
    }
    else if (!this.NewTitleScreen.Eighties)
    {
      if (GameGlobals.Debug)
        this.PromptBar.Label[3].text = "Quick Start";
    }
    else
      this.PromptBar.Label[3].text = "Debug";
    this.PromptBar.UpdateButtons();
  }

  public void UpdateOutlines()
  {
    foreach (UILabel componentsInChild in this.GetComponentsInChildren<UILabel>())
      componentsInChild.effectColor = new Color(0.0f, 0.0f, 0.0f);
  }
}
