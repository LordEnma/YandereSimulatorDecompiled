using System;
using UnityEngine;

// Token: 0x02000285 RID: 645
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x06001393 RID: 5011 RVA: 0x000B7CCF File Offset: 0x000B5ECF
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D0E RID: 7438
	public PromptScript Prompt;
}
