using System;
using UnityEngine;

// Token: 0x0200042B RID: 1067
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CA2 RID: 7330 RVA: 0x0015194C File Offset: 0x0014FB4C
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x04003349 RID: 13129
	public Transform Target;

	// Token: 0x0400334A RID: 13130
	public float Speed;
}
