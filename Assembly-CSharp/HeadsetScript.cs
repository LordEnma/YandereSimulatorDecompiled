using System;
using UnityEngine;

// Token: 0x0200030E RID: 782
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x0600184C RID: 6220 RVA: 0x000E7A5C File Offset: 0x000E5C5C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040023B0 RID: 9136
	public PromptScript Prompt;
}
