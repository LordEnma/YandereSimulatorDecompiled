using System;
using UnityEngine;

// Token: 0x0200050A RID: 1290
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x06002165 RID: 8549 RVA: 0x001EBD4B File Offset: 0x001E9F4B
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002166 RID: 8550 RVA: 0x001EBD65 File Offset: 0x001E9F65
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x04004993 RID: 18835
	public UILabel Label;

	// Token: 0x04004994 RID: 18836
	public string[] String;

	// Token: 0x04004995 RID: 18837
	public int ID;
}
