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

	public bool Started;

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

	public float HeldDown;

	public float HeldUp;

	public bool GrabbedPortraits;

	public bool Debugging;

	public void Start()
	{
		if (Started)
		{
			return;
		}
		StudentGlobals.SetStudentPhotographed(StudentManager.RivalID, true);
		StudentManager.StudentPhotographed[StudentManager.RivalID] = true;
		StudentGlobals.SetStudentPhotographed(0, true);
		StudentGlobals.SetStudentPhotographed(1, true);
		StudentManager.StudentPhotographed[0] = true;
		StudentManager.StudentPhotographed[1] = true;
		StudentGlobals.SetStudentPhotographed(98, true);
		StudentGlobals.SetStudentPhotographed(99, true);
		StudentGlobals.SetStudentPhotographed(100, true);
		StudentManager.StudentPhotographed[98] = true;
		StudentManager.StudentPhotographed[99] = true;
		StudentManager.StudentPhotographed[100] = true;
		BusyBlocker.position = new Vector3(0f, 0f, 0f);
		for (int i = 1; i < 101; i++)
		{
			GameObject gameObject = Object.Instantiate(StudentPortrait, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = PortraitGrid;
			gameObject.transform.localPosition = new Vector3(-300f + (float)Column * 150f, 80f - (float)Row * 160f, 0f);
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			StudentPortraits[i] = gameObject.GetComponent<StudentPortraitScript>();
			Column++;
			if (Column > 4)
			{
				Column = 0;
				Row++;
			}
		}
		if (PauseScreen.Eighties)
		{
			UnknownPortrait = EightiesUnknown;
			BlankPortrait = EightiesUnknown;
			Headmaster = EightiesHeadmaster;
			Counselor = EightiesCounselor;
			InfoChan = Journalist;
		}
		if (PauseScreen.Home)
		{
			if (!GameGlobals.ReputationsInitialized)
			{
				StudentManager.InitializeReputations();
			}
			else
			{
				StudentManager.LoadReps();
			}
			StudentManager.LoadPhotographs();
			StudentManager.LoadPantyshots();
		}
		Column = 0;
		Row = 0;
		Started = true;
		UpdateHighlight();
	}

	private void Update()
	{
		if (!GrabbedPortraits)
		{
			StartCoroutine(UpdatePortraits());
			GrabbedPortraits = true;
			if (PauseScreen.Eighties)
			{
				PauseScreen.BlackenAllText();
			}
		}
		if (Input.GetButtonDown("A"))
		{
			if (PromptBar.Label[0].text != string.Empty)
			{
				if (StudentManager.StudentPhotographed[StudentID] || StudentID > 97)
				{
					if (UsingLifeNote)
					{
						PauseScreen.MainMenu.SetActive(true);
						PauseScreen.Sideways = false;
						PauseScreen.Show = false;
						base.gameObject.SetActive(false);
						NoteWindow.TargetStudent = StudentID;
						NoteWindow.gameObject.SetActive(true);
						NoteWindow.SlotLabels[1].text = StudentManager.Students[StudentID].Name;
						NoteWindow.SlotsFilled[1] = true;
						UsingLifeNote = false;
						PromptBar.Label[0].text = "Confirm";
						PromptBar.UpdateButtons();
						NoteWindow.CheckForCompletion();
					}
					else
					{
						StudentInfo.gameObject.SetActive(true);
						StudentInfo.UpdateInfo(StudentID);
						StudentInfo.Topics.SetActive(false);
						base.gameObject.SetActive(false);
						PromptBar.ClearButtons();
						if (Gossiping)
						{
							PromptBar.Label[0].text = "Gossip";
						}
						if (Distracting)
						{
							PromptBar.Label[0].text = "Distract";
						}
						if (CyberBullying || CyberStalking)
						{
							PromptBar.Label[0].text = "Accept";
						}
						if (FindingLocker)
						{
							PromptBar.Label[0].text = "Find Locker";
						}
						if (MatchMaking)
						{
							PromptBar.Label[0].text = "Match";
						}
						if (Targeting || UsingLifeNote)
						{
							PromptBar.Label[0].text = "Kill";
						}
						if (SendingHome)
						{
							PromptBar.Label[0].text = "Send Home";
						}
						if (FiringCouncilMember)
						{
							PromptBar.Label[0].text = "Fire";
						}
						if (GettingOpinions)
						{
							PromptBar.Label[0].text = "Get Opinions";
						}
						if (StudentManager.Students[StudentID] != null)
						{
							if (StudentManager.Students[StudentID].gameObject.activeInHierarchy)
							{
								if (StudentManager.Tag.Target == StudentManager.Students[StudentID].Head)
								{
									PromptBar.Label[2].text = "Untag";
								}
								else
								{
									PromptBar.Label[2].text = "Tag";
								}
							}
							else
							{
								PromptBar.Label[2].text = "";
							}
						}
						else
						{
							PromptBar.Label[2].text = "";
						}
						PromptBar.Label[1].text = "Back";
						PromptBar.Label[3].text = "Interests";
						PromptBar.Label[6].text = "Reputation";
						PromptBar.UpdateButtons();
					}
				}
				else
				{
					StudentManager.StudentPhotographed[StudentID] = true;
					if (StudentManager.Students[StudentID] != null)
					{
						for (int i = 0; i < StudentManager.Students[StudentID].Outlines.Length; i++)
						{
							if (StudentManager.Students[StudentID].Outlines[i] != null)
							{
								StudentManager.Students[StudentID].Outlines[i].enabled = true;
							}
						}
					}
					PauseScreen.ServiceMenu.gameObject.SetActive(true);
					PauseScreen.ServiceMenu.UpdateList();
					PauseScreen.ServiceMenu.UpdateDesc();
					PauseScreen.ServiceMenu.Purchase();
					GettingInfo = false;
					base.gameObject.SetActive(false);
				}
				if (PauseScreen.Eighties)
				{
					PauseScreen.BlackenAllText();
				}
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			BusyBlocker.position = new Vector3(0f, 0f, 0f);
			if (Gossiping || Distracting || MatchMaking || Targeting)
			{
				if (Targeting)
				{
					PauseScreen.Yandere.RPGCamera.enabled = true;
				}
				PauseScreen.Yandere.Interaction = YandereInteractionType.Bye;
				PauseScreen.Yandere.TalkTimer = 2f;
				PauseScreen.MainMenu.SetActive(true);
				PauseScreen.Sideways = false;
				PauseScreen.Show = false;
				base.gameObject.SetActive(false);
				Time.timeScale = 1f;
				Distracting = false;
				MatchMaking = false;
				Gossiping = false;
				Targeting = false;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (CyberBullying || CyberStalking || FindingLocker)
			{
				PauseScreen.MainMenu.SetActive(true);
				PauseScreen.Sideways = false;
				PauseScreen.Show = false;
				base.gameObject.SetActive(false);
				Time.timeScale = 1f;
				if (FindingLocker)
				{
					PauseScreen.Yandere.RPGCamera.enabled = true;
				}
				FindingLocker = false;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (SendingHome || GettingInfo || GettingOpinions || FiringCouncilMember)
			{
				PauseScreen.ServiceMenu.gameObject.SetActive(true);
				PauseScreen.ServiceMenu.UpdateList();
				PauseScreen.ServiceMenu.UpdateDesc();
				base.gameObject.SetActive(false);
				FiringCouncilMember = false;
				GettingOpinions = false;
				SendingHome = false;
				GettingInfo = false;
			}
			else if (UsingLifeNote)
			{
				PauseScreen.MainMenu.SetActive(true);
				PauseScreen.Sideways = false;
				PauseScreen.Show = false;
				base.gameObject.SetActive(false);
				NoteWindow.gameObject.SetActive(true);
				UsingLifeNote = false;
			}
			else
			{
				PauseScreen.MainMenu.SetActive(true);
				PauseScreen.Sideways = false;
				PauseScreen.PressedB = true;
				base.gameObject.SetActive(false);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[1].text = "Exit";
				PromptBar.Label[4].text = "Choose";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
		}
		else
		{
			float t = Time.unscaledDeltaTime * 10f;
			float num = ((Row % 2 == 0) ? (Row / 2) : ((Row - 1) / 2));
			float b = 320f * num;
			PortraitGrid.localPosition = new Vector3(PortraitGrid.localPosition.x, Mathf.Lerp(PortraitGrid.localPosition.y, b, t), PortraitGrid.localPosition.z);
			Scrollbar.localPosition = new Vector3(Scrollbar.localPosition.x, Mathf.Lerp(Scrollbar.localPosition.y, 175f - 350f * (PortraitGrid.localPosition.y / 2880f), t), Scrollbar.localPosition.z);
			if (Row > 0)
			{
				if (InputManager.DPadUp || InputManager.StickUp || Input.GetKey("w") || Input.GetKey("up"))
				{
					HeldUp += Time.unscaledDeltaTime;
				}
				else
				{
					HeldUp = 0f;
				}
			}
			else
			{
				HeldUp = 0f;
			}
			if (Row < 19)
			{
				if (InputManager.DPadDown || InputManager.StickDown || Input.GetKey("s") || Input.GetKey("down"))
				{
					HeldDown += Time.unscaledDeltaTime;
				}
				else
				{
					HeldDown = 0f;
				}
			}
			else
			{
				HeldDown = 0f;
			}
			if (InputManager.TappedUp || HeldUp > 0.5f)
			{
				if (HeldUp > 0.5f)
				{
					HeldUp = 0.45f;
				}
				Row--;
				if (Row < 0)
				{
					Row = Rows - 1;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedDown || HeldDown > 0.5f)
			{
				if (HeldDown > 0.5f)
				{
					HeldDown = 0.45f;
				}
				Row++;
				if (Row > Rows - 1)
				{
					Row = 0;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedRight)
			{
				Column++;
				if (Column > Columns - 1)
				{
					Column = 0;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedLeft)
			{
				Column--;
				if (Column < 0)
				{
					Column = Columns - 1;
				}
				UpdateHighlight();
			}
		}
		if (GrabPortraitsNextFrame)
		{
			Frame++;
			if (Frame > 1)
			{
				StartCoroutine(UpdatePortraits());
				GrabPortraitsNextFrame = false;
				Frame = 0;
			}
		}
	}

	public void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(-300f + (float)Column * 150f, 80f - (float)Row * 160f, Highlight.localPosition.z);
		BusyBlocker.position = new Vector3(0f, 0f, 0f);
		StudentID = 1 + (Column + Row * Columns);
		if (StudentManager.StudentPhotographed[StudentID] || StudentID > 97)
		{
			PromptBar.Label[0].text = "View Info";
			PromptBar.UpdateButtons();
		}
		else
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (Gossiping && (StudentID == 1 || StudentID == PauseScreen.Yandere.TargetStudent.StudentID || JSON.Students[StudentID].Club == ClubType.Sports || StudentManager.Students[StudentID] == null || StudentGlobals.GetStudentDead(StudentID) || StudentGlobals.GetStudentKidnapped(StudentID) || (StudentID == StudentManager.RivalID && StudentManager.Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Expelled) || StudentID > 89))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (CyberBullying && (JSON.Students[StudentID].Gender == 1 || StudentGlobals.GetStudentDead(StudentID) || StudentID > 97))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (CyberStalking && (StudentGlobals.GetStudentDead(StudentID) || StudentGlobals.GetStudentArrested(StudentID) || StudentID > 97))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (FindingLocker && (StudentID == 1 || StudentID > 89 || (StudentManager.Students[StudentID] != null && StudentManager.Students[StudentID].Club == ClubType.Council) || StudentGlobals.GetStudentDead(StudentID)))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (Distracting)
		{
			Dead = false;
			if (StudentManager.Students[StudentID] == null)
			{
				Dead = true;
			}
			if (Dead)
			{
				PromptBar.Label[0].text = string.Empty;
				PromptBar.UpdateButtons();
			}
			else if (StudentID == 1 || !StudentManager.Students[StudentID].Alive || StudentID == PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentKidnapped(StudentID) || StudentManager.Students[StudentID].Tranquil || StudentManager.Students[StudentID].Teacher || StudentManager.Students[StudentID].Slave || StudentGlobals.GetStudentDead(StudentID) || StudentManager.Students[StudentID].MyBento.Tampered || StudentID > 97)
			{
				if (StudentID > 1 && StudentManager.Students[StudentID] != null && StudentManager.Students[StudentID].InEvent)
				{
					BusyBlocker.position = Highlight.position;
				}
				PromptBar.Label[0].text = string.Empty;
				PromptBar.UpdateButtons();
			}
		}
		if (MatchMaking && (StudentID == PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentDead(StudentID) || StudentID > 97))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (Targeting && (StudentManager.Students[StudentID] == null || StudentID == 1 || StudentID > 97 || StudentGlobals.GetStudentDead(StudentID) || !StudentManager.Students[StudentID].gameObject.activeInHierarchy || StudentManager.Students[StudentID].InEvent || StudentManager.Students[StudentID].Tranquil))
		{
			if (StudentID > 1 && StudentManager.Students[StudentID] != null && StudentManager.Students[StudentID].InEvent)
			{
				BusyBlocker.position = Highlight.position;
			}
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (SendingHome && StudentManager.Students[StudentID] != null)
		{
			StudentScript studentScript = StudentManager.Students[StudentID];
			if (StudentID == 1 || StudentGlobals.GetStudentDead(StudentID) || (StudentID < 98 && studentScript.SentHome) || StudentID > 97 || StudentGlobals.StudentSlave == StudentID || (studentScript.Club == ClubType.MartialArts && studentScript.ClubAttire) || (studentScript.Club == ClubType.Sports && studentScript.ClubAttire) || StudentManager.Students[StudentID].CameraReacting || !StudentManager.StudentPhotographed[StudentID] || studentScript.Wet || studentScript.Slave || studentScript.Phoneless)
			{
				PromptBar.Label[0].text = string.Empty;
				PromptBar.UpdateButtons();
			}
		}
		if (GettingInfo)
		{
			if (StudentManager.StudentPhotographed[StudentID] || StudentID > 97)
			{
				PromptBar.Label[0].text = string.Empty;
			}
			else
			{
				PromptBar.Label[0].text = "Get Info";
			}
		}
		if (GettingOpinions)
		{
			if (StudentManager.StudentPhotographed[StudentID] && StudentID < 97)
			{
				PromptBar.Label[0].text = "Get Opinions";
			}
			else
			{
				PromptBar.Label[0].text = string.Empty;
			}
		}
		PromptBar.UpdateButtons();
		if (UsingLifeNote)
		{
			if (StudentID == 1 || StudentID > 97 || (StudentID > 11 && StudentID < 21) || StudentPortraits[StudentID].DeathShadow.activeInHierarchy || (StudentManager.Students[StudentID] != null && !StudentManager.Students[StudentID].enabled))
			{
				PromptBar.Label[0].text = "";
			}
			else
			{
				PromptBar.Label[0].text = "Kill";
			}
			PromptBar.UpdateButtons();
		}
		if (FiringCouncilMember)
		{
			if (StudentManager.Students[StudentID] != null)
			{
				if (!StudentManager.StudentPhotographed[StudentID] || StudentManager.Students[StudentID].Club != ClubType.Council)
				{
					PromptBar.Label[0].text = "";
				}
				else
				{
					PromptBar.Label[0].text = "Fire";
				}
			}
			PromptBar.UpdateButtons();
		}
		if (MissionModeGlobals.MissionMode && StudentID == 1)
		{
			PromptBar.Label[0].text = "";
		}
		if (PauseScreen.Eighties && Headmaster != EightiesHeadmaster)
		{
			Headmaster = EightiesHeadmaster;
			Counselor = EightiesCounselor;
			InfoChan = Journalist;
			if (StudentPortraits[98] != null)
			{
				StudentPortraits[98].Portrait.mainTexture = Counselor;
				StudentPortraits[99].Portrait.mainTexture = Headmaster;
				StudentPortraits[100].Portrait.mainTexture = InfoChan;
			}
		}
		UpdateNameLabel();
	}

	private void UpdateNameLabel()
	{
		if (StudentID > 97 || StudentManager.StudentPhotographed[StudentID] || GettingInfo)
		{
			NameLabel.text = JSON.Students[StudentID].Name;
			if (StudentManager.Eighties && StudentID > 10 && StudentID < 21 && DateGlobals.Week < StudentID - 10)
			{
				NameLabel.text = "Unknown";
			}
		}
		else
		{
			NameLabel.text = "Unknown";
		}
	}

	public IEnumerator UpdatePortraits()
	{
		if (Debugging)
		{
			Debug.Log("The Student Info Menu was instructed to get photos.");
		}
		string EightiesPrefix = "";
		if (PauseScreen.Eighties)
		{
			EightiesPrefix = "1989";
		}
		for (int ID = 1; ID < 101; ID++)
		{
			if (ID == 0)
			{
				StudentPortraits[ID].Portrait.mainTexture = InfoChan;
			}
			else if (!PortraitLoaded[ID])
			{
				if (ID < 98)
				{
					if (PauseScreen.Eighties || (!PauseScreen.Eighties && ID < 12) || (!PauseScreen.Eighties && ID > 20))
					{
						if (StudentManager.StudentPhotographed[ID])
						{
							string url = "file:///" + Application.streamingAssetsPath + "/Portraits" + EightiesPrefix + "/Student_" + ID + ".png";
							WWW www = new WWW(url);
							yield return www;
							if (www.error == null)
							{
								if (!StudentGlobals.GetStudentReplaced(ID))
								{
									StudentPortraits[ID].Portrait.mainTexture = www.texture;
								}
								else
								{
									StudentPortraits[ID].Portrait.mainTexture = BlankPortrait;
								}
							}
							else
							{
								Debug.Log("Student #" + ID + " gets an '' Unknown'' portrait because an error occured.");
								StudentPortraits[ID].Portrait.mainTexture = UnknownPortrait;
							}
							PortraitLoaded[ID] = true;
						}
						else if (StudentPortraits[ID] != null)
						{
							StudentPortraits[ID].Portrait.mainTexture = UnknownPortrait;
						}
					}
					else if (StudentPortraits[ID] != null)
					{
						StudentPortraits[ID].Portrait.mainTexture = RivalPortraits[ID];
					}
				}
				else if (StudentPortraits[ID] != null)
				{
					switch (ID)
					{
					case 98:
						StudentPortraits[ID].Portrait.mainTexture = Counselor;
						break;
					case 99:
						StudentPortraits[ID].Portrait.mainTexture = Headmaster;
						break;
					case 100:
						StudentPortraits[ID].Portrait.mainTexture = InfoChan;
						break;
					default:
						StudentPortraits[ID].Portrait.mainTexture = RivalPortraits[ID];
						break;
					}
				}
			}
			if (StudentManager.PantyShotTaken[ID] || PlayerGlobals.GetStudentPantyShot(ID))
			{
				StudentPortraits[ID].Panties.SetActive(true);
			}
			if (StudentManager.Students[ID] != null && StudentPortraits[ID] != null)
			{
				StudentPortraits[ID].Friend.SetActive(StudentManager.Students[ID].Friend);
			}
			else if (StudentPortraits[ID] != null)
			{
				StudentPortraits[ID].Friend.SetActive(PlayerGlobals.GetStudentFriend(ID));
			}
			if (StudentGlobals.GetStudentDying(ID) || StudentGlobals.GetStudentDead(ID) || (StudentManager.Students[ID] != null && !StudentManager.Students[ID].Alive))
			{
				StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			if (MissionModeGlobals.MissionMode && ID == 1)
			{
				StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			if (SceneManager.GetActiveScene().name == "SchoolScene" && StudentManager.Students[ID] != null && StudentManager.Students[ID].Tranquil)
			{
				StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			if (StudentGlobals.GetStudentArrested(ID))
			{
				StudentPortraits[ID].PrisonBars.SetActive(true);
				StudentPortraits[ID].DeathShadow.SetActive(true);
			}
			if (StudentManager.Eighties && ID > 11 && ID < 21 && DateGlobals.Week < ID - 10 && StudentPortraits[ID] != null)
			{
				StudentPortraits[ID].Portrait.mainTexture = UnknownPortrait;
			}
		}
	}
}
