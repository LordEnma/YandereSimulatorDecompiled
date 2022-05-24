using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001EE6 RID: 7910 RVA: 0x001B5B4D File Offset: 0x001B3D4D
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04004026 RID: 16422
	public PromptScript Prompt;

	// Token: 0x04004027 RID: 16423
	public Transform Destination;
}
