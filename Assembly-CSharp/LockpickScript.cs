using System;
using UnityEngine;

// Token: 0x02000356 RID: 854
public class LockpickScript : MonoBehaviour
{
	// Token: 0x0600196D RID: 6509 RVA: 0x001012E5 File Offset: 0x000FF4E5
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.LockPick = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400286C RID: 10348
	public PromptScript Prompt;
}
