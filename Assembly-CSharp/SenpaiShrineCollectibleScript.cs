using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C64 RID: 7268 RVA: 0x0014B4E5 File Offset: 0x001496E5
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C65 RID: 7269 RVA: 0x0014B500 File Offset: 0x00149700
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

	// Token: 0x0400325C RID: 12892
	public PromptScript Prompt;

	// Token: 0x0400325D RID: 12893
	public int ID;
}
