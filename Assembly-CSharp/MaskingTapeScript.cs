using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x06001976 RID: 6518 RVA: 0x001031DC File Offset: 0x001013DC
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

	// Token: 0x040028AB RID: 10411
	public CarryableCardboardBoxScript Box;

	// Token: 0x040028AC RID: 10412
	public PromptScript Prompt;
}
