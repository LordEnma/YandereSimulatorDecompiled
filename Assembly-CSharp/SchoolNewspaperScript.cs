using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C7D RID: 7293 RVA: 0x0014DCD0 File Offset: 0x0014BED0
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

	// Token: 0x06001C7E RID: 7294 RVA: 0x0014DD48 File Offset: 0x0014BF48
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

	// Token: 0x040032BB RID: 12987
	public PromptBarScript PromptBar;

	// Token: 0x040032BC RID: 12988
	public PromptScript Prompt;

	// Token: 0x040032BD RID: 12989
	public UILabel NewspaperLabel;

	// Token: 0x040032BE RID: 12990
	public GameObject[] NewspaperPages;

	// Token: 0x040032BF RID: 12991
	public GameObject ClubPosters;

	// Token: 0x040032C0 RID: 12992
	public GameObject Newspaper;

	// Token: 0x040032C1 RID: 12993
	public string[] Article;

	// Token: 0x040032C2 RID: 12994
	public int GameplayDay;

	// Token: 0x040032C3 RID: 12995
	public bool Show;
}
