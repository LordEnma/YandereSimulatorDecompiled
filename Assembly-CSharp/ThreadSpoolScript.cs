using System;
using UnityEngine;

// Token: 0x02000477 RID: 1143
public class ThreadSpoolScript : MonoBehaviour
{
	// Token: 0x06001ED3 RID: 7891 RVA: 0x001B2C6F File Offset: 0x001B0E6F
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.String = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004002 RID: 16386
	public PromptScript Prompt;
}
