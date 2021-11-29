using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001A85 RID: 6789 RVA: 0x0011DDAC File Offset: 0x0011BFAC
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

	// Token: 0x04002BC7 RID: 11207
	public PromptScript Prompt;

	// Token: 0x04002BC8 RID: 11208
	public AudioSource[] Notes;

	// Token: 0x04002BC9 RID: 11209
	public int ID;
}
