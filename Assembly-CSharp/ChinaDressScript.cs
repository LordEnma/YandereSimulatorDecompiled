using System;
using UnityEngine;

// Token: 0x02000243 RID: 579
public class ChinaDressScript : MonoBehaviour
{
	// Token: 0x06001247 RID: 4679 RVA: 0x0008C4D0 File Offset: 0x0008A6D0
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

	// Token: 0x0400170F RID: 5903
	public PromptScript Prompt;
}
