using System;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x060020EE RID: 8430 RVA: 0x001E1A2B File Offset: 0x001DFC2B
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x001E1A45 File Offset: 0x001DFC45
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x0400483F RID: 18495
	public UILabel Label;

	// Token: 0x04004840 RID: 18496
	public string[] String;

	// Token: 0x04004841 RID: 18497
	public int ID;
}
