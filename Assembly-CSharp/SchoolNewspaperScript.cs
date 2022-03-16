using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C6D RID: 7277 RVA: 0x0014CEC8 File Offset: 0x0014B0C8
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

	// Token: 0x06001C6E RID: 7278 RVA: 0x0014CF40 File Offset: 0x0014B140
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

	// Token: 0x0400329C RID: 12956
	public PromptBarScript PromptBar;

	// Token: 0x0400329D RID: 12957
	public PromptScript Prompt;

	// Token: 0x0400329E RID: 12958
	public UILabel NewspaperLabel;

	// Token: 0x0400329F RID: 12959
	public GameObject[] NewspaperPages;

	// Token: 0x040032A0 RID: 12960
	public GameObject ClubPosters;

	// Token: 0x040032A1 RID: 12961
	public GameObject Newspaper;

	// Token: 0x040032A2 RID: 12962
	public string[] Article;

	// Token: 0x040032A3 RID: 12963
	public int GameplayDay;

	// Token: 0x040032A4 RID: 12964
	public bool Show;
}
