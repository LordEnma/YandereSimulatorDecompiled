using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CB3 RID: 7347 RVA: 0x001529B8 File Offset: 0x00150BB8
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x04003381 RID: 13185
	public Transform Target;

	// Token: 0x04003382 RID: 13186
	public float Speed;
}
