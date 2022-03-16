using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CD7 RID: 7383 RVA: 0x001569E0 File Offset: 0x00154BE0
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x040033F1 RID: 13297
	public Transform Target;

	// Token: 0x040033F2 RID: 13298
	public float Speed;
}
