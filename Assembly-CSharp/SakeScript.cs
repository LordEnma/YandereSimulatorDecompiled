using System;
using UnityEngine;

// Token: 0x020003F0 RID: 1008
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BDB RID: 7131 RVA: 0x00145276 File Offset: 0x00143476
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BDC RID: 7132 RVA: 0x001452B0 File Offset: 0x001434B0
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

	// Token: 0x040030E5 RID: 12517
	public PromptScript Prompt;
}
