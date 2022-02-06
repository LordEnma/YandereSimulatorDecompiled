using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C69 RID: 7273 RVA: 0x0014B72A File Offset: 0x0014992A
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x04003261 RID: 12897
	public UILabel Sentence;

	// Token: 0x04003262 RID: 12898
	public string[] Words;

	// Token: 0x04003263 RID: 12899
	public int ID;
}
