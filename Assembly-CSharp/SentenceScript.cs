using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C64 RID: 7268 RVA: 0x00149948 File Offset: 0x00147B48
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x04003252 RID: 12882
	public UILabel Sentence;

	// Token: 0x04003253 RID: 12883
	public string[] Words;

	// Token: 0x04003254 RID: 12884
	public int ID;
}
