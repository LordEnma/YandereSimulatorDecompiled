using System;
using UnityEngine;

// Token: 0x02000424 RID: 1060
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001CA6 RID: 7334 RVA: 0x0014FEA9 File Offset: 0x0014E0A9
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001CA7 RID: 7335 RVA: 0x0014FEC4 File Offset: 0x0014E0C4
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

	// Token: 0x0400330D RID: 13069
	public PromptScript Prompt;

	// Token: 0x0400330E RID: 13070
	public int ID;
}
