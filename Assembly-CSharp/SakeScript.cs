using System;
using UnityEngine;

// Token: 0x020003F7 RID: 1015
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001C10 RID: 7184 RVA: 0x00148716 File Offset: 0x00146916
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001C11 RID: 7185 RVA: 0x00148750 File Offset: 0x00146950
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

	// Token: 0x0400316F RID: 12655
	public PromptScript Prompt;
}
