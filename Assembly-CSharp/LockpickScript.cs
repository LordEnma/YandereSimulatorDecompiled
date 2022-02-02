using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001964 RID: 6500 RVA: 0x00100F79 File Offset: 0x000FF179
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002862 RID: 10338
	public PromptScript Prompt;
}
