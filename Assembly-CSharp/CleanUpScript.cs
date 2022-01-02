using System;
using UnityEngine;

// Token: 0x0200024A RID: 586
public class CleanUpScript : MonoBehaviour
{
	// Token: 0x06001262 RID: 4706 RVA: 0x0008E184 File Offset: 0x0008C384
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

	// Token: 0x04001760 RID: 5984
	public Projector BloodProjector;

	// Token: 0x04001761 RID: 5985
	public UISprite CleanUpDarkness;

	// Token: 0x04001762 RID: 5986
	public PromptScript Prompt;

	// Token: 0x04001763 RID: 5987
	public bool FadeOut;

	// Token: 0x04001764 RID: 5988
	public bool FadeIn;
}
