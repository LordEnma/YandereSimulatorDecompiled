using System;
using UnityEngine;

// Token: 0x020003A3 RID: 931
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001A99 RID: 6809 RVA: 0x0011F3D8 File Offset: 0x0011D5D8
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

	// Token: 0x04002C08 RID: 11272
	public PromptScript Prompt;

	// Token: 0x04002C09 RID: 11273
	public AudioSource[] Notes;

	// Token: 0x04002C0A RID: 11274
	public int ID;
}
