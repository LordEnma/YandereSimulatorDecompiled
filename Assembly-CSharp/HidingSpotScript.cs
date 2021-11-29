﻿using System;
using UnityEngine;

// Token: 0x0200030F RID: 783
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x06001837 RID: 6199 RVA: 0x000E8E20 File Offset: 0x000E7020
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

	// Token: 0x040023C3 RID: 9155
	public PromptBarScript PromptBar;

	// Token: 0x040023C4 RID: 9156
	public PromptScript Prompt;

	// Token: 0x040023C5 RID: 9157
	public Transform Exit;

	// Token: 0x040023C6 RID: 9158
	public Transform Spot;

	// Token: 0x040023C7 RID: 9159
	public string AnimName;

	// Token: 0x040023C8 RID: 9160
	public bool Bench;
}