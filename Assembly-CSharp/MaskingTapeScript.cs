using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x0600198F RID: 6543 RVA: 0x00104A38 File Offset: 0x00102C38
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

	// Token: 0x040028D5 RID: 10453
	public CarryableCardboardBoxScript Box;

	// Token: 0x040028D6 RID: 10454
	public PromptScript Prompt;
}
