using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A6F RID: 6767 RVA: 0x0011BDEC File Offset: 0x00119FEC
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

	// Token: 0x04002BBF RID: 11199
	public GameObject JammingLines;

	// Token: 0x04002BC0 RID: 11200
	public PromptScript Prompt;
}
