using System;
using UnityEngine;

// Token: 0x020003F0 RID: 1008
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BDB RID: 7131 RVA: 0x00145172 File Offset: 0x00143372
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BDC RID: 7132 RVA: 0x001451AC File Offset: 0x001433AC
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

	// Token: 0x040030E4 RID: 12516
	public PromptScript Prompt;
}
