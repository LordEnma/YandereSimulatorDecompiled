using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C61 RID: 7265 RVA: 0x001498A5 File Offset: 0x00147AA5
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C62 RID: 7266 RVA: 0x001498C0 File Offset: 0x00147AC0
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.Police.EndOfDay.ShrineItemsCollected++;
			this.Prompt.Yandere.Inventory.ShrineCollectibles[this.ID] = true;
			this.Prompt.Hide();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04003250 RID: 12880
	public PromptScript Prompt;

	// Token: 0x04003251 RID: 12881
	public int ID;
}
