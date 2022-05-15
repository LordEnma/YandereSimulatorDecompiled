using System;
using UnityEngine;

// Token: 0x0200050C RID: 1292
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x06002179 RID: 8569 RVA: 0x001EE923 File Offset: 0x001ECB23
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x0600217A RID: 8570 RVA: 0x001EE93D File Offset: 0x001ECB3D
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040049D0 RID: 18896
	public UILabel Label;

	// Token: 0x040049D1 RID: 18897
	public string[] String;

	// Token: 0x040049D2 RID: 18898
	public int ID;
}
