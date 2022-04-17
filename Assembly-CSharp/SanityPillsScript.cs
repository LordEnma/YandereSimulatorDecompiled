using System;
using UnityEngine;

// Token: 0x020003F8 RID: 1016
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001C13 RID: 7187 RVA: 0x001487B8 File Offset: 0x001469B8
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

	// Token: 0x04003170 RID: 12656
	public PromptScript Prompt;
}
