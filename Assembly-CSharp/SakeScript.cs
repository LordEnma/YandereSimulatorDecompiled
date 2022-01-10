using System;
using UnityEngine;

// Token: 0x020003EF RID: 1007
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BD8 RID: 7128 RVA: 0x00143626 File Offset: 0x00141826
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BD9 RID: 7129 RVA: 0x00143660 File Offset: 0x00141860
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

	// Token: 0x040030D9 RID: 12505
	public PromptScript Prompt;
}
