using System;
using UnityEngine;

// Token: 0x020004C8 RID: 1224
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x0600204A RID: 8266 RVA: 0x001D9598 File Offset: 0x001D7798
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

	// Token: 0x040046B2 RID: 18098
	public YandereScript Yandere;

	// Token: 0x040046B3 RID: 18099
	public PromptScript Prompt;

	// Token: 0x040046B4 RID: 18100
	public int Label = 1;
}
