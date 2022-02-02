using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C67 RID: 7271 RVA: 0x0014B48E File Offset: 0x0014968E
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x0400325D RID: 12893
	public UILabel Sentence;

	// Token: 0x0400325E RID: 12894
	public string[] Words;

	// Token: 0x0400325F RID: 12895
	public int ID;
}
