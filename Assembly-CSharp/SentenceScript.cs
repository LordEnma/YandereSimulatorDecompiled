using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C92 RID: 7314 RVA: 0x0014E3A6 File Offset: 0x0014C5A6
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x040032DD RID: 13021
	public UILabel Sentence;

	// Token: 0x040032DE RID: 13022
	public string[] Words;

	// Token: 0x040032DF RID: 13023
	public int ID;
}
