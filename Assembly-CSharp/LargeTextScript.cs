using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x0600210F RID: 8463 RVA: 0x001E4DBF File Offset: 0x001E2FBF
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002110 RID: 8464 RVA: 0x001E4DD9 File Offset: 0x001E2FD9
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040048A2 RID: 18594
	public UILabel Label;

	// Token: 0x040048A3 RID: 18595
	public string[] String;

	// Token: 0x040048A4 RID: 18596
	public int ID;
}
