using System;
using UnityEngine;

// Token: 0x0200036E RID: 878
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019D7 RID: 6615 RVA: 0x00109064 File Offset: 0x00107264
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

	// Token: 0x04002993 RID: 10643
	public PromptScript Prompt;
}
