using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CD7 RID: 7383 RVA: 0x00157954 File Offset: 0x00155B54
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04003401 RID: 13313
	public PromptScript Prompt;
}
