using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A81 RID: 6785 RVA: 0x0011CD38 File Offset: 0x0011AF38
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

	// Token: 0x04002BD9 RID: 11225
	public GameObject JammingLines;

	// Token: 0x04002BDA RID: 11226
	public PromptScript Prompt;
}
