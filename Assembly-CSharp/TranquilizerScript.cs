using System;
using UnityEngine;

// Token: 0x0200047E RID: 1150
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001ECB RID: 7883 RVA: 0x001AFB58 File Offset: 0x001ADD58
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

	// Token: 0x04003FE9 RID: 16361
	public PromptScript Prompt;
}
