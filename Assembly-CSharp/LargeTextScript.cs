using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x06002115 RID: 8469 RVA: 0x001E5977 File Offset: 0x001E3B77
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002116 RID: 8470 RVA: 0x001E5991 File Offset: 0x001E3B91
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040048B3 RID: 18611
	public UILabel Label;

	// Token: 0x040048B4 RID: 18612
	public string[] String;

	// Token: 0x040048B5 RID: 18613
	public int ID;
}
