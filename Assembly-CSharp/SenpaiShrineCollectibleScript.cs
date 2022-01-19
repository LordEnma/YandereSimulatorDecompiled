using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C63 RID: 7267 RVA: 0x0014AFAD File Offset: 0x001491AD
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C64 RID: 7268 RVA: 0x0014AFC8 File Offset: 0x001491C8
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

	// Token: 0x04003255 RID: 12885
	public PromptScript Prompt;

	// Token: 0x04003256 RID: 12886
	public int ID;
}
