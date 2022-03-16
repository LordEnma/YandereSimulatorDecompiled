using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	// Token: 0x06001C85 RID: 7301 RVA: 0x0014D7D5 File Offset: 0x0014B9D5
	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(this.ID))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C86 RID: 7302 RVA: 0x0014D7F0 File Offset: 0x0014B9F0
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

	// Token: 0x040032BF RID: 12991
	public PromptScript Prompt;

	// Token: 0x040032C0 RID: 12992
	public int ID;
}
