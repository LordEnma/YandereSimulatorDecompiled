using System;
using UnityEngine;

// Token: 0x02000412 RID: 1042
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C49 RID: 7241 RVA: 0x00148F98 File Offset: 0x00147198
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

	// Token: 0x06001C4A RID: 7242 RVA: 0x00149010 File Offset: 0x00147210
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

	// Token: 0x0400322D RID: 12845
	public PromptBarScript PromptBar;

	// Token: 0x0400322E RID: 12846
	public PromptScript Prompt;

	// Token: 0x0400322F RID: 12847
	public UILabel NewspaperLabel;

	// Token: 0x04003230 RID: 12848
	public GameObject[] NewspaperPages;

	// Token: 0x04003231 RID: 12849
	public GameObject ClubPosters;

	// Token: 0x04003232 RID: 12850
	public GameObject Newspaper;

	// Token: 0x04003233 RID: 12851
	public string[] Article;

	// Token: 0x04003234 RID: 12852
	public int GameplayDay;

	// Token: 0x04003235 RID: 12853
	public bool Show;
}
