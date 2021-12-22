using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C58 RID: 7256 RVA: 0x00149129 File Offset: 0x00147329
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C59 RID: 7257 RVA: 0x00149144 File Offset: 0x00147344
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

	// Token: 0x04003243 RID: 12867
	public PromptScript Prompt;

	// Token: 0x04003244 RID: 12868
	public int ID;
}
