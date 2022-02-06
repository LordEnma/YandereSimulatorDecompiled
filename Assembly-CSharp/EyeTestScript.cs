using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002116 RID: 8470 RVA: 0x001E5B14 File Offset: 0x001E3D14
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040048B5 RID: 18613
	public Animation MyAnimation;
}
