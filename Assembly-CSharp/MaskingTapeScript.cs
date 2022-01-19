using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x0600197C RID: 6524 RVA: 0x00103964 File Offset: 0x00101B64
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

	// Token: 0x040028B6 RID: 10422
	public CarryableCardboardBoxScript Box;

	// Token: 0x040028B7 RID: 10423
	public PromptScript Prompt;
}
