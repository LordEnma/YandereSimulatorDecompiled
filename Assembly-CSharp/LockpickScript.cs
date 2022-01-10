using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001963 RID: 6499 RVA: 0x001009D9 File Offset: 0x000FEBD9
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002859 RID: 10329
	public PromptScript Prompt;
}
