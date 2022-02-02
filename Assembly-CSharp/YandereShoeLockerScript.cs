using System;
using UnityEngine;

// Token: 0x020004CB RID: 1227
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x0600205E RID: 8286 RVA: 0x001DBA98 File Offset: 0x001D9C98
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

	// Token: 0x040046E1 RID: 18145
	public YandereScript Yandere;

	// Token: 0x040046E2 RID: 18146
	public PromptScript Prompt;

	// Token: 0x040046E3 RID: 18147
	public int Label = 1;
}
