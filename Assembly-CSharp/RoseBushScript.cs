using System;
using UnityEngine;

// Token: 0x020003EE RID: 1006
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BED RID: 7149 RVA: 0x00146DC8 File Offset: 0x00144FC8
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

	// Token: 0x0400312E RID: 12590
	public PromptScript Prompt;
}
