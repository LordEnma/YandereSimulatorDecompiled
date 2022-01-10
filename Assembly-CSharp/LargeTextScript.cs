using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x0600210D RID: 8461 RVA: 0x001E40EF File Offset: 0x001E22EF
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x001E4109 File Offset: 0x001E2309
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x0400489B RID: 18587
	public UILabel Label;

	// Token: 0x0400489C RID: 18588
	public string[] String;

	// Token: 0x0400489D RID: 18589
	public int ID;
}
