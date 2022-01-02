using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C5A RID: 7258 RVA: 0x00149531 File Offset: 0x00147731
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C5B RID: 7259 RVA: 0x0014954C File Offset: 0x0014774C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.Police.EndOfDay.ShrineItemsCollected++;
			this.Prompt.Yandere.Inventory.ShrineCollectibles[this.ID] = true;
			this.Prompt.Hide();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400324A RID: 12874
	public PromptScript Prompt;

	// Token: 0x0400324B RID: 12875
	public int ID;
}
