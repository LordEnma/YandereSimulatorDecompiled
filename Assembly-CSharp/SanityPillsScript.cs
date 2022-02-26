using System;
using UnityEngine;

// Token: 0x020003F3 RID: 1011
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001BF0 RID: 7152 RVA: 0x00146228 File Offset: 0x00144428
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

	// Token: 0x040030FF RID: 12543
	public PromptScript Prompt;
}
