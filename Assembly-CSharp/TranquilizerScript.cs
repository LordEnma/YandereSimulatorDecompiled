using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001EFD RID: 7933 RVA: 0x001B44D4 File Offset: 0x001B26D4
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

	// Token: 0x0400407C RID: 16508
	public PromptScript Prompt;
}
