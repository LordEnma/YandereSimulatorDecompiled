using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class ThreadSpoolScript : MonoBehaviour
{
	// Token: 0x06001EF4 RID: 7924 RVA: 0x001B65C3 File Offset: 0x001B47C3
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.String = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004052 RID: 16466
	public PromptScript Prompt;
}
