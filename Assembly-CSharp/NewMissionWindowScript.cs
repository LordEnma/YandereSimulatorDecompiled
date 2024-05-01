using UnityEngine;

public class NewMissionWindowScript : MonoBehaviour
{
	public MissionModeMenuScript MissionModeMenu;

	public InputManagerScript InputManager;

	public JsonScript JSON;

	public GameObject[] DeathSkulls;

	public GameObject[] Button;

	public UILabel[] MethodLabel;

	public UILabel[] NameLabel;

	public UITexture[] Portrait;

	public bool ChangingDifficulty;

	public bool Eighties;

	public int[] UnsafeNumbers;

	public int[] Target;

	public int[] Method;

	public string[] MethodNames;

	public int Selected;

	public int Column;

	public int Row;

	public Transform DifficultyOptions;

	public Transform Highlight;

	public Texture BlankPortrait;

	public Font Arial;

	public UILabel MultiMissionDifficultyOptionsLabel;

	public int NemesisDifficulty;

	public bool NemesisAggression;

	public UILabel NemesisLabel;

	public UITexture NemesisPortrait;

	public Texture AnonymousPortrait;

	public Texture NemesisGraphic;

	public Transform[] NemesisObjectives;

	private void Start()
	{
		Eighties = GameGlobals.Eighties;
		UpdateHighlight();
		for (int i = 1; i < 11; i++)
		{
			Portrait[i].mainTexture = BlankPortrait;
			NameLabel[i].text = "Kill: (Nobody)";
			MethodLabel[i].text = "By: Attacking";
			DeathSkulls[i].SetActive(value: false);
		}
		DifficultyOptions.localScale = new Vector3(0f, 0f, 0f);
		if (Eighties)
		{
			MultiMissionDifficultyOptionsLabel.text = "Yakuza Mode: Off";
		}
	}

	private void ChangeFont(UILabel Text)
	{
		Text.trueTypeFont = Arial;
		if (Text.height == 150)
		{
			Text.height = 100;
		}
	}

