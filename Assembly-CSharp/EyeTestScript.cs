using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x0600210D RID: 8461 RVA: 0x001E4D58 File Offset: 0x001E2F58
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040048A1 RID: 18593
	public Animation MyAnimation;
}
