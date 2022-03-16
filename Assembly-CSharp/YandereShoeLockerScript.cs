using System;
using UnityEngine;

// Token: 0x020004D2 RID: 1234
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x06002091 RID: 8337 RVA: 0x001DF92C File Offset: 0x001DDB2C
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

	// Token: 0x0400477F RID: 18303
	public YandereScript Yandere;

	// Token: 0x04004780 RID: 18304
	public PromptScript Prompt;

	// Token: 0x04004781 RID: 18305
	public int Label = 1;
}
