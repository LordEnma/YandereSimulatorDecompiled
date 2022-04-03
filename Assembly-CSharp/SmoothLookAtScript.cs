using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CE1 RID: 7393 RVA: 0x0015753C File Offset: 0x0015573C
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x0400340D RID: 13325
	public Transform Target;

	// Token: 0x0400340E RID: 13326
	public float Speed;
}
