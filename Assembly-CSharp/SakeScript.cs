using System;
using UnityEngine;

// Token: 0x020003F2 RID: 1010
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BEF RID: 7151 RVA: 0x001466C2 File Offset: 0x001448C2
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BF0 RID: 7152 RVA: 0x001466FC File Offset: 0x001448FC
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

	// Token: 0x04003114 RID: 12564
	public PromptScript Prompt;
}
