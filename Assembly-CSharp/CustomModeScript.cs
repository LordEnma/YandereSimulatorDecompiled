using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class CustomModeScript : MonoBehaviour
{
	public NotificationManagerScript NotificationManager;

	public StudentManagerScript StudentManager;

	public CosmeticScript StudentChanCosmetic;

	public CosmeticScript StudentKunCosmetic;

	public UniformSetterScript InitialFemale;

	public UniformSetterScript InitialMale;

	public InputManagerScript InputManager;

	public PostProcessingProfile Profile;

	public InputDeviceScript InputDevice;

	public MapIconScript CurrentMapIcon;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public AudioSource Jukebox;

	public Renderer MapShadow;

	public JsonScript JSON;

	public MapScript Map;

	public GameObject PreviousButton;

	public GameObject NextButton;

	public GameObject NumberBubble;

	public GameObject TextWindow;

	public GameObject MapIcon;

	public GameObject Protagonist;

	public GameObject Headmaster;

	public GameObject Journalist;

	public GameObject Counselor;

	public GameObject StudentChan;

	public GameObject StudentKun;

	public Transform CharacterParent;

	public Transform StudentList;

	public Transform NameList;

	public Transform MiscellaneousArrow;

	public Transform CosmeticArrow;

	public Transform LocationArrow;

	public Transform ScheduleArrow;

	public Transform InitialArrow;

	public Transform EventArrow;

	public Transform RivalArrow;

	public Transform Arrow;

	public Transform ZoomTarget;

	public UIPanel ConfirmGenderPanel;

	public UIPanel ConfirmRandomPanel;

	public UIPanel ConfirmResetPanel;

	public UIPanel MiscellaneousPanel;

	public UIPanel StudentInfoPanel;

	public UIPanel StudentListPanel;

	public UIPanel LocationsPanel;

	public UIPanel CosmeticPanel;

	public UIPanel OpinionsPanel;

	public UIPanel SchedulePanel;

	public UIPanel InitialPanel;

	public UIPanel TopDownPanel;

	public UIPanel EventPanel;

	public UIPanel ReadyPanel;

	public UIPanel RivalPanel;

	public UIPanel HangoutPanel;

	public UIPanel Patrol1Panel;

	public UIPanel Patrol2Panel;

	public UIPanel MapPanel;

	public bool Initializing;

	public bool ViewingStudents;

	public bool EditingRivals;

	public bool ViewingRivals;

	public bool Miscellaneous;

	public bool Finalizing;

	public bool EditingStudent;

	public bool EditingCosmetic;

	public bool EditingDetails;

	public bool EditingOpinions;

	public bool EditingSchedule;

	public bool EditingLocations;

	public bool PlayerIsTyping;

	public bool CanGenderSwap;

	public bool WeekSelect;

	public bool UsingMenu;

	public bool FadeOut;

	public bool Zoom;

	public int CosmeticSelected;

	public int LocationSelected;

	public int InitialSelected;

	public int DetailSelected;

	public int OptionSelected;

	public int RivalSelected;

	public int Selected;

	public int AccessoryLimit;

	public int HairstyleLimit;

	public int EyewearLimit;

	public int FemaleUniform;

	public int MaleUniform;

	public int EyeColorID;

	public int StockingID;

	public int EyeTypeID;

	public int ColorID;

	public int LocationID;

	public int ActionID;

	public int EventID;

	public float HeldDown;

	public float HeldUp;

	public UILabel LocationInstructionLabel;

	public UILabel FemaleUniformLabel;

	public UILabel MaleUniformLabel;

	public UILabel GenderSwapLabel;

	public UILabel SecondHeaderLabel;

	public UILabel HeaderLabel;

	public UILabel NameLabel;

	public UILabel ClassLabel;

	public UILabel SeatLabel;

	public UILabel ClubLabel;

	public UILabel PersonaLabel;

	public UILabel CrushLabel;

	public UILabel StrengthLabel;

	public UILabel InfoLabel;

	public UILabel EditedLabel;

	public UILabel ScheduleHelpLabel;

	public UITexture LocationPreview;

	public UISprite White;

	public UILabel[] EventLocationLabels;

	public UILabel[] MiscellaneousLabels;

	public UILabel[] EditableLabels;

	public UILabel[] RivalNameLabels;

	public UILabel[] MethodLabels;

	public UILabel[] LocationLabels;

	public UILabel[] ActionLabels;

	public UILabel[] TimeLabels;

	public UISprite[] EditingCircles;

	public UISprite[] LocationBGs;

	public UISprite[] Circles;

	public Transform[] HangoutIcons;

	public Transform[] HangoutArrows;

	public Transform[] Patrol1Icons;

	public Transform[] Patrol1Arrows;

	public Transform[] Patrol2Icons;

	public Transform[] Patrol2Arrows;

	public Transform[] ZoomTargets;

	public Texture[] LocationScreenshots;

	public Collider[] LabelColliders;

	public string[] DestinationExplanations;

	public string[] ActionExplanations;

	public string[] TimeExplanations;

	public string[] DescText;

	public bool[] MiscellaneousOptions;

	public bool[] StudentGenders;

	public string[] EliminationNames;

	public string[] Destinations;

	public string[] Actions;

	public int[] PlayerOpinions;

	public int[] ArrayToEdit;

	public int[] SkinColor;

	public int[] AnimSet;

	public int[] EyeWear;

	public AudioClip[] BGM;

	public int CurrentBGM;

	public GameObject YakuzaWindow;

	public ColorPicker ColorWheel;

	public bool ForceYakuza;

	public string[] Surnames;

	public string[] MaleNames;

	public string[] FemaleNames;

	public string[] Colors;

	public string[] EyeTypes;

	public string[] StockingColors;

	public string[] PersonaNames;

	public string[] StrengthNames;

	public string[] MaleIdles;

	public string[] FemaleIdles;

	public bool[] UsedSurnames;

	public bool[] UsedMaleNames;

	public bool[] UsedFemaleNames;

	public bool[] UsedMaleHairs;

	public bool[] UsedFemaleHairs;

	public bool[] UsedTeacherHairs;

	public UISprite[] CosmeticBubbles;

	public UISprite[] CosmeticWindows;

	public UILabel[] CosmeticLabels;

	public Color ColorValue;

	public Color[] CustomHairColor;

	public Color[] CustomEyeColor;

	public Transform TopicHighlight;

	public UISprite[] OpinionIcons;

	public UISprite[] TopicIcons;

	public UILabel TopicLabel;

	public int TopicSelected;

	public int Opinion;

	public int Column;

	public int Row;

	public int Dislikes;

	public int Likes;

	public string[] OpinionSpriteNames;

	public string[] TopicNames;

	public StudentJson[] LoadedStudentData;

	public TopicJson[] LoadedTopicData;

	public string TimeString;

	public string HourNumber;

	public string MinuteNumber;

	protected static string FolderPath => Path.Combine(Application.streamingAssetsPath, "JSON");

	private void Start()
	{
		AcknowledgeChallenges();
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		GameGlobals.Eighties = true;
		StudentManager.Eighties = GameGlobals.Eighties;
		GameGlobals.CustomMode = false;
		FemaleUniform = StudentGlobals.FemaleUniform;
		MaleUniform = StudentGlobals.MaleUniform;
		JSON.Misc.FemaleUniform = FemaleUniform;
		JSON.Misc.MaleUniform = MaleUniform;
		FemaleUniformLabel.text = FemaleUniform.ToString() ?? "";
		MaleUniformLabel.text = MaleUniform.ToString() ?? "";
		StudentKun.GetComponent<StudentScript>().DisableProps();
		StudentKun.GetComponent<StudentScript>().DisableMaleProps();
		StudentKun.GetComponent<StudentScript>().SetSplashes(Bool: false);
		StudentChan.GetComponent<StudentScript>().DisableProps();
		StudentChan.GetComponent<StudentScript>().DisableFemaleProps();
		StudentChan.GetComponent<StudentScript>().SetSplashes(Bool: false);
		DestroyComponentsInChildren(StudentKun.transform);
		DestroyComponentsInChildren(StudentChan.transform);
		for (int i = 0; i < 101; i++)
		{
			GameObject obj = UnityEngine.Object.Instantiate(NumberBubble, base.transform.position, Quaternion.identity);
			obj.transform.parent = StudentList;
			obj.transform.localPosition = new Vector3(-925f, 400 - 100 * i, 0f);
			obj.transform.localScale = new Vector3(1f, 1f, 1f);
			obj.transform.GetChild(0).GetComponent<UILabel>().text = i.ToString() ?? "";
		}
		for (int i = 0; i < 101; i++)
		{
			GameObject obj2 = UnityEngine.Object.Instantiate(TextWindow, base.transform.position, Quaternion.identity);
			obj2.transform.parent = StudentList;
			obj2.transform.localPosition = new Vector3(-700f, 400 - 100 * i, 0f);
			obj2.transform.localScale = new Vector3(1f, 1f, 1f);
			obj2.transform.GetChild(0).GetComponent<UILabel>().text = DescText[i];
		}
		for (int i = 1; i < 101; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(MapIcon, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = HangoutPanel.transform;
			gameObject.transform.localPosition = new Vector3(0f, 1f, 0f);
			gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			HangoutIcons[i] = gameObject.transform;
			HangoutArrows[i] = gameObject.GetComponent<MapIconScript>().ArrowParent;
			gameObject.GetComponent<MapIconScript>().Label.text = "Student #" + i + " Hangout Spot";
			gameObject = UnityEngine.Object.Instantiate(MapIcon, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = Patrol1Panel.transform;
			gameObject.transform.localPosition = new Vector3(0f, 1f, 0f);
			gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			Patrol1Icons[i] = gameObject.transform;
			Patrol1Arrows[i] = gameObject.GetComponent<MapIconScript>().ArrowParent;
			gameObject.GetComponent<MapIconScript>().Label.text = "Student #" + i + " Patrol Spot #1";
			gameObject = UnityEngine.Object.Instantiate(MapIcon, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = Patrol2Panel.transform;
			gameObject.transform.localPosition = new Vector3(0f, 1f, 0f);
			gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			Patrol2Icons[i] = gameObject.transform;
			Patrol2Arrows[i] = gameObject.GetComponent<MapIconScript>().ArrowParent;
			gameObject.GetComponent<MapIconScript>().Label.text = "Student #" + i + " Patrol Spot #2";
		}
		for (int i = 0; i < LabelColliders.Length; i++)
		{
			LabelColliders[i].enabled = false;
		}
		Reset();
		PromptBar.ClearButtons();
		PromptBar.Label[0].text = "Select";
		PromptBar.Label[4].text = "Change Selection";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		ConfirmGenderPanel.alpha = 0f;
		ConfirmRandomPanel.alpha = 0f;
		MiscellaneousPanel.alpha = 0f;
		ConfirmResetPanel.alpha = 0f;
		StudentListPanel.alpha = 0f;
		StudentInfoPanel.alpha = 0f;
		LocationsPanel.alpha = 0f;
		CosmeticPanel.alpha = 0f;
		OpinionsPanel.alpha = 0f;
		SchedulePanel.alpha = 0f;
		InitialPanel.alpha = 1f;
		EventPanel.alpha = 0f;
		ReadyPanel.alpha = 0f;
		RivalPanel.alpha = 0f;
		UpdateDOF(2f);
		Initializing = true;
		UpdateHeader();
		UpdateCanonMethodLabels();
		White.alpha = 1f;
	}

	private void UpdateHeader()
	{
		EditingCircles[1].transform.parent.gameObject.SetActive(value: false);
		PreviousButton.SetActive(value: false);
		NextButton.SetActive(value: false);
		SecondHeaderLabel.text = "";
		Circles[1].enabled = false;
		Circles[2].enabled = false;
		Circles[3].enabled = false;
		Circles[4].enabled = false;
		Circles[5].enabled = false;
		if (Initializing)
		{
			NextButton.SetActive(value: true);
			HeaderLabel.text = "Start Screen";
			Circles[1].enabled = true;
		}
		else if (ViewingStudents)
		{
			PreviousButton.SetActive(value: true);
			NextButton.SetActive(value: true);
			HeaderLabel.text = "Student List";
			Circles[1].enabled = true;
			Circles[2].enabled = true;
		}
		else if (EditingStudent)
		{
			HeaderLabel.text = "Editing Student";
			Circles[1].enabled = true;
			Circles[2].enabled = true;
			if (Selected == 0)
			{
				PreviousButton.SetActive(value: true);
				return;
			}
			PreviousButton.SetActive(value: true);
			NextButton.SetActive(value: true);
			EditingCircles[1].transform.parent.gameObject.SetActive(value: true);
			EditingCircles[1].enabled = false;
			EditingCircles[2].enabled = false;
			EditingCircles[3].enabled = false;
			EditingCircles[4].enabled = false;
			EditingCircles[5].enabled = false;
			if (EditingCosmetic)
			{
				SecondHeaderLabel.text = "Editing Cosmetics";
				EditingCircles[1].enabled = true;
			}
			else if (EditingDetails)
			{
				SecondHeaderLabel.text = "Editing Details";
				EditingCircles[1].enabled = true;
				EditingCircles[2].enabled = true;
			}
			else if (EditingOpinions)
			{
				SecondHeaderLabel.text = "Editing Opinions";
				EditingCircles[1].enabled = true;
				EditingCircles[2].enabled = true;
				EditingCircles[3].enabled = true;
			}
			else if (EditingSchedule)
			{
				SecondHeaderLabel.text = "Editing Schedule";
				EditingCircles[1].enabled = true;
				EditingCircles[2].enabled = true;
				EditingCircles[3].enabled = true;
				EditingCircles[4].enabled = true;
			}
			else if (EditingLocations)
			{
				NextButton.SetActive(value: false);
				SecondHeaderLabel.text = "Editing Locations";
				EditingCircles[1].enabled = true;
				EditingCircles[2].enabled = true;
				EditingCircles[3].enabled = true;
				EditingCircles[4].enabled = true;
				EditingCircles[5].enabled = true;
			}
		}
		else if (ViewingRivals)
		{
			PreviousButton.SetActive(value: true);
			NextButton.SetActive(value: true);
			HeaderLabel.text = "Rival Editor";
			Circles[1].enabled = true;
			Circles[2].enabled = true;
			Circles[3].enabled = true;
		}
		else if (EditingRivals)
		{
			PreviousButton.SetActive(value: true);
			HeaderLabel.text = "Editing Rival # " + RivalSelected;
			Circles[1].enabled = true;
			Circles[2].enabled = true;
			Circles[3].enabled = true;
			EditingCircles[1].transform.parent.gameObject.SetActive(value: true);
			SecondHeaderLabel.text = "Event Editor";
			EditingCircles[1].enabled = true;
			EditingCircles[2].enabled = false;
			EditingCircles[3].enabled = false;
			EditingCircles[4].enabled = false;
			EditingCircles[5].enabled = false;
		}
		else if (Miscellaneous)
		{
			PreviousButton.SetActive(value: true);
			NextButton.SetActive(value: true);
			HeaderLabel.text = "Miscellaneous Options";
			Circles[1].enabled = true;
			Circles[2].enabled = true;
			Circles[3].enabled = true;
			Circles[4].enabled = true;
		}
		else if (Finalizing)
		{
			PreviousButton.SetActive(value: true);
			HeaderLabel.text = "Ready?";
			Circles[1].enabled = true;
			Circles[2].enabled = true;
			Circles[3].enabled = true;
			Circles[4].enabled = true;
			Circles[5].enabled = true;
		}
	}

	private void Update()
	{
		if (EditingStudent)
		{
			for (int i = 0; i < EditableLabels.Length; i++)
			{
				if (EditableLabels[i].color == Color.red)
				{
					Debug.Log("Player started typing?");
					EditedLabel = EditableLabels[i];
					PlayerIsTyping = true;
				}
			}
		}
		if (!PlayerIsTyping && Input.GetKeyDown("m"))
		{
			CurrentBGM++;
			if (CurrentBGM >= BGM.Length)
			{
				CurrentBGM = 0;
			}
			Jukebox.clip = BGM[CurrentBGM];
			Jukebox.Play();
		}
		if (FadeOut)
		{
			White.alpha = Mathf.MoveTowards(White.alpha, 1f, Time.deltaTime);
			Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0f, Time.deltaTime);
			if (!(White.alpha > 0.999f))
			{
				return;
			}
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			if (Initializing)
			{
				GameGlobals.CustomMode = false;
				SceneManager.LoadScene("NewTitleScene");
				return;
			}
			Save();
			GameGlobals.NoCouncilShove = !JSON.Misc.Misc[1];
			GameGlobals.NoJournalist = !JSON.Misc.Misc[2];
			if (JSON.Misc.Misc[3])
			{
				GameGlobals.IntroducedAbduction = true;
				GameGlobals.IntroducedRansom = true;
				GameGlobals.YakuzaPhase = 100;
			}
			GameGlobals.ForceCanonEliminations = JSON.Misc.Misc[4];
			GameGlobals.CanBefriendCouncil = JSON.Misc.Misc[5];
			StudentGlobals.FemaleUniform = JSON.Misc.FemaleUniform;
			StudentGlobals.MaleUniform = JSON.Misc.MaleUniform;
			GameGlobals.ReturnToCustomMode = true;
			GameGlobals.CustomMode = true;
			OptionGlobals.WindowedMode = Screen.fullScreen;
			if (JSON.Students[1].Gender == 0)
			{
				GameGlobals.FemaleSenpai = true;
			}
			AcknowledgeChallenges();
			if (WeekSelect)
			{
				SceneManager.LoadScene("WeekSelectScene");
				return;
			}
			Screen.SetResolution(512, 512, fullscreen: false);
			SceneManager.LoadScene("PortraitScene");
		}
		else if (!PlayerIsTyping)
		{
			Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 1f, Time.deltaTime);
			White.alpha = Mathf.MoveTowards(White.alpha, 0f, Time.deltaTime);
			if (InputManager.DPadUp || InputManager.StickUp || Input.GetKey("w") || Input.GetKey("up"))
			{
				HeldUp += Time.unscaledDeltaTime;
			}
			else
			{
				HeldUp = 0f;
			}
			if (InputManager.DPadDown || InputManager.StickDown || Input.GetKey("s") || Input.GetKey("down"))
			{
				HeldDown += Time.unscaledDeltaTime;
			}
			else
			{
				HeldDown = 0f;
			}
			if (!Initializing)
			{
				if (!Zoom && !EditingOpinions)
				{
					if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetKey("right") || Input.GetAxis(InputNames.Xbox_DpadX) > 0.5f)
					{
						CharacterParent.transform.Rotate(Vector3.up * Time.deltaTime * -360f);
					}
					if (Input.GetAxisRaw("Horizontal") < 0f || Input.GetKey("left") || Input.GetAxis(InputNames.Xbox_DpadX) < -0.5f)
					{
						CharacterParent.transform.Rotate(Vector3.up * Time.deltaTime * 360f);
					}
				}
				if ((ViewingStudents || (EditingStudent && !EditingOpinions && !EditingSchedule && !EditingLocations)) && Input.GetButtonDown(InputNames.Xbox_X))
				{
					CharacterParent.transform.eulerAngles = new Vector3(15f, 180f, 0f);
					Zoom = !Zoom;
					if (Zoom)
					{
						UpdateDOF(0.4f);
					}
					else
					{
						UpdateDOF(2f);
					}
				}
			}
			if (Initializing)
			{
				if (ConfirmGenderPanel.alpha == 1f)
				{
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						ConfirmGenderPanel.alpha = 0f;
						GenderSwapLabel.text = "Yes";
						CanGenderSwap = true;
					}
					else if (Input.GetButtonDown(InputNames.Xbox_B))
					{
						ConfirmGenderPanel.alpha = 0f;
					}
					return;
				}
				if (ConfirmResetPanel.alpha == 1f)
				{
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						Reset();
						NotificationManager.CustomText = "Data has been reset.";
						NotificationManager.DisplayNotification(NotificationType.Custom);
						ConfirmResetPanel.alpha = 0f;
					}
					else if (Input.GetButtonDown(InputNames.Xbox_B))
					{
						ConfirmResetPanel.alpha = 0f;
					}
					return;
				}
				StudentListPanel.alpha = Mathf.MoveTowards(StudentListPanel.alpha, 0f, Time.deltaTime * 10f);
				StudentInfoPanel.alpha = Mathf.MoveTowards(StudentInfoPanel.alpha, 0f, Time.deltaTime * 10f);
				CosmeticPanel.alpha = Mathf.MoveTowards(CosmeticPanel.alpha, 0f, Time.deltaTime * 10f);
				OpinionsPanel.alpha = Mathf.MoveTowards(OpinionsPanel.alpha, 0f, Time.deltaTime * 10f);
				InitialPanel.alpha = Mathf.MoveTowards(InitialPanel.alpha, 1f, Time.deltaTime * 10f);
				if (InputManager.TappedDown || HeldDown > 0.5f)
				{
					if (HeldDown > 0.5f)
					{
						HeldDown = 0.45f;
					}
					InitialSelected++;
					if (InitialSelected > 7)
					{
						InitialSelected = 1;
					}
				}
				if (InputManager.TappedUp || HeldUp > 0.5f)
				{
					if (HeldUp > 0.5f)
					{
						HeldUp = 0.45f;
					}
					InitialSelected--;
					if (InitialSelected < 1)
					{
						InitialSelected = 7;
					}
				}
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					if (InitialSelected == 1)
					{
						FemaleUniform++;
						if (FemaleUniform > 6)
						{
							FemaleUniform = 1;
						}
						FemaleUniformLabel.text = FemaleUniform.ToString() ?? "";
						JSON.Misc.FemaleUniform = FemaleUniform;
						StudentGlobals.FemaleUniform = FemaleUniform;
						InitialFemale.Start();
					}
					else if (InitialSelected == 2)
					{
						MaleUniform++;
						if (MaleUniform > 6)
						{
							MaleUniform = 1;
						}
						MaleUniformLabel.text = MaleUniform.ToString() ?? "";
						JSON.Misc.MaleUniform = MaleUniform;
						StudentGlobals.MaleUniform = MaleUniform;
						InitialMale.Start();
					}
					else if (InitialSelected == 3)
					{
						if (!CanGenderSwap)
						{
							ConfirmGenderPanel.alpha = 1f;
						}
						else
						{
							GenderSwapLabel.text = "No";
							CanGenderSwap = false;
						}
					}
					else if (InitialSelected == 4)
					{
						ConfirmResetPanel.alpha = 1f;
					}
					else if (InitialSelected == 5)
					{
						Load();
					}
					else if (InitialSelected == 6)
					{
						Save();
					}
					else if (InitialSelected == 7)
					{
						FadeOut = true;
					}
				}
				else if (Input.GetButtonDown(InputNames.Xbox_RB))
				{
					EnterStudentList();
				}
				InitialArrow.localPosition = new Vector3(-200f, 300 - 100 * InitialSelected, 0f);
			}
			else if (ViewingStudents)
			{
				if (ConfirmRandomPanel.alpha == 0f)
				{
					StudentListPanel.alpha = Mathf.MoveTowards(StudentListPanel.alpha, 1f, Time.deltaTime * 10f);
					StudentInfoPanel.alpha = Mathf.MoveTowards(StudentInfoPanel.alpha, 1f, Time.deltaTime * 10f);
					CosmeticPanel.alpha = Mathf.MoveTowards(CosmeticPanel.alpha, 0f, Time.deltaTime * 10f);
					OpinionsPanel.alpha = Mathf.MoveTowards(OpinionsPanel.alpha, 0f, Time.deltaTime * 10f);
					InitialPanel.alpha = Mathf.MoveTowards(InitialPanel.alpha, 0f, Time.deltaTime * 10f);
					RivalPanel.alpha = Mathf.MoveTowards(RivalPanel.alpha, 0f, Time.deltaTime * 10f);
					if (!(StudentListPanel.alpha > 0.999f))
					{
						return;
					}
					if (InputManager.TappedDown || HeldDown > 0.5f)
					{
						if (HeldDown > 0.5f)
						{
							HeldDown = 0.45f;
						}
						Selected++;
						if (Selected > 100)
						{
							StudentList.localPosition = new Vector3(0f, 0f, 0f);
							Selected = 0;
						}
						UpdateStudent();
					}
					if (InputManager.TappedUp || HeldUp > 0.5f)
					{
						if (HeldUp > 0.5f)
						{
							HeldUp = 0.45f;
						}
						Selected--;
						if (Selected < 0)
						{
							StudentList.localPosition = new Vector3(0f, 9000f, 0f);
							Selected = 100;
						}
						UpdateStudent();
					}
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						if (Selected < 98)
						{
							LabelColliders[0].enabled = true;
							LabelColliders[1].enabled = true;
							ViewingStudents = false;
							EditingStudent = true;
							EditingCosmetic = true;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Next";
							PromptBar.Label[1].text = "Previous";
							PromptBar.Label[2].text = "Zoom";
							PromptBar.Label[3].text = "Randomize";
							PromptBar.Label[4].text = "Change Selection";
							PromptBar.Label[5].text = "Rotate";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							UpdateHeader();
						}
					}
					else if (Input.GetButtonDown(InputNames.Xbox_Y))
					{
						ConfirmRandomPanel.alpha = 1f;
					}
					else if (Input.GetButtonDown(InputNames.Xbox_LB))
					{
						LabelColliders[0].enabled = false;
						LabelColliders[1].enabled = false;
						ViewingStudents = false;
						EditingStudent = false;
						Initializing = true;
						Zoom = false;
						CharacterParent.position = new Vector3(3f, -0.85f, 2.25f);
						InitialFemale.gameObject.SetActive(value: true);
						InitialMale.gameObject.SetActive(value: true);
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Select";
						PromptBar.Label[4].text = "Change Selection";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						UpdateHeader();
						UpdateDOF(2f);
					}
					else if (Input.GetButtonDown(InputNames.Xbox_RB))
					{
						LabelColliders[0].enabled = false;
						LabelColliders[1].enabled = false;
						ViewingStudents = false;
						EditingStudent = false;
						ViewingRivals = true;
						RivalSelected = 1;
						UpdateStudent();
						Zoom = false;
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Edit";
						PromptBar.Label[1].text = "Next Method";
						PromptBar.Label[2].text = "Previous Method";
						PromptBar.Label[3].text = "Randomize Methods";
						PromptBar.Label[4].text = "Change Selection";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						PopulateRivalList();
						UpdateHeader();
						UpdateDOF(2f);
					}
					Arrow.localPosition = new Vector3(-1000f, 400 - 100 * Selected, 0f);
					if (Arrow.position.y < -0.4f)
					{
						StudentList.transform.position += new Vector3(0f, 0.1f, 0f);
					}
					if (Arrow.position.y > 0.4f)
					{
						StudentList.transform.position -= new Vector3(0f, 0.1f, 0f);
					}
					StudentList.transform.localPosition = new Vector3(0f, Mathf.RoundToInt(StudentList.transform.localPosition.y), 0f);
					NameList.transform.localPosition = StudentList.transform.localPosition;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					RandomizeAll();
					string action = JSON.Students[1].ScheduleBlocks[2].action;
					NotificationManager.CustomText = "Routines: " + action;
					NotificationManager.DisplayNotification(NotificationType.Custom);
					ConfirmRandomPanel.alpha = 0f;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					ConfirmRandomPanel.alpha = 0f;
				}
			}
			else if (EditingStudent)
			{
				StudentListPanel.alpha = Mathf.MoveTowards(StudentListPanel.alpha, 0f, Time.deltaTime * 10f);
				if (!(StudentListPanel.alpha < 0.0001f))
				{
					return;
				}
				if (EditingCosmetic)
				{
					StudentInfoPanel.alpha = Mathf.MoveTowards(StudentInfoPanel.alpha, 1f, Time.deltaTime * 10f);
					CosmeticPanel.alpha = Mathf.MoveTowards(CosmeticPanel.alpha, 1f, Time.deltaTime * 10f);
					OpinionsPanel.alpha = Mathf.MoveTowards(OpinionsPanel.alpha, 0f, Time.deltaTime * 10f);
					if (InputManager.TappedDown || HeldDown > 0.5f)
					{
						if (HeldDown > 0.5f)
						{
							HeldDown = 0.45f;
						}
						CosmeticSelected++;
						if (CosmeticSelected > 9)
						{
							StudentList.localPosition = new Vector3(0f, 0f, 0f);
							CosmeticSelected = 0;
						}
					}
					if (InputManager.TappedUp || HeldUp > 0.5f)
					{
						if (HeldUp > 0.5f)
						{
							HeldUp = 0.45f;
						}
						CosmeticSelected--;
						if (CosmeticSelected < 0)
						{
							CosmeticSelected = 9;
						}
					}
					CosmeticArrow.localPosition = new Vector3(-1000f, 500 - 100 * CosmeticSelected, 0f);
					if (CosmeticArrow.position.y < -0.4f)
					{
						CosmeticPanel.transform.position += new Vector3(0f, 0.1f, 0f);
					}
					if (CosmeticArrow.position.y > 0.4f)
					{
						CosmeticPanel.transform.position -= new Vector3(0f, 0.1f, 0f);
					}
					CosmeticPanel.transform.localPosition = new Vector3(0f, Mathf.RoundToInt(CosmeticPanel.transform.localPosition.y), 0f);
					if (Input.GetButtonDown(InputNames.Xbox_A) && CosmeticWindows[CosmeticSelected].alpha == 1f)
					{
						if (CosmeticSelected == 0)
						{
							int num = int.Parse(JSON.Students[Selected].Hairstyle);
							num++;
							_ = JSON.Students[Selected].Gender;
							if (num >= HairstyleLimit)
							{
								num = 1;
							}
							JSON.Students[Selected].Hairstyle = num.ToString() ?? "";
						}
						else if (CosmeticSelected == 1)
						{
							ColorID++;
							if (ColorID >= Colors.Length)
							{
								ColorID = 0;
							}
							if (Selected == 0)
							{
								Debug.Log("Informing the ColorWheel of the player's hair renderer. Yandere.Hairstyle is " + Yandere.Hairstyle);
								Renderer renderer = Yandere.Hairstyles[Yandere.Hairstyle].GetComponent<Renderer>();
								if (renderer == null)
								{
									renderer = Yandere.Hairstyles[Yandere.Hairstyle].GetComponentInChildren<Renderer>();
								}
								if (renderer != null)
								{
									Debug.Log("YandereRenderer was not null.");
									ColorWheel.r[0] = renderer;
									ColorWheel.r[1] = renderer;
								}
								else
								{
									Debug.Log("YandereRenderer was null?!");
								}
							}
							else if (StudentGenders[Selected])
							{
								ColorWheel.r[0] = StudentKunCosmetic.MaleHairRenderers[int.Parse(JSON.Students[Selected].Hairstyle)];
								ColorWheel.r[1] = StudentKunCosmetic.MaleHairRenderers[int.Parse(JSON.Students[Selected].Hairstyle)];
							}
							else
							{
								ColorWheel.r[0] = StudentChanCosmetic.FemaleHairRenderers[int.Parse(JSON.Students[Selected].Hairstyle)];
								ColorWheel.r[1] = StudentChanCosmetic.FemaleHairRenderers[int.Parse(JSON.Students[Selected].Hairstyle)];
							}
							ColorWheel.gameObject.SetActive(ColorID == Colors.Length - 1);
							JSON.Students[Selected].Color = Colors[ColorID] ?? "";
						}
						else if (CosmeticSelected == 2)
						{
							SkinColor[Selected]++;
							if (SkinColor[Selected] >= StudentKunCosmetic.SkinTextures.Length - 1)
							{
								SkinColor[Selected] = 1;
							}
							JSON.Misc.SkinColor[Selected] = SkinColor[Selected];
							if (Selected == 1)
							{
								SenpaiGlobals.SenpaiSkinColor = SkinColor[1];
							}
						}
						else if (CosmeticSelected == 3)
						{
							EyeTypeID++;
							if (EyeTypeID >= EyeTypes.Length)
							{
								EyeTypeID = 0;
							}
							JSON.Students[Selected].EyeType = EyeTypes[EyeTypeID] ?? "";
						}
						else if (CosmeticSelected == 4)
						{
							EyeColorID++;
							if (EyeColorID >= Colors.Length)
							{
								EyeColorID = 0;
							}
							if (StudentGenders[Selected])
							{
								ColorWheel.r[0] = StudentKunCosmetic.LeftEyeRenderer;
								ColorWheel.r[1] = StudentKunCosmetic.RightEyeRenderer;
							}
							else
							{
								ColorWheel.r[0] = StudentChanCosmetic.LeftEyeRenderer;
								ColorWheel.r[1] = StudentChanCosmetic.RightEyeRenderer;
							}
							ColorWheel.gameObject.SetActive(EyeColorID == Colors.Length - 1);
							JSON.Students[Selected].Eyes = Colors[EyeColorID] ?? "";
						}
						else if (CosmeticSelected == 5)
						{
							EyeWear[Selected]++;
							if (EyeWear[Selected] >= EyewearLimit)
							{
								EyeWear[Selected] = 0;
							}
							JSON.Misc.EyeWear[Selected] = EyeWear[Selected];
						}
						else if (CosmeticSelected == 6)
						{
							int num2 = int.Parse(JSON.Students[Selected].Accessory);
							num2++;
							if (num2 >= AccessoryLimit)
							{
								num2 = 0;
							}
							JSON.Students[Selected].Accessory = num2.ToString() ?? "";
						}
						else if (CosmeticSelected == 7)
						{
							float breastSize = JSON.Students[Selected].BreastSize;
							breastSize += 0.1f;
							if (breastSize > 2f)
							{
								breastSize = 0.5f;
							}
							breastSize = Mathf.Floor(breastSize * 10f) / 10f;
							JSON.Students[Selected].BreastSize = breastSize;
						}
						else if (CosmeticSelected == 8)
						{
							StockingID++;
							if (StockingID >= StockingColors.Length)
							{
								StockingID = 0;
							}
							JSON.Students[Selected].Stockings = StockingColors[StockingID];
						}
						else if (CosmeticSelected == 9)
						{
							int num3 = AnimSet[Selected];
							num3++;
							if (Selected == 0 || JSON.Students[Selected].Gender == 0)
							{
								if (num3 >= FemaleIdles.Length)
								{
									num3 = 0;
								}
							}
							else if (num3 >= MaleIdles.Length)
							{
								num3 = 0;
							}
							AnimSet[Selected] = num3;
							JSON.Misc.AnimSet[Selected] = AnimSet[Selected];
						}
						UpdateStudent();
					}
					else if (Input.GetButtonDown(InputNames.Xbox_B) && CosmeticWindows[CosmeticSelected].alpha == 1f)
					{
						if (CosmeticSelected == 0)
						{
							int num4 = int.Parse(JSON.Students[Selected].Hairstyle);
							num4--;
							_ = JSON.Students[Selected].Gender;
							if (num4 < 1)
							{
								num4 = HairstyleLimit - 1;
							}
							JSON.Students[Selected].Hairstyle = num4.ToString() ?? "";
						}
						else if (CosmeticSelected == 1)
						{
							ColorID--;
							if (ColorID <= -1)
							{
								ColorID = Colors.Length - 1;
							}
							if (Selected == 0)
							{
								Renderer renderer2 = Yandere.Hairstyles[Yandere.Hairstyle].GetComponent<Renderer>();
								if (renderer2 == null)
								{
									renderer2 = Yandere.Hairstyles[Yandere.Hairstyle].GetComponentInChildren<Renderer>();
								}
								if (renderer2 != null)
								{
									ColorWheel.r[0] = renderer2;
									ColorWheel.r[1] = renderer2;
								}
							}
							else if (StudentGenders[Selected])
							{
								ColorWheel.r[0] = StudentKunCosmetic.MaleHairRenderers[int.Parse(JSON.Students[Selected].Hairstyle)];
								ColorWheel.r[1] = StudentKunCosmetic.MaleHairRenderers[int.Parse(JSON.Students[Selected].Hairstyle)];
							}
							else
							{
								ColorWheel.r[0] = StudentChanCosmetic.FemaleHairRenderers[int.Parse(JSON.Students[Selected].Hairstyle)];
								ColorWheel.r[1] = StudentChanCosmetic.FemaleHairRenderers[int.Parse(JSON.Students[Selected].Hairstyle)];
							}
							ColorWheel.gameObject.SetActive(ColorID == Colors.Length - 1);
							JSON.Students[Selected].Color = Colors[ColorID] ?? "";
						}
						else if (CosmeticSelected == 2)
						{
							SkinColor[Selected]--;
							if (SkinColor[Selected] <= 0)
							{
								SkinColor[Selected] = StudentKunCosmetic.SkinTextures.Length - 2;
							}
							JSON.Misc.SkinColor[Selected] = SkinColor[Selected];
							if (Selected == 1)
							{
								SenpaiGlobals.SenpaiSkinColor = SkinColor[1];
							}
						}
						else if (CosmeticSelected == 3)
						{
							EyeTypeID--;
							if (EyeTypeID <= -1)
							{
								EyeTypeID = EyeTypes.Length - 1;
							}
							JSON.Students[Selected].EyeType = EyeTypes[EyeTypeID] ?? "";
						}
						else if (CosmeticSelected == 4)
						{
							EyeColorID--;
							if (EyeColorID <= -1)
							{
								EyeColorID = Colors.Length - 1;
							}
							if (StudentGenders[Selected])
							{
								ColorWheel.r[0] = StudentKunCosmetic.LeftEyeRenderer;
								ColorWheel.r[1] = StudentKunCosmetic.RightEyeRenderer;
							}
							else
							{
								ColorWheel.r[0] = StudentChanCosmetic.LeftEyeRenderer;
								ColorWheel.r[1] = StudentChanCosmetic.RightEyeRenderer;
							}
							ColorWheel.gameObject.SetActive(EyeColorID == Colors.Length - 1);
							JSON.Students[Selected].Eyes = Colors[EyeColorID] ?? "";
						}
						else if (CosmeticSelected == 5)
						{
							EyeWear[Selected]--;
							if (EyeWear[Selected] <= -1)
							{
								EyeWear[Selected] = EyewearLimit - 1;
							}
							JSON.Misc.EyeWear[Selected] = EyeWear[Selected];
						}
						else if (CosmeticSelected == 6)
						{
							int num5 = int.Parse(JSON.Students[Selected].Accessory);
							num5--;
							if (num5 < 0)
							{
								num5 = AccessoryLimit - 1;
							}
							JSON.Students[Selected].Accessory = num5.ToString() ?? "";
						}
						else if (CosmeticSelected == 7)
						{
							float breastSize2 = JSON.Students[Selected].BreastSize;
							breastSize2 -= 0.1f;
							if (breastSize2 < 0.5f)
							{
								breastSize2 = 2f;
							}
							breastSize2 = Mathf.Floor(breastSize2 * 10f) / 10f;
							JSON.Students[Selected].BreastSize = breastSize2;
						}
						else if (CosmeticSelected == 8)
						{
							StockingID--;
							if (StockingID <= -1)
							{
								StockingID = StockingColors.Length - 1;
							}
							JSON.Students[Selected].Stockings = StockingColors[StockingID];
						}
						else if (CosmeticSelected == 9)
						{
							int num6 = AnimSet[Selected];
							num6--;
							if (Selected == 0 || JSON.Students[Selected].Gender == 0)
							{
								if (num6 < 0)
								{
									num6 = FemaleIdles.Length - 1;
								}
							}
							else if (num6 < 0)
							{
								num6 = MaleIdles.Length - 1;
							}
							AnimSet[Selected] = num6;
							JSON.Misc.AnimSet[Selected] = AnimSet[Selected];
						}
						UpdateStudent();
					}
					else if (Input.GetButtonDown(InputNames.Xbox_Y))
					{
						if (Selected == 0 || StudentChan.activeInHierarchy)
						{
							RandomizeGirl(Selected);
						}
						else
						{
							RandomizeBoy(Selected);
						}
						UpdateStudent();
					}
					else if (CanGenderSwap && !PlayerIsTyping && Selected > 0 && Input.GetKeyDown("g"))
					{
						Debug.Log("Attempting to change gender now.");
						if (Selected < 90)
						{
							if (StudentGenders[Selected])
							{
								JSON.Students[Selected].Gender = 0;
								StudentGenders[Selected] = false;
							}
							else
							{
								JSON.Students[Selected].Gender = 1;
								StudentGenders[Selected] = true;
							}
							UpdateStudent();
						}
					}
					else if (Input.GetButtonDown(InputNames.Xbox_LB))
					{
						if (!ColorWheel.gameObject.activeInHierarchy)
						{
							ColorWheel.gameObject.SetActive(value: false);
							LabelColliders[0].enabled = false;
							LabelColliders[1].enabled = false;
							ViewingStudents = true;
							EditingStudent = false;
							EditingCosmetic = false;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Edit";
							PromptBar.Label[2].text = "Zoom";
							PromptBar.Label[3].text = "Randomize All";
							PromptBar.Label[4].text = "Change Selection";
							PromptBar.Label[5].text = "Rotate";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							UpdateHeader();
						}
					}
					else if (Input.GetButtonDown(InputNames.Xbox_RB) && Selected > 0 && !ColorWheel.gameObject.activeInHierarchy)
					{
						DetailSelected = 1;
						CosmeticPanel.transform.localPosition = new Vector3(0f, -100f, 0f);
						CosmeticArrow.localPosition = new Vector3(525f, 200f, 0f);
						EditingCosmetic = false;
						EditingDetails = true;
						UpdateHeader();
					}
				}
				else if (EditingDetails)
				{
					StudentInfoPanel.alpha = Mathf.MoveTowards(StudentInfoPanel.alpha, 1f, Time.deltaTime * 10f);
					CosmeticPanel.alpha = Mathf.MoveTowards(CosmeticPanel.alpha, 1f, Time.deltaTime * 10f);
					OpinionsPanel.alpha = Mathf.MoveTowards(OpinionsPanel.alpha, 0f, Time.deltaTime * 10f);
					if (InputManager.TappedDown || HeldDown > 0.5f || InputManager.TappedUp || HeldUp > 0.5f)
					{
						if (HeldDown > 0.5f)
						{
							HeldDown = 0.45f;
						}
						if (DetailSelected == 1)
						{
							CosmeticArrow.localPosition = new Vector3(525f, 0f, 0f);
							DetailSelected = 2;
						}
						else
						{
							CosmeticArrow.localPosition = new Vector3(525f, 200f, 0f);
							DetailSelected = 1;
						}
					}
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						if (DetailSelected == 1)
						{
							JSON.Students[Selected].Persona++;
							if (JSON.Students[Selected].Persona == PersonaType.PhoneAddict)
							{
								JSON.Students[Selected].Persona++;
							}
							if (JSON.Students[Selected].Persona > PersonaType.LandlineUser)
							{
								JSON.Students[Selected].Persona = PersonaType.Loner;
							}
						}
						else if (DetailSelected == 2)
						{
							JSON.Students[Selected].Strength++;
							if (JSON.Students[Selected].Strength > 9)
							{
								JSON.Students[Selected].Strength = 0;
							}
						}
						UpdateStudent();
					}
					else if (Input.GetButtonDown(InputNames.Xbox_B))
					{
						if (DetailSelected == 1)
						{
							JSON.Students[Selected].Persona--;
							if (JSON.Students[Selected].Persona == PersonaType.PhoneAddict)
							{
								JSON.Students[Selected].Persona--;
							}
							if (JSON.Students[Selected].Persona < PersonaType.Loner)
							{
								JSON.Students[Selected].Persona = PersonaType.LandlineUser;
							}
						}
						else if (DetailSelected == 2)
						{
							JSON.Students[Selected].Strength--;
							if (JSON.Students[Selected].Strength < 0)
							{
								JSON.Students[Selected].Strength = 9;
							}
						}
						UpdateStudent();
					}
					else if (Input.GetButtonDown(InputNames.Xbox_Y))
					{
						if (StudentChan.activeInHierarchy)
						{
							RandomizeGirl(Selected);
						}
						else
						{
							RandomizeBoy(Selected);
						}
						UpdateStudent();
					}
					if (Input.GetButtonDown(InputNames.Xbox_LB))
					{
						EditingDetails = false;
						EditingCosmetic = true;
						UpdateHeader();
					}
					else if (Input.GetButtonDown(InputNames.Xbox_RB))
					{
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Like";
						PromptBar.Label[1].text = "Dislike";
						PromptBar.Label[2].text = "Neutral";
						PromptBar.Label[3].text = "Randomize";
						PromptBar.Label[4].text = "Change Row";
						PromptBar.Label[5].text = "Change Column";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						EditingDetails = false;
						EditingOpinions = true;
						Column = 1;
						Row = 1;
						UpdateOpinions();
						UpdateTopicHighlight();
						UpdateHeader();
					}
				}
				else if (EditingOpinions)
				{
					StudentInfoPanel.alpha = Mathf.MoveTowards(StudentInfoPanel.alpha, 0f, Time.deltaTime * 10f);
					SchedulePanel.alpha = Mathf.MoveTowards(SchedulePanel.alpha, 0f, Time.deltaTime * 10f);
					CosmeticPanel.alpha = Mathf.MoveTowards(CosmeticPanel.alpha, 0f, Time.deltaTime * 10f);
					OpinionsPanel.alpha = Mathf.MoveTowards(OpinionsPanel.alpha, 1f, Time.deltaTime * 10f);
					if (OpinionsPanel.alpha > 0.999f)
					{
						UpdateTopicInterface();
						if (Input.GetButtonDown(InputNames.Xbox_Y))
						{
							RandomizeOpinions(Selected);
							UpdateOpinions();
						}
						else if (Input.GetButtonDown(InputNames.Xbox_LB))
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Next";
							PromptBar.Label[1].text = "Previous";
							PromptBar.Label[2].text = "Zoom";
							PromptBar.Label[3].text = "Randomize";
							PromptBar.Label[4].text = "Change Selection";
							PromptBar.Label[5].text = "Rotate";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							EditingOpinions = false;
							EditingDetails = true;
							UpdateHeader();
						}
						else if (Input.GetButtonDown(InputNames.Xbox_RB))
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Next";
							PromptBar.Label[1].text = "Previous";
							PromptBar.Label[3].text = "Randomize";
							PromptBar.Label[4].text = "Change Row";
							PromptBar.Label[5].text = "Change Column";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							EditingOpinions = false;
							EditingSchedule = true;
							Column = 1;
							Row = 1;
							UpdateHeader();
						}
					}
				}
				else if (EditingSchedule)
				{
					LocationsPanel.alpha = Mathf.MoveTowards(LocationsPanel.alpha, 0f, Time.deltaTime * 10f);
					OpinionsPanel.alpha = Mathf.MoveTowards(OpinionsPanel.alpha, 0f, Time.deltaTime * 10f);
					SchedulePanel.alpha = Mathf.MoveTowards(SchedulePanel.alpha, 1f, Time.deltaTime * 10f);
					if (!(SchedulePanel.alpha > 0.999f))
					{
						return;
					}
					if (InputManager.TappedUp)
					{
						Row--;
						if (Row < 1)
						{
							Row = JSON.Students[Selected].ScheduleBlocks.Length - 1;
						}
					}
					else if (InputManager.TappedDown)
					{
						Row++;
						if (Row > JSON.Students[Selected].ScheduleBlocks.Length - 1)
						{
							Row = 1;
						}
					}
					if (InputManager.TappedLeft)
					{
						Column--;
						if (Column < 1)
						{
							Column = 3;
						}
					}
					else if (InputManager.TappedRight)
					{
						Column++;
						if (Column > 3)
						{
							Column = 1;
						}
					}
					int num7 = 0;
					int num8 = 0;
					if (Column == 1)
					{
						num7 = -500;
					}
					else if (Column == 2)
					{
						num7 = -200;
					}
					else if (Column == 3)
					{
						num7 = 200;
					}
					num8 = 500 - Row * 100;
					ScheduleArrow.localPosition = new Vector3(num7, num8, 0f);
					if (Column == 1)
					{
						ScheduleHelpLabel.text = TimeExplanations[Row];
					}
					else if (Column == 2)
					{
						ScheduleHelpLabel.text = "This action will cause the character to perform...\n\n" + ActionExplanations[Array.IndexOf(Actions, JSON.Students[Selected].ScheduleBlocks[Row].action)];
					}
					else if (Column == 3)
					{
						ScheduleHelpLabel.text = "This destination will cause the character to go to...\n\n" + DestinationExplanations[Array.IndexOf(Destinations, JSON.Students[Selected].ScheduleBlocks[Row].destination)];
					}
					if (Column == 2)
					{
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							int num9 = Array.IndexOf(Actions, JSON.Students[Selected].ScheduleBlocks[Row].action);
							num9++;
							if (num9 > Actions.Length - 1)
							{
								num9 = 1;
							}
							JSON.Students[Selected].ScheduleBlocks[Row].action = Actions[num9];
							ScheduleHelpLabel.text = ActionExplanations[num9];
							UpdateStudent();
						}
						else if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							int num10 = Array.IndexOf(Actions, JSON.Students[Selected].ScheduleBlocks[Row].action);
							num10--;
							if (num10 < 1)
							{
								num10 = Actions.Length - 1;
							}
							JSON.Students[Selected].ScheduleBlocks[Row].action = Actions[num10];
							ScheduleHelpLabel.text = ActionExplanations[num10];
							UpdateStudent();
						}
					}
					else if (Column == 3)
					{
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							int num11 = Array.IndexOf(Destinations, JSON.Students[Selected].ScheduleBlocks[Row].destination);
							num11++;
							if (num11 > Destinations.Length - 1)
							{
								num11 = 1;
							}
							JSON.Students[Selected].ScheduleBlocks[Row].destination = Destinations[num11];
							ScheduleHelpLabel.text = DestinationExplanations[Row];
							UpdateStudent();
						}
						else if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							int num12 = Array.IndexOf(Destinations, JSON.Students[Selected].ScheduleBlocks[Row].destination);
							num12--;
							if (num12 < 1)
							{
								num12 = Destinations.Length - 1;
							}
							JSON.Students[Selected].ScheduleBlocks[Row].destination = Destinations[num12];
							ScheduleHelpLabel.text = DestinationExplanations[Row];
							UpdateStudent();
						}
					}
					if (Input.GetButtonDown(InputNames.Xbox_Y))
					{
						RandomizeSchedule(Selected);
						UpdateStudent();
					}
					else if (Input.GetButtonDown(InputNames.Xbox_LB))
					{
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Like";
						PromptBar.Label[1].text = "Dislike";
						PromptBar.Label[2].text = "Neutral";
						PromptBar.Label[3].text = "Randomize";
						PromptBar.Label[4].text = "Change Row";
						PromptBar.Label[5].text = "Change Column";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						EditingSchedule = false;
						EditingOpinions = true;
						Column = 1;
						Row = 1;
						UpdateOpinions();
						UpdateTopicHighlight();
						UpdateHeader();
					}
					else if (Input.GetButtonDown(InputNames.Xbox_RB))
					{
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Edit";
						PromptBar.Label[1].text = "Randomize";
						PromptBar.Label[2].text = "Floor Down";
						PromptBar.Label[3].text = "Floor Up";
						PromptBar.Label[4].text = "Change Selection";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						EditingSchedule = false;
						EditingLocations = true;
						UpdateHeader();
						Map.ShowMap();
					}
				}
				else
				{
					if (!EditingLocations)
					{
						return;
					}
					LocationsPanel.alpha = Mathf.MoveTowards(LocationsPanel.alpha, 1f, Time.deltaTime * 10f);
					SchedulePanel.alpha = Mathf.MoveTowards(SchedulePanel.alpha, 0f, Time.deltaTime * 10f);
					if (InputDevice.Type == InputDeviceType.MouseAndKeyboard)
					{
						LocationInstructionLabel.text = "Use the mouse to move the map. Use the scroll wheel to zoom in and out.";
					}
					else
					{
						LocationInstructionLabel.text = "Use the left stick to move the map. Use the right stick to zoom in and out.";
					}
					if (!(LocationsPanel.alpha > 0.999f))
					{
						return;
					}
					if (UsingMenu)
					{
						if (InputManager.TappedDown || HeldDown > 0.5f)
						{
							if (HeldDown > 0.5f)
							{
								HeldDown = 0.45f;
							}
							LocationSelected++;
							if (LocationSelected > 3)
							{
								LocationSelected = 1;
							}
						}
						if (InputManager.TappedUp || HeldUp > 0.5f)
						{
							if (HeldUp > 0.5f)
							{
								HeldUp = 0.45f;
							}
							LocationSelected--;
							if (LocationSelected < 1)
							{
								LocationSelected = 3;
							}
						}
						LocationArrow.localPosition = new Vector3(-980f, 275 - 100 * LocationSelected, 0f);
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							LocationInstructionLabel.transform.parent.gameObject.SetActive(value: true);
							LocationBGs[LocationSelected].color = Color.white;
							MapShadow.material.color = new Color(0f, 0f, 0f, 0f);
							if (LocationSelected == 1)
							{
								CurrentMapIcon = HangoutIcons[Selected].GetComponent<MapIconScript>();
							}
							else if (LocationSelected == 2)
							{
								CurrentMapIcon = Patrol1Icons[Selected].GetComponent<MapIconScript>();
							}
							else if (LocationSelected == 3)
							{
								CurrentMapIcon = Patrol2Icons[Selected].GetComponent<MapIconScript>();
							}
							CurrentMapIcon.transform.parent = MapPanel.transform;
							CurrentMapIcon.transform.localPosition = new Vector3(0f, 0f, 299f);
							Map.AcceptingInput = true;
							UsingMenu = false;
							PromptBar.ClearButtons();
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[2].text = "Floor Down";
							PromptBar.Label[3].text = "Floor Up";
							PromptBar.Label[5].text = "Change Direction";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						else if (!Input.GetButtonDown(InputNames.Xbox_B) && Input.GetButtonDown(InputNames.Xbox_LB))
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Next";
							PromptBar.Label[1].text = "Previous";
							PromptBar.Label[3].text = "Randomize";
							PromptBar.Label[4].text = "Change Row";
							PromptBar.Label[5].text = "Change Column";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							EditingLocations = false;
							EditingSchedule = true;
							Column = 1;
							Row = 1;
							UpdateHeader();
							Map.HideMap();
						}
						return;
					}
					HangoutPanel.transform.position += new Vector3(1f, 0f, 0f);
					HangoutPanel.transform.position -= new Vector3(1f, 0f, 0f);
					Patrol1Panel.transform.position += new Vector3(1f, 0f, 0f);
					Patrol1Panel.transform.position -= new Vector3(1f, 0f, 0f);
					Patrol2Panel.transform.position += new Vector3(1f, 0f, 0f);
					Patrol2Panel.transform.position -= new Vector3(1f, 0f, 0f);
					if (Input.GetKey("right") || Input.GetAxis(InputNames.Xbox_DpadX) > 0.5f)
					{
						CurrentMapIcon.Rotation += 360f * Time.deltaTime;
						CurrentMapIcon.ArrowParent.localEulerAngles = new Vector3(0f, 0f, CurrentMapIcon.Rotation * -1f);
					}
					else if (Input.GetKey("left") || Input.GetAxis(InputNames.Xbox_DpadX) < -0.5f)
					{
						CurrentMapIcon.Rotation -= 360f * Time.deltaTime;
						CurrentMapIcon.ArrowParent.localEulerAngles = new Vector3(0f, 0f, CurrentMapIcon.Rotation * -1f);
					}
					if (Input.GetButtonDown(InputNames.Xbox_B))
					{
						LocationInstructionLabel.transform.parent.gameObject.SetActive(value: false);
						LocationBGs[LocationSelected].color = new Color(1f, 0.75f, 1f);
						MapShadow.material.color = new Color(0f, 0f, 0f, 0.5f);
						if (LocationSelected == 1)
						{
							HangoutIcons[Selected].transform.parent = HangoutPanel.transform;
						}
						else if (LocationSelected == 2)
						{
							Patrol1Icons[Selected].transform.parent = Patrol1Panel.transform;
						}
						else if (LocationSelected == 3)
						{
							Patrol2Icons[Selected].transform.parent = Patrol2Panel.transform;
						}
						Map.AcceptingInput = false;
						UsingMenu = true;
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Edit";
						PromptBar.Label[1].text = "Randomize";
						PromptBar.Label[2].text = "Floor Down";
						PromptBar.Label[3].text = "Floor Up";
						PromptBar.Label[4].text = "Change Selection";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
					}
				}
			}
			else if (ViewingRivals)
			{
				MiscellaneousPanel.alpha = Mathf.MoveTowards(MiscellaneousPanel.alpha, 0f, Time.deltaTime * 10f);
				StudentListPanel.alpha = Mathf.MoveTowards(StudentListPanel.alpha, 0f, Time.deltaTime * 10f);
				StudentInfoPanel.alpha = Mathf.MoveTowards(StudentInfoPanel.alpha, 0f, Time.deltaTime * 10f);
				EventPanel.alpha = Mathf.MoveTowards(EventPanel.alpha, 0f, Time.deltaTime * 10f);
				RivalPanel.alpha = Mathf.MoveTowards(RivalPanel.alpha, 1f, Time.deltaTime * 10f);
				if (!(RivalPanel.alpha > 0.999f))
				{
					return;
				}
				if (InputManager.TappedDown || HeldDown > 0.5f)
				{
					if (HeldDown > 0.5f)
					{
						HeldDown = 0.45f;
					}
					RivalSelected++;
					if (RivalSelected > 10)
					{
						RivalSelected = 1;
					}
					UpdateStudent();
				}
				if (InputManager.TappedUp || HeldUp > 0.5f)
				{
					if (HeldUp > 0.5f)
					{
						HeldUp = 0.45f;
					}
					RivalSelected--;
					if (RivalSelected < 1)
					{
						RivalSelected = 10;
					}
					UpdateStudent();
				}
				RivalArrow.localPosition = new Vector3(-1100f, 550 - 100 * RivalSelected, 0f);
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					CharacterParent.position = new Vector3(3f, -0.85f, 2.25f);
					ViewingRivals = false;
					EditingRivals = true;
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Edit";
					PromptBar.Label[4].text = "Change Selection";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					if (RivalSelected == 1)
					{
						ArrayToEdit = JSON.Misc.Week1EventLocation;
					}
					else if (RivalSelected == 2)
					{
						ArrayToEdit = JSON.Misc.Week2EventLocation;
					}
					else if (RivalSelected == 3)
					{
						ArrayToEdit = JSON.Misc.Week3EventLocation;
					}
					else if (RivalSelected == 4)
					{
						ArrayToEdit = JSON.Misc.Week4EventLocation;
					}
					else if (RivalSelected == 5)
					{
						ArrayToEdit = JSON.Misc.Week5EventLocation;
					}
					else if (RivalSelected == 6)
					{
						ArrayToEdit = JSON.Misc.Week6EventLocation;
					}
					else if (RivalSelected == 7)
					{
						ArrayToEdit = JSON.Misc.Week7EventLocation;
					}
					else if (RivalSelected == 8)
					{
						ArrayToEdit = JSON.Misc.Week8EventLocation;
					}
					else if (RivalSelected == 9)
					{
						ArrayToEdit = JSON.Misc.Week9EventLocation;
					}
					else if (RivalSelected == 10)
					{
						ArrayToEdit = JSON.Misc.Week10EventLocation;
					}
					UpdateLocationList();
					EventID = 1;
					LocationPreview.mainTexture = LocationScreenshots[ArrayToEdit[EventID]];
					UpdateHeader();
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					JSON.Misc.CanonEliminations[RivalSelected]++;
					if (JSON.Misc.CanonEliminations[RivalSelected] == 10 || JSON.Misc.CanonEliminations[RivalSelected] == 16)
					{
						JSON.Misc.CanonEliminations[RivalSelected]++;
					}
					if (JSON.Misc.CanonEliminations[RivalSelected] > EliminationNames.Length - 1)
					{
						JSON.Misc.CanonEliminations[RivalSelected] = 1;
					}
					UpdateCanonMethodLabels();
				}
				else if (Input.GetButtonDown(InputNames.Xbox_X))
				{
					JSON.Misc.CanonEliminations[RivalSelected]--;
					if (JSON.Misc.CanonEliminations[RivalSelected] == 10 || JSON.Misc.CanonEliminations[RivalSelected] == 16)
					{
						JSON.Misc.CanonEliminations[RivalSelected]--;
					}
					if (JSON.Misc.CanonEliminations[RivalSelected] < 1)
					{
						JSON.Misc.CanonEliminations[RivalSelected] = EliminationNames.Length - 1;
					}
					UpdateCanonMethodLabels();
				}
				else if (Input.GetButtonDown(InputNames.Xbox_Y))
				{
					for (int j = 1; j < 11; j++)
					{
						JSON.Misc.CanonEliminations[j] = UnityEngine.Random.Range(1, EliminationNames.Length);
						while (JSON.Misc.CanonEliminations[j] == 10 || JSON.Misc.CanonEliminations[j] == 16)
						{
							JSON.Misc.CanonEliminations[j] = UnityEngine.Random.Range(1, EliminationNames.Length);
						}
					}
					UpdateCanonMethodLabels();
				}
				else if (Input.GetButtonDown(InputNames.Xbox_LB))
				{
					EnterStudentList();
				}
				else
				{
					if (!Input.GetButtonDown(InputNames.Xbox_RB))
					{
						return;
					}
					CharacterParent.position = new Vector3(3f, -0.85f, 2.25f);
					ViewingRivals = false;
					Miscellaneous = true;
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Select";
					PromptBar.Label[4].text = "Change Selection";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					YakuzaWindow.SetActive(value: false);
					ForceYakuza = false;
					for (int k = 0; k < JSON.Misc.CanonEliminations.Length; k++)
					{
						if (JSON.Misc.CanonEliminations[k] == 20)
						{
							MiscellaneousLabels[3].text = "Yes";
							MiscellaneousOptions[3] = true;
							YakuzaWindow.SetActive(value: true);
							JSON.Misc.Misc[3] = true;
							ForceYakuza = true;
						}
					}
					UpdateHeader();
				}
			}
			else if (EditingRivals)
			{
				EventPanel.alpha = Mathf.MoveTowards(EventPanel.alpha, 1f, Time.deltaTime * 10f);
				RivalPanel.alpha = Mathf.MoveTowards(RivalPanel.alpha, 0f, Time.deltaTime * 10f);
				if (!(EventPanel.alpha > 0.999f))
				{
					return;
				}
				if (InputManager.TappedDown || HeldDown > 0.5f)
				{
					if (HeldDown > 0.5f)
					{
						HeldDown = 0.45f;
					}
					EventID++;
					if (EventID > 10)
					{
						EventID = 1;
					}
					LocationPreview.mainTexture = LocationScreenshots[ArrayToEdit[EventID]];
				}
				if (InputManager.TappedUp || HeldUp > 0.5f)
				{
					if (HeldUp > 0.5f)
					{
						HeldUp = 0.45f;
					}
					EventID--;
					if (EventID < 1)
					{
						EventID = 10;
					}
					LocationPreview.mainTexture = LocationScreenshots[ArrayToEdit[EventID]];
				}
				EventArrow.localPosition = new Vector3(-1100f, 550 - 100 * EventID, 0f);
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					ArrayToEdit[EventID]++;
					int num13 = 3;
					if (EventID % 2 != 0)
					{
						num13 = 2;
					}
					if (ArrayToEdit[EventID] > num13)
					{
						ArrayToEdit[EventID] = 1;
					}
					LocationPreview.mainTexture = LocationScreenshots[ArrayToEdit[EventID]];
					UpdateLocationList();
				}
				else if (Input.GetButtonDown(InputNames.Xbox_LB))
				{
					EditingRivals = false;
					ViewingRivals = true;
					CharacterParent.position = new Vector3(0f, -0.85f, 2.25f);
					UpdateStudent();
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Edit";
					PromptBar.Label[1].text = "Next Method";
					PromptBar.Label[2].text = "Previous Method";
					PromptBar.Label[3].text = "Randomize Methods";
					PromptBar.Label[4].text = "Change Selection";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					if (RivalSelected == 1)
					{
						JSON.Misc.Week1EventLocation = ArrayToEdit;
					}
					else if (RivalSelected == 2)
					{
						JSON.Misc.Week2EventLocation = ArrayToEdit;
					}
					else if (RivalSelected == 3)
					{
						JSON.Misc.Week3EventLocation = ArrayToEdit;
					}
					else if (RivalSelected == 4)
					{
						JSON.Misc.Week4EventLocation = ArrayToEdit;
					}
					else if (RivalSelected == 5)
					{
						JSON.Misc.Week5EventLocation = ArrayToEdit;
					}
					else if (RivalSelected == 6)
					{
						JSON.Misc.Week6EventLocation = ArrayToEdit;
					}
					else if (RivalSelected == 7)
					{
						JSON.Misc.Week7EventLocation = ArrayToEdit;
					}
					else if (RivalSelected == 8)
					{
						JSON.Misc.Week8EventLocation = ArrayToEdit;
					}
					else if (RivalSelected == 9)
					{
						JSON.Misc.Week9EventLocation = ArrayToEdit;
					}
					else if (RivalSelected == 10)
					{
						JSON.Misc.Week10EventLocation = ArrayToEdit;
					}
					UpdateHeader();
				}
			}
			else if (Miscellaneous)
			{
				MiscellaneousPanel.alpha = Mathf.MoveTowards(MiscellaneousPanel.alpha, 1f, Time.deltaTime * 10f);
				ReadyPanel.alpha = Mathf.MoveTowards(ReadyPanel.alpha, 0f, Time.deltaTime * 10f);
				RivalPanel.alpha = Mathf.MoveTowards(RivalPanel.alpha, 0f, Time.deltaTime * 10f);
				if (!(MiscellaneousPanel.alpha > 0.999f))
				{
					return;
				}
				if (InputManager.TappedDown || HeldDown > 0.5f)
				{
					if (HeldDown > 0.5f)
					{
						HeldDown = 0.45f;
					}
					OptionSelected++;
					if (OptionSelected > 5)
					{
						OptionSelected = 1;
					}
				}
				if (InputManager.TappedUp || HeldUp > 0.5f)
				{
					if (HeldUp > 0.5f)
					{
						HeldUp = 0.45f;
					}
					OptionSelected--;
					if (OptionSelected < 1)
					{
						OptionSelected = 5;
					}
				}
				MiscellaneousArrow.localPosition = new Vector3(-275f, 300 - 100 * OptionSelected, 0f);
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					if (OptionSelected == 3 && ForceYakuza)
					{
						Debug.Log("Do Nothing.");
						return;
					}
					MiscellaneousOptions[OptionSelected] = !MiscellaneousOptions[OptionSelected];
					JSON.Misc.Misc[OptionSelected] = MiscellaneousOptions[OptionSelected];
					if (MiscellaneousOptions[OptionSelected])
					{
						MiscellaneousLabels[OptionSelected].text = "Yes";
					}
					else
					{
						MiscellaneousLabels[OptionSelected].text = "No";
					}
				}
				else if (Input.GetButtonDown(InputNames.Xbox_LB))
				{
					ViewingRivals = true;
					Miscellaneous = false;
					CharacterParent.position = new Vector3(0f, -0.85f, 2.25f);
					UpdateStudent();
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Edit";
					PromptBar.Label[1].text = "Next Method";
					PromptBar.Label[2].text = "Previous Method";
					PromptBar.Label[3].text = "Randomize Methods";
					PromptBar.Label[4].text = "Change Selection";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					PopulateRivalList();
					UpdateHeader();
				}
				else if (Input.GetButtonDown(InputNames.Xbox_RB))
				{
					Miscellaneous = false;
					Finalizing = true;
					PromptBar.ClearButtons();
					PromptBar.Label[3].text = "Week Select";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					UpdateHeader();
				}
			}
			else
			{
				if (!Finalizing)
				{
					return;
				}
				MiscellaneousPanel.alpha = Mathf.MoveTowards(MiscellaneousPanel.alpha, 0f, Time.deltaTime * 10f);
				ReadyPanel.alpha = Mathf.MoveTowards(ReadyPanel.alpha, 1f, Time.deltaTime * 10f);
				if (ReadyPanel.alpha > 0.999f)
				{
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						FadeOut = true;
					}
					else if (Input.GetButtonDown(InputNames.Xbox_Y))
					{
						WeekSelect = true;
						FadeOut = true;
					}
					else if (Input.GetButtonDown(InputNames.Xbox_LB))
					{
						Miscellaneous = true;
						Finalizing = false;
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Select";
						PromptBar.Label[4].text = "Change Selection";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						UpdateHeader();
					}
				}
			}
		}
		else
		{
			if (!PlayerIsTyping || !(EditedLabel.gameObject.GetComponent<UIInputOnGUI>() == null))
			{
				return;
			}
			EditedLabel.color = Color.white;
			PlayerIsTyping = false;
			JSON.Students[Selected].Name = EditableLabels[0].text;
			JSON.Students[Selected].Info = EditableLabels[1].text;
			if (EditedLabel == EditableLabels[2])
			{
				if (int.Parse(EditableLabels[2].text) < 1)
				{
					EditableLabels[2].text = "1";
				}
				else if (int.Parse(EditableLabels[2].text) > HairstyleLimit - 1)
				{
					EditableLabels[2].text = (HairstyleLimit - 1).ToString() ?? "";
				}
				JSON.Students[Selected].Hairstyle = EditableLabels[2].text;
				Debug.Log("We are now calling UpdateStudent() from this place in the code.");
				UpdateStudent();
			}
		}
	}

	private void LateUpdate()
	{
		if (!Zoom)
		{
			base.transform.position = Vector3.zero;
			base.transform.eulerAngles = Vector3.zero;
		}
		else if (Selected == 0)
		{
			base.transform.position = ZoomTargets[0].position;
			base.transform.rotation = ZoomTargets[0].rotation;
		}
		else if (Selected == 98)
		{
			base.transform.position = ZoomTargets[3].position;
			base.transform.rotation = ZoomTargets[3].rotation;
		}
		else if (Selected == 99)
		{
			base.transform.position = ZoomTargets[4].position;
			base.transform.rotation = ZoomTargets[4].rotation;
		}
		else if (Selected == 100)
		{
			base.transform.position = ZoomTargets[5].position;
			base.transform.rotation = ZoomTargets[5].rotation;
		}
		else if (JSON.Students[Selected].Gender == 1)
		{
			base.transform.position = ZoomTargets[1].position;
			base.transform.rotation = ZoomTargets[1].rotation;
		}
		else
		{
			base.transform.position = ZoomTargets[2].position;
			base.transform.rotation = ZoomTargets[2].rotation;
		}
	}

	public void EnterStudentList()
	{
		CharacterParent.position = new Vector3(0f, -0.85f, 2.25f);
		InitialFemale.gameObject.SetActive(value: false);
		InitialMale.gameObject.SetActive(value: false);
		LabelColliders[0].enabled = false;
		LabelColliders[1].enabled = false;
		ViewingRivals = false;
		ViewingStudents = true;
		EditingStudent = false;
		Initializing = false;
		PromptBar.ClearButtons();
		PromptBar.Label[0].text = "Edit";
		PromptBar.Label[2].text = "Zoom In/Out";
		PromptBar.Label[3].text = "Randomize All";
		PromptBar.Label[4].text = "Change Selection";
		PromptBar.Label[5].text = "Rotate";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		UpdateStudent();
		UpdateHeader();
	}

	public void UpdateStudent()
	{
		CharacterParent.eulerAngles = new Vector3(15f, 180f, 0f);
		Protagonist.SetActive(value: false);
		Headmaster.SetActive(value: false);
		Journalist.SetActive(value: false);
		Counselor.SetActive(value: false);
		StudentChan.SetActive(value: false);
		StudentKun.SetActive(value: false);
		if (ViewingRivals)
		{
			Selected = RivalSelected + 10;
		}
		if (Selected == 0)
		{
			Protagonist.SetActive(value: true);
			Yandere.SetUniform();
			Yandere.CharacterAnimation.CrossFade(FemaleIdles[AnimSet[0]]);
			Yandere.Hairstyle = int.Parse(JSON.Students[0].Hairstyle);
			Yandere.UpdateHair();
			Yandere.UpdateHairColor();
			Yandere.EyeType = JSON.Students[0].EyeType;
			Yandere.UpdateEyeType();
			Yandere.EyeColor = JSON.Students[0].Eyes;
			Yandere.UpdateEyeColor();
			JSON.Misc.PlayerEyewear = EyeWear[0];
			Yandere.EyewearID = JSON.Misc.PlayerEyewear;
			Yandere.UpdateEyewear();
			Yandere.AccessoryID = int.Parse(JSON.Students[0].Accessory);
			Yandere.UpdateAccessory();
			Yandere.BreastSize = JSON.Students[0].BreastSize;
			Yandere.UpdateBust();
			Yandere.Stockings = JSON.Students[0].Stockings;
			Yandere.UpdateStockings();
			GetColorValue(JSON.Students[0].Color);
			if (Yandere.Hairstyles[Yandere.Hairstyle] != null)
			{
				Renderer renderer = Yandere.Hairstyles[Yandere.Hairstyle].GetComponent<Renderer>();
				if (renderer == null)
				{
					renderer = Yandere.Hairstyles[Yandere.Hairstyle].GetComponentInChildren<Renderer>();
				}
				if (renderer != null)
				{
					renderer.material.shader = StudentChanCosmetic.StartShader;
					if (JSON.Students[0].Color == "Default")
					{
						renderer.material.SetFloat("_Saturation", 1f);
					}
					else
					{
						renderer.material.SetFloat("_Saturation", 0f);
					}
					renderer.material.color = ColorValue;
				}
			}
		}
		else if (Selected == 98)
		{
			Counselor.SetActive(value: true);
		}
		else if (Selected == 99)
		{
			Headmaster.SetActive(value: true);
		}
		else if (Selected == 100)
		{
			Journalist.SetActive(value: true);
		}
		else if (StudentGenders[Selected])
		{
			if (AnimSet[Selected] >= MaleIdles.Length)
			{
				AnimSet[Selected] = 0;
			}
			StudentKun.SetActive(value: true);
			StudentKunCosmetic.Armband.SetActive(value: false);
			StudentKunCosmetic.Initialized = false;
			StudentKunCosmetic.StudentID = Selected;
			StudentKunCosmetic.SkinColor = SkinColor[Selected];
			StudentKunCosmetic.EyewearID = EyeWear[Selected];
			StudentKunCosmetic.Start();
			StudentKunCosmetic.CharacterAnimation.CrossFade(MaleIdles[AnimSet[Selected]]);
		}
		else
		{
			if (AnimSet[Selected] >= FemaleIdles.Length)
			{
				AnimSet[Selected] = 0;
			}
			StudentChanCosmetic.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			StudentChanCosmetic.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			StudentChanCosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			StudentChanCosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			if (StudentChanCosmetic.MyRenderer.materials.Length > 2)
			{
				StudentChanCosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
				StudentChanCosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
			}
			if (StudentChanCosmetic.MyRenderer.sharedMesh.blendShapeCount > 0)
			{
				StudentChanCosmetic.ResetBlendshapes();
			}
			StudentChan.SetActive(value: true);
			if (StudentChanCosmetic.Student.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
			{
				StudentChanCosmetic.Student.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.enabled = false;
			}
			StudentChanCosmetic.MyRenderer.materials = StudentChanCosmetic.DefaultMaterials;
			StudentChanCosmetic.MyRenderer.enabled = true;
			StudentChanCosmetic.Armband.SetActive(value: false);
			StudentChanCosmetic.StudentID = Selected;
			StudentChanCosmetic.Initialized = false;
			StudentChanCosmetic.MyStockings = null;
			StudentChanCosmetic.Teacher = false;
			StudentChanCosmetic.Start();
			if (Selected > 90 && Selected < 97 && StudentChanCosmetic.Student.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
			{
				StudentChanCosmetic.Student.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.enabled = true;
			}
			StudentChanCosmetic.CharacterAnimation.CrossFade(FemaleIdles[AnimSet[Selected]]);
		}
		if (Selected > 0)
		{
			string text = JSON.Students[Selected].Class.ToString();
			text = ((text.Length > 1) ? ((Selected >= 90) ? ("Class " + text[0] + "-" + text[1]) : ("Class " + text[0] + "-" + text[1] + ", Seat " + JSON.Students[Selected].Seat)) : ((Selected >= 100) ? "Journalist" : "Faculty"));
			string text2 = "";
			text2 = ((JSON.Students[Selected].Crush != 0) ? JSON.Students[JSON.Students[Selected].Crush].Name : "None");
			string text3 = "Club: ";
			if (Selected > 89 && Selected < 98)
			{
				text3 = "Job: ";
			}
			text3 = ((Selected >= 98) ? ("Job: " + DescText[Selected]) : (text3 + JSON.Students[Selected].Club));
			NameLabel.text = JSON.Students[Selected].Name;
			ClassLabel.text = text;
			ClubLabel.text = text3;
			PersonaLabel.text = "Persona: " + PersonaNames[(int)JSON.Students[Selected].Persona];
			CrushLabel.text = "Crush: " + text2;
			StrengthLabel.text = "Strength: " + StrengthNames[JSON.Students[Selected].Strength];
			InfoLabel.text = JSON.Students[Selected].Info;
		}
		else
		{
			NameLabel.text = JSON.Students[Selected].Name;
			ClassLabel.text = "Class 2-1, Seat 13";
			ClubLabel.text = "Club: None";
			PersonaLabel.text = "Persona: Yandere";
			CrushLabel.text = "Crush: " + JSON.Students[1].Name;
			StrengthLabel.text = "Strength: Lethal";
			InfoLabel.text = JSON.Students[Selected].Info;
		}
		ColorID = DetermineColorID(JSON.Students[Selected].Color);
		EyeColorID = DetermineColorID(JSON.Students[Selected].Eyes);
		EyeTypeID = DetermineEyeTypeID(JSON.Students[Selected].EyeType);
		StockingID = DetermineStockingID(JSON.Students[Selected].Stockings);
		UpdateCosmeticLabels(Selected);
		if (Selected > 0)
		{
			UpdateScheduleLabels(Selected);
		}
		if (ViewingStudents)
		{
			if (Selected > 97)
			{
				PromptBar.Label[0].text = "";
			}
			else
			{
				PromptBar.Label[0].text = "Edit";
			}
			PromptBar.UpdateButtons();
		}
	}

	public void RandomizeAll()
	{
		int maleUniform = (StudentGlobals.FemaleUniform = UnityEngine.Random.Range(1, 7));
		StudentGlobals.MaleUniform = maleUniform;
		FemaleUniform = StudentGlobals.FemaleUniform;
		MaleUniform = StudentGlobals.MaleUniform;
		FemaleUniformLabel.text = FemaleUniform.ToString() ?? "";
		MaleUniformLabel.text = MaleUniform.ToString() ?? "";
		JSON.Misc.FemaleUniform = FemaleUniform;
		JSON.Misc.MaleUniform = MaleUniform;
		InitialFemale.Start();
		InitialMale.Start();
		for (maleUniform = 1; maleUniform < 101; maleUniform++)
		{
			UsedSurnames[maleUniform] = false;
			UsedMaleNames[maleUniform] = false;
			UsedFemaleNames[maleUniform] = false;
			UsedMaleHairs[maleUniform] = false;
			UsedFemaleHairs[maleUniform] = false;
			UsedTeacherHairs[maleUniform] = false;
		}
		UsedFemaleHairs[20] = true;
		for (maleUniform = 0; maleUniform < 98; maleUniform++)
		{
			if (maleUniform == 0 || JSON.Students[maleUniform].Gender == 0)
			{
				RandomizeGirl(maleUniform);
			}
			else
			{
				RandomizeBoy(maleUniform);
			}
		}
		UpdateStudent();
	}

	private void RandomizeGirl(int ID)
	{
		if (ID > 0)
		{
			UsedFemaleHairs[int.Parse(JSON.Students[ID].Hairstyle)] = false;
		}
		int num = 0;
		int num2 = 0;
		while (UsedFemaleNames[num2] && num < 100)
		{
			num2 = UnityEngine.Random.Range(1, FemaleNames.Length);
			num++;
		}
		UsedFemaleNames[num2] = true;
		num = 0;
		int num3 = 0;
		while (UsedSurnames[num3] && num < 100)
		{
			num3 = UnityEngine.Random.Range(1, Surnames.Length);
			num++;
		}
		UsedSurnames[num3] = true;
		JSON.Students[ID].Name = FemaleNames[num2] + " " + Surnames[num3];
		int num4 = 0;
		if (ID > 89 && ID < 98)
		{
			num = 0;
			while (UsedTeacherHairs[num4] && num < 100)
			{
				num4 = UnityEngine.Random.Range(1, StudentChanCosmetic.TeacherHair.Length);
				num++;
			}
			UsedTeacherHairs[num4] = true;
			JSON.Students[ID].BreastSize = UnityEngine.Random.Range(0.5f, 1.3f);
		}
		else
		{
			JSON.Students[ID].Stockings = StockingColors[UnityEngine.Random.Range(0, StockingColors.Length)];
			if (ID > 0)
			{
				num = 0;
				while (UsedFemaleHairs[num4] && num < 100)
				{
					num4 = UnityEngine.Random.Range(1, StudentChanCosmetic.FemaleHair.Length);
					num++;
				}
				UsedFemaleHairs[num4] = true;
				JSON.Students[ID].Accessory = UnityEngine.Random.Range(0, StudentChanCosmetic.FemaleAccessories.Length).ToString() ?? "";
			}
			else
			{
				num4 = UnityEngine.Random.Range(0, Yandere.Hairstyles.Length);
				JSON.Students[ID].Accessory = "0";
			}
			JSON.Students[ID].BreastSize = UnityEngine.Random.Range(0.5f, 2f);
		}
		JSON.Students[ID].BreastSize = Mathf.Round(JSON.Students[ID].BreastSize * 10f) * 0.1f;
		JSON.Students[ID].Hairstyle = num4.ToString() ?? "";
		AnimSet[ID] = UnityEngine.Random.Range(0, FemaleIdles.Length - 2);
		JSON.Misc.SkinColor[ID] = SkinColor[ID];
		JSON.Misc.AnimSet[ID] = AnimSet[ID];
		JSON.Misc.EyeWear[ID] = EyeWear[ID];
		RandomizeMisc(ID);
		RandomizeOpinions(ID);
		RandomizeSchedule(ID);
	}

	private void RandomizeBoy(int ID)
	{
		int num = 0;
		int num2 = 0;
		while (UsedMaleNames[num2] && num < 100)
		{
			num2 = UnityEngine.Random.Range(1, MaleNames.Length);
			num++;
		}
		UsedMaleNames[num2] = true;
		num = 0;
		int num3 = 0;
		while (UsedSurnames[num3] && num < 100)
		{
			num3 = UnityEngine.Random.Range(1, Surnames.Length);
			num++;
		}
		UsedSurnames[num3] = true;
		JSON.Students[ID].Name = MaleNames[num2] + " " + Surnames[num3];
		num = 0;
		int num4 = 0;
		while (UsedMaleHairs[num4] && num < 100)
		{
			num4 = UnityEngine.Random.Range(1, StudentKunCosmetic.MaleHair.Length);
			num++;
		}
		UsedMaleHairs[num4] = true;
		JSON.Students[ID].Hairstyle = num4.ToString() ?? "";
		JSON.Students[ID].Accessory = UnityEngine.Random.Range(0, StudentKunCosmetic.MaleAccessories.Length).ToString() ?? "";
		SkinColor[ID] = UnityEngine.Random.Range(1, StudentKunCosmetic.SkinTextures.Length - 1);
		AnimSet[ID] = UnityEngine.Random.Range(0, MaleIdles.Length);
		JSON.Misc.SkinColor[ID] = SkinColor[ID];
		JSON.Misc.AnimSet[ID] = AnimSet[ID];
		JSON.Misc.EyeWear[ID] = EyeWear[ID];
		if (ID == 1)
		{
			SenpaiGlobals.SenpaiSkinColor = SkinColor[1];
		}
		RandomizeMisc(ID);
		RandomizeOpinions(ID);
		RandomizeSchedule(ID);
	}

	private void RandomizeMisc(int ID)
	{
		JSON.Students[ID].Persona = (PersonaType)UnityEngine.Random.Range(1, 18);
		JSON.Students[ID].Strength = UnityEngine.Random.Range(0, 10);
		JSON.Students[ID].Color = "Custom";
		JSON.Students[ID].Eyes = "Custom";
		JSON.Students[ID].EyeType = EyeTypes[UnityEngine.Random.Range(0, EyeTypes.Length)];
		JSON.Students[ID].HairR = UnityEngine.Random.Range(0, 256);
		JSON.Students[ID].HairG = UnityEngine.Random.Range(0, 256);
		JSON.Students[ID].HairB = UnityEngine.Random.Range(0, 256);
		JSON.Students[ID].EyeR = UnityEngine.Random.Range(0, 256);
		JSON.Students[ID].EyeG = UnityEngine.Random.Range(0, 256);
		JSON.Students[ID].EyeB = UnityEngine.Random.Range(0, 256);
		EyeWear[ID] = 0;
	}

	private void RandomizeOpinions(int ID)
	{
		if (ID <= 0)
		{
			return;
		}
		int i = 1;
		int num = 0;
		int num2 = 0;
		for (; i < 26; i++)
		{
			JSON.Topics[ID].Topics[i] = 0;
		}
		while (num < 5)
		{
			int num3 = UnityEngine.Random.RandomRange(1, 26);
			if (JSON.Topics[ID].Topics[num3] == 0)
			{
				JSON.Topics[ID].Topics[num3] = 2;
				num++;
			}
		}
		while (num2 < 5)
		{
			int num4 = UnityEngine.Random.RandomRange(1, 26);
			if (JSON.Topics[ID].Topics[num4] == 0)
			{
				JSON.Topics[ID].Topics[num4] = 1;
				num2++;
			}
		}
	}

	private void RandomizeSchedule(int ID)
	{
		if (ID <= 0)
		{
			return;
		}
		string text = "CustomHangout";
		if (JSON.Students[ID].ScheduleBlocks[2].action == "CustomHangout")
		{
			text = "CustomPatrol";
		}
		else if (JSON.Students[ID].ScheduleBlocks[2].action == "CustomPatrol")
		{
			text = "RandomPatrol";
		}
		else if (JSON.Students[ID].ScheduleBlocks[2].action == "RandomPatrol")
		{
			text = "CustomHangout";
		}
		JSON.Students[ID].ScheduleBlocks[2].action = text;
		JSON.Students[ID].ScheduleBlocks[2].destination = text;
		JSON.Students[ID].ScheduleBlocks[4].action = text;
		JSON.Students[ID].ScheduleBlocks[4].destination = text;
		JSON.Students[ID].ScheduleBlocks[6].action = text;
		JSON.Students[ID].ScheduleBlocks[6].destination = text;
		if (JSON.Students[ID].ScheduleBlocks.Length > 7)
		{
			JSON.Students[ID].ScheduleBlocks[7].action = text;
			JSON.Students[ID].ScheduleBlocks[7].destination = text;
			if (JSON.Students[ID].ScheduleBlocks.Length > 8)
			{
				JSON.Students[ID].ScheduleBlocks[8].action = text;
				JSON.Students[ID].ScheduleBlocks[8].destination = text;
				if (JSON.Students[ID].ScheduleBlocks.Length > 9)
				{
					JSON.Students[ID].ScheduleBlocks[9].action = text;
					JSON.Students[ID].ScheduleBlocks[9].destination = text;
				}
			}
		}
		switch (ID)
		{
		case 1:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
			JSON.Students[ID].ScheduleBlocks[4].action = "Eat";
			JSON.Students[ID].ScheduleBlocks[4].destination = "LunchSpot";
			JSON.Students[ID].ScheduleBlocks[8].action = "Shoes";
			JSON.Students[ID].ScheduleBlocks[8].destination = "Locker";
			JSON.Students[ID].ScheduleBlocks[9].action = "Stand";
			JSON.Students[ID].ScheduleBlocks[9].destination = "Exit";
			break;
		}
		if (ID > 21 && ID < 73)
		{
			string text2 = ID.ToString();
			if (text2.EndsWith("2") || text2.EndsWith("7"))
			{
				int num = JSON.Students[ID].ScheduleBlocks.Length;
				JSON.Students[ID].ScheduleBlocks[num - 2].action = "Shoes";
				JSON.Students[ID].ScheduleBlocks[num - 2].destination = "Locker";
				JSON.Students[ID].ScheduleBlocks[num - 1].action = "Stand";
				JSON.Students[ID].ScheduleBlocks[num - 1].destination = "Exit";
			}
		}
	}

	private void UpdateCosmeticLabels(int ID)
	{
		if (Selected == 0)
		{
			HairstyleLimit = Yandere.Hairstyles.Length;
			AccessoryLimit = Yandere.Accessories.Length;
			EyewearLimit = 5;
		}
		else
		{
			if (JSON.Students[ID].Gender == 0)
			{
				if (ID > 89 && ID < 98)
				{
					HairstyleLimit = StudentChanCosmetic.TeacherHair.Length;
					AccessoryLimit = StudentChanCosmetic.TeacherAccessories.Length;
				}
				else
				{
					HairstyleLimit = StudentChanCosmetic.FemaleHair.Length;
					AccessoryLimit = StudentChanCosmetic.FemaleAccessories.Length;
				}
			}
			else
			{
				HairstyleLimit = StudentKunCosmetic.MaleHair.Length;
				AccessoryLimit = StudentKunCosmetic.MaleAccessories.Length;
			}
			EyewearLimit = StudentKunCosmetic.Eyewear.Length;
		}
		CosmeticLabels[0].text = JSON.Students[ID].Hairstyle;
		CosmeticLabels[1].text = JSON.Students[ID].Color;
		CosmeticLabels[2].text = SkinColor[ID].ToString() ?? "";
		CosmeticLabels[3].text = JSON.Students[ID].EyeType;
		CosmeticLabels[4].text = JSON.Students[ID].Eyes;
		CosmeticLabels[5].text = EyeWear[ID].ToString() ?? "";
		CosmeticLabels[6].text = JSON.Students[ID].Accessory;
		CosmeticLabels[7].text = JSON.Students[ID].BreastSize.ToString() ?? "";
		CosmeticLabels[8].text = JSON.Students[ID].Stockings;
		CosmeticLabels[9].text = AnimSet[ID].ToString() ?? "";
		if (JSON.Students[ID].Gender == 1)
		{
			CosmeticWindows[2].alpha = 1f;
			CosmeticBubbles[2].alpha = 1f;
			CosmeticWindows[3].alpha = 0.5f;
			CosmeticBubbles[3].alpha = 0.5f;
			CosmeticWindows[5].alpha = 1f;
			CosmeticBubbles[5].alpha = 1f;
			CosmeticWindows[7].alpha = 0.5f;
			CosmeticBubbles[7].alpha = 0.5f;
			CosmeticWindows[8].alpha = 0.5f;
			CosmeticBubbles[8].alpha = 0.5f;
			return;
		}
		CosmeticWindows[2].alpha = 0.5f;
		CosmeticBubbles[2].alpha = 0.5f;
		CosmeticWindows[3].alpha = 1f;
		CosmeticBubbles[3].alpha = 1f;
		CosmeticWindows[5].alpha = 0.5f;
		CosmeticBubbles[5].alpha = 0.5f;
		CosmeticWindows[7].alpha = 1f;
		CosmeticBubbles[7].alpha = 1f;
		CosmeticWindows[8].alpha = 1f;
		CosmeticBubbles[8].alpha = 1f;
		if (ID == 0)
		{
			CosmeticWindows[5].alpha = 1f;
			CosmeticBubbles[5].alpha = 1f;
		}
		else if (ID > 89)
		{
			CosmeticWindows[8].alpha = 0.5f;
			CosmeticBubbles[8].alpha = 0.5f;
		}
	}

	private void GetColorValue(string HairColor)
	{
		switch (HairColor)
		{
		case "Default":
		case "White":
			ColorValue = new Color(1f, 1f, 1f);
			break;
		case "Black":
			ColorValue = new Color(0.5f, 0.5f, 0.5f);
			break;
		case "SolidBlack":
			ColorValue = new Color(0.0001f, 0.0001f, 0.0001f);
			break;
		case "Red":
			ColorValue = new Color(1f, 0f, 0f);
			break;
		case "Yellow":
			ColorValue = new Color(1f, 1f, 0f);
			break;
		case "Green":
			ColorValue = new Color(0f, 1f, 0f);
			break;
		case "Cyan":
			ColorValue = new Color(0f, 1f, 1f);
			break;
		case "Blue":
			ColorValue = new Color(0f, 0f, 1f);
			break;
		case "Purple":
			ColorValue = new Color(1f, 0f, 1f);
			break;
		case "Orange":
			ColorValue = new Color(1f, 0.5f, 0f);
			break;
		case "Brown":
			ColorValue = new Color(0.5f, 0.25f, 0f);
			break;
		case "Custom":
			Debug.Log("Protagonist's HairColor is ''Custom''.");
			ColorValue = new Color((float)StudentManager.JSON.Students[0].HairR * 1f / 255f, (float)StudentManager.JSON.Students[0].HairG * 1f / 255f, (float)StudentManager.JSON.Students[0].HairB * 1f / 255f);
			break;
		}
	}

	public int DetermineColorID(string HairColor)
	{
		return HairColor switch
		{
			"Default" => 0, 
			"White" => 1, 
			"Black" => 2, 
			"Red" => 3, 
			"Yellow" => 4, 
			"Green" => 5, 
			"Cyan" => 6, 
			"Blue" => 7, 
			"Purple" => 8, 
			"Orange" => 9, 
			"Brown" => 10, 
			"Custom" => 11, 
			_ => 0, 
		};
	}

	public int DetermineEyeTypeID(string EyeType)
	{
		return EyeType switch
		{
			"Default" => 0, 
			"Thin" => 1, 
			"Serious" => 2, 
			"Round" => 3, 
			"Sad" => 4, 
			"Mean" => 5, 
			"Smug" => 6, 
			"Gentle" => 7, 
			"MO" => 8, 
			"Eighties1" => 9, 
			"Eighties2" => 10, 
			"Eighties3" => 11, 
			"Eighties4" => 12, 
			"Eighties5" => 13, 
			"Eighties6" => 14, 
			"Eighties7" => 15, 
			"Eighties8" => 16, 
			"Eighties9" => 17, 
			"Eighties10" => 18, 
			"Witness" => 19, 
			"Rival1" => 20, 
			"Ayano" => 21, 
			"Ryoba" => 22, 
			"Chill" => 23, 
			"Sweet" => 24, 
			"Reserved" => 25, 
			"Mature" => 26, 
			"Sharp" => 27, 
			"Relaxed" => 28, 
			"Friendly" => 29, 
			"Timid" => 30, 
			"Sneer" => 31, 
			"Innocent" => 32, 
			"ThinGentle" => 33, 
			"Seductive" => 34, 
			"Rival2" => 35, 
			"Succubus" => 36, 
			"Vampire" => 37, 
			_ => 0, 
		};
	}

	public int DetermineStockingID(string StockingName)
	{
		bool flag = false;
		for (int i = 1; i < StockingColors.Length; i++)
		{
			if (flag)
			{
				break;
			}
			if (StockingName == StockingColors[i])
			{
				flag = true;
				return i;
			}
		}
		return 0;
	}

	public void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
		UpdateAperture(5.6f);
	}

	public float GetDOF()
	{
		return Profile.depthOfField.settings.focusDistance;
	}

	public void UpdateAperture(float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		float num = (float)Screen.width / 1280f;
		settings.aperture = Aperture * num;
		settings.focalLength = 50f;
		Profile.depthOfField.settings = settings;
	}

	public void Reset()
	{
		for (int i = 0; i < 101; i++)
		{
			AnimSet[i] = 0;
			SkinColor[i] = 0;
			EyeWear[i] = 0;
		}
		JSON.Start();
		Yandere.SetUniform();
		Yandere.BecomeRyoba();
		for (int j = 1; j < 90; j++)
		{
			if (JSON.Students[j].Gender == 1)
			{
				StudentGenders[j] = true;
			}
			else
			{
				StudentGenders[j] = false;
			}
		}
		for (int i = 1; i < 101; i++)
		{
			if (JSON.Students[i].Gender == 1)
			{
				StudentGenders[i] = true;
				SkinColor[i] = 3;
			}
		}
		for (int i = 1; i < 101; i++)
		{
			if (JSON.Students[i].Gender == 1)
			{
				StudentGenders[i] = true;
				SkinColor[i] = 3;
			}
		}
		StudentGlobals.FemaleUniform = 6;
		StudentGlobals.MaleUniform = 1;
		FemaleUniform = 6;
		MaleUniform = 1;
		JSON.Misc.FemaleUniform = 6;
		JSON.Misc.MaleUniform = 1;
		InitialFemale.Start();
		InitialMale.Start();
		FemaleUniformLabel.text = FemaleUniform.ToString() ?? "";
		MaleUniformLabel.text = MaleUniform.ToString() ?? "";
		AnimSet[0] = 1;
		SkinColor[1] = 3;
		SenpaiGlobals.SenpaiSkinColor = SkinColor[1];
		SkinColor[87] = 7;
		AnimSet[11] = 6;
		AnimSet[12] = 3;
		AnimSet[13] = 11;
		AnimSet[14] = 9;
		AnimSet[15] = 8;
		AnimSet[16] = 2;
		AnimSet[17] = 16;
		AnimSet[18] = 7;
		AnimSet[19] = 5;
		AnimSet[20] = 4;
		JSON.Misc.AnimSet = AnimSet;
		MiscellaneousLabels[1].text = "No";
		MiscellaneousLabels[2].text = "No";
		MiscellaneousLabels[3].text = "No";
		MiscellaneousLabels[4].text = "No";
		MiscellaneousLabels[5].text = "No";
		MiscellaneousOptions[1] = false;
		MiscellaneousOptions[2] = false;
		MiscellaneousOptions[3] = false;
		MiscellaneousOptions[4] = false;
		MiscellaneousOptions[5] = false;
		JSON.Misc.Misc[1] = false;
		JSON.Misc.Misc[2] = false;
		JSON.Misc.Misc[3] = false;
		JSON.Misc.Misc[4] = false;
		JSON.Misc.Misc[5] = false;
		JSON.Misc.CanonEliminations[1] = 18;
		JSON.Misc.CanonEliminations[2] = 5;
		JSON.Misc.CanonEliminations[3] = 6;
		JSON.Misc.CanonEliminations[4] = 15;
		JSON.Misc.CanonEliminations[5] = 7;
		JSON.Misc.CanonEliminations[6] = 8;
		JSON.Misc.CanonEliminations[7] = 9;
		JSON.Misc.CanonEliminations[8] = 4;
		JSON.Misc.CanonEliminations[9] = 13;
		JSON.Misc.CanonEliminations[10] = 2;
		UpdateCanonMethodLabels();
		ResetAllCustomLocations();
		ResetAllEventLocations();
		JSON.Students[0].Name = "Ryoba Aishi";
		JSON.Students[0].Class = 21;
		JSON.Students[0].Seat = 13;
		JSON.Students[0].Crush = 1;
		JSON.Students[0].Hairstyle = 203.ToString() ?? "";
		JSON.Students[0].Accessory = "0";
		JSON.Students[0].Color = "Default";
		JSON.Students[0].EyeType = "Ryoba";
		JSON.Students[0].Eyes = "Default";
		JSON.Students[0].BreastSize = 1.5f;
		JSON.Students[0].Stockings = "Black";
		JSON.Students[0].Info = "A young woman who is willing to do absolutely anything in order to prevent the boy she loves from entering a relationship with anyone other than herself.";
		UpdateStudent();
	}

	public void ResetAllCustomLocations()
	{
		for (int i = 1; i < 101; i++)
		{
			JSON.Misc.HangoutPosX[i] = 0f;
			JSON.Misc.HangoutPosY[i] = 0f;
			JSON.Misc.HangoutPosZ[i] = 0f;
			JSON.Misc.HangoutRotX[i] = 0f;
			JSON.Misc.HangoutRotY[i] = 0f;
			JSON.Misc.HangoutRotZ[i] = 0f;
			JSON.Misc.Patrol1PosX[i] = 0f;
			JSON.Misc.Patrol1PosY[i] = 0f;
			JSON.Misc.Patrol1PosZ[i] = 0f;
			JSON.Misc.Patrol1RotX[i] = 0f;
			JSON.Misc.Patrol1RotY[i] = 0f;
			JSON.Misc.Patrol1RotZ[i] = 0f;
			JSON.Misc.Patrol2PosX[i] = 0f;
			JSON.Misc.Patrol2PosY[i] = 0f;
			JSON.Misc.Patrol2PosZ[i] = 0f;
			JSON.Misc.Patrol2RotX[i] = 0f;
			JSON.Misc.Patrol2RotY[i] = 0f;
			JSON.Misc.Patrol2RotZ[i] = 0f;
		}
		LoadAllCustomLocations();
	}

	public void SaveAllCustomLocations()
	{
		for (int i = 1; i < 101; i++)
		{
			JSON.Misc.HangoutPosX[i] = HangoutIcons[i].localPosition.x;
			JSON.Misc.HangoutPosY[i] = HangoutIcons[i].localPosition.y;
			JSON.Misc.HangoutPosZ[i] = HangoutIcons[i].localPosition.z;
			JSON.Misc.HangoutRotX[i] = HangoutIcons[i].GetComponent<MapIconScript>().ArrowParent.localEulerAngles.x;
			JSON.Misc.HangoutRotY[i] = HangoutIcons[i].GetComponent<MapIconScript>().ArrowParent.localEulerAngles.y;
			JSON.Misc.HangoutRotZ[i] = HangoutIcons[i].GetComponent<MapIconScript>().Rotation;
			if (JSON.Misc.HangoutRotZ[i] > 180f)
			{
				JSON.Misc.HangoutRotZ[i] = (360f - JSON.Misc.HangoutRotZ[i]) * -1f;
			}
			JSON.Misc.Patrol1PosX[i] = Patrol1Icons[i].localPosition.x;
			JSON.Misc.Patrol1PosY[i] = Patrol1Icons[i].localPosition.y;
			JSON.Misc.Patrol1PosZ[i] = Patrol1Icons[i].localPosition.z;
			JSON.Misc.Patrol1RotX[i] = Patrol1Icons[i].GetComponent<MapIconScript>().ArrowParent.localEulerAngles.x;
			JSON.Misc.Patrol1RotY[i] = Patrol1Icons[i].GetComponent<MapIconScript>().ArrowParent.localEulerAngles.y;
			JSON.Misc.Patrol1RotZ[i] = Patrol1Icons[i].GetComponent<MapIconScript>().Rotation;
			JSON.Misc.Patrol2PosX[i] = Patrol2Icons[i].localPosition.x;
			JSON.Misc.Patrol2PosY[i] = Patrol2Icons[i].localPosition.y;
			JSON.Misc.Patrol2PosZ[i] = Patrol2Icons[i].localPosition.z;
			JSON.Misc.Patrol2RotX[i] = Patrol2Icons[i].GetComponent<MapIconScript>().ArrowParent.localEulerAngles.x;
			JSON.Misc.Patrol2RotY[i] = Patrol2Icons[i].GetComponent<MapIconScript>().ArrowParent.localEulerAngles.y;
			JSON.Misc.Patrol2RotZ[i] = Patrol2Icons[i].GetComponent<MapIconScript>().Rotation;
		}
	}

	public void LoadAllCustomLocations()
	{
		for (int i = 1; i < 101; i++)
		{
			MapIconScript component = HangoutIcons[i].GetComponent<MapIconScript>();
			HangoutIcons[i].localPosition = new Vector3(JSON.Misc.HangoutPosX[i], JSON.Misc.HangoutPosY[i], JSON.Misc.HangoutPosZ[i]);
			component.Rotation = JSON.Misc.HangoutRotZ[i];
			component.ArrowParent.localEulerAngles = new Vector3(0f, 0f, component.Rotation * -1f);
			component = Patrol1Icons[i].GetComponent<MapIconScript>();
			Patrol1Icons[i].localPosition = new Vector3(JSON.Misc.Patrol1PosX[i], JSON.Misc.Patrol1PosY[i], JSON.Misc.Patrol1PosZ[i]);
			component.Rotation = JSON.Misc.Patrol1RotZ[i];
			component.ArrowParent.localEulerAngles = new Vector3(0f, 0f, component.Rotation * -1f);
			component = Patrol2Icons[i].GetComponent<MapIconScript>();
			Patrol2Icons[i].localPosition = new Vector3(JSON.Misc.Patrol2PosX[i], JSON.Misc.Patrol2PosY[i], JSON.Misc.Patrol2PosZ[i]);
			component.Rotation = JSON.Misc.Patrol2RotZ[i];
			component.ArrowParent.localEulerAngles = new Vector3(0f, 0f, component.Rotation * -1f);
		}
	}

	public void TranslateIntoWorldSpace()
	{
		int num = 1;
		if (!(HangoutIcons[num].localPosition.y < 400f) && !(HangoutIcons[num].localPosition.y < 800f))
		{
			_ = HangoutIcons[num].localPosition.y;
			_ = 1200f;
		}
	}

	public void ResetAllEventLocations()
	{
		JSON.Misc.Week1EventLocation[1] = 1;
		JSON.Misc.Week1EventLocation[2] = 2;
		JSON.Misc.Week1EventLocation[3] = 1;
		JSON.Misc.Week1EventLocation[4] = 2;
		JSON.Misc.Week1EventLocation[5] = 1;
		JSON.Misc.Week1EventLocation[6] = 3;
		JSON.Misc.Week1EventLocation[7] = 1;
		JSON.Misc.Week1EventLocation[8] = 2;
		JSON.Misc.Week1EventLocation[9] = 1;
		JSON.Misc.Week1EventLocation[10] = 3;
		JSON.Misc.Week2EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week3EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week4EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week5EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week6EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week7EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week8EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week9EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week10EventLocation = JSON.Misc.Week1EventLocation;
	}

	public void TestAllEventLocations()
	{
		JSON.Misc.Week1EventLocation[1] = 3;
		JSON.Misc.Week1EventLocation[2] = 3;
		JSON.Misc.Week1EventLocation[3] = 3;
		JSON.Misc.Week1EventLocation[4] = 3;
		JSON.Misc.Week1EventLocation[5] = 3;
		JSON.Misc.Week1EventLocation[6] = 3;
		JSON.Misc.Week1EventLocation[7] = 3;
		JSON.Misc.Week1EventLocation[8] = 3;
		JSON.Misc.Week1EventLocation[9] = 3;
		JSON.Misc.Week1EventLocation[10] = 3;
		JSON.Misc.Week2EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week3EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week4EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week5EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week6EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week7EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week8EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week9EventLocation = JSON.Misc.Week1EventLocation;
		JSON.Misc.Week10EventLocation = JSON.Misc.Week1EventLocation;
	}

	public void Save()
	{
		NotificationManager.CustomText = "Data has been saved.";
		NotificationManager.DisplayNotification(NotificationType.Custom);
		string contents = JsonConvert.SerializeObject(JSON.Students);
		File.WriteAllText(Path.Combine(FolderPath, "Custom.json"), contents);
		if (JSON.Topics[1] == null)
		{
			Debug.Log("Something went catastrophically wrong, and JSON.Topics[1] was empty. Filling it up with default likes and dislikes.");
			string contents2 = JsonConvert.SerializeObject(JsonScript.TopicAdapter(JSON.Topics));
			File.WriteAllText(Path.Combine(FolderPath, "EightiesTopics.json"), contents2);
		}
		else
		{
			Debug.Log("Now attempting to save JSON data for Topics.");
			string contents3 = JsonConvert.SerializeObject(JsonScript.TopicAdapter(JSON.Topics));
			File.WriteAllText(Path.Combine(FolderPath, "CustomTopics.json"), contents3);
			Debug.Log("Success!");
		}
		JSON.Misc.SkinColor = SkinColor;
		JSON.Misc.AnimSet = AnimSet;
		JSON.Misc.EyeWear = EyeWear;
		SaveAllCustomLocations();
		string contents4 = JsonConvert.SerializeObject(JSON.Misc);
		File.WriteAllText(Path.Combine(FolderPath, "Misc.json"), contents4);
	}

	public void Load()
	{
		NotificationManager.CustomText = "Data has been loaded.";
		NotificationManager.DisplayNotification(NotificationType.Custom);
		StudentJson[] array = JsonConvert.DeserializeObject<StudentJson[]>(File.ReadAllText(Path.Combine(FolderPath, "Custom.json")));
		TopicJson[] loadedTopicData = JsonConvert.DeserializeObject<TopicJson[]>(File.ReadAllText(Path.Combine(FolderPath, "CustomTopics.json")));
		MiscJson misc = JsonConvert.DeserializeObject<MiscJson>(File.ReadAllText(Path.Combine(FolderPath, "Misc.json")));
		LoadedStudentData = array;
		LoadedTopicData = loadedTopicData;
		JSON.Students = array;
		JSON.Topics = TopicJson.LoadFromJson(Path.Combine(FolderPath, "CustomTopics.json"));
		JSON.Misc = misc;
		StudentGlobals.FemaleUniform = JSON.Misc.FemaleUniform;
		StudentGlobals.MaleUniform = JSON.Misc.MaleUniform;
		FemaleUniform = JSON.Misc.FemaleUniform;
		MaleUniform = JSON.Misc.MaleUniform;
		FemaleUniformLabel.text = FemaleUniform.ToString() ?? "";
		MaleUniformLabel.text = MaleUniform.ToString() ?? "";
		InitialFemale.Start();
		InitialMale.Start();
		SkinColor = JSON.Misc.SkinColor;
		AnimSet = JSON.Misc.AnimSet;
		EyeWear = JSON.Misc.EyeWear;
		SenpaiGlobals.SenpaiSkinColor = SkinColor[1];
		MiscellaneousOptions = JSON.Misc.Misc;
		for (int i = 1; i < MiscellaneousOptions.Length; i++)
		{
			if (!MiscellaneousOptions[i])
			{
				MiscellaneousLabels[i].text = "No";
			}
			else
			{
				MiscellaneousLabels[i].text = "Yes";
			}
		}
		for (int j = 1; j < 90; j++)
		{
			if (JSON.Students[j].Gender == 1)
			{
				StudentGenders[j] = true;
			}
			else
			{
				StudentGenders[j] = false;
			}
		}
		LoadAllCustomLocations();
		UpdateCanonMethodLabels();
		UpdateStudent();
	}

	private void UpdateTopicInterface()
	{
		if (InputManager.TappedUp)
		{
			Row--;
			UpdateTopicHighlight();
		}
		else if (InputManager.TappedDown)
		{
			Row++;
			UpdateTopicHighlight();
		}
		if (InputManager.TappedLeft)
		{
			Column--;
			UpdateTopicHighlight();
		}
		else if (InputManager.TappedRight)
		{
			Column++;
			UpdateTopicHighlight();
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			if (Likes < 5)
			{
				JSON.Topics[Selected].Topics[TopicSelected] = 2;
			}
			UpdateOpinions();
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			if (Dislikes < 5)
			{
				JSON.Topics[Selected].Topics[TopicSelected] = 1;
			}
			UpdateOpinions();
		}
		else if (Input.GetButtonDown(InputNames.Xbox_X))
		{
			JSON.Topics[Selected].Topics[TopicSelected] = 0;
			UpdateOpinions();
		}
	}

	public void UpdateTopicHighlight()
	{
		if (Row < 1)
		{
			Row = 5;
		}
		else if (Row > 5)
		{
			Row = 1;
		}
		if (Column < 1)
		{
			Column = 5;
		}
		else if (Column > 5)
		{
			Column = 1;
		}
		TopicHighlight.localPosition = new Vector3(-375 + 125 * Column, 375 - 125 * Row, TopicHighlight.localPosition.z);
		TopicSelected = (Row - 1) * 5 + Column;
		TopicLabel.text = TopicNames[TopicSelected];
		DetermineOpinion();
	}

	public void UpdateOpinions()
	{
		Dislikes = 0;
		Likes = 0;
		for (int i = 1; i <= 25; i++)
		{
			UISprite obj = OpinionIcons[i];
			int[] topics = JSON.Topics[Selected].Topics;
			obj.spriteName = OpinionSpriteNames[topics[i]];
			if (topics[i] == 1)
			{
				Dislikes++;
			}
			else if (topics[i] == 2)
			{
				Likes++;
			}
		}
	}

	private void DetermineOpinion()
	{
		int[] topics = JSON.Topics[Selected].Topics;
		Opinion = topics[TopicSelected];
	}

	private void UpdateScheduleLabels(int ID)
	{
		int num = 0;
		int i;
		for (i = 1; i < TimeLabels.Length; i++)
		{
			TimeLabels[i].transform.parent.gameObject.SetActive(value: false);
			ActionLabels[i].transform.parent.gameObject.SetActive(value: false);
			LocationLabels[i].transform.parent.gameObject.SetActive(value: false);
		}
		i = 1;
		while (i < JSON.Students[ID].ScheduleBlocks.Length)
		{
			ConvertTime(JSON.Students[ID].ScheduleBlocks[i].time);
			if (i + num < JSON.Students[ID].ScheduleBlocks.Length)
			{
				TimeLabels[i + num].text = TimeString;
				TimeLabels[i + num].transform.parent.gameObject.SetActive(value: true);
			}
			ActionLabels[i].text = JSON.Students[ID].ScheduleBlocks[i].action;
			ActionLabels[i].transform.parent.gameObject.SetActive(value: true);
			LocationLabels[i].text = JSON.Students[ID].ScheduleBlocks[i].destination;
			LocationLabels[i].transform.parent.gameObject.SetActive(value: true);
			i++;
			if (i > 1)
			{
				num = 1;
			}
		}
	}

	private void ConvertTime(float Time)
	{
		if (Time == 99f)
		{
			TimeString = "Final";
			return;
		}
		Time *= 60f;
		float num = Mathf.Floor(Time / 60f);
		float num2 = Mathf.Floor((Time / 60f - num) * 60f);
		if (num == 0f || num == 12f)
		{
			HourNumber = "12";
		}
		else if (num < 12f)
		{
			HourNumber = num.ToString("f0");
		}
		else
		{
			HourNumber = (num - 12f).ToString("f0");
		}
		if (num2 < 10f)
		{
			MinuteNumber = "0" + num2.ToString("f0");
		}
		else
		{
			MinuteNumber = num2.ToString("f0");
		}
		TimeString = HourNumber + ":" + MinuteNumber + ((num < 12f) ? " AM" : " PM");
	}

	private void PopulateRivalList()
	{
		for (int i = 1; i < 11; i++)
		{
			RivalNameLabels[i].text = JSON.Students[i + 10].Name;
		}
	}

	private void UpdateCanonMethodLabels()
	{
		for (int i = 1; i < 11; i++)
		{
			MethodLabels[i].text = EliminationNames[JSON.Misc.CanonEliminations[i]];
		}
	}

	private void UpdateLocationList()
	{
		for (int i = 1; i < 11; i++)
		{
			if (RivalSelected == 1)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
			else if (RivalSelected == 2)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
			else if (RivalSelected == 3)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
			else if (RivalSelected == 4)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
			else if (RivalSelected == 5)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
			else if (RivalSelected == 6)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
			else if (RivalSelected == 7)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
			else if (RivalSelected == 8)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
			else if (RivalSelected == 9)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
			else if (RivalSelected == 10)
			{
				EventLocationLabels[i].text = "Location #" + ArrayToEdit[i];
			}
		}
	}

	private void DestroyComponentsInChildren(Transform parentTransform)
	{
		foreach (Transform item in parentTransform)
		{
			Collider component = item.GetComponent<Collider>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
			CharacterJoint component2 = item.GetComponent<CharacterJoint>();
			if (component2 != null)
			{
				UnityEngine.Object.Destroy(component2);
			}
			Rigidbody component3 = item.GetComponent<Rigidbody>();
			if (component3 != null)
			{
				UnityEngine.Object.Destroy(component3);
			}
			DestroyComponentsInChildren(item);
		}
	}

	public void AcknowledgeChallenges()
	{
		Debug.Log("We are now in the Custom Mode scene, acknowledging the challenges that the player selected.");
		if (ChallengeGlobals.KnifeOnly)
		{
			Debug.Log("KnifeOnly: True.");
		}
		if (ChallengeGlobals.NoAlerts)
		{
			Debug.Log("NoAlerts: True.");
		}
		if (ChallengeGlobals.NoBag)
		{
			Debug.Log("NoBag: True.");
		}
		if (ChallengeGlobals.NoFriends)
		{
			Debug.Log("NoFriends: True.");
		}
		if (ChallengeGlobals.NoGaming)
		{
			Debug.Log("NoGaming: True.");
		}
		if (ChallengeGlobals.NoInfo)
		{
			Debug.Log("NoInfo: True.");
		}
		if (ChallengeGlobals.NoLaugh)
		{
			Debug.Log("NoLaugh: True.");
		}
		if (ChallengeGlobals.RivalsOnly)
		{
			Debug.Log("RivalsOnly: True.");
		}
	}
}
