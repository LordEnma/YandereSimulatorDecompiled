using System;
using UnityEngine;

// Token: 0x020003F2 RID: 1010
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001BE7 RID: 7143 RVA: 0x001457B0 File Offset: 0x001439B0
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

	// Token: 0x040030EF RID: 12527
	public PromptScript Prompt;
}
