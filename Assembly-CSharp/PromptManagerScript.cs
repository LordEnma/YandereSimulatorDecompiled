using System;
using UnityEngine;

// Token: 0x020003BE RID: 958
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B0A RID: 6922 RVA: 0x0012C654 File Offset: 0x0012A854
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

	// Token: 0x04002DBE RID: 11710
	public PromptScript[] Prompts;

	// Token: 0x04002DBF RID: 11711
	public int ID;

	// Token: 0x04002DC0 RID: 11712
	public Transform Yandere;

	// Token: 0x04002DC1 RID: 11713
	public bool Outside;
}
