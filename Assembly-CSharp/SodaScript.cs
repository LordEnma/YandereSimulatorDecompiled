using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CE6 RID: 7398 RVA: 0x00158DE4 File Offset: 0x00156FE4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400344C RID: 13388
	public PromptScript Prompt;
}
