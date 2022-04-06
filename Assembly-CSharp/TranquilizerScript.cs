using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001F21 RID: 7969 RVA: 0x001B76A0 File Offset: 0x001B58A0
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

	// Token: 0x040040F7 RID: 16631
	public PromptScript Prompt;
}
