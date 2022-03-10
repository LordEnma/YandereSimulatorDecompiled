using System;
using UnityEngine;

// Token: 0x02000246 RID: 582
public class CigsScript : MonoBehaviour
{
	// Token: 0x06001250 RID: 4688 RVA: 0x0008CD30 File Offset: 0x0008AF30
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			SchemeGlobals.SetSchemeStage(3, 3);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Cigs = true;
			this.Prompt.Yandere.TheftTimer = 0.1f;
			UnityEngine.Object.Destroy(base.gameObject);
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.StolenObjectID = 1;
			Debug.Log("Yandere-chan just grabbed a box of cigarettes.");
		}
	}

	// Token: 0x04001727 RID: 5927
	public PromptScript Prompt;
}
