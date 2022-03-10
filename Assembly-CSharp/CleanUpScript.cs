using System;
using UnityEngine;

// Token: 0x0200024A RID: 586
public class CleanUpScript : MonoBehaviour
{
	// Token: 0x06001263 RID: 4707 RVA: 0x0008E594 File Offset: 0x0008C794
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

	// Token: 0x0400176F RID: 5999
	public Projector BloodProjector;

	// Token: 0x04001770 RID: 6000
	public UISprite CleanUpDarkness;

	// Token: 0x04001771 RID: 6001
	public PromptScript Prompt;

	// Token: 0x04001772 RID: 6002
	public bool FadeOut;

	// Token: 0x04001773 RID: 6003
	public bool FadeIn;
}
