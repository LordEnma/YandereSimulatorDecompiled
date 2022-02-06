using System;
using UnityEngine;

// Token: 0x020003F1 RID: 1009
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001BE0 RID: 7136 RVA: 0x001454B0 File Offset: 0x001436B0
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

	// Token: 0x040030E9 RID: 12521
	public PromptScript Prompt;
}
