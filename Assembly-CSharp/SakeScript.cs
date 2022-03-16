using System;
using UnityEngine;

// Token: 0x020003F3 RID: 1011
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BFC RID: 7164 RVA: 0x00147566 File Offset: 0x00145766
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BFD RID: 7165 RVA: 0x001475A0 File Offset: 0x001457A0
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

	// Token: 0x04003148 RID: 12616
	public PromptScript Prompt;
}
