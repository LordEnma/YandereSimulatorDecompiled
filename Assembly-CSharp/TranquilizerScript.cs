using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001EE7 RID: 7911 RVA: 0x001B2C10 File Offset: 0x001B0E10
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

	// Token: 0x04004049 RID: 16457
	public PromptScript Prompt;
}
