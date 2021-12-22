using System;
using UnityEngine;

// Token: 0x02000369 RID: 873
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019A2 RID: 6562 RVA: 0x001059AC File Offset: 0x00103BAC
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

	// Token: 0x04002908 RID: 10504
	public PromptScript Prompt;
}
