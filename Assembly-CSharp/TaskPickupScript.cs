using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001EDB RID: 7899 RVA: 0x001B533C File Offset: 0x001B353C
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x0400400C RID: 16396
	public PromptScript Prompt;

	// Token: 0x0400400D RID: 16397
	public int ButtonID = 3;
}
