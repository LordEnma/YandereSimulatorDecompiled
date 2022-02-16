using System;
using UnityEngine;

// Token: 0x0200046A RID: 1130
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E94 RID: 7828 RVA: 0x001ADB74 File Offset: 0x001ABD74
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003F1E RID: 16158
	public PromptScript Prompt;

	// Token: 0x04003F1F RID: 16159
	public int ButtonID = 3;
}
