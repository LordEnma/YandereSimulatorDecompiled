using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001ABD RID: 6845 RVA: 0x0012169C File Offset: 0x0011F89C
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

	// Token: 0x04002C74 RID: 11380
	public PromptScript Prompt;

	// Token: 0x04002C75 RID: 11381
	public AudioSource[] Notes;

	// Token: 0x04002C76 RID: 11382
	public int ID;
}
