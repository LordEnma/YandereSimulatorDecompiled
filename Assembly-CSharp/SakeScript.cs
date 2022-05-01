using System;
using UnityEngine;

// Token: 0x020003F8 RID: 1016
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001C17 RID: 7191 RVA: 0x00148F52 File Offset: 0x00147152
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001C18 RID: 7192 RVA: 0x00148F8C File Offset: 0x0014718C
	public void UpdatePrompt()
	{
		if (this.Prompt.Yandere.Inventory.Sake)
		{
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		this.Prompt.enabled = true;
		this.Prompt.Hide();
	}

	// Token: 0x0400317E RID: 12670
	public PromptScript Prompt;
}
