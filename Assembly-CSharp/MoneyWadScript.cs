using System;
using UnityEngine;

// Token: 0x0200036E RID: 878
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019D3 RID: 6611 RVA: 0x00108B64 File Offset: 0x00106D64
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Money += 20f;
			this.Prompt.Yandere.Inventory.UpdateMoney();
			if (this.Prompt.Yandere.Inventory.Money > 1000f && !GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("RichGirl", 1);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400298A RID: 10634
	public PromptScript Prompt;
}
