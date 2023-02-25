using UnityEngine;

public class TitleSaveFilesScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public InputManagerScript InputManager;

	public TitleSaveDataScript[] SaveDatas;

	public UILabel CorruptSaveLabel;

	public UILabel NewSaveLabel;

	public GameObject ConfirmationWindow;

	public GameObject ChallengeWindow;

	public GameObject ErrorWindow;

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

	public string[] ChallengeNames;

	public string[] ChallengeDescs;

	public UISprite[] ChallengeCheckmarks;

	private void Start()
	{
		ConfirmationWindow.SetActive(value: false);
		ChallengeWindow.SetActive(value: false);
		ErrorWindow.SetActive(value: false);
		ChallengeCheckmarks[1].enabled = false;
		ChallengeCheckmarks[2].enabled = false;
		ChallengeCheckmarks[3].enabled = false;
		ChallengeCheckmarks[4].enabled = false;
		ChallengeCheckmarks[5].enabled = false;
		ChallengeCheckmarks[6].enabled = false;
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
		if (!ConfirmationWindow.activeInHierarchy && !ChallengeWindow.activeInHierarchy && !ErrorWindow.activeInHierarchy)
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
							PromptBar.Label[0].text = "Load GAme";
						}
						PromptBar.Label[1].text = "Go Back";
						PromptBar.Label[4].text = "Change Selection";
						UpdateHighlight();
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
					}
					if (Input.GetButtonDown("A") || (PromptBar.Label[3].text != "" && Input.GetButtonDown("Y")))
					{
						if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) == 0)
						{
							StartNewGame();
						}
						else
						{
							Debug.Log("The game believed that Profile " + (EightiesPrefix + ID) + " already existed, so that profile is now being loaded.");
							GameGlobals.Profile = EightiesPrefix + ID;
							GameGlobals.Eighties = NewTitleScreen.Eighties;
						}
						NewTitleScreen.FadeOut = true;
						if (Input.GetButtonDown("Y"))
						{
							if (!NewTitleScreen.Eighties)
							{
								NewTitleScreen.QuickStart = true;
							}
							else
							{
								NewTitleScreen.WeekSelect = true;
							}
						}
					}
					else if (Input.GetButtonDown("B"))
					{
						NewTitleScreen.Speed = 0f;
						NewTitleScreen.Phase = 2;
						PromptBar.Show = false;
						base.enabled = false;
					}
					else if (Input.GetButtonDown("X") && PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) == 1)
					{
						ConfirmationWindow.SetActive(value: true);
					}
				}
				else
				{
					PromptBar.Show = false;
					if (Input.GetButtonDown("A"))
					{
						PlayerPrefs.SetInt("ProfileCreated_" + (EightiesPrefix + ID), 0);
						ConfirmationWindow.SetActive(value: false);
						SaveDatas[ID].Start();
					}
					else if (Input.GetButtonDown("B"))
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
				if (ChallengeColumn > 3)
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
					ChallengeColumn = 3;
				}
				UpdateChallengeHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				StartNewGame();
				if (ChallengeCheckmarks[1].enabled)
				{
					ChallengeGlobals.KnifeOnly = true;
				}
				if (ChallengeCheckmarks[2].enabled)
				{
					ChallengeGlobals.NoFriends = true;
				}
				if (ChallengeCheckmarks[3].enabled)
				{
					ChallengeGlobals.NoGaming = true;
				}
				if (ChallengeCheckmarks[4].enabled)
				{
					ChallengeGlobals.NoInfo = true;
				}
				if (ChallengeCheckmarks[5].enabled)
				{
					ChallengeGlobals.NoLaugh = true;
				}
				if (ChallengeCheckmarks[6].enabled)
				{
					ChallengeGlobals.RivalsOnly = true;
				}
			}
			else if (Input.GetButtonDown("B"))
			{
				ChallengeWindow.SetActive(value: false);
				PromptBar.Label[2].text = "Challenge";
			}
			else if (Input.GetButtonDown("X"))
			{
				ChallengeCheckmarks[ChallengeID].enabled = !ChallengeCheckmarks[ChallengeID].enabled;
			}
		}
		else if (Input.anyKeyDown)
		{
			PlayerPrefs.DeleteAll();
			Debug.Log("All player prefs deleted...");
			Application.Quit();
		}
	}

	private void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(0f, 700f - 350f * (float)ID, 0f);
		PromptBar.Label[2].text = "";
		PromptBar.Label[3].text = "";
		if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) > 0)
		{
			PromptBar.Label[2].text = "Delete";
		}
		else if (!NewTitleScreen.Eighties)
		{
			if (GameGlobals.Debug)
			{
				PromptBar.Label[3].text = "Quick Start";
			}
		}
		else
		{
			PromptBar.Label[3].text = "Week Select";
		}
		PromptBar.UpdateButtons();
	}

	private void UpdateChallengeHighlight()
	{
		ChallengeHighlight.localPosition = new Vector3(-800f + 400f * (float)ChallengeColumn, 700f - 366.66f * (float)ChallengeRow, 0f);
		ChallengeID = ChallengeColumn + (ChallengeRow - 1) * 3;
		ChallengeNameLabel.text = ChallengeNames[ChallengeID];
		ChallengeDescLabel.text = ChallengeDescs[ChallengeID];
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
		GameGlobals.Profile = EightiesPrefix + ID;
		GameGlobals.Debug = debug;
		NewTitleScreen.Darkness.color = new Color(1f, 1f, 1f, 0f);
		Started = false;
	}
}
