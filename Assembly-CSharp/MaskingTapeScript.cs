using System;
using UnityEngine;

// Token: 0x0200035D RID: 861
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x06001986 RID: 6534 RVA: 0x00104108 File Offset: 0x00102308
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

	// Token: 0x040028C6 RID: 10438
	public CarryableCardboardBoxScript Box;

	// Token: 0x040028C7 RID: 10439
	public PromptScript Prompt;
}
