using System;
using UnityEngine;

// Token: 0x020003C2 RID: 962
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B27 RID: 6951 RVA: 0x0012E8AC File Offset: 0x0012CAAC
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

	// Token: 0x04002E2A RID: 11818
	public PromptScript[] Prompts;

	// Token: 0x04002E2B RID: 11819
	public int ID;

	// Token: 0x04002E2C RID: 11820
	public Transform Yandere;

	// Token: 0x04002E2D RID: 11821
	public bool Outside;
}
