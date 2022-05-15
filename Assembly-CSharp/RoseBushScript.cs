using System;
using UnityEngine;

// Token: 0x020003F4 RID: 1012
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001C0E RID: 7182 RVA: 0x00149434 File Offset: 0x00147634
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

	// Token: 0x04003179 RID: 12665
	public PromptScript Prompt;
}
