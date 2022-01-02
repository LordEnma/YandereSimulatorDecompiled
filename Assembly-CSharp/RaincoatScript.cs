using System;
using UnityEngine;

// Token: 0x020003C5 RID: 965
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B3B RID: 6971 RVA: 0x00131A78 File Offset: 0x0012FC78
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

	// Token: 0x04002E85 RID: 11909
	public PromptScript Prompt;
}
