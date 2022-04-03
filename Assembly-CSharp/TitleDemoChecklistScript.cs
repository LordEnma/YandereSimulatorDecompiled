using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200047B RID: 1147
public class TitleDemoChecklistScript : MonoBehaviour
{
	// Token: 0x06001EE2 RID: 7906 RVA: 0x001B3D60 File Offset: 0x001B1F60
	private void Start()
	{
		this.UpdateHighlight();
		if (PlayerPrefs.GetInt("Attack") == 1)
		{
			this.Items[1].mainTexture = this.ItemTextures[1];
		}
		if (PlayerPrefs.GetInt("Befriend") == 1)
		{
			this.Items[2].mainTexture = this.ItemTextures[2];
		}
		if (PlayerPrefs.GetInt("Betray") == 1)
		{
			this.Items[3].mainTexture = this.ItemTextures[3];
		}
		if (PlayerPrefs.GetInt("Bully") == 1)
		{
			this.Items[4].mainTexture = this.ItemTextures[4];
		}
		if (PlayerPrefs.GetInt("Burn") == 1)
		{
			this.Items[5].mainTexture = this.ItemTextures[5];
		}
		if (PlayerPrefs.GetInt("Crush") == 1)
		{
			this.Items[6].mainTexture = this.ItemTextures[6];
		}
		if (PlayerPrefs.GetInt("Drown") == 1)
		{
			this.Items[7].mainTexture = this.ItemTextures[7];
		}
		if (PlayerPrefs.GetInt("Electrocute") == 1)
		{
			this.Items[8].mainTexture = this.ItemTextures[8];
		}
		if (PlayerPrefs.GetInt("Expel") == 1)
		{
			this.Items[9].mainTexture = this.ItemTextures[9];
		}
		if (PlayerPrefs.GetInt("Fan") == 1)
		{
			this.Items[10].mainTexture = this.ItemTextures[10];
		}
		if (PlayerPrefs.GetInt("Frame") == 1)
		{
			this.Items[11].mainTexture = this.ItemTextures[11];
		}
		if (PlayerPrefs.GetInt("Kidnap") == 1)
		{
			this.Items[12].mainTexture = this.ItemTextures[12];
		}
		if (PlayerPrefs.GetInt("Matchmake") == 1)
		{
			this.Items[13].mainTexture = this.ItemTextures[13];
		}
		if (PlayerPrefs.GetInt("MurderSuicide") == 1)
		{
			this.Items[14].mainTexture = this.ItemTextures[14];
		}
		if (PlayerPrefs.GetInt("Poison") == 1)
		{
			this.Items[15].mainTexture = this.ItemTextures[15];
		}
		if (PlayerPrefs.GetInt("Pool") == 1)
		{
			this.Items[16].mainTexture = this.ItemTextures[16];
		}
		if (PlayerPrefs.GetInt("Push") == 1)
		{
			this.Items[17].mainTexture = this.ItemTextures[17];
		}
		if (PlayerPrefs.GetInt("Reject") == 1)
		{
			this.Items[18].mainTexture = this.ItemTextures[18];
		}
		if (PlayerPrefs.GetInt("Suicide") == 1)
		{
			this.Items[19].mainTexture = this.ItemTextures[19];
		}
		if (PlayerPrefs.GetInt("DrivenToMurder") == 1)
		{
			this.Items[20].mainTexture = this.ItemTextures[20];
		}
		if (PlayerPrefs.GetInt("HeadHunter") > 9)
		{
			this.Items[21].mainTexture = this.ItemTextures[21];
		}
		if (PlayerPrefs.GetInt("PantyQueen") == 1)
		{
			this.Items[22].mainTexture = this.ItemTextures[22];
		}
		if (PlayerPrefs.GetInt("RichGirl") == 1)
		{
			this.Items[23].mainTexture = this.ItemTextures[23];
		}
		if (PlayerPrefs.GetInt("WeaponMaster") == 1)
		{
			this.Items[24].mainTexture = this.ItemTextures[24];
		}
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x001B40C4 File Offset: 0x001B22C4
	public void GetIndex()
	{
		this.Selected = this.Column + this.Row * this.Columns + 1;
	}

	// Token: 0x06001EE4 RID: 7908 RVA: 0x001B40E4 File Offset: 0x001B22E4
	private void Update()
	{
		if (this.Zoom)
		{
			if (!this.Shrink)
			{
				this.Items[this.Selected].transform.localPosition = Vector3.Lerp(this.Items[this.Selected].transform.localPosition, new Vector3(0f, 25f, 0f), Time.deltaTime * 10f);
				this.Items[this.Selected].transform.localScale = Vector3.Lerp(this.Items[this.Selected].transform.localScale, Vector3.one, Time.deltaTime * 10f);
				if (Input.GetButtonDown("B"))
				{
					this.Items[this.Selected].depth = 0;
					this.Shrink = true;
					return;
				}
			}
			else
			{
				this.Items[this.Selected].transform.localPosition = Vector3.Lerp(this.Items[this.Selected].transform.localPosition, this.OriginalPosition, Time.deltaTime * 10f);
				this.Items[this.Selected].transform.localScale = Vector3.Lerp(this.Items[this.Selected].transform.localScale, new Vector3(0.195f, 0.195f, 0.195f), Time.deltaTime * 10f);
				if (this.Items[this.Selected].transform.localScale.x < 0.2f)
				{
					this.Items[this.Selected].transform.localPosition = this.OriginalPosition;
					this.Items[this.Selected].transform.localScale = new Vector3(0.195f, 0.195f, 0.195f);
					this.Shrink = false;
					this.Zoom = false;
					return;
				}
			}
		}
		else if (!this.ResetWindow.activeInHierarchy)
		{
			if (this.InputManager.TappedUp)
			{
				this.Row = ((this.Row > 0) ? (this.Row - 1) : (this.Rows - 1));
			}
			if (this.InputManager.TappedDown)
			{
				this.Row = ((this.Row < this.Rows - 1) ? (this.Row + 1) : 0);
			}
			if (this.InputManager.TappedRight)
			{
				this.Column = ((this.Column < this.Columns - 1) ? (this.Column + 1) : 0);
			}
			if (this.InputManager.TappedLeft)
			{
				this.Column = ((this.Column > 0) ? (this.Column - 1) : (this.Columns - 1));
			}
			if (this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				this.UpdateHighlight();
			}
			if (this.NewTitleScreen.Speed > 3f)
			{
				if (!this.PromptBar.Show)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "View Image";
					this.PromptBar.Label[1].text = "Go Back";
					this.PromptBar.Label[2].text = "Reset Progress";
					this.PromptBar.Label[4].text = "Change Selection";
					this.PromptBar.Label[5].text = "Change Selection";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
				}
				if (Input.GetButtonDown("A"))
				{
					this.OriginalPosition = this.Items[this.Selected].transform.localPosition;
					this.Items[this.Selected].depth = 2;
					this.Zoom = true;
					return;
				}
				if (Input.GetButtonDown("X"))
				{
					this.ResetWindow.SetActive(true);
					return;
				}
				if (Input.GetButtonDown("B"))
				{
					this.NewTitleScreen.Speed = 0f;
					this.NewTitleScreen.Phase = 2;
					this.PromptBar.Show = false;
					base.enabled = false;
					return;
				}
				if (Input.GetKeyDown("r"))
				{
					this.ResetLabel.text = "This is a hidden debug command for completely removing all Yandere Simulator data from your computer's registry. This command will delete all of your save data, but may fix certain types of bugs that cannot be fixed in any other way.";
					this.DeletingGlobals = true;
					this.ResetWindow.SetActive(true);
					return;
				}
			}
		}
		else if (Input.GetButtonDown("A"))
		{
			this.Confirmations++;
			this.ConfirmBlocks[this.Confirmations].color = new Color(1f, 1f, 1f, 1f);
			if (this.Confirmations == 10)
			{
				if (this.DeletingGlobals)
				{
					PlayerPrefs.DeleteAll();
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
				}
				SceneManager.LoadScene("NewTitleScene");
				return;
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.ResetConfirmations();
		}
	}

	// Token: 0x06001EE5 RID: 7909 RVA: 0x001B46F8 File Offset: 0x001B28F8
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-350f + (float)this.Column * 100f, 100f - (float)this.Row * 100f, this.Highlight.localPosition.z);
		this.GetIndex();
		this.ItemNameLabel.text = this.ItemNames[this.Selected];
		this.ItemDescLabel.text = this.ItemDescs[this.Selected];
	}

	// Token: 0x06001EE6 RID: 7910 RVA: 0x001B4784 File Offset: 0x001B2984
	private void ResetConfirmations()
	{
		this.ResetLabel.text = "Are you ABSOLUTELY CERTAIN that you want to reset your Demo Checklist progress?\n\nMash the Confirm button 10 times to reaffirm this decision.";
		this.ResetWindow.SetActive(false);
		this.DeletingGlobals = false;
		this.PromptBar.Show = true;
		this.Confirmations = 0;
		this.ConfirmBlocks[1].color = new Color(1f, 1f, 1f, 0.5f);
		this.ConfirmBlocks[2].color = new Color(1f, 1f, 1f, 0.5f);
		this.ConfirmBlocks[3].color = new Color(1f, 1f, 1f, 0.5f);
		this.ConfirmBlocks[4].color = new Color(1f, 1f, 1f, 0.5f);
		this.ConfirmBlocks[5].color = new Color(1f, 1f, 1f, 0.5f);
		this.ConfirmBlocks[6].color = new Color(1f, 1f, 1f, 0.5f);
		this.ConfirmBlocks[7].color = new Color(1f, 1f, 1f, 0.5f);
		this.ConfirmBlocks[8].color = new Color(1f, 1f, 1f, 0.5f);
		this.ConfirmBlocks[9].color = new Color(1f, 1f, 1f, 0.5f);
		this.ConfirmBlocks[10].color = new Color(1f, 1f, 1f, 0.5f);
	}

	// Token: 0x0400401B RID: 16411
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x0400401C RID: 16412
	public InputManagerScript InputManager;

	// Token: 0x0400401D RID: 16413
	public PromptBarScript PromptBar;

	// Token: 0x0400401E RID: 16414
	public UISprite[] ConfirmBlocks;

	// Token: 0x0400401F RID: 16415
	public string[] ItemNames;

	// Token: 0x04004020 RID: 16416
	public string[] ItemDescs;

	// Token: 0x04004021 RID: 16417
	public UILabel ItemNameLabel;

	// Token: 0x04004022 RID: 16418
	public UILabel ItemDescLabel;

	// Token: 0x04004023 RID: 16419
	public UILabel ResetLabel;

	// Token: 0x04004024 RID: 16420
	public Vector3 OriginalPosition;

	// Token: 0x04004025 RID: 16421
	public GameObject ResetWindow;

	// Token: 0x04004026 RID: 16422
	public Transform Highlight;

	// Token: 0x04004027 RID: 16423
	public bool DeletingGlobals;

	// Token: 0x04004028 RID: 16424
	public bool Shrink;

	// Token: 0x04004029 RID: 16425
	public bool Show;

	// Token: 0x0400402A RID: 16426
	public bool Zoom;

	// Token: 0x0400402B RID: 16427
	public int Confirmations;

	// Token: 0x0400402C RID: 16428
	public int Columns;

	// Token: 0x0400402D RID: 16429
	public int Rows;

	// Token: 0x0400402E RID: 16430
	private int Column;

	// Token: 0x0400402F RID: 16431
	private int Row;

	// Token: 0x04004030 RID: 16432
	private int Selected = 1;

	// Token: 0x04004031 RID: 16433
	public UITexture[] Items;

	// Token: 0x04004032 RID: 16434
	public Texture[] ItemTextures;
}
