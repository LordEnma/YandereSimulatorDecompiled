using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public class ThreadSpoolScript : MonoBehaviour
{
	// Token: 0x06001EC9 RID: 7881 RVA: 0x001B16FB File Offset: 0x001AF8FB
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.String = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04003FD5 RID: 16341
	public PromptScript Prompt;
}
