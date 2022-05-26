// Decompiled with JetBrains decompiler
// Type: CalendarScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.IO;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class CalendarScript : MonoBehaviour
{
  public PostProcessingProfile NewTitleScreenProfile;
  public SelectiveGrayscale GrayscaleEffect;
  public ChallengeScript Challenge;
  public Vignetting Vignette;
  public GameObject SkipConfirmationWindow;
  public GameObject CongratulationsWindow;
  public GameObject ConfirmationWindow;
  public GameObject ResetWeekWindow;
  public GameObject AmaiWindow;
  public GameObject DeadlineLabel;
  public GameObject StatsButton;
  public GameObject AmaiButton;
  public GameObject SkipButton;
  public UILabel AtmosphereLabel;
  public UIPanel ChallengePanel;
  public UIPanel CalendarPanel;
  public UISprite Darkness;
  public UITexture Cloud;
  public UITexture Sun;
  public Transform Highlight;
  public Transform Continue;
  public UILabel[] DayNumber;
  public UILabel[] DayLabel;
  public UILabel MonthLabel;
  public UILabel WeekNumber;
  public UILabel YearLabel;
  public UILabel SkipLabel;
  public bool CameFromTitleScreen;
  public bool ViewingStats;
  public bool Incremented;
  public bool ResetWeek;
  public bool Eighties;
  public bool LoveSick;
  public bool Skipping;
  public bool FadeOut;
  public bool Switch;
  public bool Reset;
  public float Timer;
  public float Target;
  public float Offset = 66.66666f;
  public int Adjustment;
  public int Phase = 1;
  public AudioClip EightiesJingle;
  public UILabel[] Labels;
  public GameObject SundayLabel;
  public GameObject EndingLabel;
  public Font VCR;

  private void Start()
  {
    this.NewTitleScreenProfile.colorGrading.enabled = false;
    this.SetVignettePink();
    PlayerGlobals.BringingItem = 0;
    if (GameGlobals.RivalEliminationID == 0 && StudentGlobals.GetStudentDead(10 + DateGlobals.Week))
    {
      Debug.Log((object) "Upon entering the Calendar screen, the rival was dead, but RivalEliminationID was 0. Setting it to 1.");
      GameGlobals.RivalEliminationID = 1;
    }
    if (DateGlobals.Week == 0)
    {
      Debug.Log((object) "Save file had to be deleted because Week was '0''.");
      this.ResetSaveFile();
    }
    else if (GameGlobals.Eighties)
    {
      switch (DateGlobals.Week)
      {
        case 1:
          Debug.Log((object) "Rival is cute.");
          break;
        case 2:
          Debug.Log((object) "Rival is pryomaniac.");
          break;
        case 3:
          Debug.Log((object) "Rival is bookworm.");
          break;
        case 4:
          Debug.Log((object) "Rival is sporty.");
          break;
        case 5:
          Debug.Log((object) "Rival is rich.");
          break;
        case 6:
          Debug.Log((object) "Rival is idol.");
          break;
        case 7:
          Debug.Log((object) "Rival is prodigy.");
          break;
        case 8:
          Debug.Log((object) "Rival is traditional.");
          break;
        case 9:
          Debug.Log((object) "Rival is gravure.");
          break;
        case 10:
          Debug.Log((object) "Rival is investigator.");
          break;
      }
      for (int ID = 1; ID < 11; ++ID)
        PlayerGlobals.SetShrineCollectible(ID, true);
    }
    else if (DateGlobals.Week > 2)
    {
      Debug.Log((object) "Save file had to be deleted because 80s and 202X got mixed up.");
      this.ResetSaveFile();
    }
    this.LoveSickCheck();
    if (!ConversationGlobals.GetTopicDiscovered(1))
    {
      for (int topicID = 1; topicID < 26; ++topicID)
        ConversationGlobals.SetTopicDiscovered(topicID, true);
    }
    if (!SchoolGlobals.SchoolAtmosphereSet)
    {
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.SchoolAtmosphere = 1f;
      PlayerGlobals.Money = 10f;
      PlayerGlobals.SetCannotBringItem(4, true);
      PlayerGlobals.SetCannotBringItem(5, true);
      PlayerGlobals.SetCannotBringItem(6, true);
      PlayerGlobals.SetCannotBringItem(7, true);
    }
    if (DateGlobals.PassDays > 0 && !SchoolGlobals.HighSecurity && (double) SchoolGlobals.SchoolAtmosphere >= (double) SchoolGlobals.PreviousSchoolAtmosphere)
      SchoolGlobals.SchoolAtmosphere += 0.05f;
    this.ImproveSchoolAtmosphere();
    DateGlobals.DayPassed = true;
    this.Continue.transform.localPosition = new Vector3(this.Continue.transform.localPosition.x, -610f, this.Continue.transform.localPosition.z);
    this.ChallengePanel.alpha = 0.0f;
    this.CalendarPanel.alpha = 1f;
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
    Time.timeScale = 1f;
    if (GameGlobals.RivalEliminationID > 0)
      this.DeadlineLabel.SetActive(false);
    this.WeekNumber.text = "WEEK " + DateGlobals.Week.ToString();
    this.LoveSickCheck();
    this.ChangeDayColor();
    if (GameGlobals.Eighties)
    {
      this.BecomeEighties();
    }
    else
    {
      this.AmaiButton.SetActive(false);
      this.StatsButton.SetActive(false);
      this.SkipButton.transform.localPosition = new Vector3(-120f, -500f, 0.0f);
      switch (DateGlobals.Week)
      {
        case 1:
          this.DayNumber[1].text = "2";
          this.DayNumber[2].text = "3";
          this.DayNumber[3].text = "4";
          this.DayNumber[4].text = "5";
          this.DayNumber[5].text = "6";
          this.DayNumber[6].text = "7";
          this.DayNumber[7].text = "8";
          this.Adjustment = -50;
          break;
        case 2:
          this.DayNumber[1].text = "9";
          this.DayNumber[2].text = "10";
          this.DayNumber[3].text = "11";
          this.DayNumber[4].text = "12";
          this.DayNumber[5].text = "13";
          this.DayNumber[6].text = "14";
          this.DayNumber[7].text = "15";
          this.Adjustment = -50;
          this.AmaiButton.SetActive(true);
          break;
      }
    }
    this.Highlight.localPosition = new Vector3((float) ((double) this.Offset - 750.0 + 250.0 * (double) DateGlobals.Weekday) + (float) this.Adjustment, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
    if (DateGlobals.Weekday == DayOfWeek.Saturday)
      this.Highlight.localPosition = new Vector3(-1150f, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
    if (!GameGlobals.CameFromTitleScreen)
      return;
    GameGlobals.CameFromTitleScreen = false;
    this.CameFromTitleScreen = true;
  }

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if (!this.FadeOut)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
      if ((double) this.Darkness.color.a < 0.0)
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0.0f);
      if ((double) this.Timer > 1.0)
      {
        if (!this.Incremented)
        {
          if (DateGlobals.PassDays > 0)
          {
            if (this.Eighties)
            {
              this.GetComponent<AudioSource>().clip = this.EightiesJingle;
              this.GetComponent<AudioSource>().volume = 0.25f;
            }
            this.GetComponent<AudioSource>().pitch = (float) (1.0 - (0.800000011920929 - (double) SchoolGlobals.SchoolAtmosphere * 0.800000011920929));
            this.GetComponent<AudioSource>().Play();
          }
          if (DateGlobals.Weekday != DayOfWeek.Friday || this.Skipping)
          {
            bool flag = false;
            if (DateGlobals.Week == 1 && DateGlobals.Weekday == DayOfWeek.Sunday || DateGlobals.ForceSkip)
            {
              DateGlobals.ForceSkip = false;
              this.SundayLabel.SetActive(false);
              flag = true;
            }
            for (; flag || DateGlobals.PassDays > 0 && DateGlobals.Weekday != DayOfWeek.Saturday && DateGlobals.Weekday != DayOfWeek.Sunday; flag = false)
            {
              ++DateGlobals.GameplayDay;
              --DateGlobals.PassDays;
              ++DateGlobals.Weekday;
              this.ChangeDayColor();
            }
            this.Skipping = false;
          }
          else if (!this.CameFromTitleScreen)
          {
            ++DateGlobals.GameplayDay;
            --DateGlobals.PassDays;
            ++DateGlobals.Weekday;
            this.ChangeDayColor();
          }
          this.Target = 250f * (float) DateGlobals.Weekday + (float) this.Adjustment;
          if (DateGlobals.Weekday > DayOfWeek.Saturday)
          {
            this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            DateGlobals.Weekday = DayOfWeek.Sunday;
            this.Target = (float) this.Adjustment;
          }
          if (!this.Eighties && DateGlobals.Weekday != DayOfWeek.Sunday && DateGlobals.Weekday < DayOfWeek.Saturday && GameGlobals.RivalEliminationID > 0 && !GameGlobals.InformedAboutSkipping && DateGlobals.Week < 2)
          {
            GameGlobals.InformedAboutSkipping = true;
            this.CongratulationsWindow.SetActive(true);
          }
          this.Incremented = true;
          this.ChangeDayColor();
        }
        this.Continue.localPosition = new Vector3(this.Continue.localPosition.x, Mathf.Lerp(this.Continue.localPosition.y, -500f, Time.deltaTime * 10f), this.Continue.localPosition.z);
        if (!this.Switch)
        {
          if (this.ViewingStats)
          {
            if (Input.GetButtonDown("B"))
              this.Switch = true;
          }
          else if (this.CongratulationsWindow.activeInHierarchy)
          {
            if (Input.GetButtonDown("A"))
              this.CongratulationsWindow.SetActive(false);
          }
          else if (this.ResetWeekWindow.activeInHierarchy)
          {
            if (Input.GetButtonDown("A"))
            {
              this.FadeOut = true;
              this.ResetWeek = true;
            }
            else if (Input.GetButtonDown("B"))
              this.ResetWeekWindow.SetActive(false);
            else if (Input.GetButtonDown("X"))
            {
              this.ConfirmationWindow.SetActive(true);
              this.ResetWeekWindow.SetActive(false);
            }
          }
          else if (this.ConfirmationWindow.activeInHierarchy)
          {
            if (Input.GetButtonDown("A"))
            {
              this.FadeOut = true;
              this.Reset = true;
            }
            if (Input.GetButtonDown("B"))
              this.ConfirmationWindow.SetActive(false);
          }
          else if (this.SkipConfirmationWindow.activeInHierarchy)
          {
            if (Input.GetButtonDown("A"))
            {
              this.SundayLabel.SetActive(false);
              if (StudentGlobals.MemorialStudents > 0)
              {
                StudentGlobals.MemorialStudents = 0;
                StudentGlobals.MemorialStudent1 = 0;
                StudentGlobals.MemorialStudent2 = 0;
                StudentGlobals.MemorialStudent3 = 0;
                StudentGlobals.MemorialStudent4 = 0;
                StudentGlobals.MemorialStudent5 = 0;
                StudentGlobals.MemorialStudent6 = 0;
                StudentGlobals.MemorialStudent7 = 0;
                StudentGlobals.MemorialStudent8 = 0;
                StudentGlobals.MemorialStudent9 = 0;
              }
              this.SkipConfirmationWindow.SetActive(false);
              ClassGlobals.BonusStudyPoints += 10;
              GameGlobals.ShowAbduction = false;
              ++DateGlobals.Weekday;
              this.Incremented = false;
              this.Skipping = true;
              if (!SchoolGlobals.HighSecurity && (double) SchoolGlobals.SchoolAtmosphere >= (double) SchoolGlobals.PreviousSchoolAtmosphere)
                SchoolGlobals.SchoolAtmosphere += 0.05f;
              this.ImproveSchoolAtmosphere();
              if (GameGlobals.RivalEliminationID == 0 && DateGlobals.Weekday == DayOfWeek.Friday || DateGlobals.Weekday > DayOfWeek.Friday)
              {
                this.SkipButton.SetActive(false);
                if (this.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
                  this.SkipButton.SetActive(true);
              }
            }
            if (Input.GetButtonDown("B"))
              this.SkipConfirmationWindow.SetActive(false);
          }
          else if (this.AmaiWindow.activeInHierarchy)
          {
            if (Input.GetButtonDown("A"))
            {
              this.AmaiButton.SetActive(false);
              this.AmaiWindow.SetActive(false);
              ++DateGlobals.Weekday;
              this.Incremented = false;
              if (!SchoolGlobals.HighSecurity)
                SchoolGlobals.SchoolAtmosphere += 0.05f;
              this.ImproveSchoolAtmosphere();
              this.AmaiWindow.SetActive(false);
            }
            if (Input.GetButtonDown("B"))
              this.AmaiWindow.SetActive(false);
          }
          else
          {
            if (Input.GetButtonDown("A"))
              this.FadeOut = true;
            else if (Input.GetButtonDown("B"))
              this.ResetWeekWindow.SetActive(true);
            else if (Input.GetButtonDown("X") && this.Eighties)
              this.Switch = true;
            if (this.SkipButton.activeInHierarchy)
            {
              if (Input.GetButtonDown("Y"))
                this.SkipConfirmationWindow.SetActive(true);
            }
            else if (this.AmaiButton.activeInHierarchy && Input.GetButtonDown("Y"))
              this.AmaiWindow.SetActive(true);
          }
        }
      }
    }
    else
    {
      this.Continue.localPosition = new Vector3(this.Continue.localPosition.x, Mathf.Lerp(this.Continue.localPosition.y, -610f, Time.deltaTime * 10f), this.Continue.localPosition.z);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      if ((double) this.Darkness.color.a >= 1.0)
      {
        if (this.ResetWeek)
        {
          int profile = GameGlobals.Profile;
          int num = 11;
          Debug.Log((object) ("We're currently on Profile #" + profile.ToString()));
          if (this.Eighties && profile < 11)
          {
            Debug.Log((object) "...but we're in the 80s! Let's adjust that!");
            profile += 10;
          }
          if (File.Exists(Application.streamingAssetsPath + "/SaveFiles/Profile_" + profile.ToString() + "_Slot_" + num.ToString() + ".yansave"))
          {
            YanSave.LoadData("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
            YanSave.LoadPrefs("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
            Debug.Log((object) ("Successfully loaded the save in Slot #" + num.ToString()));
          }
          else
            Debug.Log((object) ("Attempted to load a save from Slot #" + num.ToString() + ", but apparently it didn't exist."));
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (this.Reset)
        {
          this.ResetSaveFile();
        }
        else
        {
          if (HomeGlobals.Night)
            HomeGlobals.Night = false;
          switch (DateGlobals.Weekday)
          {
            case DayOfWeek.Sunday:
              if (!this.Eighties)
              {
                HomeGlobals.Night = true;
                break;
              }
              break;
            case DayOfWeek.Saturday:
              if (!this.Eighties)
              {
                SceneManager.LoadScene("BusStopScene");
                goto label_89;
              }
              else
              {
                GameGlobals.EightiesCutsceneID = DateGlobals.Week + 1;
                SceneManager.LoadScene("EightiesCutsceneScene");
                goto label_89;
              }
          }
          SceneManager.LoadScene("HomeScene");
        }
      }
    }
label_89:
    if (this.Incremented)
      this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, this.Offset - 750f + this.Target, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
    if (this.Switch)
    {
      if (!this.ViewingStats)
      {
        if (this.Phase == 1)
        {
          this.CalendarPanel.alpha = Mathf.MoveTowards(this.CalendarPanel.alpha, 0.0f, Time.deltaTime * 5f);
          if ((double) this.CalendarPanel.alpha <= 0.0)
            ++this.Phase;
        }
        else
        {
          this.ChallengePanel.alpha = Mathf.MoveTowards(this.ChallengePanel.alpha, 1f, Time.deltaTime * 5f);
          if ((double) this.ChallengePanel.alpha >= 1.0)
          {
            this.ViewingStats = true;
            this.Switch = false;
            this.Phase = 1;
          }
        }
      }
      else if (this.Phase == 1)
      {
        this.ChallengePanel.alpha = Mathf.MoveTowards(this.ChallengePanel.alpha, 0.0f, Time.deltaTime * 5f);
        if ((double) this.ChallengePanel.alpha <= 0.0)
          ++this.Phase;
      }
      else
      {
        this.CalendarPanel.alpha = Mathf.MoveTowards(this.CalendarPanel.alpha, 1f, Time.deltaTime * 5f);
        if ((double) this.CalendarPanel.alpha >= 1.0)
        {
          this.ViewingStats = false;
          this.Switch = false;
          this.Phase = 1;
        }
      }
    }
    if (!Input.GetKeyDown(KeyCode.L))
      return;
    GameGlobals.LoveSick = !GameGlobals.LoveSick;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void ChangeDayColor()
  {
    foreach (UILabel uiLabel in this.DayLabel)
      ;
    foreach (UnityEngine.Object @object in this.DayNumber)
    {
      int num = @object != (UnityEngine.Object) null ? 1 : 0;
    }
    if (GameGlobals.RivalEliminationID == 0 && DateGlobals.Weekday < DayOfWeek.Friday || GameGlobals.RivalEliminationID > 0 && DateGlobals.Weekday < DayOfWeek.Saturday)
    {
      this.SkipButton.SetActive(true);
    }
    else
    {
      this.SkipButton.SetActive(false);
      if (this.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
        this.SkipButton.SetActive(true);
    }
    if (this.Eighties || DateGlobals.Week != 2)
      return;
    this.SkipButton.SetActive(false);
  }

  public void LoveSickCheck()
  {
    if (!GameGlobals.LoveSick)
      return;
    SchoolGlobals.SchoolAtmosphereSet = true;
    SchoolGlobals.SchoolAtmosphere = 0.0f;
    this.LoveSick = true;
    Camera.main.backgroundColor = new Color(0.0f, 0.0f, 0.0f, 1f);
    foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
    {
      UISprite component1 = gameObject.GetComponent<UISprite>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        component1.color = new Color(1f, 0.0f, 0.0f, component1.color.a);
      UITexture component2 = gameObject.GetComponent<UITexture>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
        component2.color = new Color(1f, 0.0f, 0.0f, component2.color.a);
      UILabel component3 = gameObject.GetComponent<UILabel>();
      if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
      {
        if (component3.color != Color.black)
          component3.color = new Color(1f, 0.0f, 0.0f, component3.color.a);
        if (component3.text == "?")
          component3.color = new Color(1f, 0.0f, 0.0f, component3.color.a);
      }
    }
    this.Darkness.color = Color.black;
    this.AtmosphereLabel.enabled = false;
    this.Cloud.enabled = false;
    this.Sun.enabled = false;
  }

  public void SetVignettePink() => this.NewTitleScreenProfile.vignette.settings = this.NewTitleScreenProfile.vignette.settings with
  {
    color = new Color(1f, 0.75f, 1f, 1f)
  };

  private void ImproveSchoolAtmosphere()
  {
    if ((double) SchoolGlobals.SchoolAtmosphere > 1.0)
      SchoolGlobals.SchoolAtmosphere = 1f;
    this.Sun.color = new Color(this.Sun.color.r, this.Sun.color.g, this.Sun.color.b, SchoolGlobals.SchoolAtmosphere);
    this.Cloud.color = new Color(this.Cloud.color.r, this.Cloud.color.g, this.Cloud.color.b, 1f - SchoolGlobals.SchoolAtmosphere);
    this.AtmosphereLabel.text = (SchoolGlobals.SchoolAtmosphere * 100f).ToString("f0") + "%";
    float num = 1f - SchoolGlobals.SchoolAtmosphere;
    this.GrayscaleEffect.desaturation = num;
    this.Vignette.intensity = num * 5f;
    this.Vignette.blur = num;
    this.Vignette.chromaticAberration = num;
    SchoolGlobals.PreviousSchoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
  }

  private void BecomeEighties()
  {
    this.Vignette.enabled = false;
    StudentGlobals.FemaleUniform = 6;
    StudentGlobals.MaleUniform = 1;
    if (DateGlobals.Week > 1 && DateGlobals.Weekday == DayOfWeek.Sunday)
    {
      this.SundayLabel.SetActive(true);
      this.SkipButton.SetActive(true);
    }
    if (DateGlobals.ForceSkip)
      this.SundayLabel.SetActive(false);
    this.Eighties = true;
    this.Labels = UnityEngine.Object.FindSceneObjectsOfType(typeof (UILabel)) as UILabel[];
    for (int index = 0; index < this.Labels.Length; ++index)
      this.EightiesifyLabel(this.Labels[index]);
    this.EightiesifyLabel(this.SkipLabel);
    for (int index = 1; index < this.DayNumber.Length; ++index)
    {
      this.DayNumber[index].fontSize = 150;
      this.DayNumber[index].effectDistance = new Vector2(10f, 10f);
    }
    for (int index = 0; index < this.DayLabel.Length; ++index)
    {
      this.DayLabel[index].pivot = UIWidget.Pivot.Center;
      this.DayLabel[index].transform.localPosition = new Vector3(0.0f, 120f, 0.0f);
      this.DayLabel[index].transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }
    Camera.main.backgroundColor = new Color(0.0f, 0.0f, 0.75f, 1f);
    this.AtmosphereLabel.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.YearLabel.text = "1989";
    this.Offset = 0.0f;
    this.Highlight.localScale = new Vector3(1f, 1.25f, 1f);
    this.DeadlineLabel.transform.localPosition = new Vector3(500f, -200f, 0.0f);
    this.Continue.localPosition = new Vector3(650f, this.Continue.localPosition.y, this.Continue.localPosition.z);
    switch (DateGlobals.Week)
    {
      case 1:
        this.DayNumber[1].text = "2";
        this.DayNumber[2].text = "3";
        this.DayNumber[3].text = "4";
        this.DayNumber[4].text = "5";
        this.DayNumber[5].text = "6";
        this.DayNumber[6].text = "7";
        this.DayNumber[7].text = "8";
        break;
      case 2:
        this.DayNumber[1].text = "9";
        this.DayNumber[2].text = "10";
        this.DayNumber[3].text = "11";
        this.DayNumber[4].text = "12";
        this.DayNumber[5].text = "13";
        this.DayNumber[6].text = "14";
        this.DayNumber[7].text = "15";
        break;
      case 3:
        this.DayNumber[1].text = "16";
        this.DayNumber[2].text = "17";
        this.DayNumber[3].text = "18";
        this.DayNumber[4].text = "19";
        this.DayNumber[5].text = "20";
        this.DayNumber[6].text = "21";
        this.DayNumber[7].text = "22";
        break;
      case 4:
        this.DayNumber[1].text = "23";
        this.DayNumber[2].text = "24";
        this.DayNumber[3].text = "25";
        this.DayNumber[4].text = "26";
        this.DayNumber[5].text = "27";
        this.DayNumber[6].text = "28";
        this.DayNumber[7].text = "29";
        break;
      case 5:
        this.DayNumber[1].text = "30";
        this.DayNumber[2].text = "1";
        this.DayNumber[3].text = "2";
        this.DayNumber[4].text = "3";
        this.DayNumber[5].text = "4";
        this.DayNumber[6].text = "5";
        this.DayNumber[7].text = "6";
        break;
      case 6:
        this.DayNumber[1].text = "7";
        this.DayNumber[2].text = "8";
        this.DayNumber[3].text = "9";
        this.DayNumber[4].text = "10";
        this.DayNumber[5].text = "11";
        this.DayNumber[6].text = "12";
        this.DayNumber[7].text = "13";
        break;
      case 7:
        this.DayNumber[1].text = "14";
        this.DayNumber[2].text = "15";
        this.DayNumber[3].text = "16";
        this.DayNumber[4].text = "17";
        this.DayNumber[5].text = "18";
        this.DayNumber[6].text = "19";
        this.DayNumber[7].text = "20";
        break;
      case 8:
        this.DayNumber[1].text = "21";
        this.DayNumber[2].text = "22";
        this.DayNumber[3].text = "23";
        this.DayNumber[4].text = "24";
        this.DayNumber[5].text = "25";
        this.DayNumber[6].text = "26";
        this.DayNumber[7].text = "27";
        break;
      case 9:
        this.DayNumber[1].text = "28";
        this.DayNumber[2].text = "29";
        this.DayNumber[3].text = "30";
        this.DayNumber[4].text = "31";
        this.DayNumber[5].text = "1";
        this.DayNumber[6].text = "2";
        this.DayNumber[7].text = "3";
        break;
      case 10:
        this.DayNumber[1].text = "4";
        this.DayNumber[2].text = "5";
        this.DayNumber[3].text = "6";
        this.DayNumber[4].text = "7";
        this.DayNumber[5].text = "8";
        this.DayNumber[6].text = "9";
        this.DayNumber[7].text = "10";
        break;
      case 11:
        GameGlobals.RivalEliminationID = 1;
        this.EndingLabel.SetActive(true);
        this.DayNumber[1].text = "11";
        this.DayNumber[2].text = "12";
        this.DayNumber[3].text = "13";
        this.DayNumber[4].text = "14";
        this.DayNumber[5].text = "15";
        this.DayNumber[6].text = "16";
        this.DayNumber[7].text = "17";
        break;
    }
    if (DateGlobals.Week == 9 && DateGlobals.Weekday > DayOfWeek.Wednesday || DateGlobals.Week > 9)
      this.MonthLabel.text = "JUNE";
    else if (DateGlobals.Week == 5 && DateGlobals.Weekday > DayOfWeek.Sunday || DateGlobals.Week > 5)
      this.MonthLabel.text = "MAY";
    if ((double) SchoolGlobals.SchoolAtmosphere > 0.5)
      return;
    this.AtmosphereLabel.color = new Color(1f, 1f, 1f);
  }

  public void EightiesifyLabel(UILabel Label)
  {
    Label.trueTypeFont = this.VCR;
    Label.applyGradient = false;
    Label.color = new Color(1f, 1f, 1f, 1f);
    Label.effectStyle = UILabel.Effect.Outline8;
    Label.effectColor = new Color(0.0f, 0.0f, 0.0f, 1f);
  }

  public void ResetSaveFile()
  {
    int profile = GameGlobals.Profile;
    bool eighties = GameGlobals.Eighties;
    bool debug = GameGlobals.Debug;
    int femaleUniform = StudentGlobals.FemaleUniform;
    int maleUniform = StudentGlobals.MaleUniform;
    Globals.DeleteAll();
    if (eighties && profile < 11)
      profile += 10;
    PlayerPrefs.SetInt("ProfileCreated_" + profile.ToString(), 1);
    GameGlobals.Eighties = eighties;
    GameGlobals.Profile = profile;
    GameGlobals.Debug = debug;
    StudentGlobals.FemaleUniform = femaleUniform;
    StudentGlobals.MaleUniform = maleUniform;
    GameGlobals.LoveSick = this.LoveSick;
    DateGlobals.PassDays = 1;
    if (GameGlobals.Eighties)
    {
      for (int studentID = 1; studentID < 101; ++studentID)
        StudentGlobals.SetStudentPhotographed(studentID, true);
    }
    OptionGlobals.DisableTint = !eighties;
    YanSave.SaveData("Profile_" + profile.ToString() + "_Slot_" + 11.ToString());
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
