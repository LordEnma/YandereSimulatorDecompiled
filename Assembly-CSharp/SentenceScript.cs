using System;
using UnityEngine;

// Token: 0x02000425 RID: 1061
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001CA9 RID: 7337 RVA: 0x0014FF56 File Offset: 0x0014E156
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x0400330F RID: 13071
	public UILabel Sentence;

	// Token: 0x04003310 RID: 13072
	public string[] Words;

	// Token: 0x04003311 RID: 13073
	public int ID;
}
