using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018A8 RID: 6312 RVA: 0x000F1ED8 File Offset: 0x000F00D8
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

	// Token: 0x04002581 RID: 9601
	public PromptScript Prompt;

	// Token: 0x04002582 RID: 9602
	public bool Fake;
}
