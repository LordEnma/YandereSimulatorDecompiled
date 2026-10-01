using UnityEngine;

public class SchemesScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public SchemeManagerScript SchemeManager;

	public InputManagerScript InputManager;

	public InventoryScript Inventory;

	public PromptBarScript PromptBar;

	public GameObject SchemesSubMenu;

	public GameObject NextStepInput;

	public GameObject FavorMenu;

	public Transform Highlight;

	public Transform Arrow;

	public UILabel SchemeInstructions;

	public UILabel HeaderLabel;

	public UILabel PantyCount;

	public UILabel SchemeDesc;

	public UITexture SchemeIcon;

	public UILabel[] SchemeDeadlineLabels;

	public UILabel[] SchemeCostLabels;

	public UILabel[] SchemeNameLabels;

	public UISprite[] Exclamations;

	public Texture[] SchemeIcons;

	public int[] SchemeCosts;

	public Transform[] SchemeDestinations;

	public string[] SchemeDeadlines;

	public string[] SchemeSkills;

	public string[] SchemeDescs;

	public string[] SchemeNames;

	public Scheme[] SchemeTypes;

	public bool[] SchemeUnlocked;

	[Multiline]
	[SerializeField]
	public string[] SchemeSteps;

	public int ListPosition = 1;

	public int Limit = 20;

	public int ID = 1;

	public string[] Steps;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	public Transform[] Scheme1Destinations;

	public Transform[] Scheme2Destinations;

	public Transform[] Scheme3Destinations;

	public Transform[] Scheme4Destinations;

	public Transform[] Scheme5Destinations;

	public bool[] DisableScheme;

	public bool Initialized;

	public int SchemeCategory;

	public string Title;

	[Multiline]
	[SerializeField]
	public string AlternatePoisonSteps;

	public float HeldDown;

	public float HeldUp;

	public GameObject HUDIcon;

	public UILabel HUDInstructions;

	public void Start()
	{
		if (!(SchemeManager != null))
		{
			return;
		}
		if (!Initialized)
		{
			SchemeManager.CurrentScheme = SchemeGlobals.CurrentScheme;
			SchemeManager.CurrentCategory = SchemeGlobals.SchemeCategory;
			for (int i = 1; i < 1001; i++)
			{
				SchemeManager.SchemePreviousStage[i] = SchemeGlobals.GetSchemePreviousStage(i);
				SchemeManager.SchemeStage[i] = SchemeGlobals.GetSchemeStage(i);
			}
			for (int j = 1; j < SchemeNameLabels.Length; j++)
			{
				if (!SchemeGlobals.GetSchemeStatus(j))
				{
					SchemeDeadlineLabels[j].text = SchemeDeadlines[j];
					SchemeNameLabels[j].text = SchemeNames[j];
				}
			}
			Initialized = true;
		}
		else
		{
			Debug.Log(base.gameObject.name + " is now firing the Start() function again...");
		}
		if (NextStepInput != null)
		{
			NextStepInput.SetActive(value: false);
		}
		UpdateSchemeInfo();
		if (StudentManager.MissionMode)
		{
			SchemeInstructions.color = Color.white;
			SchemeDesc.color = Color.white;
		}
		if (SchemeManager.CurrentScheme > 0)
		{
			UpdateSchemeDestinations();
			UpdateInstructions();
		}
		ConfirmWhatSchemesAreUnlocked();
	}

	private void Update()
	{
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
		if (InputManager.TappedUp || HeldUp > 0.5f)
		{
			if (HeldUp > 0.5f)
			{
				HeldUp = 0.45f;
			}
			if (ID == 1)
			{
				ID = Limit;
			}
			else
			{
				ID--;
			}
			UpdateSchemeInfo();
		}
		if (InputManager.TappedDown || HeldDown > 0.5f)
		{
			if (HeldDown > 0.5f)
			{
				HeldDown = 0.45f;
			}
			if (ID == Limit)
			{
				ID = 1;
			}
			else
			{
				ID++;
			}
			UpdateSchemeInfo();
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			AudioSource component = GetComponent<AudioSource>();
			if (PromptBar.Label[0].text != string.Empty)
			{
				if (SchemeNameLabels[ID].color.a == 1f)
				{
					SchemeManager.enabled = true;
					Debug.Log("Selecting a scheme. Checking to see if we had already unlocked that scheme or not.");
					if (!SchemeUnlocked[ID + ListPosition])
					{
						Debug.Log("We are unlocking this Scheme now.");
						if (Inventory.PantyShots >= SchemeCosts[ID + ListPosition])
						{
							Inventory.PantyShots -= SchemeCosts[ID + ListPosition];
							SchemeUnlocked[ID + ListPosition] = true;
							SchemeManager.SchemeUnlocked[(int)SchemeTypes[ID + ListPosition]] = true;
							SchemeManager.SchemeID = (int)SchemeTypes[ID + ListPosition];
							SchemeManager.CurrentSteps = SchemeSteps[ID + ListPosition];
							SchemeManager.CurrentCategory = SchemeCategory;
							SchemeManager.CurrentScheme = ID + ListPosition;
							if (SchemeManager.SchemeStage[(int)SchemeTypes[ID + ListPosition]] == 0)
							{
								SchemeManager.SchemeStage[(int)SchemeTypes[ID + ListPosition]] = 1;
							}
							UpdateSchemeDestinations();
							UpdateInstructions();
							UpdateSchemeList();
							UpdateSchemeInfo();
							component.clip = InfoPurchase;
							component.Play();
						}
					}
					else
					{
						Debug.Log("We're activating/deactivating a Scheme that had already been unlocked.");
						if (SchemeManager.CurrentCategory == SchemeCategory && SchemeManager.CurrentScheme == ID + ListPosition)
						{
							Debug.Log("Setting CurrentScheme to 0.");
							Arrow.gameObject.SetActive(value: false);
							HUDIcon.gameObject.SetActive(value: false);
							HUDInstructions.text = string.Empty;
							SchemeManager.CurrentScheme = 0;
							SchemeManager.enabled = false;
						}
						else
						{
							Debug.Log("Setting CurrentScheme to " + (ID + ListPosition) + ".");
							SchemeManager.SchemeID = (int)SchemeTypes[ID + ListPosition];
							SchemeManager.CurrentSteps = SchemeSteps[ID + ListPosition];
							SchemeManager.CurrentScheme = ID + ListPosition;
							SchemeManager.CurrentCategory = SchemeCategory;
						}
						UpdateSchemeDestinations();
						UpdateInstructions();
						UpdateSchemeInfo();
					}
					if (SchemeManager.SchemeID == 410)
					{
						SchemeManager.ClockCheck = true;
					}
				}
			}
			else if (SchemeManager.SchemeStage[(int)SchemeTypes[ID + ListPosition]] != 100 && Inventory.PantyShots < SchemeCosts[ID + ListPosition])
			{
				StudentManager.Yandere.PauseScreen.FavorMenu.Flicker = true;
				component.clip = InfoAfford;
				component.Play();
			}
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[5].text = "Choose";
			PromptBar.UpdateButtons();
			SchemesSubMenu.SetActive(value: true);
			base.gameObject.SetActive(value: false);
		}
	}

	public void UpdateSchemeList()
	{
		Debug.Log(base.gameObject.name + " is now firing UpdateSchemeList().");
		if (Limit < 16)
		{
			_ = Limit;
		}
		for (int i = 1; i < Limit; i++)
		{
			if (SchemeManager.SchemeStage[(int)SchemeTypes[ID + ListPosition]] == 100)
			{
				UILabel uILabel = SchemeNameLabels[i];
				uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
				SchemeCostLabels[i].text = string.Empty;
				continue;
			}
			if (SchemeUnlocked[i])
			{
				SchemeCostLabels[i].text = SchemeCosts[i].ToString();
			}
			else
			{
				SchemeCostLabels[i].text = string.Empty;
			}
			if (SchemeManager.SchemeStage[i] > SchemeManager.SchemePreviousStage[i])
			{
				SchemeManager.SchemePreviousStage[i] = SchemeManager.SchemeStage[i];
			}
		}
	}

	public void UpdateSchemeInfo()
	{
		if (SchemeManager.SchemeStage[(int)SchemeTypes[ID + ListPosition]] != 100)
		{
			if (!SchemeUnlocked[ID + ListPosition])
			{
				Arrow.gameObject.SetActive(value: false);
				if (Inventory != null)
				{
					PromptBar.Label[0].text = ((Inventory.PantyShots >= SchemeCosts[ID + ListPosition]) ? "Purchase" : string.Empty);
				}
				PromptBar.UpdateButtons();
			}
			else if (SchemeManager.CurrentCategory == SchemeCategory && SchemeManager.CurrentScheme == ID + ListPosition)
			{
				Arrow.gameObject.SetActive(value: true);
				Arrow.localPosition = new Vector3(Arrow.localPosition.x, -10f - 21f * (float)SchemeManager.SchemeStage[(int)SchemeTypes[ID + ListPosition]], Arrow.localPosition.z);
				PromptBar.Label[0].text = "Stop Tracking";
				PromptBar.UpdateButtons();
			}
			else
			{
				Arrow.gameObject.SetActive(value: false);
				PromptBar.Label[0].text = "Start Tracking";
				PromptBar.UpdateButtons();
			}
		}
		else
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 200f - 25f * (float)ID, Highlight.localPosition.z);
		int num = 16;
		if (Limit < 16)
		{
			num = Limit + 1;
		}
		for (int i = 1; i < 16; i++)
		{
			SchemeNameLabels[i].text = "";
			SchemeCostLabels[i].text = "";
			SchemeDeadlineLabels[i].text = "";
			Exclamations[i].enabled = false;
		}
		for (int j = 1; j < num; j++)
		{
			SchemeNameLabels[j].text = SchemeNames[j + ListPosition];
			SchemeDeadlineLabels[j].text = SchemeDeadlines[j + ListPosition];
			if (SchemeUnlocked[j + ListPosition])
			{
				SchemeCostLabels[j].text = "✔";
			}
			else
			{
				SchemeCostLabels[j].text = SchemeCosts[j + ListPosition].ToString() ?? "";
			}
			if (DisableScheme[j + ListPosition])
			{
				SchemeNameLabels[j].color = new Color(0f, 0f, 0f, 0.5f);
			}
			else
			{
				SchemeNameLabels[j].color = new Color(0f, 0f, 0f, 1f);
			}
			if (SchemeManager != null && SchemeManager.CurrentCategory == SchemeCategory && SchemeManager.CurrentScheme == j + ListPosition)
			{
				Exclamations[j].enabled = true;
			}
		}
		SchemeIcon.mainTexture = SchemeIcons[ID + ListPosition];
		SchemeDesc.text = SchemeDescs[ID + ListPosition];
		if (SchemeManager.SchemeStage[(int)SchemeTypes[ID + ListPosition]] == 100)
		{
			SchemeInstructions.text = "This scheme is no longer available.";
		}
		else
		{
			SchemeInstructions.text = ((!SchemeUnlocked[ID + ListPosition]) ? ("Skills Required:\n" + SchemeSkills[ID + ListPosition]) : SchemeSteps[ID + ListPosition]);
		}
		UpdatePantyCount();
	}

	public void UpdatePantyCount()
	{
		if (Inventory != null)
		{
			PantyCount.text = Inventory.PantyShots.ToString();
		}
	}

	public void UpdateInstructions()
	{
		Debug.Log("Now running Schemes.UpdateInstructions().");
		Steps = SchemeManager.CurrentSteps.Split('\n');
		Debug.Log("SchemeManager.CurrentCategory is: " + SchemeManager.CurrentCategory);
		Debug.Log("SchemeManager.CurrentScheme is: " + SchemeManager.CurrentScheme);
		Debug.Log("SchemeManager.SchemeID is: " + SchemeManager.SchemeID);
		if (SchemeManager.CurrentScheme > 0)
		{
			if (SchemeManager.SchemeID == 409 && SchemeManager.SchemeStage[409] == 1 && ((StudentManager.Yandere.Weapon[1] != null && StudentManager.Yandere.Weapon[1].WeaponID == 6) || (StudentManager.Yandere.Weapon[2] != null && StudentManager.Yandere.Weapon[2].WeaponID == 6)))
			{
				SchemeManager.SchemeStage[409] = 2;
			}
			if (SchemeManager.SchemeStage[SchemeManager.SchemeID] < 100)
			{
				Debug.Log("SchemeManager.GetSchemeStage(SchemeManager.SchemeID) is less than 100...");
				if (SchemeManager.SchemeStage[SchemeManager.SchemeID] < 1)
				{
					Debug.Log("SchemeManager.GetSchemeStage(SchemeManager.SchemeID) is less than 1...");
					SchemeManager.SchemeStage[SchemeManager.SchemeID] = Steps.Length;
				}
				else if (SchemeManager.SchemeStage[SchemeManager.SchemeID] > Steps.Length)
				{
					Debug.Log("SchemeManager.GetSchemeStage(SchemeManager.SchemeID) is greater than the number of steps in the scheme.");
					SchemeManager.SchemeStage[SchemeManager.SchemeID] = 1;
				}
				HUDIcon.SetActive(value: true);
				HUDInstructions.text = Steps[SchemeManager.SchemeStage[SchemeManager.SchemeID] - 1].ToString();
			}
			else
			{
				Arrow.gameObject.SetActive(value: false);
				HUDIcon.gameObject.SetActive(value: false);
				HUDInstructions.text = string.Empty;
				SchemeManager.CurrentScheme = 0;
			}
		}
		else
		{
			HUDIcon.SetActive(value: false);
			NextStepInput.SetActive(value: false);
			HUDInstructions.text = string.Empty;
		}
		if (StudentManager.Week == 1 && SchemeManager.CurrentCategory > 3 && SchemeManager.CurrentScheme > 5 && SchemeManager.CurrentScheme < 12)
		{
			NextStepInput.SetActive(value: false);
		}
		else if (SchemeManager.CurrentScheme > 0)
		{
			NextStepInput.SetActive(value: true);
		}
	}

	public void UpdateSchemeDestinations()
	{
		for (int i = 0; i < SchemeManager.CurrentDestinations.Length; i++)
		{
			SchemeManager.CurrentDestinations[i] = null;
		}
		if (StudentManager.Students[StudentManager.RivalID] != null)
		{
			Scheme1Destinations[3] = StudentManager.Students[StudentManager.RivalID].transform;
			Scheme1Destinations[7] = StudentManager.Students[StudentManager.RivalID].transform;
			Scheme4Destinations[5] = StudentManager.Students[StudentManager.RivalID].transform;
			Scheme4Destinations[6] = StudentManager.Students[StudentManager.RivalID].transform;
		}
		if (StudentManager.Students[2] != null)
		{
			Scheme2Destinations[3] = StudentManager.Students[2].transform;
		}
		if (StudentManager.Students[97] != null)
		{
			Scheme5Destinations[3] = StudentManager.Students[97].transform;
		}
		if (SchemeManager.CurrentCategory == 4)
		{
			if (SchemeManager.CurrentScheme == 6)
			{
				SchemeDestinations = Scheme1Destinations;
			}
			else if (SchemeManager.CurrentScheme == 7)
			{
				SchemeDestinations = Scheme2Destinations;
			}
			else if (SchemeManager.CurrentScheme == 8)
			{
				SchemeDestinations = Scheme3Destinations;
			}
			else if (SchemeManager.CurrentScheme == 9)
			{
				SchemeDestinations = Scheme4Destinations;
			}
			else if (SchemeManager.CurrentScheme == 10)
			{
				SchemeDestinations = Scheme5Destinations;
			}
			SchemeManager.CurrentDestinations = SchemeDestinations;
		}
	}

	public void ConfirmWhatSchemesAreUnlocked()
	{
		int num = SchemeCategory * 100;
		if (SchemeCategory > 0)
		{
			for (int i = 1; i < SchemeUnlocked.Length; i++)
			{
				SchemeUnlocked[i] = SchemeManager.SchemeUnlocked[num + i];
			}
		}
	}

	public void CheckForSpecialCase()
	{
		Debug.Log(base.gameObject.name + " is now checking for special cases.");
		int week = DateGlobals.Week;
		if (SchemeCategory != 2)
		{
			return;
		}
		for (int i = 0; i < SchemeSteps.Length; i++)
		{
			if (SchemeSteps[i].Contains("(X)"))
			{
				SchemeSteps[i] = SchemeSteps[i].Replace("(X)", (week * 10).ToString() ?? "");
			}
			if (week > 1 && SchemeSteps[i].Contains("Raibaru"))
			{
				int num = SchemeSteps[i].IndexOf('\n');
				if (num >= 0)
				{
					SchemeSteps[i] = SchemeSteps[i].Substring(num + 1);
				}
			}
		}
		if (week > 1)
		{
			SchemeSteps[5] = SchemeSteps[5].Replace("Go to your rival's desk and put emetic poison into her bento.", "Go to your rival's desk, open her bookbag, and put emetic poison into her bento.");
			SchemeDeadlines[5] = "None";
			SchemeSteps[8] = SchemeSteps[8].Replace("Eavesdrop on your rival's Monday morning conversations, or pay Info-chan using the Services Menu.", "Befriend your rival's clubmates to learn her social media, or Pay Info-chan for her social media.");
			SchemeSteps[8] = SchemeSteps[8].Replace("Step 4: Ask the suitor to follow you. Go to the library. Help the suitor study.", "Step 4: Ask the suitor to follow you. Go to the Art Room. Help the suitor raise his courage.");
			SchemeSteps[9] = AlternatePoisonSteps;
		}
	}
}
