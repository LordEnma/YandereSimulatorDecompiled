using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001998 RID: 6552 RVA: 0x00104015 File Offset: 0x00102215
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040028EB RID: 10475
	public PromptScript Prompt;
}
