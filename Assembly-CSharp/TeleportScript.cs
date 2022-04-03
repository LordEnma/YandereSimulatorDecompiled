using System;
using UnityEngine;

// Token: 0x02000472 RID: 1138
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001EC5 RID: 7877 RVA: 0x001B21F9 File Offset: 0x001B03F9
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003FD6 RID: 16342
	public PromptScript Prompt;

	// Token: 0x04003FD7 RID: 16343
	public Transform Destination;
}
