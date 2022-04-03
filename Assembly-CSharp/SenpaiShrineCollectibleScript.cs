using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C8F RID: 7311 RVA: 0x0014E2F9 File Offset: 0x0014C4F9
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C90 RID: 7312 RVA: 0x0014E314 File Offset: 0x0014C514
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			Debug.Log("Picked up shrine item.");
			this.Prompt.Yandere.StudentManager.Police.EndOfDay.ShrineItemsCollected++;
			this.Prompt.Yandere.Inventory.ShrineCollectibles[this.ID] = true;
			this.Prompt.Hide();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040032DB RID: 13019
	public PromptScript Prompt;

	// Token: 0x040032DC RID: 13020
	public int ID;
}
