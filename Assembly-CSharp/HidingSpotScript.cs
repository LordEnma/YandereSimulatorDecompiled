using System;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x0600183E RID: 6206 RVA: 0x000E95E0 File Offset: 0x000E77E0
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

	// Token: 0x040023E3 RID: 9187
	public PromptBarScript PromptBar;

	// Token: 0x040023E4 RID: 9188
	public PromptScript Prompt;

	// Token: 0x040023E5 RID: 9189
	public Transform Exit;

	// Token: 0x040023E6 RID: 9190
	public Transform Spot;

	// Token: 0x040023E7 RID: 9191
	public string AnimName;

	// Token: 0x040023E8 RID: 9192
	public bool Bench;
}
