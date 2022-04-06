using System;
using UnityEngine;

// Token: 0x02000359 RID: 857
public class LockpickScript : MonoBehaviour
{
	// Token: 0x0600198A RID: 6538 RVA: 0x00103079 File Offset: 0x00101279
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040028C9 RID: 10441
	public PromptScript Prompt;
}
