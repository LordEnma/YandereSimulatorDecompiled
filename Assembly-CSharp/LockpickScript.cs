using System;
using UnityEngine;

// Token: 0x02000353 RID: 851
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001956 RID: 6486 RVA: 0x000FFB99 File Offset: 0x000FDD99
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400282C RID: 10284
	public PromptScript Prompt;
}
