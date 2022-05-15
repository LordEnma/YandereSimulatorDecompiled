using System;
using UnityEngine;

// Token: 0x020003C4 RID: 964
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B3B RID: 6971 RVA: 0x0013000C File Offset: 0x0012E20C
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

	// Token: 0x04002E56 RID: 11862
	public PromptScript[] Prompts;

	// Token: 0x04002E57 RID: 11863
	public int ID;

	// Token: 0x04002E58 RID: 11864
	public Transform Yandere;

	// Token: 0x04002E59 RID: 11865
	public bool Outside;
}
