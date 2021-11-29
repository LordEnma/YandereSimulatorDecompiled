using System;
using UnityEngine;

// Token: 0x02000465 RID: 1125
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E6E RID: 7790 RVA: 0x001AA46C File Offset: 0x001A866C
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003EB3 RID: 16051
	public PromptScript Prompt;

	// Token: 0x04003EB4 RID: 16052
	public int ButtonID = 3;
}
