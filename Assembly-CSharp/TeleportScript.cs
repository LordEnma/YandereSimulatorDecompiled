using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001EAB RID: 7851 RVA: 0x001AF579 File Offset: 0x001AD779
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003F5F RID: 16223
	public PromptScript Prompt;

	// Token: 0x04003F60 RID: 16224
	public Transform Destination;
}
