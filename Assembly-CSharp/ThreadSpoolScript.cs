using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class ThreadSpoolScript : MonoBehaviour
{
	// Token: 0x06001EF3 RID: 7923 RVA: 0x001B6133 File Offset: 0x001B4333
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.String = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004049 RID: 16457
	public PromptScript Prompt;
}
