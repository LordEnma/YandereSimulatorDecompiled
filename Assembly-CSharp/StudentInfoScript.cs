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

	public RobotChanScript RobotChan;

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

	private static readonly IntAndStringDictionary StrengthStrings = new IntAndStringDictionary
	{
		{ 0, "Incapable" },
		{ 1, "Very Weak" },
		{ 2, "Weak" },
		{ 3, "Strong" },
		{ 4, "Very Strong" },
		{ 5, "Peak Physical Strength" },
		{ 6, "Extensive Training" },
		{ 7, "Carries Pepper Spray" },
		{ 8, "Armed" },
		{ 9, "Invincible" },
		{ 99, "?????" }
	};

	public UILabel LeftCrushLabel;

	public string PartnerName;

	public bool Matchmade;

	private void Start()
	{
		Topics.SetActive(value: false);
		Eighties = GameGlobals.Eighties;
		if (Eighties)
		{
			InfoLabel.transform.localPosition += new Vector3(0f, -10f, 0f);
			ReputationChart.BecomeEighties();
		}
		if (!UpdatedOnce)
		{
			UpdateInfo(StudentInfoMenu.StudentID);
		}
	}

	public void UpdateInfo(int ID)
	{
		CurrentStudent = ID;
		if (!UpdatedOnce)
		{
			Eighties = GameGlobals.Eighties;
		}
		UpdatedOnce = true;
		StudentJson studentJson = JSON.Students[ID];
		if (studentJson.RealName == "" || GameGlobals.CustomMode)
		{
			NameLabel.transform.localPosition = new Vector3(-228f, 195f, 0f);
			RealNameLabel.text = "";
		}
		else
		{
			NameLabel.transform.localPosition = new Vector3(-228f, 210f, 0f);
			RealNameLabel.text = "Real Name: " + studentJson.RealName;
		}
		NameLabel.text = studentJson.Name;
		string text = studentJson.Class.ToString() ?? "";
		text = text.Insert(1, "-");
		ClassLabel.text = "Class " + text;
		if (ID == 90 || ID > 96)
		{
			ClassLabel.text = "";
		}
		float num = 0f;
		num = StudentManager.StudentReps[ID];
		if (num < 0f)
		{
			ReputationLabel.text = num.ToString() ?? "";
		}
		else if (num > 0f)
		{
			ReputationLabel.text = "+" + num;
		}
		else
		{
			ReputationLabel.text = "0";
		}
		ReputationBar.localPosition = new Vector3(num * 0.96f, ReputationBar.localPosition.y, ReputationBar.localPosition.z);
		if (ReputationBar.localPosition.x > 96f)
		{
			ReputationBar.localPosition = new Vector3(96f, ReputationBar.localPosition.y, ReputationBar.localPosition.z);
		}
		if (ReputationBar.localPosition.x < -96f)
		{
			ReputationBar.localPosition = new Vector3(-96f, ReputationBar.localPosition.y, ReputationBar.localPosition.z);
		}
		if (StudentManager.Students[CurrentStudent] != null)
		{
			PersonaLabel.text = Persona.PersonaNames[StudentManager.Students[CurrentStudent].Persona];
		}
		else
		{
			PersonaLabel.text = Persona.PersonaNames[studentJson.Persona];
		}
		if (studentJson.Persona == PersonaType.Strict && studentJson.Club == ClubType.GymTeacher && !StudentGlobals.GetStudentReplaced(ID))
		{
			PersonaLabel.text = "Friendly but Strict";
		}
		MatchmadeCheck();
		int num2 = 0;
		num2 = StudentManager.SuitorID;
		if (Matchmade)
		{
			Debug.Log("This character has been matchmade.");
			LeftCrushLabel.text = "Relationship";
			CrushLabel.text = JSON.Students[studentJson.Crush].Name;
			CrushLabel.text = PartnerName;
		}
		else
		{
			LeftCrushLabel.text = "Crush";
			if (CurrentStudent > 10 && CurrentStudent < 21)
			{
				StudentManager.RivalID = DateGlobals.Week + 10;
				if (CurrentStudent == StudentManager.RivalID && GameGlobals.RivalEliminationID == 0)
				{
					Debug.Log("This character is the current rival.");
					CrushLabel.text = JSON.Students[studentJson.Crush].Name;
				}
				else
				{
					Debug.Log("This character was the rival.");
					CrushLabel.text = "None Anymore";
					if (Eighties && !StudentGlobals.GetStudentDead(CurrentStudent))
					{
						PersonaLabel.text = EliminatedEightiesRivalPersona(CurrentStudent);
					}
				}
			}
			else if (CurrentStudent == num2)
			{
				if (StudentManager.LoveManager != null && StudentManager.LoveManager.SuitorProgress == 0)
				{
					CrushLabel.text = "Unknown";
				}
				else
				{
					CrushLabel.text = JSON.Students[studentJson.Crush].Name;
				}
			}
			else if (studentJson.Crush == 0)
			{
				CrushLabel.text = "None";
			}
			else if (studentJson.Crush == 99)
			{
				CrushLabel.text = "None";
			}
			else
			{
				Debug.Log("The JSON has an entry for this character's crush...");
				CrushLabel.text = JSON.Students[studentJson.Crush].Name;
				bool flag = false;
				if (StudentManager.Week == 0)
				{
					Debug.Log("Week was 0. Are we in the HomeScene?");
					StudentManager.Week = DateGlobals.Week;
				}
				for (int i = StudentManager.Week + 1; i < 11; i++)
				{
					if (CurrentStudent == StudentManager.SuitorIDs[i])
					{
						Debug.Log("This guy's ID is in the suitor list.");
						flag = true;
					}
				}
				if (flag)
				{
					for (int i = 2; i < 11; i++)
					{
						if (CurrentStudent == StudentManager.SuitorIDs[i] && StudentManager.Week < i)
						{
							Debug.Log("This guy will be a suitor one day in the future.");
							CrushLabel.text = "Unknown";
						}
					}
				}
				if (CurrentStudent == StudentManager.SuitorIDs[StudentManager.Week])
				{
					Debug.Log("This guy is the CURRENT rival's suitor!");
					int num3 = 0;
					if (((!(StudentManager.LoveManager != null)) ? DatingGlobals.SuitorProgress : StudentManager.LoveManager.SuitorProgress) == 0)
					{
						Debug.Log("We don't know who he has a crush on yet.");
						CrushLabel.text = "Unknown";
					}
					else
					{
						Debug.Log("We know who he has a crush on.");
					}
				}
			}
		}
		if (studentJson.Club < ClubType.Teacher)
		{
			OccupationLabel.text = "Club";
		}
		else
		{
			OccupationLabel.text = "Occupation";
		}
		if (studentJson.Club < ClubType.Teacher)
		{
			ClubLabel.text = Club.ClubNames[studentJson.Club];
		}
		else
		{
			ClubLabel.text = Club.TeacherClubNames[studentJson.Class];
		}
		if (ClubGlobals.GetClubClosed(studentJson.Club))
		{
			ClubLabel.text = "No Club";
		}
		StrengthLabel.text = StrengthStrings[studentJson.Strength];
		AudioSource component = GetComponent<AudioSource>();
		component.enabled = false;
		Static.SetActive(value: false);
		component.volume = 0f;
		component.Stop();
		string text2 = "";
		if (Eighties)
		{
			text2 = "1989";
			if (GameGlobals.CustomMode)
			{
				text2 = "Custom";
			}
		}
		if (ID < 98)
		{
			int num4 = 11 + DateGlobals.Week;
			if (StudentManager.MissionMode)
			{
				num4 = 13;
			}
			if (Eighties || (!Eighties && ID < num4) || (!Eighties && ID > 20))
			{
				WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + text2 + "/Student_" + ID + ".png");
				if (!StudentGlobals.GetStudentReplaced(ID))
				{
					Portrait.mainTexture = wWW.texture;
				}
				else
				{
					Portrait.mainTexture = StudentInfoMenu.BlankPortrait;
				}
				if (Eighties && CurrentStudent > 10 && CurrentStudent < 21 && DateGlobals.Week < CurrentStudent - 10)
				{
					Portrait.mainTexture = StudentInfoMenu.EightiesUnknown;
				}
				if (!Eighties && ID == 1)
				{
					Debug.Log("Attempting to load custom Senpai portrait.");
					WWW wWW2 = new WWW("file:///" + Application.streamingAssetsPath + "/SenpaiPortrait.png");
					if (wWW2.error == null)
					{
						Debug.Log("No error!");
						Portrait.mainTexture = wWW2.texture;
					}
					else
					{
						Debug.Log("Uh, there was an error: " + wWW2.error);
					}
				}
			}
			else
			{
				Portrait.mainTexture = StudentInfoMenu.RivalPortraits[ID];
			}
		}
		else
		{
			switch (ID)
			{
			case 98:
				Portrait.mainTexture = StudentInfoMenu.Counselor;
				break;
			case 99:
				Portrait.mainTexture = StudentInfoMenu.Headmaster;
				break;
			case 100:
				Portrait.mainTexture = StudentInfoMenu.InfoChan;
				if (!Eighties)
				{
					Static.SetActive(value: true);
					if (!StudentInfoMenu.Gossiping && !StudentInfoMenu.Distracting && !StudentInfoMenu.CyberBullying && !StudentInfoMenu.CyberStalking)
					{
						component.enabled = true;
						component.volume = 1f;
						component.Play();
					}
				}
				break;
			}
		}
		UpdateAdditionalInfo(ID);
		UpdateRepChart();
		CensorUnknownRivalInfo();
		UpdateTagButton();
	}

	private void Update()
	{
		if (CurrentStudent == 100)
		{
			UpdateRepChart();
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			if (StudentInfoMenu.Gossiping)
			{
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				DialogueWheel.Victim = CurrentStudent;
				StudentInfoMenu.Gossiping = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 0.0001f;
				DialogueWheel.TopicInterface.Socializing = false;
				DialogueWheel.TopicInterface.StudentID = Yandere.TargetStudent.StudentID;
				DialogueWheel.TopicInterface.Student = Yandere.TargetStudent;
				DialogueWheel.TopicInterface.TargetStudentID = CurrentStudent;
				DialogueWheel.TopicInterface.TargetStudent = StudentManager.Students[CurrentStudent];
				DialogueWheel.TopicInterface.UpdateOpinions();
				DialogueWheel.TopicInterface.UpdateTopicHighlight();
				DialogueWheel.TopicInterface.gameObject.SetActive(value: true);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Speak";
				PromptBar.Label[1].text = "Back";
				PromptBar.Label[2].text = "Positive/Negative";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			else if (StudentInfoMenu.Distracting)
			{
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				DialogueWheel.Victim = CurrentStudent;
				StudentInfoMenu.Distracting = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 1f;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.CyberBullying)
			{
				HomeInternet.PostLabels[1].text = JSON.Students[CurrentStudent].Name;
				HomeInternet.Student = CurrentStudent;
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				StudentInfoMenu.CyberBullying = false;
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.CyberStalking)
			{
				HomeInternet.HomeCamera.CyberstalkWindow.SetActive(value: true);
				HomeInternet.Student = CurrentStudent;
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				StudentInfoMenu.CyberStalking = false;
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.MatchMaking)
			{
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				DialogueWheel.Victim = CurrentStudent;
				StudentInfoMenu.MatchMaking = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 1f;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.Targeting)
			{
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				Yandere.TargetStudent.HuntTarget = StudentManager.Students[CurrentStudent];
				Yandere.TargetStudent.HuntTarget.Hunted = true;
				Yandere.TargetStudent.GoCommitMurder();
				Yandere.RPGCamera.enabled = true;
				Yandere.TargetStudent = null;
				StudentInfoMenu.Targeting = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 1f;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.SendingHome)
			{
				if (CurrentStudent == 10 || CurrentStudent == StudentManager.RivalID)
				{
					StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(11);
					base.gameObject.SetActive(value: false);
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = string.Empty;
					PromptBar.Label[1].text = "Back";
					PromptBar.UpdateButtons();
				}
				else
				{
					if (StudentManager.Students[CurrentStudent].Routine && !StudentManager.Students[CurrentStudent].InEvent && !StudentManager.Students[CurrentStudent].TargetedForDistraction && StudentManager.Students[CurrentStudent].ClubActivityPhase < 16 && !StudentManager.Students[CurrentStudent].MyBento.Tampered && !PlayerGlobals.GetStudentSentHome(CurrentStudent))
					{
						StudentManager.Students[CurrentStudent].Routine = false;
						StudentManager.Students[CurrentStudent].SentHome = true;
						StudentManager.Students[CurrentStudent].CameraReacting = false;
						StudentManager.Students[CurrentStudent].SpeechLines.Stop();
						StudentManager.Students[CurrentStudent].EmptyHands();
						Yandere.PauseScreen.ServiceMenu.ServicePurchased[Yandere.PauseScreen.ServiceMenu.Selected] = true;
						StudentInfoMenu.PauseScreen.ServiceMenu.gameObject.SetActive(value: true);
						StudentInfoMenu.PauseScreen.ServiceMenu.UpdateList();
						StudentInfoMenu.PauseScreen.ServiceMenu.UpdateDesc();
						StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
						StudentInfoMenu.SendingHome = false;
						Yandere.PauseScreen.ServiceMenu.StudentSentHome = CurrentStudent;
					}
					else if (PlayerGlobals.GetStudentSentHome(CurrentStudent))
					{
						StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(12);
					}
					else
					{
						StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(0);
					}
					base.gameObject.SetActive(value: false);
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = string.Empty;
					PromptBar.Label[1].text = "Back";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
				}
			}
			else if (StudentInfoMenu.FindingLocker)
			{
				NoteLocker.gameObject.SetActive(value: true);
				NoteLocker.transform.position = StudentManager.Students[StudentInfoMenu.StudentID].MyLocker.position;
				NoteLocker.transform.position += new Vector3(0f, 1.355f, 0f);
				NoteLocker.transform.position += StudentManager.Students[StudentInfoMenu.StudentID].MyLocker.forward * 0.33333f;
				NoteLocker.Prompt.Label[0].text = "     Leave note for " + StudentManager.Students[StudentInfoMenu.StudentID].Name;
				NoteLocker.Student = StudentManager.Students[StudentInfoMenu.StudentID];
				NoteLocker.LockerOwner = StudentInfoMenu.StudentID;
				NoteLocker.StudentID = StudentInfoMenu.StudentID;
				NoteLocker.Prompt.enabled = true;
				NoteLocker.transform.GetChild(0).gameObject.SetActive(value: true);
				NoteLocker.CheckingNote = false;
				NoteLocker.CanLeaveNote = true;
				NoteLocker.SpawnedNote = false;
				NoteLocker.NoteLeft = false;
				NoteLocker.Success = false;
				NoteLocker.Timer = 0f;
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				StudentInfoMenu.FindingLocker = false;
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Yandere.RPGCamera.enabled = true;
				Time.timeScale = 1f;
				if (StudentInfoMenu.StudentID == 11 && SchemeGlobals.GetSchemeStage(6) == 4)
				{
					SchemeGlobals.SetSchemeStage(6, 5);
					Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
			}
			else if (StudentInfoMenu.FiringCouncilMember)
			{
				if (StudentManager.Students[CurrentStudent].Routine && !StudentManager.Students[CurrentStudent].InEvent && !StudentManager.Students[CurrentStudent].Distracted && StudentManager.Students[CurrentStudent].ClubActivityPhase < 16 && !StudentManager.Students[CurrentStudent].MyBento.Tampered)
				{
					StudentManager.Students[CurrentStudent].OriginalPersona = PersonaType.Heroic;
					StudentManager.Students[CurrentStudent].Persona = PersonaType.Heroic;
					StudentManager.Students[CurrentStudent].Club = ClubType.None;
					StudentManager.Students[CurrentStudent].CameraReacting = false;
					StudentManager.Students[CurrentStudent].SpeechLines.Stop();
					StudentManager.Students[CurrentStudent].EmptyHands();
					StudentManager.Students[CurrentStudent].Strength = 5;
					StudentManager.Students[CurrentStudent].IdleAnim = StudentManager.Students[CurrentStudent].BulliedIdleAnim;
					StudentManager.Students[CurrentStudent].WalkAnim = StudentManager.Students[CurrentStudent].BulliedWalkAnim;
					StudentManager.Students[CurrentStudent].Armband.SetActive(value: false);
					StudentScript studentScript = StudentManager.Students[CurrentStudent];
					ScheduleBlock obj = studentScript.ScheduleBlocks[3];
					obj.destination = "LunchSpot";
					obj.action = "Eat";
					studentScript.GetDestinations();
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
					StudentInfoMenu.PauseScreen.ServiceMenu.gameObject.SetActive(value: true);
					StudentInfoMenu.PauseScreen.ServiceMenu.UpdateList();
					StudentInfoMenu.PauseScreen.ServiceMenu.UpdateDesc();
					StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
					StudentInfoMenu.FiringCouncilMember = false;
					StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(9);
				}
				else
				{
					StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(0);
				}
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = string.Empty;
				PromptBar.Label[1].text = "Back";
				PromptBar.UpdateButtons();
			}
			else if (StudentInfoMenu.RobotTargeting)
			{
				RobotChan.TargetStudent = StudentManager.Students[CurrentStudent];
				RobotChan.TargetStudent.Hunted = true;
				RobotChan.GoCommitMurder();
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				StudentInfoMenu.RobotTargeting = false;
				base.gameObject.SetActive(value: false);
				Yandere.RPGCamera.enabled = true;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Time.timeScale = 1f;
			}
			else if (StudentInfoMenu.GettingOpinions)
			{
				Debug.Log("Are we ''GettingOpinions'' now?");
				for (int i = 1; i < 26; i++)
				{
					ConversationGlobals.SetTopicDiscovered(i, value: true);
					StudentManager.SetTopicLearnedByStudent(i, CurrentStudent, boolean: true);
				}
				StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
				base.gameObject.SetActive(value: false);
				StudentInfoMenu.GettingOpinions = false;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = string.Empty;
				PromptBar.Label[1].text = "Back";
				PromptBar.UpdateButtons();
			}
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			ShowRep = false;
			Topics.SetActive(value: false);
			GetComponent<AudioSource>().Stop();
			ReputationChart.transform.localScale = new Vector3(0f, 0f, 0f);
			if (Shutter != null)
			{
				if (!Shutter.PhotoIcons.activeInHierarchy)
				{
					Back = true;
				}
			}
			else
			{
				Back = true;
			}
			if (Back)
			{
				StudentInfoMenu.gameObject.SetActive(value: true);
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "View Info";
				if (!StudentInfoMenu.Gossiping)
				{
					PromptBar.Label[1].text = "Back";
				}
				PromptBar.UpdateButtons();
				Back = false;
			}
		}
		if (Input.GetButtonDown(InputNames.Xbox_X) && PromptBar.Button[2].enabled)
		{
			if (StudentManager.Tag.Target != StudentManager.Students[CurrentStudent].Head)
			{
				StudentManager.Tag.Target = StudentManager.Students[CurrentStudent].Head;
				StudentManager.TagStudentID = CurrentStudent;
				PromptBar.Label[2].text = "Untag";
			}
			else
			{
				StudentManager.TagStudentID = 0;
				StudentManager.Tag.Target = null;
				PromptBar.Label[2].text = "Tag";
			}
			PromptBar.UpdateButtons();
		}
		if (Input.GetButtonDown(InputNames.Xbox_Y) && PromptBar.Button[3].enabled)
		{
			if (!Topics.activeInHierarchy)
			{
				PromptBar.Label[3].text = "Basic Info";
				PromptBar.UpdateButtons();
				Topics.SetActive(value: true);
				UpdateTopics();
			}
			else
			{
				PromptBar.Label[3].text = "Interests";
				PromptBar.UpdateButtons();
				Topics.SetActive(value: false);
			}
		}
		if (Input.GetButtonDown(InputNames.Xbox_LB))
		{
			UpdateRepChart();
			ShowRep = !ShowRep;
		}
		if (Yandere != null && !Yandere.NoDebug)
		{
			if (Input.GetKeyDown(KeyCode.Equals))
			{
				StudentManager.StudentReps[CurrentStudent] += 10f;
				UpdateInfo(CurrentStudent);
			}
			if (Input.GetKeyDown(KeyCode.Minus))
			{
				StudentManager.StudentReps[CurrentStudent] -= 10f;
				UpdateInfo(CurrentStudent);
			}
		}
		StudentInfoMenuScript studentInfoMenu = StudentInfoMenu;
		if (!studentInfoMenu.CyberBullying && !studentInfoMenu.CyberStalking && !studentInfoMenu.FindingLocker && !studentInfoMenu.UsingLifeNote && !studentInfoMenu.GettingInfo && !studentInfoMenu.MatchMaking && !studentInfoMenu.Distracting && !studentInfoMenu.SendingHome && !studentInfoMenu.Gossiping && !studentInfoMenu.Targeting && !studentInfoMenu.GettingOpinions && !studentInfoMenu.Dead && !studentInfoMenu.RobotTargeting)
		{
			if (StudentInfoMenu.PauseScreen.InputManager.TappedRight)
			{
				CurrentStudent++;
				if (CurrentStudent > 100)
				{
					CurrentStudent = 1;
				}
				while (!StudentManager.StudentPhotographed[CurrentStudent])
				{
					CurrentStudent++;
					if (CurrentStudent > 100)
					{
						CurrentStudent = 1;
					}
				}
				UpdateInfo(CurrentStudent);
				UpdateTopics();
			}
			if (StudentInfoMenu.PauseScreen.InputManager.TappedLeft)
			{
				CurrentStudent--;
				if (CurrentStudent < 1)
				{
					CurrentStudent = 100;
				}
				while (!StudentManager.StudentPhotographed[CurrentStudent])
				{
					CurrentStudent--;
					if (CurrentStudent < 1)
					{
						CurrentStudent = 100;
					}
				}
				UpdateInfo(CurrentStudent);
				UpdateTopics();
			}
		}
		if (ShowRep)
		{
			ReputationChart.transform.localScale = Vector3.Lerp(ReputationChart.transform.localScale, new Vector3(138f, 138f, 138f), Time.unscaledDeltaTime * 10f);
		}
		else
		{
			ReputationChart.transform.localScale = Vector3.Lerp(ReputationChart.transform.localScale, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
		}
	}

	private void UpdateAdditionalInfo(int ID)
	{
		if (!Eighties)
		{
			switch (ID)
			{
			case 1:
				if (StudentManager.MissionMode)
				{
					Strings[1] = "The first target you ever assassinated.";
					Strings[2] = "Good thing you were wearing gloves at the time...";
					Strings[3] = "Why? Oh, you know...fingerprints and whatnot...";
					InfoLabel.text = Strings[1] + "\n\n" + Strings[2] + "\n\n" + Strings[3];
				}
				else
				{
					InfoLabel.text = JSON.Students[ID].Info;
				}
				return;
			case 11:
				if (Yandere != null)
				{
					Strings[1] = (Yandere.Police.EndOfDay.LearnedOsanaInfo1 ? "May be a victim of blackmail." : "?????");
					Strings[2] = (Yandere.Police.EndOfDay.LearnedOsanaInfo2 ? "Has a stalker." : "?????");
				}
				else
				{
					Strings[1] = "?????";
					Strings[2] = "?????";
				}
				InfoLabel.text = "Senpai's childhood friend.\n\n" + Strings[1] + "\n\n" + Strings[2];
				return;
			case 12:
				if (Yandere == null)
				{
					Strings[1] = (EventGlobals.LearnedRivalDarkSecret ? "Suspicious of a ''new bakery'' in town." : "You may be able to learn additional information by stalking her or buying it from Info-chan.");
				}
				else
				{
					Strings[1] = (Yandere.Police.EndOfDay.LearnedRivalDarkSecret ? "Suspicious of a ''new bakery'' in town." : "You may be able to learn additional information by stalking her or buying it from Info-chan.");
				}
				InfoLabel.text = "The president of the Cooking Club.\n\n[c][800000]" + Strings[1] + "[-][/c]";
				return;
			case 51:
				if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
				{
					InfoLabel.text = "Disbanded the Light Music Club, dyed her hair back to its original color, removed her piercings, and stopped socializing with others.";
				}
				else
				{
					InfoLabel.text = JSON.Students[ID].Info;
				}
				return;
			}
			if (!StudentGlobals.GetStudentReplaced(ID))
			{
				if (JSON.Students[ID].Info == string.Empty)
				{
					InfoLabel.text = "No additional information is available at this time.";
				}
				else
				{
					InfoLabel.text = JSON.Students[ID].Info;
				}
			}
			else
			{
				InfoLabel.text = "No additional information is available at this time.";
			}
		}
		else if (!StudentGlobals.GetStudentReplaced(ID))
		{
			if (JSON.Students[ID].Info == string.Empty)
			{
				InfoLabel.text = "No additional information is available at this time.";
			}
			else
			{
				InfoLabel.text = JSON.Students[ID].Info;
			}
		}
		else
		{
			InfoLabel.text = "No additional information is available at this time.";
		}
	}

	private void UpdateTopics()
	{
		Debug.Log("UpdateTopics() has just been called.");
		if (!StudentManager.TopicsLoaded)
		{
			StudentManager.LoadTopicsLearned();
		}
		int num = 0;
		int num2 = 0;
		for (int i = 1; i < TopicIcons.Length; i++)
		{
			TopicIcons[i].spriteName = (ConversationGlobals.GetTopicDiscovered(i) ? i : 0).ToString();
		}
		for (int j = 1; j <= 25; j++)
		{
			UISprite uISprite = TopicOpinionIcons[j];
			if (!StudentManager.GetTopicLearnedByStudent(j, CurrentStudent))
			{
				uISprite.spriteName = "Unknown";
				continue;
			}
			int[] topics = JSON.Topics[CurrentStudent].Topics;
			uISprite.spriteName = OpinionSpriteNames[topics[j]];
			if (topics[j] == 1)
			{
				num2++;
			}
			if (topics[j] == 2)
			{
				num++;
			}
		}
	}

	private void UpdateRepChart()
	{
		Vector3 zero = Vector3.zero;
		zero = ((CurrentStudent < 100) ? StudentGlobals.GetReputationTriangle(CurrentStudent) : (Eighties ? new Vector3(0f, 50f, 100f) : new Vector3(Random.Range(-100, 101), Random.Range(-100, 101), Random.Range(-100, 101))));
		ReputationChart.fields[0].Value = zero.x;
		ReputationChart.fields[1].Value = zero.y;
		ReputationChart.fields[2].Value = zero.z;
	}

	private void MatchmadeCheck()
	{
		Debug.Log("Performing Matchmaking Check.");
		Matchmade = false;
		if (Eighties)
		{
			if ((CurrentStudent > 10 && CurrentStudent < 21 && GameGlobals.GetRivalEliminations(CurrentStudent - 10) == 6) || (CurrentStudent == 22 && GameGlobals.GetRivalEliminations(1) == 6) || (CurrentStudent == 27 && GameGlobals.GetRivalEliminations(2) == 6) || (CurrentStudent == 32 && GameGlobals.GetRivalEliminations(3) == 6) || (CurrentStudent == 37 && GameGlobals.GetRivalEliminations(4) == 6) || (CurrentStudent == 42 && GameGlobals.GetRivalEliminations(5) == 6) || (CurrentStudent == 47 && GameGlobals.GetRivalEliminations(6) == 6) || (CurrentStudent == 57 && GameGlobals.GetRivalEliminations(7) == 6) || (CurrentStudent == 62 && GameGlobals.GetRivalEliminations(8) == 6) || (CurrentStudent == 67 && GameGlobals.GetRivalEliminations(9) == 6) || (CurrentStudent == 72 && GameGlobals.GetRivalEliminations(10) == 6))
			{
				Matchmade = true;
				if (CurrentStudent == 11)
				{
					PartnerName = JSON.Students[22].Name;
				}
				else if (CurrentStudent == 12)
				{
					PartnerName = JSON.Students[27].Name;
				}
				else if (CurrentStudent == 13)
				{
					PartnerName = JSON.Students[32].Name;
				}
				else if (CurrentStudent == 14)
				{
					PartnerName = JSON.Students[37].Name;
				}
				else if (CurrentStudent == 15)
				{
					PartnerName = JSON.Students[42].Name;
				}
				else if (CurrentStudent == 16)
				{
					PartnerName = JSON.Students[47].Name;
				}
				else if (CurrentStudent == 17)
				{
					PartnerName = JSON.Students[57].Name;
				}
				else if (CurrentStudent == 18)
				{
					PartnerName = JSON.Students[62].Name;
				}
				else if (CurrentStudent == 19)
				{
					PartnerName = JSON.Students[67].Name;
				}
				else if (CurrentStudent == 20)
				{
					PartnerName = JSON.Students[72].Name;
				}
				else if (CurrentStudent == 22)
				{
					PartnerName = JSON.Students[11].Name;
				}
				else if (CurrentStudent == 27)
				{
					PartnerName = JSON.Students[12].Name;
				}
				else if (CurrentStudent == 32)
				{
					PartnerName = JSON.Students[13].Name;
				}
				else if (CurrentStudent == 37)
				{
					PartnerName = JSON.Students[14].Name;
				}
				else if (CurrentStudent == 42)
				{
					PartnerName = JSON.Students[15].Name;
				}
				else if (CurrentStudent == 47)
				{
					PartnerName = JSON.Students[16].Name;
				}
				else if (CurrentStudent == 57)
				{
					PartnerName = JSON.Students[17].Name;
				}
				else if (CurrentStudent == 62)
				{
					PartnerName = JSON.Students[18].Name;
				}
				else if (CurrentStudent == 67)
				{
					PartnerName = JSON.Students[19].Name;
				}
				else if (CurrentStudent == 72)
				{
					PartnerName = JSON.Students[20].Name;
				}
				if (CurrentStudent == 14)
				{
					Debug.Log("This is student #14! PartnerName should be JSON.Students[32].Name which is: " + JSON.Students[32].Name);
				}
			}
			return;
		}
		Debug.Log("Osana's elimination: " + GameGlobals.GetRivalEliminations(1));
		Debug.Log("Matchmade elimination number is: " + 6);
		if ((CurrentStudent > 10 && CurrentStudent < 21 && GameGlobals.GetRivalEliminations(CurrentStudent - 10) == 6) || (CurrentStudent == 6 && GameGlobals.GetRivalEliminations(1) == 6))
		{
			Matchmade = true;
			if (CurrentStudent == 11)
			{
				PartnerName = JSON.Students[6].Name;
			}
			else if (CurrentStudent == 6)
			{
				PartnerName = JSON.Students[11].Name;
			}
		}
	}

	private void CensorUnknownRivalInfo()
	{
		if (!StudentManager.MissionMode && CurrentStudent > 10 && CurrentStudent < 21 && DateGlobals.Week < CurrentStudent - 10)
		{
			NameLabel.text = "?????";
			PersonaLabel.text = "?????";
			CrushLabel.text = "?????";
			ClubLabel.text = "?????";
			StrengthLabel.text = "?????";
			InfoLabel.text = "?????";
			ReputationLabel.text = "";
			ReputationBar.localPosition = new Vector3(0f, -10f, 0f);
		}
	}

	public void UpdateTagButton()
	{
		if (StudentManager.TagStudentID == CurrentStudent)
		{
			PromptBar.Label[2].text = "Untag";
		}
		else
		{
			PromptBar.Label[2].text = "Tag";
		}
		PromptBar.UpdateButtons();
	}

	private string EliminatedEightiesRivalPersona(int StudentID)
	{
		string result = "";
		switch (StudentID)
		{
		case 11:
			result = "Snitch";
			break;
		case 12:
			result = "Snitch";
			break;
		case 13:
			result = "Coward";
			break;
		case 14:
			result = "Heroic";
			break;
		case 15:
			result = "Loner";
			break;
		case 16:
			result = "Snitch";
			break;
		case 17:
			result = "Teacher's Pet";
			break;
		case 18:
			result = "Teacher's Pet";
			break;
		case 19:
			result = "Snitch";
			break;
		case 20:
			result = "Heroic";
			break;
		}
		return result;
	}
}
