using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class ThreadSpoolScript : MonoBehaviour
{
	// Token: 0x06001EEB RID: 7915 RVA: 0x001B4FBB File Offset: 0x001B31BB
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.String = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400402B RID: 16427
	public PromptScript Prompt;
}
