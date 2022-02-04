using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001E95 RID: 7829 RVA: 0x001ADC3D File Offset: 0x001ABE3D
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003F2C RID: 16172
	public PromptScript Prompt;

	// Token: 0x04003F2D RID: 16173
	public Transform Destination;
}
