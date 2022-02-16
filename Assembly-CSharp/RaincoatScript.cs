using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B4C RID: 6988 RVA: 0x001329F4 File Offset: 0x00130BF4
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

	// Token: 0x04002E9F RID: 11935
	public PromptScript Prompt;
}
