using System;
using UnityEngine;

// Token: 0x0200030F RID: 783
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001852 RID: 6226 RVA: 0x000E8058 File Offset: 0x000E6258
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040023C3 RID: 9155
	public PromptScript Prompt;
}
