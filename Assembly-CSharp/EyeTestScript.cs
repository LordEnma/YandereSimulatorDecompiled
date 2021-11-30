using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class EyeTestScript : MonoBehaviour
{
	// Token: 0x060020EC RID: 8428 RVA: 0x001E19C4 File Offset: 0x001DFBC4
	private void Start()
	{
		this.MyAnimation["moodyEyes_00"].layer = 1;
		this.MyAnimation.Play("moodyEyes_00");
		this.MyAnimation["moodyEyes_00"].weight = 1f;
		this.MyAnimation.Play("moodyEyes_00");
	}

	// Token: 0x0400483E RID: 18494
	public Animation MyAnimation;
}
