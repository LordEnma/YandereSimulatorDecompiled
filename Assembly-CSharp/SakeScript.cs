using System;
using UnityEngine;

// Token: 0x020003F6 RID: 1014
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001C06 RID: 7174 RVA: 0x00148022 File Offset: 0x00146222
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001C07 RID: 7175 RVA: 0x0014805C File Offset: 0x0014625C
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

	// Token: 0x04003161 RID: 12641
	public PromptScript Prompt;
}
