using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001F27 RID: 7975 RVA: 0x001B8078 File Offset: 0x001B6278
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

	// Token: 0x04004107 RID: 16647
	public PromptScript Prompt;
}
