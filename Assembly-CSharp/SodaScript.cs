using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CC2 RID: 7362 RVA: 0x00154DBC File Offset: 0x00152FBC
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040033DC RID: 13276
	public PromptScript Prompt;
}
