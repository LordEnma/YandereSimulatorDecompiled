using System;
using UnityEngine;

// Token: 0x020003F0 RID: 1008
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001BDB RID: 7131 RVA: 0x001436C8 File Offset: 0x001418C8
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

	// Token: 0x040030DA RID: 12506
	public PromptScript Prompt;
}
