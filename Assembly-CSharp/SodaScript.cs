using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CB1 RID: 7345 RVA: 0x00153D50 File Offset: 0x00151F50
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040033A4 RID: 13220
	public PromptScript Prompt;
}
