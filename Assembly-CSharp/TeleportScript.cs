using System;
using UnityEngine;

// Token: 0x0200046A RID: 1130
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001E90 RID: 7824 RVA: 0x001AC7CD File Offset: 0x001AA9CD
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003F18 RID: 16152
	public PromptScript Prompt;

	// Token: 0x04003F19 RID: 16153
	public Transform Destination;
}
