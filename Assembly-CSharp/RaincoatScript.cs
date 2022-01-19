using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B42 RID: 6978 RVA: 0x00131FE4 File Offset: 0x001301E4
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

	// Token: 0x04002E8F RID: 11919
	public PromptScript Prompt;
}
