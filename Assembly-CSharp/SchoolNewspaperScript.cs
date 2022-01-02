using System;
using UnityEngine;

// Token: 0x02000410 RID: 1040
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C42 RID: 7234 RVA: 0x00148C24 File Offset: 0x00146E24
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

	// Token: 0x06001C43 RID: 7235 RVA: 0x00148C9C File Offset: 0x00146E9C
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

	// Token: 0x04003227 RID: 12839
	public PromptBarScript PromptBar;

	// Token: 0x04003228 RID: 12840
	public PromptScript Prompt;

	// Token: 0x04003229 RID: 12841
	public UILabel NewspaperLabel;

	// Token: 0x0400322A RID: 12842
	public GameObject[] NewspaperPages;

	// Token: 0x0400322B RID: 12843
	public GameObject ClubPosters;

	// Token: 0x0400322C RID: 12844
	public GameObject Newspaper;

	// Token: 0x0400322D RID: 12845
	public string[] Article;

	// Token: 0x0400322E RID: 12846
	public int GameplayDay;

	// Token: 0x0400322F RID: 12847
	public bool Show;
}
