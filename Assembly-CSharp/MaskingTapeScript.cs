using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x060019B2 RID: 6578 RVA: 0x00107064 File Offset: 0x00105264
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.MaskingTape = true;
			this.Box.Prompt.enabled = true;
			this.Box.enabled = true;
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0400294C RID: 10572
	public CarryableCardboardBoxScript Box;

	// Token: 0x0400294D RID: 10573
	public PromptScript Prompt;
}
