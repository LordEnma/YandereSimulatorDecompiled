using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CF9 RID: 7417 RVA: 0x00159128 File Offset: 0x00157328
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x0400343F RID: 13375
	public Transform Target;

	// Token: 0x04003440 RID: 13376
	public float Speed;
}
