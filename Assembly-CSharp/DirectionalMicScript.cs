using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x0600139D RID: 5021 RVA: 0x000B82B7 File Offset: 0x000B64B7
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D21 RID: 7457
	public PromptScript Prompt;
}
