using System;
using UnityEngine;

// Token: 0x020003A9 RID: 937
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001AC3 RID: 6851 RVA: 0x00121848 File Offset: 0x0011FA48
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

	// Token: 0x04002C77 RID: 11383
	public PromptScript Prompt;

	// Token: 0x04002C78 RID: 11384
	public AudioSource[] Notes;

	// Token: 0x04002C79 RID: 11385
	public int ID;
}
