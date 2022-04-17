using System;
using UnityEngine;

// Token: 0x02000330 RID: 816
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018DE RID: 6366 RVA: 0x000F5218 File Offset: 0x000F3418
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

	// Token: 0x04002613 RID: 9747
	public PromptScript Prompt;

	// Token: 0x04002614 RID: 9748
	public bool Fake;
}
