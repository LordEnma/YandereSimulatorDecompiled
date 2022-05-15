using System;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002177 RID: 8567 RVA: 0x001EE8BC File Offset: 0x001ECABC
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040049CF RID: 18895
	public Animation MyAnimation;
}
