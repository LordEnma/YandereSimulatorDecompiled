using System;
using UnityEngine;

// Token: 0x02000509 RID: 1289
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x0600215C RID: 8540 RVA: 0x001EB288 File Offset: 0x001E9488
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x04004980 RID: 18816
	public Animation MyAnimation;
}
