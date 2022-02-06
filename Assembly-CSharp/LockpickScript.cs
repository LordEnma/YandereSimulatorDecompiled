using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001966 RID: 6502 RVA: 0x00101141 File Offset: 0x000FF341
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002866 RID: 10342
	public PromptScript Prompt;
}
