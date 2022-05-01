using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x060013A1 RID: 5025 RVA: 0x000B88D3 File Offset: 0x000B6AD3
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D2A RID: 7466
	public PromptScript Prompt;
}
