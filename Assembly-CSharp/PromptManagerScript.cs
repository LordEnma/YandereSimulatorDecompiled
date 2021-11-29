using System;
using UnityEngine;

// Token: 0x020003BA RID: 954
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001AEF RID: 6895 RVA: 0x0012AB44 File Offset: 0x00128D44
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

	// Token: 0x04002D75 RID: 11637
	public PromptScript[] Prompts;

	// Token: 0x04002D76 RID: 11638
	public int ID;

	// Token: 0x04002D77 RID: 11639
	public Transform Yandere;

	// Token: 0x04002D78 RID: 11640
	public bool Outside;
}
