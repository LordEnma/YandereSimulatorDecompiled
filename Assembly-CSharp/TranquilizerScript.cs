using System;
using UnityEngine;

// Token: 0x0200047F RID: 1151
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001ED7 RID: 7895 RVA: 0x001B0DDC File Offset: 0x001AEFDC
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

	// Token: 0x04004020 RID: 16416
	public PromptScript Prompt;
}
