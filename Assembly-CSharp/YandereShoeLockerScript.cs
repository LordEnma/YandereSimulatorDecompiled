using System;
using UnityEngine;

// Token: 0x020004CC RID: 1228
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x0600206A RID: 8298 RVA: 0x001DC468 File Offset: 0x001DA668
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

	// Token: 0x040046F3 RID: 18163
	public YandereScript Yandere;

	// Token: 0x040046F4 RID: 18164
	public PromptScript Prompt;

	// Token: 0x040046F5 RID: 18165
	public int Label = 1;
}
