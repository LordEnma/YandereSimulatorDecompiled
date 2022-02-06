using System;
using UnityEngine;

// Token: 0x020003EB RID: 1003
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BCE RID: 7118 RVA: 0x00144C70 File Offset: 0x00142E70
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Rose = true;
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x040030CE RID: 12494
	public PromptScript Prompt;
}
