using System;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002144 RID: 8516 RVA: 0x001E94E8 File Offset: 0x001E76E8
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x0400494A RID: 18762
	public Animation MyAnimation;
}
