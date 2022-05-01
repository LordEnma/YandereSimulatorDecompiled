using System;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001860 RID: 6240 RVA: 0x000E88F4 File Offset: 0x000E6AF4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040023D7 RID: 9175
	public PromptScript Prompt;
}
