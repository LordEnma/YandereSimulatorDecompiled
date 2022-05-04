using System;
using UnityEngine;

// Token: 0x02000472 RID: 1138
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001ED2 RID: 7890 RVA: 0x001B3D34 File Offset: 0x001B1F34
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003FE5 RID: 16357
	public PromptScript Prompt;

	// Token: 0x04003FE6 RID: 16358
	public int ButtonID = 3;
}
