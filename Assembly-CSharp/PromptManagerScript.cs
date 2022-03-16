using System;
using UnityEngine;

// Token: 0x020003BF RID: 959
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B1E RID: 6942 RVA: 0x0012E11C File Offset: 0x0012C31C
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

	// Token: 0x04002E11 RID: 11793
	public PromptScript[] Prompts;

	// Token: 0x04002E12 RID: 11794
	public int ID;

	// Token: 0x04002E13 RID: 11795
	public Transform Yandere;

	// Token: 0x04002E14 RID: 11796
	public bool Outside;
}
