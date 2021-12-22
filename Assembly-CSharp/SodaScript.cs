using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CB9 RID: 7353 RVA: 0x00154674 File Offset: 0x00152874
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040033CF RID: 13263
	public PromptScript Prompt;
}
