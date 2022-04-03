using System;
using UnityEngine;

// Token: 0x02000358 RID: 856
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001984 RID: 6532 RVA: 0x00102F79 File Offset: 0x00101179
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040028C6 RID: 10438
	public PromptScript Prompt;
}
