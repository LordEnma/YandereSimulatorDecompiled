using System;
using UnityEngine;

// Token: 0x0200046F RID: 1135
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001EBB RID: 7867 RVA: 0x001B0C85 File Offset: 0x001AEE85
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003FA9 RID: 16297
	public PromptScript Prompt;

	// Token: 0x04003FAA RID: 16298
	public Transform Destination;
}
