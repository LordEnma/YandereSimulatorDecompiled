using System;
using UnityEngine;

// Token: 0x020003E8 RID: 1000
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BC2 RID: 7106 RVA: 0x00142B14 File Offset: 0x00140D14
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

	// Token: 0x040030B9 RID: 12473
	public PromptScript Prompt;
}
