using System;
using UnityEngine;

// Token: 0x02000285 RID: 645
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x06001397 RID: 5015 RVA: 0x000B81B7 File Offset: 0x000B63B7
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D1F RID: 7455
	public PromptScript Prompt;
}
