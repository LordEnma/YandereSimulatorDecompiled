using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001EE4 RID: 7908 RVA: 0x001B242C File Offset: 0x001B062C
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

	// Token: 0x0400403B RID: 16443
	public PromptScript Prompt;
}
