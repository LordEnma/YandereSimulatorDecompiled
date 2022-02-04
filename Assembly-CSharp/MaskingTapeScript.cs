using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x0600197D RID: 6525 RVA: 0x00103E58 File Offset: 0x00102058
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

	// Token: 0x040028BD RID: 10429
	public CarryableCardboardBoxScript Box;

	// Token: 0x040028BE RID: 10430
	public PromptScript Prompt;
}
