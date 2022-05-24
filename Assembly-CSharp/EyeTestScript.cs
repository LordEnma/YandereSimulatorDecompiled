using System;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002178 RID: 8568 RVA: 0x001EEE24 File Offset: 0x001ED024
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040049D8 RID: 18904
	public Animation MyAnimation;
}
