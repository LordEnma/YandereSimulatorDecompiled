using System;
using UnityEngine;

// Token: 0x020003F2 RID: 1010
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001C01 RID: 7169 RVA: 0x00147F78 File Offset: 0x00146178
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

	// Token: 0x04003155 RID: 12629
	public PromptScript Prompt;
}
