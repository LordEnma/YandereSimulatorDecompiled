using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C66 RID: 7270 RVA: 0x0014B05A File Offset: 0x0014925A
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x04003257 RID: 12887
	public UILabel Sentence;

	// Token: 0x04003258 RID: 12888
	public string[] Words;

	// Token: 0x04003259 RID: 12889
	public int ID;
}
