using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C88 RID: 7304 RVA: 0x0014E8E8 File Offset: 0x0014CAE8
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

	// Token: 0x06001C89 RID: 7305 RVA: 0x0014E960 File Offset: 0x0014CB60
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

	// Token: 0x040032D5 RID: 13013
	public PromptBarScript PromptBar;

	// Token: 0x040032D6 RID: 13014
	public PromptScript Prompt;

	// Token: 0x040032D7 RID: 13015
	public UILabel NewspaperLabel;

	// Token: 0x040032D8 RID: 13016
	public GameObject[] NewspaperPages;

	// Token: 0x040032D9 RID: 13017
	public GameObject ClubPosters;

	// Token: 0x040032DA RID: 13018
	public GameObject Newspaper;

	// Token: 0x040032DB RID: 13019
	public string[] Article;

	// Token: 0x040032DC RID: 13020
	public int GameplayDay;

	// Token: 0x040032DD RID: 13021
	public bool Show;
}
