using System;
using UnityEngine;

// Token: 0x02000285 RID: 645
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x06001393 RID: 5011 RVA: 0x000B795B File Offset: 0x000B5B5B
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D04 RID: 7428
	public PromptScript Prompt;
}
