using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CBF RID: 7359 RVA: 0x00154AA4 File Offset: 0x00152CA4
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x04003396 RID: 13206
	public Transform Target;

	// Token: 0x04003397 RID: 13207
	public float Speed;
}
