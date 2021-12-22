using System;
using UnityEngine;

// Token: 0x02000419 RID: 1049
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001C5B RID: 7259 RVA: 0x001491CC File Offset: 0x001473CC
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x04003245 RID: 12869
	public UILabel Sentence;

	// Token: 0x04003246 RID: 12870
	public string[] Words;

	// Token: 0x04003247 RID: 12871
	public int ID;
}
