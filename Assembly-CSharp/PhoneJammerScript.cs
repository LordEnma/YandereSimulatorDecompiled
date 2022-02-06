using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A71 RID: 6769 RVA: 0x0011C008 File Offset: 0x0011A208
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

	// Token: 0x04002BC3 RID: 11203
	public GameObject JammingLines;

	// Token: 0x04002BC4 RID: 11204
	public PromptScript Prompt;
}
