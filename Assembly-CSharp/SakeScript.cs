using System;
using UnityEngine;

// Token: 0x020003F9 RID: 1017
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001C1E RID: 7198 RVA: 0x00149E8E File Offset: 0x0014808E
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001C1F RID: 7199 RVA: 0x00149EC8 File Offset: 0x001480C8
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

	// Token: 0x0400319B RID: 12699
	public PromptScript Prompt;
}
