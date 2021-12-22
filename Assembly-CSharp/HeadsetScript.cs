using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x0600182E RID: 6190 RVA: 0x000E5B84 File Offset: 0x000E3D84
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002362 RID: 9058
	public PromptScript Prompt;
}
