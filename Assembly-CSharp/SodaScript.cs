using System;
using UnityEngine;

// Token: 0x0200043C RID: 1084
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001D09 RID: 7433 RVA: 0x0015B7E8 File Offset: 0x001599E8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040034A2 RID: 13474
	public PromptScript Prompt;
}
