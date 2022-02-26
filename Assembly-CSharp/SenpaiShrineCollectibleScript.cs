using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C76 RID: 7286 RVA: 0x0014C3F5 File Offset: 0x0014A5F5
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C77 RID: 7287 RVA: 0x0014C410 File Offset: 0x0014A610
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

	// Token: 0x04003275 RID: 12917
	public PromptScript Prompt;

	// Token: 0x04003276 RID: 12918
	public int ID;
}
