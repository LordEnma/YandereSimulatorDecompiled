using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C70 RID: 7280 RVA: 0x0014BA2A File Offset: 0x00149C2A
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x04003267 RID: 12903
	public UILabel Sentence;

	// Token: 0x04003268 RID: 12904
	public string[] Words;

	// Token: 0x04003269 RID: 12905
	public int ID;
}
