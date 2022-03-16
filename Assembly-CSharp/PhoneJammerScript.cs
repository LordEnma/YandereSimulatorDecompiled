using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A8C RID: 6796 RVA: 0x0011DC20 File Offset: 0x0011BE20
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

	// Token: 0x04002C18 RID: 11288
	public GameObject JammingLines;

	// Token: 0x04002C19 RID: 11289
	public PromptScript Prompt;
}
