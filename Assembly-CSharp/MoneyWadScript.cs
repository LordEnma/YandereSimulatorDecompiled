using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019DE RID: 6622 RVA: 0x00109A70 File Offset: 0x00107C70
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

	// Token: 0x040029AB RID: 10667
	public PromptScript Prompt;
}
