using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001EBA RID: 7866 RVA: 0x001B19FC File Offset: 0x001AFBFC
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003FBC RID: 16316
	public PromptScript Prompt;

	// Token: 0x04003FBD RID: 16317
	public int ButtonID = 3;
}
