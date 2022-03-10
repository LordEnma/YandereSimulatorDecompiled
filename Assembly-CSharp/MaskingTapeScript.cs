using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x0600198F RID: 6543 RVA: 0x00104DA0 File Offset: 0x00102FA0
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

	// Token: 0x040028EB RID: 10475
	public CarryableCardboardBoxScript Box;

	// Token: 0x040028EC RID: 10476
	public PromptScript Prompt;
}
