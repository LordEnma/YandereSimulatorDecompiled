using System;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E78 RID: 7800 RVA: 0x001AB1F8 File Offset: 0x001A93F8
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003EE3 RID: 16099
	public PromptScript Prompt;

	// Token: 0x04003EE4 RID: 16100
	public int ButtonID = 3;
}
