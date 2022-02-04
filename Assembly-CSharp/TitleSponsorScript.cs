using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001EC2 RID: 7874 RVA: 0x001B0F3D File Offset: 0x001AF13D
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001EC3 RID: 7875 RVA: 0x001B0F52 File Offset: 0x001AF152
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001EC4 RID: 7876 RVA: 0x001B0F68 File Offset: 0x001AF168
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001EC5 RID: 7877 RVA: 0x001B0F7C File Offset: 0x001AF17C
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

	// Token: 0x06001EC6 RID: 7878 RVA: 0x001B1184 File Offset: 0x001AF384
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001EC7 RID: 7879 RVA: 0x001B11F0 File Offset: 0x001AF3F0
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

	// Token: 0x04003FE0 RID: 16352
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FE1 RID: 16353
	public InputManagerScript InputManager;

	// Token: 0x04003FE2 RID: 16354
	public PromptBarScript PromptBar;

	// Token: 0x04003FE3 RID: 16355
	public string[] SponsorURLs;

	// Token: 0x04003FE4 RID: 16356
	public string[] Sponsors;

	// Token: 0x04003FE5 RID: 16357
	public UILabel SponsorName;

	// Token: 0x04003FE6 RID: 16358
	public Transform Highlight;

	// Token: 0x04003FE7 RID: 16359
	public bool Show;

	// Token: 0x04003FE8 RID: 16360
	public int Columns;

	// Token: 0x04003FE9 RID: 16361
	public int Rows;

	// Token: 0x04003FEA RID: 16362
	private int Column;

	// Token: 0x04003FEB RID: 16363
	private int Row;

	// Token: 0x04003FEC RID: 16364
	public UISprite BlackSprite;

	// Token: 0x04003FED RID: 16365
	public UISprite[] RedSprites;

	// Token: 0x04003FEE RID: 16366
	public UILabel[] Labels;
}
