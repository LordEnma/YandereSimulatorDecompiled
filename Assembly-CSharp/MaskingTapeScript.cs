using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x06001978 RID: 6520 RVA: 0x0010349C File Offset: 0x0010169C
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

	// Token: 0x040028AF RID: 10415
	public CarryableCardboardBoxScript Box;

	// Token: 0x040028B0 RID: 10416
	public PromptScript Prompt;
}
