using System;
using UnityEngine;

// Token: 0x02000424 RID: 1060
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001CA7 RID: 7335 RVA: 0x00150165 File Offset: 0x0014E365
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001CA8 RID: 7336 RVA: 0x00150180 File Offset: 0x0014E380
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

	// Token: 0x04003315 RID: 13077
	public PromptScript Prompt;

	// Token: 0x04003316 RID: 13078
	public int ID;
}
