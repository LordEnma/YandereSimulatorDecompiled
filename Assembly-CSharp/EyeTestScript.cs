using System;
using UnityEngine;

// Token: 0x02000509 RID: 1289
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x06002163 RID: 8547 RVA: 0x001EBCE4 File Offset: 0x001E9EE4
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x04004992 RID: 18834
	public Animation MyAnimation;
}
