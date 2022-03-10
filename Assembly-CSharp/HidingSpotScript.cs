using System;
using UnityEngine;

// Token: 0x02000313 RID: 787
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x06001857 RID: 6231 RVA: 0x000EB030 File Offset: 0x000E9230
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

	// Token: 0x04002420 RID: 9248
	public PromptBarScript PromptBar;

	// Token: 0x04002421 RID: 9249
	public PromptScript Prompt;

	// Token: 0x04002422 RID: 9250
	public Transform Exit;

	// Token: 0x04002423 RID: 9251
	public Transform Spot;

	// Token: 0x04002424 RID: 9252
	public string AnimName;

	// Token: 0x04002425 RID: 9253
	public bool Bench;
}
