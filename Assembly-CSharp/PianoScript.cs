using System;
using UnityEngine;

// Token: 0x020003A1 RID: 929
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001A8D RID: 6797 RVA: 0x0011E5EC File Offset: 0x0011C7EC
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

	// Token: 0x04002BF1 RID: 11249
	public PromptScript Prompt;

	// Token: 0x04002BF2 RID: 11250
	public AudioSource[] Notes;

	// Token: 0x04002BF3 RID: 11251
	public int ID;
}
