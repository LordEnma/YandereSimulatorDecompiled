using System;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018BF RID: 6335 RVA: 0x000F3594 File Offset: 0x000F1794
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

	// Token: 0x040025BC RID: 9660
	public PromptScript Prompt;

	// Token: 0x040025BD RID: 9661
	public bool Fake;
}
