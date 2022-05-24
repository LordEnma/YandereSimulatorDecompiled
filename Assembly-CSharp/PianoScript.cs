using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PianoScript : MonoBehaviour
{
	// Token: 0x06001AD2 RID: 6866 RVA: 0x00122C70 File Offset: 0x00120E70
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

	// Token: 0x04002CA1 RID: 11425
	public PromptScript Prompt;

	// Token: 0x04002CA2 RID: 11426
	public AudioSource[] Notes;

	// Token: 0x04002CA3 RID: 11427
	public int ID;
}
