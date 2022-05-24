using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C8F RID: 7311 RVA: 0x0014F858 File Offset: 0x0014DA58
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

	// Token: 0x06001C90 RID: 7312 RVA: 0x0014F8D0 File Offset: 0x0014DAD0
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

	// Token: 0x040032F2 RID: 13042
	public PromptBarScript PromptBar;

	// Token: 0x040032F3 RID: 13043
	public PromptScript Prompt;

	// Token: 0x040032F4 RID: 13044
	public UILabel NewspaperLabel;

	// Token: 0x040032F5 RID: 13045
	public GameObject[] NewspaperPages;

	// Token: 0x040032F6 RID: 13046
	public GameObject ClubPosters;

	// Token: 0x040032F7 RID: 13047
	public GameObject Newspaper;

	// Token: 0x040032F8 RID: 13048
	public string[] Article;

	// Token: 0x040032F9 RID: 13049
	public int GameplayDay;

	// Token: 0x040032FA RID: 13050
	public bool Show;
}
