using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A5D RID: 6749 RVA: 0x0011A9DC File Offset: 0x00118BDC
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

	// Token: 0x04002B82 RID: 11138
	public GameObject JammingLines;

	// Token: 0x04002B83 RID: 11139
	public PromptScript Prompt;
}
