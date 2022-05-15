using System;
using UnityEngine;

// Token: 0x02000287 RID: 647
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x060013A3 RID: 5027 RVA: 0x000B8B1B File Offset: 0x000B6D1B
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D31 RID: 7473
	public PromptScript Prompt;
}
