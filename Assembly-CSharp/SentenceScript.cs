using System;
using UnityEngine;

// Token: 0x02000425 RID: 1061
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001CAA RID: 7338 RVA: 0x00150212 File Offset: 0x0014E412
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x04003317 RID: 13079
	public UILabel Sentence;

	// Token: 0x04003318 RID: 13080
	public string[] Words;

	// Token: 0x04003319 RID: 13081
	public int ID;
}
