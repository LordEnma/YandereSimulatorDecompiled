using System;
using UnityEngine;

// Token: 0x0200023C RID: 572
public class ChainScript : MonoBehaviour
{
	// Token: 0x06001239 RID: 4665 RVA: 0x0008C618 File Offset: 0x0008A818
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

	// Token: 0x040016F7 RID: 5879
	public PromptScript Prompt;

	// Token: 0x040016F8 RID: 5880
	public TarpScript Tarp;

	// Token: 0x040016F9 RID: 5881
	public AudioClip ChainRattle;

	// Token: 0x040016FA RID: 5882
	public GameObject[] Chains;

	// Token: 0x040016FB RID: 5883
	public int Unlocked;
}
