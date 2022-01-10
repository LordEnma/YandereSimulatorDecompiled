using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001EE2 RID: 7906 RVA: 0x001B175C File Offset: 0x001AF95C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Tranquilizer = true;
			this.Prompt.Yandere.StudentManager.UpdateAllBentos();
			this.Prompt.Yandere.TheftTimer = 0.1f;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004034 RID: 16436
	public PromptScript Prompt;
}
