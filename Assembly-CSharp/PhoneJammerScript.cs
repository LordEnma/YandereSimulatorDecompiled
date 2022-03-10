using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A82 RID: 6786 RVA: 0x0011D110 File Offset: 0x0011B310
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

	// Token: 0x04002BEF RID: 11247
	public GameObject JammingLines;

	// Token: 0x04002BF0 RID: 11248
	public PromptScript Prompt;
}
