using System;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x0600216E RID: 8558 RVA: 0x001ED1D7 File Offset: 0x001EB3D7
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x0600216F RID: 8559 RVA: 0x001ED1F1 File Offset: 0x001EB3F1
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040049A9 RID: 18857
	public UILabel Label;

	// Token: 0x040049AA RID: 18858
	public string[] String;

	// Token: 0x040049AB RID: 18859
	public int ID;
}
