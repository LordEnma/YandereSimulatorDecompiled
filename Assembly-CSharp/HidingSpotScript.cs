using System;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x0600186C RID: 6252 RVA: 0x000EBE48 File Offset: 0x000EA048
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

	// Token: 0x0400244F RID: 9295
	public PromptBarScript PromptBar;

	// Token: 0x04002450 RID: 9296
	public PromptScript Prompt;

	// Token: 0x04002451 RID: 9297
	public Transform Exit;

	// Token: 0x04002452 RID: 9298
	public Transform Spot;

	// Token: 0x04002453 RID: 9299
	public string AnimName;

	// Token: 0x04002454 RID: 9300
	public bool Bench;
}
