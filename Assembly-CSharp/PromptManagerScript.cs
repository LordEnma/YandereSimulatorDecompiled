using System;
using UnityEngine;

// Token: 0x020003BD RID: 957
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B00 RID: 6912 RVA: 0x0012BC44 File Offset: 0x00129E44
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

	// Token: 0x04002DAE RID: 11694
	public PromptScript[] Prompts;

	// Token: 0x04002DAF RID: 11695
	public int ID;

	// Token: 0x04002DB0 RID: 11696
	public Transform Yandere;

	// Token: 0x04002DB1 RID: 11697
	public bool Outside;
}
