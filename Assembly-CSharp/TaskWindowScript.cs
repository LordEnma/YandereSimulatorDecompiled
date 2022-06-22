// Decompiled with JetBrains decompiler
// Type: TaskWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TaskWindowScript : MonoBehaviour
{
  public CheckOutBookScript HomeworkAssignment;
  public DialogueWheelScript DialogueWheel;
  public SewingMachineScript SewingMachine;
  public CheckOutBookScript CheckOutBook;
  public TaskManagerScript TaskManager;
  public PromptBarScript PromptBar;
  public UILabel TaskDescLabel;
  public YandereScript Yandere;
  public UITexture Portrait;
  public UITexture Icon;
  public GameObject[] TaskCompleteLetters;
  public string[] Descriptions;
  public Texture[] Portraits;
  public Texture[] Icons;
  public bool TaskComplete;
  public bool Generic;
  public GameObject Window;
  public int StudentID;
  public int ID;
  public float TrueTimer;
  public float Timer;
  public string[] EightiesDescriptions;
  public Texture[] EightiesIcons;
  public AudioClip EightiesJingle;

  private void Start()
  {
    if (GameGlobals.Eighties)
    {
      this.GetComponent<AudioSource>().clip = this.EightiesJingle;
      this.GetComponent<AudioSource>().volume = 0.1f;
      this.Descriptions = this.EightiesDescriptions;
      this.Icons = this.EightiesIcons;
    }
    else
      this.UpdateTaskObjects(30);
    this.Window.SetActive(false);
  }

  public void UpdateWindow(int ID)
  {
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Accept";
    this.PromptBar.Label[1].text = "Refuse";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
    this.GetPortrait(ID);
    this.StudentID = ID;
    this.GenericCheck();
    if (this.Generic)
    {
      ID = 0;
      this.Generic = false;
    }
    this.TaskDescLabel.transform.parent.gameObject.SetActive(true);
    this.TaskDescLabel.text = this.Descriptions[ID];
    this.Icon.mainTexture = this.Icons[ID];
    this.Window.SetActive(true);
    Time.timeScale = 0.0001f;
  }

  private void Update()
  {
    if (this.Window.activeInHierarchy)
    {
      if (Input.GetButtonDown("A"))
      {
        this.TaskManager.TaskStatus[this.StudentID] = 1;
        this.Yandere.TargetStudent.TalkTimer = 100f;
        this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
        this.Yandere.TargetStudent.TaskPhase = 4;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
        this.Window.SetActive(false);
        if (!this.Yandere.StudentManager.Eighties)
          this.UpdateTaskObjects(this.StudentID);
        Time.timeScale = 1f;
      }
      else if (Input.GetButtonDown("B"))
      {
        this.Yandere.TargetStudent.TalkTimer = 100f;
        this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
        this.Yandere.TargetStudent.TaskPhase = 0;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
        this.Window.SetActive(false);
        Time.timeScale = 1f;
      }
    }
    if (!this.TaskComplete)
      return;
    if ((double) this.TrueTimer == 0.0)
      this.GetComponent<AudioSource>().Play();
    this.TrueTimer += Time.deltaTime;
    this.Timer += Time.deltaTime;
    if (this.ID < this.TaskCompleteLetters.Length && (double) this.Timer > 0.0500000007450581)
    {
      this.TaskCompleteLetters[this.ID].SetActive(true);
      this.Timer = 0.0f;
      ++this.ID;
    }
    if ((double) this.TaskCompleteLetters[12].transform.localPosition.y >= -725.0)
      return;
    for (this.ID = 0; this.ID < this.TaskCompleteLetters.Length; ++this.ID)
      this.TaskCompleteLetters[this.ID].GetComponent<GrowShrinkScript>().Return();
    this.TaskCheck();
    this.DialogueWheel.End();
    this.TaskComplete = false;
    this.TrueTimer = 0.0f;
    this.Timer = 0.0f;
    this.ID = 0;
  }

  private void TaskCheck()
  {
    this.GenericCheck();
    if (this.Generic)
    {
      if (!this.Yandere.StudentManager.Eighties)
      {
        this.Yandere.Inventory.Book = false;
        this.CheckOutBook.UpdatePrompt();
      }
      else
      {
        this.Yandere.Inventory.FinishedHomework = false;
        this.HomeworkAssignment.UpdatePrompt();
      }
      this.Generic = false;
    }
    else
    {
      if (this.Yandere.TargetStudent.StudentID != 37)
        return;
      this.DialogueWheel.Yandere.TargetStudent.Cosmetic.MaleAccessories[1].SetActive(true);
    }
  }

  private void GetPortrait(int ID)
  {
    string str = "";
    if (GameGlobals.Eighties)
      str = "1989";
    this.Portrait.mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + str + "/Student_" + ID.ToString() + ".png").texture;
  }

  private void UpdateTaskObjects(int StudentID)
  {
    if (this.Yandere.StudentManager.Eighties || this.StudentID != 30)
      return;
    this.SewingMachine.Check = true;
  }

  public void GenericCheck()
  {
    this.Generic = false;
    if (this.Yandere.StudentManager.Eighties)
    {
      if (this.Yandere.TargetStudent.StudentID == 79)
        return;
      this.Generic = true;
    }
    else
    {
      if (this.Yandere.TargetStudent.StudentID == 6 || this.Yandere.TargetStudent.StudentID == 8 || this.Yandere.TargetStudent.StudentID == 11 || this.Yandere.TargetStudent.StudentID == 25 || this.Yandere.TargetStudent.StudentID == 28 || this.Yandere.TargetStudent.StudentID == 30 || this.Yandere.TargetStudent.StudentID == 36 || this.Yandere.TargetStudent.StudentID == 37 || this.Yandere.TargetStudent.StudentID == 38 || this.Yandere.TargetStudent.StudentID == 46 || this.Yandere.TargetStudent.StudentID == 47 || this.Yandere.TargetStudent.StudentID == 48 || this.Yandere.TargetStudent.StudentID == 49 || this.Yandere.TargetStudent.StudentID == 50 || this.Yandere.TargetStudent.StudentID == 52 || this.Yandere.TargetStudent.StudentID == 76 || this.Yandere.TargetStudent.StudentID == 77 || this.Yandere.TargetStudent.StudentID == 78 || this.Yandere.TargetStudent.StudentID == 79 || this.Yandere.TargetStudent.StudentID == 80 || this.Yandere.TargetStudent.StudentID == 81)
        return;
      this.Generic = true;
    }
  }

  public void AltGenericCheck(int TempID)
  {
    this.Generic = false;
    if (this.Yandere.StudentManager.Eighties)
    {
      if (TempID == 79)
        return;
      this.Generic = true;
    }
    else
    {
      if (TempID == 6 || TempID == 8 || TempID == 11 || TempID == 25 || TempID == 28 || TempID == 30 || TempID == 36 || TempID == 37 || TempID == 38 || TempID == 46 || TempID == 47 || TempID == 48 || TempID == 49 || TempID == 50 || TempID == 52 || TempID == 76 || TempID == 77 || TempID == 78 || TempID == 79 || TempID == 80 || TempID == 81)
        return;
      this.Generic = true;
    }
  }
}
