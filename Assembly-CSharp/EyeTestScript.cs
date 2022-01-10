using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x0600210B RID: 8459 RVA: 0x001E4088 File Offset: 0x001E2288
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x0400489A RID: 18586
	public Animation MyAnimation;
}
