// Decompiled with JetBrains decompiler
// Type: NoteWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class NoteWindowScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public NoteLockerScript NoteLocker;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public ClockScript Clock;
  public Transform SubHighlight;
  public Transform SubMenu;
  public UISprite[] SlotHighlights;
  public UILabel[] SlotLabels;
  public UILabel[] SubLabels;
  public string[] OriginalText;
  public string[] Subjects;
  public string[] Locations;
  public string[] Times;
  public float[] Hours;
  public bool[] SlotsFilled;
  public int SubSlot;
  public int MeetID;
  public int Slot = 1;
  public float Rotation;
  public float TimeID;
  public int ID;
  public bool Selecting;
  public bool Fade;
  public bool Show;
  public NoteWindowScript.NoteSubjectType NoteSubject;
  public UITexture Stationery;
  public UISprite Background1;
  public UISprite Background2;
  public Texture LifeNoteTexture;
  public UILabel[] Labels;
  public bool LifeNote;
  public int TargetStudent;
  public string[] MurderMethods;

  private void Start()
  {
    this.SubMenu.transform.localScale = Vector3.zero;
    this.transform.localPosition = new Vector3(455f, -965f, 0.0f);
    this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
    this.OriginalText[1] = this.SlotLabels[1].text;
    this.OriginalText[2] = this.SlotLabels[2].text;
    this.OriginalText[3] = this.SlotLabels[3].text;
    this.UpdateHighlights();
    this.UpdateSubLabels();
    if (!GameGlobals.Eighties)
      return;
    this.Subjects[10] = "''Evil Photographer''";
    this.Subjects[6] = "''Technology''";
  }

  public void BecomeLifeNote()
  {
    this.Stationery.mainTexture = this.LifeNoteTexture;
    this.Stationery.color = new Color(1f, 1f, 1f, 1f);
    this.Background2.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    foreach (UILabel label in this.Labels)
    {
      if ((UnityEngine.Object) label != (UnityEngine.Object) null)
        label.color = new Color(1f, 1f, 1f, 1f);
    }
    this.Labels[1].color = new Color(1f, 1f, 1f, 0.0f);
    this.Labels[2].color = new Color(1f, 1f, 1f, 0.0f);
    this.Labels[3].transform.localPosition = new Vector3(-365f, 265f, 0.0f);
    this.Labels[3].text = "______________";
    this.Labels[4].text = "will die from";
    this.Labels[8].color = new Color(1f, 1f, 1f, 0.0f);
    this.SlotHighlights[1].transform.localPosition = new Vector3(-100f, 280f, 0.0f);
    foreach (UILabel subLabel in this.SubLabels)
    {
      if ((UnityEngine.Object) subLabel != (UnityEngine.Object) null)
        subLabel.color = new Color(1f, 1f, 1f, 1f);
    }
    this.LifeNote = true;
  }

  private void Update()
  {
    float t = Time.unscaledDeltaTime * 10f;
    if (!this.Show)
    {
      if ((double) this.Rotation > -90.0)
      {
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(455f, -965f, 0.0f), t);
        this.Rotation = Mathf.Lerp(this.Rotation, -91f, t);
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.Rotation);
      }
      else
        this.gameObject.SetActive(false);
    }
    else
    {
      this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, Vector3.zero, t);
      this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, t);
      this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.Rotation);
      if (!this.Selecting)
      {
        if ((double) this.SubMenu.transform.localScale.x > 0.10000000149011612)
          this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, Vector3.zero, t);
        else
          this.SubMenu.transform.localScale = Vector3.zero;
        if (this.InputManager.TappedDown)
        {
          ++this.Slot;
          if (this.Slot > 3)
            this.Slot = 1;
          this.UpdateHighlights();
        }
        if (this.InputManager.TappedUp)
        {
          --this.Slot;
          if (this.Slot < 1)
            this.Slot = 3;
          this.UpdateHighlights();
        }
        if (Input.GetButtonDown("A"))
        {
          if (this.LifeNote && this.Slot == 1)
          {
            this.Yandere.PauseScreen.transform.parent.GetComponent<UIPanel>().alpha = 1f;
            this.Yandere.PauseScreen.StudentInfoMenu.UsingLifeNote = true;
            this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
            this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
            this.Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
            this.Yandere.PauseScreen.MainMenu.SetActive(false);
            this.Yandere.PauseScreen.Panel.enabled = true;
            this.Yandere.PauseScreen.Sideways = true;
            this.Yandere.PauseScreen.Show = true;
            Time.timeScale = 0.0001f;
            this.Yandere.PromptBar.ClearButtons();
            this.Yandere.PromptBar.Label[1].text = "Cancel";
            this.Yandere.PromptBar.UpdateButtons();
            this.Yandere.PromptBar.Show = true;
            this.gameObject.SetActive(false);
          }
          else
          {
            this.PromptBar.Label[2].text = string.Empty;
            this.PromptBar.UpdateButtons();
            this.Selecting = true;
            this.UpdateSubLabels();
          }
        }
        if (Input.GetButtonDown("B"))
          this.Exit();
        if (Input.GetButtonDown("X") && this.SlotsFilled[1] && this.SlotsFilled[2] && this.SlotsFilled[3])
        {
          if (this.LifeNote)
          {
            AudioSource.PlayClipAtPoint(this.Yandere.DramaticWriting, this.Yandere.transform.position);
            this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
            this.Yandere.CharacterAnimation["f02_dramaticWriting_00"].speed = 2f;
            this.Yandere.CharacterAnimation["f02_dramaticWriting_00"].time = 0.0f;
            this.Yandere.CharacterAnimation["f02_dramaticWriting_00"].weight = 0.75f;
            this.Yandere.CharacterAnimation.CrossFade("f02_dramaticWriting_00");
            this.Yandere.WritingName = true;
            this.Exit();
          }
          else
          {
            this.NoteLocker.MeetID = this.MeetID;
            this.NoteLocker.MeetTime = this.TimeID;
            this.NoteLocker.Prompt.enabled = false;
            this.NoteLocker.CanLeaveNote = false;
            this.NoteLocker.NoteLeft = true;
            if (this.NoteLocker.Student.StudentID == 30)
            {
              if (this.NoteSubject == NoteWindowScript.NoteSubjectType.CompensatedDating || this.NoteSubject == NoteWindowScript.NoteSubjectType.DomesticAbuse)
                this.NoteLocker.Success = true;
            }
            else if (this.NoteLocker.Student.StudentID == 5)
            {
              if (this.NoteLocker.Student.Bullied && this.NoteSubject == NoteWindowScript.NoteSubjectType.Bullying && this.MeetID > 7 || this.NoteLocker.StudentManager.MissionMode)
                this.NoteLocker.Success = true;
            }
            else if (this.NoteLocker.Student.StudentID == this.Yandere.StudentManager.RivalID)
            {
              if (DateGlobals.Weekday == DayOfWeek.Friday && (double) this.TimeID == 17.0)
                Debug.Log((object) "Note must fail because she wouldn't accept a note that close to confessing to Senpai.");
              else if (this.NoteSubject == NoteWindowScript.NoteSubjectType.DomesticAbuse)
              {
                this.NoteLocker.Success = true;
                if (SchemeGlobals.GetSchemeStage(6) == 5)
                {
                  SchemeGlobals.SetSchemeStage(6, 6);
                  this.Yandere.PauseScreen.Schemes.UpdateInstructions();
                }
              }
            }
            else if ((this.NoteLocker.Student.StudentID == 2 || this.NoteLocker.Student.StudentID == 3 || this.NoteLocker.Student.Club == ClubType.Occult) && this.NoteSubject == NoteWindowScript.NoteSubjectType.TheSupernatural)
              this.NoteLocker.Success = true;
            if (this.NoteLocker.Student.Persona == PersonaType.Loner && this.NoteSubject == NoteWindowScript.NoteSubjectType.MakingFriends)
              this.NoteLocker.Success = true;
            else if (this.NoteLocker.Student.Persona == PersonaType.TeachersPet && this.NoteSubject == NoteWindowScript.NoteSubjectType.LowGrades)
              this.NoteLocker.Success = true;
            else if (this.NoteLocker.Student.Persona == PersonaType.Heroic && this.NoteSubject == NoteWindowScript.NoteSubjectType.FightingEvil)
              this.NoteLocker.Success = true;
            else if (this.NoteLocker.Student.Persona == PersonaType.Coward)
            {
              if (this.NoteSubject == NoteWindowScript.NoteSubjectType.MakingFriends || this.NoteSubject == NoteWindowScript.NoteSubjectType.SuspiciousActivity)
                this.NoteLocker.Success = true;
            }
            else if (this.NoteLocker.Student.Persona == PersonaType.SocialButterfly && this.NoteSubject == NoteWindowScript.NoteSubjectType.YourFriends)
              this.NoteLocker.Success = true;
            else if (this.NoteLocker.Student.Persona == PersonaType.PhoneAddict && this.NoteSubject == NoteWindowScript.NoteSubjectType.SocialMedia)
              this.NoteLocker.Success = true;
            else if (this.NoteLocker.Student.Club == ClubType.Bully)
            {
              if (this.NoteSubject == NoteWindowScript.NoteSubjectType.YourFriends || this.NoteSubject == NoteWindowScript.NoteSubjectType.CompensatedDating)
                this.NoteLocker.Success = true;
            }
            else if (this.NoteLocker.Student.Persona == PersonaType.Sleuth)
            {
              if (this.NoteSubject == NoteWindowScript.NoteSubjectType.MakingFriends || this.NoteSubject == NoteWindowScript.NoteSubjectType.FightingEvil || this.NoteSubject == NoteWindowScript.NoteSubjectType.MakingFriends || this.NoteSubject == NoteWindowScript.NoteSubjectType.SuspiciousActivity || this.NoteSubject == NoteWindowScript.NoteSubjectType.YourFriends)
                this.NoteLocker.Success = true;
            }
            else if (this.NoteLocker.Student.Persona == PersonaType.Spiteful || this.NoteLocker.Student.Persona == PersonaType.Evil)
            {
              if (this.NoteSubject == NoteWindowScript.NoteSubjectType.Bullying)
                this.NoteLocker.Success = true;
            }
            else if (this.NoteLocker.Student.Persona == PersonaType.Violent)
            {
              if (this.NoteSubject == NoteWindowScript.NoteSubjectType.Bullying)
                this.NoteLocker.Success = true;
            }
            else if (this.NoteLocker.Student.Persona == PersonaType.LandlineUser && (this.NoteSubject == NoteWindowScript.NoteSubjectType.Bullying || this.NoteSubject == NoteWindowScript.NoteSubjectType.FightingEvil || this.NoteSubject == NoteWindowScript.NoteSubjectType.SuspiciousActivity))
              this.NoteLocker.Success = true;
            this.NoteLocker.FindStudentLocker.Prompt.Hide();
            this.NoteLocker.FindStudentLocker.Prompt.Label[0].text = "     You Must Wait For Other Student";
            this.NoteLocker.FindStudentLocker.TargetedStudent = this.NoteLocker.Student;
            this.NoteLocker.transform.GetChild(0).gameObject.SetActive(false);
          }
          this.Exit();
        }
      }
      else
      {
        this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, new Vector3(1f, 1f, 1f), t);
        if (this.InputManager.TappedDown)
        {
          ++this.SubSlot;
          if (this.LifeNote && this.Slot == 2)
          {
            if (this.SubSlot > 6)
              this.SubSlot = 1;
          }
          else if (this.SubSlot > 10)
            this.SubSlot = 1;
          this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, (float) (550.0 - 100.0 * (double) this.SubSlot), this.SubHighlight.localPosition.z);
        }
        if (this.InputManager.TappedUp)
        {
          --this.SubSlot;
          if (this.LifeNote && this.Slot == 2)
          {
            if (this.SubSlot < 1)
              this.SubSlot = 6;
          }
          else if (this.SubSlot < 1)
            this.SubSlot = 10;
          this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, (float) (550.0 - 100.0 * (double) this.SubSlot), this.SubHighlight.localPosition.z);
        }
        if (Input.GetButtonDown("A") && (double) this.SubLabels[this.SubSlot].color.a > 0.5 && this.SubLabels[this.SubSlot].text != string.Empty && this.SubLabels[this.SubSlot].text != "??????????")
        {
          this.SlotLabels[this.Slot].text = this.SubLabels[this.SubSlot].text;
          this.SlotsFilled[this.Slot] = true;
          if (this.Slot == 1)
            this.NoteSubject = (NoteWindowScript.NoteSubjectType) this.SubSlot;
          if (this.Slot == 2)
            this.MeetID = this.SubSlot;
          if (this.Slot == 3)
            this.TimeID = this.Hours[this.SubSlot];
          this.CheckForCompletion();
          this.Selecting = false;
          this.SubSlot = 1;
          this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 450f, this.SubHighlight.localPosition.z);
        }
        if (Input.GetButtonDown("B"))
        {
          this.CheckForCompletion();
          this.Selecting = false;
          this.SubSlot = 1;
          this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 450f, this.SubHighlight.localPosition.z);
        }
      }
      UISprite slotHighlight = this.SlotHighlights[this.Slot];
      if (!this.Fade)
      {
        slotHighlight.color = new Color(slotHighlight.color.r, slotHighlight.color.g, slotHighlight.color.b, slotHighlight.color.a + 0.0166666675f);
        if ((double) slotHighlight.color.a < 0.5)
          return;
        this.Fade = true;
      }
      else
      {
        slotHighlight.color = new Color(slotHighlight.color.r, slotHighlight.color.g, slotHighlight.color.b, slotHighlight.color.a - 0.0166666675f);
        if ((double) slotHighlight.color.a > 0.0)
          return;
        this.Fade = false;
      }
    }
  }

  private void UpdateHighlights()
  {
    for (int index = 1; index < this.SlotHighlights.Length; ++index)
    {
      UISprite slotHighlight = this.SlotHighlights[index];
      slotHighlight.color = new Color(slotHighlight.color.r, slotHighlight.color.g, slotHighlight.color.b, 0.0f);
    }
  }

  private void UpdateSubLabels()
  {
    if (this.Slot == 1)
    {
      for (this.ID = 1; this.ID < this.SubLabels.Length; ++this.ID)
      {
        UILabel subLabel = this.SubLabels[this.ID];
        subLabel.text = this.Subjects[this.ID];
        subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 1f);
      }
      if (!EventGlobals.Event1)
        this.SubLabels[9].text = "??????????";
      if (!GameGlobals.Eighties)
      {
        if (this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 && this.Yandere.Police.EndOfDay.LearnedOsanaInfo2)
          return;
        this.SubLabels[10].text = "??????????";
      }
      else
      {
        if (this.Yandere.Police.EndOfDay.LearnedAboutPhotographer)
          return;
        this.SubLabels[10].text = "??????????";
      }
    }
    else if (this.Slot == 2)
    {
      for (this.ID = 1; this.ID < this.SubLabels.Length; ++this.ID)
      {
        UILabel subLabel = this.SubLabels[this.ID];
        subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 1f);
        subLabel.text = !this.LifeNote ? this.Locations[this.ID] : this.MurderMethods[this.ID];
      }
    }
    else
    {
      if (this.Slot != 3)
        return;
      for (this.ID = 1; this.ID < this.SubLabels.Length; ++this.ID)
      {
        UILabel subLabel = this.SubLabels[this.ID];
        subLabel.text = this.Times[this.ID];
        subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 1f);
      }
      this.DisableOptions();
    }
  }

  public void CheckForCompletion()
  {
    if (!this.SlotsFilled[1] || !this.SlotsFilled[2] || !this.SlotsFilled[3])
      return;
    this.PromptBar.Label[2].text = "Finish";
    this.PromptBar.UpdateButtons();
  }

  private void Exit()
  {
    this.UpdateHighlights();
    if (!this.Yandere.WritingName)
      this.Yandere.CanMove = true;
    this.Yandere.RPGCamera.enabled = true;
    this.Yandere.Blur.enabled = false;
    this.Yandere.HUD.alpha = 1f;
    Time.timeScale = 1f;
    this.Show = false;
    this.Slot = 1;
    this.PromptBar.Label[0].text = string.Empty;
    this.PromptBar.Label[1].text = string.Empty;
    this.PromptBar.Label[2].text = string.Empty;
    this.PromptBar.Label[4].text = string.Empty;
    this.PromptBar.Show = false;
    this.PromptBar.UpdateButtons();
    this.SlotLabels[1].text = this.OriginalText[1];
    this.SlotLabels[2].text = this.OriginalText[2];
    this.SlotLabels[3].text = this.OriginalText[3];
    this.SlotsFilled[1] = false;
    this.SlotsFilled[2] = false;
    this.SlotsFilled[3] = false;
  }

  private void DisableOptions()
  {
    if ((double) this.Clock.HourTime >= 7.25)
    {
      UILabel subLabel = this.SubLabels[1];
      subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 0.5f);
    }
    if ((double) this.Clock.HourTime >= 7.5)
    {
      UILabel subLabel = this.SubLabels[2];
      subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 0.5f);
    }
    if ((double) this.Clock.HourTime >= 7.75)
    {
      UILabel subLabel = this.SubLabels[3];
      subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 0.5f);
    }
    if ((double) this.Clock.HourTime >= 8.0)
    {
      UILabel subLabel = this.SubLabels[4];
      subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 0.5f);
    }
    if ((double) this.Clock.HourTime >= 8.25)
    {
      UILabel subLabel = this.SubLabels[5];
      subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 0.5f);
    }
    if ((double) this.Clock.HourTime >= 15.5)
    {
      UILabel subLabel = this.SubLabels[6];
      subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 0.5f);
    }
    if ((double) this.Clock.HourTime >= 16.0)
    {
      UILabel subLabel = this.SubLabels[7];
      subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 0.5f);
    }
    if ((double) this.Clock.HourTime >= 16.5)
    {
      UILabel subLabel = this.SubLabels[8];
      subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 0.5f);
    }
    if ((double) this.Clock.HourTime >= 17.0)
    {
      UILabel subLabel = this.SubLabels[9];
      subLabel.color = new Color(subLabel.color.r, subLabel.color.g, subLabel.color.b, 0.5f);
    }
    if ((double) this.Clock.HourTime < 17.5)
      return;
    UILabel subLabel1 = this.SubLabels[10];
    subLabel1.color = new Color(subLabel1.color.r, subLabel1.color.g, subLabel1.color.b, 0.5f);
  }

  public enum NoteSubjectType
  {
    Empty,
    MakingFriends,
    LowGrades,
    FightingEvil,
    SuspiciousActivity,
    YourFriends,
    SocialMedia,
    Bullying,
    TheSupernatural,
    CompensatedDating,
    DomesticAbuse,
  }
}
