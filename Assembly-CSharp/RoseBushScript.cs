using System;
using UnityEngine;

// Token: 0x020003E8 RID: 1000
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BC0 RID: 7104 RVA: 0x00142718 File Offset: 0x00140918
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

	// Token: 0x040030B2 RID: 12466
	public PromptScript Prompt;
}
