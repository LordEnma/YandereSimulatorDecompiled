using System;
using UnityEngine;

// Token: 0x020003F1 RID: 1009
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001BDE RID: 7134 RVA: 0x00145318 File Offset: 0x00143518
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Alphabet.Cheats++;
			this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			this.Prompt.Yandere.SanityPills = true;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x040030E6 RID: 12518
	public PromptScript Prompt;
}
