using System;
using UnityEngine;

// Token: 0x020003F1 RID: 1009
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BE4 RID: 7140 RVA: 0x0014570E File Offset: 0x0014390E
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BE5 RID: 7141 RVA: 0x00145748 File Offset: 0x00143948
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

	// Token: 0x040030EE RID: 12526
	public PromptScript Prompt;
}
