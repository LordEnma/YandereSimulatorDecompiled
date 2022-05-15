using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x060019B1 RID: 6577 RVA: 0x00106E60 File Offset: 0x00105060
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

	// Token: 0x04002945 RID: 10565
	public CarryableCardboardBoxScript Box;

	// Token: 0x04002946 RID: 10566
	public PromptScript Prompt;
}
