using System;
using UnityEngine;

// Token: 0x02000369 RID: 873
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019A4 RID: 6564 RVA: 0x00105C88 File Offset: 0x00103E88
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

	// Token: 0x0400290C RID: 10508
	public PromptScript Prompt;
}