	private void Update()
	{
		if (!ChangingDifficulty)
		{
			if (InputManager.TappedDown)
			{
				Row++;
				UpdateHighlight();
			}
			if (InputManager.TappedUp)
			{
				Row--;
				UpdateHighlight();
			}
			if (InputManager.TappedRight)
			{
				Column++;
				UpdateHighlight();
			}
			if (InputManager.TappedLeft)
			{
				Column--;
				UpdateHighlight();
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				int num = 0;
				for (int i = 0; i < 11; i++)
				{
					if (Target[i] > 0)
					{
						num++;
					}
				}
				if (Row == 5)
				{
					if (Column == 1)
					{
						if (num > 0)
						{
							Debug.Log("Switching GameGlobals.Profile to 4, since we are beginning a Mission Mode mission, and nothing we do in here should carry over to any of the player's other save files.");
							GameGlobals.Profile = 4;
							Globals.DeleteAll();
							SaveInfo();
							MissionModeMenu.GetComponent<AudioSource>().PlayOneShot(MissionModeMenu.InfoLines[6]);
							SchoolGlobals.SchoolAtmosphere = 1f - (float)num * 0.1f;
							SchoolGlobals.SchoolAtmosphereSet = true;
							MissionModeGlobals.MissionMode = true;
							MissionModeGlobals.MultiMission = true;
							MissionModeGlobals.MissionDifficulty = num;
							ClassGlobals.BiologyGrade = 1;
							ClassGlobals.ChemistryGrade = 1;
							ClassGlobals.LanguageGrade = 1;
							ClassGlobals.PhysicalGrade = 1;
							ClassGlobals.PsychologyGrade = 1;
							MissionModeMenu.PromptBar.Show = false;
							MissionModeMenu.Speed = 0f;
							MissionModeMenu.Phase = 4;
							if (Eighties)
							{
								DateGlobals.Week = 10;
								for (int j = 1; j < 101; j++)
								{
									StudentGlobals.SetStudentPhotographed(j, value: true);
								}
								StudentGlobals.FemaleUniform = 6;
								StudentGlobals.MaleUniform = 1;
							}
							base.enabled = false;
						}
					}
					else if (Column == 2)
					{
						Randomize();
					}
					else if (Column == 3)
					{
						if (Eighties)
						{
							if (NemesisDifficulty == 0)
							{
								NemesisDifficulty = 1;
								MultiMissionDifficultyOptionsLabel.text = "Yakuza Mode: On";
							}
							else
							{
								NemesisDifficulty = 0;
								MultiMissionDifficultyOptionsLabel.text = "Yakuza Mode: Off";
							}
						}
						else
						{
							ChangingDifficulty = true;
							MissionModeMenu.PromptBar.ClearButtons();
							MissionModeMenu.PromptBar.Label[0].text = "Change";
							MissionModeMenu.PromptBar.Label[1].text = "Back";
							MissionModeMenu.PromptBar.Label[2].text = "Aggression";
							MissionModeMenu.PromptBar.UpdateButtons();
							MissionModeMenu.PromptBar.Show = true;
						}
					}
				}
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				MissionModeMenu.PromptBar.ClearButtons();
				MissionModeMenu.PromptBar.Label[0].text = "Accept";
				MissionModeMenu.PromptBar.Label[4].text = "Choose";
				MissionModeMenu.PromptBar.UpdateButtons();
				MissionModeMenu.PromptBar.Show = true;
				MissionModeMenu.TargetID = 0;
				MissionModeMenu.Phase = 2;
				base.enabled = false;
			}
			if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				if (Row == 1)
				{
					for (int k = 1; k < 11; k++)
					{
						UnsafeNumbers[k] = Target[k];
					}
					Increment(0);
					if (Target[Column] != 0)
					{
						while ((Target[Column] != 0 && Target[Column] == UnsafeNumbers[1]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[2]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[3]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[4]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[5]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[6]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[7]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[8]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[9]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[10]))
						{
							Increment(0);
						}
					}
					UnsafeNumbers[Column] = Target[Column];
				}
				else if (Row == 2)
				{
					Method[Column]++;
					if (Eighties && Method[Column] == 5)
					{
						Method[Column]++;
					}
					if (Method[Column] == MethodNames.Length)
					{
						Method[Column] = 0;
					}
					MethodLabel[Column].text = "By: " + MethodNames[Method[Column]];
				}
				else if (Row == 3)
				{
					for (int l = 1; l < 11; l++)
					{
						UnsafeNumbers[l] = Target[l];
					}
					Increment(5);
					if (Target[Column + 5] != 0)
					{
						while ((Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[1]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[2]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[3]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[4]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[5]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[6]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[7]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[8]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[9]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[10]))
						{
							Increment(5);
						}
					}
					UnsafeNumbers[Column + 5] = Target[Column + 5];
				}
				else if (Row == 4)
				{
					Method[Column + 5]++;
					if (Eighties && Method[Column + 5] == 5)
					{
						Method[Column + 5]++;
					}
					if (Method[Column + 5] == MethodNames.Length)
					{
						Method[Column + 5] = 0;
					}
					MethodLabel[Column + 5].text = "By: " + MethodNames[Method[Column + 5]];
				}
			}
			if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				if (Row == 1)
				{
					for (int m = 1; m < 11; m++)
					{
						UnsafeNumbers[m] = Target[m];
					}
					Decrement(0);
					if (Target[Column] != 0)
					{
						while ((Target[Column] != 0 && Target[Column] == UnsafeNumbers[1]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[2]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[3]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[4]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[5]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[6]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[7]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[8]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[9]) || (Target[Column] != 0 && Target[Column] == UnsafeNumbers[10]))
						{
							Debug.Log("Unsafe number. We're going to have to decrement.");
							Decrement(0);
						}
					}
					UnsafeNumbers[Column] = Target[Column];
				}
				else if (Row == 2)
				{
					Method[Column]--;
					if (Eighties && Method[Column] == 5)
					{
						Method[Column]--;
					}
					if (Method[Column] < 0)
					{
						Method[Column] = MethodNames.Length - 1;
					}
					MethodLabel[Column].text = "By: " + MethodNames[Method[Column]];
				}
				else if (Row == 3)
				{
					for (int n = 1; n < 11; n++)
					{
						UnsafeNumbers[n] = Target[n];
					}
					Decrement(5);
					if (Target[Column + 5] != 0)
					{
						while ((Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[1]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[2]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[3]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[4]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[5]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[6]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[7]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[8]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[9]) || (Target[Column + 5] != 0 && Target[Column + 5] == UnsafeNumbers[10]))
						{
							Debug.Log("Unsafe number. We're going to have to decrement.");
							Decrement(5);
						}
					}
					UnsafeNumbers[Column + 5] = Target[Column + 5];
				}
				else if (Row == 4)
				{
					Method[Column + 5]--;
					if (Eighties && Method[Column + 5] == 5)
					{
						Method[Column + 5]--;
					}
					if (Method[Column + 5] < 0)
					{
						Method[Column + 5] = MethodNames.Length - 1;
					}
					MethodLabel[Column + 5].text = "By: " + MethodNames[Method[Column + 5]];
				}
			}
			if (Input.GetKeyDown("space"))
			{
				FillOutInfo();
			}
			DifficultyOptions.localScale = Vector3.Lerp(DifficultyOptions.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
		}
		else
		{
			DifficultyOptions.localScale = Vector3.Lerp(DifficultyOptions.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				NemesisDifficulty++;
				UpdateNemesisDifficulty();
			}
			if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				NemesisAggression = !NemesisAggression;
				UpdateNemesisDifficulty();
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				MissionModeMenu.PromptBar.ClearButtons();
				MissionModeMenu.PromptBar.Label[0].text = "";
				MissionModeMenu.PromptBar.Label[1].text = "Return";
				MissionModeMenu.PromptBar.Label[2].text = "Adjust Up";
				MissionModeMenu.PromptBar.Label[3].text = "Adjust Down";
				MissionModeMenu.PromptBar.Label[4].text = "Selection";
				MissionModeMenu.PromptBar.Label[5].text = "Selection";
				MissionModeMenu.PromptBar.UpdateButtons();
				Column = 1;
				Row = 1;
				UpdateHighlight();
				ChangingDifficulty = false;
			}
		}
		UpdateNemesisList();
	}

	private void Increment(int Number)
	{
		Target[Column + Number]++;
		if (Target[Column + Number] == 1)
		{
			Target[Column + Number] = 2;
		}
		else if (Target[Column + Number] == 13 && !Eighties)
		{
			Target[Column + Number] = 21;
		}
		else if (Target[Column + Number] > 89)
		{
			Target[Column + Number] = 0;
		}
		if (Target[Column + Number] == 0)
		{
			NameLabel[Column + Number].text = "Kill: Nobody";
		}
		else
		{
			NameLabel[Column + Number].text = "Kill: " + JSON.Students[Target[Column + Number]].Name;
		}
		Eighties = GameGlobals.Eighties;
		string text = "";
		text = ((!Eighties) ? ("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + Target[Column + Number] + ".png") : ("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_" + Target[Column + Number] + ".png"));
		WWW wWW = new WWW(text);
		if (Target[Column + Number] > 0)
		{
			Portrait[Column + Number].mainTexture = wWW.texture;
		}
		else
		{
			Portrait[Column + Number].mainTexture = BlankPortrait;
		}
	}

	private void Decrement(int Number)
	{
		Target[Column + Number]--;
		Debug.Log("Decremented. Number has become: " + Target[Column + Number]);
		if (Target[Column + Number] == 1)
		{
			Target[Column + Number] = 0;
			Debug.Log("Correcting to 0.");
		}
		else if (Target[Column + Number] == 20 && !Eighties)
		{
			Target[Column + Number] = 12;
			Debug.Log("Correcting to 12.");
		}
		else if (Target[Column + Number] == -1)
		{
			Target[Column + Number] = 89;
			Debug.Log("Correcting to 89.");
		}
		if (Target[Column + Number] == 0)
		{
			NameLabel[Column + Number].text = "Kill: Nobody";
		}
		else
		{
			NameLabel[Column + Number].text = "Kill: " + JSON.Students[Target[Column + Number]].Name;
		}
		Eighties = GameGlobals.Eighties;
		string text = "";
		text = ((!Eighties) ? ("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + Target[Column + Number] + ".png") : ("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_" + Target[Column + Number] + ".png"));
		WWW wWW = new WWW(text);
		Debug.Log("Updating portraits in Decrement() function.");
		if (Target[Column + Number] > 0)
		{
			Portrait[Column + Number].mainTexture = wWW.texture;
		}
		else
		{
			Portrait[Column + Number].mainTexture = BlankPortrait;
		}
	}

	private void Randomize()
	{
		int i;
		for (i = 1; i < 11; i++)
		{
			Target[i] = Random.Range(2, 89);
			Method[i] = Random.Range(0, 7);
			while (Eighties && Method[i] == 5)
			{
				Method[i] = Random.Range(0, 7);
			}
			MethodLabel[i].text = "By: " + MethodNames[Method[i]];
		}
		i = 1;
		Column = 0;
		for (; i < 11; i++)
		{
			for (int j = 1; j < 11; j++)
			{
				UnsafeNumbers[j] = Target[j];
			}
			while (Target[i] == UnsafeNumbers[1] || Target[i] == UnsafeNumbers[2] || Target[i] == UnsafeNumbers[3] || Target[i] == UnsafeNumbers[4] || Target[i] == UnsafeNumbers[5] || Target[i] == UnsafeNumbers[6] || Target[i] == UnsafeNumbers[7] || Target[i] == UnsafeNumbers[8] || Target[i] == UnsafeNumbers[9] || Target[i] == UnsafeNumbers[10] || Target[i] == 0 || (!Eighties && Target[i] > 12 && Target[i] < 21))
			{
				Increment(i);
			}
		}
		Column = 2;
	}

	public void UpdateHighlight()
	{
		MissionModeMenu.PromptBar.Label[0].text = "";
		if (Row < 1)
		{
			Row = 5;
		}
		else if (Row > 5)
		{
			Row = 1;
		}
		if (Row < 5)
		{
			if (Column < 1)
			{
				Column = 5;
			}
			else if (Column > 5)
			{
				Column = 1;
			}
			int num = 0;
			if (Row == 1)
			{
				num = 225;
			}
			else if (Row == 2)
			{
				num = 125;
			}
			else if (Row == 3)
			{
				num = -300;
			}
			else if (Row == 4)
			{
				num = -400;
			}
			Highlight.localPosition = new Vector3(-1200 + 400 * Column, num, 0f);
			return;
		}
		if (Column < 1)
		{
			Column = 3;
		}
		else if (Column > 3)
		{
			Column = 1;
		}
		Highlight.localPosition = new Vector3(-1200 + 600 * Column, -525f, 0f);
		if (Column == 1)
		{
			if (Target[1] + Target[2] + Target[3] + Target[4] + Target[5] + Target[6] + Target[7] + Target[8] + Target[9] + Target[10] == 0)
			{
				MissionModeMenu.PromptBar.Label[0].text = "";
			}
			else
			{
				MissionModeMenu.PromptBar.Label[0].text = "Confirm";
			}
		}
		else if (Column == 2)
		{
			MissionModeMenu.PromptBar.Label[0].text = "Confirm";
		}
		else
		{
			MissionModeMenu.PromptBar.Label[0].text = "Confirm";
		}
		MissionModeMenu.PromptBar.UpdateButtons();
	}

	private void SaveInfo()
	{
		for (int i = 1; i < 11; i++)
		{
			PlayerPrefs.SetInt("MissionModeTarget" + i, Target[i]);
			PlayerPrefs.SetInt("MissionModeMethod" + i, Method[i]);
		}
		MissionModeGlobals.NemesisDifficulty = NemesisDifficulty;
		MissionModeGlobals.NemesisAggression = NemesisAggression;
	}

	public void FillOutInfo()
	{
		for (int i = 1; i < 11; i++)
		{
			ChangeFont(NameLabel[i]);
			ChangeFont(MethodLabel[i]);
			Target[i] = PlayerPrefs.GetInt("MissionModeTarget" + i);
			Method[i] = PlayerPrefs.GetInt("MissionModeMethod" + i);
			Eighties = GameGlobals.Eighties;
			string text = "";
			text = ((!Eighties) ? ("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + Target[i] + ".png") : ("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_" + Target[i] + ".png"));
			WWW wWW = new WWW(text);
			if (Target[i] == 0)
			{
				NameLabel[i].text = "Kill: Nobody";
				Portrait[i].mainTexture = BlankPortrait;
			}
			else
			{
				NameLabel[i].text = "Kill: " + JSON.Students[Target[i]].Name;
				Portrait[i].mainTexture = wWW.texture;
			}
			MethodLabel[i].text = "By: " + MethodNames[Method[i]];
			DeathSkulls[i].SetActive(value: false);
		}
	}

	public void HideButtons()
	{
		Button[0].SetActive(value: false);
		Button[1].SetActive(value: false);
		Button[2].SetActive(value: false);
		Button[3].SetActive(value: false);
	}

	private void UpdateNemesisDifficulty()
	{
		if (NemesisDifficulty < 0)
		{
			NemesisDifficulty = 4;
		}
		else if (NemesisDifficulty > 4)
		{
			NemesisDifficulty = 0;
		}
		if (NemesisDifficulty == 0)
		{
			NemesisLabel.text = "Nemesis: Off";
			return;
		}
		NemesisLabel.text = "Nemesis: On";
		NemesisPortrait.mainTexture = ((NemesisDifficulty > 2) ? AnonymousPortrait : NemesisGraphic);
	}

	private void UpdateNemesisList()
	{
		if (NemesisDifficulty == 0)
		{
			NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
			NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
			NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (NemesisDifficulty == 1)
		{
			NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
			NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (NemesisDifficulty == 2)
		{
			NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (NemesisDifficulty == 3)
		{
			NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
			NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
		else if (NemesisDifficulty == 4)
		{
			NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
		if (NemesisAggression)
		{
			NemesisObjectives[4].localScale = Vector3.Lerp(NemesisObjectives[4].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
		else
		{
			NemesisObjectives[4].localScale = Vector3.Lerp(NemesisObjectives[4].localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
		}
	}
}
