using System;
using UnityEngine;

// Token: 0x02000439 RID: 1081
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CF0 RID: 7408 RVA: 0x00159940 File Offset: 0x00157B40
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04003468 RID: 13416
	public PromptScript Prompt;
}
