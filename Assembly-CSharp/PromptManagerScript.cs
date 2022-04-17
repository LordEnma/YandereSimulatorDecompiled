using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B31 RID: 6961 RVA: 0x0012EE68 File Offset: 0x0012D068
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

	// Token: 0x04002E38 RID: 11832
	public PromptScript[] Prompts;

	// Token: 0x04002E39 RID: 11833
	public int ID;

	// Token: 0x04002E3A RID: 11834
	public Transform Yandere;

	// Token: 0x04002E3B RID: 11835
	public bool Outside;
}
