using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C64 RID: 7268 RVA: 0x0014B3E1 File Offset: 0x001495E1
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C65 RID: 7269 RVA: 0x0014B3FC File Offset: 0x001495FC
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

	// Token: 0x0400325B RID: 12891
	public PromptScript Prompt;

	// Token: 0x0400325C RID: 12892
	public int ID;
}
