using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001EA8 RID: 7848 RVA: 0x001AEE51 File Offset: 0x001AD051
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003F48 RID: 16200
	public PromptScript Prompt;

	// Token: 0x04003F49 RID: 16201
	public Transform Destination;
}
