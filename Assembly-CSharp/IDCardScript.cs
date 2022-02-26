using System;
using UnityEngine;

// Token: 0x0200032E RID: 814
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018C8 RID: 6344 RVA: 0x000F3E78 File Offset: 0x000F2078
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

	// Token: 0x040025CB RID: 9675
	public PromptScript Prompt;

	// Token: 0x040025CC RID: 9676
	public bool Fake;
}
