using System;
using UnityEngine;

// Token: 0x020004CB RID: 1227
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x06002063 RID: 8291 RVA: 0x001DBFB4 File Offset: 0x001DA1B4
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

	// Token: 0x040046EA RID: 18154
	public YandereScript Yandere;

	// Token: 0x040046EB RID: 18155
	public PromptScript Prompt;

	// Token: 0x040046EC RID: 18156
	public int Label = 1;
}
