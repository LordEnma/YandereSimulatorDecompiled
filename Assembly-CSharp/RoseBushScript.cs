using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BDE RID: 7134 RVA: 0x001459E8 File Offset: 0x00143BE8
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

	// Token: 0x040030E4 RID: 12516
	public PromptScript Prompt;
}
