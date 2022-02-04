using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001964 RID: 6500 RVA: 0x00101035 File Offset: 0x000FF235
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002863 RID: 10339
	public PromptScript Prompt;
}
