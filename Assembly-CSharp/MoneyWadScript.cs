using System;
using UnityEngine;

// Token: 0x0200036A RID: 874
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019A9 RID: 6569 RVA: 0x0010668C File Offset: 0x0010488C
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

	// Token: 0x0400291C RID: 10524
	public PromptScript Prompt;
}
