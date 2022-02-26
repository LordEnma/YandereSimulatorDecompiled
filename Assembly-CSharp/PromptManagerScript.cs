using System;
using UnityEngine;

// Token: 0x020003BF RID: 959
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B13 RID: 6931 RVA: 0x0012D094 File Offset: 0x0012B294
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

	// Token: 0x04002DCE RID: 11726
	public PromptScript[] Prompts;

	// Token: 0x04002DCF RID: 11727
	public int ID;

	// Token: 0x04002DD0 RID: 11728
	public Transform Yandere;

	// Token: 0x04002DD1 RID: 11729
	public bool Outside;
}
