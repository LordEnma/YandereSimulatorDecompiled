using System;
using UnityEngine;

// Token: 0x020003F1 RID: 1009
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BF7 RID: 7159 RVA: 0x00147884 File Offset: 0x00145A84
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

	// Token: 0x04003147 RID: 12615
	public PromptScript Prompt;
}
