using System;
using UnityEngine;

// Token: 0x0200047D RID: 1149
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001EEA RID: 7914 RVA: 0x001B3F5D File Offset: 0x001B215D
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001EEB RID: 7915 RVA: 0x001B3F72 File Offset: 0x001B2172
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001EEC RID: 7916 RVA: 0x001B3F88 File Offset: 0x001B2188
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001EED RID: 7917 RVA: 0x001B3F9C File Offset: 0x001B219C
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

	// Token: 0x06001EEE RID: 7918 RVA: 0x001B41A4 File Offset: 0x001B23A4
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001EEF RID: 7919 RVA: 0x001B4210 File Offset: 0x001B2410
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

	// Token: 0x0400405E RID: 16478
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x0400405F RID: 16479
	public InputManagerScript InputManager;

	// Token: 0x04004060 RID: 16480
	public PromptBarScript PromptBar;

	// Token: 0x04004061 RID: 16481
	public string[] SponsorURLs;

	// Token: 0x04004062 RID: 16482
	public string[] Sponsors;

	// Token: 0x04004063 RID: 16483
	public UILabel SponsorName;

	// Token: 0x04004064 RID: 16484
	public Transform Highlight;

	// Token: 0x04004065 RID: 16485
	public bool Show;

	// Token: 0x04004066 RID: 16486
	public int Columns;

	// Token: 0x04004067 RID: 16487
	public int Rows;

	// Token: 0x04004068 RID: 16488
	private int Column;

	// Token: 0x04004069 RID: 16489
	private int Row;

	// Token: 0x0400406A RID: 16490
	public UISprite BlackSprite;

	// Token: 0x0400406B RID: 16491
	public UISprite[] RedSprites;

	// Token: 0x0400406C RID: 16492
	public UILabel[] Labels;
}
