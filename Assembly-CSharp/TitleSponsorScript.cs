using System;
using UnityEngine;

// Token: 0x02000483 RID: 1155
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001F15 RID: 7957 RVA: 0x001B8E25 File Offset: 0x001B7025
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x001B8E3A File Offset: 0x001B703A
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001F17 RID: 7959 RVA: 0x001B8E50 File Offset: 0x001B7050
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x001B8E64 File Offset: 0x001B7064
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

	// Token: 0x06001F19 RID: 7961 RVA: 0x001B906C File Offset: 0x001B726C
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B90D8 File Offset: 0x001B72D8
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

	// Token: 0x040040DB RID: 16603
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x040040DC RID: 16604
	public InputManagerScript InputManager;

	// Token: 0x040040DD RID: 16605
	public PromptBarScript PromptBar;

	// Token: 0x040040DE RID: 16606
	public string[] SponsorURLs;

	// Token: 0x040040DF RID: 16607
	public string[] Sponsors;

	// Token: 0x040040E0 RID: 16608
	public UILabel SponsorName;

	// Token: 0x040040E1 RID: 16609
	public Transform Highlight;

	// Token: 0x040040E2 RID: 16610
	public bool Show;

	// Token: 0x040040E3 RID: 16611
	public int Columns;

	// Token: 0x040040E4 RID: 16612
	public int Rows;

	// Token: 0x040040E5 RID: 16613
	private int Column;

	// Token: 0x040040E6 RID: 16614
	private int Row;

	// Token: 0x040040E7 RID: 16615
	public UISprite BlackSprite;

	// Token: 0x040040E8 RID: 16616
	public UISprite[] RedSprites;

	// Token: 0x040040E9 RID: 16617
	public UILabel[] Labels;
}
