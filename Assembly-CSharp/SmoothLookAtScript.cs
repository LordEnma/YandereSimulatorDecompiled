using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CEC RID: 7404 RVA: 0x00157C6C File Offset: 0x00155E6C
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x0400341B RID: 13339
	public Transform Target;

	// Token: 0x0400341C RID: 13340
	public float Speed;
}
