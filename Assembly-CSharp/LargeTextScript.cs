using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x0600211F RID: 8479 RVA: 0x001E602F File Offset: 0x001E422F
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002120 RID: 8480 RVA: 0x001E6049 File Offset: 0x001E4249
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040048BF RID: 18623
	public UILabel Label;

	// Token: 0x040048C0 RID: 18624
	public string[] String;

	// Token: 0x040048C1 RID: 18625
	public int ID;
}
