using System;
using UnityEngine;

// Token: 0x02000283 RID: 643
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x06001387 RID: 4999 RVA: 0x000B6FAB File Offset: 0x000B51AB
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001CD6 RID: 7382
	public PromptScript Prompt;
}
