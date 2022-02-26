using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001EFA RID: 7930 RVA: 0x001B3DAC File Offset: 0x001B1FAC
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

	// Token: 0x04004065 RID: 16485
	public PromptScript Prompt;
}
