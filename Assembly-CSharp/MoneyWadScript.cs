using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019B2 RID: 6578 RVA: 0x00106ABC File Offset: 0x00104CBC
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

	// Token: 0x04002925 RID: 10533
	public PromptScript Prompt;
}
