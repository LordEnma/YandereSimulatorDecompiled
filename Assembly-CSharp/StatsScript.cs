// Decompiled with JetBrains decompiler
// Type: StatsScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.IO;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
  public PauseScreenScript PauseScreen;
  public PromptBarScript PromptBar;
  public ClassScript Class;
  public UISprite[] Subject1Bars;
  public UISprite[] Subject2Bars;
  public UISprite[] Subject3Bars;
  public UISprite[] Subject4Bars;
  public UISprite[] Subject5Bars;
  public UISprite[] Subject6Bars;
  public UISprite[] Subject7Bars;
  public UISprite[] Subject8Bars;
  public UILabel[] Ranks;
  public UILabel ClubLabel;
  public int Grade;
  public int BarID;
  public UITexture Portrait;
  public Texture RyobaPortrait;
  private ClubTypeAndStringDictionary ClubLabels;

  private void Awake()
  {
    ClubTypeAndStringDictionary stringDictionary = new ClubTypeAndStringDictionary();
    stringDictionary.Add(ClubType.None, "None");
    stringDictionary.Add(ClubType.Cooking, "Cooking");
    stringDictionary.Add(ClubType.Drama, "Drama");
    stringDictionary.Add(ClubType.Occult, "Occult");
    stringDictionary.Add(ClubType.Art, "Art");
    stringDictionary.Add(ClubType.LightMusic, "Light Music");
    stringDictionary.Add(ClubType.MartialArts, "Martial Arts");
    stringDictionary.Add(ClubType.Photography, "Photography");
    stringDictionary.Add(ClubType.Science, "Science");
    stringDictionary.Add(ClubType.Sports, "Sports");
    stringDictionary.Add(ClubType.Gardening, "Gardening");
    stringDictionary.Add(ClubType.Gaming, "Gaming");
    this.ClubLabels = stringDictionary;
  }

  private void Start()
  {
    if (this.PauseScreen.Eighties)
      this.Portrait.mainTexture = this.RyobaPortrait;
    if (!File.Exists(Application.streamingAssetsPath + "/CustomPortrait.txt") || !(File.ReadAllText(Application.streamingAssetsPath + "/CustomPortrait.txt") == "1"))
      return;
    this.Portrait.mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/CustomPortrait.png").texture;
  }

  private void Update()
  {
    if (!Input.GetButtonDown("B"))
      return;
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Accept";
    this.PromptBar.Label[1].text = "Exit";
    this.PromptBar.Label[4].text = "Choose";
    this.PromptBar.UpdateButtons();
    this.PauseScreen.MainMenu.SetActive(true);
    this.PauseScreen.Sideways = false;
    this.PauseScreen.PressedB = true;
    this.gameObject.SetActive(false);
  }

  public void UpdateStats()
  {
    Debug.Log((object) "The Stats script just checked the Class script for info and updated the bars accordingly.");
    this.Grade = this.Class.BiologyGrade;
    for (this.BarID = 1; this.BarID < 6; ++this.BarID)
    {
      UISprite subject1Bar = this.Subject1Bars[this.BarID];
      if (this.Grade > 0)
      {
        subject1Bar.color = new Color(1f, 1f, 1f, 1f);
        --this.Grade;
      }
      else
        subject1Bar.color = new Color(1f, 1f, 1f, 0.5f);
    }
    if (this.Class.BiologyGrade < 5)
      this.Subject1Bars[this.Class.BiologyGrade + 1].color = this.Class.BiologyBonus > 0 ? new Color(1f, 0.0f, 0.0f, 1f) : new Color(1f, 1f, 1f, 0.5f);
    this.Grade = this.Class.ChemistryGrade;
    for (this.BarID = 1; this.BarID < 6; ++this.BarID)
    {
      UISprite subject2Bar = this.Subject2Bars[this.BarID];
      if (this.Grade > 0)
      {
        subject2Bar.color = new Color(subject2Bar.color.r, subject2Bar.color.g, subject2Bar.color.b, 1f);
        --this.Grade;
      }
      else
        subject2Bar.color = new Color(subject2Bar.color.r, subject2Bar.color.g, subject2Bar.color.b, 0.5f);
    }
    if (this.Class.ChemistryGrade < 5)
      this.Subject2Bars[this.Class.ChemistryGrade + 1].color = this.Class.ChemistryBonus > 0 ? new Color(1f, 0.0f, 0.0f, 1f) : new Color(1f, 1f, 1f, 0.5f);
    this.Grade = this.Class.LanguageGrade;
    for (this.BarID = 1; this.BarID < 6; ++this.BarID)
    {
      UISprite subject3Bar = this.Subject3Bars[this.BarID];
      if (this.Grade > 0)
      {
        subject3Bar.color = new Color(subject3Bar.color.r, subject3Bar.color.g, subject3Bar.color.b, 1f);
        --this.Grade;
      }
      else
        subject3Bar.color = new Color(subject3Bar.color.r, subject3Bar.color.g, subject3Bar.color.b, 0.5f);
    }
    if (this.Class.LanguageGrade < 5)
      this.Subject3Bars[this.Class.LanguageGrade + 1].color = this.Class.LanguageBonus > 0 ? new Color(1f, 0.0f, 0.0f, 1f) : new Color(1f, 1f, 1f, 0.5f);
    this.Grade = this.Class.PhysicalGrade;
    for (this.BarID = 1; this.BarID < 6; ++this.BarID)
    {
      UISprite subject4Bar = this.Subject4Bars[this.BarID];
      if (this.Grade > 0)
      {
        subject4Bar.color = new Color(subject4Bar.color.r, subject4Bar.color.g, subject4Bar.color.b, 1f);
        --this.Grade;
      }
      else
        subject4Bar.color = new Color(subject4Bar.color.r, subject4Bar.color.g, subject4Bar.color.b, 0.5f);
    }
    if (this.Class.PhysicalGrade < 5)
      this.Subject4Bars[this.Class.PhysicalGrade + 1].color = this.Class.PhysicalBonus > 0 ? new Color(1f, 0.0f, 0.0f, 1f) : new Color(1f, 1f, 1f, 0.5f);
    this.Grade = this.Class.PsychologyGrade;
    for (this.BarID = 1; this.BarID < 6; ++this.BarID)
    {
      UISprite subject5Bar = this.Subject5Bars[this.BarID];
      if (this.Grade > 0)
      {
        subject5Bar.color = new Color(subject5Bar.color.r, subject5Bar.color.g, subject5Bar.color.b, 1f);
        --this.Grade;
      }
      else
        subject5Bar.color = new Color(subject5Bar.color.r, subject5Bar.color.g, subject5Bar.color.b, 0.5f);
    }
    if (this.Class.PsychologyGrade < 5)
      this.Subject5Bars[this.Class.PsychologyGrade + 1].color = this.Class.PsychologyBonus > 0 ? new Color(1f, 0.0f, 0.0f, 1f) : new Color(1f, 1f, 1f, 0.5f);
    this.Grade = this.Class.Seduction;
    for (this.BarID = 1; this.BarID < 6; ++this.BarID)
    {
      UISprite subject6Bar = this.Subject6Bars[this.BarID];
      if (this.Grade > 0)
      {
        subject6Bar.color = new Color(subject6Bar.color.r, subject6Bar.color.g, subject6Bar.color.b, 1f);
        --this.Grade;
      }
      else
        subject6Bar.color = new Color(subject6Bar.color.r, subject6Bar.color.g, subject6Bar.color.b, 0.5f);
    }
    if (this.Class.Seduction < 5)
      this.Subject6Bars[this.Class.Seduction + 1].color = this.Class.SeductionBonus > 0 ? new Color(1f, 0.0f, 0.0f, 1f) : new Color(1f, 1f, 1f, 0.5f);
    this.Grade = this.Class.Numbness;
    for (this.BarID = 1; this.BarID < 6; ++this.BarID)
    {
      UISprite subject7Bar = this.Subject7Bars[this.BarID];
      if (this.Grade > 0)
      {
        subject7Bar.color = new Color(subject7Bar.color.r, subject7Bar.color.g, subject7Bar.color.b, 1f);
        --this.Grade;
      }
      else
        subject7Bar.color = new Color(subject7Bar.color.r, subject7Bar.color.g, subject7Bar.color.b, 0.5f);
    }
    if (this.Class.Numbness < 5)
      this.Subject7Bars[this.Class.Numbness + 1].color = this.Class.NumbnessBonus > 0 ? new Color(1f, 0.0f, 0.0f, 1f) : new Color(1f, 1f, 1f, 0.5f);
    this.Grade = this.Class.Enlightenment;
    for (this.BarID = 1; this.BarID < 6; ++this.BarID)
    {
      UISprite subject8Bar = this.Subject8Bars[this.BarID];
      if (this.Grade > 0)
      {
        subject8Bar.color = new Color(subject8Bar.color.r, subject8Bar.color.g, subject8Bar.color.b, 1f);
        --this.Grade;
      }
      else
        subject8Bar.color = new Color(subject8Bar.color.r, subject8Bar.color.g, subject8Bar.color.b, 0.5f);
    }
    if (this.Class.Enlightenment < 5)
      this.Subject8Bars[this.Class.Enlightenment + 1].color = this.Class.EnlightenmentBonus > 0 ? new Color(1f, 0.0f, 0.0f, 1f) : new Color(1f, 1f, 1f, 0.5f);
    this.Ranks[1].text = "Rank: " + this.Class.BiologyGrade.ToString();
    this.Ranks[2].text = "Rank: " + this.Class.ChemistryGrade.ToString();
    this.Ranks[3].text = "Rank: " + this.Class.LanguageGrade.ToString();
    this.Ranks[4].text = "Rank: " + this.Class.PhysicalGrade.ToString();
    this.Ranks[5].text = "Rank: " + this.Class.PsychologyGrade.ToString();
    this.Ranks[6].text = "Rank: " + this.Class.Seduction.ToString();
    this.Ranks[7].text = "Rank: " + this.Class.Numbness.ToString();
    this.Ranks[8].text = "Rank: " + this.Class.Enlightenment.ToString();
    string str;
    this.ClubLabels.TryGetValue(this.PauseScreen.Yandere.Club, out str);
    this.ClubLabel.text = "Club: " + str;
  }
}
