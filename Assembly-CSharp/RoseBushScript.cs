using System;
using UnityEngine;

// Token: 0x020003EA RID: 1002
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BC9 RID: 7113 RVA: 0x00142E88 File Offset: 0x00141088
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

	// Token: 0x040030BF RID: 12479
	public PromptScript Prompt;
}
