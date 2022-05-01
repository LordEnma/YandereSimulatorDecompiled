using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x060019AB RID: 6571 RVA: 0x00106658 File Offset: 0x00104858
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.MaskingTape = true;
			this.Box.Prompt.enabled = true;
			this.Box.enabled = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002934 RID: 10548
	public CarryableCardboardBoxScript Box;

	// Token: 0x04002935 RID: 10549
	public PromptScript Prompt;
}
