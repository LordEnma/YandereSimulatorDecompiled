using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CAA RID: 7338 RVA: 0x00152270 File Offset: 0x00150470
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x04003374 RID: 13172
	public Transform Target;

	// Token: 0x04003375 RID: 13173
	public float Speed;
}
