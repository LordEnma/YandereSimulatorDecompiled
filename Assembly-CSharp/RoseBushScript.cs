using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BE0 RID: 7136 RVA: 0x00145F24 File Offset: 0x00144124
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

	// Token: 0x040030FA RID: 12538
	public PromptScript Prompt;
}
