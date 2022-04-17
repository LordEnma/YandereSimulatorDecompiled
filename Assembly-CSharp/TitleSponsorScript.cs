using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001F02 RID: 7938 RVA: 0x001B63B1 File Offset: 0x001B45B1
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001F03 RID: 7939 RVA: 0x001B63C6 File Offset: 0x001B45C6
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001F04 RID: 7940 RVA: 0x001B63DC File Offset: 0x001B45DC
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001F05 RID: 7941 RVA: 0x001B63F0 File Offset: 0x001B45F0
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

	// Token: 0x06001F06 RID: 7942 RVA: 0x001B65F8 File Offset: 0x001B47F8
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001F07 RID: 7943 RVA: 0x001B6664 File Offset: 0x001B4864
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

	// Token: 0x0400409E RID: 16542
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x0400409F RID: 16543
	public InputManagerScript InputManager;

	// Token: 0x040040A0 RID: 16544
	public PromptBarScript PromptBar;

	// Token: 0x040040A1 RID: 16545
	public string[] SponsorURLs;

	// Token: 0x040040A2 RID: 16546
	public string[] Sponsors;

	// Token: 0x040040A3 RID: 16547
	public UILabel SponsorName;

	// Token: 0x040040A4 RID: 16548
	public Transform Highlight;

	// Token: 0x040040A5 RID: 16549
	public bool Show;

	// Token: 0x040040A6 RID: 16550
	public int Columns;

	// Token: 0x040040A7 RID: 16551
	public int Rows;

	// Token: 0x040040A8 RID: 16552
	private int Column;

	// Token: 0x040040A9 RID: 16553
	private int Row;

	// Token: 0x040040AA RID: 16554
	public UISprite BlackSprite;

	// Token: 0x040040AB RID: 16555
	public UISprite[] RedSprites;

	// Token: 0x040040AC RID: 16556
	public UILabel[] Labels;
}
