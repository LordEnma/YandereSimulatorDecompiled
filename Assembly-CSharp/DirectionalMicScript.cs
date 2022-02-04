using System;
using UnityEngine;

// Token: 0x02000284 RID: 644
public class DirectionalMicScript : MonoBehaviour
{
	// Token: 0x0600138F RID: 5007 RVA: 0x000B7947 File Offset: 0x000B5B47
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.DirectionalMic = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001CFF RID: 7423
	public PromptScript Prompt;
}
