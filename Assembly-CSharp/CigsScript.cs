using System;
using UnityEngine;

// Token: 0x02000246 RID: 582
public class CigsScript : MonoBehaviour
{
	// Token: 0x06001252 RID: 4690 RVA: 0x0008D194 File Offset: 0x0008B394
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

	// Token: 0x0400172E RID: 5934
	public PromptScript Prompt;
}
