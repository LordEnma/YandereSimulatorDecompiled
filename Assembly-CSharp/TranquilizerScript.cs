using System;
using UnityEngine;

// Token: 0x02000483 RID: 1155
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001EF1 RID: 7921 RVA: 0x001B3260 File Offset: 0x001B1460
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

	// Token: 0x04004055 RID: 16469
	public PromptScript Prompt;
}
