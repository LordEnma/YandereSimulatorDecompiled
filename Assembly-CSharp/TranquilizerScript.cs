using System;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001F19 RID: 7961 RVA: 0x001B7198 File Offset: 0x001B5398
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

	// Token: 0x040040F4 RID: 16628
	public PromptScript Prompt;
}
