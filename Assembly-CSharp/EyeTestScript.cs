using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002111 RID: 8465 RVA: 0x001E55F8 File Offset: 0x001E37F8
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040048AC RID: 18604
	public Animation MyAnimation;
}
