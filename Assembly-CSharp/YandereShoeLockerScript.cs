using System;
using UnityEngine;

// Token: 0x020004C8 RID: 1224
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x0600204D RID: 8269 RVA: 0x001D9B88 File Offset: 0x001D7D88
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

	// Token: 0x040046BB RID: 18107
	public YandereScript Yandere;

	// Token: 0x040046BC RID: 18108
	public PromptScript Prompt;

	// Token: 0x040046BD RID: 18109
	public int Label = 1;
}
