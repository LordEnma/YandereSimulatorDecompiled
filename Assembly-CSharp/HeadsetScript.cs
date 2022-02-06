using System;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001837 RID: 6199 RVA: 0x000E6828 File Offset: 0x000E4A28
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002376 RID: 9078
	public PromptScript Prompt;
}
