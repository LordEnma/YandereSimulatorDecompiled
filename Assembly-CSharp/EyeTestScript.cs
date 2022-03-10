using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x0600212C RID: 8492 RVA: 0x001E7580 File Offset: 0x001E5780
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040048EB RID: 18667
	public Animation MyAnimation;
}
