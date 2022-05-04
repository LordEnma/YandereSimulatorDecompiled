using System;
using UnityEngine;

// Token: 0x020003A9 RID: 937
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001ACB RID: 6859 RVA: 0x001220DC File Offset: 0x001202DC
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

	// Token: 0x04002C88 RID: 11400
	public PromptScript Prompt;

	// Token: 0x04002C89 RID: 11401
	public AudioSource[] Notes;

	// Token: 0x04002C8A RID: 11402
	public int ID;
}
