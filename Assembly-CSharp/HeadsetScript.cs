using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001830 RID: 6192 RVA: 0x000E5E54 File Offset: 0x000E4054
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002366 RID: 9062
	public PromptScript Prompt;
}
