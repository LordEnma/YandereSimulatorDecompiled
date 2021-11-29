using System;
using UnityEngine;

// Token: 0x0200040F RID: 1039
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C38 RID: 7224 RVA: 0x00147F40 File Offset: 0x00146140
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			this.ClubPosters.SetActive(false);
			if (ClubGlobals.GetClubClosed(ClubType.Newspaper))
			{
				this.NewspaperPages[1].SetActive(false);
				this.NewspaperPages[2].SetActive(false);
				this.NewspaperPages[3].SetActive(false);
				this.Prompt.enabled = false;
				this.Prompt.Hide();
				return;
			}
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001C39 RID: 7225 RVA: 0x00147FB8 File Offset: 0x001461B8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.Newspaper.SetActive(true);
			this.GameplayDay = (int)((DateGlobals.Week - 1) * 5 + DateGlobals.Weekday);
			this.NewspaperLabel.text = this.Article[this.GameplayDay];
			this.NewspaperLabel.text = this.NewspaperLabel.text.Replace('@', '\n');
			if (this.NewspaperLabel.text == "")
			{
				this.NewspaperLabel.text = "Whoops! Sorry, this article is coming in a future update.";
			}
			Time.timeScale = 0f;
			this.Show = true;
		}
		if (this.Show && Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Show = false;
			this.Newspaper.SetActive(false);
			Time.timeScale = 1f;
		}
	}

	// Token: 0x040031F5 RID: 12789
	public PromptBarScript PromptBar;

	// Token: 0x040031F6 RID: 12790
	public PromptScript Prompt;

	// Token: 0x040031F7 RID: 12791
	public UILabel NewspaperLabel;

	// Token: 0x040031F8 RID: 12792
	public GameObject[] NewspaperPages;

	// Token: 0x040031F9 RID: 12793
	public GameObject ClubPosters;

	// Token: 0x040031FA RID: 12794
	public GameObject Newspaper;

	// Token: 0x040031FB RID: 12795
	public string[] Article;

	// Token: 0x040031FC RID: 12796
	public int GameplayDay;

	// Token: 0x040031FD RID: 12797
	public bool Show;
}
