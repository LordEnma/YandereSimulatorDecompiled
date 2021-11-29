using System;
using UnityEngine;

// Token: 0x02000249 RID: 585
public class CleanUpScript : MonoBehaviour
{
	// Token: 0x0600125D RID: 4701 RVA: 0x0008DF1C File Offset: 0x0008C11C
	private void Update()
	{
		if (this.Prompt.Yandere.PickUp != null && this.Prompt.Yandere.PickUp.Mop != null && this.Prompt.Yandere.PickUp.Mop.Bleached)
		{
			this.Prompt.HideButton[0] = false;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Yandere.CanMove = false;
				this.FadeOut = true;
			}
			if (this.FadeOut)
			{
				this.CleanUpDarkness.alpha = Mathf.MoveTowards(this.CleanUpDarkness.alpha, 1f, Time.deltaTime);
				if (this.CleanUpDarkness.alpha == 1f)
				{
					this.BloodProjector.enabled = false;
					this.FadeOut = false;
					this.FadeIn = true;
				}
			}
			if (this.FadeIn)
			{
				this.CleanUpDarkness.alpha = Mathf.MoveTowards(this.CleanUpDarkness.alpha, 0f, Time.deltaTime);
				if (this.CleanUpDarkness.alpha == 0f)
				{
					this.Prompt.Hide();
					this.BloodProjector.gameObject.SetActive(false);
					this.Prompt.Yandere.CanMove = true;
					return;
				}
			}
		}
		else
		{
			this.Prompt.HideButton[0] = true;
		}
	}

	// Token: 0x0400175C RID: 5980
	public Projector BloodProjector;

	// Token: 0x0400175D RID: 5981
	public UISprite CleanUpDarkness;

	// Token: 0x0400175E RID: 5982
	public PromptScript Prompt;

	// Token: 0x0400175F RID: 5983
	public bool FadeOut;

	// Token: 0x04001760 RID: 5984
	public bool FadeIn;
}
