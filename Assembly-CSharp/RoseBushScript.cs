using System;
using UnityEngine;

// Token: 0x020003F3 RID: 1011
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001C08 RID: 7176 RVA: 0x00148780 File Offset: 0x00146980
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

	// Token: 0x04003164 RID: 12644
	public PromptScript Prompt;
}
