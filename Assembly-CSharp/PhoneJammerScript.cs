using System;
using UnityEngine;

// Token: 0x020003A4 RID: 932
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001AA7 RID: 6823 RVA: 0x0011F600 File Offset: 0x0011D800
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

	// Token: 0x04002C53 RID: 11347
	public GameObject JammingLines;

	// Token: 0x04002C54 RID: 11348
	public PromptScript Prompt;
}
