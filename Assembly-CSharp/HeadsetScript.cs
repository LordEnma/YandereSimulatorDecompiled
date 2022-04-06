using System;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001858 RID: 6232 RVA: 0x000E8158 File Offset: 0x000E6358
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040023C6 RID: 9158
	public PromptScript Prompt;
}
