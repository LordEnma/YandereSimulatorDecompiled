using System;
using UnityEngine;

// Token: 0x0200030E RID: 782
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001847 RID: 6215 RVA: 0x000E75B0 File Offset: 0x000E57B0
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400239F RID: 9119
	public PromptScript Prompt;
}
