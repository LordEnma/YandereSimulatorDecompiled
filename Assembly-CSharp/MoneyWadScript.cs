using System;
using UnityEngine;

// Token: 0x02000368 RID: 872
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x0600199B RID: 6555 RVA: 0x0010510C File Offset: 0x0010330C
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

	// Token: 0x040028E3 RID: 10467
	public PromptScript Prompt;
}
