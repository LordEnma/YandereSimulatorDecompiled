using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CFA RID: 7418 RVA: 0x001593E4 File Offset: 0x001575E4
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x04003447 RID: 13383
	public Transform Target;

	// Token: 0x04003448 RID: 13384
	public float Speed;
}
