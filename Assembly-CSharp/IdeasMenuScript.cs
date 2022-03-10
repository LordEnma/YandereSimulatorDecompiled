using System;
using UnityEngine;

// Token: 0x0200032F RID: 815
public class IdeasMenuScript : MonoBehaviour
{
	// Token: 0x060018CA RID: 6346 RVA: 0x000F4270 File Offset: 0x000F2470
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			if (!CollectibleGlobals.GetAdvicePurchased(i))
			{
				this.IdeaNames[17 + i] = "?????";
				this.Ideas[17 + i] = "To unlock this information, you'll need to find someone who has experience getting away with murder...";
			}
		}
		this.UpdateHighlightPosition();
		this.Description.enabled = false;
		this.List.SetActive(true);
	}

	// Token: 0x060018CB RID: 6347 RVA: 0x000F42D0 File Offset: 0x000F24D0
	private void Update()
	{
		if (this.List.activeInHierarchy)
		{
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				this.UpdateHighlightPosition();
				return;
			}
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				this.UpdateHighlightPosition();
				return;
			}
			if (Input.GetButtonDown("A"))
			{
				this.PauseScreen.PromptBar.ClearButtons();
				this.PauseScreen.PromptBar.Label[1].text = "Back";
				this.PauseScreen.PromptBar.UpdateButtons();
				this.PauseScreen.PromptBar.Show = true;
				this.Description.text = this.Ideas[this.Selected + this.Offset];
				this.Description.text = this.Description.text.Replace('@', '\n');
				this.Description.enabled = true;
				this.List.SetActive(false);
				return;
			}
			if (Input.GetButtonDown("B"))
			{
				this.PauseScreen.PromptBar.ClearButtons();
				this.PauseScreen.PromptBar.Label[0].text = "Accept";
				this.PauseScreen.PromptBar.Label[1].text = "Exit";
				this.PauseScreen.PromptBar.Label[4].text = "Choose";
				this.PauseScreen.PromptBar.Label[5].text = "Choose";
				this.PauseScreen.PromptBar.UpdateButtons();
				this.PauseScreen.MainMenu.SetActive(true);
				base.gameObject.SetActive(false);
				return;
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.PauseScreen.PromptBar.ClearButtons();
			this.PauseScreen.PromptBar.Label[0].text = "Confirm";
			this.PauseScreen.PromptBar.Label[1].text = "Back";
			this.PauseScreen.PromptBar.Label[4].text = "Choose";
			this.PauseScreen.PromptBar.UpdateButtons();
			this.PauseScreen.PromptBar.Show = true;
			this.Description.enabled = false;
			this.List.SetActive(true);
		}
	}

	// Token: 0x060018CC RID: 6348 RVA: 0x000F4550 File Offset: 0x000F2750
	private void UpdateHighlightPosition()
	{
		if (this.Selected < 1)
		{
			this.Selected = 1;
			this.Offset--;
		}
		else if (this.Selected > this.ListSize)
		{
			this.Selected = this.ListSize;
			this.Offset++;
		}
		if (this.Offset < 0)
		{
			this.Selected = this.ListSize;
			this.Offset = this.Limit - this.ListSize;
		}
		else if (this.Offset > this.Limit - this.ListSize)
		{
			this.Selected = 1;
			this.Offset = 0;
		}
		for (int i = 1; i < this.Labels.Length; i++)
		{
			this.Labels[i].text = this.IdeaNames[i + this.Offset];
		}
		this.Highlight.transform.localPosition = new Vector3(-125f, (float)(550 - this.Selected * 50), 0f);
	}

	// Token: 0x040025E1 RID: 9697
	public InputManagerScript InputManager;

	// Token: 0x040025E2 RID: 9698
	public PauseScreenScript PauseScreen;

	// Token: 0x040025E3 RID: 9699
	public Transform Highlight;

	// Token: 0x040025E4 RID: 9700
	public UILabel Description;

	// Token: 0x040025E5 RID: 9701
	public string[] IdeaNames;

	// Token: 0x040025E6 RID: 9702
	public string[] Ideas;

	// Token: 0x040025E7 RID: 9703
	public UILabel[] Labels;

	// Token: 0x040025E8 RID: 9704
	public GameObject List;

	// Token: 0x040025E9 RID: 9705
	public int ListSize = 21;

	// Token: 0x040025EA RID: 9706
	public int Selected = 1;

	// Token: 0x040025EB RID: 9707
	public int Offset;

	// Token: 0x040025EC RID: 9708
	public int Limit = 27;
}
