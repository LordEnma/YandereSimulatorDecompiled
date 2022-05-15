using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001EE5 RID: 7909 RVA: 0x001B56BD File Offset: 0x001B38BD
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x0400401D RID: 16413
	public PromptScript Prompt;

	// Token: 0x0400401E RID: 16414
	public Transform Destination;
}
