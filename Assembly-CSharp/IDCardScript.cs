using System;
using UnityEngine;

// Token: 0x0200032F RID: 815
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018D4 RID: 6356 RVA: 0x000F4E84 File Offset: 0x000F3084
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

	// Token: 0x04002608 RID: 9736
	public PromptScript Prompt;

	// Token: 0x04002609 RID: 9737
	public bool Fake;
}
