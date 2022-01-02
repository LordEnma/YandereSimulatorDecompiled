using System;
using UnityEngine;

// Token: 0x020003A1 RID: 929
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001A8F RID: 6799 RVA: 0x0011E8C8 File Offset: 0x0011CAC8
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

	// Token: 0x04002BF5 RID: 11253
	public PromptScript Prompt;

	// Token: 0x04002BF6 RID: 11254
	public AudioSource[] Notes;

	// Token: 0x04002BF7 RID: 11255
	public int ID;
}
