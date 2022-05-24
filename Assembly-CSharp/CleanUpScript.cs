using System;
using UnityEngine;

// Token: 0x0200024B RID: 587
public class CleanUpScript : MonoBehaviour
{
	// Token: 0x06001267 RID: 4711 RVA: 0x0008EF9C File Offset: 0x0008D19C
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

	// Token: 0x0400177F RID: 6015
	public Projector BloodProjector;

	// Token: 0x04001780 RID: 6016
	public UISprite CleanUpDarkness;

	// Token: 0x04001781 RID: 6017
	public PromptScript Prompt;

	// Token: 0x04001782 RID: 6018
	public bool FadeOut;

	// Token: 0x04001783 RID: 6019
	public bool FadeIn;
}
