using System;
using UnityEngine;

// Token: 0x020002C6 RID: 710
public class FavorMenuScript : MonoBehaviour
{
	// Token: 0x06001488 RID: 5256 RVA: 0x000C8FD0 File Offset: 0x000C71D0
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

	// Token: 0x06001489 RID: 5257 RVA: 0x000C93AC File Offset: 0x000C75AC
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

	// Token: 0x04001FEF RID: 8175
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04001FF0 RID: 8176
	public InputManagerScript InputManager;

	// Token: 0x04001FF1 RID: 8177
	public PauseScreenScript PauseScreen;

	// Token: 0x04001FF2 RID: 8178
	public ServicesScript ServicesMenu;

	// Token: 0x04001FF3 RID: 8179
	public SchemesScript SchemesMenu;

	// Token: 0x04001FF4 RID: 8180
	public DropsScript DropsMenu;

	// Token: 0x04001FF5 RID: 8181
	public PromptBarScript PromptBar;

	// Token: 0x04001FF6 RID: 8182
	public GameObject BountyMenu;

	// Token: 0x04001FF7 RID: 8183
	public GameObject Panel;

	// Token: 0x04001FF8 RID: 8184
	public Transform Highlight;

	// Token: 0x04001FF9 RID: 8185
	public UITexture Portrait;

	// Token: 0x04001FFA RID: 8186
	public int ID = 1;
}
