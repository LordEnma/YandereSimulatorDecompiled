using System;
using UnityEngine;

// Token: 0x020003A4 RID: 932
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001AA0 RID: 6816 RVA: 0x0011F6F4 File Offset: 0x0011D8F4
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

	// Token: 0x04002C0E RID: 11278
	public PromptScript Prompt;

	// Token: 0x04002C0F RID: 11279
	public AudioSource[] Notes;

	// Token: 0x04002C10 RID: 11280
	public int ID;
}
