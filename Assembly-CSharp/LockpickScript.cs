using System;
using UnityEngine;

// Token: 0x02000357 RID: 855
public class LockpickScript : MonoBehaviour
{
	// Token: 0x0600197E RID: 6526 RVA: 0x001028CD File Offset: 0x00100ACD
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040028B3 RID: 10419
	public PromptScript Prompt;
}
