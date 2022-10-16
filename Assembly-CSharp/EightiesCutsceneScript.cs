// Decompiled with JetBrains decompiler
// Type: EightiesCutsceneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EightiesCutsceneScript : MonoBehaviour
{
  public GameObject SkipTutorialButton;
  public GameObject SkipTutorialWindow;
  public GameObject Panel;
  public TypewriterEffect Typewriter;
  public UITexture Silhouette;
  public AudioSource MyAudio;
  public AudioSource BGM;
  public UISprite Darkness;
  public UILabel Label;
  public Texture[] RivalSilhouettes;
  public string[] Lines;
  public string[] CutsceneLines1;
  public string[] CutsceneLines2;
  public string[] CutsceneLines3;
  public string[] CutsceneLines4;
  public string[] CutsceneLines5;
  public string[] CutsceneLines6;
  public string[] CutsceneLines7;
  public string[] CutsceneLines8;
  public string[] CutsceneLines9;
  public string[] CutsceneLines10;
  public string[] CutsceneLines11;
  public string[] FinalCutsceneLines;
  public AudioClip[] Clips;
  public AudioClip[] CutsceneClips1;
  public AudioClip[] CutsceneClips2;
  public AudioClip[] CutsceneClips3;
  public AudioClip[] CutsceneClips4;
  public AudioClip[] CutsceneClips5;
  public AudioClip[] CutsceneClips6;
  public AudioClip[] CutsceneClips7;
  public AudioClip[] CutsceneClips8;
  public AudioClip[] CutsceneClips9;
  public AudioClip[] CutsceneClips10;
  public AudioClip[] CutsceneClips11;
  public AudioClip[] FinalCutsceneClips;
  public float Speed;
  public int RivalLine;
  public int DarkLine;
  public int Phase;
  public int ID;
  public string[] EliminationNames;
  public string[] EliminationDetails;
  public bool SkipTutorial;

  private void Start()
  {
    GameGlobals.Eighties = true;
    if (GameGlobals.EightiesCutsceneID < 2)
      this.Darkness.color = new Color(1f, 1f, 1f, 1f);
    else
      this.Darkness.color = new Color(0.1f, 0.1f, 0.1f, 1f);
    this.Typewriter.gameObject.SetActive(false);
    if (GameGlobals.EightiesCutsceneID == 0)
      this.DarkLine = 13;
    if (GameGlobals.EightiesCutsceneID == 1)
    {
      this.Lines = this.CutsceneLines1;
      this.Clips = this.CutsceneClips1;
      this.DarkLine = 10;
      this.RivalLine = 10;
      this.Silhouette.mainTexture = this.RivalSilhouettes[1];
    }
    if (GameGlobals.EightiesCutsceneID == 2)
    {
      this.Lines = this.CutsceneLines2;
      this.Clips = this.CutsceneClips2;
      this.DarkLine = 13;
      this.RivalLine = 3;
      this.Silhouette.mainTexture = this.RivalSilhouettes[2];
    }
    if (GameGlobals.EightiesCutsceneID == 3)
    {
      this.Lines = this.CutsceneLines3;
      this.Clips = this.CutsceneClips3;
      this.DarkLine = 13;
      this.RivalLine = 3;
      this.Silhouette.mainTexture = this.RivalSilhouettes[3];
    }
    if (GameGlobals.EightiesCutsceneID == 4)
    {
      this.Lines = this.CutsceneLines4;
      this.Clips = this.CutsceneClips4;
      this.DarkLine = 12;
      this.RivalLine = 3;
      this.Silhouette.mainTexture = this.RivalSilhouettes[4];
    }
    if (GameGlobals.EightiesCutsceneID == 5)
    {
      this.Lines = this.CutsceneLines5;
      this.Clips = this.CutsceneClips5;
      this.DarkLine = 11;
      this.RivalLine = 2;
      this.Silhouette.mainTexture = this.RivalSilhouettes[5];
    }
    if (GameGlobals.EightiesCutsceneID == 6)
    {
      this.Lines = this.CutsceneLines6;
      this.Clips = this.CutsceneClips6;
      this.DarkLine = 12;
      this.RivalLine = 2;
      this.Silhouette.mainTexture = this.RivalSilhouettes[6];
    }
    if (GameGlobals.EightiesCutsceneID == 7)
    {
      this.Lines = this.CutsceneLines7;
      this.Clips = this.CutsceneClips7;
      this.DarkLine = 9;
      this.RivalLine = 3;
      this.Silhouette.mainTexture = this.RivalSilhouettes[7];
    }
    if (GameGlobals.EightiesCutsceneID == 8)
    {
      this.Lines = this.CutsceneLines8;
      this.Clips = this.CutsceneClips8;
      this.DarkLine = 14;
      this.RivalLine = 11;
      this.Silhouette.mainTexture = this.RivalSilhouettes[8];
    }
    if (GameGlobals.EightiesCutsceneID == 9)
    {
      this.Lines = this.CutsceneLines9;
      this.Clips = this.CutsceneClips9;
      this.DarkLine = 12;
      this.RivalLine = 8;
      this.Silhouette.mainTexture = this.RivalSilhouettes[9];
    }
    if (GameGlobals.EightiesCutsceneID == 10)
    {
      this.Lines = this.CutsceneLines10;
      this.Clips = this.CutsceneClips10;
      this.DarkLine = 0;
      this.RivalLine = 9;
      this.Silhouette.mainTexture = this.RivalSilhouettes[10];
    }
    if (GameGlobals.EightiesCutsceneID == 11)
    {
      this.Lines = this.CutsceneLines11;
      this.Clips = this.CutsceneClips11;
      this.DarkLine = 99;
      this.RivalLine = 99;
      this.Silhouette.mainTexture = this.RivalSilhouettes[10];
    }
    if (GameGlobals.EightiesCutsceneID == 12)
    {
      this.Lines = this.FinalCutsceneLines;
      this.Clips = this.FinalCutsceneClips;
      this.DarkLine = 99;
      this.RivalLine = 99;
      this.Silhouette.mainTexture = this.RivalSilhouettes[10];
    }
    this.Silhouette.alpha = 0.0f;
    if (GameGlobals.EightiesCutsceneID > 0)
      this.SkipTutorialButton.SetActive(false);
    Time.timeScale = 1f;
  }

  private void Update()
  {
    if (this.Phase < 3)
      this.BGM.volume = Mathf.MoveTowards(this.BGM.volume, 0.1f, Time.deltaTime * 0.1f);
    if (this.DarkLine == 0)
      this.BGM.pitch = 0.1f;
    else if (this.ID >= this.DarkLine)
      this.BGM.pitch = Mathf.MoveTowards(this.BGM.pitch, 0.9f, Time.deltaTime * 0.1f);
    if (this.RivalLine > 0 && this.ID >= this.RivalLine)
    {
      this.Speed += Time.deltaTime;
      this.Label.transform.localPosition = Vector3.Lerp(this.Label.transform.localPosition, new Vector3(-800f, 360f, 0.0f), Time.deltaTime * this.Speed);
      this.Silhouette.alpha = Mathf.MoveTowards(this.Silhouette.alpha, 1f, Time.deltaTime);
    }
    if (this.Phase == 0)
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime);
      if ((double) this.Darkness.alpha != 0.0)
        return;
      this.Typewriter.gameObject.SetActive(true);
      this.Typewriter.ResetToBeginning();
      this.Label.text = "";
      this.Typewriter.mFullText = this.Lines[this.ID];
      this.MyAudio.clip = this.Clips[this.ID];
      this.MyAudio.Play();
      ++this.Phase;
    }
    else if (this.Phase == 1)
    {
      if (!this.SkipTutorialWindow.activeInHierarchy)
      {
        if (Input.GetButtonDown("A"))
        {
          if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
          {
            this.Typewriter.Finish();
          }
          else
          {
            ++this.ID;
            if (this.ID < this.Lines.Length)
            {
              this.Typewriter.ResetToBeginning();
              this.Label.text = "";
              this.Typewriter.mFullText = this.Lines[this.ID];
              this.MyAudio.clip = this.Clips[this.ID];
              this.MyAudio.Play();
            }
            else
            {
              this.Typewriter.enabled = false;
              ++this.Phase;
            }
          }
        }
        else if (Input.GetButtonDown("X"))
        {
          ++this.Phase;
        }
        else
        {
          if (!Input.GetButtonDown("Y") || !this.SkipTutorialButton.activeInHierarchy)
            return;
          this.SkipTutorialWindow.SetActive(true);
          this.Panel.SetActive(false);
        }
      }
      else if (Input.GetButtonDown("A"))
      {
        this.SkipTutorialWindow.SetActive(false);
        this.Panel.SetActive(true);
        ++this.Phase;
        this.SkipTutorial = true;
      }
      else
      {
        if (!Input.GetButtonDown("B"))
          return;
        this.SkipTutorialWindow.SetActive(false);
        this.Panel.SetActive(true);
      }
    }
    else if (this.Phase == 2)
    {
      if (GameGlobals.EightiesCutsceneID > 0)
        this.Darkness.color = new Color(0.1f, 0.1f, 0.1f, 0.0f);
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 3)
        return;
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime);
      this.MyAudio.volume = Mathf.MoveTowards(this.MyAudio.volume, 0.0f, Time.deltaTime);
      this.BGM.volume = Mathf.MoveTowards(this.BGM.volume, 0.0f, Time.deltaTime * 0.1f);
      if ((double) this.Darkness.alpha != 1.0)
        return;
      if (this.SkipTutorial)
      {
        GameGlobals.EightiesTutorial = false;
        GameGlobals.EightiesCutsceneID = 1;
        OptionGlobals.Fog = false;
        SceneManager.LoadScene("EightiesCutsceneScene");
      }
      else if (GameGlobals.EightiesCutsceneID == 0)
      {
        SceneManager.LoadScene("LoadingScene");
      }
      else
      {
        GameGlobals.Eighties = true;
        if (GameGlobals.EightiesCutsceneID > 1)
        {
          if (GameGlobals.RivalEliminationID == 0)
            GameGlobals.RivalEliminationID = 1;
          GameGlobals.SetRivalEliminations(DateGlobals.Week, GameGlobals.RivalEliminationID);
          GameGlobals.SetSpecificEliminations(DateGlobals.Week, GameGlobals.SpecificEliminationID);
          GameGlobals.RivalEliminationID = 0;
          GameGlobals.SpecificEliminationID = 0;
          DateGlobals.Week = GameGlobals.EightiesCutsceneID;
        }
        EventGlobals.LearnedAboutPhotographer = false;
        SchemeGlobals.EmbarassingSecret = false;
        CounselorGlobals.ReportedAlcohol = false;
        CounselorGlobals.ReportedCheating = false;
        CounselorGlobals.ReportedCigarettes = false;
        CounselorGlobals.ReportedCondoms = false;
        CounselorGlobals.ReportedTheft = false;
        SchemeGlobals.SetSchemeStage(6, 0);
        StudentGlobals.ExpelProgress = 0;
        DatingGlobals.RivalSabotaged = 0;
        DatingGlobals.SuitorProgress = 0;
        DatingGlobals.Affection = 0.0f;
        StudentGlobals.CustomSuitor = false;
        StudentGlobals.CustomSuitorHair = 0;
        StudentGlobals.CustomSuitorAccessory = 0;
        StudentGlobals.CustomSuitorBlack = false;
        StudentGlobals.CustomSuitorJewelry = 0;
        StudentGlobals.CustomSuitorEyewear = 0;
        StudentGlobals.CustomSuitorTan = false;
        for (int topicID = 1; topicID < 26; ++topicID)
          DatingGlobals.SetTopicDiscussed(topicID, false);
        for (int complimentID = 1; complimentID < 11; ++complimentID)
          DatingGlobals.SetComplimentGiven(complimentID, false);
        for (int traitID = 1; traitID < 4; ++traitID)
        {
          DatingGlobals.SetTraitDemonstrated(traitID, 0);
          DatingGlobals.SetSuitorTrait(traitID, 0);
        }
        for (int giftID = 1; giftID < 5; ++giftID)
          CollectibleGlobals.SetGiftGiven(giftID, false);
        DateGlobals.Weekday = DayOfWeek.Sunday;
        if (DateGlobals.Week == 1)
          DateGlobals.PassDays = 1;
        ClubGlobals.ActivitiesAttended = 0;
        if (DateGlobals.Week < 11)
        {
          this.Save();
          SceneManager.LoadScene("CalendarScene");
        }
        else if (GameGlobals.EightiesCutsceneID == 12)
          SceneManager.LoadScene("GenocideScene");
        else
          SceneManager.LoadScene("LoadingScene");
      }
    }
  }

  private void Save()
  {
    int profile = GameGlobals.Profile;
    int num = 11;
    Debug.Log((object) ("Current profile is: " + profile.ToString()));
    YanSave.SaveData("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
    Debug.Log((object) ("Saved current state of the game to Slot #" + num.ToString()));
  }
}
