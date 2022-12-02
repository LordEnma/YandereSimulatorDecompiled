using UnityEngine;

public class TitleSaveFilesScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public InputManagerScript InputManager;

	public TitleSaveDataScript[] SaveDatas;

	public UILabel CorruptSaveLabel;

	public UILabel NewSaveLabel;

	public GameObject ConfirmationWindow;

	public GameObject ErrorWindow;

	public PromptBarScript PromptBar;

	public TitleMenuScript Menu;

	public Transform Highlight;

	public bool Started;

	public bool Show;

	public int EightiesPrefix;

	public int ID = 1;

	private void Update()
	{
		if (!(NewTitleScreen.Speed > 3f) || NewTitleScreen.FadeOut)
		{
			return;
		}
		if (Started)
		{
			ErrorWindow.SetActive(true);
			if (!Started)
			{
				CorruptSaveLabel.gameObject.SetActive(true);
				NewSaveLabel.gameObject.SetActive(false);
			}
			Started = false;
		}
		if (!ConfirmationWindow.activeInHierarchy)
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
			if (!ConfirmationWindow.activeInHierarchy)
			{
				if (!PromptBar.Show)
				{
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Make Selection";
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
						Started = true;
						bool debug = GameGlobals.Debug;
						GameGlobals.Profile = EightiesPrefix + ID;
						Globals.DeleteAll();
						if (GameGlobals.Eighties)
						{
							for (int i = 1; i < 101; i++)
							{
								StudentGlobals.SetStudentPhotographed(i, true);
							}
						}
						GameGlobals.Profile = EightiesPrefix + ID;
						GameGlobals.Debug = debug;
						NewTitleScreen.Darkness.color = new Color(1f, 1f, 1f, 0f);
						Started = false;
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
				else if (Input.GetButtonDown("X"))
				{
					if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) > 0)
					{
						ConfirmationWindow.SetActive(true);
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					NewTitleScreen.Speed = 0f;
					NewTitleScreen.Phase = 2;
					PromptBar.Show = false;
					base.enabled = false;
				}
			}
			else
			{
				PromptBar.Show = false;
				if (Input.GetButtonDown("A"))
				{
					PlayerPrefs.SetInt("ProfileCreated_" + (EightiesPrefix + ID), 0);
					ConfirmationWindow.SetActive(false);
					SaveDatas[ID].Start();
				}
				else if (Input.GetButtonDown("B"))
				{
					ConfirmationWindow.SetActive(false);
				}
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
			PromptBar.UpdateButtons();
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

	public void UpdateOutlines()
	{
		UILabel[] componentsInChildren = GetComponentsInChildren<UILabel>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].effectColor = new Color(0f, 0f, 0f);
		}
	}
}
