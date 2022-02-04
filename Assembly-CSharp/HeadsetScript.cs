using System;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001835 RID: 6197 RVA: 0x000E673C File Offset: 0x000E493C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002373 RID: 9075
	public PromptScript Prompt;
}
