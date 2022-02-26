using System;
using UnityEngine;

// Token: 0x020003F2 RID: 1010
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BED RID: 7149 RVA: 0x00146186 File Offset: 0x00144386
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BEE RID: 7150 RVA: 0x001461C0 File Offset: 0x001443C0
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

	// Token: 0x040030FE RID: 12542
	public PromptScript Prompt;
}
