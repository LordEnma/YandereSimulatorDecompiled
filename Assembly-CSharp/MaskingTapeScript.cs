using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x0600199D RID: 6557 RVA: 0x00105DC4 File Offset: 0x00103FC4
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

	// Token: 0x04002920 RID: 10528
	public CarryableCardboardBoxScript Box;

	// Token: 0x04002921 RID: 10529
	public PromptScript Prompt;
}
