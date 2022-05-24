using System;
using UnityEngine;

// Token: 0x02000245 RID: 581
public class ChinaDressScript : MonoBehaviour
{
	// Token: 0x0600124F RID: 4687 RVA: 0x0008D4A0 File Offset: 0x0008B6A0
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.WearChinaDress();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x04001730 RID: 5936
	public PromptScript Prompt;
}
