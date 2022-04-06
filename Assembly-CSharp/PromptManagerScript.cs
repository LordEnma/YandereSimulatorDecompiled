using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B2D RID: 6957 RVA: 0x0012EA58 File Offset: 0x0012CC58
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

	// Token: 0x04002E2D RID: 11821
	public PromptScript[] Prompts;

	// Token: 0x04002E2E RID: 11822
	public int ID;

	// Token: 0x04002E2F RID: 11823
	public Transform Yandere;

	// Token: 0x04002E30 RID: 11824
	public bool Outside;
}
