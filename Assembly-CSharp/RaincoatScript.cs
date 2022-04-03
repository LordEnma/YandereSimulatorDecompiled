using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B6D RID: 7021 RVA: 0x00135268 File Offset: 0x00133468
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Invisible)
			{
				this.Prompt.Yandere.WearRaincoat();
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04002F12 RID: 12050
	public PromptScript Prompt;
}
