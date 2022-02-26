using System;
using UnityEngine;

// Token: 0x020003C9 RID: 969
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B55 RID: 6997 RVA: 0x0013343C File Offset: 0x0013163C
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

	// Token: 0x04002EAF RID: 11951
	public PromptScript Prompt;
}
