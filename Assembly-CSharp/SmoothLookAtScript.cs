using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CB5 RID: 7349 RVA: 0x001540CC File Offset: 0x001522CC
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x04003386 RID: 13190
	public Transform Target;

	// Token: 0x04003387 RID: 13191
	public float Speed;
}
