using System;
using UnityEngine;

// Token: 0x02000483 RID: 1155
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001F14 RID: 7956 RVA: 0x001B8995 File Offset: 0x001B6B95
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x001B89AA File Offset: 0x001B6BAA
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x001B89C0 File Offset: 0x001B6BC0
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001F17 RID: 7959 RVA: 0x001B89D4 File Offset: 0x001B6BD4
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

	// Token: 0x06001F18 RID: 7960 RVA: 0x001B8BDC File Offset: 0x001B6DDC
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001F19 RID: 7961 RVA: 0x001B8C48 File Offset: 0x001B6E48
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

	// Token: 0x040040D2 RID: 16594
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x040040D3 RID: 16595
	public InputManagerScript InputManager;

	// Token: 0x040040D4 RID: 16596
	public PromptBarScript PromptBar;

	// Token: 0x040040D5 RID: 16597
	public string[] SponsorURLs;

	// Token: 0x040040D6 RID: 16598
	public string[] Sponsors;

	// Token: 0x040040D7 RID: 16599
	public UILabel SponsorName;

	// Token: 0x040040D8 RID: 16600
	public Transform Highlight;

	// Token: 0x040040D9 RID: 16601
	public bool Show;

	// Token: 0x040040DA RID: 16602
	public int Columns;

	// Token: 0x040040DB RID: 16603
	public int Rows;

	// Token: 0x040040DC RID: 16604
	private int Column;

	// Token: 0x040040DD RID: 16605
	private int Row;

	// Token: 0x040040DE RID: 16606
	public UISprite BlackSprite;

	// Token: 0x040040DF RID: 16607
	public UISprite[] RedSprites;

	// Token: 0x040040E0 RID: 16608
	public UILabel[] Labels;
}
