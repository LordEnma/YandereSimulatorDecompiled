using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A93 RID: 6803 RVA: 0x0011E280 File Offset: 0x0011C480
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

	// Token: 0x04002C2D RID: 11309
	public GameObject JammingLines;

	// Token: 0x04002C2E RID: 11310
	public PromptScript Prompt;
}
