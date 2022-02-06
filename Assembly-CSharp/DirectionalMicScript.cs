using System;
using UnityEngine;

// Token: 0x02000284 RID: 644
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x0600138F RID: 5007 RVA: 0x000B7A17 File Offset: 0x000B5C17
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D01 RID: 7425
	public PromptScript Prompt;
}
