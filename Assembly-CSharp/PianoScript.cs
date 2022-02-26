using System;
using UnityEngine;

// Token: 0x020003A5 RID: 933
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001AA9 RID: 6825 RVA: 0x00120108 File Offset: 0x0011E308
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

	// Token: 0x04002C1E RID: 11294
	public PromptScript Prompt;

	// Token: 0x04002C1F RID: 11295
	public AudioSource[] Notes;

	// Token: 0x04002C20 RID: 11296
	public int ID;
}
