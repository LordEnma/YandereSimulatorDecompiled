using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x06001875 RID: 6261 RVA: 0x000EC610 File Offset: 0x000EA810
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

	// Token: 0x04002463 RID: 9315
	public PromptBarScript PromptBar;

	// Token: 0x04002464 RID: 9316
	public PromptScript Prompt;

	// Token: 0x04002465 RID: 9317
	public Transform Exit;

	// Token: 0x04002466 RID: 9318
	public Transform Spot;

	// Token: 0x04002467 RID: 9319
	public string AnimName;

	// Token: 0x04002468 RID: 9320
	public bool Bench;
}
