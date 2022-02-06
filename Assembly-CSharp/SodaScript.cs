using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CC7 RID: 7367 RVA: 0x00156BA0 File Offset: 0x00154DA0
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040033EB RID: 13291
	public PromptScript Prompt;
}
