using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E8A RID: 7818 RVA: 0x001AD49C File Offset: 0x001AB69C
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003F12 RID: 16146
	public PromptScript Prompt;

	// Token: 0x04003F13 RID: 16147
	public int ButtonID = 3;
}
