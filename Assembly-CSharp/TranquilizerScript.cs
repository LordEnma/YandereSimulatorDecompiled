using System;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001F3A RID: 7994 RVA: 0x001BAAEC File Offset: 0x001B8CEC
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Tranquilizer = true;
			this.Prompt.Yandere.StudentManager.UpdateAllBentos();
			this.Prompt.Yandere.TheftTimer = 0.1f;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004144 RID: 16708
	public PromptScript Prompt;
}
