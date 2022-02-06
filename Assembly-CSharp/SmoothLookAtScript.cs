using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CB8 RID: 7352 RVA: 0x0015479C File Offset: 0x0015299C
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x04003390 RID: 13200
	public Transform Target;

	// Token: 0x04003391 RID: 13201
	public float Speed;
}
