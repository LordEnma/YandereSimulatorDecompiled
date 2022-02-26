using System;
using UnityEngine;

// Token: 0x02000357 RID: 855
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001976 RID: 6518 RVA: 0x00101C15 File Offset: 0x000FFE15
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400287B RID: 10363
	public PromptScript Prompt;
}
