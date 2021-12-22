using System;
using UnityEngine;

// Token: 0x02000410 RID: 1040
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C40 RID: 7232 RVA: 0x0014881C File Offset: 0x00146A1C
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

	// Token: 0x06001C41 RID: 7233 RVA: 0x00148894 File Offset: 0x00146A94
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

	// Token: 0x04003220 RID: 12832
	public PromptBarScript PromptBar;

	// Token: 0x04003221 RID: 12833
	public PromptScript Prompt;

	// Token: 0x04003222 RID: 12834
	public UILabel NewspaperLabel;

	// Token: 0x04003223 RID: 12835
	public GameObject[] NewspaperPages;

	// Token: 0x04003224 RID: 12836
	public GameObject ClubPosters;

	// Token: 0x04003225 RID: 12837
	public GameObject Newspaper;

	// Token: 0x04003226 RID: 12838
	public string[] Article;

	// Token: 0x04003227 RID: 12839
	public int GameplayDay;

	// Token: 0x04003228 RID: 12840
	public bool Show;
}
