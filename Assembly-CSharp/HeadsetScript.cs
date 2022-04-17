using System;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x0600185C RID: 6236 RVA: 0x000E83F8 File Offset: 0x000E65F8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040023CE RID: 9166
	public PromptScript Prompt;
}
