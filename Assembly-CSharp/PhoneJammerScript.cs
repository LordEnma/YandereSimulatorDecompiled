using System;
using UnityEngine;

// Token: 0x0200039C RID: 924
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A67 RID: 6759 RVA: 0x0011B4F8 File Offset: 0x001196F8
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

	// Token: 0x04002BB0 RID: 11184
	public GameObject JammingLines;

	// Token: 0x04002BB1 RID: 11185
	public PromptScript Prompt;
}
