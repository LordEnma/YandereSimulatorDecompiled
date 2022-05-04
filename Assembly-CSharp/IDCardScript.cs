using System;
using UnityEngine;

// Token: 0x02000330 RID: 816
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018E2 RID: 6370 RVA: 0x000F56E8 File Offset: 0x000F38E8
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

	// Token: 0x0400261C RID: 9756
	public PromptScript Prompt;

	// Token: 0x0400261D RID: 9757
	public bool Fake;
}
