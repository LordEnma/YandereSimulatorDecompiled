using System;
using UnityEngine;

// Token: 0x020003A3 RID: 931
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A99 RID: 6809 RVA: 0x0011E42C File Offset: 0x0011C62C
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

	// Token: 0x04002C30 RID: 11312
	public GameObject JammingLines;

	// Token: 0x04002C31 RID: 11313
	public PromptScript Prompt;
}
