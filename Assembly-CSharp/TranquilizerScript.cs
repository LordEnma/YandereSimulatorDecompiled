using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class TranquilizerScript : MonoBehaviour
{
	// Token: 0x06001F0F RID: 7951 RVA: 0x001B5C24 File Offset: 0x001B3E24
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

	// Token: 0x040040C7 RID: 16583
	public PromptScript Prompt;
}
