using System;
using UnityEngine;

// Token: 0x020003F4 RID: 1012
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001C0F RID: 7183 RVA: 0x001496F0 File Offset: 0x001478F0
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

	// Token: 0x04003181 RID: 12673
	public PromptScript Prompt;
}
