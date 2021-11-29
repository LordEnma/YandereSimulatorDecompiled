using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C50 RID: 7248 RVA: 0x0014884D File Offset: 0x00146A4D
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C51 RID: 7249 RVA: 0x00148868 File Offset: 0x00146A68
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

	// Token: 0x04003218 RID: 12824
	public PromptScript Prompt;

	// Token: 0x04003219 RID: 12825
	public int ID;
}
