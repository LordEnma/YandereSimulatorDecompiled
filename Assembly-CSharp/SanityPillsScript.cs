using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class SanityPillsScript : MonoBehaviour
{
	// Token: 0x06001BCA RID: 7114 RVA: 0x00142698 File Offset: 0x00140898
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

	// Token: 0x040030A3 RID: 12451
	public PromptScript Prompt;
}
