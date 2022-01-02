using System;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class TaskPickupScript : MonoBehaviour
{
	// Token: 0x06001E7A RID: 7802 RVA: 0x001AB6AC File Offset: 0x001A98AC
	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.Inventory.Bra = true;
		}
	}

	// Token: 0x04003EEA RID: 16106
	public PromptScript Prompt;

	// Token: 0x04003EEB RID: 16107
	public int ButtonID = 3;
}
