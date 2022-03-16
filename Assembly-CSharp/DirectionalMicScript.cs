using System;
using UnityEngine;

// Token: 0x02000285 RID: 645
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x06001396 RID: 5014 RVA: 0x000B80AB File Offset: 0x000B62AB
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D1C RID: 7452
	public PromptScript Prompt;
}
