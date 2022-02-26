using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002126 RID: 8486 RVA: 0x001E6BA8 File Offset: 0x001E4DA8
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040048CE RID: 18638
	public Animation MyAnimation;
}
