using System;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x060020FD RID: 8445 RVA: 0x001E30F8 File Offset: 0x001E12F8
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x0400487D RID: 18557
	public Animation MyAnimation;
}
