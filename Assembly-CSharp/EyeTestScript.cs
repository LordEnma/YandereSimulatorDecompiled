using System;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002100 RID: 8448 RVA: 0x001E36E8 File Offset: 0x001E18E8
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x04004886 RID: 18566
	public Animation MyAnimation;
}
