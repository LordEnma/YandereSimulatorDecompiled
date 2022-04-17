using System;
using UnityEngine;

// Token: 0x020003A9 RID: 937
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001AC7 RID: 6855 RVA: 0x00121B74 File Offset: 0x0011FD74
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

	// Token: 0x04002C7F RID: 11391
	public PromptScript Prompt;

	// Token: 0x04002C80 RID: 11392
	public AudioSource[] Notes;

	// Token: 0x04002C81 RID: 11393
	public int ID;
}
