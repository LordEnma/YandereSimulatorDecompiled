using UnityEngine;

public class WorkbenchScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public WeaponScript MakeshiftKnife;

	public InventoryScript Inventory;

	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public GameObject ConfirmationWindow;

	public GameObject EleventhOption;

	public GameObject OutcomeCamera;

	public Transform WorkbenchWindow;

	public Transform Highlight;

	public UILabel ConfirmationLabel;

	public UILabel HeaderLabel;

	public UILabel HintLabel;

	public AudioSource MyAudio;

	public AudioClip Success;

	public UISprite Darkness;

	public GameObject[] MaterialModel;

	public GameObject[] OutcomeModel;

	public GameObject[] Checkmark;

	public AudioClip[] LiquidSFX;

	public AudioClip[] SolidSFX;

	public AudioClip[] SFX;

	public UILabel[] Label;

	public string[] Hints;

	public int[] Material;

	public bool[] InStock;

	public bool[] Solids;

	public bool CraftingSequence;

	public bool Chemistry;

	public bool Triple;

	public bool Return;

	public bool Show;

	public string Outcome = "";

	public int Checkmarks;

	public int Selection = 1;

	public int OutcomeID = 1;

	public int Limit = 11;

	public float Rotation;

	private void Start()
	{
		WorkbenchWindow.gameObject.SetActive(false);
		RemoveCheckmarks();
	}

	private void Update()
	{
		if (!Show)
		{
			if (Prompt.Circle[0].fillAmount != 0f)
			{
				return;
			}
			Prompt.Circle[0].fillAmount = 1f;
			if (!Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0)
			{
				if (!Chemistry)
				{
					Prompt.Yandere.MainCamera.transform.position = new Vector3(26f, 5.55f, 5f);
					Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(54f, 0f, 0f);
					Prompt.Yandere.transform.position = new Vector3(26f, 4f, 4f);
				}
				else
				{
					Prompt.Yandere.MainCamera.transform.position = new Vector3(26f, 5.55f, -9.307f);
					Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(54f, 180f, 0f);
					Prompt.Yandere.transform.position = new Vector3(26f, 4f, -8.5f);
				}
				Prompt.Yandere.MyController.enabled = false;
				Prompt.Yandere.RPGCamera.enabled = false;
				Prompt.Yandere.CanMove = false;
				WorkbenchWindow.gameObject.SetActive(true);
				PromptBar.Label[0].text = "Select";
				PromptBar.Label[1].text = "Exit";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Show = true;
				Selection = 1;
				UpdateHighlight();
				if (!Chemistry)
				{
					Limit = 11;
					CheckInventory();
					EleventhOption.SetActive(true);
					HeaderLabel.text = "Materials";
				}
				else
				{
					Limit = 10;
					CheckChemicals();
					EleventhOption.SetActive(false);
					HeaderLabel.text = "Chemicals";
				}
			}
			return;
		}
		if (MakeshiftKnife != null)
		{
			Debug.Log("Telling the damn knife to use gravity.");
			MakeshiftKnife.MyRigidbody.useGravity = true;
			MakeshiftKnife.MyRigidbody.isKinematic = false;
			MakeshiftKnife = null;
		}
		if (!CraftingSequence)
		{
			if (!ConfirmationWindow.activeInHierarchy)
			{
				if (InputManager.TappedUp)
				{
					Selection--;
					UpdateHighlight();
				}
				else if (InputManager.TappedDown)
				{
					Selection++;
					UpdateHighlight();
				}
				if (Input.GetButtonDown("A"))
				{
					if (InStock[Selection] && Label[Selection].alpha == 1f)
					{
						MaterialModel[Selection].SetActive(!MaterialModel[Selection].activeInHierarchy);
						Checkmark[Selection].SetActive(!Checkmark[Selection].activeInHierarchy);
						if (Checkmark[Selection].activeInHierarchy)
						{
							Material[Checkmarks + 1] = Selection;
						}
						else
						{
							Material[Checkmarks] = 0;
						}
						CountCheckmarks();
						PlayRandomSound();
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					WorkbenchWindow.gameObject.SetActive(false);
					Prompt.Yandere.MyController.enabled = true;
					Prompt.Yandere.RPGCamera.enabled = true;
					Prompt.Yandere.CanMove = true;
					PromptBar.ClearButtons();
					PromptBar.UpdateButtons();
					PromptBar.Show = false;
					RemoveCheckmarks();
					Material[1] = 0;
					Material[2] = 0;
					Material[3] = 0;
					Triple = false;
					Show = false;
				}
				else if (Input.GetButtonDown("X") && PromptBar.Label[2].text != "")
				{
					ConfirmationWindow.SetActive(true);
					PromptBar.Label[0].text = "";
					if (!Chemistry)
					{
						ConfirmationLabel.text = "Combine these objects to make " + Outcome + "?";
						PromptBar.Label[0].text = "Yes";
					}
					else if (Prompt.Yandere.Class.ChemistryGrade + Prompt.Yandere.Class.ChemistryBonus < OutcomeID)
					{
						ConfirmationLabel.text = "You lack the chemistry knowledge to combine these chemicals effectively. Raise your Chemistry stat to at least " + OutcomeID + " and try again.";
					}
					else
					{
						ConfirmationLabel.text = "Synthesize these chemicals to create " + Outcome + "?";
						PromptBar.Label[0].text = "Yes";
					}
					PromptBar.Label[1].text = "No";
					PromptBar.Label[2].text = "";
					PromptBar.UpdateButtons();
				}
			}
			else if (PromptBar.Label[0].text != "" && Input.GetButtonDown("A"))
			{
				ConfirmationWindow.SetActive(false);
				OutcomeModel[OutcomeID].transform.localScale = new Vector3(0f, 0f, 0f);
				OutcomeModel[OutcomeID].SetActive(true);
				OutcomeCamera.SetActive(true);
				CraftingSequence = true;
				PromptBar.Label[0].text = "Continue";
				PromptBar.Label[1].text = "";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				if (Chemistry)
				{
					MyAudio.clip = Success;
					MyAudio.Play();
				}
				else
				{
					PlayRandomSound();
				}
			}
			else if (Input.GetButtonDown("B"))
			{
				ConfirmationWindow.SetActive(false);
				PromptBar.Label[0].text = "Select";
				PromptBar.Label[1].text = "Exit";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
		}
		else if (!Return)
		{
			Rotation = Mathf.Lerp(Rotation, 360f, Time.deltaTime * 10f);
			OutcomeModel[OutcomeID].transform.localScale = Vector3.Lerp(OutcomeModel[OutcomeID].transform.localScale, Vector3.one, Time.deltaTime * 10f);
			OutcomeModel[OutcomeID].transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
			Darkness.alpha = Mathf.Lerp(Darkness.alpha, 0.5f, Time.deltaTime * 10f);
			if (!(Darkness.alpha > 0.49f) || !Input.GetButtonDown("A"))
			{
				return;
			}
			if (!Chemistry)
			{
				if (OutcomeID == 1)
				{
					Inventory.Ammonium = false;
					Inventory.Balloons = false;
					GameObject obj = Object.Instantiate(Prompt.Yandere.PauseScreen.FavorMenu.DropsMenu.InfoChanWindow.Drops[13], Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
					obj.GetComponent<Rigidbody>().useGravity = true;
					obj.GetComponent<Rigidbody>().isKinematic = false;
					obj.name = "Box of Stink Bombs";
				}
				else if (OutcomeID == 2)
				{
					Inventory.Hairpins = false;
					Inventory.PaperClips = false;
					Inventory.LockPick = true;
				}
				else if (OutcomeID == 3)
				{
					Inventory.SilverFulminate = false;
					Inventory.Paper = false;
					GameObject obj2 = Object.Instantiate(Prompt.Yandere.PauseScreen.FavorMenu.DropsMenu.InfoChanWindow.Drops[12], Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
					obj2.GetComponent<Rigidbody>().useGravity = true;
					obj2.GetComponent<Rigidbody>().isKinematic = false;
					obj2.name = "Box of Bang Snaps";
				}
				else if (OutcomeID == 4)
				{
					Inventory.Nails = false;
					Prompt.Yandere.EquippedWeapon.Nails.SetActive(true);
				}
				else if (OutcomeID == 5)
				{
					Inventory.Bandages = false;
					Inventory.WoodenSticks = false;
					Inventory.Glass = false;
					MakeshiftKnife = Prompt.Yandere.WeaponManager.Weapons[45];
					MakeshiftKnife.gameObject.SetActive(true);
					MakeshiftKnife.transform.position = Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0.5f);
					MakeshiftKnife.Start();
					MakeshiftKnife.MyRigidbody.useGravity = true;
					MakeshiftKnife.MyRigidbody.isKinematic = false;
				}
			}
			else
			{
				if (OutcomeID == 1)
				{
					Inventory.Mustard = false;
					Inventory.Salt = false;
					Inventory.EmeticChemical = true;
					Inventory.EmeticPoisons++;
				}
				else if (OutcomeID == 2)
				{
					Inventory.Tyramine = false;
					Inventory.Phenylethylamine = false;
					Inventory.HeadacheChemical = true;
					Inventory.HeadachePoisons++;
				}
				else if (OutcomeID == 3)
				{
					Inventory.Acetone = false;
					Inventory.Chloroform = false;
					Inventory.SedativeChemical = true;
					Inventory.SedativePoisons++;
				}
				else if (OutcomeID == 4)
				{
					Inventory.AceticAcid = false;
					Inventory.BariumCarbonate = false;
					Inventory.LethalChemical = true;
					Inventory.LethalPoisons++;
				}
				else if (OutcomeID == 5)
				{
					Inventory.PotassiumNitrate = false;
					Inventory.Sugar = false;
					GameObject obj3 = Object.Instantiate(Prompt.Yandere.PauseScreen.FavorMenu.DropsMenu.InfoChanWindow.Drops[14], Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
					obj3.GetComponent<Rigidbody>().useGravity = true;
					obj3.GetComponent<Rigidbody>().isKinematic = false;
					obj3.name = "Smoke Bomb";
				}
				Prompt.Yandere.StudentManager.UpdateAllBentos();
			}
			RemoveCheckmarks();
			if (!Chemistry)
			{
				CheckInventory();
			}
			else
			{
				CheckChemicals();
			}
			Return = true;
		}
		else
		{
			Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 10f);
			OutcomeModel[OutcomeID].transform.localScale = Vector3.Lerp(OutcomeModel[OutcomeID].transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			OutcomeModel[OutcomeID].transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha == 0f)
			{
				OutcomeModel[OutcomeID].transform.localScale = Vector3.zero;
				OutcomeModel[OutcomeID].SetActive(false);
				OutcomeCamera.SetActive(false);
				PromptBar.Label[0].text = "Select";
				PromptBar.Label[1].text = "Exit";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				CraftingSequence = false;
				Return = false;
			}
		}
	}

	private void PlayRandomSound()
	{
		if (Chemistry)
		{
			if (Solids[Selection])
			{
				MyAudio.clip = SolidSFX[Random.Range(1, SolidSFX.Length)];
			}
			else
			{
				MyAudio.clip = LiquidSFX[Random.Range(1, LiquidSFX.Length)];
			}
		}
		else
		{
			MyAudio.clip = SFX[Random.Range(1, SFX.Length)];
		}
		MyAudio.Play();
	}

	private void CheckInventory()
	{
		Debug.Log("The game is now checking what items are currently in Yandere-chan's inventory.");
		for (int i = 1; i < Checkmark.Length; i++)
		{
			Label[i].color = new Color(0f, 0f, 0f, 0.5f);
			Label[i].text = "?????";
			InStock[i] = false;
		}
		if (Inventory.Ammonium)
		{
			Label[1].text = "Ammonium";
			InStock[1] = true;
		}
		if (Inventory.Balloons)
		{
			Label[2].text = "Balloons";
			InStock[2] = true;
		}
		if (Inventory.Bandages)
		{
			Label[3].text = "Bandages";
			InStock[3] = true;
		}
		if (Inventory.Glass)
		{
			Label[4].text = "Glass Shards";
			InStock[4] = true;
		}
		if (Inventory.Hairpins)
		{
			Label[5].text = "Hair Pins";
			InStock[5] = true;
		}
		if (Inventory.Nails)
		{
			Label[6].text = "Nails";
			InStock[6] = true;
		}
		if (Inventory.Paper)
		{
			Label[7].text = "Paper";
			InStock[7] = true;
		}
		if (Inventory.PaperClips)
		{
			Label[8].text = "Paper Clips";
			InStock[8] = true;
		}
		if (Inventory.SilverFulminate)
		{
			Label[9].text = "Silver Fulminate";
			InStock[9] = true;
		}
		if (Inventory.WoodenSticks)
		{
			Label[10].text = "Wooden Sticks";
			InStock[10] = true;
		}
		if (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.WeaponID == 9 && !Prompt.Yandere.EquippedWeapon.Nails.activeInHierarchy)
		{
			Label[11].text = "Baseball Bat";
			InStock[11] = true;
		}
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Label[i].text != "?????")
			{
				Label[i].color = new Color(0f, 0f, 0f, 1f);
			}
		}
	}

	private void CheckChemicals()
	{
		Debug.Log("The game is now checking what chemicals are currently in Yandere-chan's inventory.");
		for (int i = 1; i < Checkmark.Length; i++)
		{
			Label[i].color = new Color(0f, 0f, 0f, 0.5f);
			Label[i].text = "?????";
			InStock[i] = false;
		}
		if (Inventory.Mustard)
		{
			Label[1].text = "Mustard";
			InStock[1] = true;
		}
		if (Inventory.Salt)
		{
			Label[2].text = "Salt";
			InStock[2] = true;
		}
		if (Inventory.Tyramine)
		{
			Label[3].text = "Tyramine";
			InStock[3] = true;
		}
		if (Inventory.Phenylethylamine)
		{
			Label[4].text = "Phenylethylamine";
			InStock[4] = true;
		}
		if (Inventory.Acetone)
		{
			Label[5].text = "Acetone";
			InStock[5] = true;
		}
		if (Inventory.Chloroform)
		{
			Label[6].text = "Chloroform";
			InStock[6] = true;
		}
		if (Inventory.AceticAcid)
		{
			Label[7].text = "Acetic Acid";
			InStock[7] = true;
		}
		if (Inventory.BariumCarbonate)
		{
			Label[8].text = "Barium Carbonate";
			InStock[8] = true;
		}
		if (Inventory.PotassiumNitrate)
		{
			Label[9].text = "Potassium Nitrate";
			InStock[9] = true;
		}
		if (Inventory.Sugar)
		{
			Label[10].text = "Sugar";
			InStock[10] = true;
		}
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Label[i].text != "?????")
			{
				Label[i].color = new Color(0f, 0f, 0f, 1f);
			}
		}
	}

	private void UpdateHighlight()
	{
		if (Selection > Limit)
		{
			Selection = 1;
		}
		else if (Selection < 1)
		{
			Selection = Limit;
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 440f - 80f * (float)Selection, Highlight.localPosition.z);
		HintLabel.text = Hints[Selection];
	}

	private void CountCheckmarks()
	{
		Debug.Log("The game is now counting how many checkmarks are currently displayed.");
		PromptBar.Label[2].text = "";
		Checkmarks = 0;
		Triple = false;
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Checkmark[i].activeInHierarchy)
			{
				Checkmarks++;
				if (!Chemistry && (i == 3 || i == 4 || i == 10))
				{
					Triple = true;
				}
			}
		}
		if (!Triple && Checkmarks == 2)
		{
			PromptBar.Label[2].text = "Combine";
		}
		else if (Checkmarks == 3)
		{
			PromptBar.Label[2].text = "Combine";
		}
		PromptBar.UpdateButtons();
		if (!Chemistry)
		{
			DisableInvalidOptions();
		}
		else
		{
			DisableInvalidChemicals();
		}
	}

	private void RemoveCheckmarks()
	{
		for (int i = 1; i < Limit + 1; i++)
		{
			MaterialModel[i].SetActive(false);
			Checkmark[i].SetActive(false);
		}
		Checkmarks = 0;
	}

	private void DisableInvalidOptions()
	{
		Debug.Log("The player has picked a material, and the game is now disabling the materials that cannot be applied to that material.");
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Checkmarks > 0)
			{
				Label[i].color = new Color(0f, 0f, 0f, 0.5f);
			}
			else
			{
				Label[i].color = new Color(0f, 0f, 0f, 1f);
			}
		}
		if (!Triple)
		{
			if (Material[1] == 1 || Material[1] == 2)
			{
				Label[1].color = new Color(0f, 0f, 0f, 1f);
				Label[2].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "five stink bombs";
				OutcomeID = 1;
			}
			else if (Material[1] == 5 || Material[1] == 8)
			{
				Label[5].color = new Color(0f, 0f, 0f, 1f);
				Label[8].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "a lockpick";
				OutcomeID = 2;
			}
			else if (Material[1] == 7 || Material[1] == 9)
			{
				Label[7].color = new Color(0f, 0f, 0f, 1f);
				Label[9].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "twenty bang snaps";
				OutcomeID = 3;
			}
			else if (Material[1] == 6 || Material[1] == 11)
			{
				Label[11].color = new Color(0f, 0f, 0f, 1f);
				Label[6].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "a spiked baseball bat";
				OutcomeID = 4;
			}
		}
		if (Triple && (Material[1] == 3 || Material[2] == 3 || Material[1] == 4 || Material[2] == 4 || Material[1] == 10 || Material[2] == 10))
		{
			Label[3].color = new Color(0f, 0f, 0f, 1f);
			Label[4].color = new Color(0f, 0f, 0f, 1f);
			Label[10].color = new Color(0f, 0f, 0f, 1f);
			Outcome = "a makeshift knife";
			OutcomeID = 5;
		}
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Label[i].text == "?????")
			{
				Label[i].color = new Color(0f, 0f, 0f, 0.5f);
			}
		}
	}

	private void DisableInvalidChemicals()
	{
		Debug.Log("The player has picked a chemical, and the game is now disabling the chemicals that cannot be synthesized with that chemical.");
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Checkmarks > 0)
			{
				Label[i].color = new Color(0f, 0f, 0f, 0.5f);
			}
			else
			{
				Label[i].color = new Color(0f, 0f, 0f, 1f);
			}
		}
		if (!Triple)
		{
			if (Material[1] == 1 || Material[1] == 2)
			{
				Label[1].color = new Color(0f, 0f, 0f, 1f);
				Label[2].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "emetic poison";
				OutcomeID = 1;
			}
			else if (Material[1] == 3 || Material[1] == 4)
			{
				Label[3].color = new Color(0f, 0f, 0f, 1f);
				Label[4].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "headache poison";
				OutcomeID = 2;
			}
			else if (Material[1] == 5 || Material[1] == 6)
			{
				Label[5].color = new Color(0f, 0f, 0f, 1f);
				Label[6].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "a sedative";
				OutcomeID = 3;
			}
			else if (Material[1] == 7 || Material[1] == 8)
			{
				Label[7].color = new Color(0f, 0f, 0f, 1f);
				Label[8].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "lethal poison";
				OutcomeID = 4;
			}
			else if (Material[1] == 9 || Material[1] == 10)
			{
				Label[9].color = new Color(0f, 0f, 0f, 1f);
				Label[10].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "a smoke bomb";
				OutcomeID = 5;
			}
		}
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Label[i].text == "?????")
			{
				Label[i].color = new Color(0f, 0f, 0f, 0.5f);
			}
		}
	}
}
