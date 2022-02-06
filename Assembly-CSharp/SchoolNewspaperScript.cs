﻿using System;
using UnityEngine;

// Token: 0x02000413 RID: 1043
public class SchoolNewspaperScript : MonoBehaviour
{
	// Token: 0x06001C4E RID: 7246 RVA: 0x0014AD70 File Offset: 0x00148F70
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

	// Token: 0x06001C4F RID: 7247 RVA: 0x0014ADE8 File Offset: 0x00148FE8
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

	// Token: 0x0400323C RID: 12860
	public PromptBarScript PromptBar;

	// Token: 0x0400323D RID: 12861
	public PromptScript Prompt;

	// Token: 0x0400323E RID: 12862
	public UILabel NewspaperLabel;

	// Token: 0x0400323F RID: 12863
	public GameObject[] NewspaperPages;

	// Token: 0x04003240 RID: 12864
	public GameObject ClubPosters;

	// Token: 0x04003241 RID: 12865
	public GameObject Newspaper;

	// Token: 0x04003242 RID: 12866
	public string[] Article;

	// Token: 0x04003243 RID: 12867
	public int GameplayDay;

	// Token: 0x04003244 RID: 12868
	public bool Show;
}
