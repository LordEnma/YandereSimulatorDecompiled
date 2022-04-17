using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C99 RID: 7321 RVA: 0x0014E9ED File Offset: 0x0014CBED
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C9A RID: 7322 RVA: 0x0014EA08 File Offset: 0x0014CC08
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

	// Token: 0x040032E9 RID: 13033
	public PromptScript Prompt;

	// Token: 0x040032EA RID: 13034
	public int ID;
}
