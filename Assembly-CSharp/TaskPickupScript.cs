using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E8D RID: 7821 RVA: 0x001AD6BC File Offset: 0x001AB8BC
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003F15 RID: 16149
	public PromptScript Prompt;

	// Token: 0x04003F16 RID: 16150
	public int ButtonID = 3;
}
