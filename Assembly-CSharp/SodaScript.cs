using System;
using UnityEngine;

// Token: 0x0200043C RID: 1084
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001D08 RID: 7432 RVA: 0x0015B52C File Offset: 0x0015972C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400349A RID: 13466
	public PromptScript Prompt;
}
