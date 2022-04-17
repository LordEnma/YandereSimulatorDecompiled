using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C9C RID: 7324 RVA: 0x0014EA9A File Offset: 0x0014CC9A
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x040032EB RID: 13035
	public UILabel Sentence;

	// Token: 0x040032EC RID: 13036
	public string[] Words;

	// Token: 0x040032ED RID: 13037
	public int ID;
}
