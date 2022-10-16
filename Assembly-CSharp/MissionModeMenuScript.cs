// Decompiled with JetBrains decompiler
// Type: MissionModeMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class MissionModeMenuScript : MonoBehaviour
{
  public PostProcessingProfile Profile;
  public StudentManagerScript StudentManager;
  public NewMissionWindowScript MultiMission;
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public JsonScript JSON;
  public UITexture CustomTargetPortrait;
  public UILabel CustomDifficultyLabel;
  public UILabel CustomPopulationLabel;
  public UILabel CustomNemesisLabel;
  public UITexture NemesisPortrait;
  public UITexture TargetPortrait;
  public UILabel LoadMissionLabel;
  public UILabel DescriptionLabel;
  public UILabel DifficultyLabel;
  public UILabel PopulationLabel;
  public UILabel NemesisLabel;
  public UILabel ErrorLabel;
  public UILabel Header;
  public UISprite Highlight;
  public UISprite Darkness;
  public Transform CustomMissionWindow;
  public Transform MultiMissionWindow;
  public Transform ObjectiveHighlight;
  public Transform LoadMissionWindow;
  public Transform MissionWindow;
  public Transform InfoChan;
  public Transform Options;
  public Transform Neck;
  public GameObject NowLoading;
  public string[] ConditionDescs;
  public int[] Conditions;
  public string[] ClothingNames;
  public string[] DisposalNames;
  public string[] WeaponNames;
  public int RequiredClothingID;
  public int RequiredDisposalID;
  public int RequiredWeaponID;
  public Transform[] CustomNemesisObjectives;
  public Transform[] NemesisObjectives;
  public UIPanel[] CustomObjectives;
  public Texture[] ConditionIcons;
  public Transform[] Objectives;
  public Transform[] Option;
  public UITexture[] Icons;
  public UILabel[] CustomDescs;
  public UILabel[] Descs;
  public Texture NemesisGraphic;
  public Texture BlankPortrait;
  public string MissionIDString = string.Empty;
  public string TargetName = string.Empty;
  public int NemesisDifficulty;
  public int CustomSelected = 1;
  public int Difficulty = 1;
  public int Selected = 1;
  public int TargetID;
  public int Phase;
  public int Column = 1;
  public int Row = 1;
  public float Rotation;
  public float Speed;
  public float Timer;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public AudioClip[] InfoLines;
  public bool[] InfoSpoke;
  public bool Toggling;
  public bool Valid;
  public int TargetNumber;
  public int WeaponNumber;
  public int ClothingNumber;
  public int DisposalNumber;
  public int NemesisNumber;
  public int PopulationNumber;
  public int Condition5Number;
  public int Condition6Number;
  public int Condition7Number;
  public int Condition8Number;
  public int Condition9Number;
  public int Condition10Number;
  public int Condition11Number;
  public int Condition12Number;
  public int Condition13Number;
  public int Condition14Number;
  public int Condition15Number;
  public string TargetString = string.Empty;
  public string WeaponString = string.Empty;
  public string ClothingString = string.Empty;
  public string DisposalString = string.Empty;
  public string MissionID = string.Empty;
  public string[] ConditionString;
  public UILabel MissionIDLabel;
  public Font Arial;

  private void Start()
  {
    this.transform.position = new Vector3(0.0f, 0.95f, -4.266667f);
    ColorGradingModel.Settings settings1 = this.Profile.colorGrading.settings;
    settings1.basic.saturation = 1f;
    settings1.channelMixer.red = new Vector3(1f, 0.0f, 0.0f);
    settings1.channelMixer.green = new Vector3(0.0f, 1f, 0.0f);
    settings1.channelMixer.blue = new Vector3(0.0f, 0.0f, 1f);
    this.Profile.colorGrading.settings = settings1;
    this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
    {
      focusDistance = 10f,
      aperture = 11.2f
    };
    BloomModel.Settings settings2 = this.Profile.bloom.settings;
    settings2.bloom.intensity = 1f;
    settings2.bloom.threshold = 1f;
    settings2.bloom.softKnee = 1f;
    settings2.bloom.radius = 4f;
    this.Profile.bloom.settings = settings2;
    MissionModeGlobals.MultiMission = false;
    this.NemesisPortrait.transform.parent.localScale = Vector3.zero;
    this.CustomMissionWindow.transform.localScale = Vector3.zero;
    this.MultiMissionWindow.transform.localScale = Vector3.zero;
    this.LoadMissionWindow.transform.localScale = Vector3.zero;
    this.MissionWindow.transform.localScale = Vector3.zero;
    this.Options.transform.localPosition = new Vector3(-700f, this.Options.transform.localPosition.y, this.Options.transform.localPosition.z);
    this.Highlight.color = new Color(this.Highlight.color.r, this.Highlight.color.g, this.Highlight.color.b, 0.0f);
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
    this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, 0.0f);
    Time.timeScale = 1f;
    this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
    this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
    this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
    for (int index = 1; index < 6; ++index)
    {
      Transform transform = this.Option[index].transform;
      transform.localPosition = new Vector3(-800f, transform.localPosition.y, transform.localPosition.z);
    }
    for (int index = 1; index < this.Objectives.Length; ++index)
      this.Objectives[index].localScale = Vector3.zero;
    for (int index = 1; index < this.NemesisObjectives.Length; ++index)
      this.NemesisObjectives[index].localScale = Vector3.zero;
    for (int index = 1; index < this.CustomObjectives.Length; ++index)
    {
      if ((Object) this.CustomObjectives[index] != (Object) null)
        this.CustomObjectives[index].alpha = 0.5f;
    }
    this.CustomPopulationLabel.text = "";
    this.PopulationLabel.text = "";
    this.ChangeFont();
  }

  private void Update()
  {
    if (this.Phase == 1)
    {
      this.Speed += Time.deltaTime;
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp(this.transform.position.z, 2f, (float) ((double) this.Speed * (double) Time.deltaTime * 0.25)));
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime / 3f));
      if ((double) this.Speed > 1.0)
      {
        this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, Mathf.MoveTowards(this.Header.color.a, 1f, Time.deltaTime));
        if ((double) this.Speed > 3.0)
        {
          if (!this.InfoSpoke[0])
          {
            this.MyAudio.PlayOneShot(this.InfoLines[0]);
            this.InfoSpoke[0] = true;
          }
          this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
          Transform transform1 = this.Option[1];
          transform1.localPosition = new Vector3(Mathf.Lerp(transform1.localPosition.x, 0.0f, Time.deltaTime * 10f), transform1.localPosition.y, transform1.localPosition.z);
          if ((double) this.Speed > 3.25)
          {
            Transform transform2 = this.Option[2];
            transform2.localPosition = new Vector3(Mathf.Lerp(transform2.localPosition.x, 0.0f, Time.deltaTime * 10f), transform2.localPosition.y, transform2.localPosition.z);
            if ((double) this.Speed > 3.5)
            {
              Transform transform3 = this.Option[3];
              transform3.localPosition = new Vector3(Mathf.Lerp(transform3.localPosition.x, 0.0f, Time.deltaTime * 10f), transform3.localPosition.y, transform3.localPosition.z);
              if ((double) this.Speed > 3.75)
              {
                Transform transform4 = this.Option[4];
                transform4.localPosition = new Vector3(Mathf.Lerp(transform4.localPosition.x, 0.0f, Time.deltaTime * 10f), transform4.localPosition.y, transform4.localPosition.z);
                if ((double) this.Speed > 4.0)
                {
                  Transform transform5 = this.Option[5];
                  transform5.localPosition = new Vector3(Mathf.Lerp(transform5.localPosition.x, 0.0f, Time.deltaTime * 10f), transform5.localPosition.y, transform5.localPosition.z);
                  if ((double) this.Speed > 5.0)
                  {
                    this.PromptBar.Label[0].text = "Accept";
                    this.PromptBar.Label[4].text = "Choose";
                    this.PromptBar.UpdateButtons();
                    this.PromptBar.Show = true;
                    ++this.Phase;
                  }
                }
              }
            }
          }
        }
      }
      if (!Input.GetButtonDown("A"))
        return;
      if (!this.InfoSpoke[0])
      {
        this.MyAudio.PlayOneShot(this.InfoLines[0]);
        this.InfoSpoke[0] = true;
      }
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, 180f, this.InfoChan.localEulerAngles.z);
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 2f);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0.0f);
      this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, 1f);
      this.Rotation = 0.0f;
      for (int index = 1; index < 6; ++index)
      {
        Transform transform = this.Option[index];
        transform.localPosition = new Vector3(0.0f, transform.localPosition.y, transform.localPosition.z);
      }
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      ++this.Phase;
    }
    else if (this.Phase == 2)
    {
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp(this.transform.position.z, 2f, (float) ((double) this.Speed * (double) Time.deltaTime * 0.25)));
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -700f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp(this.transform.position.z, 2f, (float) ((double) this.Speed * (double) Time.deltaTime * 0.25)));
      if (this.InputManager.TappedUp)
      {
        --this.Selected;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedDown)
      {
        ++this.Selected;
        this.UpdateHighlight();
      }
      this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, Mathf.Lerp(this.Highlight.transform.localPosition.y, (float) (150.0 - 50.0 * (double) this.Selected), Time.deltaTime * 10f), this.Highlight.transform.localPosition.z);
      this.Highlight.color = new Color(this.Highlight.color.r, this.Highlight.color.g, this.Highlight.color.b, Mathf.MoveTowards(this.Highlight.color.a, 1f, Time.deltaTime));
      for (int index = 1; index < 6; ++index)
      {
        if (index != this.Selected)
        {
          Transform transform = this.Option[index];
          transform.localPosition = new Vector3(Mathf.Lerp(transform.transform.localPosition.x, 0.0f, Time.deltaTime * 10f), transform.localPosition.y, transform.localPosition.z);
        }
      }
      Transform transform6 = this.Option[this.Selected];
      transform6.localPosition = new Vector3(Mathf.Lerp(transform6.transform.localPosition.x, 50f, Time.deltaTime * 10f), transform6.localPosition.y, transform6.localPosition.z);
      if (!Input.GetButtonDown("A"))
        return;
      if (!this.InfoSpoke[this.Selected])
      {
        this.MyAudio.PlayOneShot(this.InfoLines[this.Selected]);
        this.InfoSpoke[this.Selected] = true;
      }
      if (this.Selected == 1)
      {
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[1].text = "Return";
        this.PromptBar.Label[2].text = "Generate";
        this.PromptBar.Label[3].text = "";
        this.PromptBar.Label[4].text = "Nemesis";
        this.PromptBar.Label[5].text = "Change Difficulty";
        this.PromptBar.UpdateButtons();
        for (int index = 1; index < this.Conditions.Length; ++index)
          this.Conditions[index] = 0;
        if (this.TargetID == 0)
          this.ChooseTarget();
        this.RequiredClothingID = 0;
        this.RequiredDisposalID = 0;
        this.RequiredWeaponID = 0;
        this.NemesisDifficulty = 0;
        this.Difficulty = 1;
        this.UpdateNemesisDifficulty();
        this.UpdateDifficultyLabel();
        ++this.Phase;
      }
      else if (this.Selected == 2)
      {
        this.Difficulty = 1;
        this.Phase = 5;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Toggle";
        this.PromptBar.Label[1].text = "Return";
        this.PromptBar.Label[2].text = "Change";
        this.PromptBar.Label[3].text = "";
        this.PromptBar.Label[4].text = "Selection";
        this.PromptBar.Label[5].text = "Selection";
        this.PromptBar.UpdateButtons();
        this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
        this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
        this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
        this.UpdateObjectiveHighlight();
        this.UpdateDifficultyLabel();
        this.RequiredClothingID = 1;
        this.RequiredDisposalID = 1;
        this.RequiredWeaponID = 1;
        this.TargetID = 2;
        this.ChooseTarget();
        this.CalculateMissionID();
      }
      else if (this.Selected == 3)
      {
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "";
        this.PromptBar.Label[1].text = "Return";
        this.PromptBar.Label[2].text = "Adjust Up";
        this.PromptBar.Label[3].text = "Adjust Down";
        this.PromptBar.Label[4].text = "Selection";
        this.PromptBar.Label[5].text = "Selection";
        this.PromptBar.UpdateButtons();
        this.MultiMission.enabled = true;
        this.MultiMission.Column = 1;
        this.MultiMission.Row = 1;
        this.MultiMission.UpdateHighlight();
        this.Phase = 6;
      }
      else if (this.Selected == 4)
      {
        Cursor.visible = true;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Confirm";
        this.PromptBar.Label[1].text = "Back";
        this.PromptBar.UpdateButtons();
        this.Phase = 7;
      }
      else
      {
        if (this.Selected != 5)
          return;
        this.PromptBar.Show = false;
        this.Phase = 4;
        this.Speed = 0.0f;
      }
    }
    else if (this.Phase == 3)
    {
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp(this.transform.position.z, 2f, (float) ((double) this.Speed * (double) Time.deltaTime * 0.25)));
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
      if (this.InputManager.TappedLeft)
      {
        --this.Difficulty;
        this.UpdateDifficulty();
      }
      if (this.InputManager.TappedRight)
      {
        ++this.Difficulty;
        this.UpdateDifficulty();
      }
      if (this.InputManager.TappedUp)
      {
        --this.NemesisDifficulty;
        this.UpdateNemesisDifficulty();
      }
      if (this.InputManager.TappedDown)
      {
        ++this.NemesisDifficulty;
        this.UpdateNemesisDifficulty();
      }
      for (int index = 1; index < this.Objectives.Length; ++index)
      {
        Transform objective = this.Objectives[index];
        objective.localScale = Vector3.Lerp(objective.localScale, index > this.Difficulty ? Vector3.zero : Vector3.one, Time.deltaTime * 10f);
      }
      if (this.NemesisDifficulty == 0)
      {
        this.NemesisPortrait.transform.parent.localScale = Vector3.Lerp(this.NemesisPortrait.transform.parent.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      else
        this.NemesisPortrait.transform.parent.localScale = Vector3.Lerp(this.NemesisPortrait.transform.parent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.NemesisDifficulty == 1)
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
      if (Input.GetButtonDown("A"))
        this.StartMission();
      else if (Input.GetButtonDown("B"))
      {
        Cursor.visible = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.TargetID = 0;
        --this.Phase;
      }
      else if (Input.GetButtonDown("X"))
      {
        this.RequiredClothingID = 0;
        this.RequiredDisposalID = 0;
        this.RequiredWeaponID = 0;
        this.ChooseTarget();
        if (this.Difficulty > 1)
        {
          int difficulty = this.Difficulty;
          this.Difficulty = 1;
          while (this.Difficulty < difficulty)
          {
            ++this.Difficulty;
            this.PickNewCondition();
          }
        }
        this.UpdateDifficultyLabel();
      }
      else
      {
        if (!Input.GetButtonDown("Y"))
          return;
        this.UpdatePopulation();
      }
    }
    else if (this.Phase == 4)
    {
      this.Speed += Time.deltaTime;
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 0.0f, Time.deltaTime * this.Speed), this.InfoChan.localEulerAngles.z);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 0.5f));
      Transform parent = this.Option[1].parent;
      parent.localPosition = new Vector3(parent.localPosition.x - this.Speed * 1000f * Time.deltaTime, parent.localPosition.y, parent.localPosition.z);
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - this.Speed * Time.deltaTime);
      this.Jukebox.volume -= Time.deltaTime;
      this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, this.Header.color.a - Time.deltaTime);
      if ((double) this.Darkness.color.a != 1.0)
        return;
      if (this.TargetID == 0 && !MissionModeGlobals.MultiMission)
      {
        SceneManager.LoadScene("NewTitleScene");
      }
      else
      {
        this.NowLoading.SetActive(true);
        SceneManager.LoadScene("SchoolScene");
      }
    }
    else if (this.Phase == 5)
    {
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp(this.transform.position.z, 2f, (float) ((double) this.Speed * (double) Time.deltaTime * 0.25)));
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
      if (this.InputManager.TappedUp)
      {
        --this.Row;
        this.UpdateObjectiveHighlight();
      }
      if (this.InputManager.TappedDown)
      {
        ++this.Row;
        this.UpdateObjectiveHighlight();
      }
      if (this.InputManager.TappedRight)
      {
        ++this.Column;
        this.UpdateObjectiveHighlight();
      }
      if (this.InputManager.TappedLeft)
      {
        --this.Column;
        this.UpdateObjectiveHighlight();
      }
      if (Input.GetButtonDown("A"))
      {
        if (this.CustomSelected == 1)
        {
          ++this.TargetID;
          this.ChooseTarget();
        }
        else if (this.CustomSelected == 6)
        {
          for (int index = 1; index < this.Conditions.Length; ++index)
            this.Conditions[index] = 0;
          int index1 = 2;
          for (int index2 = 2; index2 < this.CustomObjectives.Length; ++index2)
          {
            if ((Object) this.CustomObjectives[index2] != (Object) null && (double) this.CustomObjectives[index2].alpha == 1.0)
            {
              this.Conditions[index1] = index2 >= 6 ? (index2 >= 12 ? index2 - 3 : index2 - 2) : index2 - 1;
              ++index1;
            }
          }
          this.StartMission();
        }
        else if (this.CustomSelected == 12)
        {
          ++this.NemesisDifficulty;
          this.UpdateNemesisDifficulty();
        }
        if (this.Toggling)
        {
          if ((double) this.CustomObjectives[this.CustomSelected].alpha == 0.5)
          {
            if (this.Difficulty < 10)
            {
              ++this.Difficulty;
              this.UpdateDifficultyLabel();
              this.CustomObjectives[this.CustomSelected].alpha = 1f;
            }
          }
          else
          {
            --this.Difficulty;
            this.UpdateDifficultyLabel();
            this.CustomObjectives[this.CustomSelected].alpha = 0.5f;
          }
        }
        this.CalculateMissionID();
      }
      else if (Input.GetButtonDown("B"))
      {
        Cursor.visible = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        for (int index = 1; index < this.CustomObjectives.Length; ++index)
        {
          if ((Object) this.CustomObjectives[index] != (Object) null)
            this.CustomObjectives[index].alpha = 0.5f;
        }
        this.NemesisDifficulty = 0;
        this.UpdateNemesisDifficulty();
        this.Difficulty = 1;
        this.TargetID = 0;
        this.Phase = 2;
      }
      else if (Input.GetButtonDown("X"))
      {
        if (this.CustomSelected == 1)
        {
          --this.TargetID;
          this.ChooseTarget();
          this.CalculateMissionID();
        }
        else if (this.CustomSelected == 2)
        {
          ++this.RequiredWeaponID;
          if (this.RequiredWeaponID == 11)
            ++this.RequiredWeaponID;
          if (this.RequiredWeaponID > this.WeaponNames.Length - 1)
            this.RequiredWeaponID = 1;
          this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[this.RequiredWeaponID];
        }
        else if (this.CustomSelected == 3)
        {
          ++this.RequiredClothingID;
          if (this.RequiredClothingID > this.ClothingNames.Length - 1)
            this.RequiredClothingID = 1;
          this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[this.RequiredClothingID];
        }
        else if (this.CustomSelected == 4)
        {
          ++this.RequiredDisposalID;
          if (this.RequiredDisposalID > this.DisposalNames.Length - 1)
            this.RequiredDisposalID = 1;
          this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[this.RequiredDisposalID];
        }
        else if (this.CustomSelected == 12)
        {
          --this.NemesisDifficulty;
          this.UpdateNemesisDifficulty();
        }
        this.CalculateMissionID();
      }
      else if (Input.GetButtonDown("Y"))
      {
        this.UpdatePopulation();
        this.CalculateMissionID();
      }
      if (this.NemesisDifficulty == 0)
      {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      else if (this.NemesisDifficulty == 1)
      {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      else if (this.NemesisDifficulty == 2)
      {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      else if (this.NemesisDifficulty == 3)
      {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
      else if (this.NemesisDifficulty == 4)
      {
        this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
      this.MissionIDLabel.gameObject.GetComponent<UIInput>().value = this.MissionID;
    }
    else if (this.Phase == 6)
    {
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
      this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
    }
    else
    {
      if (this.Phase != 7)
        return;
      this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp(this.transform.position.z, 2f, (float) ((double) this.Speed * (double) Time.deltaTime * 0.25)));
      this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
      if (!Input.anyKey)
      {
        this.MissionIDString = this.LoadMissionLabel.text;
        if (this.MissionIDString.Length < 19)
          this.ErrorLabel.text = "A Mission ID must be 19 numbers long.";
        else if (this.MissionIDString[0] != '-')
        {
          this.Valid = false;
          this.GetNumbers();
          bool flag = false;
          if (this.TargetNumber > 11 && this.TargetNumber < 21 || this.TargetNumber > 89)
            flag = true;
          if (this.TargetNumber == 0)
            this.ErrorLabel.text = "Invalid Mission ID (No target specified)";
          else if (this.TargetNumber == 1)
            this.ErrorLabel.text = "Invalid Mission ID (Target cannot be Senpai)";
          else if (flag)
            this.ErrorLabel.text = "Invalid Mission ID (That student has not been implemented yet)";
          else if (this.WeaponNumber == 11)
            this.ErrorLabel.text = "Invalid Mission ID (Weapon does not apply to Mission Mode)";
          else if (this.WeaponNumber > 14)
            this.ErrorLabel.text = "Invalid Mission ID (Weapon does not exist)";
          else if (this.ClothingNumber > 5)
            this.ErrorLabel.text = "Invalid Mission ID (Clothing does not exist)";
          else if (this.DisposalNumber > 3)
            this.ErrorLabel.text = "Invalid Mission ID (Disposal method does not exist)";
          else if (this.NemesisNumber > 4)
            this.ErrorLabel.text = "Invalid Mission ID (Nemesis level too high)";
          else if (this.PopulationNumber > 0)
            this.ErrorLabel.text = "Invalid Mission ID (Final digit must be '0')";
          else if (this.Condition5Number > 1 || this.Condition6Number > 1 || this.Condition7Number > 1 || this.Condition8Number > 1 || this.Condition9Number > 1 || this.Condition10Number > 1 || this.Condition11Number > 1 || this.Condition12Number > 1 || this.Condition13Number > 1 || this.Condition14Number > 1 || this.Condition15Number > 1)
          {
            this.ErrorLabel.text = "Invalid Mission ID (One of those conditions should be 1 or 0)";
          }
          else
          {
            this.ErrorLabel.text = "Valid Mission ID!";
            this.Valid = true;
          }
        }
        else
          this.ErrorLabel.text = "Invalid Mission ID (Cannot be negative number)";
      }
      else if (Input.GetButtonDown("A"))
      {
        if (!this.Valid)
          return;
        Debug.Log((object) ("Target ID is: " + this.TargetNumber.ToString() + " and Weapon ID is: " + this.WeaponNumber.ToString()));
        this.TargetID = this.TargetNumber;
        this.Difficulty = 1;
        if (this.WeaponNumber > 0)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 2;
          this.CustomObjectives[2].alpha = 1f;
          this.RequiredWeaponID = this.WeaponNumber;
          this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[this.RequiredWeaponID];
        }
        else
        {
          this.CustomObjectives[2].alpha = 0.5f;
          this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
        }
        if (this.ClothingNumber > 0)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 3;
          this.CustomObjectives[3].alpha = 1f;
          this.RequiredClothingID = this.ClothingNumber;
          this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[this.RequiredClothingID];
        }
        else
        {
          this.CustomObjectives[3].alpha = 0.5f;
          this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
        }
        if (this.DisposalNumber > 0)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 4;
          this.CustomObjectives[4].alpha = 1f;
          this.RequiredDisposalID = this.DisposalNumber;
          this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[this.RequiredDisposalID];
        }
        else
        {
          this.CustomObjectives[4].alpha = 0.5f;
          this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
        }
        if (this.Difficulty < 10 && this.Condition5Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 5;
          this.CustomObjectives[5].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition6Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 6;
          this.CustomObjectives[7].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition7Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 7;
          this.CustomObjectives[8].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition8Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 8;
          this.CustomObjectives[9].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition9Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 9;
          this.CustomObjectives[10].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition10Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 10;
          this.CustomObjectives[11].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition11Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 11;
          this.CustomObjectives[13].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition12Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 12;
          this.CustomObjectives[14].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition13Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 13;
          this.CustomObjectives[15].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition14Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 14;
          this.CustomObjectives[16].alpha = 1f;
        }
        if (this.Difficulty < 10 && this.Condition15Number == 1)
        {
          ++this.Difficulty;
          this.Conditions[this.Difficulty] = 15;
          this.CustomObjectives[17].alpha = 1f;
        }
        this.NemesisDifficulty = this.NemesisNumber;
        SchoolGlobals.Population = this.PopulationNumber;
        this.Phase = 5;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Toggle";
        this.PromptBar.Label[1].text = "Return";
        this.PromptBar.Label[2].text = "Change";
        this.PromptBar.Label[3].text = "";
        this.PromptBar.Label[4].text = "Selection";
        this.PromptBar.Label[5].text = "Selection";
        this.PromptBar.UpdateButtons();
        this.UpdateObjectiveHighlight();
        this.UpdateNemesisDifficulty();
        this.UpdateDifficultyLabel();
        this.CalculateMissionID();
        this.ChooseTarget();
      }
      else
      {
        if (!Input.GetButtonDown("B"))
          return;
        Cursor.visible = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.TargetID = 0;
        this.Phase = 2;
      }
    }
  }

  private void GetNumbers()
  {
    this.TargetNumber = (int) char.GetNumericValue(this.MissionIDString[0]) * 10 + (int) char.GetNumericValue(this.MissionIDString[1]);
    this.WeaponNumber = (int) char.GetNumericValue(this.MissionIDString[2]) * 10 + (int) char.GetNumericValue(this.MissionIDString[3]);
    this.ClothingNumber = (int) char.GetNumericValue(this.MissionIDString[4]);
    this.DisposalNumber = (int) char.GetNumericValue(this.MissionIDString[5]);
    this.Condition5Number = (int) char.GetNumericValue(this.MissionIDString[6]);
    this.Condition6Number = (int) char.GetNumericValue(this.MissionIDString[7]);
    this.Condition7Number = (int) char.GetNumericValue(this.MissionIDString[8]);
    this.Condition8Number = (int) char.GetNumericValue(this.MissionIDString[9]);
    this.Condition9Number = (int) char.GetNumericValue(this.MissionIDString[10]);
    this.Condition10Number = (int) char.GetNumericValue(this.MissionIDString[11]);
    this.Condition11Number = (int) char.GetNumericValue(this.MissionIDString[12]);
    this.Condition12Number = (int) char.GetNumericValue(this.MissionIDString[13]);
    this.Condition13Number = (int) char.GetNumericValue(this.MissionIDString[14]);
    this.Condition14Number = (int) char.GetNumericValue(this.MissionIDString[15]);
    this.Condition15Number = (int) char.GetNumericValue(this.MissionIDString[16]);
    this.NemesisNumber = (int) char.GetNumericValue(this.MissionIDString[17]);
    this.PopulationNumber = (int) char.GetNumericValue(this.MissionIDString[18]);
  }

  private void LateUpdate()
  {
    if ((double) this.Speed > 3.0)
      this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * (this.Speed - 3f));
    this.Neck.transform.localEulerAngles = new Vector3(this.Neck.transform.localEulerAngles.x + this.Rotation, this.Neck.transform.localEulerAngles.y, this.Neck.transform.localEulerAngles.z);
  }

  private void UpdateHighlight()
  {
    if (this.Selected == 0)
    {
      this.Selected = 5;
    }
    else
    {
      if (this.Selected != 6)
        return;
      this.Selected = 1;
    }
  }

  private void ChooseTarget()
  {
    if (this.Phase != 5)
    {
      this.TargetID = Random.Range(2, 90);
      if (this.TargetNumber > 11 && this.TargetNumber < 21)
        this.ChooseTarget();
    }
    else
    {
      if (this.TargetNumber > 11 && this.TargetNumber < 21)
      {
        if (Input.GetButtonDown("A"))
          ++this.TargetID;
        else
          --this.TargetID;
        this.ChooseTarget();
      }
      if (this.TargetID > 89)
        this.TargetID = 2;
      else if (this.TargetID < 2)
        this.TargetID = 89;
    }
    WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + this.TargetID.ToString() + ".png");
    if (this.TargetNumber > 11 && this.TargetNumber < 21)
      this.TargetPortrait.mainTexture = this.BlankPortrait;
    else
      this.TargetPortrait.mainTexture = (Texture) www.texture;
    this.CustomTargetPortrait.mainTexture = this.TargetPortrait.mainTexture;
    this.TargetName = this.JSON.Students[this.TargetID].Name == "Random" || this.JSON.Students[this.TargetID].Name == "Unknown" ? this.StudentManager.FirstNames[Random.Range(0, this.StudentManager.FirstNames.Length)] + " " + this.StudentManager.LastNames[Random.Range(0, this.StudentManager.LastNames.Length)] : this.JSON.Students[this.TargetID].Name;
    this.CustomDescs[1].text = "Kill " + this.TargetName + ".";
    this.Descs[1].text = "Kill " + this.TargetName + ".";
    if (this.TargetID <= 11 || this.TargetID >= 21)
      return;
    if (this.Phase == 5)
      this.TargetID += Input.GetButtonDown("A") ? 1 : -1;
    this.ChooseTarget();
  }

  private void UpdateDifficulty()
  {
    if (this.Difficulty < 1)
      this.Difficulty = 1;
    else if (this.Difficulty > 10)
      this.Difficulty = 10;
    if (this.InputManager.TappedRight)
      this.PickNewCondition();
    else
      this.ErasePreviousCondition();
  }

  private void UpdateDifficultyLabel()
  {
    this.CustomDifficultyLabel.text = "Difficulty Level - " + this.Difficulty.ToString();
    this.DifficultyLabel.text = "Difficulty Level - " + this.Difficulty.ToString();
    string str1 = "Kill " + this.TargetName + ".";
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string empty3 = string.Empty;
    string str2 = this.RequiredWeaponID != 0 ? "You must kill the target with a " + this.WeaponNames[this.RequiredWeaponID] : "You can kill the target with any weapon.";
    string str3 = this.RequiredClothingID != 0 ? "You must kill the target while wearing " + this.ClothingNames[this.RequiredClothingID] : "You can kill the target wearing any clothing.";
    string str4 = this.RequiredDisposalID != 0 ? "You must dispose of the target's corpse by " + this.DisposalNames[this.RequiredDisposalID] : "It is not necessary to dispose of the target's corpse.";
    this.DescriptionLabel.text = str1 + "\n\n" + str2 + "\n\n" + str3 + "\n\n" + str4;
  }

  private void UpdateNemesisDifficulty()
  {
    if (this.NemesisDifficulty < 0)
      this.NemesisDifficulty = 4;
    else if (this.NemesisDifficulty > 4)
      this.NemesisDifficulty = 0;
    if (this.NemesisDifficulty == 0)
    {
      this.CustomNemesisLabel.text = "Nemesis: Off";
      this.NemesisLabel.text = "Nemesis: Off";
    }
    else
    {
      this.CustomNemesisLabel.text = "Nemesis: On";
      this.NemesisLabel.text = "Nemesis: On";
      this.NemesisPortrait.mainTexture = this.NemesisDifficulty > 2 ? this.BlankPortrait : this.NemesisGraphic;
    }
  }

  private void PickNewCondition()
  {
    int index1 = Random.Range(1, this.ConditionDescs.Length);
    this.Conditions[this.Difficulty] = index1;
    this.Descs[this.Difficulty].text = this.ConditionDescs[index1];
    this.Icons[this.Difficulty].mainTexture = this.ConditionIcons[index1];
    bool flag = false;
    for (int index2 = 2; index2 < this.Difficulty; ++index2)
    {
      if (index1 == this.Conditions[index2])
        flag = true;
    }
    if (flag)
      this.PickNewCondition();
    else if (index1 > 3)
    {
      this.Descs[this.Difficulty].text = this.ConditionDescs[index1];
    }
    else
    {
      switch (index1)
      {
        case 1:
          this.RequiredWeaponID = 11;
          while (this.RequiredWeaponID == 11)
            this.RequiredWeaponID = Random.Range(1, this.WeaponNames.Length);
          this.Descs[this.Difficulty].text = this.ConditionDescs[index1] + " " + this.WeaponNames[this.RequiredWeaponID];
          break;
        case 2:
          this.RequiredClothingID = Random.Range(1, this.ClothingNames.Length);
          this.Descs[this.Difficulty].text = this.ConditionDescs[index1] + " " + this.ClothingNames[this.RequiredClothingID];
          break;
        case 3:
          this.RequiredDisposalID = Random.Range(1, this.DisposalNames.Length);
          this.Descs[this.Difficulty].text = this.ConditionDescs[index1] + " " + this.DisposalNames[this.RequiredDisposalID];
          break;
      }
    }
    this.UpdateDifficultyLabel();
  }

  private void ErasePreviousCondition()
  {
    if (this.Conditions[this.Difficulty + 1] == 1)
      this.RequiredWeaponID = 0;
    else if (this.Conditions[this.Difficulty + 1] == 2)
      this.RequiredClothingID = 0;
    else if (this.Conditions[this.Difficulty + 1] == 3)
      this.RequiredDisposalID = 0;
    this.Conditions[this.Difficulty + 1] = 0;
    this.UpdateDifficultyLabel();
  }

  public void UpdateGraphics()
  {
    this.TargetID = MissionModeGlobals.MissionTarget;
    if (this.TargetNumber > 11 && this.TargetNumber < 21)
    {
      this.TargetPortrait.mainTexture = this.BlankPortrait;
      this.TargetName = MissionModeGlobals.MissionTargetName;
    }
    else
    {
      this.Icons[1].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + MissionModeGlobals.MissionTarget.ToString() + ".png").texture;
      this.TargetName = this.JSON.Students[MissionModeGlobals.MissionTarget].Name;
    }
    this.Descs[1].text = "Kill " + this.TargetName + ".";
    this.ChangeLabel(this.Descs[1]);
    for (int index = 2; index < this.Objectives.Length; ++index)
      this.Objectives[index].gameObject.SetActive(false);
    if (MissionModeGlobals.MissionDifficulty <= 1)
      return;
    for (int id = 2; id < MissionModeGlobals.MissionDifficulty + 1; ++id)
    {
      this.Objectives[id].gameObject.SetActive(true);
      this.Icons[id].mainTexture = this.ConditionIcons[MissionModeGlobals.GetMissionCondition(id)];
      this.ChangeLabel(this.Descs[id]);
      if (MissionModeGlobals.GetMissionCondition(id) > 3)
        this.Descs[id].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(id)];
      else if (MissionModeGlobals.GetMissionCondition(id) == 1)
      {
        this.RequiredWeaponID = 11;
        while (this.RequiredWeaponID == 11)
          this.RequiredWeaponID = Random.Range(1, this.WeaponNames.Length);
        this.Descs[id].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(id)] + " " + this.WeaponNames[MissionModeGlobals.MissionRequiredWeapon];
      }
      else if (MissionModeGlobals.GetMissionCondition(id) == 2)
      {
        this.RequiredClothingID = Random.Range(0, this.ClothingNames.Length);
        this.Descs[id].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(id)] + " " + this.ClothingNames[MissionModeGlobals.MissionRequiredClothing];
      }
      else if (MissionModeGlobals.GetMissionCondition(id) == 3)
      {
        this.RequiredDisposalID = Random.Range(1, this.DisposalNames.Length);
        this.Descs[id].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(id)] + " " + this.DisposalNames[MissionModeGlobals.MissionRequiredDisposal];
      }
    }
  }

  private void UpdatePopulation()
  {
    this.CustomPopulationLabel.text = "";
    this.PopulationLabel.text = "";
    OptionGlobals.HighPopulation = false;
  }

  private void UpdateObjectiveHighlight()
  {
    if (this.Row < 1)
      this.Row = 6;
    else if (this.Row > 6)
      this.Row = 1;
    else if (this.Column < 1)
      this.Column = 3;
    else if (this.Column > 3)
      this.Column = 1;
    if (this.Row == 6 && this.Column == 3)
      this.Column = 1;
    int num = 0;
    if (this.Row == 6)
      num = 75;
    this.PromptBar.Label[2].text = this.Column == 1 && this.Row < 5 || this.Column == 2 && this.Row == 6 ? "Change" : string.Empty;
    this.ObjectiveHighlight.localPosition = new Vector3((float) (650.0 * (double) this.Column - 1050.0), (float) (450.0 - 150.0 * (double) this.Row) - (float) num, this.ObjectiveHighlight.localPosition.z);
    this.CustomSelected = this.Row + (this.Column - 1) * 6;
    this.Toggling = false;
    if (this.CustomSelected == 1 || this.CustomSelected == 12)
      this.PromptBar.Label[0].text = "Forward";
    else if (this.CustomSelected == 6)
    {
      this.PromptBar.Label[0].text = "Start";
    }
    else
    {
      this.PromptBar.Label[0].text = "Toggle";
      this.Toggling = true;
    }
    this.PromptBar.Label[2].text = this.CustomSelected == 1 || this.CustomSelected == 12 ? "Backward" : (this.CustomSelected <= 4 ? "Change" : string.Empty);
    this.PromptBar.UpdateButtons();
  }

  private void CalculateMissionID()
  {
    this.TargetString = (this.TargetID < 10 ? "0" : "") + this.TargetID.ToString();
    this.WeaponString = (double) this.CustomObjectives[2].alpha != 1.0 ? "00" : (this.RequiredWeaponID < 10 ? "0" : "") + this.RequiredWeaponID.ToString();
    this.ClothingString = (double) this.CustomObjectives[3].alpha == 1.0 ? this.RequiredClothingID.ToString() : "0";
    this.DisposalString = (double) this.CustomObjectives[4].alpha == 1.0 ? this.RequiredDisposalID.ToString() : "0";
    for (int index = 1; index < this.CustomObjectives.Length; ++index)
    {
      if ((Object) this.CustomObjectives[index] != (Object) null)
        this.ConditionString[index] = (double) this.CustomObjectives[index].alpha == 1.0 ? "1" : "0";
    }
    this.MissionID = this.TargetString + this.WeaponString + this.ClothingString + this.DisposalString + this.ConditionString[5] + this.ConditionString[6] + this.ConditionString[7] + this.ConditionString[8] + this.ConditionString[9] + this.ConditionString[10] + this.ConditionString[11] + this.ConditionString[12] + this.ConditionString[13] + this.ConditionString[14] + this.ConditionString[15] + this.ConditionString[16] + this.ConditionString[17] + this.NemesisDifficulty.ToString() + "0";
    this.MissionIDLabel.text = this.MissionID;
  }

  private void StartMission()
  {
    this.MyAudio.PlayOneShot(this.InfoLines[6]);
    Debug.Log((object) "Switching GameGlobals.Profile to 4, since we are beginning a Mission Mode mission, and nothing we do in here should carry over to any of the player's other save files.");
    GameGlobals.Profile = 4;
    Globals.DeleteAll();
    OptionGlobals.TutorialsOff = true;
    SchoolGlobals.SchoolAtmosphere = (float) (1.0 - (double) this.Difficulty * 0.10000000149011612);
    MissionModeGlobals.NemesisDifficulty = this.NemesisDifficulty;
    MissionModeGlobals.MissionTargetName = this.TargetName;
    MissionModeGlobals.MissionDifficulty = this.Difficulty;
    MissionModeGlobals.MissionTarget = this.TargetID;
    SchoolGlobals.SchoolAtmosphereSet = true;
    MissionModeGlobals.MissionMode = true;
    ClassGlobals.BiologyGrade = 1;
    ClassGlobals.ChemistryGrade = 1;
    ClassGlobals.LanguageGrade = 1;
    ClassGlobals.PhysicalGrade = 1;
    ClassGlobals.PsychologyGrade = 1;
    if (this.Difficulty > 1)
    {
      for (int id = 2; id < this.Difficulty + 1; ++id)
      {
        if (this.Conditions[id] == 1)
          MissionModeGlobals.MissionRequiredWeapon = this.RequiredWeaponID;
        else if (this.Conditions[id] == 2)
          MissionModeGlobals.MissionRequiredClothing = this.RequiredClothingID;
        else if (this.Conditions[id] == 3)
          MissionModeGlobals.MissionRequiredDisposal = this.RequiredDisposalID;
        MissionModeGlobals.SetMissionCondition(id, this.Conditions[id]);
      }
    }
    this.PromptBar.Show = false;
    this.Speed = 0.0f;
    this.Phase = 4;
  }

  private void ChangeFont()
  {
    foreach (UILabel uiLabel in Object.FindObjectsOfType<UILabel>())
    {
      uiLabel.trueTypeFont = this.Arial;
      uiLabel.fontSize += 10;
      if (uiLabel.height == 150)
        uiLabel.height = 100;
    }
  }

  private void ChangeLabel(UILabel Text) => Text.trueTypeFont = this.Arial;
}
