using System;
using UnityEngine;

// Token: 0x02000284 RID: 644
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x0600138E RID: 5006 RVA: 0x000B7777 File Offset: 0x000B5977
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001CF9 RID: 7417
	public PromptScript Prompt;
}
