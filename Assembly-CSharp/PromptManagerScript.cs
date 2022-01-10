using System;
using UnityEngine;

// Token: 0x020003BD RID: 957
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B00 RID: 6912 RVA: 0x0012BAC0 File Offset: 0x00129CC0
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

	// Token: 0x04002DAA RID: 11690
	public PromptScript[] Prompts;

	// Token: 0x04002DAB RID: 11691
	public int ID;

	// Token: 0x04002DAC RID: 11692
	public Transform Yandere;

	// Token: 0x04002DAD RID: 11693
	public bool Outside;
}
