using System;
using UnityEngine;

// Token: 0x020004CB RID: 1227
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x0600205A RID: 8282 RVA: 0x001DB1F8 File Offset: 0x001D93F8
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

	// Token: 0x040046D6 RID: 18134
	public YandereScript Yandere;

	// Token: 0x040046D7 RID: 18135
	public PromptScript Prompt;

	// Token: 0x040046D8 RID: 18136
	public int Label = 1;
}
