using System;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001F30 RID: 7984 RVA: 0x001B93E8 File Offset: 0x001B75E8
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

	// Token: 0x0400411D RID: 16669
	public PromptScript Prompt;
}
