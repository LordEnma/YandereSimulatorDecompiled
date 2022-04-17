using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001ED3 RID: 7891 RVA: 0x001B30D9 File Offset: 0x001B12D9
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003FE9 RID: 16361
	public PromptScript Prompt;

	// Token: 0x04003FEA RID: 16362
	public Transform Destination;
}
