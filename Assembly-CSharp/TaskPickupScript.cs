using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E9D RID: 7837 RVA: 0x001AE6B0 File Offset: 0x001AC8B0
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003F2E RID: 16174
	public PromptScript Prompt;

	// Token: 0x04003F2F RID: 16175
	public int ButtonID = 3;
}
