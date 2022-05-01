using System;
using UnityEngine;

// Token: 0x020003A3 RID: 931
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001AA1 RID: 6817 RVA: 0x0011ECD0 File Offset: 0x0011CED0
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

	// Token: 0x04002C41 RID: 11329
	public GameObject JammingLines;

	// Token: 0x04002C42 RID: 11330
	public PromptScript Prompt;
}
