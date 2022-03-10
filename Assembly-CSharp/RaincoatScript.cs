using System;
using UnityEngine;

// Token: 0x020003C9 RID: 969
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B56 RID: 6998 RVA: 0x00133954 File Offset: 0x00131B54
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

	// Token: 0x04002EC5 RID: 11973
	public PromptScript Prompt;
}
