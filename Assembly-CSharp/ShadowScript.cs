using System;
using UnityEngine;

// Token: 0x02000426 RID: 1062
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001CA3 RID: 7331 RVA: 0x0014FFA0 File Offset: 0x0014E1A0
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x04003324 RID: 13092
	public Transform Foot;
}
