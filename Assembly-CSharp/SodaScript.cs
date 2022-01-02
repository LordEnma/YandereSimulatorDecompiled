using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class SodaScript : MonoBehaviour
{
	// Token: 0x06001CBB RID: 7355 RVA: 0x00154AB8 File Offset: 0x00152CB8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Soda = true;
			this.Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040033D6 RID: 13270
	public PromptScript Prompt;
}
