using System;
using UnityEngine;

// Token: 0x0200045B RID: 1115
public class StudentInfoScript : MonoBehaviour
{
	// Token: 0x06001D7C RID: 7548 RVA: 0x0016421C File Offset: 0x0016241C
	private void Start()
	{
		StudentGlobals.SetStudentPhotographed(98, true);
		StudentGlobals.SetStudentPhotographed(99, true);
		StudentGlobals.SetStudentPhotographed(100, true);
		this.Topics.SetActive(false);
		this.Eighties = GameGlobals.Eighties;
		if (this.Eighties)
		{
			this.InfoLabel.transform.localPosition += new Vector3(0f, -10f, 0f);
		}
		if (!this.UpdatedOnce)
		{
			this.UpdateInfo(this.StudentInfoMenu.StudentID);
		}
	}

	// Token: 0x06001D7D RID: 7549 RVA: 0x001642A8 File Offset: 0x001624A8
	public void UpdateInfo(int ID)
	{
		this.CurrentStudent = ID;
		if (!this.UpdatedOnce)
		{
			this.Eighties = GameGlobals.Eighties;
		}
		this.UpdatedOnce = true;
		StudentJson studentJson = this.JSON.Students[ID];
		if (studentJson.RealName == "")
		{
			this.NameLabel.transform.localPosition = new Vector3(-228f, 195f, 0f);
			this.RealNameLabel.text = "";
		}
		else
		{
			this.NameLabel.transform.localPosition = new Vector3(-228f, 210f, 0f);
			this.RealNameLabel.text = "Real Name: " + studentJson.RealName;
		}
		this.NameLabel.text = studentJson.Name;
		string text = studentJson.Class.ToString() ?? "";
		text = text.Insert(1, "-");
		this.ClassLabel.text = "Class " + text;
		if (ID == 90 || ID > 96)
		{
			this.ClassLabel.text = "";
		}
		float num;
		if (this.StudentManager != null)
		{
			num = this.StudentManager.StudentReps[ID];
		}
		else
		{
			num = (float)StudentGlobals.GetStudentReputation(ID);
		}
		if (num < 0f)
		{
			this.ReputationLabel.text = (num.ToString() ?? "");
		}
		else if (num > 0f)
		{
			this.ReputationLabel.text = "+" + num.ToString();
		}
		else
		{
			this.ReputationLabel.text = "0";
		}
		this.ReputationBar.localPosition = new Vector3(num * 0.96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
		if (this.ReputationBar.localPosition.x > 96f)
		{
			this.ReputationBar.localPosition = new Vector3(96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
		}
		if (this.ReputationBar.localPosition.x < -96f)
		{
			this.ReputationBar.localPosition = new Vector3(-96f, this.ReputationBar.localPosition.y, this.ReputationBar.localPosition.z);
		}
		if (this.StudentManager.Students[this.CurrentStudent] != null)
		{
			this.PersonaLabel.text = Persona.PersonaNames[this.StudentManager.Students[this.CurrentStudent].Persona];
		}
		else
		{
			this.PersonaLabel.text = "?????";
		}
		if (studentJson.Persona == PersonaType.Strict && studentJson.Club == ClubType.GymTeacher && !StudentGlobals.GetStudentReplaced(ID))
		{
			this.PersonaLabel.text = "Friendly but Strict";
		}
		this.MatchmadeCheck();
		if (this.Matchmade)
		{
			this.LeftCrushLabel.text = "Relationship";
			this.CrushLabel.text = this.JSON.Students[studentJson.Crush].Name;
			this.CrushLabel.text = this.PartnerName;
		}
		else
		{
			this.LeftCrushLabel.text = "Crush";
			if (studentJson.Crush == 0)
			{
				this.CrushLabel.text = "Unknown";
			}
			else if (studentJson.Crush == 99)
			{
				this.CrushLabel.text = "?????";
			}
			else if (this.CurrentStudent == this.StudentManager.RivalID || (this.CurrentStudent == this.StudentManager.SuitorID && this.StudentManager.LoveManager.SuitorProgress > 0))
			{
				this.CrushLabel.text = this.JSON.Students[studentJson.Crush].Name;
			}
			else if (this.CurrentStudent > 10 && this.CurrentStudent < 21)
			{
				this.CrushLabel.text = "None Anymore";
			}
			else
			{
				this.CrushLabel.text = "Unknown";
			}
		}
		if (studentJson.Club < ClubType.Teacher)
		{
			this.OccupationLabel.text = "Club";
		}
		else
		{
			this.OccupationLabel.text = "Occupation";
		}
		if (studentJson.Club < ClubType.Teacher)
		{
			this.ClubLabel.text = Club.ClubNames[studentJson.Club];
		}
		else
		{
			this.ClubLabel.text = Club.TeacherClubNames[studentJson.Class];
		}
		if (ClubGlobals.GetClubClosed(studentJson.Club))
		{
			this.ClubLabel.text = "No Club";
		}
		this.StrengthLabel.text = StudentInfoScript.StrengthStrings[studentJson.Strength];
		AudioSource component = base.GetComponent<AudioSource>();
		component.enabled = false;
		this.Static.SetActive(false);
		component.volume = 0f;
		component.Stop();
		string text2 = "";
		if (this.Eighties)
		{
			text2 = "1989";
		}
		if (ID < 98)
		{
			if (this.Eighties || (!this.Eighties && ID < 12) || (!this.Eighties && ID > 20))
			{
				WWW www = new WWW(string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Portraits",
					text2,
					"/Student_",
					ID.ToString(),
					".png"
				}));
				if (!StudentGlobals.GetStudentReplaced(ID))
				{
					this.Portrait.mainTexture = www.texture;
				}
				else
				{
					this.Portrait.mainTexture = this.BlankPortrait;
				}
				if (this.Eighties && this.CurrentStudent > 10 && this.CurrentStudent < 21 && DateGlobals.Week < this.CurrentStudent - 10)
				{
					this.Portrait.mainTexture = this.StudentInfoMenu.EightiesUnknown;
				}
			}
			else
			{
				this.Portrait.mainTexture = this.StudentInfoMenu.RivalPortraits[ID];
			}
		}
		else if (ID == 98)
		{
			this.Portrait.mainTexture = this.StudentInfoMenu.Counselor;
		}
		else if (ID == 99)
		{
			this.Portrait.mainTexture = this.StudentInfoMenu.Headmaster;
		}
		else if (ID == 100)
		{
			this.Portrait.mainTexture = this.StudentInfoMenu.InfoChan;
			if (!this.Eighties)
			{
				this.Static.SetActive(true);
				if (!this.StudentInfoMenu.Gossiping && !this.StudentInfoMenu.Distracting && !this.StudentInfoMenu.CyberBullying && !this.StudentInfoMenu.CyberStalking)
				{
					component.enabled = true;
					component.volume = 1f;
					component.Play();
				}
			}
		}
		this.UpdateAdditionalInfo(ID);
		this.UpdateRepChart();
		this.CensorUnknownRivalInfo();
	}

