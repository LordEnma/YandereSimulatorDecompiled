using System;
using UnityEngine;

// Token: 0x020003E7 RID: 999
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BB8 RID: 7096 RVA: 0x00141E58 File Offset: 0x00140058
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

	// Token: 0x04003088 RID: 12424
	public PromptScript Prompt;
}
