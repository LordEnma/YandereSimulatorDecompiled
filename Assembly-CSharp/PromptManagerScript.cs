using System;
using UnityEngine;

// Token: 0x020003BB RID: 955
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001AF9 RID: 6905 RVA: 0x0012B6E8 File Offset: 0x001298E8
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

	// Token: 0x04002DA4 RID: 11684
	public PromptScript[] Prompts;

	// Token: 0x04002DA5 RID: 11685
	public int ID;

	// Token: 0x04002DA6 RID: 11686
	public Transform Yandere;

	// Token: 0x04002DA7 RID: 11687
	public bool Outside;
}
