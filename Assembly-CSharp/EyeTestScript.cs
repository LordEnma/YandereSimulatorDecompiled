using System;
using UnityEngine;

// Token: 0x0200050A RID: 1290
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x0600216D RID: 8557 RVA: 0x001ED26C File Offset: 0x001EB46C
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x040049A8 RID: 18856
	public Animation MyAnimation;
}
