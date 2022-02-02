using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CB6 RID: 7350 RVA: 0x00154500 File Offset: 0x00152700
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x0400338C RID: 13196
	public Transform Target;

	// Token: 0x0400338D RID: 13197
	public float Speed;
}
