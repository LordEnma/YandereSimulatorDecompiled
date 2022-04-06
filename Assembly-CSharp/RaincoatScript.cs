using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B73 RID: 7027 RVA: 0x00135480 File Offset: 0x00133680
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

	// Token: 0x04002F15 RID: 12053
	public PromptScript Prompt;
}
