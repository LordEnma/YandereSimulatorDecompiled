using System;
using UnityEngine;

// Token: 0x0200043A RID: 1082
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CFB RID: 7419 RVA: 0x0015A070 File Offset: 0x00158270
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04003476 RID: 13430
	public PromptScript Prompt;
}
