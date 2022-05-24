using System;
using UnityEngine;

// Token: 0x020003C4 RID: 964
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B3C RID: 6972 RVA: 0x00130288 File Offset: 0x0012E488
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

	// Token: 0x04002E5E RID: 11870
	public PromptScript[] Prompts;

	// Token: 0x04002E5F RID: 11871
	public int ID;

	// Token: 0x04002E60 RID: 11872
	public Transform Yandere;

	// Token: 0x04002E61 RID: 11873
	public bool Outside;
}
