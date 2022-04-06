using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001EFC RID: 7932 RVA: 0x001B59D9 File Offset: 0x001B3BD9
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001EFD RID: 7933 RVA: 0x001B59EE File Offset: 0x001B3BEE
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001EFE RID: 7934 RVA: 0x001B5A04 File Offset: 0x001B3C04
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001EFF RID: 7935 RVA: 0x001B5A18 File Offset: 0x001B3C18
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

	// Token: 0x06001F00 RID: 7936 RVA: 0x001B5C20 File Offset: 0x001B3E20
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001F01 RID: 7937 RVA: 0x001B5C8C File Offset: 0x001B3E8C
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

	// Token: 0x0400408E RID: 16526
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x0400408F RID: 16527
	public InputManagerScript InputManager;

	// Token: 0x04004090 RID: 16528
	public PromptBarScript PromptBar;

	// Token: 0x04004091 RID: 16529
	public string[] SponsorURLs;

	// Token: 0x04004092 RID: 16530
	public string[] Sponsors;

	// Token: 0x04004093 RID: 16531
	public UILabel SponsorName;

	// Token: 0x04004094 RID: 16532
	public Transform Highlight;

	// Token: 0x04004095 RID: 16533
	public bool Show;

	// Token: 0x04004096 RID: 16534
	public int Columns;

	// Token: 0x04004097 RID: 16535
	public int Rows;

	// Token: 0x04004098 RID: 16536
	private int Column;

	// Token: 0x04004099 RID: 16537
	private int Row;

	// Token: 0x0400409A RID: 16538
	public UISprite BlackSprite;

	// Token: 0x0400409B RID: 16539
	public UISprite[] RedSprites;

	// Token: 0x0400409C RID: 16540
	public UILabel[] Labels;
}
