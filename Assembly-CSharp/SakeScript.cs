using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BD1 RID: 7121 RVA: 0x001432B2 File Offset: 0x001414B2
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BD2 RID: 7122 RVA: 0x001432EC File Offset: 0x001414EC
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

	// Token: 0x040030D3 RID: 12499
	public PromptScript Prompt;
}
