using System;
using UnityEngine;

// Token: 0x020003EC RID: 1004
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BC7 RID: 7111 RVA: 0x001425F6 File Offset: 0x001407F6
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BC8 RID: 7112 RVA: 0x00142630 File Offset: 0x00140830
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

	// Token: 0x040030A2 RID: 12450
	public PromptScript Prompt;
}
