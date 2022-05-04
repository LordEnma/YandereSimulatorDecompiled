using System;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x0600216F RID: 8559 RVA: 0x001ED2D3 File Offset: 0x001EB4D3
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002170 RID: 8560 RVA: 0x001ED2ED File Offset: 0x001EB4ED
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
