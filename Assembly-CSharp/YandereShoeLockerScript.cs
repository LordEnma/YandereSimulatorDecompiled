using System;
using UnityEngine;

// Token: 0x020004C6 RID: 1222
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x06002039 RID: 8249 RVA: 0x001D7E64 File Offset: 0x001D6064
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

	// Token: 0x04004673 RID: 18035
	public YandereScript Yandere;

	// Token: 0x04004674 RID: 18036
	public PromptScript Prompt;

	// Token: 0x04004675 RID: 18037
	public int Label = 1;
}
