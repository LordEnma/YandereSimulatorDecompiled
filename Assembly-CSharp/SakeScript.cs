using System;
using UnityEngine;

// Token: 0x020003F0 RID: 1008
public class SakeScript : MonoBehaviour
{
	// Token: 0x06001BDD RID: 7133 RVA: 0x0014540E File Offset: 0x0014360E
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Sake = true;
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001BDE RID: 7134 RVA: 0x00145448 File Offset: 0x00143648
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

	// Token: 0x040030E8 RID: 12520
	public PromptScript Prompt;
}
