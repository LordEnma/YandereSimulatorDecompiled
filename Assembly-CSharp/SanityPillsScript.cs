using System;
using UnityEngine;

// Token: 0x020003F7 RID: 1015
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001C09 RID: 7177 RVA: 0x001480C4 File Offset: 0x001462C4
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

	// Token: 0x04003162 RID: 12642
	public PromptScript Prompt;
}
