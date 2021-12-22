using System;
using UnityEngine;

// Token: 0x02000354 RID: 852
public class LockpickScript : MonoBehaviour
{
	// Token: 0x0600195D RID: 6493 RVA: 0x001003B9 File Offset: 0x000FE5B9
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002851 RID: 10321
	public PromptScript Prompt;
}
