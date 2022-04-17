using System;
using UnityEngine;

// Token: 0x02000359 RID: 857
public class LockpickScript : MonoBehaviour
{
	// Token: 0x0600198E RID: 6542 RVA: 0x0010330D File Offset: 0x0010150D
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040028D1 RID: 10449
	public PromptScript Prompt;
}
