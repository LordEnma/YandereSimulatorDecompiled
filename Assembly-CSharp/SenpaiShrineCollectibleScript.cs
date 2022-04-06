using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C95 RID: 7317 RVA: 0x0014E5DD File Offset: 0x0014C7DD
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C96 RID: 7318 RVA: 0x0014E5F8 File Offset: 0x0014C7F8
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

	// Token: 0x040032DE RID: 13022
	public PromptScript Prompt;

	// Token: 0x040032DF RID: 13023
	public int ID;
}
