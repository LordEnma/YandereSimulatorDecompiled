using System;
using UnityEngine;

// Token: 0x020003A5 RID: 933
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001AB4 RID: 6836 RVA: 0x00120FF0 File Offset: 0x0011F1F0
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

	// Token: 0x04002C5D RID: 11357
	public PromptScript Prompt;

	// Token: 0x04002C5E RID: 11358
	public AudioSource[] Notes;

	// Token: 0x04002C5F RID: 11359
	public int ID;
}
