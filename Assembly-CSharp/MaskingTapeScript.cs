using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MaskingTapeScript : MonoBehaviour
{
	// Token: 0x060019A7 RID: 6567 RVA: 0x00106158 File Offset: 0x00104358
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

	// Token: 0x0400292B RID: 10539
	public CarryableCardboardBoxScript Box;

	// Token: 0x0400292C RID: 10540
	public PromptScript Prompt;
}
