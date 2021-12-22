using System;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001E83 RID: 7811 RVA: 0x001AB999 File Offset: 0x001A9B99
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003EFD RID: 16125
	public PromptScript Prompt;

	// Token: 0x04003EFE RID: 16126
	public Transform Destination;
}
