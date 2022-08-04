// Decompiled with JetBrains decompiler
// Type: StudentInfoMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudentInfoMenuScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public StudentInfoScript StudentInfo;
  public NoteWindowScript NoteWindow;
  public PromptBarScript PromptBar;
  public JsonScript JSON;
  public GameObject StudentPortrait;
  public Texture UnknownPortrait;
  public Texture BlankPortrait;
  public Texture Headmaster;
  public Texture Counselor;
  public Texture InfoChan;
  public Texture EightiesHeadmaster;
  public Texture EightiesCounselor;
  public Texture EightiesUnknown;
  public Texture Journalist;
  public Transform PortraitGrid;
  public Transform BusyBlocker;
  public Transform Highlight;
  public Transform Scrollbar;
  public StudentPortraitScript[] StudentPortraits;
  public Texture[] RivalPortraits;
  public bool[] PortraitLoaded;
  public UISprite[] DeathShadows;
  public UISprite[] Friends;
  public UISprite[] Panties;
  public UITexture[] PrisonBars;
  public UITexture[] Portraits;
  public UILabel NameLabel;
  public bool FiringCouncilMember;
  public bool GettingOpinions;
  public bool CyberBullying;
  public bool CyberStalking;
  public bool FindingLocker;
  public bool UsingLifeNote;
  public bool GettingInfo;
  public bool MatchMaking;
  public bool Distracting;
  public bool SendingHome;
  public bool Gossiping;
  public bool Targeting;
  public bool Dead;
  public int[] SetSizes;
  public int StudentID;
  public int Column;
  public int Row;
  public int Set;
  public int Columns;
  public int Rows;
  public bool GrabPortraitsNextFrame;
  public int Frame;
  public bool GrabbedPortraits;
  public bool Debugging;

  private void Start()
  {
    StudentGlobals.GetStudentPhotographed(11);
    this.BusyBlocker.position = new Vector3(0.0f, 0.0f, 0.0f);
    for (int index = 1; index < 101; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.StudentPortrait, this.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.PortraitGrid;
      gameObject.transform.localPosition = new Vector3((float) ((double) this.Column * 150.0 - 300.0), (float) (80.0 - (double) this.Row * 160.0), 0.0f);
      gameObject.transform.localEulerAngles = Vector3.zero;
      gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
      this.StudentPortraits[index] = gameObject.GetComponent<StudentPortraitScript>();
      ++this.Column;
      if (this.Column > 4)
      {
        this.Column = 0;
        ++this.Row;
      }
    }
    if (this.PauseScreen.Eighties)
    {
      this.UnknownPortrait = this.EightiesUnknown;
      this.Headmaster = this.EightiesHeadmaster;
      this.Counselor = this.EightiesCounselor;
      this.InfoChan = this.Journalist;
    }
    this.Column = 0;
    this.Row = 0;
  }

  private void Update()
  {
    if (!this.GrabbedPortraits)
    {
      this.StartCoroutine(this.UpdatePortraits());
      this.GrabbedPortraits = true;
      if (this.PauseScreen.Eighties)
        this.PauseScreen.BlackenAllText();
    }
    if (Input.GetButtonDown("A"))
    {
      if (this.PromptBar.Label[0].text != string.Empty)
      {
        if (StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentID > 97)
        {
          if (this.UsingLifeNote)
          {
            this.PauseScreen.MainMenu.SetActive(true);
            this.PauseScreen.Sideways = false;
            this.PauseScreen.Show = false;
            this.gameObject.SetActive(false);
            this.NoteWindow.TargetStudent = this.StudentID;
            this.NoteWindow.gameObject.SetActive(true);
            this.NoteWindow.SlotLabels[1].text = this.StudentManager.Students[this.StudentID].Name;
            this.NoteWindow.SlotsFilled[1] = true;
            this.UsingLifeNote = false;
            this.PromptBar.Label[0].text = "Confirm";
            this.PromptBar.UpdateButtons();
            this.NoteWindow.CheckForCompletion();
          }
          else
          {
            this.StudentInfo.gameObject.SetActive(true);
            this.StudentInfo.UpdateInfo(this.StudentID);
            this.StudentInfo.Topics.SetActive(false);
            this.gameObject.SetActive(false);
            this.PromptBar.ClearButtons();
            if (this.Gossiping)
              this.PromptBar.Label[0].text = "Gossip";
            if (this.Distracting)
              this.PromptBar.Label[0].text = "Distract";
            if (this.CyberBullying || this.CyberStalking)
              this.PromptBar.Label[0].text = "Accept";
            if (this.FindingLocker)
              this.PromptBar.Label[0].text = "Find Locker";
            if (this.MatchMaking)
              this.PromptBar.Label[0].text = "Match";
            if (this.Targeting || this.UsingLifeNote)
              this.PromptBar.Label[0].text = "Kill";
            if (this.SendingHome)
              this.PromptBar.Label[0].text = "Send Home";
            if (this.FiringCouncilMember)
              this.PromptBar.Label[0].text = "Fire";
            if (this.GettingOpinions)
              this.PromptBar.Label[0].text = "Get Opinions";
            this.PromptBar.Label[2].text = !((Object) this.StudentManager.Students[this.StudentID] != (Object) null) ? "" : (!this.StudentManager.Students[this.StudentID].gameObject.activeInHierarchy ? "" : (!((Object) this.StudentManager.Tag.Target == (Object) this.StudentManager.Students[this.StudentID].Head) ? "Tag" : "Untag"));
            this.PromptBar.Label[1].text = "Back";
            this.PromptBar.Label[3].text = "Interests";
            this.PromptBar.Label[6].text = "Reputation";
            this.PromptBar.UpdateButtons();
          }
        }
        else
        {
          StudentGlobals.SetStudentPhotographed(this.StudentID, true);
          if ((Object) this.StudentManager.Students[this.StudentID] != (Object) null)
          {
            for (int index = 0; index < this.StudentManager.Students[this.StudentID].Outlines.Length; ++index)
            {
              if ((Object) this.StudentManager.Students[this.StudentID].Outlines[index] != (Object) null)
                this.StudentManager.Students[this.StudentID].Outlines[index].enabled = true;
            }
          }
          this.PauseScreen.ServiceMenu.gameObject.SetActive(true);
          this.PauseScreen.ServiceMenu.UpdateList();
          this.PauseScreen.ServiceMenu.UpdateDesc();
          this.PauseScreen.ServiceMenu.Purchase();
          this.GettingInfo = false;
          this.gameObject.SetActive(false);
        }
        if (this.PauseScreen.Eighties)
          this.PauseScreen.BlackenAllText();
      }
    }
    else if (Input.GetButtonDown("B"))
    {
      this.BusyBlocker.position = new Vector3(0.0f, 0.0f, 0.0f);
      if (this.Gossiping || this.Distracting || this.MatchMaking || this.Targeting)
      {
        if (this.Targeting)
          this.PauseScreen.Yandere.RPGCamera.enabled = true;
        this.PauseScreen.Yandere.Interaction = YandereInteractionType.Bye;
        this.PauseScreen.Yandere.TalkTimer = 2f;
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.Show = false;
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        this.Distracting = false;
        this.MatchMaking = false;
        this.Gossiping = false;
        this.Targeting = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      }
      else if (this.CyberBullying || this.CyberStalking || this.FindingLocker)
      {
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.Show = false;
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        if (this.FindingLocker)
          this.PauseScreen.Yandere.RPGCamera.enabled = true;
        this.FindingLocker = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      }
      else if (this.SendingHome || this.GettingInfo || this.GettingOpinions || this.FiringCouncilMember)
      {
        this.PauseScreen.ServiceMenu.gameObject.SetActive(true);
        this.PauseScreen.ServiceMenu.UpdateList();
        this.PauseScreen.ServiceMenu.UpdateDesc();
        this.gameObject.SetActive(false);
        this.FiringCouncilMember = false;
        this.GettingOpinions = false;
        this.SendingHome = false;
        this.GettingInfo = false;
      }
      else if (this.UsingLifeNote)
      {
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.Show = false;
        this.gameObject.SetActive(false);
        this.NoteWindow.gameObject.SetActive(true);
        this.UsingLifeNote = false;
      }
      else
      {
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.PressedB = true;
        this.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[1].text = "Exit";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
      }
    }
    else
    {
      float t = Time.unscaledDeltaTime * 10f;
      this.PortraitGrid.localPosition = new Vector3(this.PortraitGrid.localPosition.x, Mathf.Lerp(this.PortraitGrid.localPosition.y, 320f * (this.Row % 2 == 0 ? (float) (this.Row / 2) : (float) ((this.Row - 1) / 2)), t), this.PortraitGrid.localPosition.z);
      this.Scrollbar.localPosition = new Vector3(this.Scrollbar.localPosition.x, Mathf.Lerp(this.Scrollbar.localPosition.y, (float) (175.0 - 350.0 * ((double) this.PortraitGrid.localPosition.y / 2880.0)), t), this.Scrollbar.localPosition.z);
      if (this.InputManager.TappedUp)
      {
        --this.Row;
        if (this.Row < 0)
          this.Row = this.Rows - 1;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedDown)
      {
        ++this.Row;
        if (this.Row > this.Rows - 1)
          this.Row = 0;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedRight)
      {
        ++this.Column;
        if (this.Column > this.Columns - 1)
          this.Column = 0;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedLeft)
      {
        --this.Column;
        if (this.Column < 0)
          this.Column = this.Columns - 1;
        this.UpdateHighlight();
      }
    }
    if (!this.GrabPortraitsNextFrame)
      return;
    ++this.Frame;
    if (this.Frame <= 1)
      return;
    this.StartCoroutine(this.UpdatePortraits());
    this.GrabPortraitsNextFrame = false;
    this.Frame = 0;
  }

  public void UpdateHighlight()
  {
    this.Highlight.localPosition = new Vector3((float) ((double) this.Column * 150.0 - 300.0), (float) (80.0 - (double) this.Row * 160.0), this.Highlight.localPosition.z);
    this.BusyBlocker.position = new Vector3(0.0f, 0.0f, 0.0f);
    this.StudentID = 1 + (this.Column + this.Row * this.Columns);
    if (StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentID > 97)
    {
      this.PromptBar.Label[0].text = "View Info";
      this.PromptBar.UpdateButtons();
    }
    else
    {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.Gossiping && (this.StudentID == 1 || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || this.JSON.Students[this.StudentID].Club == ClubType.Sports || (Object) this.StudentManager.Students[this.StudentID] == (Object) null || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID == this.StudentManager.RivalID && this.StudentManager.Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Expelled || this.StudentID > 89))
    {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.CyberBullying && (this.JSON.Students[this.StudentID].Gender == 1 || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97))
    {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.CyberStalking && (StudentGlobals.GetStudentDead(this.StudentID) || StudentGlobals.GetStudentArrested(this.StudentID) || this.StudentID > 97))
    {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.FindingLocker && (this.StudentID == 1 || this.StudentID > 89 || (Object) this.StudentManager.Students[this.StudentID] != (Object) null && this.StudentManager.Students[this.StudentID].Club == ClubType.Council || StudentGlobals.GetStudentDead(this.StudentID)))
    {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.Distracting)
    {
      this.Dead = false;
      if ((Object) this.StudentManager.Students[this.StudentID] == (Object) null)
        this.Dead = true;
      if (this.Dead)
      {
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.UpdateButtons();
      }
      else if (this.StudentID == 1 || !this.StudentManager.Students[this.StudentID].Alive || this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentKidnapped(this.StudentID) || this.StudentManager.Students[this.StudentID].Tranquil || this.StudentManager.Students[this.StudentID].Teacher || this.StudentManager.Students[this.StudentID].Slave || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentManager.Students[this.StudentID].MyBento.Tampered || this.StudentID > 97)
      {
        if (this.StudentID > 1 && (Object) this.StudentManager.Students[this.StudentID] != (Object) null && this.StudentManager.Students[this.StudentID].InEvent)
          this.BusyBlocker.position = this.Highlight.position;
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.UpdateButtons();
      }
    }
    if (this.MatchMaking && (this.StudentID == this.PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID > 97))
    {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.Targeting && ((Object) this.StudentManager.Students[this.StudentID] == (Object) null || this.StudentID == 1 || this.StudentID > 97 || StudentGlobals.GetStudentDead(this.StudentID) || !this.StudentManager.Students[this.StudentID].gameObject.activeInHierarchy || this.StudentManager.Students[this.StudentID].InEvent || this.StudentManager.Students[this.StudentID].Tranquil))
    {
      if (this.StudentID > 1 && (Object) this.StudentManager.Students[this.StudentID] != (Object) null && this.StudentManager.Students[this.StudentID].InEvent)
        this.BusyBlocker.position = this.Highlight.position;
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    if (this.SendingHome)
    {
      Debug.Log((object) ("Highlighting student number " + this.StudentID.ToString()));
      if ((Object) this.StudentManager.Students[this.StudentID] != (Object) null)
      {
        StudentScript student = this.StudentManager.Students[this.StudentID];
        if (this.StudentID == 1 || StudentGlobals.GetStudentDead(this.StudentID) || this.StudentID < 98 && student.SentHome || this.StudentID > 97 || StudentGlobals.StudentSlave == this.StudentID || student.Club == ClubType.MartialArts && student.ClubAttire || student.Club == ClubType.Sports && student.ClubAttire || this.StudentManager.Students[this.StudentID].CameraReacting || !StudentGlobals.GetStudentPhotographed(this.StudentID) || student.Wet || student.Slave || student.Phoneless)
        {
          this.PromptBar.Label[0].text = string.Empty;
          this.PromptBar.UpdateButtons();
        }
      }
    }
    if (this.GettingInfo)
    {
      this.PromptBar.Label[0].text = StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentID > 97 ? string.Empty : "Get Info";
      this.PromptBar.UpdateButtons();
    }
    if (this.GettingOpinions)
    {
      this.PromptBar.Label[0].text = "Get Opinions";
      this.PromptBar.UpdateButtons();
    }
    if (this.UsingLifeNote)
    {
      this.PromptBar.Label[0].text = this.StudentID == 1 || this.StudentID > 97 || this.StudentID > 11 && this.StudentID < 21 || this.StudentPortraits[this.StudentID].DeathShadow.activeInHierarchy || (Object) this.StudentManager.Students[this.StudentID] != (Object) null && !this.StudentManager.Students[this.StudentID].enabled ? "" : "Kill";
      this.PromptBar.UpdateButtons();
    }
    if (this.FiringCouncilMember)
    {
      if ((Object) this.StudentManager.Students[this.StudentID] != (Object) null)
        this.PromptBar.Label[0].text = !StudentGlobals.GetStudentPhotographed(this.StudentID) || this.StudentManager.Students[this.StudentID].Club != ClubType.Council ? "" : "Fire";
      this.PromptBar.UpdateButtons();
    }
    if (MissionModeGlobals.MissionMode && this.StudentID == 1)
      this.PromptBar.Label[0].text = "";
    if (this.PauseScreen.Eighties && (Object) this.Headmaster != (Object) this.EightiesHeadmaster)
    {
      this.Headmaster = this.EightiesHeadmaster;
      this.Counselor = this.EightiesCounselor;
      this.InfoChan = this.Journalist;
      if ((Object) this.StudentPortraits[98] != (Object) null)
      {
        this.StudentPortraits[98].Portrait.mainTexture = this.Counselor;
        this.StudentPortraits[99].Portrait.mainTexture = this.Headmaster;
        this.StudentPortraits[100].Portrait.mainTexture = this.InfoChan;
      }
    }
    this.UpdateNameLabel();
  }

  private void UpdateNameLabel()
  {
    if (this.StudentID > 97 || StudentGlobals.GetStudentPhotographed(this.StudentID) || this.GettingInfo)
    {
      this.NameLabel.text = this.JSON.Students[this.StudentID].Name;
      if (!this.StudentManager.Eighties || this.StudentID <= 10 || this.StudentID >= 21 || DateGlobals.Week >= this.StudentID - 10)
        return;
      this.NameLabel.text = "Unknown";
    }
    else
      this.NameLabel.text = "Unknown";
  }

  public IEnumerator UpdatePortraits()
  {
    if (this.Debugging)
      Debug.Log((object) "The Student Info Menu was instructed to get photos.");
    string EightiesPrefix = "";
    if (this.PauseScreen.Eighties)
      EightiesPrefix = "1989";
    for (int ID = 1; ID < 101; ++ID)
    {
      if (ID == 0)
        this.StudentPortraits[ID].Portrait.mainTexture = this.InfoChan;
      else if (!this.PortraitLoaded[ID])
      {
        if (ID < 98)
        {
          if (this.PauseScreen.Eighties || !this.PauseScreen.Eighties && ID < 12 || !this.PauseScreen.Eighties && ID > 20)
          {
            if (StudentGlobals.GetStudentPhotographed(ID))
            {
              WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + EightiesPrefix + "/Student_" + ID.ToString() + ".png");
              yield return (object) www;
              if (www.error == null)
              {
                if (!StudentGlobals.GetStudentReplaced(ID))
                  this.StudentPortraits[ID].Portrait.mainTexture = (Texture) www.texture;
                else
                  this.StudentPortraits[ID].Portrait.mainTexture = this.BlankPortrait;
              }
              else
              {
                Debug.Log((object) ("Student #" + ID.ToString() + " gets an '' Unknown'' portrait because an error occured."));
                this.StudentPortraits[ID].Portrait.mainTexture = this.UnknownPortrait;
              }
              this.PortraitLoaded[ID] = true;
              www = (WWW) null;
            }
            else
              this.StudentPortraits[ID].Portrait.mainTexture = this.UnknownPortrait;
          }
          else
            this.StudentPortraits[ID].Portrait.mainTexture = this.RivalPortraits[ID];
        }
        else
        {
          switch (ID)
          {
            case 98:
              this.StudentPortraits[ID].Portrait.mainTexture = this.Counselor;
              break;
            case 99:
              this.StudentPortraits[ID].Portrait.mainTexture = this.Headmaster;
              break;
            case 100:
              this.StudentPortraits[ID].Portrait.mainTexture = this.InfoChan;
              break;
            default:
              this.StudentPortraits[ID].Portrait.mainTexture = this.RivalPortraits[ID];
              break;
          }
        }
      }
      if (this.StudentManager.PantyShotTaken[ID] || PlayerGlobals.GetStudentPantyShot(ID))
        this.StudentPortraits[ID].Panties.SetActive(true);
      if ((Object) this.StudentManager.Students[ID] != (Object) null)
        this.StudentPortraits[ID].Friend.SetActive(this.StudentManager.Students[ID].Friend);
      if (StudentGlobals.GetStudentDying(ID) || StudentGlobals.GetStudentDead(ID) || (Object) this.StudentManager.Students[ID] != (Object) null && !this.StudentManager.Students[ID].Alive)
        this.StudentPortraits[ID].DeathShadow.SetActive(true);
      if (MissionModeGlobals.MissionMode && ID == 1)
        this.StudentPortraits[ID].DeathShadow.SetActive(true);
      if (SceneManager.GetActiveScene().name == "SchoolScene" && (Object) this.StudentManager.Students[ID] != (Object) null && this.StudentManager.Students[ID].Tranquil)
        this.StudentPortraits[ID].DeathShadow.SetActive(true);
      if (StudentGlobals.GetStudentArrested(ID))
      {
        this.StudentPortraits[ID].PrisonBars.SetActive(true);
        this.StudentPortraits[ID].DeathShadow.SetActive(true);
      }
      if (this.StudentManager.Eighties && ID > 11 && ID < 21 && DateGlobals.Week < ID - 10)
        this.StudentPortraits[ID].Portrait.mainTexture = this.UnknownPortrait;
    }
  }
}
