using System;
using UnityEngine;

// Token: 0x0200024A RID: 586
public class CleanUpScript : MonoBehaviour
{
	// Token: 0x06001265 RID: 4709 RVA: 0x0008ECD4 File Offset: 0x0008CED4
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

	// Token: 0x04001779 RID: 6009
	public Projector BloodProjector;

	// Token: 0x0400177A RID: 6010
	public UISprite CleanUpDarkness;

	// Token: 0x0400177B RID: 6011
	public PromptScript Prompt;

	// Token: 0x0400177C RID: 6012
	public bool FadeOut;

	// Token: 0x0400177D RID: 6013
	public bool FadeIn;
}
