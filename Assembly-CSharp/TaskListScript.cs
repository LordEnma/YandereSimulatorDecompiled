// Decompiled with JetBrains decompiler
// Type: TaskListScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class TaskListScript : MonoBehaviour
{
  public TutorialWindowScript TutorialWindow;
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public TaskWindowScript TaskWindow;
  public JsonScript JSON;
  public GameObject MainMenu;
  public UITexture StudentIcon;
  public UITexture TaskIcon;
  public UILabel TaskDesc;
  public Texture QuestionMark;
  public Transform Highlight;
  public Texture Silhouette;
  public UILabel[] TaskNameLabels;
  public UISprite[] Checkmarks;
  public Texture[] TutorialTextures;
  public string[] TutorialDescs;
  public string[] TutorialNames;
  public float HeldDown;
  public float HeldUp;
  public int ListPosition;
  public int Limit = 84;
  public int ID = 1;
  public bool Tutorials;

  private void Start()
  {
    if (!MissionModeGlobals.MissionMode)
      return;
    this.TaskDesc.color = new Color(1f, 1f, 1f, 1f);
  }

  private void Update()
  {
    if (this.InputManager.DPadUp || this.InputManager.StickUp || Input.GetKey("w") || Input.GetKey("up"))
    {
      Debug.Log((object) "yes, it's up...");
      this.HeldUp += Time.unscaledDeltaTime;
    }
    else
      this.HeldUp = 0.0f;
    if (this.InputManager.DPadDown || this.InputManager.StickDown || Input.GetKey("s") || Input.GetKey("down"))
      this.HeldDown += Time.unscaledDeltaTime;
    else
      this.HeldDown = 0.0f;
    if (this.InputManager.TappedUp || (double) this.HeldUp > 0.5)
    {
      if ((double) this.HeldUp > 0.5)
        this.HeldUp = 0.45f;
      if (this.ID == 1)
      {
        --this.ListPosition;
        if (this.ListPosition < 0)
        {
          this.ListPosition = this.Limit - 16;
          this.ID = 16;
        }
      }
      else
        --this.ID;
      this.UpdateTaskList();
      this.StartCoroutine(this.UpdateTaskInfo());
    }
    if (this.InputManager.TappedDown || (double) this.HeldDown > 0.5)
    {
      if ((double) this.HeldDown > 0.5)
        this.HeldDown = 0.45f;
      if (this.ID == 16)
      {
        ++this.ListPosition;
        if (this.ID + this.ListPosition > this.Limit)
        {
          this.ListPosition = 0;
          this.ID = 1;
        }
      }
      else
        ++this.ID;
      this.UpdateTaskList();
      this.StartCoroutine(this.UpdateTaskInfo());
    }
    if (this.Tutorials)
    {
      if (this.TutorialWindow.Hide || this.TutorialWindow.Show)
        return;
      if (Input.GetButtonDown("A"))
      {
        OptionGlobals.TutorialsOff = false;
        this.TutorialWindow.ForceID = this.ListPosition + this.ID;
        this.TutorialWindow.ShowTutorial();
        this.TutorialWindow.enabled = true;
        this.TutorialWindow.SummonWindow();
      }
      else
      {
        if (!Input.GetButtonDown("B"))
          return;
        this.Exit();
      }
    }
    else
    {
      if (!Input.GetButtonDown("B"))
        return;
      this.Exit();
    }
  }

  public void UpdateTaskList()
  {
    if (!this.TaskWindow.TaskManager.Initialized)
      this.TaskWindow.TaskManager.Start();
    if (this.Tutorials)
    {
      for (int index = 1; index < this.TaskNameLabels.Length; ++index)
        this.TaskNameLabels[index].text = this.TutorialNames[index + this.ListPosition];
    }
    else
    {
      for (int index = 1; index < this.TaskNameLabels.Length; ++index)
      {
        this.TaskNameLabels[index].text = this.TaskWindow.TaskManager.TaskStatus[index + this.ListPosition] != 0 ? this.JSON.Students[index + this.ListPosition].Name + "'s Task" : "Undiscovered Task #" + (index + this.ListPosition).ToString();
        this.Checkmarks[index].enabled = this.TaskWindow.TaskManager.TaskStatus[index + this.ListPosition] == 3;
      }
    }
  }

  public IEnumerator UpdateTaskInfo()
  {
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (200.0 - 25.0 * (double) this.ID), this.Highlight.localPosition.z);
    if (this.Tutorials)
    {
      this.TaskIcon.mainTexture = this.TutorialTextures[this.ID + this.ListPosition];
      this.TaskDesc.text = "This tutorial will teach you about the topic of ''" + this.TutorialNames[this.ID + this.ListPosition] + "''.";
    }
    else
    {
      string str = "";
      if (GameGlobals.Eighties)
        str = "1989";
      if (this.TaskWindow.TaskManager.TaskStatus[this.ID + this.ListPosition] == 0)
      {
        this.StudentIcon.mainTexture = this.Silhouette;
        this.TaskIcon.mainTexture = this.QuestionMark;
        this.TaskDesc.text = "This task has not been discovered yet.";
      }
      else
      {
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + str + "/Student_" + (this.ID + this.ListPosition).ToString() + ".png");
        yield return (object) www;
        this.StudentIcon.mainTexture = (Texture) www.texture;
        this.TaskWindow.AltGenericCheck(this.ID + this.ListPosition);
        if (this.TaskWindow.Generic)
        {
          this.TaskIcon.mainTexture = this.TaskWindow.Icons[0];
          this.TaskDesc.text = this.TaskWindow.Descriptions[0];
        }
        else
        {
          this.TaskIcon.mainTexture = this.TaskWindow.Icons[this.ID + this.ListPosition];
          this.TaskDesc.text = this.TaskWindow.Descriptions[this.ID + this.ListPosition];
        }
        www = (WWW) null;
      }
    }
  }

  public void Exit()
  {
    this.PauseScreen.PromptBar.ClearButtons();
    this.PauseScreen.PromptBar.Label[0].text = "Accept";
    this.PauseScreen.PromptBar.Label[1].text = "Back";
    this.PauseScreen.PromptBar.Label[4].text = "Choose";
    this.PauseScreen.PromptBar.Label[5].text = "Choose";
    this.PauseScreen.PromptBar.UpdateButtons();
    this.PauseScreen.Sideways = false;
    this.PauseScreen.PressedB = true;
    this.MainMenu.SetActive(true);
    this.gameObject.SetActive(false);
  }
}
