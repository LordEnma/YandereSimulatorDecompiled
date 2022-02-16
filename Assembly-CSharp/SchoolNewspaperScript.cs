using System;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C55 RID: 7253 RVA: 0x0014B070 File Offset: 0x00149270
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

	// Token: 0x06001C56 RID: 7254 RVA: 0x0014B0E8 File Offset: 0x001492E8
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

	// Token: 0x04003242 RID: 12866
	public PromptBarScript PromptBar;

	// Token: 0x04003243 RID: 12867
	public PromptScript Prompt;

	// Token: 0x04003244 RID: 12868
	public UILabel NewspaperLabel;

	// Token: 0x04003245 RID: 12869
	public GameObject[] NewspaperPages;

	// Token: 0x04003246 RID: 12870
	public GameObject ClubPosters;

	// Token: 0x04003247 RID: 12871
	public GameObject Newspaper;

	// Token: 0x04003248 RID: 12872
	public string[] Article;

	// Token: 0x04003249 RID: 12873
	public int GameplayDay;

	// Token: 0x0400324A RID: 12874
	public bool Show;
}
