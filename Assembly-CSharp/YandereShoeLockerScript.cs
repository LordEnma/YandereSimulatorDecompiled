using System;
using UnityEngine;

// Token: 0x020004CB RID: 1227
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x06002060 RID: 8288 RVA: 0x001DBDB0 File Offset: 0x001D9FB0
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

	// Token: 0x040046E7 RID: 18151
	public YandereScript Yandere;

	// Token: 0x040046E8 RID: 18152
	public PromptScript Prompt;

	// Token: 0x040046E9 RID: 18153
	public int Label = 1;
}
