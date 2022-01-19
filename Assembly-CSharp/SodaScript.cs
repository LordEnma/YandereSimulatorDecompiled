using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CC4 RID: 7364 RVA: 0x001564D0 File Offset: 0x001546D0
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040033E1 RID: 13281
	public PromptScript Prompt;
}
