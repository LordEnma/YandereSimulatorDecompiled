using System;
using UnityEngine;

// Token: 0x0200046C RID: 1132
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001E9F RID: 7839 RVA: 0x001AE315 File Offset: 0x001AC515
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003F38 RID: 16184
	public PromptScript Prompt;

	// Token: 0x04003F39 RID: 16185
	public Transform Destination;
}
