using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001ECD RID: 7885 RVA: 0x001B2701 File Offset: 0x001B0901
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003FD9 RID: 16345
	public PromptScript Prompt;

	// Token: 0x04003FDA RID: 16346
	public Transform Destination;
}
