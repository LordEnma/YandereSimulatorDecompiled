using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C98 RID: 7320 RVA: 0x0014E68A File Offset: 0x0014C88A
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x040032E0 RID: 13024
	public UILabel Sentence;

	// Token: 0x040032E1 RID: 13025
	public string[] Words;

	// Token: 0x040032E2 RID: 13026
	public int ID;
}
