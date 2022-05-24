using System;
using UnityEngine;

// Token: 0x020003A4 RID: 932
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001AA8 RID: 6824 RVA: 0x0011F830 File Offset: 0x0011DA30
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

	// Token: 0x04002C5A RID: 11354
	public GameObject JammingLines;

	// Token: 0x04002C5B RID: 11355
	public PromptScript Prompt;
}
