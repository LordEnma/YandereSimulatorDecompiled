using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x06002128 RID: 8488 RVA: 0x001E6C0F File Offset: 0x001E4E0F
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002129 RID: 8489 RVA: 0x001E6C29 File Offset: 0x001E4E29
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040048CF RID: 18639
	public UILabel Label;

	// Token: 0x040048D0 RID: 18640
	public string[] String;

	// Token: 0x040048D1 RID: 18641
	public int ID;
}
