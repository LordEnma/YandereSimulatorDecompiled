using System;
using UnityEngine;

// Token: 0x020003A5 RID: 933
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001AAA RID: 6826 RVA: 0x001204E0 File Offset: 0x0011E6E0
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount < 1f && this.Prompt.Circle[0].fillAmount > 0f)
		{
			this.Prompt.Circle[0].fillAmount = 0f;
			this.Notes[this.ID].Play();
			this.ID++;
			if (this.ID == this.Notes.Length)
			{
				this.ID = 0;
			}
		}
	}

	// Token: 0x04002C34 RID: 11316
	public PromptScript Prompt;

	// Token: 0x04002C35 RID: 11317
	public AudioSource[] Notes;

	// Token: 0x04002C36 RID: 11318
	public int ID;
}
