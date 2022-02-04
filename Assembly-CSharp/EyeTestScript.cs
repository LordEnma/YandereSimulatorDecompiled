using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002113 RID: 8467 RVA: 0x001E5910 File Offset: 0x001E3B10
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040048B2 RID: 18610
	public Animation MyAnimation;
}
