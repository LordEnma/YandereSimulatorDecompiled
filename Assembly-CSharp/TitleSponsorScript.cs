using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001ED5 RID: 7893 RVA: 0x001B20E5 File Offset: 0x001B02E5
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001ED6 RID: 7894 RVA: 0x001B20FA File Offset: 0x001B02FA
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001ED7 RID: 7895 RVA: 0x001B2110 File Offset: 0x001B0310
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001ED8 RID: 7896 RVA: 0x001B2124 File Offset: 0x001B0324
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

	// Token: 0x06001ED9 RID: 7897 RVA: 0x001B232C File Offset: 0x001B052C
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001EDA RID: 7898 RVA: 0x001B2398 File Offset: 0x001B0598
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

	// Token: 0x04003FFC RID: 16380
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FFD RID: 16381
	public InputManagerScript InputManager;

	// Token: 0x04003FFE RID: 16382
	public PromptBarScript PromptBar;

	// Token: 0x04003FFF RID: 16383
	public string[] SponsorURLs;

	// Token: 0x04004000 RID: 16384
	public string[] Sponsors;

	// Token: 0x04004001 RID: 16385
	public UILabel SponsorName;

	// Token: 0x04004002 RID: 16386
	public Transform Highlight;

	// Token: 0x04004003 RID: 16387
	public bool Show;

	// Token: 0x04004004 RID: 16388
	public int Columns;

	// Token: 0x04004005 RID: 16389
	public int Rows;

	// Token: 0x04004006 RID: 16390
	private int Column;

	// Token: 0x04004007 RID: 16391
	private int Row;

	// Token: 0x04004008 RID: 16392
	public UISprite BlackSprite;

	// Token: 0x04004009 RID: 16393
	public UISprite[] RedSprites;

	// Token: 0x0400400A RID: 16394
	public UILabel[] Labels;
}
