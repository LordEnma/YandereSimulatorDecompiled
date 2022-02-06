using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001E98 RID: 7832 RVA: 0x001ADE5D File Offset: 0x001AC05D
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003F2F RID: 16175
	public PromptScript Prompt;

	// Token: 0x04003F30 RID: 16176
	public Transform Destination;
}
