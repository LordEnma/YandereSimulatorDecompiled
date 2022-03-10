using System;
using UnityEngine;

// Token: 0x02000357 RID: 855
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001976 RID: 6518 RVA: 0x00101F55 File Offset: 0x00100155
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002891 RID: 10385
	public PromptScript Prompt;
}
