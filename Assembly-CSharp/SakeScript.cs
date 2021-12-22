using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BCF RID: 7119 RVA: 0x00142EB6 File Offset: 0x001410B6
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BD0 RID: 7120 RVA: 0x00142EF0 File Offset: 0x001410F0
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

	// Token: 0x040030CC RID: 12492
	public PromptScript Prompt;
}
