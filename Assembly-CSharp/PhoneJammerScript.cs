using System;
using UnityEngine;

// Token: 0x020003A3 RID: 931
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A9D RID: 6813 RVA: 0x0011E734 File Offset: 0x0011C934
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

	// Token: 0x04002C38 RID: 11320
	public GameObject JammingLines;

	// Token: 0x04002C39 RID: 11321
	public PromptScript Prompt;
}
