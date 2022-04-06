using System;
using UnityEngine;

// Token: 0x020003F7 RID: 1015
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001C0C RID: 7180 RVA: 0x00148306 File Offset: 0x00146506
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x00148340 File Offset: 0x00146540
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

	// Token: 0x04003164 RID: 12644
	public PromptScript Prompt;
}
