using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x06002113 RID: 8467 RVA: 0x001E565F File Offset: 0x001E385F
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x001E5679 File Offset: 0x001E3879
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040048AD RID: 18605
	public UILabel Label;

	// Token: 0x040048AE RID: 18606
	public string[] String;

	// Token: 0x040048AF RID: 18607
	public int ID;
}
