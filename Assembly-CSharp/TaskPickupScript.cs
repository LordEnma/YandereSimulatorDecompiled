using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001EA0 RID: 7840 RVA: 0x001AEDD8 File Offset: 0x001ACFD8
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003F45 RID: 16197
	public PromptScript Prompt;

	// Token: 0x04003F46 RID: 16198
	public int ButtonID = 3;
}
