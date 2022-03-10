using System;
using UnityEngine;

// Token: 0x020002CC RID: 716
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x060014A8 RID: 5288 RVA: 0x000CB4F9 File Offset: 0x000C96F9
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x0400204E RID: 8270
	public Transform Target;
}