	// Token: 0x06001D7E RID: 7550 RVA: 0x001649AC File Offset: 0x00162BAC
	private void Update()
	{
		if (this.CurrentStudent == 100)
		{
			this.UpdateRepChart();
		}
		if (Input.GetButtonDown("A"))
		{
			if (this.StudentInfoMenu.Gossiping)
			{
				this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.DialogueWheel.Victim = this.CurrentStudent;
				this.StudentInfoMenu.Gossiping = false;
				base.gameObject.SetActive(false);
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
				base.gameObject.SetActive(false);
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
				base.gameObject.SetActive(false);
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
				base.gameObject.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.StudentInfoMenu.MatchMaking)
			{
				this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.DialogueWheel.Victim = this.CurrentStudent;
				this.StudentInfoMenu.MatchMaking = false;
				base.gameObject.SetActive(false);
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
				this.Yandere.TargetStudent = null;
				this.StudentInfoMenu.Targeting = false;
				base.gameObject.SetActive(false);
				Time.timeScale = 1f;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
			else if (this.StudentInfoMenu.SendingHome)
			{
				if (this.CurrentStudent == 10 || this.CurrentStudent == this.StudentManager.RivalID)
				{
					this.StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(11);
					base.gameObject.SetActive(false);
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
					base.gameObject.SetActive(false);
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
				}
				else
				{
					this.StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(0);
					base.gameObject.SetActive(false);
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
				this.NoteLocker.transform.position += new Vector3(0f, 1.355f, 0f);
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
				this.NoteLocker.Timer = 0f;
				this.StudentInfoMenu.PauseScreen.MainMenu.SetActive(true);
				this.StudentInfoMenu.PauseScreen.Show = false;
				this.StudentInfoMenu.FindingLocker = false;
				base.gameObject.SetActive(false);
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
					StudentScript studentScript = this.StudentManager.Students[this.CurrentStudent];
					ScheduleBlock scheduleBlock = studentScript.ScheduleBlocks[3];
					scheduleBlock.destination = "LunchSpot";
					scheduleBlock.action = "Eat";
					studentScript.GetDestinations();
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
					this.StudentInfoMenu.PauseScreen.ServiceMenu.gameObject.SetActive(true);
					this.StudentInfoMenu.PauseScreen.ServiceMenu.UpdateList();
					this.StudentInfoMenu.PauseScreen.ServiceMenu.UpdateDesc();
					this.StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
					this.StudentInfoMenu.FiringCouncilMember = false;
					this.StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(9);
				}
				else
				{
					this.StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(0);
				}
				base.gameObject.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.Label[1].text = "Back";
				this.PromptBar.UpdateButtons();
			}
			else if (this.StudentInfoMenu.GettingOpinions)
			{
				for (int i = 1; i < 26; i++)
				{
					ConversationGlobals.SetTopicDiscovered(i, true);
					ConversationGlobals.SetTopicLearnedByStudent(i, this.CurrentStudent, true);
				}
				this.StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
				base.gameObject.SetActive(false);
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
			base.GetComponent<AudioSource>().Stop();
			this.ReputationChart.transform.localScale = new Vector3(0f, 0f, 0f);
			if (this.Shutter != null)
			{
				if (!this.Shutter.PhotoIcons.activeInHierarchy)
				{
					this.Back = true;
				}
			}
			else
			{
				this.Back = true;
			}
			if (this.Back)
			{
				this.StudentInfoMenu.gameObject.SetActive(true);
				base.gameObject.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "View Info";
				if (!this.StudentInfoMenu.Gossiping)
				{
					this.PromptBar.Label[1].text = "Back";
				}
				this.PromptBar.UpdateButtons();
				this.Back = false;
			}
		}
		if (Input.GetButtonDown("X") && this.PromptBar.Button[2].enabled)
		{
			if (this.StudentManager.Tag.Target != this.StudentManager.Students[this.CurrentStudent].Head)
			{
				this.StudentManager.Tag.Target = this.StudentManager.Students[this.CurrentStudent].Head;
				this.StudentManager.TagStudentID = this.CurrentStudent;
				this.PromptBar.Label[2].text = "Untag";
			}
			else
			{
				this.StudentManager.TagStudentID = 0;
				this.StudentManager.Tag.Target = null;
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
		if (this.Yandere != null && !this.Yandere.NoDebug)
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
				this.CurrentStudent++;
				if (this.CurrentStudent > 100)
				{
					this.CurrentStudent = 1;
				}
				while (!StudentGlobals.GetStudentPhotographed(this.CurrentStudent))
				{
					this.CurrentStudent++;
					if (this.CurrentStudent > 100)
					{
						this.CurrentStudent = 1;
					}
				}
				this.UpdateInfo(this.CurrentStudent);
				this.UpdateTopics();
			}
			if (this.StudentInfoMenu.PauseScreen.InputManager.TappedLeft)
			{
				this.CurrentStudent--;
				if (this.CurrentStudent < 1)
				{
					this.CurrentStudent = 100;
				}
				while (!StudentGlobals.GetStudentPhotographed(this.CurrentStudent))
				{
					this.CurrentStudent--;
					if (this.CurrentStudent < 1)
					{
						this.CurrentStudent = 100;
					}
				}
				this.UpdateInfo(this.CurrentStudent);
				this.UpdateTopics();
			}
		}
		if (this.ShowRep)
		{
			this.ReputationChart.transform.localScale = Vector3.Lerp(this.ReputationChart.transform.localScale, new Vector3(138f, 138f, 138f), Time.unscaledDeltaTime * 10f);
			return;
		}
		this.ReputationChart.transform.localScale = Vector3.Lerp(this.ReputationChart.transform.localScale, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
	}

	// Token: 0x06001D7F RID: 7551 RVA: 0x00165C4C File Offset: 0x00163E4C
	private void UpdateAdditionalInfo(int ID)
	{
		if (!this.Eighties)
		{
			if (ID == 11)
			{
				if (this.Yandere != null)
				{
					this.Strings[1] = (this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 ? "May be a victim of blackmail." : "?????");
					this.Strings[2] = (this.Yandere.Police.EndOfDay.LearnedOsanaInfo2 ? "Has a stalker." : "?????");
				}
				else
				{
					this.Strings[1] = "?????";
					this.Strings[2] = "?????";
				}
				this.InfoLabel.text = this.Strings[1] + "\n\n" + this.Strings[2];
				return;
			}
			if (ID == 51)
			{
				if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
				{
					this.InfoLabel.text = "Disbanded the Light Music Club, dyed her hair back to its original color, removed her piercings, and stopped socializing with others.";
					return;
				}
				this.InfoLabel.text = this.JSON.Students[ID].Info;
				return;
			}
			else
			{
				if (StudentGlobals.GetStudentReplaced(ID))
				{
					this.InfoLabel.text = "No additional information is available at this time.";
					return;
				}
				if (this.JSON.Students[ID].Info == string.Empty)
				{
					this.InfoLabel.text = "No additional information is available at this time.";
					return;
				}
				this.InfoLabel.text = this.JSON.Students[ID].Info;
				return;
			}
		}
		else
		{
			if (StudentGlobals.GetStudentReplaced(ID))
			{
				this.InfoLabel.text = "No additional information is available at this time.";
				return;
			}
			if (this.JSON.Students[ID].Info == string.Empty)
			{
				this.InfoLabel.text = "No additional information is available at this time.";
				return;
			}
			this.InfoLabel.text = this.JSON.Students[ID].Info;
			return;
		}
	}

	// Token: 0x06001D80 RID: 7552 RVA: 0x00165E1C File Offset: 0x0016401C
	private void UpdateTopics()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 1; i < this.TopicIcons.Length; i++)
		{
			this.TopicIcons[i].spriteName = ((!ConversationGlobals.GetTopicDiscovered(i)) ? 0 : i).ToString();
		}
		for (int j = 1; j <= 25; j++)
		{
			UISprite uisprite = this.TopicOpinionIcons[j];
			if (!ConversationGlobals.GetTopicLearnedByStudent(j, this.CurrentStudent))
			{
				uisprite.spriteName = "Unknown";
			}
			else
			{
				int[] topics = this.JSON.Topics[this.CurrentStudent].Topics;
				uisprite.spriteName = this.OpinionSpriteNames[topics[j]];
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
	}

	// Token: 0x06001D81 RID: 7553 RVA: 0x00165EE0 File Offset: 0x001640E0
	private void UpdateRepChart()
	{
		Vector3 vector = Vector3.zero;
		if (this.CurrentStudent < 100)
		{
			vector = StudentGlobals.GetReputationTriangle(this.CurrentStudent);
		}
		else if (!this.Eighties)
		{
			vector = new Vector3((float)UnityEngine.Random.Range(-100, 101), (float)UnityEngine.Random.Range(-100, 101), (float)UnityEngine.Random.Range(-100, 101));
		}
		else
		{
			vector = new Vector3(0f, 50f, 100f);
		}
		this.ReputationChart.fields[0].Value = vector.x;
		this.ReputationChart.fields[1].Value = vector.y;
		this.ReputationChart.fields[2].Value = vector.z;
	}

	// Token: 0x06001D82 RID: 7554 RVA: 0x00165FA4 File Offset: 0x001641A4
	private void MatchmadeCheck()
	{
		this.Matchmade = false;
		if (this.Eighties)
		{
			if ((this.CurrentStudent > 10 && this.CurrentStudent < 21 && GameGlobals.GetRivalEliminations(this.CurrentStudent - 10) == 6) || (this.CurrentStudent == 22 && GameGlobals.GetRivalEliminations(1) == 6) || (this.CurrentStudent == 27 && GameGlobals.GetRivalEliminations(2) == 6) || (this.CurrentStudent == 32 && GameGlobals.GetRivalEliminations(3) == 6) || (this.CurrentStudent == 37 && GameGlobals.GetRivalEliminations(4) == 6) || (this.CurrentStudent == 42 && GameGlobals.GetRivalEliminations(5) == 6) || (this.CurrentStudent == 47 && GameGlobals.GetRivalEliminations(6) == 6) || (this.CurrentStudent == 57 && GameGlobals.GetRivalEliminations(7) == 6) || (this.CurrentStudent == 62 && GameGlobals.GetRivalEliminations(8) == 6) || (this.CurrentStudent == 67 && GameGlobals.GetRivalEliminations(9) == 6) || (this.CurrentStudent == 72 && GameGlobals.GetRivalEliminations(10) == 6))
			{
				this.Matchmade = true;
				if (this.CurrentStudent == 11)
				{
					this.PartnerName = this.JSON.Students[22].Name;
					return;
				}
				if (this.CurrentStudent == 12)
				{
					this.PartnerName = this.JSON.Students[27].Name;
					return;
				}
				if (this.CurrentStudent == 13)
				{
					this.PartnerName = this.JSON.Students[28].Name;
					return;
				}
				if (this.CurrentStudent == 14)
				{
					this.PartnerName = this.JSON.Students[32].Name;
					return;
				}
				if (this.CurrentStudent == 15)
				{
					this.PartnerName = this.JSON.Students[42].Name;
					return;
				}
				if (this.CurrentStudent == 16)
				{
					this.PartnerName = this.JSON.Students[47].Name;
					return;
				}
				if (this.CurrentStudent == 17)
				{
					this.PartnerName = this.JSON.Students[57].Name;
					return;
				}
				if (this.CurrentStudent == 18)
				{
					this.PartnerName = this.JSON.Students[62].Name;
					return;
				}
				if (this.CurrentStudent == 19)
				{
					this.PartnerName = this.JSON.Students[67].Name;
					return;
				}
				if (this.CurrentStudent == 20)
				{
					this.PartnerName = this.JSON.Students[72].Name;
					return;
				}
				if (this.CurrentStudent == 22)
				{
					this.PartnerName = this.JSON.Students[11].Name;
					return;
				}
				if (this.CurrentStudent == 27)
				{
					this.PartnerName = this.JSON.Students[12].Name;
					return;
				}
				if (this.CurrentStudent == 32)
				{
					this.PartnerName = this.JSON.Students[13].Name;
					return;
				}
				if (this.CurrentStudent == 37)
				{
					this.PartnerName = this.JSON.Students[14].Name;
					return;
				}
				if (this.CurrentStudent == 42)
				{
					this.PartnerName = this.JSON.Students[15].Name;
					return;
				}
				if (this.CurrentStudent == 47)
				{
					this.PartnerName = this.JSON.Students[16].Name;
					return;
				}
				if (this.CurrentStudent == 57)
				{
					this.PartnerName = this.JSON.Students[17].Name;
					return;
				}
				if (this.CurrentStudent == 62)
				{
					this.PartnerName = this.JSON.Students[18].Name;
					return;
				}
				if (this.CurrentStudent == 67)
				{
					this.PartnerName = this.JSON.Students[19].Name;
					return;
				}
				if (this.CurrentStudent == 72)
				{
					this.PartnerName = this.JSON.Students[20].Name;
					return;
				}
			}
		}
		else if ((this.CurrentStudent > 10 && this.CurrentStudent < 21 && GameGlobals.GetRivalEliminations(this.CurrentStudent - 10) == 6) || (this.CurrentStudent == 6 && GameGlobals.GetRivalEliminations(1) == 6))
		{
			this.Matchmade = true;
			if (this.CurrentStudent == 11)
			{
				this.PartnerName = this.JSON.Students[6].Name;
				return;
			}
			if (this.CurrentStudent == 6)
			{
				this.PartnerName = this.JSON.Students[11].Name;
			}
		}
	}

	// Token: 0x06001D83 RID: 7555 RVA: 0x00166418 File Offset: 0x00164618
	private void CensorUnknownRivalInfo()
	{
		if (this.CurrentStudent > 10 && this.CurrentStudent < 21 && DateGlobals.Week < this.CurrentStudent - 10)
		{
			this.NameLabel.text = "?????";
			this.PersonaLabel.text = "?????";
			this.CrushLabel.text = "?????";
			this.ClubLabel.text = "?????";
			this.StrengthLabel.text = "?????";
			this.InfoLabel.text = "?????";
			this.ReputationLabel.text = "";
			this.ReputationBar.localPosition = new Vector3(0f, -10f, 0f);
		}
	}

	// Token: 0x04003679 RID: 13945
	public StudentInfoMenuScript StudentInfoMenu;

	// Token: 0x0400367A RID: 13946
	public StudentManagerScript StudentManager;

	// Token: 0x0400367B RID: 13947
	public DialogueWheelScript DialogueWheel;

	// Token: 0x0400367C RID: 13948
	public HomeInternetScript HomeInternet;

	// Token: 0x0400367D RID: 13949
	public TopicManagerScript TopicManager;

	// Token: 0x0400367E RID: 13950
	public NoteLockerScript NoteLocker;

	// Token: 0x0400367F RID: 13951
	public RadarChart ReputationChart;

	// Token: 0x04003680 RID: 13952
	public PromptBarScript PromptBar;

	// Token: 0x04003681 RID: 13953
	public ShutterScript Shutter;

	// Token: 0x04003682 RID: 13954
	public YandereScript Yandere;

	// Token: 0x04003683 RID: 13955
	public JsonScript JSON;

	// Token: 0x04003684 RID: 13956
	public Texture GuidanceCounselor;

	// Token: 0x04003685 RID: 13957
	public Texture DefaultPortrait;

	// Token: 0x04003686 RID: 13958
	public Texture BlankPortrait;

	// Token: 0x04003687 RID: 13959
	public Texture Headmaster;

	// Token: 0x04003688 RID: 13960
	public Texture InfoChan;

	// Token: 0x04003689 RID: 13961
	public Transform ReputationBar;

	// Token: 0x0400368A RID: 13962
	public GameObject Static;

	// Token: 0x0400368B RID: 13963
	public GameObject Topics;

	// Token: 0x0400368C RID: 13964
	public UILabel OccupationLabel;

	// Token: 0x0400368D RID: 13965
	public UILabel ReputationLabel;

	// Token: 0x0400368E RID: 13966
	public UILabel RealNameLabel;

	// Token: 0x0400368F RID: 13967
	public UILabel StrengthLabel;

	// Token: 0x04003690 RID: 13968
	public UILabel PersonaLabel;

	// Token: 0x04003691 RID: 13969
	public UILabel ClassLabel;

	// Token: 0x04003692 RID: 13970
	public UILabel CrushLabel;

	// Token: 0x04003693 RID: 13971
	public UILabel ClubLabel;

	// Token: 0x04003694 RID: 13972
	public UILabel InfoLabel;

	// Token: 0x04003695 RID: 13973
	public UILabel NameLabel;

	// Token: 0x04003696 RID: 13974
	public UITexture Portrait;

	// Token: 0x04003697 RID: 13975
	public string[] OpinionSpriteNames;

	// Token: 0x04003698 RID: 13976
	public string[] Strings;

	// Token: 0x04003699 RID: 13977
	public int CurrentStudent;

	// Token: 0x0400369A RID: 13978
	public bool UpdatedOnce;

	// Token: 0x0400369B RID: 13979
	public bool Eighties;

	// Token: 0x0400369C RID: 13980
	public bool ShowRep;

	// Token: 0x0400369D RID: 13981
	public bool Back;

	// Token: 0x0400369E RID: 13982
	public UISprite[] TopicIcons;

	// Token: 0x0400369F RID: 13983
	public UISprite[] TopicOpinionIcons;

	// Token: 0x040036A0 RID: 13984
	private static readonly IntAndStringDictionary StrengthStrings = new IntAndStringDictionary
	{
		{
			0,
			"Incapable"
		},
		{
			1,
			"Very Weak"
		},
		{
			2,
			"Weak"
		},
		{
			3,
			"Strong"
		},
		{
			4,
			"Very Strong"
		},
		{
			5,
			"Peak Physical Strength"
		},
		{
			6,
			"Extensive Training"
		},
		{
			7,
			"Carries Pepper Spray"
		},
		{
			8,
			"Armed"
		},
		{
			9,
			"Invincible"
		},
		{
			99,
			"?????"
		}
	};

	// Token: 0x040036A1 RID: 13985
	public UILabel LeftCrushLabel;

	// Token: 0x040036A2 RID: 13986
	public string PartnerName;

	// Token: 0x040036A3 RID: 13987
	public bool Matchmade;
}
