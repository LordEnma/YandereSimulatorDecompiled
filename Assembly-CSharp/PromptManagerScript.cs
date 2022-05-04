using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B35 RID: 6965 RVA: 0x0012F448 File Offset: 0x0012D648
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

	// Token: 0x04002E41 RID: 11841
	public PromptScript[] Prompts;

	// Token: 0x04002E42 RID: 11842
	public int ID;

	// Token: 0x04002E43 RID: 11843
	public Transform Yandere;

	// Token: 0x04002E44 RID: 11844
	public bool Outside;
}
