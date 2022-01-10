using System;
using UnityEngine;

// Token: 0x020003A3 RID: 931
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001A96 RID: 6806 RVA: 0x0011EC10 File Offset: 0x0011CE10
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

	// Token: 0x04002BFB RID: 11259
	public PromptScript Prompt;

	// Token: 0x04002BFC RID: 11260
	public AudioSource[] Notes;

	// Token: 0x04002BFD RID: 11261
	public int ID;
}
