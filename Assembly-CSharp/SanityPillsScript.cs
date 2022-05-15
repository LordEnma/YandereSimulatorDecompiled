using System;
using UnityEngine;

// Token: 0x020003FA RID: 1018
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001C20 RID: 7200 RVA: 0x00149C74 File Offset: 0x00147E74
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

	// Token: 0x04003194 RID: 12692
	public PromptScript Prompt;
}
