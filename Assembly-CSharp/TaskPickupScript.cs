using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001EB0 RID: 7856 RVA: 0x001B04E4 File Offset: 0x001AE6E4
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003F8F RID: 16271
	public PromptScript Prompt;

	// Token: 0x04003F90 RID: 16272
	public int ButtonID = 3;
}
