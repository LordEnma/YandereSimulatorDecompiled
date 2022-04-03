using System;
using UnityEngine;

// Token: 0x02000508 RID: 1288
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002154 RID: 8532 RVA: 0x001EAD58 File Offset: 0x001E8F58
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x0400497C RID: 18812
	public Animation MyAnimation;
}
