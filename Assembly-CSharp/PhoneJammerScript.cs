using System;
using UnityEngine;

// Token: 0x0200039F RID: 927
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A78 RID: 6776 RVA: 0x0011C324 File Offset: 0x0011A524
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

	// Token: 0x04002BC9 RID: 11209
	public GameObject JammingLines;

	// Token: 0x04002BCA RID: 11210
	public PromptScript Prompt;
}
