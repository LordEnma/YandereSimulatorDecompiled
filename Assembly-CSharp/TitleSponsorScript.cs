using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001EF4 RID: 7924 RVA: 0x001B54D1 File Offset: 0x001B36D1
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001EF5 RID: 7925 RVA: 0x001B54E6 File Offset: 0x001B36E6
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001EF6 RID: 7926 RVA: 0x001B54FC File Offset: 0x001B36FC
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001EF7 RID: 7927 RVA: 0x001B5510 File Offset: 0x001B3710
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

	// Token: 0x06001EF8 RID: 7928 RVA: 0x001B5718 File Offset: 0x001B3918
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001EF9 RID: 7929 RVA: 0x001B5784 File Offset: 0x001B3984
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

	// Token: 0x0400408B RID: 16523
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x0400408C RID: 16524
	public InputManagerScript InputManager;

	// Token: 0x0400408D RID: 16525
	public PromptBarScript PromptBar;

	// Token: 0x0400408E RID: 16526
	public string[] SponsorURLs;

	// Token: 0x0400408F RID: 16527
	public string[] Sponsors;

	// Token: 0x04004090 RID: 16528
	public UILabel SponsorName;

	// Token: 0x04004091 RID: 16529
	public Transform Highlight;

	// Token: 0x04004092 RID: 16530
	public bool Show;

	// Token: 0x04004093 RID: 16531
	public int Columns;

	// Token: 0x04004094 RID: 16532
	public int Rows;

	// Token: 0x04004095 RID: 16533
	private int Column;

	// Token: 0x04004096 RID: 16534
	private int Row;

	// Token: 0x04004097 RID: 16535
	public UISprite BlackSprite;

	// Token: 0x04004098 RID: 16536
	public UISprite[] RedSprites;

	// Token: 0x04004099 RID: 16537
	public UILabel[] Labels;
}
