using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CC5 RID: 7365 RVA: 0x00156904 File Offset: 0x00154B04
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040033E7 RID: 13287
	public PromptScript Prompt;
}
