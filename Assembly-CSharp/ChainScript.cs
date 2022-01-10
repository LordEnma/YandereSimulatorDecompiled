using System;
using UnityEngine;

// Token: 0x0200023B RID: 571
public class ChainScript : MonoBehaviour
{
	// Token: 0x06001234 RID: 4660 RVA: 0x0008B81C File Offset: 0x00089A1C
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

	// Token: 0x040016D8 RID: 5848
	public PromptScript Prompt;

	// Token: 0x040016D9 RID: 5849
	public TarpScript Tarp;

	// Token: 0x040016DA RID: 5850
	public AudioClip ChainRattle;

	// Token: 0x040016DB RID: 5851
	public GameObject[] Chains;

	// Token: 0x040016DC RID: 5852
	public int Unlocked;
}
