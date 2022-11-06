// Decompiled with JetBrains decompiler
// Type: NewMissionWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NewMissionWindowScript : MonoBehaviour
{
  public MissionModeMenuScript MissionModeMenu;
  public InputManagerScript InputManager;
  public JsonScript JSON;
  public GameObject[] DeathSkulls;
  public GameObject[] Button;
  public UILabel[] MethodLabel;
  public UILabel[] NameLabel;
  public UITexture[] Portrait;
  public bool ChangingDifficulty;
  public int[] UnsafeNumbers;
  public int[] Target;
  public int[] Method;
  public string[] MethodNames;
  public int Selected;
  public int Column;
  public int Row;
  public Transform DifficultyOptions;
  public Transform Highlight;
  public Texture BlankPortrait;
  public Font Arial;
  public int NemesisDifficulty;
  public bool NemesisAggression;
  public UILabel NemesisLabel;
  public UITexture NemesisPortrait;
  public Texture AnonymousPortrait;
  public Texture NemesisGraphic;
  public Transform[] NemesisObjectives;

  private void Start()
  {
    this.UpdateHighlight();
    for (int index = 1; index < 11; ++index)
    {
      this.Portrait[index].mainTexture = this.BlankPortrait;
      this.NameLabel[index].text = "Kill: (Nobody)";
      this.MethodLabel[index].text = "By: Attacking";
      this.DeathSkulls[index].SetActive(false);
    }
    this.DifficultyOptions.localScale = new Vector3(0.0f, 0.0f, 0.0f);
  }

  private void ChangeFont(UILabel Text)
  {
    Text.trueTypeFont = this.Arial;
    if (Text.height != 150)
      return;
    Text.height = 100;
  }

  private void Update()
  {
    if (!this.ChangingDifficulty)
    {
      if (this.InputManager.TappedDown)
      {
        ++this.Row;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedUp)
      {
        --this.Row;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedRight)
      {
        ++this.Column;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedLeft)
      {
        --this.Column;
        this.UpdateHighlight();
      }
      if (Input.GetButtonDown("A"))
      {
        int num = 0;
        for (int index = 0; index < 11; ++index)
        {
          if (this.Target[index] > 0)
            ++num;
        }
        if (this.Row == 5)
        {
          if (this.Column == 1)
          {
            if (num > 0)
            {
              Globals.DeleteAll();
              this.SaveInfo();
              this.MissionModeMenu.GetComponent<AudioSource>().PlayOneShot(this.MissionModeMenu.InfoLines[6]);
              SchoolGlobals.SchoolAtmosphere = (float) (1.0 - (double) num * 0.10000000149011612);
              SchoolGlobals.SchoolAtmosphereSet = true;
              MissionModeGlobals.MissionMode = true;
              MissionModeGlobals.MultiMission = true;
              MissionModeGlobals.MissionDifficulty = num;
              ClassGlobals.BiologyGrade = 1;
              ClassGlobals.ChemistryGrade = 1;
              ClassGlobals.LanguageGrade = 1;
              ClassGlobals.PhysicalGrade = 1;
              ClassGlobals.PsychologyGrade = 1;
              this.MissionModeMenu.PromptBar.Show = false;
              this.MissionModeMenu.Speed = 0.0f;
              this.MissionModeMenu.Phase = 4;
              this.enabled = false;
            }
          }
          else if (this.Column == 2)
            this.Randomize();
          else if (this.Column == 3)
          {
            this.ChangingDifficulty = true;
            this.MissionModeMenu.PromptBar.ClearButtons();
            this.MissionModeMenu.PromptBar.Label[0].text = "Change";
            this.MissionModeMenu.PromptBar.Label[1].text = "Back";
            this.MissionModeMenu.PromptBar.Label[2].text = "Aggression";
            this.MissionModeMenu.PromptBar.UpdateButtons();
            this.MissionModeMenu.PromptBar.Show = true;
          }
        }
      }
      if (Input.GetButtonDown("B"))
      {
        this.MissionModeMenu.PromptBar.ClearButtons();
        this.MissionModeMenu.PromptBar.Label[0].text = "Accept";
        this.MissionModeMenu.PromptBar.Label[4].text = "Choose";
        this.MissionModeMenu.PromptBar.UpdateButtons();
        this.MissionModeMenu.PromptBar.Show = true;
        this.MissionModeMenu.TargetID = 0;
        this.MissionModeMenu.Phase = 2;
        this.enabled = false;
      }
      if (Input.GetButtonDown("X"))
      {
        if (this.Row == 1)
        {
          for (int index = 1; index < 11; ++index)
            this.UnsafeNumbers[index] = this.Target[index];
          this.Increment(0);
          if (this.Target[this.Column] != 0)
          {
            while (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[1] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[2] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[3] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[4] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[5] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[6] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[7] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[8] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[9] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[10])
              this.Increment(0);
          }
          this.UnsafeNumbers[this.Column] = this.Target[this.Column];
        }
        else if (this.Row == 2)
        {
          ++this.Method[this.Column];
          if (this.Method[this.Column] == this.MethodNames.Length)
            this.Method[this.Column] = 0;
          this.MethodLabel[this.Column].text = "By: " + this.MethodNames[this.Method[this.Column]];
        }
        else if (this.Row == 3)
        {
          for (int index = 1; index < 11; ++index)
            this.UnsafeNumbers[index] = this.Target[index];
          this.Increment(5);
          if (this.Target[this.Column + 5] != 0)
          {
            while (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[1] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[2] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[3] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[4] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[5] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[6] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[7] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[8] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[9] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[10])
              this.Increment(5);
          }
          this.UnsafeNumbers[this.Column + 5] = this.Target[this.Column + 5];
        }
        else if (this.Row == 4)
        {
          ++this.Method[this.Column + 5];
          if (this.Method[this.Column + 5] == this.MethodNames.Length)
            this.Method[this.Column + 5] = 0;
          this.MethodLabel[this.Column + 5].text = "By: " + this.MethodNames[this.Method[this.Column + 5]];
        }
      }
      if (Input.GetButtonDown("Y"))
      {
        if (this.Row == 1)
        {
          for (int index = 1; index < 11; ++index)
            this.UnsafeNumbers[index] = this.Target[index];
          this.Decrement(0);
          if (this.Target[this.Column] != 0)
          {
            while (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[1] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[2] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[3] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[4] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[5] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[6] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[7] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[8] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[9] || this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[10])
            {
              Debug.Log((object) "Unsafe number. We're going to have to decrement.");
              this.Decrement(0);
            }
          }
          this.UnsafeNumbers[this.Column] = this.Target[this.Column];
        }
        else if (this.Row == 2)
        {
          --this.Method[this.Column];
          if (this.Method[this.Column] < 0)
            this.Method[this.Column] = this.MethodNames.Length - 1;
          this.MethodLabel[this.Column].text = "By: " + this.MethodNames[this.Method[this.Column]];
        }
        else if (this.Row == 3)
        {
          for (int index = 1; index < 11; ++index)
            this.UnsafeNumbers[index] = this.Target[index];
          this.Decrement(5);
          if (this.Target[this.Column + 5] != 0)
          {
            while (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[1] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[2] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[3] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[4] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[5] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[6] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[7] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[8] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[9] || this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[10])
            {
              Debug.Log((object) "Unsafe number. We're going to have to decrement.");
              this.Decrement(5);
            }
          }
          this.UnsafeNumbers[this.Column + 5] = this.Target[this.Column + 5];
        }
        else if (this.Row == 4)
        {
          --this.Method[this.Column + 5];
          if (this.Method[this.Column + 5] < 0)
            this.Method[this.Column + 5] = this.MethodNames.Length - 1;
          this.MethodLabel[this.Column + 5].text = "By: " + this.MethodNames[this.Method[this.Column + 5]];
        }
      }
      if (Input.GetKeyDown("space"))
        this.FillOutInfo();
      this.DifficultyOptions.localScale = Vector3.Lerp(this.DifficultyOptions.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);
    }
    else
    {
      this.DifficultyOptions.localScale = Vector3.Lerp(this.DifficultyOptions.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (Input.GetButtonDown("A"))
      {
        ++this.NemesisDifficulty;
        this.UpdateNemesisDifficulty();
      }
      if (Input.GetButtonDown("X"))
      {
        this.NemesisAggression = !this.NemesisAggression;
        this.UpdateNemesisDifficulty();
      }
      if (Input.GetButtonDown("B"))
      {
        this.MissionModeMenu.PromptBar.ClearButtons();
        this.MissionModeMenu.PromptBar.Label[0].text = "";
        this.MissionModeMenu.PromptBar.Label[1].text = "Return";
        this.MissionModeMenu.PromptBar.Label[2].text = "Adjust Up";
        this.MissionModeMenu.PromptBar.Label[3].text = "Adjust Down";
        this.MissionModeMenu.PromptBar.Label[4].text = "Selection";
        this.MissionModeMenu.PromptBar.Label[5].text = "Selection";
        this.MissionModeMenu.PromptBar.UpdateButtons();
        this.Column = 1;
        this.Row = 1;
        this.UpdateHighlight();
        this.ChangingDifficulty = false;
      }
    }
    this.UpdateNemesisList();
  }

  private void Increment(int Number)
  {
    ++this.Target[this.Column + Number];
    if (this.Target[this.Column + Number] == 1)
      this.Target[this.Column + Number] = 2;
    else if (this.Target[this.Column + Number] == 12)
      this.Target[this.Column + Number] = 21;
    else if (this.Target[this.Column + Number] > 89)
      this.Target[this.Column + Number] = 0;
    this.NameLabel[this.Column + Number].text = this.Target[this.Column + Number] != 0 ? "Kill: " + this.JSON.Students[this.Target[this.Column + Number]].Name : "Kill: Nobody";
    WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + this.Target[this.Column + Number].ToString() + ".png");
    if (this.Target[this.Column + Number] > 0)
      this.Portrait[this.Column + Number].mainTexture = (Texture) www.texture;
    else
      this.Portrait[this.Column + Number].mainTexture = this.BlankPortrait;
  }

  private void Decrement(int Number)
  {
    --this.Target[this.Column + Number];
    Debug.Log((object) ("Decremented. Number has become: " + this.Target[this.Column + Number].ToString()));
    if (this.Target[this.Column + Number] == 1)
    {
      this.Target[this.Column + Number] = 0;
      Debug.Log((object) "Correcting to 0.");
    }
    else if (this.Target[this.Column + Number] == 20)
    {
      this.Target[this.Column + Number] = 11;
      Debug.Log((object) "Correcting to 11.");
    }
    else if (this.Target[this.Column + Number] == -1)
    {
      this.Target[this.Column + Number] = 89;
      Debug.Log((object) "Correcting to 89.");
    }
    this.NameLabel[this.Column + Number].text = this.Target[this.Column + Number] != 0 ? "Kill: " + this.JSON.Students[this.Target[this.Column + Number]].Name : "Kill: Nobody";
    WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + this.Target[this.Column + Number].ToString() + ".png");
    if (this.Target[this.Column + Number] > 0)
      this.Portrait[this.Column + Number].mainTexture = (Texture) www.texture;
    else
      this.Portrait[this.Column + Number].mainTexture = this.BlankPortrait;
  }

  private void Randomize()
  {
    for (int index = 1; index < 11; ++index)
    {
      this.Target[index] = Random.Range(2, 89);
      this.Method[index] = Random.Range(0, 7);
      this.MethodLabel[index].text = "By: " + this.MethodNames[this.Method[index]];
    }
    int Number = 1;
    this.Column = 0;
    for (; Number < 11; ++Number)
    {
      for (int index = 1; index < 11; ++index)
        this.UnsafeNumbers[index] = this.Target[index];
      while (this.Target[Number] == this.UnsafeNumbers[1] || this.Target[Number] == this.UnsafeNumbers[2] || this.Target[Number] == this.UnsafeNumbers[3] || this.Target[Number] == this.UnsafeNumbers[4] || this.Target[Number] == this.UnsafeNumbers[5] || this.Target[Number] == this.UnsafeNumbers[6] || this.Target[Number] == this.UnsafeNumbers[7] || this.Target[Number] == this.UnsafeNumbers[8] || this.Target[Number] == this.UnsafeNumbers[9] || this.Target[Number] == this.UnsafeNumbers[10] || this.Target[Number] == 0 || this.Target[Number] > 11 && this.Target[Number] < 21)
        this.Increment(Number);
    }
    this.Column = 2;
  }

  public void UpdateHighlight()
  {
    this.MissionModeMenu.PromptBar.Label[0].text = "";
    if (this.Row < 1)
      this.Row = 5;
    else if (this.Row > 5)
      this.Row = 1;
    if (this.Row < 5)
    {
      if (this.Column < 1)
        this.Column = 5;
      else if (this.Column > 5)
        this.Column = 1;
      int y = 0;
      if (this.Row == 1)
        y = 225;
      else if (this.Row == 2)
        y = 125;
      else if (this.Row == 3)
        y = -300;
      else if (this.Row == 4)
        y = -400;
      this.Highlight.localPosition = new Vector3((float) (400 * this.Column - 1200), (float) y, 0.0f);
    }
    else
    {
      if (this.Column < 1)
        this.Column = 3;
      else if (this.Column > 3)
        this.Column = 1;
      this.Highlight.localPosition = new Vector3((float) (600 * this.Column - 1200), -525f, 0.0f);
      this.MissionModeMenu.PromptBar.Label[0].text = this.Column != 1 ? (this.Column != 2 ? "" : "Confirm") : (this.Target[1] + this.Target[2] + this.Target[3] + this.Target[4] + this.Target[5] + this.Target[6] + this.Target[7] + this.Target[8] + this.Target[9] + this.Target[10] != 0 ? "Confirm" : "");
      this.MissionModeMenu.PromptBar.UpdateButtons();
    }
  }

  private void SaveInfo()
  {
    for (int index = 1; index < 11; ++index)
    {
      PlayerPrefs.SetInt("MissionModeTarget" + index.ToString(), this.Target[index]);
      PlayerPrefs.SetInt("MissionModeMethod" + index.ToString(), this.Method[index]);
    }
    MissionModeGlobals.NemesisDifficulty = this.NemesisDifficulty;
    MissionModeGlobals.NemesisAggression = this.NemesisAggression;
  }

  public void FillOutInfo()
  {
    for (int index = 1; index < 11; ++index)
    {
      this.ChangeFont(this.NameLabel[index]);
      this.ChangeFont(this.MethodLabel[index]);
      this.Target[index] = PlayerPrefs.GetInt("MissionModeTarget" + index.ToString());
      this.Method[index] = PlayerPrefs.GetInt("MissionModeMethod" + index.ToString());
      this.NameLabel[index].text = this.Target[index] != 0 ? "Kill: " + this.JSON.Students[this.Target[index]].Name : "Kill: Nobody";
      WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + this.Target[index].ToString() + ".png");
      this.Portrait[index].mainTexture = (Texture) www.texture;
      this.MethodLabel[index].text = "By: " + this.MethodNames[this.Method[index]];
      this.DeathSkulls[index].SetActive(false);
    }
  }

  public void HideButtons()
  {
    this.Button[0].SetActive(false);
    this.Button[1].SetActive(false);
    this.Button[2].SetActive(false);
    this.Button[3].SetActive(false);
  }

  private void UpdateNemesisDifficulty()
  {
    if (this.NemesisDifficulty < 0)
      this.NemesisDifficulty = 4;
    else if (this.NemesisDifficulty > 4)
      this.NemesisDifficulty = 0;
    if (this.NemesisDifficulty == 0)
    {
      this.NemesisLabel.text = "Nemesis: Off";
    }
    else
    {
      this.NemesisLabel.text = "Nemesis: On";
      this.NemesisPortrait.mainTexture = this.NemesisDifficulty > 2 ? this.AnonymousPortrait : this.NemesisGraphic;
    }
  }

  private void UpdateNemesisList()
  {
    if (this.NemesisDifficulty == 0)
    {
      this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
      this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
      this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
    }
    else if (this.NemesisDifficulty == 1)
    {
      this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
      this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
    }
    else if (this.NemesisDifficulty == 2)
    {
      this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
    }
    else if (this.NemesisDifficulty == 3)
    {
      this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
      this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    }
    else if (this.NemesisDifficulty == 4)
    {
      this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    }
    if (this.NemesisAggression)
      this.NemesisObjectives[4].localScale = Vector3.Lerp(this.NemesisObjectives[4].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    else
      this.NemesisObjectives[4].localScale = Vector3.Lerp(this.NemesisObjectives[4].localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);
  }
}
