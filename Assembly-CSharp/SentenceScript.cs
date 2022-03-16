using System;
using UnityEngine;

// Token: 0x0200041F RID: 1055
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C88 RID: 7304 RVA: 0x0014D882 File Offset: 0x0014BA82
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x040032C1 RID: 12993
	public UILabel Sentence;

	// Token: 0x040032C2 RID: 12994
	public string[] Words;

	// Token: 0x040032C3 RID: 12995
	public int ID;
}
