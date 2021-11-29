using System;
using UnityEngine;

// Token: 0x0200023A RID: 570
public class ChainScript : MonoBehaviour
{
	// Token: 0x06001231 RID: 4657 RVA: 0x0008B674 File Offset: 0x00089874
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

	// Token: 0x040016D6 RID: 5846
	public PromptScript Prompt;

	// Token: 0x040016D7 RID: 5847
	public TarpScript Tarp;

	// Token: 0x040016D8 RID: 5848
	public AudioClip ChainRattle;

	// Token: 0x040016D9 RID: 5849
	public GameObject[] Chains;

	// Token: 0x040016DA RID: 5850
	public int Unlocked;
}
