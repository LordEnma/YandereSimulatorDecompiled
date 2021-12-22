using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x060020FF RID: 8447 RVA: 0x001E315F File Offset: 0x001E135F
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x001E3179 File Offset: 0x001E1379
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x0400487E RID: 18558
	public UILabel Label;

	// Token: 0x0400487F RID: 18559
	public string[] String;

	// Token: 0x04004880 RID: 18560
	public int ID;
}
