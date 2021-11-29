using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001EA6 RID: 7846 RVA: 0x001ADE85 File Offset: 0x001AC085
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001EA7 RID: 7847 RVA: 0x001ADE9A File Offset: 0x001AC09A
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001EA8 RID: 7848 RVA: 0x001ADEB0 File Offset: 0x001AC0B0
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001EA9 RID: 7849 RVA: 0x001ADEC4 File Offset: 0x001AC0C4
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

	// Token: 0x06001EAA RID: 7850 RVA: 0x001AE0CC File Offset: 0x001AC2CC
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001EAB RID: 7851 RVA: 0x001AE138 File Offset: 0x001AC338
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

	// Token: 0x04003F80 RID: 16256
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003F81 RID: 16257
	public InputManagerScript InputManager;

	// Token: 0x04003F82 RID: 16258
	public PromptBarScript PromptBar;

	// Token: 0x04003F83 RID: 16259
	public string[] SponsorURLs;

	// Token: 0x04003F84 RID: 16260
	public string[] Sponsors;

	// Token: 0x04003F85 RID: 16261
	public UILabel SponsorName;

	// Token: 0x04003F86 RID: 16262
	public Transform Highlight;

	// Token: 0x04003F87 RID: 16263
	public bool Show;

	// Token: 0x04003F88 RID: 16264
	public int Columns;

	// Token: 0x04003F89 RID: 16265
	public int Rows;

	// Token: 0x04003F8A RID: 16266
	private int Column;

	// Token: 0x04003F8B RID: 16267
	private int Row;

	// Token: 0x04003F8C RID: 16268
	public UISprite BlackSprite;

	// Token: 0x04003F8D RID: 16269
	public UISprite[] RedSprites;

	// Token: 0x04003F8E RID: 16270
	public UILabel[] Labels;
}
