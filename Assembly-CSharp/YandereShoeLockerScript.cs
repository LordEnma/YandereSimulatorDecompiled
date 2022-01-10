using System;
using UnityEngine;

// Token: 0x020004CA RID: 1226
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x06002058 RID: 8280 RVA: 0x001DA528 File Offset: 0x001D8728
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

	// Token: 0x040046CF RID: 18127
	public YandereScript Yandere;

	// Token: 0x040046D0 RID: 18128
	public PromptScript Prompt;

	// Token: 0x040046D1 RID: 18129
	public int Label = 1;
}
