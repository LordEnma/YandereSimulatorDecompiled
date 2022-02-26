using System;
using UnityEngine;

// Token: 0x02000415 RID: 1045
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C5E RID: 7262 RVA: 0x0014BAE8 File Offset: 0x00149CE8
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

	// Token: 0x06001C5F RID: 7263 RVA: 0x0014BB60 File Offset: 0x00149D60
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

	// Token: 0x04003252 RID: 12882
	public PromptBarScript PromptBar;

	// Token: 0x04003253 RID: 12883
	public PromptScript Prompt;

	// Token: 0x04003254 RID: 12884
	public UILabel NewspaperLabel;

	// Token: 0x04003255 RID: 12885
	public GameObject[] NewspaperPages;

	// Token: 0x04003256 RID: 12886
	public GameObject ClubPosters;

	// Token: 0x04003257 RID: 12887
	public GameObject Newspaper;

	// Token: 0x04003258 RID: 12888
	public string[] Article;

	// Token: 0x04003259 RID: 12889
	public int GameplayDay;

	// Token: 0x0400325A RID: 12890
	public bool Show;
}
