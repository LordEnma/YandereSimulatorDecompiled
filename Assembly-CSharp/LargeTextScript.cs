using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x06002102 RID: 8450 RVA: 0x001E374F File Offset: 0x001E194F
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002103 RID: 8451 RVA: 0x001E3769 File Offset: 0x001E1969
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x04004887 RID: 18567
	public UILabel Label;

	// Token: 0x04004888 RID: 18568
	public string[] String;

	// Token: 0x04004889 RID: 18569
	public int ID;
}
