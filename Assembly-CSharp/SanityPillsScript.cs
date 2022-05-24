using System;
using UnityEngine;

// Token: 0x020003FA RID: 1018
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001C21 RID: 7201 RVA: 0x00149F30 File Offset: 0x00148130
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

	// Token: 0x0400319C RID: 12700
	public PromptScript Prompt;
}
