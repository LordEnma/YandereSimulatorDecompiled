using System;
using UnityEngine;

// Token: 0x0200032E RID: 814
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018CE RID: 6350 RVA: 0x000F483C File Offset: 0x000F2A3C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.StolenObject = base.gameObject;
			if (!this.Fake)
			{
				this.Prompt.Yandere.Inventory.IDCard = true;
				this.Prompt.Yandere.TheftTimer = 1f;
			}
			else
			{
				this.Prompt.Yandere.Inventory.FakeID = true;
			}
			this.Prompt.Hide();
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x040025F5 RID: 9717
	public PromptScript Prompt;

	// Token: 0x040025F6 RID: 9718
	public bool Fake;
}
