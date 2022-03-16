using System;
using UnityEngine;

// Token: 0x02000244 RID: 580
public class ChinaDressScript : MonoBehaviour
{
	// Token: 0x0600124D RID: 4685 RVA: 0x0008CE3C File Offset: 0x0008B03C
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

	// Token: 0x04001726 RID: 5926
	public PromptScript Prompt;
}
