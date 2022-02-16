using System;
using UnityEngine;

// Token: 0x0200030D RID: 781
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x0600183E RID: 6206 RVA: 0x000E699C File Offset: 0x000E4B9C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400237C RID: 9084
	public PromptScript Prompt;
}
