// Decompiled with JetBrains decompiler
// Type: ClassScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassScript : MonoBehaviour
{
  public CutsceneManagerScript CutsceneManager;
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public SchemesScript Schemes;
  public PortalScript Portal;
  public GameObject Poison;
  public UILabel StudyPointsLabel;
  public UILabel[] SubjectLabels;
  public UILabel GradeUpDesc;
  public UILabel GradeUpName;
  public UILabel DescLabel;
  public UISprite Darkness;
  public Transform[] Subject1Bars;
  public Transform[] Subject2Bars;
  public Transform[] Subject3Bars;
  public Transform[] Subject4Bars;
  public Transform[] Subject5Bars;
  public string[] Subject1GradeText;
  public string[] Subject2GradeText;
  public string[] Subject3GradeText;
  public string[] Subject3GradeTextEighties;
  public string[] Subject4GradeText;
  public string[] Subject5GradeText;
  public Transform WarningWindow;
  public Transform GradeUpWindow;
  public Transform Highlight;
  public int[] SubjectTemp;
  public int[] Subject;
  public string[] Desc;
  public int StartingPoints;
  public int BonusPoints;
  public int StudyPoints;
  public int GradeUpSubject;
  public int Selected;
  public int Grade;
  public bool ShowWarning;
  public bool GradeUp;
  public bool Show;
  public int Biology;
  public int Chemistry;
  public int Language;
  public int Physical;
  public int Psychology;
  public int BiologyGrade;
  public int ChemistryGrade;
  public int LanguageGrade;
  public int PhysicalGrade;
  public int PsychologyGrade;
  public int BiologyBonus;
  public int ChemistryBonus;
  public int LanguageBonus;
  public int PhysicalBonus;
  public int PsychologyBonus;
  public int Seduction;
  public int Numbness;
  public int Social;
  public int Stealth;
  public int Speed;
  public int Enlightenment;
  public int SpeedBonus;
  public int SocialBonus;
  public int StealthBonus;
  public int SeductionBonus;
  public int NumbnessBonus;
  public int EnlightenmentBonus;
  public float HoldRightTimer;
  public float HoldLeftTimer;
  public bool Initialized;

  private void Start()
  {
    if ((Object) this.Portal == (Object) null || !this.Portal.StudentManager.ReturnedFromSave)
      this.GetStats();
    if (SceneManager.GetActiveScene().name != "SchoolScene")
    {
      this.enabled = false;
    }
    else
    {
      this.GradeUpWindow.localScale = Vector3.zero;
      this.Subject[1] = this.Biology;
      this.Subject[2] = this.Chemistry;
      this.Subject[3] = this.Language;
      this.Subject[4] = this.Physical;
      this.Subject[5] = this.Psychology;
      this.DescLabel.text = this.Desc[this.Selected];
      this.UpdateSubjectLabels();
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
      this.UpdateBars();
    }
    if (!GameGlobals.Eighties)
      return;
    this.Subject3GradeText = this.Subject3GradeTextEighties;
  }

  public void GetStats()
  {
    if (!this.Initialized)
    {
      this.BonusPoints += ClassGlobals.BonusStudyPoints;
      this.Initialized = true;
    }
    this.Biology = ClassGlobals.Biology;
    this.Chemistry = ClassGlobals.Chemistry;
    this.Language = ClassGlobals.Language;
    this.Physical = ClassGlobals.Physical;
    this.Psychology = ClassGlobals.Psychology;
    this.BiologyGrade = ClassGlobals.BiologyGrade;
    this.ChemistryGrade = ClassGlobals.ChemistryGrade;
    this.LanguageGrade = ClassGlobals.LanguageGrade;
    this.PhysicalGrade = ClassGlobals.PhysicalGrade;
    this.PsychologyGrade = ClassGlobals.PsychologyGrade;
    if (this.BiologyBonus == 0)
      this.BiologyBonus = ClassGlobals.BiologyBonus;
    if (this.ChemistryBonus == 0)
      this.ChemistryBonus = ClassGlobals.ChemistryBonus;
    if (this.LanguageBonus == 0)
      this.LanguageBonus = ClassGlobals.LanguageBonus;
    if (this.PhysicalBonus == 0)
      this.PhysicalBonus = ClassGlobals.PhysicalBonus;
    if (this.PsychologyBonus == 0)
      this.PsychologyBonus = ClassGlobals.PsychologyBonus;
    this.Seduction = PlayerGlobals.Seduction;
    this.Numbness = PlayerGlobals.Numbness;
    this.Enlightenment = PlayerGlobals.Enlightenment;
    if (this.SpeedBonus == 0)
      this.SpeedBonus = PlayerGlobals.SpeedBonus;
    if (this.SocialBonus == 0)
      this.SocialBonus = PlayerGlobals.SocialBonus;
    if (this.StealthBonus == 0)
      this.StealthBonus = PlayerGlobals.StealthBonus;
    if (this.SeductionBonus == 0)
      this.SeductionBonus = PlayerGlobals.SeductionBonus;
    if (this.NumbnessBonus == 0)
      this.NumbnessBonus = PlayerGlobals.NumbnessBonus;
    if (this.EnlightenmentBonus != 0)
      return;
    this.EnlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
  }

  private void Update()
  {
    if (this.Show)
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime);
      if ((double) this.Darkness.alpha == 0.0)
      {
        if (!this.Portal.Yandere.NoDebug)
        {
          if (Input.GetKeyDown(KeyCode.Backslash))
            this.GivePoints();
          if (Input.GetKeyDown(KeyCode.P))
            this.MaxPhysical();
        }
        if (!this.ShowWarning)
        {
          if (this.InputManager.TappedDown)
          {
            ++this.Selected;
            if (this.Selected > 5)
              this.Selected = 1;
            this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (375.0 - 125.0 * (double) this.Selected), this.Highlight.localPosition.z);
            this.DescLabel.text = this.Desc[this.Selected];
            this.UpdateSubjectLabels();
          }
          if (this.InputManager.TappedUp)
          {
            --this.Selected;
            if (this.Selected < 1)
              this.Selected = 5;
            this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (375.0 - 125.0 * (double) this.Selected), this.Highlight.localPosition.z);
            this.DescLabel.text = this.Desc[this.Selected];
            this.UpdateSubjectLabels();
          }
          if (this.InputManager.TappedRight)
            this.AddStudyPoints();
          if (this.InputManager.TappedLeft)
            this.SubtractStudyPoints();
          if ((double) Input.GetAxisRaw("DpadX") > 0.5 || (double) Input.GetAxisRaw("Horizontal") > 0.5)
          {
            this.HoldRightTimer += Time.deltaTime;
            if ((double) this.HoldRightTimer > 0.5)
              this.AddStudyPoints();
          }
          else
            this.HoldRightTimer = 0.0f;
          if ((double) Input.GetAxisRaw("DpadX") < -0.5 || (double) Input.GetAxisRaw("Horizontal") < -0.5)
          {
            this.HoldLeftTimer += Time.deltaTime;
            if ((double) this.HoldLeftTimer > 0.5)
              this.SubtractStudyPoints();
          }
          else
            this.HoldLeftTimer = 0.0f;
          if (Input.GetButtonDown("A"))
          {
            bool flag = true;
            if (this.BiologyGrade == 5 && this.ChemistryGrade == 5 && this.LanguageGrade == 5 && this.PhysicalGrade == 5 && this.PsychologyGrade == 5)
              flag = false;
            if (this.StudyPoints == this.StartingPoints & flag)
            {
              this.ShowWarning = true;
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Finish Class";
              this.PromptBar.Label[1].text = "Allocate Points";
              this.PromptBar.UpdateButtons();
            }
            else
              this.ExitClass();
          }
        }
        else if ((double) this.WarningWindow.localScale.x > 0.89999997615814209)
        {
          if (Input.GetButtonDown("A"))
            this.ExitClass();
          if (Input.GetButtonDown("B"))
          {
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Finish Class";
            this.PromptBar.Label[4].text = "Choose";
            this.PromptBar.Label[5].text = "Allocate";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.ShowWarning = false;
          }
        }
      }
      if (this.ShowWarning)
        this.WarningWindow.localScale = Vector3.Lerp(this.WarningWindow.localScale, Vector3.one, Time.deltaTime * 10f);
      else
        this.WarningWindow.localScale = Vector3.Lerp(this.WarningWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
    }
    else
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime);
      if ((double) this.Darkness.color.a != 1.0)
        return;
      if (!this.GradeUp)
      {
        this.GradeUpWindow.localScale = (double) this.GradeUpWindow.localScale.x <= 0.10000000149011612 ? Vector3.zero : Vector3.Lerp(this.GradeUpWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
        if ((double) this.GradeUpWindow.localScale.x >= 0.0099999997764825821)
          return;
        this.GradeUpWindow.localScale = Vector3.zero;
        this.CheckForGradeUp();
        if (this.GradeUp)
          return;
        if (this.ChemistryGrade > 0 && (Object) this.Poison != (Object) null)
          this.Poison.SetActive(true);
        StudentManagerScript studentManager = this.Portal.Yandere.StudentManager;
        if (this.CutsceneManager.Scheme > 0 && (Object) studentManager.Students[studentManager.RivalID] != (Object) null && studentManager.Students[studentManager.RivalID].Alive && !studentManager.Students[studentManager.RivalID].Tranquil)
        {
          SchemeGlobals.SetSchemeStage(this.CutsceneManager.Scheme, 100);
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Continue";
          this.PromptBar.UpdateButtons();
          this.CutsceneManager.gameObject.SetActive(true);
          this.Schemes.UpdateInstructions();
          this.gameObject.SetActive(false);
        }
        else
        {
          Debug.Log((object) "We don't need to go to the counselor's office.");
          if (this.Portal.FadeOut)
            return;
          Debug.Log((object) "Instructing the portal to proceed with its code.");
          this.Portal.Yandere.PhysicalGrade = this.PhysicalGrade;
          this.Portal.Yandere.CameraEffects.UpdateDOF(this.Portal.OriginalDOF);
          this.Portal.ClassDarkness.alpha = 1f;
          this.Portal.Transition = true;
          this.Portal.FadeOut = false;
          this.Portal.Proceed = true;
          this.PromptBar.Show = false;
          this.gameObject.SetActive(false);
        }
      }
      else
      {
        if ((double) this.GradeUpWindow.localScale.x == 0.0)
        {
          if (this.GradeUpSubject == 1)
          {
            this.GradeUpName.text = "BIOLOGY RANK UP";
            this.GradeUpDesc.text = this.Subject1GradeText[this.Grade];
          }
          else if (this.GradeUpSubject == 2)
          {
            this.GradeUpName.text = "CHEMISTRY RANK UP";
            this.GradeUpDesc.text = this.Subject2GradeText[this.Grade];
          }
          else if (this.GradeUpSubject == 3)
          {
            this.GradeUpName.text = "LANGUAGE RANK UP";
            this.GradeUpDesc.text = this.Subject3GradeText[this.Grade];
          }
          else if (this.GradeUpSubject == 4)
          {
            this.GradeUpName.text = "PHYSICAL RANK UP";
            this.GradeUpDesc.text = this.Subject4GradeText[this.Grade];
          }
          else if (this.GradeUpSubject == 5)
          {
            this.GradeUpName.text = "PSYCHOLOGY RANK UP";
            this.GradeUpDesc.text = this.Subject5GradeText[this.Grade];
          }
          this.GradeUpDesc.text = this.GradeUpDesc.text.Replace("\\n", "\n\n");
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Continue";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
        }
        else if ((double) this.GradeUpWindow.localScale.x > 0.89999997615814209 && Input.GetButtonDown("A"))
        {
          this.PromptBar.ClearButtons();
          this.GradeUp = false;
        }
        this.GradeUpWindow.localScale = Vector3.Lerp(this.GradeUpWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
    }
  }

  private void UpdateSubjectLabels()
  {
    for (int index = 1; index < 6; ++index)
      this.SubjectLabels[index].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.SubjectLabels[this.Selected].color = new Color(1f, 1f, 1f, 1f);
  }

  public void UpdateLabel() => this.StudyPointsLabel.text = "STUDY POINTS: " + this.StudyPoints.ToString();

  private void UpdateBars()
  {
    for (int index = 1; index < 6; ++index)
    {
      Transform subject1Bar = this.Subject1Bars[index];
      if (this.Subject[1] + this.SubjectTemp[1] > (index - 1) * 20)
      {
        subject1Bar.localScale = new Vector3((float) -((double) ((index - 1) * 20 - (this.Subject[1] + this.SubjectTemp[1])) / 20.0), subject1Bar.localScale.y, subject1Bar.localScale.z);
        if ((double) subject1Bar.localScale.x > 1.0)
          subject1Bar.localScale = new Vector3(1f, subject1Bar.localScale.y, subject1Bar.localScale.z);
      }
      else
        subject1Bar.localScale = new Vector3(0.0f, subject1Bar.localScale.y, subject1Bar.localScale.z);
    }
    for (int index = 1; index < 6; ++index)
    {
      Transform subject2Bar = this.Subject2Bars[index];
      if (this.Subject[2] + this.SubjectTemp[2] > (index - 1) * 20)
      {
        subject2Bar.localScale = new Vector3((float) -((double) ((index - 1) * 20 - (this.Subject[2] + this.SubjectTemp[2])) / 20.0), subject2Bar.localScale.y, subject2Bar.localScale.z);
        if ((double) subject2Bar.localScale.x > 1.0)
          subject2Bar.localScale = new Vector3(1f, subject2Bar.localScale.y, subject2Bar.localScale.z);
      }
      else
        subject2Bar.localScale = new Vector3(0.0f, subject2Bar.localScale.y, subject2Bar.localScale.z);
    }
    for (int index = 1; index < 6; ++index)
    {
      Transform subject3Bar = this.Subject3Bars[index];
      if (this.Subject[3] + this.SubjectTemp[3] > (index - 1) * 20)
      {
        subject3Bar.localScale = new Vector3((float) -((double) ((index - 1) * 20 - (this.Subject[3] + this.SubjectTemp[3])) / 20.0), subject3Bar.localScale.y, subject3Bar.localScale.z);
        if ((double) subject3Bar.localScale.x > 1.0)
          subject3Bar.localScale = new Vector3(1f, subject3Bar.localScale.y, subject3Bar.localScale.z);
      }
      else
        subject3Bar.localScale = new Vector3(0.0f, subject3Bar.localScale.y, subject3Bar.localScale.z);
    }
    for (int index = 1; index < 6; ++index)
    {
      Transform subject4Bar = this.Subject4Bars[index];
      if (this.Subject[4] + this.SubjectTemp[4] > (index - 1) * 20)
      {
        subject4Bar.localScale = new Vector3((float) -((double) ((index - 1) * 20 - (this.Subject[4] + this.SubjectTemp[4])) / 20.0), subject4Bar.localScale.y, subject4Bar.localScale.z);
        if ((double) subject4Bar.localScale.x > 1.0)
          subject4Bar.localScale = new Vector3(1f, subject4Bar.localScale.y, subject4Bar.localScale.z);
      }
      else
        subject4Bar.localScale = new Vector3(0.0f, subject4Bar.localScale.y, subject4Bar.localScale.z);
    }
    for (int index = 1; index < 6; ++index)
    {
      Transform subject5Bar = this.Subject5Bars[index];
      if (this.Subject[5] + this.SubjectTemp[5] > (index - 1) * 20)
      {
        subject5Bar.localScale = new Vector3((float) -((double) ((index - 1) * 20 - (this.Subject[5] + this.SubjectTemp[5])) / 20.0), subject5Bar.localScale.y, subject5Bar.localScale.z);
        if ((double) subject5Bar.localScale.x > 1.0)
          subject5Bar.localScale = new Vector3(1f, subject5Bar.localScale.y, subject5Bar.localScale.z);
      }
      else
        subject5Bar.localScale = new Vector3(0.0f, subject5Bar.localScale.y, subject5Bar.localScale.z);
    }
  }

  private void CheckForGradeUp()
  {
    if (this.Biology >= 20 && this.BiologyGrade < 1)
    {
      this.BiologyGrade = 1;
      this.GradeUpSubject = 1;
      this.GradeUp = true;
      this.Grade = 1;
    }
    else if (this.Biology >= 40 && this.BiologyGrade < 2)
    {
      this.BiologyGrade = 2;
      this.GradeUpSubject = 1;
      this.GradeUp = true;
      this.Grade = 2;
    }
    else if (this.Biology >= 60 && this.BiologyGrade < 3)
    {
      this.BiologyGrade = 3;
      this.GradeUpSubject = 1;
      this.GradeUp = true;
      this.Grade = 3;
    }
    else if (this.Biology >= 80 && this.BiologyGrade < 4)
    {
      this.BiologyGrade = 4;
      this.GradeUpSubject = 1;
      this.GradeUp = true;
      this.Grade = 4;
    }
    else if (this.Biology >= 100 && this.BiologyGrade < 5)
    {
      this.BiologyGrade = 5;
      this.GradeUpSubject = 1;
      this.GradeUp = true;
      this.Grade = 5;
    }
    else if (this.Chemistry >= 20 && this.ChemistryGrade < 1)
    {
      this.ChemistryGrade = 1;
      this.GradeUpSubject = 2;
      this.GradeUp = true;
      this.Grade = 1;
    }
    else if (this.Chemistry >= 40 && this.ChemistryGrade < 2)
    {
      this.ChemistryGrade = 2;
      this.GradeUpSubject = 2;
      this.GradeUp = true;
      this.Grade = 2;
    }
    else if (this.Chemistry >= 60 && this.ChemistryGrade < 3)
    {
      this.ChemistryGrade = 3;
      this.GradeUpSubject = 2;
      this.GradeUp = true;
      this.Grade = 3;
    }
    else if (this.Chemistry >= 80 && this.ChemistryGrade < 4)
    {
      this.ChemistryGrade = 4;
      this.GradeUpSubject = 2;
      this.GradeUp = true;
      this.Grade = 4;
    }
    else if (this.Chemistry >= 100 && this.ChemistryGrade < 5)
    {
      this.ChemistryGrade = 5;
      this.GradeUpSubject = 2;
      this.GradeUp = true;
      this.Grade = 5;
    }
    else if (this.Language >= 20 && this.LanguageGrade < 1)
    {
      this.LanguageGrade = 1;
      this.GradeUpSubject = 3;
      this.GradeUp = true;
      this.Grade = 1;
    }
    else if (this.Language >= 40 && this.LanguageGrade < 2)
    {
      this.LanguageGrade = 2;
      this.GradeUpSubject = 3;
      this.GradeUp = true;
      this.Grade = 2;
    }
    else if (this.Language >= 60 && this.LanguageGrade < 3)
    {
      this.LanguageGrade = 3;
      this.GradeUpSubject = 3;
      this.GradeUp = true;
      this.Grade = 3;
    }
    else if (this.Language >= 80 && this.LanguageGrade < 4)
    {
      this.LanguageGrade = 4;
      this.GradeUpSubject = 3;
      this.GradeUp = true;
      this.Grade = 4;
    }
    else if (this.Language >= 100 && this.LanguageGrade < 5)
    {
      this.LanguageGrade = 5;
      this.GradeUpSubject = 3;
      this.GradeUp = true;
      this.Grade = 5;
    }
    else if (this.Physical >= 20 && this.PhysicalGrade < 1)
    {
      this.PhysicalGrade = 1;
      this.GradeUpSubject = 4;
      this.GradeUp = true;
      this.Grade = 1;
    }
    else if (this.Physical >= 40 && this.PhysicalGrade < 2)
    {
      this.PhysicalGrade = 2;
      this.GradeUpSubject = 4;
      this.GradeUp = true;
      this.Grade = 2;
    }
    else if (this.Physical >= 60 && this.PhysicalGrade < 3)
    {
      this.PhysicalGrade = 3;
      this.GradeUpSubject = 4;
      this.GradeUp = true;
      this.Grade = 3;
    }
    else if (this.Physical >= 80 && this.PhysicalGrade < 4)
    {
      this.PhysicalGrade = 4;
      this.GradeUpSubject = 4;
      this.GradeUp = true;
      this.Grade = 4;
    }
    else if (this.Physical == 100 && this.PhysicalGrade < 5)
    {
      this.PhysicalGrade = 5;
      this.GradeUpSubject = 4;
      this.GradeUp = true;
      this.Grade = 5;
    }
    else if (this.Psychology >= 20 && this.PsychologyGrade < 1)
    {
      this.PsychologyGrade = 1;
      this.GradeUpSubject = 5;
      this.GradeUp = true;
      this.Grade = 1;
    }
    else if (this.Psychology >= 40 && this.PsychologyGrade < 2)
    {
      this.PsychologyGrade = 2;
      this.GradeUpSubject = 5;
      this.GradeUp = true;
      this.Grade = 2;
    }
    else if (this.Psychology >= 60 && this.PsychologyGrade < 3)
    {
      this.PsychologyGrade = 3;
      this.GradeUpSubject = 5;
      this.GradeUp = true;
      this.Grade = 3;
    }
    else if (this.Psychology >= 80 && this.PsychologyGrade < 4)
    {
      this.PsychologyGrade = 4;
      this.GradeUpSubject = 5;
      this.GradeUp = true;
      this.Grade = 4;
    }
    else if (this.Psychology >= 100 && this.PsychologyGrade < 5)
    {
      this.PsychologyGrade = 5;
      this.GradeUpSubject = 5;
      this.GradeUp = true;
      this.Grade = 5;
    }
    this.Portal.Yandere.UpdateNumbness();
  }

  private void GivePoints()
  {
    this.StudyPoints = 500;
    this.BiologyGrade = 0;
    this.ChemistryGrade = 0;
    this.LanguageGrade = 0;
    this.PhysicalGrade = 0;
    this.PsychologyGrade = 0;
    this.Biology = 19;
    this.Chemistry = 19;
    this.Language = 19;
    this.Physical = 19;
    this.Psychology = 19;
    this.Subject[1] = this.Biology;
    this.Subject[2] = this.Chemistry;
    this.Subject[3] = this.Language;
    this.Subject[4] = this.Physical;
    this.Subject[5] = this.Psychology;
    this.UpdateBars();
  }

  private void MaxPhysical()
  {
    this.PhysicalGrade = 0;
    this.Physical = 99;
    this.Subject[4] = this.Physical;
    this.UpdateBars();
  }

  private void AddStudyPoints()
  {
    if (this.StudyPoints <= 0 || this.Subject[this.Selected] + this.SubjectTemp[this.Selected] >= 100)
      return;
    ++this.SubjectTemp[this.Selected];
    --this.StudyPoints;
    this.UpdateLabel();
    this.UpdateBars();
  }

  private void SubtractStudyPoints()
  {
    if (this.SubjectTemp[this.Selected] <= 0)
      return;
    --this.SubjectTemp[this.Selected];
    ++this.StudyPoints;
    this.UpdateLabel();
    this.UpdateBars();
  }

  private void ExitClass()
  {
    this.WarningWindow.localScale = Vector3.zero;
    this.ShowWarning = false;
    this.Show = false;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Biology = this.Subject[1] + this.SubjectTemp[1];
    this.Chemistry = this.Subject[2] + this.SubjectTemp[2];
    this.Language = this.Subject[3] + this.SubjectTemp[3];
    this.Physical = this.Subject[4] + this.SubjectTemp[4];
    this.Psychology = this.Subject[5] + this.SubjectTemp[5];
    for (int index = 0; index < 6; ++index)
    {
      this.Subject[index] += this.SubjectTemp[index];
      this.SubjectTemp[index] = 0;
    }
    this.CheckForGradeUp();
  }
}
