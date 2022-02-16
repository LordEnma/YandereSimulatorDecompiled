using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x0600211D RID: 8477 RVA: 0x001E5FC8 File Offset: 0x001E41C8
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040048BE RID: 18622
	public Animation MyAnimation;
}
