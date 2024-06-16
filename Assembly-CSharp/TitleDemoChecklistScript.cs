using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDemoChecklistScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public UISprite[] ConfirmBlocks;

	public string[] ItemNames;

	public string[] ItemDescs;

	public UILabel ItemNameLabel;

	public UILabel ItemDescLabel;

	public UILabel ResetLabel;

	public Vector3 OriginalPosition;

	public GameObject ResetWindow;

	public Transform ExaminedIconParent;

	public Transform Highlight;

	public Transform Icons;

	public bool DeletingGlobals;

	public bool Shrink;

	public bool Show;

	public bool Zoom;

	public int Confirmations;

	public int Columns;

	public int Rows;

	public int OffsetLimit;

	public int Offset;

	public int Column;

	public int Row;

	public int Selected = 1;

	public UITexture[] Items;

	public Texture[] ItemTextures;

	public int[] Checklist;

	private void Start()
	{
		UpdateHighlight();
		if (PlayerPrefs.GetInt("Attack") == 1)
		{
			Items[1].mainTexture = ItemTextures[1];
		}
		if (PlayerPrefs.GetInt("Befriend") == 1)
		{
			Items[2].mainTexture = ItemTextures[2];
		}
		if (PlayerPrefs.GetInt("Betray") == 1)
		{
			Items[3].mainTexture = ItemTextures[3];
		}
		if (PlayerPrefs.GetInt("Bully") == 1)
		{
			Items[4].mainTexture = ItemTextures[4];
		}
		if (PlayerPrefs.GetInt("Burn") == 1)
		{
			Items[5].mainTexture = ItemTextures[5];
		}
		if (PlayerPrefs.GetInt("Crush") == 1)
		{
			Items[6].mainTexture = ItemTextures[6];
		}
		if (PlayerPrefs.GetInt("Drown") == 1)
		{
			Items[7].mainTexture = ItemTextures[7];
		}
		if (PlayerPrefs.GetInt("Electrocute") == 1)
		{
			Items[8].mainTexture = ItemTextures[8];
		}
		if (PlayerPrefs.GetInt("Expel") == 1)
		{
			Items[9].mainTexture = ItemTextures[9];
		}
		if (PlayerPrefs.GetInt("Fan") == 1)
		{
			Items[10].mainTexture = ItemTextures[10];
		}
		if (PlayerPrefs.GetInt("Frame") == 1)
		{
			Items[11].mainTexture = ItemTextures[11];
		}
		if (PlayerPrefs.GetInt("Kidnap") == 1)
		{
			Items[12].mainTexture = ItemTextures[12];
		}
		if (PlayerPrefs.GetInt("Matchmake") == 1)
		{
			Items[13].mainTexture = ItemTextures[13];
		}
		if (PlayerPrefs.GetInt("MurderSuicide") == 1)
		{
			Items[14].mainTexture = ItemTextures[14];
		}
		if (PlayerPrefs.GetInt("Poison") == 1)
		{
			Items[15].mainTexture = ItemTextures[15];
		}
		if (PlayerPrefs.GetInt("Pool") == 1)
		{
			Items[16].mainTexture = ItemTextures[16];
		}
		if (PlayerPrefs.GetInt("Push") == 1)
		{
			Items[17].mainTexture = ItemTextures[17];
		}
		if (PlayerPrefs.GetInt("Reject") == 1)
		{
			Items[18].mainTexture = ItemTextures[18];
		}
		if (PlayerPrefs.GetInt("Suicide") == 1)
		{
			Items[19].mainTexture = ItemTextures[19];
		}
		if (PlayerPrefs.GetInt("DrivenToMurder") == 1)
		{
			Items[20].mainTexture = ItemTextures[20];
		}
		if (PlayerPrefs.GetInt("HeadHunter") == 1)
		{
			Items[21].mainTexture = ItemTextures[21];
		}
		if (PlayerPrefs.GetInt("PantyQueen") == 1)
		{
			Items[22].mainTexture = ItemTextures[22];
		}
		if (PlayerPrefs.GetInt("RichGirl") == 1)
		{
			Items[23].mainTexture = ItemTextures[23];
		}
		if (PlayerPrefs.GetInt("WeaponMaster") == 1)
		{
			Items[24].mainTexture = ItemTextures[24];
		}
		if (PlayerPrefs.GetInt("Alphabet") == 1)
		{
			Items[25].mainTexture = ItemTextures[25];
		}
		if (PlayerPrefs.GetInt("Amai") == 1)
		{
			Items[26].mainTexture = ItemTextures[26];
		}
		if (PlayerPrefs.GetInt("Dance") == 1)
		{
			Items[27].mainTexture = ItemTextures[27];
		}
		if (PlayerPrefs.GetInt("Genocide") == 1)
		{
			Items[28].mainTexture = ItemTextures[28];
		}
		if (PlayerPrefs.GetInt("Headmaster") == 1)
		{
			Items[29].mainTexture = ItemTextures[29];
		}
		if (PlayerPrefs.GetInt("Journalist") == 1)
		{
			Items[30].mainTexture = ItemTextures[30];
		}
		if (PlayerPrefs.GetInt("LifeNote") == 1)
		{
			Items[31].mainTexture = ItemTextures[31];
		}
		if (PlayerPrefs.GetInt("Maid") == 1)
		{
			Items[32].mainTexture = ItemTextures[32];
		}
		if (PlayerPrefs.GetInt("Mission") == 1)
		{
			Items[33].mainTexture = ItemTextures[33];
		}
		if (PlayerPrefs.GetInt("Miyuki") == 1)
		{
			Items[34].mainTexture = ItemTextures[34];
		}
		if (PlayerPrefs.GetInt("Basement") == 1)
		{
			Items[35].mainTexture = ItemTextures[35];
		}
		if (PlayerPrefs.GetInt("Panther") == 1)
		{
			Items[36].mainTexture = ItemTextures[36];
		}
		if (PlayerPrefs.GetInt("Selene") == 1)
		{
			Items[37].mainTexture = ItemTextures[37];
		}
		if (PlayerPrefs.GetInt("SNAP") == 1)
		{
			Items[38].mainTexture = ItemTextures[38];
		}
		if (PlayerPrefs.GetInt("Yakuza") == 1)
		{
			Items[39].mainTexture = ItemTextures[39];
		}
		if (PlayerPrefs.GetInt("Yanvania") == 1)
		{
			Items[40].mainTexture = ItemTextures[40];
		}
	}

	private void Update()
	{
		if (Zoom)
		{
			if (!Shrink)
			{
				Items[Selected].transform.localPosition = Vector3.Lerp(Items[Selected].transform.localPosition, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
				Items[Selected].transform.localScale = Vector3.Lerp(Items[Selected].transform.localScale, new Vector3(0.6f, 0.6f, 0.6f), Time.deltaTime * 10f);
				if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					Items[Selected].transform.parent = Icons;
					Items[Selected].depth = 0;
					Shrink = true;
				}
			}
			else
			{
				Items[Selected].transform.localPosition = Vector3.Lerp(Items[Selected].transform.localPosition, OriginalPosition, Time.deltaTime * 10f);
				Items[Selected].transform.localScale = Vector3.Lerp(Items[Selected].transform.localScale, new Vector3(0.195f, 0.195f, 0.195f), Time.deltaTime * 10f);
				if (Items[Selected].transform.localScale.x < 0.2f)
				{
					Items[Selected].transform.localPosition = OriginalPosition;
					Items[Selected].transform.localScale = new Vector3(0.195f, 0.195f, 0.195f);
					Shrink = false;
					Zoom = false;
				}
			}
		}
		else if (!ResetWindow.activeInHierarchy)
		{
			if (InputManager.TappedUp)
			{
				Row--;
				if (Row < 0)
				{
					Row = 0;
					if (Offset > 0)
					{
						Offset--;
					}
				}
			}
			if (InputManager.TappedDown)
			{
				Row++;
				if (Row > Rows - 1)
				{
					Row--;
					if (Offset < OffsetLimit)
					{
						Offset++;
					}
				}
			}
			if (InputManager.TappedRight)
			{
				Column = ((Column < Columns - 1) ? (Column + 1) : 0);
			}
			if (InputManager.TappedLeft)
			{
				Column = ((Column > 0) ? (Column - 1) : (Columns - 1));
			}
			if (InputManager.TappedUp || InputManager.TappedDown || InputManager.TappedRight || InputManager.TappedLeft)
			{
				UpdateHighlight();
			}
			if (NewTitleScreen.Speed > 3f)
			{
				if (!PromptBar.Show)
				{
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "View Image";
					PromptBar.Label[1].text = "Go Back";
					PromptBar.Label[2].text = "Reset Progress";
					PromptBar.Label[4].text = "Change Selection";
					PromptBar.Label[5].text = "Change Selection";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
				}
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					OriginalPosition = Items[Selected].transform.localPosition;
					Items[Selected].transform.parent = ExaminedIconParent;
					Items[Selected].depth = 2;
					Zoom = true;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_X))
				{
					ResetWindow.SetActive(value: true);
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					NewTitleScreen.Speed = 0f;
					NewTitleScreen.Phase = 2;
					PromptBar.Show = false;
					base.enabled = false;
				}
				else if (Input.GetKeyDown("r"))
				{
					ResetLabel.text = "This is a hidden debug command for completely removing all Yandere Simulator data from your computer's registry. This command will delete all of your save data, but may fix certain types of bugs that cannot be fixed in any other way. (Your Content Checklist progress will NOT be deleted.)";
					DeletingGlobals = true;
					ResetWindow.SetActive(value: true);
				}
			}
		}
		else if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			Confirmations++;
			ConfirmBlocks[Confirmations].color = new Color(1f, 1f, 1f, 1f);
			if (Confirmations == 10)
			{
				if (DeletingGlobals)
				{
					RememberChecklistProgress();
					PlayerPrefs.DeleteAll();
					RecallChecklistProgress();
					OptionGlobals.DisableScanlines = true;
				}
				else
				{
					PlayerPrefs.SetInt("Attack", 0);
					PlayerPrefs.SetInt("Befriend", 0);
					PlayerPrefs.SetInt("Betray", 0);
					PlayerPrefs.SetInt("Bully", 0);
					PlayerPrefs.SetInt("Burn", 0);
					PlayerPrefs.SetInt("Crush", 0);
					PlayerPrefs.SetInt("Drown", 0);
					PlayerPrefs.SetInt("Electrocute", 0);
					PlayerPrefs.SetInt("Expel", 0);
					PlayerPrefs.SetInt("Fan", 0);
					PlayerPrefs.SetInt("Frame", 0);
					PlayerPrefs.SetInt("Kidnap", 0);
					PlayerPrefs.SetInt("Matchmake", 0);
					PlayerPrefs.SetInt("MurderSuicide", 0);
					PlayerPrefs.SetInt("Poison", 0);
					PlayerPrefs.SetInt("Pool", 0);
					PlayerPrefs.SetInt("Push", 0);
					PlayerPrefs.SetInt("Reject", 0);
					PlayerPrefs.SetInt("Suicide", 0);
					PlayerPrefs.SetInt("DrivenToMurder", 0);
					PlayerPrefs.SetInt("HeadHunter", 0);
					PlayerPrefs.SetInt("PantyQueen", 0);
					PlayerPrefs.SetInt("RichGirl", 0);
					PlayerPrefs.SetInt("WeaponMaster", 0);
					PlayerPrefs.SetInt("HeadsHunted", 0);
					PlayerPrefs.SetInt("Alphabet", 0);
					PlayerPrefs.SetInt("Amai", 0);
					PlayerPrefs.SetInt("Dance", 0);
					PlayerPrefs.SetInt("Genocide", 0);
					PlayerPrefs.SetInt("Headmaster", 0);
					PlayerPrefs.SetInt("Journalist", 0);
					PlayerPrefs.SetInt("LifeNote", 0);
					PlayerPrefs.SetInt("Maid", 0);
					PlayerPrefs.SetInt("Mission", 0);
					PlayerPrefs.SetInt("Miyuki", 0);
					PlayerPrefs.SetInt("Basement", 0);
					PlayerPrefs.SetInt("Panther", 0);
					PlayerPrefs.SetInt("Selene", 0);
					PlayerPrefs.SetInt("SNAP", 0);
					PlayerPrefs.SetInt("Yakuza", 0);
					PlayerPrefs.SetInt("Yanvania", 0);
				}
				SceneManager.LoadScene("ResolutionScene");
			}
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			ResetConfirmations();
		}
		Icons.localPosition = Vector3.Lerp(Icons.localPosition, new Vector3(0f, Offset * 100, 0f), Time.deltaTime * 10f);
	}

	private void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(-350f + (float)Column * 100f, 100f - (float)Row * 100f, Highlight.localPosition.z);
		GetIndex();
		ItemNameLabel.text = ItemNames[Selected];
		ItemDescLabel.text = ItemDescs[Selected];
	}

	public void GetIndex()
	{
		Selected = Column + (Row + Offset) * Columns + 1;
	}

	private void ResetConfirmations()
	{
		ResetLabel.text = "Are you ABSOLUTELY CERTAIN that you want to reset your Demo Checklist progress?\n\nMash the Confirm button 10 times to reaffirm this decision.";
		ResetWindow.SetActive(value: false);
		DeletingGlobals = false;
		PromptBar.Show = true;
		Confirmations = 0;
		ConfirmBlocks[1].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[2].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[3].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[4].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[5].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[6].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[7].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[8].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[9].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[10].color = new Color(1f, 1f, 1f, 0.5f);
	}

	private void RememberChecklistProgress()
	{
		Checklist[0] = PlayerPrefs.GetInt("Attack");
		Checklist[1] = PlayerPrefs.GetInt("Befriend");
		Checklist[2] = PlayerPrefs.GetInt("Betray");
		Checklist[3] = PlayerPrefs.GetInt("Bully");
		Checklist[4] = PlayerPrefs.GetInt("Burn");
		Checklist[5] = PlayerPrefs.GetInt("Crush");
		Checklist[6] = PlayerPrefs.GetInt("Drown");
		Checklist[7] = PlayerPrefs.GetInt("Electrocute");
		Checklist[8] = PlayerPrefs.GetInt("Expel");
		Checklist[9] = PlayerPrefs.GetInt("Fan");
		Checklist[10] = PlayerPrefs.GetInt("Frame");
		Checklist[11] = PlayerPrefs.GetInt("Kidnap");
		Checklist[12] = PlayerPrefs.GetInt("Matchmake");
		Checklist[13] = PlayerPrefs.GetInt("MurderSuicide");
		Checklist[14] = PlayerPrefs.GetInt("Poison");
		Checklist[15] = PlayerPrefs.GetInt("Pool");
		Checklist[16] = PlayerPrefs.GetInt("Push");
		Checklist[17] = PlayerPrefs.GetInt("Reject");
		Checklist[18] = PlayerPrefs.GetInt("Suicide");
		Checklist[19] = PlayerPrefs.GetInt("DrivenToMurder");
		Checklist[20] = PlayerPrefs.GetInt("HeadHunter");
		Checklist[21] = PlayerPrefs.GetInt("PantyQueen");
		Checklist[22] = PlayerPrefs.GetInt("RichGirl");
		Checklist[23] = PlayerPrefs.GetInt("WeaponMaster");
		Checklist[24] = PlayerPrefs.GetInt("HeadsHunted");
		Checklist[25] = PlayerPrefs.GetInt("Alphabet");
		Checklist[26] = PlayerPrefs.GetInt("Amai");
		Checklist[27] = PlayerPrefs.GetInt("Dance");
		Checklist[28] = PlayerPrefs.GetInt("Genocide");
		Checklist[29] = PlayerPrefs.GetInt("Headmaster");
		Checklist[30] = PlayerPrefs.GetInt("Journalist");
		Checklist[31] = PlayerPrefs.GetInt("LifeNote");
		Checklist[32] = PlayerPrefs.GetInt("Maid");
		Checklist[33] = PlayerPrefs.GetInt("Mission");
		Checklist[34] = PlayerPrefs.GetInt("Miyuki");
		Checklist[35] = PlayerPrefs.GetInt("Basement");
		Checklist[36] = PlayerPrefs.GetInt("Panther");
		Checklist[37] = PlayerPrefs.GetInt("Selene");
		Checklist[38] = PlayerPrefs.GetInt("SNAP");
		Checklist[39] = PlayerPrefs.GetInt("Yakuza");
		Checklist[40] = PlayerPrefs.GetInt("Yanvania");
	}

	private void RecallChecklistProgress()
	{
		PlayerPrefs.SetInt("Attack", Checklist[0]);
		PlayerPrefs.SetInt("Befriend", Checklist[1]);
		PlayerPrefs.SetInt("Betray", Checklist[2]);
		PlayerPrefs.SetInt("Bully", Checklist[3]);
		PlayerPrefs.SetInt("Burn", Checklist[4]);
		PlayerPrefs.SetInt("Crush", Checklist[5]);
		PlayerPrefs.SetInt("Drown", Checklist[6]);
		PlayerPrefs.SetInt("Electrocute", Checklist[7]);
		PlayerPrefs.SetInt("Expel", Checklist[8]);
		PlayerPrefs.SetInt("Fan", Checklist[9]);
		PlayerPrefs.SetInt("Frame", Checklist[10]);
		PlayerPrefs.SetInt("Kidnap", Checklist[11]);
		PlayerPrefs.SetInt("Matchmake", Checklist[12]);
		PlayerPrefs.SetInt("MurderSuicide", Checklist[13]);
		PlayerPrefs.SetInt("Poison", Checklist[14]);
		PlayerPrefs.SetInt("Pool", Checklist[15]);
		PlayerPrefs.SetInt("Push", Checklist[16]);
		PlayerPrefs.SetInt("Reject", Checklist[17]);
		PlayerPrefs.SetInt("Suicide", Checklist[18]);
		PlayerPrefs.SetInt("DrivenToMurder", Checklist[19]);
		PlayerPrefs.SetInt("HeadHunter", Checklist[20]);
		PlayerPrefs.SetInt("PantyQueen", Checklist[21]);
		PlayerPrefs.SetInt("RichGirl", Checklist[22]);
		PlayerPrefs.SetInt("WeaponMaster", Checklist[23]);
		PlayerPrefs.SetInt("HeadsHunted", Checklist[24]);
		PlayerPrefs.SetInt("Alphabet", Checklist[25]);
		PlayerPrefs.SetInt("Amai", Checklist[26]);
		PlayerPrefs.SetInt("Dance", Checklist[27]);
		PlayerPrefs.SetInt("Genocide", Checklist[28]);
		PlayerPrefs.SetInt("Headmaster", Checklist[29]);
		PlayerPrefs.SetInt("Journalist", Checklist[30]);
		PlayerPrefs.SetInt("LifeNote", Checklist[31]);
		PlayerPrefs.SetInt("Maid", Checklist[32]);
		PlayerPrefs.SetInt("Mission", Checklist[33]);
		PlayerPrefs.SetInt("Miyuki", Checklist[34]);
		PlayerPrefs.SetInt("Basement", Checklist[35]);
		PlayerPrefs.SetInt("Panther", Checklist[36]);
		PlayerPrefs.SetInt("Selene", Checklist[37]);
		PlayerPrefs.SetInt("SNAP", Checklist[38]);
		PlayerPrefs.SetInt("Yakuza", Checklist[39]);
		PlayerPrefs.SetInt("Yanvania", Checklist[40]);
	}
}
