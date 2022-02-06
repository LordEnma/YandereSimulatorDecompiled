using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C66 RID: 7270 RVA: 0x0014B67D File Offset: 0x0014987D
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C67 RID: 7271 RVA: 0x0014B698 File Offset: 0x00149898
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

	// Token: 0x0400325F RID: 12895
	public PromptScript Prompt;

	// Token: 0x04003260 RID: 12896
	public int ID;
}
