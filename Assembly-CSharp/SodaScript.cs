using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CD9 RID: 7385 RVA: 0x00157ED8 File Offset: 0x001560D8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04003417 RID: 13335
	public PromptScript Prompt;
}
