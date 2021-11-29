using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x0600196F RID: 6511 RVA: 0x00102980 File Offset: 0x00100B80
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

	// Token: 0x04002886 RID: 10374
	public CarryableCardboardBoxScript Box;

	// Token: 0x04002887 RID: 10375
	public PromptScript Prompt;
}
