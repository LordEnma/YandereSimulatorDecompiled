using System;
using UnityEngine;

// Token: 0x020003F9 RID: 1017
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001C1A RID: 7194 RVA: 0x00148FF4 File Offset: 0x001471F4
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

	// Token: 0x0400317F RID: 12671
	public PromptScript Prompt;
}
