using System;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001F39 RID: 7993 RVA: 0x001BA65C File Offset: 0x001B885C
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

	// Token: 0x0400413B RID: 16699
	public PromptScript Prompt;
}
