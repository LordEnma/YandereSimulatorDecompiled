using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CAC RID: 7340 RVA: 0x001526B4 File Offset: 0x001508B4
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x0400337B RID: 13179
	public Transform Target;

	// Token: 0x0400337C RID: 13180
	public float Speed;
}
