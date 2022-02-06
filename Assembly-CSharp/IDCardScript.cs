using System;
using UnityEngine;

// Token: 0x0200032C RID: 812
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018B8 RID: 6328 RVA: 0x000F33F0 File Offset: 0x000F15F0
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

	// Token: 0x040025B6 RID: 9654
	public PromptScript Prompt;

	// Token: 0x040025B7 RID: 9655
	public bool Fake;
}
