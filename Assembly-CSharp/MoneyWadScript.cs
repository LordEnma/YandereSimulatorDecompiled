using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019C9 RID: 6601 RVA: 0x001087A0 File Offset: 0x001069A0
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

	// Token: 0x0400297F RID: 10623
	public PromptScript Prompt;
}
