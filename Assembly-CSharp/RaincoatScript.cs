using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B43 RID: 6979 RVA: 0x0013252C File Offset: 0x0013072C
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

	// Token: 0x04002E96 RID: 11926
	public PromptScript Prompt;
}
