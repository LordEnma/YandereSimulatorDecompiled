using System;
using UnityEngine;

// Token: 0x02000244 RID: 580
public class ChinaDressScript : MonoBehaviour
{
	// Token: 0x0600124A RID: 4682 RVA: 0x0008C6B4 File Offset: 0x0008A8B4
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

	// Token: 0x04001713 RID: 5907
	public PromptScript Prompt;
}
