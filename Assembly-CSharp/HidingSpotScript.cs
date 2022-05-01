using System;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x06001870 RID: 6256 RVA: 0x000EC344 File Offset: 0x000EA544
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

	// Token: 0x04002458 RID: 9304
	public PromptBarScript PromptBar;

	// Token: 0x04002459 RID: 9305
	public PromptScript Prompt;

	// Token: 0x0400245A RID: 9306
	public Transform Exit;

	// Token: 0x0400245B RID: 9307
	public Transform Spot;

	// Token: 0x0400245C RID: 9308
	public string AnimName;

	// Token: 0x0400245D RID: 9309
	public bool Bench;
}
