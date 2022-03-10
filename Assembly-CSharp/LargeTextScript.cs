using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x0600212E RID: 8494 RVA: 0x001E75E7 File Offset: 0x001E57E7
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x0600212F RID: 8495 RVA: 0x001E7601 File Offset: 0x001E5801
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040048EC RID: 18668
	public UILabel Label;

	// Token: 0x040048ED RID: 18669
	public string[] String;

	// Token: 0x040048EE RID: 18670
	public int ID;
}
