using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001EC2 RID: 7874 RVA: 0x001B1EF0 File Offset: 0x001B00F0
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003FBF RID: 16319
	public PromptScript Prompt;

	// Token: 0x04003FC0 RID: 16320
	public int ButtonID = 3;
}
