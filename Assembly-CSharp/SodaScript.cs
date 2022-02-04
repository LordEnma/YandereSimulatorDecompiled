using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CC5 RID: 7365 RVA: 0x00156A08 File Offset: 0x00154C08
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040033E8 RID: 13288
	public PromptScript Prompt;
}
