using System;
using UnityEngine;

// Token: 0x02000359 RID: 857
public class LockpickScript : MonoBehaviour
{
	// Token: 0x06001992 RID: 6546 RVA: 0x0010380D File Offset: 0x00101A0D
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040028DA RID: 10458
	public PromptScript Prompt;
}
