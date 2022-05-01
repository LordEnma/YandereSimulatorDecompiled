using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001F0B RID: 7947 RVA: 0x001B7721 File Offset: 0x001B5921
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001F0C RID: 7948 RVA: 0x001B7736 File Offset: 0x001B5936
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x001B774C File Offset: 0x001B594C
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001F0E RID: 7950 RVA: 0x001B7760 File Offset: 0x001B5960
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

	// Token: 0x06001F0F RID: 7951 RVA: 0x001B7968 File Offset: 0x001B5B68
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001F10 RID: 7952 RVA: 0x001B79D4 File Offset: 0x001B5BD4
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

	// Token: 0x040040B4 RID: 16564
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x040040B5 RID: 16565
	public InputManagerScript InputManager;

	// Token: 0x040040B6 RID: 16566
	public PromptBarScript PromptBar;

	// Token: 0x040040B7 RID: 16567
	public string[] SponsorURLs;

	// Token: 0x040040B8 RID: 16568
	public string[] Sponsors;

	// Token: 0x040040B9 RID: 16569
	public UILabel SponsorName;

	// Token: 0x040040BA RID: 16570
	public Transform Highlight;

	// Token: 0x040040BB RID: 16571
	public bool Show;

	// Token: 0x040040BC RID: 16572
	public int Columns;

	// Token: 0x040040BD RID: 16573
	public int Rows;

	// Token: 0x040040BE RID: 16574
	private int Column;

	// Token: 0x040040BF RID: 16575
	private int Row;

	// Token: 0x040040C0 RID: 16576
	public UISprite BlackSprite;

	// Token: 0x040040C1 RID: 16577
	public UISprite[] RedSprites;

	// Token: 0x040040C2 RID: 16578
	public UILabel[] Labels;
}
