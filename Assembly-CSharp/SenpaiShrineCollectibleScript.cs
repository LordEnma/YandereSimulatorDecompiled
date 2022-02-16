using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C6D RID: 7277 RVA: 0x0014B97D File Offset: 0x00149B7D
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C6E RID: 7278 RVA: 0x0014B998 File Offset: 0x00149B98
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

	// Token: 0x04003265 RID: 12901
	public PromptScript Prompt;

	// Token: 0x04003266 RID: 12902
	public int ID;
}
