using System;
using UnityEngine;

// Token: 0x020003EC RID: 1004
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BD5 RID: 7125 RVA: 0x00144F70 File Offset: 0x00143170
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

	// Token: 0x040030D4 RID: 12500
	public PromptScript Prompt;
}
