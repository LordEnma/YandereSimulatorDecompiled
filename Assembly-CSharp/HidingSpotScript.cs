using System;
using UnityEngine;

// Token: 0x02000314 RID: 788
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x06001862 RID: 6242 RVA: 0x000EBAA8 File Offset: 0x000E9CA8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0 && this.Prompt.Yandere.Pursuer == null)
			{
				if (this.Bench)
				{
					this.Prompt.Yandere.MyController.radius = 0.1f;
				}
				else
				{
					this.Prompt.Yandere.MyController.center = new Vector3(this.Prompt.Yandere.MyController.center.x, 0.3f, this.Prompt.Yandere.MyController.center.z);
					this.Prompt.Yandere.MyController.radius = 0f;
					this.Prompt.Yandere.MyController.height = 0.5f;
				}
				this.Prompt.Yandere.HideAnim = this.AnimName;
				this.Prompt.Yandere.HidingSpot = this.Spot;
				this.Prompt.Yandere.ExitSpot = this.Exit;
				this.Prompt.Yandere.CanMove = false;
				this.Prompt.Yandere.Hiding = true;
				this.Prompt.Yandere.EmptyHands();
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[1].text = "Stop";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
		}
	}

	// Token: 0x04002444 RID: 9284
	public PromptBarScript PromptBar;

	// Token: 0x04002445 RID: 9285
	public PromptScript Prompt;

	// Token: 0x04002446 RID: 9286
	public Transform Exit;

	// Token: 0x04002447 RID: 9287
	public Transform Spot;

	// Token: 0x04002448 RID: 9288
	public string AnimName;

	// Token: 0x04002449 RID: 9289
	public bool Bench;
}
