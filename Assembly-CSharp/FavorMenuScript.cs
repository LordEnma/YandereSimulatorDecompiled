using System;
using UnityEngine;

// Token: 0x020002C7 RID: 711
public class FavorMenuScript : MonoBehaviour
{
	// Token: 0x0600148F RID: 5263 RVA: 0x000C99B4 File Offset: 0x000C7BB4
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

	// Token: 0x06001490 RID: 5264 RVA: 0x000C9D90 File Offset: 0x000C7F90
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

	// Token: 0x04002012 RID: 8210
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04002013 RID: 8211
	public InputManagerScript InputManager;

	// Token: 0x04002014 RID: 8212
	public PauseScreenScript PauseScreen;

	// Token: 0x04002015 RID: 8213
	public ServicesScript ServicesMenu;

	// Token: 0x04002016 RID: 8214
	public SchemesScript SchemesMenu;

	// Token: 0x04002017 RID: 8215
	public DropsScript DropsMenu;

	// Token: 0x04002018 RID: 8216
	public PromptBarScript PromptBar;

	// Token: 0x04002019 RID: 8217
	public GameObject BountyMenu;

	// Token: 0x0400201A RID: 8218
	public GameObject Panel;

	// Token: 0x0400201B RID: 8219
	public Transform Highlight;

	// Token: 0x0400201C RID: 8220
	public UITexture Portrait;

	// Token: 0x0400201D RID: 8221
	public int ID = 1;
}
