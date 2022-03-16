using System;
using UnityEngine;

// Token: 0x020002CC RID: 716
public class FloatAbovePointScript : MonoBehaviour
{
	// Token: 0x060014AB RID: 5291 RVA: 0x000CB969 File Offset: 0x000C9B69
	private void Update()
	{
		base.transform.position = this.Target.position + new Vector3(0f, 0.15f, 0f);
	}

	// Token: 0x0400205E RID: 8286
	public Transform Target;
}
