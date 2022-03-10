using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C78 RID: 7288 RVA: 0x0014C931 File Offset: 0x0014AB31
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C79 RID: 7289 RVA: 0x0014C94C File Offset: 0x0014AB4C
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

	// Token: 0x0400328B RID: 12939
	public PromptScript Prompt;

	// Token: 0x0400328C RID: 12940
	public int ID;
}
