using System;
using UnityEngine;

// Token: 0x02000431 RID: 1073
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CCA RID: 7370 RVA: 0x00155AD4 File Offset: 0x00153CD4
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x040033BC RID: 13244
	public Transform Target;

	// Token: 0x040033BD RID: 13245
	public float Speed;
}
