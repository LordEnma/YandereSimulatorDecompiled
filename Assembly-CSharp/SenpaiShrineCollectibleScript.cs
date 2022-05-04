using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001CA0 RID: 7328 RVA: 0x0014F1F5 File Offset: 0x0014D3F5
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001CA1 RID: 7329 RVA: 0x0014F210 File Offset: 0x0014D410
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

	// Token: 0x040032F8 RID: 13048
	public PromptScript Prompt;

	// Token: 0x040032F9 RID: 13049
	public int ID;
}
