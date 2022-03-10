using System;
using UnityEngine;

// Token: 0x02000415 RID: 1045
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C60 RID: 7264 RVA: 0x0014C024 File Offset: 0x0014A224
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

	// Token: 0x06001C61 RID: 7265 RVA: 0x0014C09C File Offset: 0x0014A29C
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

	// Token: 0x04003268 RID: 12904
	public PromptBarScript PromptBar;

	// Token: 0x04003269 RID: 12905
	public PromptScript Prompt;

	// Token: 0x0400326A RID: 12906
	public UILabel NewspaperLabel;

	// Token: 0x0400326B RID: 12907
	public GameObject[] NewspaperPages;

	// Token: 0x0400326C RID: 12908
	public GameObject ClubPosters;

	// Token: 0x0400326D RID: 12909
	public GameObject Newspaper;

	// Token: 0x0400326E RID: 12910
	public string[] Article;

	// Token: 0x0400326F RID: 12911
	public int GameplayDay;

	// Token: 0x04003270 RID: 12912
	public bool Show;
}
