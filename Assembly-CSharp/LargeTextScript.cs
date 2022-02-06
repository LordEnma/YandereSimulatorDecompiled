using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x06002118 RID: 8472 RVA: 0x001E5B7B File Offset: 0x001E3D7B
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002119 RID: 8473 RVA: 0x001E5B95 File Offset: 0x001E3D95
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040048B6 RID: 18614
	public UILabel Label;

	// Token: 0x040048B7 RID: 18615
	public string[] String;

	// Token: 0x040048B8 RID: 18616
	public int ID;
}
