using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SmoothLookAtScript : MonoBehaviour
{
	// Token: 0x06001CF3 RID: 7411 RVA: 0x00158474 File Offset: 0x00156674
	private void LateUpdate()
	{
		Quaternion b = Quaternion.LookRotation(this.Target.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.Speed);
	}

	// Token: 0x0400342A RID: 13354
	public Transform Target;

	// Token: 0x0400342B RID: 13355
	public float Speed;
}
