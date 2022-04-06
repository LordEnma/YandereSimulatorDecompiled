using System;
using UnityEngine;

// Token: 0x020003F2 RID: 1010
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BFD RID: 7165 RVA: 0x00147B68 File Offset: 0x00145D68
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

	// Token: 0x0400314A RID: 12618
	public PromptScript Prompt;
}
