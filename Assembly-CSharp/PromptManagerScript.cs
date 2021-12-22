using System;
using UnityEngine;

// Token: 0x020003BB RID: 955
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001AF7 RID: 6903 RVA: 0x0012B398 File Offset: 0x00129598
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

	// Token: 0x04002D9F RID: 11679
	public PromptScript[] Prompts;

	// Token: 0x04002DA0 RID: 11680
	public int ID;

	// Token: 0x04002DA1 RID: 11681
	public Transform Yandere;

	// Token: 0x04002DA2 RID: 11682
	public bool Outside;
}
