using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B7B RID: 7035 RVA: 0x00135ED4 File Offset: 0x001340D4
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

	// Token: 0x04002F2A RID: 12074
	public PromptScript Prompt;
}
