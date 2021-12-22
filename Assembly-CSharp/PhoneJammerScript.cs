using System;
using UnityEngine;

// Token: 0x0200039C RID: 924
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A65 RID: 6757 RVA: 0x0011B21C File Offset: 0x0011941C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Alphabet.Cheats++;
			this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			this.Prompt.Yandere.StudentManager.Jammed = true;
			this.JammingLines.SetActive(true);
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			base.enabled = false;
		}
	}

	// Token: 0x04002BAC RID: 11180
	public GameObject JammingLines;

	// Token: 0x04002BAD RID: 11181
	public PromptScript Prompt;
}
