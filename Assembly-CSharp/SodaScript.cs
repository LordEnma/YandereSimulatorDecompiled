using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CCE RID: 7374 RVA: 0x00156EA8 File Offset: 0x001550A8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040033F1 RID: 13297
	public PromptScript Prompt;
}
