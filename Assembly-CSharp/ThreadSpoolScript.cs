using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class ThreadSpoolScript : MonoBehaviour
{
	// Token: 0x06001EDB RID: 7899 RVA: 0x001B3177 File Offset: 0x001B1377
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.String = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004005 RID: 16389
	public PromptScript Prompt;
}
