using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C79 RID: 7289 RVA: 0x0014C4A2 File Offset: 0x0014A6A2
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x04003277 RID: 12919
	public UILabel Sentence;

	// Token: 0x04003278 RID: 12920
	public string[] Words;

	// Token: 0x04003279 RID: 12921
	public int ID;
}
