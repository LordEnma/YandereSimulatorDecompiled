using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B63 RID: 7011 RVA: 0x001347F4 File Offset: 0x001329F4
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

	// Token: 0x04002EF9 RID: 12025
	public PromptScript Prompt;
}
