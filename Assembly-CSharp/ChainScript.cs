using System;
using UnityEngine;

// Token: 0x0200023B RID: 571
public class ChainScript : MonoBehaviour
{
	// Token: 0x06001237 RID: 4663 RVA: 0x0008C07C File Offset: 0x0008A27C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Inventory.MysteriousKeys > 0)
			{
				AudioSource.PlayClipAtPoint(this.ChainRattle, base.transform.position);
				this.Unlocked++;
				this.Chains[this.Unlocked].SetActive(false);
				this.Prompt.Yandere.Inventory.MysteriousKeys--;
				if (this.Unlocked == 5)
				{
					this.Tarp.Prompt.enabled = true;
					this.Tarp.enabled = true;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x040016EE RID: 5870
	public PromptScript Prompt;

	// Token: 0x040016EF RID: 5871
	public TarpScript Tarp;

	// Token: 0x040016F0 RID: 5872
	public AudioClip ChainRattle;

	// Token: 0x040016F1 RID: 5873
	public GameObject[] Chains;

	// Token: 0x040016F2 RID: 5874
	public int Unlocked;
}
