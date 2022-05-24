using System;
using UnityEngine;

// Token: 0x02000331 RID: 817
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018E7 RID: 6375 RVA: 0x000F5B48 File Offset: 0x000F3D48
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.StolenObject = base.gameObject;
			if (!this.Fake)
			{
				this.Prompt.Yandere.Inventory.IDCard = true;
				this.Prompt.Yandere.TheftTimer = 1f;
			}
			else
			{
				this.Prompt.Yandere.Inventory.FakeID = true;
			}
			this.Prompt.Hide();
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0400262A RID: 9770
	public PromptScript Prompt;

	// Token: 0x0400262B RID: 9771
	public bool Fake;
}
