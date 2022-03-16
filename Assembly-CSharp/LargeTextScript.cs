using System;
using UnityEngine;

// Token: 0x02000504 RID: 1284
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x06002146 RID: 8518 RVA: 0x001E954F File Offset: 0x001E774F
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002147 RID: 8519 RVA: 0x001E9569 File Offset: 0x001E7769
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x0400494B RID: 18763
	public UILabel Label;

	// Token: 0x0400494C RID: 18764
	public string[] String;

	// Token: 0x0400494D RID: 18765
	public int ID;
}
