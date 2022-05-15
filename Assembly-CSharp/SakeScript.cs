using System;
using UnityEngine;

// Token: 0x020003F9 RID: 1017
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001C1D RID: 7197 RVA: 0x00149BD2 File Offset: 0x00147DD2
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001C1E RID: 7198 RVA: 0x00149C0C File Offset: 0x00147E0C
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

	// Token: 0x04003193 RID: 12691
	public PromptScript Prompt;
}
