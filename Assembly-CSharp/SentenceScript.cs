using System;
using UnityEngine;

// Token: 0x02000419 RID: 1049
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C5D RID: 7261 RVA: 0x001495D4 File Offset: 0x001477D4
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x0400324C RID: 12876
	public UILabel Sentence;

	// Token: 0x0400324D RID: 12877
	public string[] Words;

	// Token: 0x0400324E RID: 12878
	public int ID;
}
