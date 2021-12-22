using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001EB0 RID: 7856 RVA: 0x001AEC55 File Offset: 0x001ACE55
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001EB1 RID: 7857 RVA: 0x001AEC6A File Offset: 0x001ACE6A
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001EB2 RID: 7858 RVA: 0x001AEC80 File Offset: 0x001ACE80
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001EB3 RID: 7859 RVA: 0x001AEC94 File Offset: 0x001ACE94
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

	// Token: 0x06001EB4 RID: 7860 RVA: 0x001AEE9C File Offset: 0x001AD09C
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001EB5 RID: 7861 RVA: 0x001AEF08 File Offset: 0x001AD108
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

	// Token: 0x04003FB0 RID: 16304
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FB1 RID: 16305
	public InputManagerScript InputManager;

	// Token: 0x04003FB2 RID: 16306
	public PromptBarScript PromptBar;

	// Token: 0x04003FB3 RID: 16307
	public string[] SponsorURLs;

	// Token: 0x04003FB4 RID: 16308
	public string[] Sponsors;

	// Token: 0x04003FB5 RID: 16309
	public UILabel SponsorName;

	// Token: 0x04003FB6 RID: 16310
	public Transform Highlight;

	// Token: 0x04003FB7 RID: 16311
	public bool Show;

	// Token: 0x04003FB8 RID: 16312
	public int Columns;

	// Token: 0x04003FB9 RID: 16313
	public int Rows;

	// Token: 0x04003FBA RID: 16314
	private int Column;

	// Token: 0x04003FBB RID: 16315
	private int Row;

	// Token: 0x04003FBC RID: 16316
	public UISprite BlackSprite;

	// Token: 0x04003FBD RID: 16317
	public UISprite[] RedSprites;

	// Token: 0x04003FBE RID: 16318
	public UILabel[] Labels;
}
