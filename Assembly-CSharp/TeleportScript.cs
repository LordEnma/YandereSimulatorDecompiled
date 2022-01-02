using System;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001E85 RID: 7813 RVA: 0x001ABE4D File Offset: 0x001AA04D
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003F04 RID: 16132
	public PromptScript Prompt;

	// Token: 0x04003F05 RID: 16133
	public Transform Destination;
}
