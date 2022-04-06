using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CE8 RID: 7400 RVA: 0x0015785C File Offset: 0x00155A5C
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x04003410 RID: 13328
	public Transform Target;

	// Token: 0x04003411 RID: 13329
	public float Speed;
}
