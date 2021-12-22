using System;
using UnityEngine;

// Token: 0x0200032B RID: 811
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018AF RID: 6319 RVA: 0x000F26C8 File Offset: 0x000F08C8
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

	// Token: 0x040025A1 RID: 9633
	public PromptScript Prompt;

	// Token: 0x040025A2 RID: 9634
	public bool Fake;
}
