using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001E93 RID: 7827 RVA: 0x001AD931 File Offset: 0x001ABB31
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003F26 RID: 16166
	public PromptScript Prompt;

	// Token: 0x04003F27 RID: 16167
	public Transform Destination;
}
