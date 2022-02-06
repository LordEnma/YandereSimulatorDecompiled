using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x0600197F RID: 6527 RVA: 0x00103F64 File Offset: 0x00102164
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

	// Token: 0x040028C0 RID: 10432
	public CarryableCardboardBoxScript Box;

	// Token: 0x040028C1 RID: 10433
	public PromptScript Prompt;
}
