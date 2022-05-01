using System;
using UnityEngine;

// Token: 0x02000265 RID: 613
public class CraftableItemScript : MonoBehaviour
{
	// Token: 0x060012FF RID: 4863 RVA: 0x000A87D4 File Offset: 0x000A69D4
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

	// Token: 0x04001B10 RID: 6928
	public PromptScript Prompt;

	// Token: 0x04001B11 RID: 6929
	public int ID;
}
