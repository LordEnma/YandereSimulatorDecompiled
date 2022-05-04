using System;
using UnityEngine;

// Token: 0x02000424 RID: 1060
public class SentenceScript : MonoBehaviour
{
	// Token: 0x06001CA3 RID: 7331 RVA: 0x0014F2A2 File Offset: 0x0014D4A2
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}

	// Token: 0x040032FA RID: 13050
	public UILabel Sentence;

	// Token: 0x040032FB RID: 13051
	public string[] Words;

	// Token: 0x040032FC RID: 13052
	public int ID;
}
