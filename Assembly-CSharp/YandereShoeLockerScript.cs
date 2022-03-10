using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x06002079 RID: 8313 RVA: 0x001DDA14 File Offset: 0x001DBC14
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

	// Token: 0x04004720 RID: 18208
	public YandereScript Yandere;

	// Token: 0x04004721 RID: 18209
	public PromptScript Prompt;

	// Token: 0x04004722 RID: 18210
	public int Label = 1;
}
