using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001EC8 RID: 7880 RVA: 0x001B28C8 File Offset: 0x001B0AC8
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003FCF RID: 16335
	public PromptScript Prompt;

	// Token: 0x04003FD0 RID: 16336
	public int ButtonID = 3;
}
