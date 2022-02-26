using System;
using UnityEngine;

// Token: 0x020004CD RID: 1229
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x06002073 RID: 8307 RVA: 0x001DD048 File Offset: 0x001DB248
	private void Update()
	{
		if (this.Yandere.Schoolwear == 1 && !this.Yandere.ClubAttire && !this.Yandere.Egg)
		{
			if (this.Label == 2)
			{
				this.Prompt.Label[0].text = "     Change Shoes";
				this.Label = 1;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Yandere.Casual = !this.Yandere.Casual;
				this.Yandere.ChangeSchoolwear();
				this.Yandere.CanMove = true;
				return;
			}
		}
		else
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Label == 1)
			{
				this.Prompt.Label[0].text = "     Not Available";
				this.Label = 2;
			}
		}
	}

	// Token: 0x04004703 RID: 18179
	public YandereScript Yandere;

	// Token: 0x04004704 RID: 18180
	public PromptScript Prompt;

	// Token: 0x04004705 RID: 18181
	public int Label = 1;
}
