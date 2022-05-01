﻿using System;
using UnityEngine;

// Token: 0x020002CB RID: 715
public class FavorMenuScript : MonoBehaviour
{
	// Token: 0x060014B0 RID: 5296 RVA: 0x000CBB24 File Offset: 0x000C9D24
	private void Update()
	{
		if (!this.BountyMenu.activeInHierarchy)
		{
			if (this.InputManager.TappedRight)
			{
				this.ID++;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedLeft)
			{
				this.ID--;
				this.UpdateHighlight();
			}
			if (!this.TutorialWindow.Hide && !this.TutorialWindow.Show)
			{
				if (Input.GetButtonDown("A"))
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Accept";
					this.PromptBar.Label[1].text = "Exit";
					this.PromptBar.Label[4].text = "Choose";
					this.PromptBar.UpdateButtons();
					if (this.ID == 1)
					{
						this.SchemesMenu.UpdatePantyCount();
						this.SchemesMenu.UpdateSchemeList();
						this.SchemesMenu.UpdateSchemeInfo();
						this.SchemesMenu.gameObject.SetActive(true);
						base.gameObject.SetActive(false);
						return;
					}
					if (this.ID == 2)
					{
						this.ServicesMenu.UpdatePantyCount();
						this.ServicesMenu.UpdateList();
						this.ServicesMenu.UpdateDesc();
						this.ServicesMenu.gameObject.SetActive(true);
						base.gameObject.SetActive(false);
						return;
					}
					if (this.ID == 3)
					{
						this.DropsMenu.UpdatePantyCount();
						this.DropsMenu.UpdateList();
						this.DropsMenu.UpdateDesc();
						this.DropsMenu.gameObject.SetActive(true);
						base.gameObject.SetActive(false);
						return;
					}
					if (this.ID == 4)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.UpdateButtons();
						this.Panel.SetActive(false);
						this.BountyMenu.SetActive(true);
						return;
					}
				}
				else
				{
					if (Input.GetButtonDown("X"))
					{
						this.TutorialWindow.TitleLabel.text = "Info Points";
						this.TutorialWindow.TutorialLabel.text = this.TutorialWindow.PointsString;
						this.TutorialWindow.TutorialLabel.text = this.TutorialWindow.TutorialLabel.text.Replace('@', '\n');
						this.TutorialWindow.TutorialImage.mainTexture = this.TutorialWindow.InfoTexture;
						this.TutorialWindow.ForcingTutorial = true;
						this.TutorialWindow.enabled = true;
						this.TutorialWindow.SummonWindow();
						return;
					}
					if (Input.GetButtonDown("B"))
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Accept";
						this.PromptBar.Label[1].text = "Exit";
						this.PromptBar.Label[4].text = "Choose";
						this.PromptBar.UpdateButtons();
						this.PauseScreen.MainMenu.SetActive(true);
						this.PauseScreen.Sideways = false;
						this.PauseScreen.PressedB = true;
						base.gameObject.SetActive(false);
						return;
					}
				}
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.Panel.SetActive(true);
			this.BountyMenu.SetActive(false);
		}
	}

	// Token: 0x060014B1 RID: 5297 RVA: 0x000CBF00 File Offset: 0x000CA100
	private void UpdateHighlight()
	{
		if (this.ID > 4)
		{
			this.ID = 1;
		}
		else if (this.ID < 1)
		{
			this.ID = 4;
		}
		this.Highlight.transform.localPosition = new Vector3(-500f + 200f * (float)this.ID, this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z);
	}

	// Token: 0x0400205E RID: 8286
	public TutorialWindowScript TutorialWindow;

	// Token: 0x0400205F RID: 8287
	public InputManagerScript InputManager;

	// Token: 0x04002060 RID: 8288
	public PauseScreenScript PauseScreen;

	// Token: 0x04002061 RID: 8289
	public ServicesScript ServicesMenu;

	// Token: 0x04002062 RID: 8290
	public SchemesScript SchemesMenu;

	// Token: 0x04002063 RID: 8291
	public DropsScript DropsMenu;

	// Token: 0x04002064 RID: 8292
	public PromptBarScript PromptBar;

	// Token: 0x04002065 RID: 8293
	public GameObject BountyMenu;

	// Token: 0x04002066 RID: 8294
	public GameObject Panel;

	// Token: 0x04002067 RID: 8295
	public Transform Highlight;

	// Token: 0x04002068 RID: 8296
	public UITexture Portrait;

	// Token: 0x04002069 RID: 8297
	public int ID = 1;
}
