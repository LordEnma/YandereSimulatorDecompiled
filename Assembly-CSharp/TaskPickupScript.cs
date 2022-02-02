using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E88 RID: 7816 RVA: 0x001AD190 File Offset: 0x001AB390
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003F0C RID: 16140
	public PromptScript Prompt;

	// Token: 0x04003F0D RID: 16141
	public int ButtonID = 3;
}
