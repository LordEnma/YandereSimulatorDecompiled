using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C99 RID: 7321 RVA: 0x0014F47C File Offset: 0x0014D67C
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x04003308 RID: 13064
	public Transform Foot;
}
