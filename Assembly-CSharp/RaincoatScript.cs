using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B77 RID: 7031 RVA: 0x00135890 File Offset: 0x00133A90
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

	// Token: 0x04002F20 RID: 12064
	public PromptScript Prompt;
}
