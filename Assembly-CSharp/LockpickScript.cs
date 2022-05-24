using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001999 RID: 6553 RVA: 0x00104219 File Offset: 0x00102419
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040028F2 RID: 10482
	public PromptScript Prompt;
}
