using System;
using UnityEngine;

// Token: 0x02000431 RID: 1073
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CC8 RID: 7368 RVA: 0x00155550 File Offset: 0x00153750
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x040033A6 RID: 13222
	public Transform Target;

	// Token: 0x040033A7 RID: 13223
	public float Speed;
}
