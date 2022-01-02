using System;
using UnityEngine;

// Token: 0x0200032B RID: 811
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018B1 RID: 6321 RVA: 0x000F297C File Offset: 0x000F0B7C
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

	// Token: 0x040025A5 RID: 9637
	public PromptScript Prompt;

	// Token: 0x040025A6 RID: 9638
	public bool Fake;
}
