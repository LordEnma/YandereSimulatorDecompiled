using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class ThreadSpoolScript : MonoBehaviour
{
	// Token: 0x06001EE1 RID: 7905 RVA: 0x001B3B4F File Offset: 0x001B1D4F
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.String = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004015 RID: 16405
	public PromptScript Prompt;
}
