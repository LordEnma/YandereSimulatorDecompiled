using System;
using UnityEngine;

// Token: 0x020003F0 RID: 1008
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BDA RID: 7130 RVA: 0x00144D2E File Offset: 0x00142F2E
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BDB RID: 7131 RVA: 0x00144D68 File Offset: 0x00142F68
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

	// Token: 0x040030DE RID: 12510
	public PromptScript Prompt;
}
