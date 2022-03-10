using System;
using UnityEngine;

// Token: 0x0200036C RID: 876
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019BB RID: 6587 RVA: 0x00107754 File Offset: 0x00105954
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

	// Token: 0x0400294A RID: 10570
	public PromptScript Prompt;
}
