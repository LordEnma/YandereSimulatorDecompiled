using System;
using UnityEngine;

// Token: 0x02000244 RID: 580
public class ChinaDressScript : MonoBehaviour
{
	// Token: 0x0600124A RID: 4682 RVA: 0x0008C664 File Offset: 0x0008A864
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

	// Token: 0x04001711 RID: 5905
	public PromptScript Prompt;
}
