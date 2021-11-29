using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C53 RID: 7251 RVA: 0x001488F0 File Offset: 0x00146AF0
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x0400321A RID: 12826
	public UILabel Sentence;

	// Token: 0x0400321B RID: 12827
	public string[] Words;

	// Token: 0x0400321C RID: 12828
	public int ID;
}
