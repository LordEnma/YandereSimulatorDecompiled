using System;
using UnityEngine;

// Token: 0x0200036E RID: 878
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019CF RID: 6607 RVA: 0x001088A0 File Offset: 0x00106AA0
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

	// Token: 0x04002982 RID: 10626
	public PromptScript Prompt;
}
