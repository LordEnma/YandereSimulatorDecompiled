using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x06001997 RID: 6551 RVA: 0x00105718 File Offset: 0x00103918
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

	// Token: 0x0400290D RID: 10509
	public CarryableCardboardBoxScript Box;

	// Token: 0x0400290E RID: 10510
	public PromptScript Prompt;
}
