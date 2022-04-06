using System;
using UnityEngine;

// Token: 0x0200050A RID: 1290
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x0600215E RID: 8542 RVA: 0x001EB2EF File Offset: 0x001E94EF
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x0600215F RID: 8543 RVA: 0x001EB309 File Offset: 0x001E9509
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x04004981 RID: 18817
	public UILabel Label;

	// Token: 0x04004982 RID: 18818
	public string[] String;

	// Token: 0x04004983 RID: 18819
	public int ID;
}
