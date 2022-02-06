using System;
using UnityEngine;

// Token: 0x020003BD RID: 957
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B03 RID: 6915 RVA: 0x0012C34C File Offset: 0x0012A54C
	private void Update()
	{
		if (this.Yandere.transform.position.z < -38f)
		{
			if (!this.Outside)
			{
				this.Outside = true;
				foreach (PromptScript promptScript in this.Prompts)
				{
					if (promptScript != null)
					{
						promptScript.enabled = false;
					}
				}
				return;
			}
		}
		else if (this.Outside)
		{
			this.Outside = false;
			foreach (PromptScript promptScript2 in this.Prompts)
			{
				if (promptScript2 != null)
				{
					promptScript2.enabled = true;
				}
			}
		}
	}

	// Token: 0x04002DB8 RID: 11704
	public PromptScript[] Prompts;

	// Token: 0x04002DB9 RID: 11705
	public int ID;

	// Token: 0x04002DBA RID: 11706
	public Transform Yandere;

	// Token: 0x04002DBB RID: 11707
	public bool Outside;
}
