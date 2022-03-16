using System;
using UnityEngine;

// Token: 0x020003F4 RID: 1012
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001BFF RID: 7167 RVA: 0x00147608 File Offset: 0x00145808
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

	// Token: 0x04003149 RID: 12617
	public PromptScript Prompt;
}
