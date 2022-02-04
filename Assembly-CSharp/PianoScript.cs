using System;
using UnityEngine;

// Token: 0x020003A3 RID: 931
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001A97 RID: 6807 RVA: 0x0011F2C0 File Offset: 0x0011D4C0
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

	// Token: 0x04002C05 RID: 11269
	public PromptScript Prompt;

	// Token: 0x04002C06 RID: 11270
	public AudioSource[] Notes;

	// Token: 0x04002C07 RID: 11271
	public int ID;
}
