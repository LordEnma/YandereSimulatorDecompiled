using System;
using UnityEngine;

// Token: 0x0200043B RID: 1083
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001D02 RID: 7426 RVA: 0x0015A878 File Offset: 0x00158A78
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04003485 RID: 13445
	public PromptScript Prompt;
}
