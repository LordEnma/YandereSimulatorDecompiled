using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001963 RID: 6499 RVA: 0x00100B41 File Offset: 0x000FED41
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400285C RID: 10332
	public PromptScript Prompt;
}
