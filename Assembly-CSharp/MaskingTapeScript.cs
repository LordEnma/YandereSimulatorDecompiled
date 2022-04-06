using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x060019A3 RID: 6563 RVA: 0x00105EC4 File Offset: 0x001040C4
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

	// Token: 0x04002923 RID: 10531
	public CarryableCardboardBoxScript Box;

	// Token: 0x04002924 RID: 10532
	public PromptScript Prompt;
}
