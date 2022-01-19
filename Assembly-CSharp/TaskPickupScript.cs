using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E87 RID: 7815 RVA: 0x001ACCFC File Offset: 0x001AAEFC
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003F05 RID: 16133
	public PromptScript Prompt;

	// Token: 0x04003F06 RID: 16134
	public int ButtonID = 3;
}
