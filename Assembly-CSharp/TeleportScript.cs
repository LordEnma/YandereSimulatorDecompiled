using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001E92 RID: 7826 RVA: 0x001AD49D File Offset: 0x001AB69D
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003F1F RID: 16159
	public PromptScript Prompt;

	// Token: 0x04003F20 RID: 16160
	public Transform Destination;
}
