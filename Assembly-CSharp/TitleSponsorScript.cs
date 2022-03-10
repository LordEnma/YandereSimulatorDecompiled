using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001ED8 RID: 7896 RVA: 0x001B280D File Offset: 0x001B0A0D
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001ED9 RID: 7897 RVA: 0x001B2822 File Offset: 0x001B0A22
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001EDA RID: 7898 RVA: 0x001B2838 File Offset: 0x001B0A38
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001EDB RID: 7899 RVA: 0x001B284C File Offset: 0x001B0A4C
	private void Update()
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
				this.PromptBar.Label[0].text = "Make Selection";
				this.PromptBar.Label[1].text = "Go Back";
				this.PromptBar.Label[4].text = "Change Selection";
				this.PromptBar.Label[5].text = "Change Selection";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
			if (Input.GetButtonDown("A"))
			{
				int sponsorIndex = this.GetSponsorIndex();
				if (this.SponsorHasWebsite(sponsorIndex))
				{
					Application.OpenURL(this.SponsorURLs[sponsorIndex]);
				}
			}
			if (Input.GetButtonDown("B"))
			{
				this.NewTitleScreen.Speed = 0f;
				this.NewTitleScreen.Phase = 2;
				this.PromptBar.Show = false;
				base.enabled = false;
			}
		}
	}

	// Token: 0x06001EDC RID: 7900 RVA: 0x001B2A54 File Offset: 0x001B0C54
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001EDD RID: 7901 RVA: 0x001B2AC0 File Offset: 0x001B0CC0
	private void TurnLoveSick()
	{
		this.BlackSprite.color = Color.black;
		foreach (UISprite uisprite in this.RedSprites)
		{
			uisprite.color = new Color(1f, 0f, 0f, uisprite.color.a);
		}
		foreach (UILabel uilabel in this.Labels)
		{
			uilabel.color = new Color(1f, 0f, 0f, uilabel.color.a);
		}
	}

	// Token: 0x04004013 RID: 16403
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04004014 RID: 16404
	public InputManagerScript InputManager;

	// Token: 0x04004015 RID: 16405
	public PromptBarScript PromptBar;

	// Token: 0x04004016 RID: 16406
	public string[] SponsorURLs;

	// Token: 0x04004017 RID: 16407
	public string[] Sponsors;

	// Token: 0x04004018 RID: 16408
	public UILabel SponsorName;

	// Token: 0x04004019 RID: 16409
	public Transform Highlight;

	// Token: 0x0400401A RID: 16410
	public bool Show;

	// Token: 0x0400401B RID: 16411
	public int Columns;

	// Token: 0x0400401C RID: 16412
	public int Rows;

	// Token: 0x0400401D RID: 16413
	private int Column;

	// Token: 0x0400401E RID: 16414
	private int Row;

	// Token: 0x0400401F RID: 16415
	public UISprite BlackSprite;

	// Token: 0x04004020 RID: 16416
	public UISprite[] RedSprites;

	// Token: 0x04004021 RID: 16417
	public UILabel[] Labels;
}
