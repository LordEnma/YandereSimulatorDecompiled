using System;
using UnityEngine;

// Token: 0x02000467 RID: 1127
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001E79 RID: 7801 RVA: 0x001AAC0D File Offset: 0x001A8E0D
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003ECD RID: 16077
	public PromptScript Prompt;

	// Token: 0x04003ECE RID: 16078
	public Transform Destination;
}
