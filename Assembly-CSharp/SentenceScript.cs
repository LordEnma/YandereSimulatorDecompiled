using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C7B RID: 7291 RVA: 0x0014C9DE File Offset: 0x0014ABDE
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x0400328D RID: 12941
	public UILabel Sentence;

	// Token: 0x0400328E RID: 12942
	public string[] Words;

	// Token: 0x0400328F RID: 12943
	public int ID;
}
