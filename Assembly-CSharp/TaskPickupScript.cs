using System;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E85 RID: 7813 RVA: 0x001AC02C File Offset: 0x001AA22C
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003EFE RID: 16126
	public PromptScript Prompt;

	// Token: 0x04003EFF RID: 16127
	public int ButtonID = 3;
}
