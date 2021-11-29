using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001827 RID: 6183 RVA: 0x000E53C4 File Offset: 0x000E35C4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002342 RID: 9026
	public PromptScript Prompt;
}
