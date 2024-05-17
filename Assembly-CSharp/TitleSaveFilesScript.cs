using UnityEngine;

public class TitleSaveFilesScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public InputManagerScript InputManager;

	public TitleSaveDataScript[] SaveDatas;

	public UILabel CorruptSaveLabel;

	public UILabel NewSaveLabel;

	public GameObject ConfirmationWindow;

	public GameObject DifficultyWindow;

	public GameObject ChallengeWindow;

	public GameObject ErrorWindow;

	public GameObject StartButton;

	public PromptBarScript PromptBar;

	public TitleMenuScript Menu;

	public Transform ChallengeHighlight;

	public Transform Highlight;

	public bool Started;

	public bool Show;

	public int EightiesPrefix;

	public int ID = 1;

	public int ChallengeColumn = 1;

	public int ChallengeRow = 1;

	public int ChallengeID = 1;

	public UILabel ChallengeNameLabel;

	public UILabel ChallengeDescLabel;

	public string[] EightiesChallengeNames;

	public string[] EightiesChallengeDescs;

	public string[] ChallengeNames;

	public string[] ChallengeDescs;

	public UISprite[] ChallengeCheckmarks;

	public UITexture[] ChallengeIcons;

	public Texture[] EightiesIcons;

	public Texture[] ModernIcons;

	public Transform[] DifficultyHighlight;

	public bool[] DifficultySettings;

	public Transform DifficultArrow;

	public UITexture DifficultyIcon;

	public UILabel DifficultyLabel;

	public Texture[] DifficultyIcons;

	public string[] DifficultyNames;

	public int DifficultyID;

	public int Difficulty;

	public int TopLimit;

	public UILabel[] RaibaruLabel;

	private void Start()
	{
		ConfirmationWindow.SetActive(value: false);
		ChallengeWindow.SetActive(value: false);
		ErrorWindow.SetActive(value: false);
		StartButton.SetActive(value: false);
		ChallengeCheckmarks[1].enabled = false;
		ChallengeCheckmarks[2].enabled = false;
		ChallengeCheckmarks[3].enabled = false;
		ChallengeCheckmarks[4].enabled = false;
		ChallengeCheckmarks[5].enabled = false;
		ChallengeCheckmarks[6].enabled = false;
		ChallengeCheckmarks[7].enabled = false;
		ChallengeCheckmarks[8].enabled = false;
	}

	private void Update()
	{
		if (!(NewTitleScreen.Speed > 3f) || NewTitleScreen.FadeOut)
		{
			return;
		}
		if (Started)
		{
			ErrorWindow.SetActive(value: true);
			if (!Started)
			{
				CorruptSaveLabel.gameObject.SetActive(value: true);
				NewSaveLabel.gameObject.SetActive(value: false);
			}
			Started = false;
		}
		if (!DifficultyWindow.activeInHierarchy && !ConfirmationWindow.activeInHierarchy && !ChallengeWindow.activeInHierarchy && !ErrorWindow.activeInHierarchy)
		{
			if (InputManager.TappedDown)
			{
				ID++;
				if (ID > 3)
				{
					ID = 1;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedUp)
			{
				ID--;
				if (ID < 1)
				{
					ID = 3;
				}
				UpdateHighlight();
			}
		}
		if (!DifficultyWindow.activeInHierarchy)
		{
			if (!ErrorWindow.activeInHierarchy)
			{
				if (!ChallengeWindow.activeInHierarchy)
				{
					if (!ConfirmationWindow.activeInHierarchy)
					{
						if (!PromptBar.Show)
						{
							PromptBar.ClearButtons();
							if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) == 0)
							{
								PromptBar.Label[0].text = "New Game";
							}
							else
							{
								PromptBar.Label[0].text = "Load Game";
							}
							PromptBar.Label[1].text = "Go Back";
							PromptBar.Label[4].text = "Change Selection";
							UpdateHighlight();
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						if (Input.GetButtonDown(InputNames.Xbox_A) || (PromptBar.Label[3].text != "" && Input.GetButtonDown(InputNames.Xbox_Y)))
						{
							if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) == 0)
							{
								DifficultyWindow.SetActive(value: true);
								PromptBar.Label[2].text = "";
								PromptBar.Label[3].text = "";
								PromptBar.Label[5].text = "Change Difficulty";
								PromptBar.Label[6].text = "";
								PromptBar.UpdateButtons();
							}
							else
							{
								Debug.Log("The game believed that Profile " + (EightiesPrefix + ID) + " already existed, so that profile is now being loaded.");
								GameGlobals.Profile = EightiesPrefix + ID;
								GameGlobals.Eighties = NewTitleScreen.Eighties;
								NewTitleScreen.FadeOut = true;
							}
							if (Input.GetButtonDown(InputNames.Xbox_Y))
							{
								NewTitleScreen.WeekSelect = true;
							}
						}
						else if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							NewTitleScreen.WeekSelect = false;
							NewTitleScreen.Speed = 0f;
							NewTitleScreen.Phase = 2;
							PromptBar.Show = false;
							base.enabled = false;
						}
						else if (Input.GetButtonDown(InputNames.Xbox_X))
						{
							if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) == 1)
							{
								ConfirmationWindow.SetActive(value: true);
								return;
							}
							PromptBar.Label[0].text = "Enable/Disable";
							PromptBar.Label[2].text = "";
							PromptBar.Label[3].text = "";
							PromptBar.UpdateButtons();
							ChallengeWindow.SetActive(value: true);
						}
						else if (Input.GetButtonDown(InputNames.Xbox_LB) && NewTitleScreen.Eighties && PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) == 0)
						{
							StartNewGame();
							NewTitleScreen.CustomMode = true;
							NewTitleScreen.FadeOut = true;
						}
					}
					else
					{
						PromptBar.Show = false;
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							PlayerPrefs.SetInt("ProfileCreated_" + (EightiesPrefix + ID), 0);
							ConfirmationWindow.SetActive(value: false);
							SaveDatas[ID].Start();
						}
						else if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							ConfirmationWindow.SetActive(value: false);
						}
					}
					return;
				}
				if (InputManager.TappedDown)
				{
					ChallengeRow++;
					if (ChallengeRow > 2)
					{
						ChallengeRow = 1;
					}
					UpdateChallengeHighlight();
				}
				if (InputManager.TappedUp)
				{
					ChallengeRow--;
					if (ChallengeRow < 1)
					{
						ChallengeRow = 2;
					}
					UpdateChallengeHighlight();
				}
				if (InputManager.TappedRight)
				{
					ChallengeColumn++;
					if (ChallengeColumn > 4)
					{
						ChallengeColumn = 1;
					}
					UpdateChallengeHighlight();
				}
				if (InputManager.TappedLeft)
				{
					ChallengeColumn--;
					if (ChallengeColumn < 1)
					{
						ChallengeColumn = 4;
					}
					UpdateChallengeHighlight();
				}
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					if (ChallengeID < 9)
					{
						ChallengeCheckmarks[ChallengeID].enabled = !ChallengeCheckmarks[ChallengeID].enabled;
						return;
					}
					StartNewGame();
					AcknowledgeChallenges();
					NewTitleScreen.FadeOut = true;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					ChallengeWindow.SetActive(value: false);
					PromptBar.Label[0].text = "New Game";
					PromptBar.Label[2].text = "Challenges";
					PromptBar.Label[3].text = "Week Select";
					if (NewTitleScreen.Eighties)
					{
						PromptBar.Label[6].text = "Custom Mode";
					}
					PromptBar.UpdateButtons();
				}
			}
			else if (Input.GetKeyDown("e"))
			{
				PlayerPrefs.DeleteAll();
				Debug.Log("All player prefs deleted...");
				Application.Quit();
			}
			else if (Input.GetKeyDown("q"))
			{
				Application.Quit();
			}
			return;
		}
		if (NewTitleScreen.Eighties)
		{
			RaibaruLabel[0].enabled = false;
			RaibaruLabel[1].enabled = false;
			TopLimit = 2;
			if (DifficultyID < TopLimit)
			{
				DifficultyID = TopLimit;
				DifficultArrow.localPosition = new Vector3(-700f, 500 - 150 * DifficultyID, 0f);
			}
		}
		else
		{
			RaibaruLabel[0].enabled = true;
			RaibaruLabel[1].enabled = true;
			TopLimit = 1;
		}
		if (InputManager.TappedDown)
		{
			DifficultyID++;
			if (DifficultyID > 7)
			{
				DifficultyID = TopLimit;
			}
			DifficultArrow.localPosition = new Vector3(-700f, 500 - 150 * DifficultyID, 0f);
		}
		if (InputManager.TappedUp)
		{
			DifficultyID--;
			if (DifficultyID < TopLimit)
			{
				DifficultyID = 7;
			}
			DifficultArrow.localPosition = new Vector3(-700f, 500 - 150 * DifficultyID, 0f);
		}
		if (InputManager.TappedRight || InputManager.TappedLeft)
		{
			DifficultySettings[DifficultyID] = !DifficultySettings[DifficultyID];
			if (!DifficultySettings[DifficultyID])
			{
				DifficultyHighlight[DifficultyID].localPosition = new Vector3(-300f, DifficultyHighlight[DifficultyID].localPosition.y, DifficultyHighlight[DifficultyID].localPosition.z);
			}
			else
			{
				DifficultyHighlight[DifficultyID].localPosition = new Vector3(400f, DifficultyHighlight[DifficultyID].localPosition.y, DifficultyHighlight[DifficultyID].localPosition.z);
			}
			DetermineDifficulty();
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			Debug.Log("Starting a new game from the Difficulty window.");
			DifficultyWindow.SetActive(value: false);
			StartNewGame();
			AcknowledgeChallenges();
			NewTitleScreen.FadeOut = true;
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			DifficultyWindow.SetActive(value: false);
			PromptBar.Label[2].text = "Challenges";
			PromptBar.Label[3].text = "Week Select";
			if (NewTitleScreen.Eighties)
			{
				PromptBar.Label[6].text = "Custom Mode";
			}
			PromptBar.Label[5].text = "";
			PromptBar.UpdateButtons();
		}
	}

	private void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(0f, 700f - 350f * (float)ID, 0f);
		PromptBar.Label[2].text = "";
		PromptBar.Label[3].text = "";
		if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) > 0)
		{
			PromptBar.Label[0].text = "Load Game";
			PromptBar.Label[2].text = "Delete";
			PromptBar.Label[6].text = "";
		}
		else
		{
			PromptBar.Label[0].text = "New Game";
			PromptBar.Label[2].text = "Challenges";
			PromptBar.Label[3].text = "Week Select";
			if (!NewTitleScreen.Eighties)
			{
				if (GameGlobals.Debug)
				{
					PromptBar.Label[3].text = "Quick Start";
				}
			}
			else
			{
				PromptBar.Label[6].text = "Custom Mode";
			}
		}
		PromptBar.UpdateButtons();
	}

	private void UpdateChallengeHighlight()
	{
		if (ChallengeRow == 3)
		{
			ChallengeID = 9;
			ChallengeHighlight.gameObject.SetActive(value: false);
			StartButton.SetActive(value: true);
		}
		else
		{
			ChallengeID = ChallengeColumn + (ChallengeRow - 1) * 4;
			ChallengeHighlight.gameObject.SetActive(value: true);
			StartButton.SetActive(value: false);
		}
		ChallengeHighlight.localPosition = new Vector3(-875f + 350f * (float)ChallengeColumn, 525f - 350f * (float)ChallengeRow, 0f);
		if (GameGlobals.Eighties)
		{
			ChallengeNameLabel.text = EightiesChallengeNames[ChallengeID];
			ChallengeDescLabel.text = EightiesChallengeDescs[ChallengeID];
		}
		else
		{
			ChallengeNameLabel.text = ChallengeNames[ChallengeID];
			ChallengeDescLabel.text = ChallengeDescs[ChallengeID];
		}
	}

	public void UpdateOutlines()
	{
		UILabel[] componentsInChildren = GetComponentsInChildren<UILabel>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].effectColor = new Color(0f, 0f, 0f);
		}
	}

	public void StartNewGame()
	{
		Started = true;
		bool debug = GameGlobals.Debug;
		GameGlobals.Profile = EightiesPrefix + ID;
		Globals.DeleteAll();
		if (GameGlobals.Eighties)
		{
			for (int i = 1; i < 101; i++)
			{
				StudentGlobals.SetStudentPhotographed(i, value: true);
			}
		}
		for (int j = 1; j < 26; j++)
		{
			ConversationGlobals.SetTopicLearnedByStudent(j, 1, value: true);
		}
		GameGlobals.Profile = EightiesPrefix + ID;
		GameGlobals.Debug = debug;
		NewTitleScreen.Darkness.color = new Color(1f, 1f, 1f, 0f);
		Started = false;
	}

	public void BecomeEighties()
	{
		ChallengeIcons[5].mainTexture = EightiesIcons[5];
		ChallengeIcons[6].mainTexture = EightiesIcons[6];
	}

	public void BecomeModern()
	{
		ChallengeIcons[5].mainTexture = ModernIcons[5];
		ChallengeIcons[6].mainTexture = ModernIcons[6];
	}

	public void DetermineDifficulty()
	{
		Difficulty = 0;
		for (int i = 1; i < DifficultySettings.Length; i++)
		{
			if (DifficultySettings[i])
			{
				Difficulty++;
			}
		}
		DifficultyLabel.text = DifficultyNames[Difficulty];
		DifficultyIcon.mainTexture = DifficultyIcons[Difficulty];
	}

	public void AcknowledgeChallenges()
	{
		Debug.Log("Acknowledging the challenges that the player selected.");
		if (ChallengeCheckmarks[1].enabled)
		{
			ChallengeGlobals.KnifeOnly = true;
			Debug.Log("KnifeOnly: True.");
		}
		if (ChallengeCheckmarks[2].enabled)
		{
			ChallengeGlobals.NoAlerts = true;
			Debug.Log("NoAlerts: True.");
		}
		if (ChallengeCheckmarks[3].enabled)
		{
			ChallengeGlobals.NoBag = true;
			Debug.Log("NoBag: True.");
		}
		if (ChallengeCheckmarks[4].enabled)
		{
			ChallengeGlobals.NoFriends = true;
			Debug.Log("NoFriends: True.");
		}
		if (ChallengeCheckmarks[5].enabled)
		{
			ChallengeGlobals.NoGaming = true;
			Debug.Log("NoGaming: True.");
		}
		if (ChallengeCheckmarks[6].enabled)
		{
			ChallengeGlobals.NoInfo = true;
			Debug.Log("NoInfo: True.");
		}
		if (ChallengeCheckmarks[7].enabled)
		{
			ChallengeGlobals.NoLaugh = true;
			Debug.Log("NoLaugh: True.");
		}
		if (ChallengeCheckmarks[8].enabled)
		{
			ChallengeGlobals.RivalsOnly = true;
			Debug.Log("RivalsOnly: True.");
		}
	}
}
