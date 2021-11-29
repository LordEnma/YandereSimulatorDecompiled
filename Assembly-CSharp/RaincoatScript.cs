using System;
using UnityEngine;

// Token: 0x020003C4 RID: 964
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B31 RID: 6961 RVA: 0x00130DBC File Offset: 0x0012EFBC
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

	// Token: 0x04002E54 RID: 11860
	public PromptScript Prompt;
}
