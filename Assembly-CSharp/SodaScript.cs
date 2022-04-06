using System;
using UnityEngine;

// Token: 0x0200043A RID: 1082
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CF7 RID: 7415 RVA: 0x00159C60 File Offset: 0x00157E60
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400346B RID: 13419
	public PromptScript Prompt;
}
