using System;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001834 RID: 6196 RVA: 0x000E617C File Offset: 0x000E437C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400236A RID: 9066
	public PromptScript Prompt;
}
