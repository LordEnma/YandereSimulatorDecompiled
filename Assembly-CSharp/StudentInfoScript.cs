// Decompiled with JetBrains decompiler
// Type: StudentInfoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StudentInfoScript : MonoBehaviour
{
  public StudentInfoMenuScript StudentInfoMenu;
  public StudentManagerScript StudentManager;
  public DialogueWheelScript DialogueWheel;
  public HomeInternetScript HomeInternet;
  public TopicManagerScript TopicManager;
  public NoteLockerScript NoteLocker;
  public RadarChart ReputationChart;
  public PromptBarScript PromptBar;
  public ShutterScript Shutter;
  public YandereScript Yandere;
  public JsonScript JSON;
  public Texture GuidanceCounselor;
  public Texture DefaultPortrait;
  public Texture BlankPortrait;
  public Texture Headmaster;
  public Texture InfoChan;
  public Transform ReputationBar;
  public GameObject Static;
  public GameObject Topics;
  public UILabel OccupationLabel;
  public UILabel ReputationLabel;
  public UILabel RealNameLabel;
  public UILabel StrengthLabel;
  public UILabel PersonaLabel;
  public UILabel ClassLabel;
  public UILabel CrushLabel;
  public UILabel ClubLabel;
  public UILabel InfoLabel;
  public UILabel NameLabel;
  public UITexture Portrait;
  public string[] OpinionSpriteNames;
  public string[] Strings;
  public int CurrentStudent;
  public bool UpdatedOnce;
  public bool Eighties;
  public bool ShowRep;
  public bool Back;
  public UISprite[] TopicIcons;
  public UISprite[] TopicOpinionIcons;
  private static readonly IntAndStringDictionary StrengthStrings;
  public UILabel LeftCrushLabel;
  public string PartnerName;
  public bool Matchmade;

  private void Start()
  {
    StudentGlobals.SetStudentPhotographed(98, true);
    StudentGlobals.SetStudentPhotographed(99, true);
    StudentGlobals.SetStudentPhotographed(100, true);
    this.Topics.SetActive(false);
    this.Eighties = GameGlobals.Eighties;
    if (this.Eighties)
      this.InfoLabel.transform.localPosition += new Vector3(0.0f, -10f, 0.0f);
    if (this.UpdatedOnce)
      return;
    this.UpdateInfo(this.StudentInfoMenu.StudentID);
  }

  public void UpdateInfo(int ID)
  {
    this.CurrentStudent = ID;
    if (!this.UpdatedOnce)
      this.Eighties = GameGlobals.Eighties;
    this.UpdatedOnce = true;
    StudentJson student = this.JSON.Students[ID];
    if (student.RealName == "")
    {
      this.NameLabel.transform.localPosition = new Vector3(-228f, 195f, 0.0f);
      this.RealNameLabel.text = "";
    }
    else
    {
      this.NameLabel.transform.localPosition = new Vector3(-228f, 210f, 0.0f);
      this.RealNameLabel.text = "Real Name: " + student.RealName;
    }
    this.NameLabel.text = student.Name;
    this.ClassLabel.text = "Class " + (student.Class.ToString() ?? "").Insert(1, "-");
    if (ID == 90 || ID > 96)
      this.ClassLabel.text = "";
    float num1 = !((Object) this.StudentManager != (Object) null) ? (float) StudentGlobals.GetStudentReputation(ID) : this.StudentManager.StudentReps[ID];
    this.ReputationLabel.text = (double) num1 >= 0.0 ? ((double) num1 <= 0.0 ? "0" : "+" + num1.ToString()) : num1.ToString() ?? "";
    this.ReputationBar.localPosition = new Vector3(num1 * 0.96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
    if ((double) this.ReputationBar.localPosition.x > 96.0)
      this.ReputationBar.localPosition = new Vector3(96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
    if ((double) this.ReputationBar.localPosition.x < -96.0)
      this.ReputationBar.localPosition = new Vector3(-96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
    this.PersonaLabel.text = !((Object) this.StudentManager != (Object) null) || !((Object) this.StudentManager.Students[this.CurrentStudent] != (Object) null) ? Persona.PersonaNames[student.Persona] : Persona.PersonaNames[this.StudentManager.Students[this.CurrentStudent].Persona];
    if (student.Persona == PersonaType.Strict && student.Club == ClubType.GymTeacher && !StudentGlobals.GetStudentReplaced(ID))
      this.PersonaLabel.text = "Friendly but Strict";
    this.MatchmadeCheck();
    int num2 = 0;
    if ((Object) this.StudentManager != (Object) null)
      num2 = this.StudentManager.SuitorID;
    if (this.Matchmade)
    {
      this.LeftCrushLabel.text = "Relationship";
      this.CrushLabel.text = this.JSON.Students[student.Crush].Name;
      this.CrushLabel.text = this.PartnerName;
    }
    else
    {
      this.LeftCrushLabel.text = "Crush";
      if (this.CurrentStudent > 10 && this.CurrentStudent < 21)
        this.CrushLabel.text = this.CurrentStudent != this.StudentManager.RivalID ? "None Anymore" : this.JSON.Students[student.Crush].Name;
      if (this.CurrentStudent == num2)
        this.CrushLabel.text = this.StudentManager.LoveManager.SuitorProgress != 0 ? this.JSON.Students[student.Crush].Name : "Unknown";
      else if (student.Crush == 0)
        this.CrushLabel.text = "Unknown";
      else if (student.Crush == 99)
      {
        this.CrushLabel.text = "?????";
      }
      else
      {
        this.CrushLabel.text = this.JSON.Students[student.Crush].Name;
        for (int index = 2; index < 11; ++index)
        {
          if (this.CurrentStudent == this.StudentManager.SuitorIDs[index] && this.StudentManager.Week < index)
            this.CrushLabel.text = "Unknown";
        }
      }
    }
    this.OccupationLabel.text = student.Club >= ClubType.Teacher ? "Occupation" : "Club";
    this.ClubLabel.text = student.Club >= ClubType.Teacher ? Club.TeacherClubNames[student.Class] : Club.ClubNames[student.Club];
    if (ClubGlobals.GetClubClosed(student.Club))
      this.ClubLabel.text = "No Club";
    this.StrengthLabel.text = StudentInfoScript.StrengthStrings[student.Strength];
    AudioSource component = this.GetComponent<AudioSource>();
    component.enabled = false;
    this.Static.SetActive(false);
    component.volume = 0.0f;
    component.Stop();
    string str = "";
    if (this.Eighties)
      str = "1989";
    if (ID < 98)
    {
      if (this.Eighties || !this.Eighties && ID < 12 || !this.Eighties && ID > 20)
      {
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + str + "/Student_" + ID.ToString() + ".png");
        if (!StudentGlobals.GetStudentReplaced(ID))
          this.Portrait.mainTexture = (Texture) www.texture;
        else
          this.Portrait.mainTexture = this.BlankPortrait;
        if (this.Eighties && this.CurrentStudent > 10 && this.CurrentStudent < 21 && DateGlobals.Week < this.CurrentStudent - 10)
          this.Portrait.mainTexture = this.StudentInfoMenu.EightiesUnknown;
      }
      else
        this.Portrait.mainTexture = this.StudentInfoMenu.RivalPortraits[ID];
    }
    else
    {
      switch (ID)
      {
        case 98:
          this.Portrait.mainTexture = this.StudentInfoMenu.Counselor;
          break;
        case 99:
          this.Portrait.mainTexture = this.StudentInfoMenu.Headmaster;
          break;
        case 100:
          this.Portrait.mainTexture = this.StudentInfoMenu.InfoChan;
          if (!this.Eighties)
          {
            this.Static.SetActive(true);
            if (!this.StudentInfoMenu.Gossiping && !this.StudentInfoMenu.Distracting && !this.StudentInfoMenu.CyberBullying && !this.StudentInfoMenu.CyberStalking)
            {
              component.enabled = true;
              component.volume = 1f;
              component.Play();
              break;
            }
            break;
          }
          break;
      }
    }
    this.UpdateAdditionalInfo(ID);
    this.UpdateRepChart();
    this.CensorUnknownRivalInfo();
  }

  private void Update()
  {
    if (this.CurrentStudent == 100)
      this.UpdateRepChart();
    if (Input.GetButtonDown("A"))
    {
      if (this.StudentInfoMenu.Gossiping)
      {
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.DialogueWheel.Victim = this.CurrentStudent;
        this.StudentInfoMenu.Gossiping = false;
        this.gameObject.SetActive(false);
        Time.timeScale = 0.0001f;
        this.DialogueWheel.TopicInterface.Socializing = false;
        this.DialogueWheel.TopicInterface.StudentID = this.Yandere.TargetStudent.StudentID;
        this.DialogueWheel.TopicInterface.Student = this.Yandere.TargetStudent;
        this.DialogueWheel.TopicInterface.TargetStudentID = this.CurrentStudent;
        this.DialogueWheel.TopicInterface.TargetStudent = this.StudentManager.Students[this.CurrentStudent];
        this.DialogueWheel.TopicInterface.UpdateOpinions();
        this.DialogueWheel.TopicInterface.UpdateTopicHighlight();
        this.DialogueWheel.TopicInterface.gameObject.SetActive(true);
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Speak";
        this.PromptBar.Label[1].text = "Back";
        this.PromptBar.Label[2].text = "Positive/Negative";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
      }
      else if (this.StudentInfoMenu.Distracting)
      {
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.DialogueWheel.Victim = this.CurrentStudent;
        this.StudentInfoMenu.Distracting = false;
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      }
      else if (this.StudentInfoMenu.CyberBullying)
      {
        this.HomeInternet.PostLabels[1].text = this.JSON.Students[this.CurrentStudent].Name;
        this.HomeInternet.Student = this.CurrentStudent;
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.StudentInfoMenu.CyberBullying = false;
        this.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      }
      else if (this.StudentInfoMenu.CyberStalking)
      {
        this.HomeInternet.HomeCamera.CyberstalkWindow.SetActive(true);
        this.HomeInternet.Student = this.CurrentStudent;
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.StudentInfoMenu.CyberStalking = false;
        this.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      }
      else if (this.StudentInfoMenu.MatchMaking)
      {
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.DialogueWheel.Victim = this.CurrentStudent;
        this.StudentInfoMenu.MatchMaking = false;
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      }
      else if (this.StudentInfoMenu.Targeting)
      {
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.Yandere.TargetStudent.HuntTarget = this.StudentManager.Students[this.CurrentStudent];
        this.Yandere.TargetStudent.HuntTarget.Hunted = true;
        this.Yandere.TargetStudent.GoCommitMurder();
        this.Yandere.RPGCamera.enabled = true;
        this.Yandere.TargetStudent = (StudentScript) null;
        this.StudentInfoMenu.Targeting = false;
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
      }
      else if (this.StudentInfoMenu.SendingHome)
      {
        if (this.CurrentStudent == 10 || this.CurrentStudent == this.StudentManager.RivalID)
        {
          this.StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(11);
          this.gameObject.SetActive(false);
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = string.Empty;
          this.PromptBar.Label[1].text = "Back";
          this.PromptBar.UpdateButtons();
        }
        else if (this.StudentManager.Students[this.CurrentStudent].Routine && !this.StudentManager.Students[this.CurrentStudent].InEvent && !this.StudentManager.Students[this.CurrentStudent].TargetedForDistraction && this.StudentManager.Students[this.CurrentStudent].ClubActivityPhase < 16 && !this.StudentManager.Students[this.CurrentStudent].MyBento.Tampered)
        {
          this.StudentManager.Students[this.CurrentStudent].Routine = false;
          this.StudentManager.Students[this.CurrentStudent].SentHome = true;
          this.StudentManager.Students[this.CurrentStudent].CameraReacting = false;
          this.StudentManager.Students[this.CurrentStudent].SpeechLines.Stop();
          this.StudentManager.Students[this.CurrentStudent].EmptyHands();
          this.StudentInfoMenu.PauseScreen.ServiceMenu.gameObject.SetActive(true);
          this.StudentInfoMenu.PauseScreen.ServiceMenu.UpdateList();
          this.StudentInfoMenu.PauseScreen.ServiceMenu.UpdateDesc();
          this.StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
          this.StudentInfoMenu.SendingHome = false;
          this.gameObject.SetActive(false);
          this.PromptBar.ClearButtons();
          this.PromptBar.Show = false;
        }
        else
        {
          this.StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(0);
          this.gameObject.SetActive(false);
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = string.Empty;
          this.PromptBar.Label[1].text = "Back";
          this.PromptBar.UpdateButtons();
        }
      }
      else if (this.StudentInfoMenu.FindingLocker)
      {
        this.NoteLocker.gameObject.SetActive(true);
        this.NoteLocker.transform.position = this.StudentManager.Students[this.StudentInfoMenu.StudentID].MyLocker.position;
        this.NoteLocker.transform.position += new Vector3(0.0f, 1.355f, 0.0f);
        this.NoteLocker.transform.position += this.StudentManager.Students[this.StudentInfoMenu.StudentID].MyLocker.forward * 0.33333f;
        this.NoteLocker.Prompt.Label[0].text = "     Leave note for " + this.StudentManager.Students[this.StudentInfoMenu.StudentID].Name;
        this.NoteLocker.Student = this.StudentManager.Students[this.StudentInfoMenu.StudentID];
        this.NoteLocker.LockerOwner = this.StudentInfoMenu.StudentID;
        this.NoteLocker.Prompt.enabled = true;
        this.NoteLocker.transform.GetChild(0).gameObject.SetActive(true);
        this.NoteLocker.CheckingNote = false;
        this.NoteLocker.CanLeaveNote = true;
        this.NoteLocker.SpawnedNote = false;
        this.NoteLocker.NoteLeft = false;
        this.NoteLocker.Success = false;
        this.NoteLocker.Timer = 0.0f;
        this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
        this.StudentInfoMenu.PauseScreen.Show = false;
        this.StudentInfoMenu.FindingLocker = false;
        this.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
        this.Yandere.RPGCamera.enabled = true;
        Time.timeScale = 1f;
        if (this.StudentInfoMenu.StudentID == 11 && SchemeGlobals.GetSchemeStage(6) == 4)
        {
          SchemeGlobals.SetSchemeStage(6, 5);
          this.Yandere.PauseScreen.Schemes.UpdateInstructions();
        }
      }
      else if (this.StudentInfoMenu.FiringCouncilMember)
      {
        if (this.StudentManager.Students[this.CurrentStudent].Routine && !this.StudentManager.Students[this.CurrentStudent].InEvent && !this.StudentManager.Students[this.CurrentStudent].TargetedForDistraction && this.StudentManager.Students[this.CurrentStudent].ClubActivityPhase < 16 && !this.StudentManager.Students[this.CurrentStudent].MyBento.Tampered)
        {
          this.StudentManager.Students[this.CurrentStudent].OriginalPersona = PersonaType.Heroic;
          this.StudentManager.Students[this.CurrentStudent].Persona = PersonaType.Heroic;
          this.StudentManager.Students[this.CurrentStudent].Club = ClubType.None;
          this.StudentManager.Students[this.CurrentStudent].CameraReacting = false;
          this.StudentManager.Students[this.CurrentStudent].SpeechLines.Stop();
          this.StudentManager.Students[this.CurrentStudent].EmptyHands();
          this.StudentManager.Students[this.CurrentStudent].IdleAnim = this.StudentManager.Students[this.CurrentStudent].BulliedIdleAnim;
          this.StudentManager.Students[this.CurrentStudent].WalkAnim = this.StudentManager.Students[this.CurrentStudent].BulliedWalkAnim;
          this.StudentManager.Students[this.CurrentStudent].Armband.SetActive(false);
          StudentScript student = this.StudentManager.Students[this.CurrentStudent];
          ScheduleBlock scheduleBlock = student.ScheduleBlocks[3];
          scheduleBlock.destination = "LunchSpot";
          scheduleBlock.action = "Eat";
          student.GetDestinations();
          student.CurrentDestination = student.Destinations[student.Phase];
          student.Pathfinding.target = student.Destinations[student.Phase];
          this.StudentInfoMenu.PauseScreen.ServiceMenu.gameObject.SetActive(true);
          this.StudentInfoMenu.PauseScreen.ServiceMenu.UpdateList();
          this.StudentInfoMenu.PauseScreen.ServiceMenu.UpdateDesc();
          this.StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
          this.StudentInfoMenu.FiringCouncilMember = false;
          this.StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(9);
        }
        else
          this.StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(0);
        this.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.Label[1].text = "Back";
        this.PromptBar.UpdateButtons();
      }
      else if (this.StudentInfoMenu.GettingOpinions)
      {
        for (int topicID = 1; topicID < 26; ++topicID)
        {
          ConversationGlobals.SetTopicDiscovered(topicID, true);
          ConversationGlobals.SetTopicLearnedByStudent(topicID, this.CurrentStudent, true);
        }
        this.StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
        this.gameObject.SetActive(false);
        this.StudentInfoMenu.GettingOpinions = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.Label[1].text = "Back";
        this.PromptBar.UpdateButtons();
      }
    }
    if (Input.GetButtonDown("B"))
    {
      this.ShowRep = false;
      this.Topics.SetActive(false);
      this.GetComponent<AudioSource>().Stop();
      this.ReputationChart.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
      if ((Object) this.Shutter != (Object) null)
      {
        if (!this.Shutter.PhotoIcons.activeInHierarchy)
          this.Back = true;
      }
      else
        this.Back = true;
      if (this.Back)
      {
        this.StudentInfoMenu.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "View Info";
        if (!this.StudentInfoMenu.Gossiping)
          this.PromptBar.Label[1].text = "Back";
        this.PromptBar.UpdateButtons();
        this.Back = false;
      }
    }
    if (Input.GetButtonDown("X") && this.PromptBar.Button[2].enabled)
    {
      if ((Object) this.StudentManager.Tag.Target != (Object) this.StudentManager.Students[this.CurrentStudent].Head)
      {
        this.StudentManager.Tag.Target = this.StudentManager.Students[this.CurrentStudent].Head;
        this.StudentManager.TagStudentID = this.CurrentStudent;
        this.PromptBar.Label[2].text = "Untag";
      }
      else
      {
        this.StudentManager.TagStudentID = 0;
        this.StudentManager.Tag.Target = (Transform) null;
        this.PromptBar.Label[2].text = "Tag";
      }
    }
    if (Input.GetButtonDown("Y") && this.PromptBar.Button[3].enabled)
    {
      if (!this.Topics.activeInHierarchy)
      {
        this.PromptBar.Label[3].text = "Basic Info";
        this.PromptBar.UpdateButtons();
        this.Topics.SetActive(true);
        this.UpdateTopics();
      }
      else
      {
        this.PromptBar.Label[3].text = "Interests";
        this.PromptBar.UpdateButtons();
        this.Topics.SetActive(false);
      }
    }
    if (Input.GetButtonDown("LB"))
    {
      this.UpdateRepChart();
      this.ShowRep = !this.ShowRep;
    }
    if ((Object) this.Yandere != (Object) null && !this.Yandere.NoDebug)
    {
      if (Input.GetKeyDown(KeyCode.Equals))
      {
        this.StudentManager.StudentReps[this.CurrentStudent] += 10f;
        this.UpdateInfo(this.CurrentStudent);
      }
      if (Input.GetKeyDown(KeyCode.Minus))
      {
        this.StudentManager.StudentReps[this.CurrentStudent] -= 10f;
        this.UpdateInfo(this.CurrentStudent);
      }
    }
    StudentInfoMenuScript studentInfoMenu = this.StudentInfoMenu;
    if (!studentInfoMenu.CyberBullying && !studentInfoMenu.CyberStalking && !studentInfoMenu.FindingLocker && !studentInfoMenu.UsingLifeNote && !studentInfoMenu.GettingInfo && !studentInfoMenu.MatchMaking && !studentInfoMenu.Distracting && !studentInfoMenu.SendingHome && !studentInfoMenu.Gossiping && !studentInfoMenu.Targeting && !studentInfoMenu.GettingOpinions && !studentInfoMenu.Dead)
    {
      if (this.StudentInfoMenu.PauseScreen.InputManager.TappedRight)
      {
        ++this.CurrentStudent;
        if (this.CurrentStudent > 100)
          this.CurrentStudent = 1;
        while (!StudentGlobals.GetStudentPhotographed(this.CurrentStudent))
        {
          ++this.CurrentStudent;
          if (this.CurrentStudent > 100)
            this.CurrentStudent = 1;
        }
        this.UpdateInfo(this.CurrentStudent);
        this.UpdateTopics();
      }
      if (this.StudentInfoMenu.PauseScreen.InputManager.TappedLeft)
      {
        --this.CurrentStudent;
        if (this.CurrentStudent < 1)
          this.CurrentStudent = 100;
        while (!StudentGlobals.GetStudentPhotographed(this.CurrentStudent))
        {
          --this.CurrentStudent;
          if (this.CurrentStudent < 1)
            this.CurrentStudent = 100;
        }
        this.UpdateInfo(this.CurrentStudent);
        this.UpdateTopics();
      }
    }
    if (this.ShowRep)
      this.ReputationChart.transform.localScale = Vector3.Lerp(this.ReputationChart.transform.localScale, new Vector3(138f, 138f, 138f), Time.unscaledDeltaTime * 10f);
    else
      this.ReputationChart.transform.localScale = Vector3.Lerp(this.ReputationChart.transform.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.unscaledDeltaTime * 10f);
  }

  private void UpdateAdditionalInfo(int ID)
  {
    if (!this.Eighties)
    {
      switch (ID)
      {
        case 11:
          if ((Object) this.Yandere != (Object) null)
          {
            this.Strings[1] = this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 ? "May be a victim of blackmail." : "?????";
            this.Strings[2] = this.Yandere.Police.EndOfDay.LearnedOsanaInfo2 ? "Has a stalker." : "?????";
          }
          else
          {
            this.Strings[1] = "?????";
            this.Strings[2] = "?????";
          }
          this.InfoLabel.text = this.Strings[1] + "\n\n" + this.Strings[2];
          break;
        case 51:
          if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
          {
            this.InfoLabel.text = "Disbanded the Light Music Club, dyed her hair back to its original color, removed her piercings, and stopped socializing with others.";
            break;
          }
          this.InfoLabel.text = this.JSON.Students[ID].Info;
          break;
        default:
          if (!StudentGlobals.GetStudentReplaced(ID))
          {
            if (this.JSON.Students[ID].Info == string.Empty)
            {
              this.InfoLabel.text = "No additional information is available at this time.";
              break;
            }
            this.InfoLabel.text = this.JSON.Students[ID].Info;
            break;
          }
          this.InfoLabel.text = "No additional information is available at this time.";
          break;
      }
    }
    else if (!StudentGlobals.GetStudentReplaced(ID))
    {
      if (this.JSON.Students[ID].Info == string.Empty)
        this.InfoLabel.text = "No additional information is available at this time.";
      else
        this.InfoLabel.text = this.JSON.Students[ID].Info;
    }
    else
      this.InfoLabel.text = "No additional information is available at this time.";
  }

  private void UpdateTopics()
  {
    int num1 = 0;
    int num2 = 0;
    for (int topicID = 1; topicID < this.TopicIcons.Length; ++topicID)
      this.TopicIcons[topicID].spriteName = (!ConversationGlobals.GetTopicDiscovered(topicID) ? 0 : topicID).ToString();
    for (int topicID = 1; topicID <= 25; ++topicID)
    {
      UISprite topicOpinionIcon = this.TopicOpinionIcons[topicID];
      if (!ConversationGlobals.GetTopicLearnedByStudent(topicID, this.CurrentStudent))
      {
        topicOpinionIcon.spriteName = "Unknown";
      }
      else
      {
        int[] topics = this.JSON.Topics[this.CurrentStudent].Topics;
        topicOpinionIcon.spriteName = this.OpinionSpriteNames[topics[topicID]];
        if (topics[topicID] == 1)
          ++num2;
        if (topics[topicID] == 2)
          ++num1;
      }
    }
  }

  private void UpdateRepChart()
  {
    Vector3 vector3 = Vector3.zero;
    vector3 = this.CurrentStudent >= 100 ? (this.Eighties ? new Vector3(0.0f, 50f, 100f) : new Vector3((float) Random.Range(-100, 101), (float) Random.Range(-100, 101), (float) Random.Range(-100, 101))) : StudentGlobals.GetReputationTriangle(this.CurrentStudent);
    this.ReputationChart.fields[0].Value = vector3.x;
    this.ReputationChart.fields[1].Value = vector3.y;
    this.ReputationChart.fields[2].Value = vector3.z;
  }

  private void MatchmadeCheck()
  {
    this.Matchmade = false;
    if (this.Eighties)
    {
      if ((this.CurrentStudent <= 10 || this.CurrentStudent >= 21 || GameGlobals.GetRivalEliminations(this.CurrentStudent - 10) != 6) && (this.CurrentStudent != 22 || GameGlobals.GetRivalEliminations(1) != 6) && (this.CurrentStudent != 27 || GameGlobals.GetRivalEliminations(2) != 6) && (this.CurrentStudent != 32 || GameGlobals.GetRivalEliminations(3) != 6) && (this.CurrentStudent != 37 || GameGlobals.GetRivalEliminations(4) != 6) && (this.CurrentStudent != 42 || GameGlobals.GetRivalEliminations(5) != 6) && (this.CurrentStudent != 47 || GameGlobals.GetRivalEliminations(6) != 6) && (this.CurrentStudent != 57 || GameGlobals.GetRivalEliminations(7) != 6) && (this.CurrentStudent != 62 || GameGlobals.GetRivalEliminations(8) != 6) && (this.CurrentStudent != 67 || GameGlobals.GetRivalEliminations(9) != 6) && (this.CurrentStudent != 72 || GameGlobals.GetRivalEliminations(10) != 6))
        return;
      this.Matchmade = true;
      if (this.CurrentStudent == 11)
        this.PartnerName = this.JSON.Students[22].Name;
      else if (this.CurrentStudent == 12)
        this.PartnerName = this.JSON.Students[27].Name;
      else if (this.CurrentStudent == 13)
        this.PartnerName = this.JSON.Students[28].Name;
      else if (this.CurrentStudent == 14)
        this.PartnerName = this.JSON.Students[32].Name;
      else if (this.CurrentStudent == 15)
        this.PartnerName = this.JSON.Students[42].Name;
      else if (this.CurrentStudent == 16)
        this.PartnerName = this.JSON.Students[47].Name;
      else if (this.CurrentStudent == 17)
        this.PartnerName = this.JSON.Students[57].Name;
      else if (this.CurrentStudent == 18)
        this.PartnerName = this.JSON.Students[62].Name;
      else if (this.CurrentStudent == 19)
        this.PartnerName = this.JSON.Students[67].Name;
      else if (this.CurrentStudent == 20)
        this.PartnerName = this.JSON.Students[72].Name;
      else if (this.CurrentStudent == 22)
        this.PartnerName = this.JSON.Students[11].Name;
      else if (this.CurrentStudent == 27)
        this.PartnerName = this.JSON.Students[12].Name;
      else if (this.CurrentStudent == 32)
        this.PartnerName = this.JSON.Students[13].Name;
      else if (this.CurrentStudent == 37)
        this.PartnerName = this.JSON.Students[14].Name;
      else if (this.CurrentStudent == 42)
        this.PartnerName = this.JSON.Students[15].Name;
      else if (this.CurrentStudent == 47)
        this.PartnerName = this.JSON.Students[16].Name;
      else if (this.CurrentStudent == 57)
        this.PartnerName = this.JSON.Students[17].Name;
      else if (this.CurrentStudent == 62)
        this.PartnerName = this.JSON.Students[18].Name;
      else if (this.CurrentStudent == 67)
      {
        this.PartnerName = this.JSON.Students[19].Name;
      }
      else
      {
        if (this.CurrentStudent != 72)
          return;
        this.PartnerName = this.JSON.Students[20].Name;
      }
    }
    else
    {
      if ((this.CurrentStudent <= 10 || this.CurrentStudent >= 21 || GameGlobals.GetRivalEliminations(this.CurrentStudent - 10) != 6) && (this.CurrentStudent != 6 || GameGlobals.GetRivalEliminations(1) != 6))
        return;
      this.Matchmade = true;
      if (this.CurrentStudent == 11)
      {
        this.PartnerName = this.JSON.Students[6].Name;
      }
      else
      {
        if (this.CurrentStudent != 6)
          return;
        this.PartnerName = this.JSON.Students[11].Name;
      }
    }
  }

  private void CensorUnknownRivalInfo()
  {
    if (this.CurrentStudent <= 10 || this.CurrentStudent >= 21 || DateGlobals.Week >= this.CurrentStudent - 10)
      return;
    this.NameLabel.text = "?????";
    this.PersonaLabel.text = "?????";
    this.CrushLabel.text = "?????";
    this.ClubLabel.text = "?????";
    this.StrengthLabel.text = "?????";
    this.InfoLabel.text = "?????";
    this.ReputationLabel.text = "";
    this.ReputationBar.localPosition = new Vector3(0.0f, -10f, 0.0f);
  }

  static StudentInfoScript()
  {
    IntAndStringDictionary stringDictionary = new IntAndStringDictionary();
    stringDictionary.Add(0, "Incapable");
    stringDictionary.Add(1, "Very Weak");
    stringDictionary.Add(2, "Weak");
    stringDictionary.Add(3, "Strong");
    stringDictionary.Add(4, "Very Strong");
    stringDictionary.Add(5, "Peak Physical Strength");
    stringDictionary.Add(6, "Extensive Training");
    stringDictionary.Add(7, "Carries Pepper Spray");
    stringDictionary.Add(8, "Armed");
    stringDictionary.Add(9, "Invincible");
    stringDictionary.Add(99, "?????");
    StudentInfoScript.StrengthStrings = stringDictionary;
  }
}
