using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C81 RID: 7297 RVA: 0x0014E0E0 File Offset: 0x0014C2E0
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

	// Token: 0x06001C82 RID: 7298 RVA: 0x0014E158 File Offset: 0x0014C358
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

	// Token: 0x040032C6 RID: 12998
	public PromptBarScript PromptBar;

	// Token: 0x040032C7 RID: 12999
	public PromptScript Prompt;

	// Token: 0x040032C8 RID: 13000
	public UILabel NewspaperLabel;

	// Token: 0x040032C9 RID: 13001
	public GameObject[] NewspaperPages;

	// Token: 0x040032CA RID: 13002
	public GameObject ClubPosters;

	// Token: 0x040032CB RID: 13003
	public GameObject Newspaper;

	// Token: 0x040032CC RID: 13004
	public string[] Article;

	// Token: 0x040032CD RID: 13005
	public int GameplayDay;

	// Token: 0x040032CE RID: 13006
	public bool Show;
}
