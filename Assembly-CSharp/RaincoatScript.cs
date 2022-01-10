using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B42 RID: 6978 RVA: 0x00131E14 File Offset: 0x00130014
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

	// Token: 0x04002E8B RID: 11915
	public PromptScript Prompt;
}
