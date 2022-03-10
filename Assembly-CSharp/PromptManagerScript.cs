using System;
using UnityEngine;

// Token: 0x020003BF RID: 959
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B14 RID: 6932 RVA: 0x0012D46C File Offset: 0x0012B66C
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

	// Token: 0x04002DE4 RID: 11748
	public PromptScript[] Prompts;

	// Token: 0x04002DE5 RID: 11749
	public int ID;

	// Token: 0x04002DE6 RID: 11750
	public Transform Yandere;

	// Token: 0x04002DE7 RID: 11751
	public bool Outside;
}
