using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001EE5 RID: 7909 RVA: 0x001B2904 File Offset: 0x001B0B04
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

	// Token: 0x04004043 RID: 16451
	public PromptScript Prompt;
}
