using System;
using UnityEngine;

// Token: 0x0200036C RID: 876
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019C3 RID: 6595 RVA: 0x001080E4 File Offset: 0x001062E4
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

	// Token: 0x0400296C RID: 10604
	public PromptScript Prompt;
}
