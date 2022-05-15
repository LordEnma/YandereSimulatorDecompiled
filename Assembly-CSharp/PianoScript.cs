using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001AD1 RID: 6865 RVA: 0x00122A40 File Offset: 0x00120C40
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

	// Token: 0x04002C9A RID: 11418
	public PromptScript Prompt;

	// Token: 0x04002C9B RID: 11419
	public AudioSource[] Notes;

	// Token: 0x04002C9C RID: 11420
	public int ID;
}
