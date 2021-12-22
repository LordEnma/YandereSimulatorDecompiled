using System;
using UnityEngine;

// Token: 0x020003C5 RID: 965
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B39 RID: 6969 RVA: 0x0013167C File Offset: 0x0012F87C
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

	// Token: 0x04002E7E RID: 11902
	public PromptScript Prompt;
}
