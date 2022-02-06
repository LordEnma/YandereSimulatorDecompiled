using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B45 RID: 6981 RVA: 0x001326C4 File Offset: 0x001308C4
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

	// Token: 0x04002E99 RID: 11929
	public PromptScript Prompt;
}
