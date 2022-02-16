using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001ECC RID: 7884 RVA: 0x001B1599 File Offset: 0x001AF799
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001ECD RID: 7885 RVA: 0x001B15AE File Offset: 0x001AF7AE
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001ECE RID: 7886 RVA: 0x001B15C4 File Offset: 0x001AF7C4
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001ECF RID: 7887 RVA: 0x001B15D8 File Offset: 0x001AF7D8
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

	// Token: 0x06001ED0 RID: 7888 RVA: 0x001B17E0 File Offset: 0x001AF9E0
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001ED1 RID: 7889 RVA: 0x001B184C File Offset: 0x001AFA4C
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

	// Token: 0x04003FEC RID: 16364
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FED RID: 16365
	public InputManagerScript InputManager;

	// Token: 0x04003FEE RID: 16366
	public PromptBarScript PromptBar;

	// Token: 0x04003FEF RID: 16367
	public string[] SponsorURLs;

	// Token: 0x04003FF0 RID: 16368
	public string[] Sponsors;

	// Token: 0x04003FF1 RID: 16369
	public UILabel SponsorName;

	// Token: 0x04003FF2 RID: 16370
	public Transform Highlight;

	// Token: 0x04003FF3 RID: 16371
	public bool Show;

	// Token: 0x04003FF4 RID: 16372
	public int Columns;

	// Token: 0x04003FF5 RID: 16373
	public int Rows;

	// Token: 0x04003FF6 RID: 16374
	private int Column;

	// Token: 0x04003FF7 RID: 16375
	private int Row;

	// Token: 0x04003FF8 RID: 16376
	public UISprite BlackSprite;

	// Token: 0x04003FF9 RID: 16377
	public UISprite[] RedSprites;

	// Token: 0x04003FFA RID: 16378
	public UILabel[] Labels;
}
