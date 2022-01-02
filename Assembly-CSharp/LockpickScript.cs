using System;
using UnityEngine;

// Token: 0x02000354 RID: 852
public class LockpickScript : MonoBehaviour
{
	// Token: 0x0600195F RID: 6495 RVA: 0x00100679 File Offset: 0x000FE879
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002855 RID: 10325
	public PromptScript Prompt;
}
