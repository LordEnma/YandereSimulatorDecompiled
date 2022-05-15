using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001EDA RID: 7898 RVA: 0x001B4EAC File Offset: 0x001B30AC
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04004003 RID: 16387
	public PromptScript Prompt;

	// Token: 0x04004004 RID: 16388
	public int ButtonID = 3;
}
