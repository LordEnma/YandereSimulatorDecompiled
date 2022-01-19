using System;
using UnityEngine;

// Token: 0x02000264 RID: 612
public class CraftableItemScript : MonoBehaviour
{
	// Token: 0x060012F2 RID: 4850 RVA: 0x000A77D0 File Offset: 0x000A59D0
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			switch (this.ID)
			{
			case 1:
				this.Prompt.Yandere.Inventory.Ammonium = true;
				break;
			case 2:
				this.Prompt.Yandere.Inventory.Balloons = true;
				break;
			case 3:
				this.Prompt.Yandere.Inventory.Bandages = true;
				break;
			case 4:
				this.Prompt.Yandere.Inventory.Glass = true;
				break;
			case 5:
				this.Prompt.Yandere.Inventory.Hairpins = true;
				break;
			case 6:
				this.Prompt.Yandere.Inventory.Nails = true;
				break;
			case 7:
				this.Prompt.Yandere.Inventory.Paper = true;
				break;
			case 8:
				this.Prompt.Yandere.Inventory.PaperClips = true;
				break;
			case 9:
				this.Prompt.Yandere.Inventory.SilverFulminate = true;
				break;
			case 10:
				this.Prompt.Yandere.Inventory.WoodenSticks = true;
				break;
			}
			this.Prompt.Hide();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001AE6 RID: 6886
	public PromptScript Prompt;

	// Token: 0x04001AE7 RID: 6887
	public int ID;
}
